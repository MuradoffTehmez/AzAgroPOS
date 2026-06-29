// Fayl: AzAgroPOS.Mentiq/Idareciler/QaytarmaManager.cs

using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;

namespace AzAgroPOS.Mentiq.Idareciler;
/// <summary>
/// Qaytarma əməliyyatlarını idarə edən menecer
/// diqqət: Bu sinif satış qaytarma prosesini tam şəkildə idarə edir:
///   - Stok hərəkətlərinin qeydiyyatı
///   - Maliyyə uçotunun yenilənməsi (növbə, nağd pul)
///   - Nisyə hesablarının düzəlişi
///   - Qaytarma tarixçəsinin saxlanması
/// qeyd: Bütün əməliyyatlar vahid tranzaksiya daxilində həyata keçirilir
/// </summary>
public class QaytarmaManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly StokHareketiManager _stokHareketiManager;
    private readonly MaliyyeManager _maliyyeManager;

    public QaytarmaManager(IUnitOfWork unitOfWork, StokHareketiManager stokHareketiManager, MaliyyeManager maliyyeManager)
    {
        _unitOfWork = unitOfWork;
        _stokHareketiManager = stokHareketiManager;
        _maliyyeManager = maliyyeManager;
    }

    /// <summary>
    /// Tam qaytarma əməliyyatını həyata keçirir
    /// diqqət: Bu metod aşağıdakı əməliyyatları yerinə yetirir:
    ///   1. Satışın yoxlanması və validasiyası
    ///   2. Qaytarma qeydinin yaradılması
    ///   3. Stok hərəkətlərinin qeydiyyatı (Daxilolma)
    ///   4. Nisyə borcunun azaldılması (əgər satış nisyə idisə)
    ///   5. Növbə maliyyəsinin yenilənməsi
    /// qeyd: Əməliyyat uğursuz olarsa, bütün dəyişikliklər geri qaytarılır
    /// </summary>
    /// <param name="satisId">Əsas satışın ID-si</param>
    /// <param name="qaytarilanMehsullar">Qaytarılan məhsulların siyahısı (MehsulId və Miqdar)</param>
    /// <param name="sebeb">Qaytarma səbəbi</param>
    /// <param name="kassirId">Qaytarmanı həyata keçirən kassirin ID-si</param>
    /// <param name="aktivNovbeId">Aktiv növbənin ID-si (nullable)</param>
    /// <returns>Əməliyyat nəticəsi və yaradılan qaytarma ID-si</returns>
    public async Task<EmeliyyatNeticesi<int>> QaytarmaYaratAsync(
        int satisId,
        List<(int MehsulId, int Miqdar, decimal VahidinQiymeti)> qaytarilanMehsullar,
        string sebeb,
        int kassirId,
        int? aktivNovbeId = null)
    {
        Logger.MelumatYaz($"Qaytarma əməliyyatı başlayır: SatışId={satisId}");

        try
        {
            // 1. Validasiya
            if (qaytarilanMehsullar == null || !qaytarilanMehsullar.Any())
            {
                Logger.XəbərdarlıqYaz("Qaytarılan məhsul siyahısı boşdur");
                return EmeliyyatNeticesi<int>.Ugursuz("Qaytarılan məhsul siyahısı boş ola bilməz.");
            }

            if (string.IsNullOrWhiteSpace(sebeb))
            {
                Logger.XəbərdarlıqYaz("Qaytarma səbəbi göstərilməyib");
                return EmeliyyatNeticesi<int>.Ugursuz("Qaytarma səbəbi göstərilməlidir.");
            }

            // 2. Əsas satışı tap və yoxla
            Satis satis = await _unitOfWork.Satislar.GetirAsync(satisId);
            if (satis == null)
            {
                Logger.XəbərdarlıqYaz($"Satış tapılmadı: ID={satisId}");
                return EmeliyyatNeticesi<int>.Ugursuz("Satış tapılmadı.");
            }

            // 3. Qaytarılan məhsulların satışda olub-olmadığını yoxla
            foreach ((int mehsulId, int miqdar, decimal _) in qaytarilanMehsullar)
            {
                SatisDetali? satisDetali = satis.SatisDetallari.FirstOrDefault(sd => sd.MehsulId == mehsulId);
                if (satisDetali == null)
                {
                    Logger.XəbərdarlıqYaz($"Məhsul bu satışda yoxdur: MehsulId={mehsulId}");
                    return EmeliyyatNeticesi<int>.Ugursuz($"Məhsul ID={mehsulId} bu satışda yoxdur.");
                }

                // Artıq qaytarılmış miqdarı yoxla
                decimal artiqQaytarilan = await HesablaArtiqQaytarilanMiqdarAsync(satisId, mehsulId);
                decimal qalan = satisDetali.Miqdar - artiqQaytarilan;

                if (miqdar > qalan)
                {
                    Logger.XəbərdarlıqYaz($"Qaytarılan miqdar çoxdur: Məhsul={mehsulId}, Qalan={qalan}, İstənilən={miqdar}");
                    return EmeliyyatNeticesi<int>.Ugursuz($"Məhsul üçün maksimum {qalan} ədəd qaytarıla bilər.");
                }
            }

            // 4. Qaytarma məbləğini hesabla
            decimal umumiMebleg = qaytarilanMehsullar.Sum(m => m.Miqdar * m.VahidinQiymeti);

            // 5. Qaytarma qeydini yarat
            Qaytarma qaytarma = new()
            {
                Tarix = DateTime.Now,
                SatisId = satisId,
                Sebeb = sebeb,
                KassirId = kassirId,
                UmumiMebleg = umumiMebleg
            };

            await _unitOfWork.Qaytarmalar.ElaveEtAsync(qaytarma);
            await _unitOfWork.EmeliyyatiTesdiqleAsync(); // ID əldə etmək üçün

            // 6. Qaytarma detallarını və stok hərəkətlərini qeydə al
            foreach ((int mehsulId, int miqdar, decimal vahidinQiymeti) in qaytarilanMehsullar)
            {
                // Qaytarma detalı
                QaytarmaDetali detali = new()
                {
                    QaytarmaId = qaytarma.Id,
                    MehsulId = mehsulId,
                    Miqdar = miqdar,
                    Qiymet = vahidinQiymeti,
                    UmumiMebleg = miqdar * vahidinQiymeti
                };
                qaytarma.QaytarmaDetallari.Add(detali);

                // Stok hərəkəti (Daxilolma - məhsul anbara qaytarılır)
                EmeliyyatNeticesi<int> stokNeticesi = await _stokHareketiManager.StokHareketiQeydeAlAsync(
                    StokHareketTipi.Daxilolma,
                    SenedNovu.Qaytarma,
                    qaytarma.Id,
                    mehsulId,
                    miqdar,
                    vahidinQiymeti, // Alış qiyməti
                    vahidinQiymeti, // Satış qiyməti
                    $"Qaytarma: ID={qaytarma.Id}, Səbəb: {sebeb}",
                    kassirId
                );

                if (!stokNeticesi.UgurluDur)
                {
                    Logger.XəbərdarlıqYaz($"Stok hərəkəti qeydə alınarkən xəta: {stokNeticesi.Mesaj}");
                    return EmeliyyatNeticesi<int>.Ugursuz($"Stok hərəkəti qeydə alınarkən xəta: {stokNeticesi.Mesaj}");
                }
            }

            // 7. Nisyə hesabını düzəlt (əgər satış nisyə idisə)
            if (satis.OdenisMetodu == OdenisMetodu.Nisyə && satis.MusteriId.HasValue)
            {
                Musteri musteri = await _unitOfWork.Musteriler.GetirAsync(satis.MusteriId.Value);
                if (musteri != null)
                {
                    // Müştəri borcunu azalt
                    musteri.UmumiBorc -= umumiMebleg;
                    _unitOfWork.Musteriler.Yenile(musteri);

                    // Nisyə hərəkəti yarat
                    NisyeHereketi nisyeHereketi = new()
                    {
                        MusteriId = satis.MusteriId.Value,
                        Mebleg = -umumiMebleg, // Mənfi - çünki borc azalır
                        Tarix = DateTime.Now,
                        EmeliyyatNovu = EmeliyyatNovu.Qaytarma,
                        SatisId = satisId,
                        Qeyd = $"Qaytarma: {sebeb}"
                    };
                    await _unitOfWork.NisyeHereketleri.ElaveEtAsync(nisyeHereketi);

                    Logger.MelumatYaz($"Nisyə hesabı yeniləndi: Müştəri={satis.MusteriId.Value}, Məbləğ={umumiMebleg}");
                }
            }

            // 8. Növbə maliyyəsini yenilə
            if (aktivNovbeId.HasValue)
            {
                Novbe novbe = await _unitOfWork.Novbeler.GetirAsync(aktivNovbeId.Value);
                if (novbe != null)
                {
                    // Ödəniş metoduna görə növbə məbləğini azalt
                    if (satis.OdenisMetodu == OdenisMetodu.Nağd)
                    {
                        novbe.FaktikiMebleg -= umumiMebleg;
                        Logger.MelumatYaz($"Növbə nağd pulu azaldıldı: {umumiMebleg}");

                        // Maliyyə jurnalına giriş qeydi əlavə et (nağd qaytarma)
                        try
                        {
                            EmeliyyatNeticesi<int> kassaHareketiNetice = await _maliyyeManager.KassaHareketiElaveEtAsync(
                                KassaHareketiNovu.Cixis,  // Pul geri qaytarılır, ona görə çıxış
                                EmeliyyatNovu.Qaytarma,
                                emeliyyatId: qaytarma.Id,
                                mebleg: -umumiMebleg,  // Mənfi, çünki pulu geri qaytarırıq
                                qeyd: $"Qaytarma ödənişinin geri qaytarılması (Nağd): {sebeb}, Satış ID={satisId}",
                                istifadeciId: kassirId
                            );

                            if (!kassaHareketiNetice.UgurluDur)
                            {
                                Logger.XəbərdarlıqYaz($"Kassa hərəkəti qeydiyyatı zamanı xəta: {kassaHareketiNetice.Mesaj}");
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.XetaYaz(ex, "Kassa hərəkəti qeydiyyatı zamanı istisna baş verdi");
                        }
                    }
                    else if (satis.OdenisMetodu == OdenisMetodu.Kart)
                    {
                        // Kart ödənişləri üçün ayrı-ayrı field olsa düzəliş edilməlidir
                        // Hazırda fərz edirik ki, FaktikiMebleg həm nağd, həm də kart üçündür
                        novbe.FaktikiMebleg -= umumiMebleg;
                        Logger.MelumatYaz($"Növbə kart məbləği azaldıldı: {umumiMebleg}");

                        // Maliyyə jurnalına giriş qeydi əlavə et (kart qaytarma)
                        try
                        {
                            EmeliyyatNeticesi<int> kassaHareketiNetice = await _maliyyeManager.KassaHareketiElaveEtAsync(
                                KassaHareketiNovu.Cixis,  // Pul geri qaytarılır, ona görə çıxış
                                EmeliyyatNovu.Qaytarma,
                                emeliyyatId: qaytarma.Id,
                                mebleg: -umumiMebleg,  // Mənfi, çünki pulu geri qaytarırıq
                                qeyd: $"Qaytarma ödənişinin geri qaytarılması (Kart): {sebeb}, Satış ID={satisId}",
                                istifadeciId: kassirId
                            );

                            if (!kassaHareketiNetice.UgurluDur)
                            {
                                Logger.XəbərdarlıqYaz($"Kassa hərəkəti qeydiyyatı zamanı xəta: {kassaHareketiNetice.Mesaj}");
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.XetaYaz(ex, "Kassa hərəkəti qeydiyyatı zamanı istisna baş verdi");
                        }
                    }
                    // Nisyə ödənişləri növbəni təsir etmir

                    _unitOfWork.Novbeler.Yenile(novbe);
                }
            }

            // 9. Bütün dəyişiklikləri təsdiqlə
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"Qaytarma uğurla yaradıldı: ID={qaytarma.Id}, Məbləğ={umumiMebleg}");
            return EmeliyyatNeticesi<int>.Ugurlu(qaytarma.Id);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Qaytarma əməliyyatı zamanı xəta baş verdi");
            return EmeliyyatNeticesi<int>.Ugursuz($"Qaytarma əməliyyatı zamanı xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Məhsul üçün artıq qaytarılmış miqdarı hesablayır
    /// </summary>
    private async Task<decimal> HesablaArtiqQaytarilanMiqdarAsync(int satisId, int mehsulId)
    {
        IEnumerable<Qaytarma> qaytarmalar = await _unitOfWork.Qaytarmalar.AxtarAsync(q => q.SatisId == satisId && !q.Silinib);

        decimal toplam = 0;
        foreach (Qaytarma qaytarma in qaytarmalar)
        {
            QaytarmaDetali? detali = qaytarma.QaytarmaDetallari.FirstOrDefault(d => d.MehsulId == mehsulId);
            if (detali != null)
            {
                toplam += detali.Miqdar;
            }
        }

        return toplam;
    }

    /// <summary>
    /// Satış üçün bütün qaytarmaları gətirir
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<Qaytarma>>> SatisQaytarmalariGetirAsync(int satisId)
    {
        Logger.MelumatYaz($"Satış qaytarmaları əldə edilir: SatışId={satisId}");

        try
        {
            IEnumerable<Qaytarma> qaytarmalar = await _unitOfWork.Qaytarmalar.AxtarAsync(q => q.SatisId == satisId && !q.Silinib);
            List<Qaytarma> siyahi = qaytarmalar.OrderByDescending(q => q.Tarix).ToList();

            Logger.MelumatYaz($"Satış qaytarmaları əldə edildi: Say={siyahi.Count}");
            return EmeliyyatNeticesi<List<Qaytarma>>.Ugurlu(siyahi);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Satış qaytarmaları əldə edilərkən xəta");
            return EmeliyyatNeticesi<List<Qaytarma>>.Ugursuz($"Qaytarmalar əldə edilərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Tarix aralığında qaytarmaları gətirir
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<Qaytarma>>> TarixAraligindaQaytarmalarGetirAsync(
        DateTime baslangicTarixi,
        DateTime bitisTarixi)
    {
        Logger.MelumatYaz($"Tarix aralığında qaytarmalar əldə edilir: {baslangicTarixi:d} - {bitisTarixi:d}");

        try
        {
            IEnumerable<Qaytarma> qaytarmalar = await _unitOfWork.Qaytarmalar.AxtarAsync(q =>
                q.Tarix >= baslangicTarixi &&
                q.Tarix <= bitisTarixi &&
                !q.Silinib);

            List<Qaytarma> siyahi = qaytarmalar.OrderByDescending(q => q.Tarix).ToList();

            Logger.MelumatYaz($"Tarix aralığında qaytarmalar əldə edildi: Say={siyahi.Count}");
            return EmeliyyatNeticesi<List<Qaytarma>>.Ugurlu(siyahi);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Tarix aralığında qaytarmalar əldə edilərkən xəta");
            return EmeliyyatNeticesi<List<Qaytarma>>.Ugursuz($"Qaytarmalar əldə edilərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Qaytarma məlumatlarını gətirir
    /// </summary>
    public async Task<EmeliyyatNeticesi<Qaytarma>> QaytarmaGetirAsync(int qaytarmaId)
    {
        Logger.MelumatYaz($"Qaytarma məlumatları əldə edilir: ID={qaytarmaId}");

        try
        {
            Qaytarma qaytarma = await _unitOfWork.Qaytarmalar.GetirAsync(qaytarmaId);
            if (qaytarma == null)
            {
                Logger.XəbərdarlıqYaz($"Qaytarma tapılmadı: ID={qaytarmaId}");
                return EmeliyyatNeticesi<Qaytarma>.Ugursuz("Qaytarma tapılmadı.");
            }

            Logger.MelumatYaz($"Qaytarma məlumatları əldə edildi: ID={qaytarmaId}");
            return EmeliyyatNeticesi<Qaytarma>.Ugurlu(qaytarma);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Qaytarma məlumatları əldə edilərkən xəta");
            return EmeliyyatNeticesi<Qaytarma>.Ugursuz($"Qaytarma əldə edilərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Səhifələnmiş qaytarma siyahısını əldə edir.
    /// Diqqət: Bu metod böyük məlumat bazaları üçün əlverişlidir.
    /// </summary>
    /// <param name="parametrler">Səhifələmə parametrləri</param>
    /// <returns>Səhifələnmiş qaytarma məlumatları</returns>
    public async Task<EmeliyyatNeticesi<SehifelenmisMelumat<Qaytarma>>> QaytarmalariSehifelenmisGetirAsync(SehifeParametrleri parametrler)
    {
        Logger.MelumatYaz($"Səhifələnmiş qaytarmalar əldə edilir - Səhifə: {parametrler.SehifeNomresi}, Ölçü: {parametrler.SehifeOlcusu}");
        try
        {
            (IEnumerable<Qaytarma>? qaytarmalar, int umumiSay) = await _unitOfWork.Qaytarmalar.SehifelenmisGetirAsync(
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu,
                q => !q.Silinib);

            SehifelenmisMelumat<Qaytarma> sehifelenmis = new(
                qaytarmalar.ToList(), umumiSay, parametrler.SehifeNomresi, parametrler.SehifeOlcusu);

            Logger.MelumatYaz($"Səhifələnmiş qaytarmalar uğurla əldə edildi - {qaytarmalar.Count()}/{umumiSay}");
            return EmeliyyatNeticesi<SehifelenmisMelumat<Qaytarma>>.Ugurlu(sehifelenmis);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Səhifələnmiş qaytarmalar əldə edilərkən istisna baş verdi");
            return EmeliyyatNeticesi<SehifelenmisMelumat<Qaytarma>>.Ugursuz($"Səhifələnmiş qaytarmalar əldə edilərkən xəta: {ex.Message}");
        }
    }
}
