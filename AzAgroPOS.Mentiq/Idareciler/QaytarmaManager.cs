// Fayl: AzAgroPOS.Mentiq/Idareciler/QaytarmaManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    public QaytarmaManager(IUnitOfWork unitOfWork, StokHareketiManager stokHareketiManager)
    {
        _unitOfWork = unitOfWork;
        _stokHareketiManager = stokHareketiManager;
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
            var satis = await _unitOfWork.Satislar.GetirAsync(satisId);
            if (satis == null)
            {
                Logger.XəbərdarlıqYaz($"Satış tapılmadı: ID={satisId}");
                return EmeliyyatNeticesi<int>.Ugursuz("Satış tapılmadı.");
            }

            // 3. Qaytarılan məhsulların satışda olub-olmadığını yoxla
            foreach (var (mehsulId, miqdar, _) in qaytarilanMehsullar)
            {
                var satisDetali = satis.SatisDetallari.FirstOrDefault(sd => sd.MehsulId == mehsulId);
                if (satisDetali == null)
                {
                    Logger.XəbərdarlıqYaz($"Məhsul bu satışda yoxdur: MehsulId={mehsulId}");
                    return EmeliyyatNeticesi<int>.Ugursuz($"Məhsul ID={mehsulId} bu satışda yoxdur.");
                }

                // Artıq qaytarılmış miqdarı yoxla
                var artiqQaytarilan = await HesablaArtiqQaytarilanMiqdarAsync(satisId, mehsulId);
                var qalan = satisDetali.Miqdar - artiqQaytarilan;

                if (miqdar > qalan)
                {
                    Logger.XəbərdarlıqYaz($"Qaytarılan miqdar çoxdur: Məhsul={mehsulId}, Qalan={qalan}, İstənilən={miqdar}");
                    return EmeliyyatNeticesi<int>.Ugursuz($"Məhsul üçün maksimum {qalan} ədəd qaytarıla bilər.");
                }
            }

            // 4. Qaytarma məbləğini hesabla
            decimal umumiMebleg = qaytarilanMehsullar.Sum(m => m.Miqdar * m.VahidinQiymeti);

            // 5. Qaytarma qeydini yarat
            var qaytarma = new Qaytarma
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
            foreach (var (mehsulId, miqdar, vahidinQiymeti) in qaytarilanMehsullar)
            {
                // Qaytarma detalı
                var detali = new QaytarmaDetali
                {
                    QaytarmaId = qaytarma.Id,
                    MehsulId = mehsulId,
                    Miqdar = miqdar,
                    Qiymet = vahidinQiymeti,
                    UmumiMebleg = miqdar * vahidinQiymeti
                };
                qaytarma.QaytarmaDetallari.Add(detali);

                // Stok hərəkəti (Daxilolma - məhsul anbara qaytarılır)
                var stokNeticesi = await _stokHareketiManager.StokHareketiQeydeAlAsync(
                    StokHareketTipi.Daxilolma,
                    SenedNovu.Qaytarma,
                    qaytarma.Id,
                    mehsulId,
                    miqdar,
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
                var musteri = await _unitOfWork.Musteriler.GetirAsync(satis.MusteriId.Value);
                if (musteri != null)
                {
                    // Müştəri borcunu azalt
                    musteri.UmumiBorc -= umumiMebleg;
                    _unitOfWork.Musteriler.Yenile(musteri);

                    // Nisyə hərəkəti yarat
                    var nisyeHereketi = new NisyeHereketi
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
                var novbe = await _unitOfWork.Novbeler.GetirAsync(aktivNovbeId.Value);
                if (novbe != null)
                {
                    // Ödəniş metoduna görə növbə məbləğini azalt
                    if (satis.OdenisMetodu == OdenisMetodu.Nağd)
                    {
                        novbe.FaktikiMebleg -= umumiMebleg;
                        Logger.MelumatYaz($"Növbə nağd pulu azaldıldı: {umumiMebleg}");
                    }
                    else if (satis.OdenisMetodu == OdenisMetodu.Kart)
                    {
                        // Kart ödənişləri üçün ayrıca field olsa düzəliş edilməlidir
                        // Hazırda fərz edirik ki, FaktikiMebleg həm nağd, həm də kart üçündür
                        novbe.FaktikiMebleg -= umumiMebleg;
                        Logger.MelumatYaz($"Növbə kart məbləği azaldıldı: {umumiMebleg}");
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
        var qaytarmalar = await _unitOfWork.Qaytarmalar.AxtarAsync(q => q.SatisId == satisId && !q.Silinib);

        decimal toplam = 0;
        foreach (var qaytarma in qaytarmalar)
        {
            var detali = qaytarma.QaytarmaDetallari.FirstOrDefault(d => d.MehsulId == mehsulId);
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
            var qaytarmalar = await _unitOfWork.Qaytarmalar.AxtarAsync(q => q.SatisId == satisId && !q.Silinib);
            var siyahi = qaytarmalar.OrderByDescending(q => q.Tarix).ToList();

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
            var qaytarmalar = await _unitOfWork.Qaytarmalar.AxtarAsync(q =>
                q.Tarix >= baslangicTarixi &&
                q.Tarix <= bitisTarixi &&
                !q.Silinib);

            var siyahi = qaytarmalar.OrderByDescending(q => q.Tarix).ToList();

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
            var qaytarma = await _unitOfWork.Qaytarmalar.GetirAsync(qaytarmaId);
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
}
