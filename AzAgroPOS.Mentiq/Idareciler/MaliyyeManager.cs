// Fayl: AzAgroPOS.Mentiq/Idareciler/MaliyyeManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Maliyyə və xərc uçotu əməliyyatlarını idarə edən menecer
/// diqqət: Bu sinif, şirkətin xərc və gəlirlərinin uçotunu, kassa hərəkətlərini idarə edir.
/// qeyd: Bütün maliyyə əməliyyatları vahid tranzaksiya daxilində həyata keçirilir.
/// rol: Maliyyə hesabatları və mənfəət/zərər analizləri üçün mərkəzi mənbədir.
/// </summary>
public class MaliyyeManager
{
    private readonly IUnitOfWork _unitOfWork;

    public MaliyyeManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Yeni xərc qeydiyyatı yaradır
    /// diqqət: Bu metod xərc qeydiyyatını və müvafiq kassa hərəkətini yaradır.
    /// qeyd: Xərc yaradıldıqdan sonra kassa hərəkəti də qeydə alınır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> XercYaratAsync(
        XercNovu novu,
        string? ad,
        decimal mebleg,
        DateTime tarix,
        string? senedNomresi,
        string? qeyd,
        int? istifadeciId = null)
    {
        Logger.MelumatYaz($"Xərc qeydiyyatı yaradılır: Növ={novu}, Məbləğ={mebleg}");

        try
        {
            // Validasiya
            if (mebleg <= 0)
            {
                Logger.XəbərdarlıqYaz("Xərc məbləği sıfır və ya mənfi ola bilməz");
                return EmeliyyatNeticesi<int>.Ugursuz("Xərc məbləği sıfır və ya mənfi ola bilməz.");
            }

            if (string.IsNullOrWhiteSpace(ad))
            {
                Logger.XəbərdarlıqYaz("Xərc adı boş ola bilməz");
                return EmeliyyatNeticesi<int>.Ugursuz("Xərc adı boş ola bilməz.");
            }

            // Yeni xərc qeydiyyatı yarat
            var xerc = new Xerc
            {
                Novu = novu,
                Ad = ad,
                Mebleg = mebleg,
                Tarix = tarix,
                SenedNomresi = senedNomresi,
                Qeyd = qeyd,
                IstifadeciId = istifadeciId
            };

            await _unitOfWork.Xercler.ElaveEtAsync(xerc);
            await _unitOfWork.EmeliyyatiTesdiqleAsync(); // Xərc ID-sini əldə etmək üçün

            // Kassa hərəkəti yarat (xərc - çıxış)
            var kassaHareketi = new KassaHareketi
            {
                HareketNovu = KassaHareketiNovu.Cixis,
                EmeliyyatNovu = EmeliyyatNovu.Xerc,
                EmeliyyatId = xerc.Id, // Xərc ID-si
                Mebleg = mebleg,
                Tarix = tarix,
                Qeyd = $"Xərc: {ad}",
                IstifadeciId = istifadeciId
            };

            await _unitOfWork.KassaHareketleri.ElaveEtAsync(kassaHareketi);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"Xərc uğurla qeydə alındı: ID={xerc.Id}");
            return EmeliyyatNeticesi<int>.Ugurlu(xerc.Id);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Xərc qeydiyyatı zamanı xəta baş verdi");
            return EmeliyyatNeticesi<int>.Ugursuz($"Xərc qeydiyyatı zamanı xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Xərc qeydiyyatını yeniləyir
    /// diqqət: Bu metod xərc məlumatlarını və əlaqəli kassa hərəkətini yeniləyir.
    /// qeyd: Əvvəlki kassa hərəkəti silinir və yenisini yaradılır.
    /// </summary>
    public async Task<EmeliyyatNeticesi> XercYenileAsync(
        int xercId,
        XercNovu novu,
        string? ad,
        decimal mebleg,
        DateTime tarix,
        string? senedNomresi,
        string? qeyd,
        int? istifadeciId = null)
    {
        Logger.MelumatYaz($"Xərc yenilənir: ID={xercId}, Məbləğ={mebleg}");

        try
        {
            // Validasiya
            if (mebleg <= 0)
            {
                Logger.XəbərdarlıqYaz("Xərc məbləği sıfır və ya mənfi ola bilməz");
                return EmeliyyatNeticesi.Ugursuz("Xərc məbləği sıfır və ya mənfi ola bilməz.");
            }

            if (string.IsNullOrWhiteSpace(ad))
            {
                Logger.XəbərdarlıqYaz("Xərc adı boş ola bilməz");
                return EmeliyyatNeticesi.Ugursuz("Xərc adı boş ola bilməz.");
            }

            // Mövcud xərci tap
            var movcudXerc = await _unitOfWork.Xercler.GetirAsync(xercId);
            if (movcudXerc == null)
            {
                Logger.XəbərdarlıqYaz("Xərc tapılmadı");
                return EmeliyyatNeticesi.Ugursuz("Xərc tapılmadı.");
            }

            // Kassa hərəkətlərini tap və sil (xərcə aid olanı)
            var kassaHareketleri = await _unitOfWork.KassaHareketleri.AxtarAsync(k => k.EmeliyyatId == xercId && k.EmeliyyatNovu == EmeliyyatNovu.Xerc);
            foreach (var hareket in kassaHareketleri)
            {
                _unitOfWork.KassaHareketleri.Sil(hareket);
            }

            // Xərc məlumatlarını yenilə
            movcudXerc.Novu = novu;
            movcudXerc.Ad = ad;
            movcudXerc.Mebleg = mebleg;
            movcudXerc.Tarix = tarix;
            movcudXerc.SenedNomresi = senedNomresi;
            movcudXerc.Qeyd = qeyd;
            movcudXerc.IstifadeciId = istifadeciId;

            _unitOfWork.Xercler.Yenile(movcudXerc);

            // Yeni kassa hərəkəti yarat
            var yeniKassaHareketi = new KassaHareketi
            {
                HareketNovu = KassaHareketiNovu.Cixis,
                EmeliyyatNovu = EmeliyyatNovu.Xerc,
                EmeliyyatId = movcudXerc.Id,
                Mebleg = mebleg,
                Tarix = tarix,
                Qeyd = $"Xərc: {ad}",
                IstifadeciId = istifadeciId
            };

            await _unitOfWork.KassaHareketleri.ElaveEtAsync(yeniKassaHareketi);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"Xərc uğurla yeniləndi: ID={xercId}");
            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Xərc yeniləməsi zamanı xəta baş verdi");
            return EmeliyyatNeticesi.Ugursuz($"Xərc yeniləməsi zamanı xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Xərc qeydiyyatını silir
    /// diqqət: Bu metod xərc qeydiyyatını və əlaqəli kassa hərəkətini silir.
    /// qeyd: Hərəkət silinərkən tranzaksiya ilə təmin olunur.
    /// </summary>
    public async Task<EmeliyyatNeticesi> XercSilAsync(int xercId)
    {
        Logger.MelumatYaz($"Xərc silinir: ID={xercId}");

        try
        {
            // Mövcud xərci tap
            var xerc = await _unitOfWork.Xercler.GetirAsync(xercId);
            if (xerc == null)
            {
                Logger.XəbərdarlıqYaz("Xərc tapılmadı");
                return EmeliyyatNeticesi.Ugursuz("Xərc tapılmadı.");
            }

            // Əlaqəli kassa hərəkətlərini tap və sil
            var kassaHareketleri = await _unitOfWork.KassaHareketleri.AxtarAsync(k => k.EmeliyyatId == xercId && k.EmeliyyatNovu == EmeliyyatNovu.Xerc);
            foreach (var hareket in kassaHareketleri)
            {
                _unitOfWork.KassaHareketleri.Sil(hareket);
            }

            // Xərc qeydiyyatını sil
            _unitOfWork.Xercler.Sil(xerc);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"Xərc uğurla silindi: ID={xercId}");
            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Xərc silinməsi zamanı xəta baş verdi");
            return EmeliyyatNeticesi.Ugursuz($"Xərc silinməsi zamanı xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Bütün xərc qeydiyyatlarını gətirir
    /// diqqət: Bu metod tarix aralığına görə xərc qeydiyyatlarını qaytarır.
    /// qeyd: Ən yeni qeydiyyatlar əvvəldə olur.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<Xerc>>> ButunXercleriGetirAsync(
        DateTime? baslangicTarixi = null,
        DateTime? bitisTarixi = null)
    {
        Logger.MelumatYaz("Xərc qeydiyyatları əldə edilir");

        try
        {
            var filter = baslangicTarixi.HasValue && bitisTarixi.HasValue
                ? (Func<Xerc, bool>)(x => x.Tarix.Date >= baslangicTarixi.Value.Date && x.Tarix.Date <= bitisTarixi.Value.Date)
                : baslangicTarixi.HasValue
                    ? (Func<Xerc, bool>)(x => x.Tarix.Date >= baslangicTarixi.Value.Date)
                    : bitisTarixi.HasValue
                        ? (Func<Xerc, bool>)(x => x.Tarix.Date <= bitisTarixi.Value.Date)
                        : (Func<Xerc, bool>)(x => true);

            var xercler = (await _unitOfWork.Xercler.ButununuGetirAsync()).Where(filter).OrderByDescending(x => x.Tarix).ToList();

            Logger.MelumatYaz($"Xərc qeydiyyatları əldə edildi: Say={xercler.Count}");
            return EmeliyyatNeticesi<List<Xerc>>.Ugurlu(xercler);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Xərc qeydiyyatları əldə edilərkən xəta baş verdi");
            return EmeliyyatNeticesi<List<Xerc>>.Ugursuz($"Xərc qeydiyyatları əldə edilərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Bütün xərc qeydiyyatlarını DTO formatında gətirir
    /// diqqət: Bu metod tarix aralığına görə xərc qeydiyyatlarını DTO formatında qaytarır.
    /// qeyd: Ən yeni qeydiyyatlar əvvəldə olur.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<XercDto>>> ButunXercleriDtoFormatindaGetirAsync(
        DateTime? baslangicTarixi = null,
        DateTime? bitisTarixi = null)
    {
        Logger.MelumatYaz("Xərc qeydiyyatları DTO formatında əldə edilir");

        try
        {
            var filter = baslangicTarixi.HasValue && bitisTarixi.HasValue
                ? (Func<Xerc, bool>)(x => x.Tarix.Date >= baslangicTarixi.Value.Date && x.Tarix.Date <= bitisTarixi.Value.Date)
                : baslangicTarixi.HasValue
                    ? (Func<Xerc, bool>)(x => x.Tarix.Date >= baslangicTarixi.Value.Date)
                    : bitisTarixi.HasValue
                        ? (Func<Xerc, bool>)(x => x.Tarix.Date <= bitisTarixi.Value.Date)
                        : (Func<Xerc, bool>)(x => true);

            var xercler = (await _unitOfWork.Xercler.ButununuGetirAsync()).Where(filter).OrderByDescending(x => x.Tarix).ToList();

            var dtolar = new List<XercDto>();
            foreach (var xerc in xercler)
            {
                var dto = new XercDto
                {
                    Id = xerc.Id,
                    Novu = xerc.Novu,
                    Ad = xerc.Ad,
                    Mebleg = xerc.Mebleg,
                    Tarix = xerc.Tarix,
                    SenedNomresi = xerc.SenedNomresi,
                    Qeyd = xerc.Qeyd,
                    IstifadeciAdi = xerc.Istifadeci?.TamAd
                };
                dtolar.Add(dto);
            }

            Logger.MelumatYaz($"Xərc qeydiyyatları DTO formatında əldə edildi: Say={dtolar.Count}");
            return EmeliyyatNeticesi<List<XercDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Xərc qeydiyyatları DTO formatında əldə edilərkən xəta baş verdi");
            return EmeliyyatNeticesi<List<XercDto>>.Ugursuz($"Xərc qeydiyyatları DTO formatında əldə edilərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Xərc növünə görə xərc qeydiyyatlarını gətirir
    /// diqqət: Bu metod xərc növünə görə filtrlənmiş qeydiyyatları qaytarır.
    /// qeyd: Müəyyən növ xərcləri analiz etmək üçün istifadə olunur.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<Xerc>>> XercNovunaGoreGetirAsync(XercNovu novu)
    {
        Logger.MelumatYaz($"Xərc növünə görə qeydiyyatlar əldə edilir: Növ={novu}");

        try
        {
            var xercler = (await _unitOfWork.Xercler.ButununuGetirAsync())
                .Where(x => x.Novu == novu)
                .OrderByDescending(x => x.Tarix)
                .ToList();

            Logger.MelumatYaz($"Xərc növünə görə qeydiyyatlar əldə edildi: Say={xercler.Count}");
            return EmeliyyatNeticesi<List<Xerc>>.Ugurlu(xercler);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Xərc növünə görə qeydiyyatlar əldə edilərkən xəta baş verdi");
            return EmeliyyatNeticesi<List<Xerc>>.Ugursuz($"Xərc növünə görə qeydiyyatlar əldə edilərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Xərclərin ümumi cəmini hesablayır
    /// diqqət: Bu metod xərclərin ümumi məbləğini hesablayır.
    /// qeyd: Hesabatlar üçün istifadə olunur.
    /// </summary>
    public async Task<EmeliyyatNeticesi<decimal>> XercCeminiHesablaAsync(
        DateTime? baslangicTarixi = null,
        DateTime? bitisTarixi = null)
    {
        Logger.MelumatYaz("Xərc cəmi hesablanır");

        try
        {
            var filter = baslangicTarixi.HasValue && bitisTarixi.HasValue
                ? (Func<Xerc, bool>)(x => x.Tarix.Date >= baslangicTarixi.Value.Date && x.Tarix.Date <= bitisTarixi.Value.Date)
                : baslangicTarixi.HasValue
                    ? (Func<Xerc, bool>)(x => x.Tarix.Date >= baslangicTarixi.Value.Date)
                    : bitisTarixi.HasValue
                        ? (Func<Xerc, bool>)(x => x.Tarix.Date <= bitisTarixi.Value.Date)
                        : (Func<Xerc, bool>)(x => true);

            var xercler = (await _unitOfWork.Xercler.ButununuGetirAsync()).Where(filter);
            var cem = xercler.Sum(x => x.Mebleg);

            Logger.MelumatYaz($"Xərc cəmi hesablandı: Cəm={cem}");
            return EmeliyyatNeticesi<decimal>.Ugurlu(cem);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Xərc cəmi hesablanarkən xəta baş verdi");
            return EmeliyyatNeticesi<decimal>.Ugursuz($"Xərc cəmi hesablanarkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Kassa hərəkətlərini əldə edir
    /// diqqət: Bu metod kassa hərəkətlərini tarixə görə qaytarır.
    /// qeyd: Bütün gəlir və xərclərin izlənməsi üçün istifadə olunur.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<KassaHareketi>>> KassaHareketleriniGetirAsync(
        DateTime? baslangicTarixi = null,
        DateTime? bitisTarixi = null)
    {
        Logger.MelumatYaz("Kassa hərəkətləri əldə edilir");

        try
        {
            var filter = baslangicTarixi.HasValue && bitisTarixi.HasValue
                ? (Func<KassaHareketi, bool>)(k => k.Tarix.Date >= baslangicTarixi.Value.Date && k.Tarix.Date <= bitisTarixi.Value.Date)
                : baslangicTarixi.HasValue
                    ? (Func<KassaHareketi, bool>)(k => k.Tarix.Date >= baslangicTarixi.Value.Date)
                    : bitisTarixi.HasValue
                        ? (Func<KassaHareketi, bool>)(k => k.Tarix.Date <= bitisTarixi.Value.Date)
                        : (Func<KassaHareketi, bool>)(k => true);

            var hareketler = (await _unitOfWork.KassaHareketleri.ButununuGetirAsync()).Where(filter).OrderByDescending(k => k.Tarix).ToList();

            Logger.MelumatYaz($"Kassa hərəkətləri əldə edildi: Say={hareketler.Count}");
            return EmeliyyatNeticesi<List<KassaHareketi>>.Ugurlu(hareketler);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Kassa hərəkətləri əldə edilərkən xəta baş verdi");
            return EmeliyyatNeticesi<List<KassaHareketi>>.Ugursuz($"Kassa hərəkətləri əldə edilərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Kassa gəliri əlavə edir (növbə bağlanarkən istifadə olunur)
    /// diqqət: Bu metod satış gəlirini kassa hərəkəti kimi qeydə alır.
    /// qeyd: Əsasən NovbeManager tərəfindən çağırılır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> KassaGeliriElaveEtAsync(
        decimal mebleg,
        int novbeId,
        string? qeyd = null,
        int? istifadeciId = null)
    {
        Logger.MelumatYaz($"Kassa gəliri əlavə olunur: Məbləğ={mebleg}, Növbə={novbeId}");

        try
        {
            if (mebleg <= 0)
            {
                Logger.XəbərdarlıqYaz("Gəlir məbləği sıfır və ya mənfi ola bilməz");
                return EmeliyyatNeticesi<int>.Ugursuz("Gəlir məbləği sıfır və ya mənfi ola bilməz.");
            }

            var kassaHareketi = new KassaHareketi
            {
                HareketNovu = KassaHareketiNovu.Daxilolma,
                EmeliyyatNovu = EmeliyyatNovu.Gelir,
                EmeliyyatId = novbeId,
                Mebleg = mebleg,
                Tarix = DateTime.Now,
                Qeyd = qeyd ?? $"Növbə gəliri: #{novbeId}",
                IstifadeciId = istifadeciId
            };

            await _unitOfWork.KassaHareketleri.ElaveEtAsync(kassaHareketi);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"Kassa gəliri uğurla əlavə olundu: ID={kassaHareketi.Id}");
            return EmeliyyatNeticesi<int>.Ugurlu(kassaHareketi.Id);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Kassa gəliri əlavə edilərkən xəta baş verdi");
            return EmeliyyatNeticesi<int>.Ugursuz($"Kassa gəliri əlavə edilərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Mənfəət və ya zərər hesablayır
    /// diqqət: Bu metod müəyyən dövrdə əldə edilən gəliri və xərcləri müqayisə edir.
    /// qeyd: Mənfəət = Gəlir - Xərc
    /// </summary>
    public async Task<EmeliyyatNeticesi<decimal>> MenfeetZerereHesablaAsync(
        DateTime? baslangicTarixi = null,
        DateTime? bitisTarixi = null)
    {
        Logger.MelumatYaz("Mənfəət/zərər hesablanır");

        try
        {
            // Gəlirləri hesabla
            var gelirFilter = baslangicTarixi.HasValue && bitisTarixi.HasValue
                ? (Func<KassaHareketi, bool>)(k => k.HareketNovu == KassaHareketiNovu.Daxilolma && 
                                                k.Tarix.Date >= baslangicTarixi.Value.Date && 
                                                k.Tarix.Date <= bitisTarixi.Value.Date)
                : baslangicTarixi.HasValue
                    ? (Func<KassaHareketi, bool>)(k => k.HareketNovu == KassaHareketiNovu.Daxilolma && 
                                                    k.Tarix.Date >= baslangicTarixi.Value.Date)
                    : bitisTarixi.HasValue
                        ? (Func<KassaHareketi, bool>)(k => k.HareketNovu == KassaHareketiNovu.Daxilolma && 
                                                        k.Tarix.Date <= bitisTarixi.Value.Date)
                        : (Func<KassaHareketi, bool>)(k => k.HareketNovu == KassaHareketiNovu.Daxilolma);

            var gelirler = (await _unitOfWork.KassaHareketleri.ButununuGetirAsync()).Where(gelirFilter);
            var umumiGelir = gelirler.Sum(k => k.Mebleg);

            // Xərcləri hesabla
            var xercFilter = baslangicTarixi.HasValue && bitisTarixi.HasValue
                ? (Func<KassaHareketi, bool>)(k => k.HareketNovu == KassaHareketiNovu.Cixis && 
                                                k.Tarix.Date >= baslangicTarixi.Value.Date && 
                                                k.Tarix.Date <= bitisTarixi.Value.Date)
                : baslangicTarixi.HasValue
                    ? (Func<KassaHareketi, bool>)(k => k.HareketNovu == KassaHareketiNovu.Cixis && 
                                                    k.Tarix.Date >= baslangicTarixi.Value.Date)
                    : bitisTarixi.HasValue
                        ? (Func<KassaHareketi, bool>)(k => k.HareketNovu == KassaHareketiNovu.Cixis && 
                                                        k.Tarix.Date <= bitisTarixi.Value.Date)
                        : (Func<KassaHareketi, bool>)(k => k.HareketNovu == KassaHareketiNovu.Cixis);

            var xercler = (await _unitOfWork.KassaHareketleri.ButununuGetirAsync()).Where(xercFilter);
            var umumiXerc = xercler.Sum(k => k.Mebleg);

            var menfeet = umumiGelir - umumiXerc;

            Logger.MelumatYaz($"Mənfəət/zərər hesablandı: Gəlir={umumiGelir}, Xərc={umumiXerc}, Nəticə={menfeet}");
            return EmeliyyatNeticesi<decimal>.Ugurlu(menfeet);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Mənfəət/zərər hesablanarkən xəta baş verdi");
            return EmeliyyatNeticesi<decimal>.Ugursuz($"Mənfəət/zərər hesablanarkən xəta: {ex.Message}");
        }
    }
}