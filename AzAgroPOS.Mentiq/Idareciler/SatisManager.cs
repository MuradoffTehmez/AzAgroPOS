// Fayl: AzAgroPOS.Mentiq/Idareciler/SatisManager.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using System.Linq;

namespace AzAgroPOS.Mentiq.Idareciler;
/// <summary>
/// Satışlarla bağlı əməliyyatları idarə edən menecer.
/// </summary>
public class SatisManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly NisyeManager _nisyeManager;
    private readonly StokHareketiManager _stokHareketiManager;

    public SatisManager(IUnitOfWork unitOfWork, NisyeManager nisyeManager, StokHareketiManager stokHareketiManager)
    {
        _unitOfWork = unitOfWork;
        _nisyeManager = nisyeManager;
        _stokHareketiManager = stokHareketiManager;
    }

    /// <summary>
    /// Yeni bir satış yaradır, stokları azaldır və nisyədirsə borcu qeydə alır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<Satis>> SatisYaratAsync(SatisYaratDto satisDto)
    {
        Logger.MelumatYaz("Satış yaratma əməliyyatı başlayır");
        try
        {
            if (satisDto.SebetElementleri == null || !satisDto.SebetElementleri.Any())
            {
                Logger.XəbərdarlıqYaz("Satış üçün səbət boşdur");
                return EmeliyyatNeticesi<Satis>.Ugursuz("Satış üçün səbət boşdur.");
            }

            if (satisDto.OdenisMetodu == OdenisMetodu.Nisyə && !satisDto.MusteriId.HasValue)
            {
                Logger.XəbərdarlıqYaz("Nisyə satış üçün müştəri seçilməlidir");
                return EmeliyyatNeticesi<Satis>.Ugursuz("Nisyə satış üçün müştəri seçilməlidir.");
            }

            // Stok yoxlaması - Batch query (N+1 problemini həll edir)
            List<int> mehsulIdleri = satisDto.SebetElementleri.Select(e => e.MehsulId).ToList();
            Dictionary<int, Mehsul> mehsullar = (await _unitOfWork.Mehsullar.AxtarAsync(m => mehsulIdleri.Contains(m.Id)))
                .ToDictionary(m => m.Id);

            foreach (SatisSebetiElementiDto element in satisDto.SebetElementleri)
            {
                if (!mehsullar.TryGetValue(element.MehsulId, out Mehsul? mehsul) || mehsul.MovcudSay < element.Miqdar)
                {
                    Logger.XəbərdarlıqYaz($"'{element.MehsulAdi}' üçün stokda kifayət qədər məhsul yoxdur");
                    return EmeliyyatNeticesi<Satis>.Ugursuz($"'{element.MehsulAdi}' üçün stokda kifayət qədər məhsul yoxdur.");
                }
            }

            // Tranzaksiyanı başladırıq
            await _unitOfWork.BeginTransactionAsync();

            Satis satis = new()
            {
                Tarix = System.DateTime.Now,
                OdenisMetodu = satisDto.OdenisMetodu,
                UmumiMebleg = satisDto.SebetElementleri.Sum(e => e.UmumiMebleg),
                NovbeId = satisDto.NovbeId,
                MusteriId = satisDto.MusteriId
            };

            await _unitOfWork.Satislar.ElaveEtAsync(satis);
            await _unitOfWork.EmeliyyatiTesdiqleAsync(); // Satış ID-sini əldə etmək üçün

            // Satış detallarını əlavə et və stok hərəkətlərini qeydə al
            foreach (SatisSebetiElementiDto element in satisDto.SebetElementleri)
            {
                satis.SatisDetallari.Add(new SatisDetali
                {
                    MehsulId = element.MehsulId,
                    Miqdar = element.Miqdar,
                    Qiymet = element.VahidinQiymeti,
                    UmumiMebleg = element.Miqdar * element.VahidinQiymeti
                });

                // Stok hərəkətini qeydə al (Çıxış)
                EmeliyyatNeticesi<int> stokNeticesi = await _stokHareketiManager.StokHareketiQeydeAlAsync(
                    StokHareketTipi.Cixis,
                    SenedNovu.Satis,
                    satis.Id,
                    element.MehsulId,
                    (int)element.Miqdar,
                    element.VahidinQiymeti, // Alış qiyməti (satışda bu satış qiymətidir, amma metod parametr olaraq istəyir)
                    element.VahidinQiymeti, // Satış qiyməti
                    $"Satış: ID={satis.Id}",
                    null // İstifadəçi ID-si
                );

                if (!stokNeticesi.UgurluDur)
                {
                    Logger.XəbərdarlıqYaz($"Stok hərəkəti qeydə alınarkən xəta: {stokNeticesi.Mesaj}");
                    await _unitOfWork.RollbackTransactionAsync();
                    return EmeliyyatNeticesi<Satis>.Ugursuz($"Stok hərəkəti qeydə alınarkən xəta: {stokNeticesi.Mesaj}");
                }
            }

            // Əgər nisyədirsə, borcu qeydə al
            if (satis.OdenisMetodu == OdenisMetodu.Nisyə)
            {
                EmeliyyatNeticesi nisyeNetice = await _nisyeManager.NisyeyeSatisElaveEtAsync(satis);
                if (!nisyeNetice.UgurluDur)
                {
                    Logger.XetaYaz(new Exception(nisyeNetice.Mesaj), "Nisyə qeydiyatı zamanı xəta");
                    await _unitOfWork.RollbackTransactionAsync();
                    return EmeliyyatNeticesi<Satis>.Ugursuz($"Nisyə qeydiyatı zamanı xəta: {nisyeNetice.Mesaj}");
                }
            }

            // Vacib: Bütün dəyişiklikləri təsdiqlə
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            // Tranzaksiyanı tamamlayırıq
            await _unitOfWork.CommitTransactionAsync();

            Logger.MelumatYaz("Satış uğurla yaradıldı");
            return EmeliyyatNeticesi<Satis>.Ugurlu(satis);
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            Logger.XetaYaz(ex, "Satış yaratma əməliyyatı zamanı istisna baş verdi");
            return EmeliyyatNeticesi<Satis>.Ugursuz("Satış yaratma əməliyyatı zamanı istisna baş verdi: " + ex.Message);
        }
    }

    /// <summary>
    /// Satış nömrəsinə görə satış məlumatlarını qaytarır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<SatisQebzDto>> SatisGetirAsync(string satisNomresi)
    {
        Logger.MelumatYaz($"Satış məlumatları əldə edilir: {satisNomresi}");
        try
        {
            if (string.IsNullOrWhiteSpace(satisNomresi))
            {
                return EmeliyyatNeticesi<SatisQebzDto>.Ugursuz("Satış nömrəsi boş ola bilməz.");
            }

            string cleaned = satisNomresi.Trim();
            string[] toRemove = { "ÇEK-", "ÇEK", "Çək-", "Çək", "QƏBZ-", "QƏBZ", "Qebz-", "Qebz", "№", "No.", "No", "Nə", "-", " " };
            foreach (var item in toRemove)
            {
                cleaned = cleaned.Replace(item, "", StringComparison.OrdinalIgnoreCase);
            }

            // Satış nömrəsi formatı kontrolü
            if (string.IsNullOrEmpty(cleaned) || !int.TryParse(cleaned, out int satisId))
            {
                Logger.XəbərdarlıqYaz("Yanlış satış nömrəsi formatı");
                return EmeliyyatNeticesi<SatisQebzDto>.Ugursuz("Yanlış satış nömrəsi formatı.");
            }

            // Eager Loading: Satışı SatisDetallari və onların Mehsul məlumatları ilə yüklə
            Satis satis = await _unitOfWork.Satislar.GetirAsync(satisId, s => s.SatisDetallari.Select(d => d.Mehsul));
            if (satis == null)
            {
                Logger.XəbərdarlıqYaz("Satış tapılmadı");
                return EmeliyyatNeticesi<SatisQebzDto>.Ugursuz("Satış tapılmadı.");
            }

            // Satış detallarını və məhsul məlumatlarını map et (artıq database query yoxdur)
            List<SatisSebetiElementiDto> sebetElementleri = satis.SatisDetallari
                .Where(detali => detali.Mehsul != null)
                .Select(detali => new SatisSebetiElementiDto
                {
                    MehsulId = detali.MehsulId,
                    MehsulAdi = detali.Mehsul.Ad,
                    Miqdar = detali.Miqdar,
                    VahidinQiymeti = detali.Qiymet
                })
                .ToList();

            SatisQebzDto satisDto = new()
            {
                SatisId = satis.Id,
                Tarix = satis.Tarix,
                SatilanMehsullar = sebetElementleri
            };

            Logger.MelumatYaz("Satış məlumatları uğurla əldə edildi");
            return EmeliyyatNeticesi<SatisQebzDto>.Ugurlu(satisDto);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Satış məlumatları əldə edilərkən istisna baş verdi");
            return EmeliyyatNeticesi<SatisQebzDto>.Ugursuz("Satış məlumatları əldə edilərkən istisna baş verdi: " + ex.Message);
        }
    }

    /// <summary>
    /// Qaytarma əməliyyatını həyata keçirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<bool>> QaytarmaEmeliyyatiAsync(List<SatisSebetiElementiDto> qaytarilanMehsullar, int satisId, string sebeb, int kassirId, int? aktivNovbeId)
    {
        Logger.MelumatYaz("Qaytarma əməliyyatı başlayır");
        try
        {
            // Əsas satışı tap
            Satis satis = await _unitOfWork.Satislar.GetirAsync(satisId);
            if (satis == null)
            {
                Logger.XəbərdarlıqYaz("Satış tapılmadı");
                return EmeliyyatNeticesi<bool>.Ugursuz("Satış tapılmadı.");
            }

            // Tranzaksiyanı başladırıq
            await _unitOfWork.BeginTransactionAsync();

            // Qaytarma obyektini yarat
            Qaytarma qaytarma = new()
            {
                Tarix = DateTime.Now,
                SatisId = satisId,
                Sebeb = sebeb,
                KassirId = kassirId,
                UmumiMebleg = qaytarilanMehsullar.Sum(e => e.UmumiMebleg)
            };

            // Qaytarma qeydini əlavə et
            await _unitOfWork.Qaytarmalar.ElaveEtAsync(qaytarma);
            await _unitOfWork.EmeliyyatiTesdiqleAsync(); // Qaytarma ID-sini əldə etmək üçün

            // Qaytarma detallarını əlavə et və stok hərəkətlərini qeydə al
            foreach (SatisSebetiElementiDto element in qaytarilanMehsullar)
            {
                // Qaytarma detallarını əlavə et
                qaytarma.QaytarmaDetallari.Add(new QaytarmaDetali
                {
                    MehsulId = element.MehsulId,
                    Miqdar = element.Miqdar,
                    Qiymet = element.VahidinQiymeti,
                    UmumiMebleg = element.UmumiMebleg
                });

                // Stok hərəkətini qeydə al (Daxilolma - qaytarma)
                EmeliyyatNeticesi<int> stokNeticesi = await _stokHareketiManager.StokHareketiQeydeAlAsync(
                    StokHareketTipi.Daxilolma,
                    SenedNovu.Qaytarma,
                    qaytarma.Id,
                    element.MehsulId,
                    (int)element.Miqdar,
                    element.VahidinQiymeti, // alisQiymeti
                    element.VahidinQiymeti, // satisQiymeti
                    $"Qaytarma: ID={qaytarma.Id}, Səbəb: {sebeb}",
                    kassirId
                );

                if (!stokNeticesi.UgurluDur)
                {
                    Logger.XəbərdarlıqYaz($"Stok hərəkəti qeydə alınarkən xəta: {stokNeticesi.Mesaj}");
                    await _unitOfWork.RollbackTransactionAsync();
                    return EmeliyyatNeticesi<bool>.Ugursuz($"Stok hərəkəti qeydə alınarkən xəta: {stokNeticesi.Mesaj}");
                }
            }

            // Müştərinin borcunu azalt (əgər satış nisyə idisə)
            if (satis.OdenisMetodu == OdenisMetodu.Nisyə && satis.MusteriId.HasValue)
            {
                Musteri musteri = await _unitOfWork.Musteriler.GetirAsync(satis.MusteriId.Value);
                if (musteri != null)
                {
                    musteri.UmumiBorc -= qaytarma.UmumiMebleg;
                    _unitOfWork.Musteriler.Yenile(musteri);

                    // Nisyə hərəkəti yarat
                    NisyeHereketi nisyeHereketi = new()
                    {
                        MusteriId = satis.MusteriId.Value,
                        Mebleg = qaytarma.UmumiMebleg,
                        Tarix = DateTime.Now,
                        EmeliyyatNovu = EmeliyyatNovu.Qaytarma,
                        SatisId = 0 // Qaytarma ID-si əlavə edildikdən sonra təyin ediləcək
                    };
                    await _unitOfWork.NisyeHereketleri.ElaveEtAsync(nisyeHereketi);
                }
            }

            // Kassirin aktiv növbəsindəki nağd və ya kart məbləğini azalt
            if (aktivNovbeId.HasValue)
            {
                Novbe novbe = await _unitOfWork.Novbeler.GetirAsync(aktivNovbeId.Value);
                if (novbe != null)
                {
                    if (satis.OdenisMetodu == OdenisMetodu.Nağd)
                    {
                        novbe.FaktikiMebleg -= qaytarma.UmumiMebleg;
                    }
                    else if (satis.OdenisMetodu == OdenisMetodu.Kart)
                    {
                        // Kart ödənişləri üçün lazımi dəyişikliklər
                        // Bu implementasiya şirkətin daxili qaydalarına görə dəyişə bilər
                    }
                    _unitOfWork.Novbeler.Yenile(novbe);
                }
            }

            // Bütün əməliyyatları təsdiqlə
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            // Tranzaksiyanı tamamlayırıq
            await _unitOfWork.CommitTransactionAsync();

            Logger.MelumatYaz("Qaytarma əməliyyatı uğurla tamamlandı");
            return EmeliyyatNeticesi<bool>.Ugurlu(true);
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            Logger.XetaYaz(ex, "Qaytarma əməliyyatı zamanı istisna baş verdi");
            return EmeliyyatNeticesi<bool>.Ugursuz("Qaytarma əməliyyatı zamanı istisna baş verdi: " + ex.Message);
        }
    }

    /// <summary>
    /// Səhifələnmiş satış siyahısını əldə edir.
    /// Diqqət: Bu metod böyük məlumat bazaları üçün əlverişlidir.
    /// </summary>
    /// <param name="parametrler">Səhifələmə parametrləri</param>
    /// <returns>Səhifələnmiş satış məlumatları</returns>
    public async Task<EmeliyyatNeticesi<SehifelenmisMelumat<SatisDto>>> SatislariSehifelenmisGetirAsync(SehifeParametrleri parametrler)
    {
        Logger.MelumatYaz($"Səhifələnmiş satışlar əldə edilir - Səhifə: {parametrler.SehifeNomresi}, Ölçü: {parametrler.SehifeOlcusu}");
        try
        {
            (IEnumerable<Satis>? satislar, int umumiSay) = await _unitOfWork.Satislar.SehifelenmisGetirAsync(
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu,
                s => !s.Silinib);

            List<SatisDto> satisDtolar = satislar.Select(s => new SatisDto
            {
                Id = s.Id,
                Tarix = s.Tarix,
                OdenisMetodu = s.OdenisMetodu,
                UmumiMebleg = s.UmumiMebleg,
                NovbeId = s.NovbeId,
                MusteriId = s.MusteriId
            }).ToList();

            SehifelenmisMelumat<SatisDto> sehifelenmis = new(
                satisDtolar,
                umumiSay,
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu);

            Logger.MelumatYaz($"Səhifələnmiş satışlar uğurla əldə edildi - {satisDtolar.Count}/{umumiSay}");
            return EmeliyyatNeticesi<SehifelenmisMelumat<SatisDto>>.Ugurlu(sehifelenmis);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Səhifələnmiş satışlar əldə edilərkən istisna baş verdi");
            return EmeliyyatNeticesi<SehifelenmisMelumat<SatisDto>>.Ugursuz($"Səhifələnmiş satışlar əldə edilərkən xəta: {ex.Message}");
        }
    }
}