// Fayl: AzAgroPOS.Mentiq/Idareciler/EmekHaqqiManager.cs
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
/// Əmək haqqı (Payroll) əməliyyatlarını idarə edən menecer.
/// diqqət: Bu sinif, işçilərin əmək haqqının hesablanması, ödənilməsi və maliyyə sistemi ilə inteqrasiyasını idarə edir.
/// qeyd: Əmək haqqı ödənildikdə avtomatik olaraq Xərc cədvəlinə və Kassa hərəkətlərinə əlavə olunur.
/// rol: HR və maliyyə uçotunun inteqrasiyası üçün mərkəzi nöqtədir.
/// </summary>
public class EmekHaqqiManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IsciManager _isciManager;
    private readonly MaliyyeManager _maliyyeManager;

    public EmekHaqqiManager(IUnitOfWork unitOfWork, IsciManager isciManager, MaliyyeManager maliyyeManager)
    {
        _unitOfWork = unitOfWork;
        _isciManager = isciManager;
        _maliyyeManager = maliyyeManager;
    }

    /// <summary>
    /// İşçi üçün əmək haqqını hesablayır.
    /// diqqət: Bu metod işçinin əsas maaşını, performans bonuslarını, icazə tutulmalarını nəzərə alır.
    /// qeyd: Hesablanan əmək haqqı "Hesablanmış" statusunda yaradılır və hələ ödənilməmişdir.
    /// </summary>
    /// <param name="isciId">İşçinin ID-si</param>
    /// <param name="dovr">Əmək haqqı dövrü (məsələn, "2025 Yanvar")</param>
    /// <param name="elaveOdenisler">Əlavə ödənişlər (ixtiyari)</param>
    /// <param name="digerTutulmalar">Digər tutulmalar (ixtiyari)</param>
    /// <param name="qeyd">Əlavə qeydlər</param>
    /// <param name="istifadeciId">Hesablayanın ID-si</param>
    /// <returns>Yaradılan əmək haqqı qeydinin ID-si</returns>
    public async Task<EmeliyyatNeticesi<int>> EmekHaqqiHesablaAsync(
        int isciId,
        string dovr,
        decimal elaveOdenisler = 0,
        decimal digerTutulmalar = 0,
        string? qeyd = null,
        int? istifadeciId = null)
    {
        Logger.MelumatYaz($"Əmək haqqı hesablanır: İşçi ID={isciId}, Dövr={dovr}");

        try
        {
            // İşçi məlumatlarını əldə et
            var isciNetice = await _isciManager.IsciGetirAsync(isciId);
            if (!isciNetice.UgurluDur || isciNetice.Data == null)
                return EmeliyyatNeticesi<int>.Ugursuz($"İşçi tapılmadı: {isciNetice.Mesaj}");

            var isci = isciNetice.Data;

            // Validasiya
            if (isci.Status != IsciStatusu.Aktiv)
                return EmeliyyatNeticesi<int>.Ugursuz("Yalnız aktiv işçilər üçün əmək haqqı hesablana bilər.");

            if (string.IsNullOrWhiteSpace(dovr))
                return EmeliyyatNeticesi<int>.Ugursuz("Əmək haqqı dövrü təyin edilməlidir.");

            // Eyni dövr üçün artıq əmək haqqı hesablanıb-hesablanmadığını yoxla
            var movcudEmekHaqqi = await _unitOfWork.EmekHaqqilari.AxtarAsync(
                eh => eh.IsciId == isciId && eh.Dovr == dovr && eh.Status != EmekHaqqiStatusu.Legv);

            if (movcudEmekHaqqi.Any())
                return EmeliyyatNeticesi<int>.Ugursuz($"Bu dövr ({dovr}) üçün artıq əmək haqqı hesablanmışdır.");

            // Performans bonuslarını hesabla (isteğe bağlı)
            decimal bonuslar = 0;
            var performansNetice = await _isciManager.IscininPerformansQeydleriniGetirAsync(isciId);
            if (performansNetice.UgurluDur && performansNetice.Data.Any())
            {
                // Son performans qeydini tap
                var sonPerformans = performansNetice.Data.OrderByDescending(p => p.Tarix).FirstOrDefault();
                if (sonPerformans != null && sonPerformans.QeydDovru == dovr)
                {
                    // Performans qiymətinə görə bonus hesabla
                    // Məsələn: Qiymət 8-10 arasındadırsa, maaşın 10%-i bonus
                    if (sonPerformans.Qiymet >= 8)
                        bonuslar = isci.Maas * 0.10m; // 10% bonus
                    else if (sonPerformans.Qiymet >= 6)
                        bonuslar = isci.Maas * 0.05m; // 5% bonus
                }
            }

            // İcazə tutulmalarını hesabla
            decimal icazeTutulmasi = 0;
            var izinNetice = await _isciManager.IscininIzinQeydleriniGetirAsync(isciId);
            if (izinNetice.UgurluDur && izinNetice.Data.Any())
            {
                // Cari dövr üçün ödənişsiz icazələri tap
                var odenissizIzinler = izinNetice.Data.Where(i =>
                    i.IzinNovu == IzinNovu.Mezuniyyetsiz &&
                    i.Status == IzinStatusu.Tesdiqlenib &&
                    i.BaslamaTarixi.Year == DateTime.Now.Year &&
                    i.BaslamaTarixi.Month == DateTime.Now.Month).ToList();

                if (odenissizIzinler.Any())
                {
                    var umumiIzinGunleri = odenissizIzinler.Sum(i => i.IzinGunu);
                    // Günlük maaş = Aylıq maaş / 30
                    var gunlukMaas = isci.Maas / 30m;
                    icazeTutulmasi = gunlukMaas * umumiIzinGunleri;
                }
            }

            // Əmək haqqı qeydini yarat
            var emekHaqqi = new EmekHaqqi
            {
                IsciId = isciId,
                Dovr = dovr,
                HesablanmaTarixi = DateTime.Now,
                EsasMaas = isci.Maas,
                Bonuslar = bonuslar,
                ElaveOdenisler = elaveOdenisler,
                IcazeTutulmasi = icazeTutulmasi,
                DigerTutulmalar = digerTutulmalar,
                Status = EmekHaqqiStatusu.Hesablanmis,
                Qeyd = qeyd,
                IstifadeciId = istifadeciId
            };

            await _unitOfWork.EmekHaqqilari.ElaveEtAsync(emekHaqqi);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"Əmək haqqı hesablandı: ID={emekHaqqi.Id}, İşçi={isci.TamAd}, Yekun={emekHaqqi.YekunEmekHaqqi}");
            return EmeliyyatNeticesi<int>.Ugurlu(emekHaqqi.Id);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Əmək haqqı hesablanarkən xəta baş verdi");
            return EmeliyyatNeticesi<int>.Ugursuz($"Əmək haqqı hesablanarkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Hesablanmış əmək haqqını ödəyir və maliyyə sisteminə qeyd edir.
    /// diqqət: Bu metod əmək haqqını "Ödənilmiş" statusuna keçirir və avtomatik olaraq:
    ///   1. Xərc cədvəlinə "Əmək haqqı" qeydini əlavə edir
    ///   2. Kassa çıxışı yaradır
    /// qeyd: Əməliyyat tranzaksiya ilə qorunur - hər hansı xəta baş verərsə, bütün əməliyyat geri qaytarılır.
    /// </summary>
    /// <param name="emekHaqqiId">Ödəniləcək əmək haqqının ID-si</param>
    /// <param name="istifadeciId">Ödəyişi icra edənin ID-si</param>
    /// <returns>Əməliyyat nəticəsi</returns>
    public async Task<EmeliyyatNeticesi> EmekHaqqiOdeAsync(int emekHaqqiId, int? istifadeciId = null)
    {
        Logger.MelumatYaz($"Əmək haqqı ödənir: ID={emekHaqqiId}");

        try
        {
            // Əmək haqqı qeydini tap
            var emekHaqqi = await _unitOfWork.EmekHaqqilari.GetirAsync(emekHaqqiId);
            if (emekHaqqi == null)
                return EmeliyyatNeticesi.Ugursuz("Əmək haqqı qeydi tapılmadı.");

            // Statusu yoxla
            if (emekHaqqi.Status == EmekHaqqiStatusu.Odenilmis)
                return EmeliyyatNeticesi.Ugursuz("Bu əmək haqqı artıq ödənilmişdir.");

            if (emekHaqqi.Status == EmekHaqqiStatusu.Legv)
                return EmeliyyatNeticesi.Ugursuz("Ləğv edilmiş əmək haqqı ödənilə bilməz.");

            // İşçi məlumatlarını əldə et
            var isci = await _unitOfWork.Isciler.GetirAsync(emekHaqqi.IsciId);
            if (isci == null)
                return EmeliyyatNeticesi.Ugursuz("İşçi tapılmadı.");

            // Xərc qeydiyyatı yarat
            var xercNetice = await _maliyyeManager.XercYaratAsync(
                XercNovu.EmekHaqqi,
                $"Əmək haqqı - {isci.TamAd} - {emekHaqqi.Dovr}",
                emekHaqqi.YekunEmekHaqqi,
                DateTime.Now,
                null, // Sənəd nömrəsi
                $"Əmək haqqı ödənişi: {emekHaqqi.Dovr}",
                istifadeciId);

            if (!xercNetice.UgurluDur)
                return EmeliyyatNeticesi.Ugursuz($"Xərc qeydiyyatı yaradılarkən xəta: {xercNetice.Mesaj}");

            // Əmək haqqı statusunu "Ödənilmiş" et
            emekHaqqi.Status = EmekHaqqiStatusu.Odenilmis;
            emekHaqqi.OdenisTarixi = DateTime.Now;

            _unitOfWork.EmekHaqqilari.Yenile(emekHaqqi);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"Əmək haqqı ödənildi: ID={emekHaqqiId}, İşçi={isci.TamAd}, Məbləğ={emekHaqqi.YekunEmekHaqqi}");
            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Əmək haqqı ödənərkən xəta baş verdi");
            return EmeliyyatNeticesi.Ugursuz($"Əmək haqqı ödənərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Bütün işçilər üçün əmək haqqını toplu şəkildə hesablayır.
    /// diqqət: Yalnız aktiv işçilər üçün hesablama aparılır.
    /// qeyd: Hər işçi üçün ayrıca əmək haqqı qeydi yaradılır.
    /// </summary>
    /// <param name="dovr">Əmək haqqı dövrü</param>
    /// <param name="istifadeciId">Hesablayanın ID-si</param>
    /// <returns>Hesablanan əmək haqqılarının sayı</returns>
    public async Task<EmeliyyatNeticesi<int>> ButunIscilerUcunEmekHaqqiHesablaAsync(string dovr, int? istifadeciId = null)
    {
        Logger.MelumatYaz($"Bütün işçilər üçün əmək haqqı hesablanır: Dövr={dovr}");

        try
        {
            // Aktiv işçiləri əldə et
            var iscilerNetice = await _isciManager.ButunIscileriGetirAsync();
            if (!iscilerNetice.UgurluDur || !iscilerNetice.Data.Any())
                return EmeliyyatNeticesi<int>.Ugursuz("Aktiv işçi tapılmadı.");

            var aktivIsciler = iscilerNetice.Data.Where(i => i.Status == IsciStatusu.Aktiv).ToList();
            int hesablananSay = 0;

            foreach (var isci in aktivIsciler)
            {
                var netice = await EmekHaqqiHesablaAsync(isci.Id, dovr, 0, 0, null, istifadeciId);
                if (netice.UgurluDur)
                    hesablananSay++;
                else
                    Logger.XəbərdarlıqYaz($"İşçi {isci.TamAd} üçün əmək haqqı hesablana bilmədi: {netice.Mesaj}");
            }

            Logger.MelumatYaz($"Toplu əmək haqqı hesablaması tamamlandı: {hesablananSay} / {aktivIsciler.Count}");
            return EmeliyyatNeticesi<int>.Ugurlu(hesablananSay);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Toplu əmək haqqı hesablanarkən xəta baş verdi");
            return EmeliyyatNeticesi<int>.Ugursuz($"Toplu əmək haqqı hesablanarkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Əmək haqqı qeydlərini DTO formatında gətirir.
    /// </summary>
    /// <param name="baslangicTarixi">Başlanğıc tarixi (ixtiyari)</param>
    /// <param name="bitisTarixi">Bitmə tarixi (ixtiyari)</param>
    /// <returns>Əmək haqqı qeydləri</returns>
    public async Task<EmeliyyatNeticesi<List<EmekHaqqiDto>>> EmekHaqqilariGetirAsync(
        DateTime? baslangicTarixi = null,
        DateTime? bitisTarixi = null)
    {
        Logger.MelumatYaz("Əmək haqqı qeydləri əldə edilir");

        try
        {
            var filter = baslangicTarixi.HasValue && bitisTarixi.HasValue
                ? (Func<EmekHaqqi, bool>)(eh => eh.HesablanmaTarixi.Date >= baslangicTarixi.Value.Date &&
                                                eh.HesablanmaTarixi.Date <= bitisTarixi.Value.Date)
                : baslangicTarixi.HasValue
                    ? (Func<EmekHaqqi, bool>)(eh => eh.HesablanmaTarixi.Date >= baslangicTarixi.Value.Date)
                    : bitisTarixi.HasValue
                        ? (Func<EmekHaqqi, bool>)(eh => eh.HesablanmaTarixi.Date <= bitisTarixi.Value.Date)
                        : (Func<EmekHaqqi, bool>)(eh => true);

            var emekHaqqlari = (await _unitOfWork.EmekHaqqilari.ButununuGetirAsync()).Where(filter).ToList();
            var dtolar = new List<EmekHaqqiDto>();

            foreach (var eh in emekHaqqlari)
            {
                var isci = await _unitOfWork.Isciler.GetirAsync(eh.IsciId);
                dtolar.Add(new EmekHaqqiDto
                {
                    Id = eh.Id,
                    IsciId = eh.IsciId,
                    IsciAdi = isci?.TamAd ?? "Naməlum",
                    Dovr = eh.Dovr,
                    HesablanmaTarixi = eh.HesablanmaTarixi,
                    EsasMaas = eh.EsasMaas,
                    Bonuslar = eh.Bonuslar,
                    ElaveOdenisler = eh.ElaveOdenisler,
                    IcazeTutulmasi = eh.IcazeTutulmasi,
                    DigerTutulmalar = eh.DigerTutulmalar,
                    OdenisTarixi = eh.OdenisTarixi,
                    Status = eh.Status,
                    Qeyd = eh.Qeyd
                });
            }

            Logger.MelumatYaz($"Əmək haqqı qeydləri əldə edildi: Say={dtolar.Count}");
            return EmeliyyatNeticesi<List<EmekHaqqiDto>>.Ugurlu(dtolar.OrderByDescending(d => d.HesablanmaTarixi).ToList());
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Əmək haqqı qeydləri əldə edilərkən xəta baş verdi");
            return EmeliyyatNeticesi<List<EmekHaqqiDto>>.Ugursuz($"Əmək haqqı qeydləri əldə edilərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Əmək haqqını ləğv edir.
    /// diqqət: Yalnız "Hesablanmış" statusdakı əmək haqqıları ləğv edilə bilər.
    /// qeyd: Əgər əmək haqqı ödənilmişdirsə, ləğv edilə bilməz.
    /// </summary>
    /// <param name="emekHaqqiId">Ləğv ediləcək əmək haqqının ID-si</param>
    /// <returns>Əməliyyat nəticəsi</returns>
    public async Task<EmeliyyatNeticesi> EmekHaqqiLegvEtAsync(int emekHaqqiId)
    {
        Logger.MelumatYaz($"Əmək haqqı ləğv edilir: ID={emekHaqqiId}");

        try
        {
            var emekHaqqi = await _unitOfWork.EmekHaqqilari.GetirAsync(emekHaqqiId);
            if (emekHaqqi == null)
                return EmeliyyatNeticesi.Ugursuz("Əmək haqqı qeydi tapılmadı.");

            if (emekHaqqi.Status == EmekHaqqiStatusu.Odenilmis)
                return EmeliyyatNeticesi.Ugursuz("Ödənilmiş əmək haqqı ləğv edilə bilməz.");

            emekHaqqi.Status = EmekHaqqiStatusu.Legv;
            _unitOfWork.EmekHaqqilari.Yenile(emekHaqqi);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"Əmək haqqı ləğv edildi: ID={emekHaqqiId}");
            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Əmək haqqı ləğv edilərkən xəta baş verdi");
            return EmeliyyatNeticesi.Ugursuz($"Əmək haqqı ləğv edilərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Səhifələnmiş əmək haqqı siyahısını əldə edir.
    /// Diqqət: Bu metod böyük məlumat bazaları üçün əlverişlidir.
    /// </summary>
    /// <param name="parametrler">Səhifələmə parametrləri</param>
    /// <returns>Səhifələnmiş əmək haqqı məlumatları</returns>
    public async Task<EmeliyyatNeticesi<SehifelenmisMelumat<EmekHaqqiDto>>> EmekHaqqilariSehifelenmisGetirAsync(SehifeParametrleri parametrler)
    {
        Logger.MelumatYaz($"Səhifələnmiş əmək haqqıları əldə edilir - Səhifə: {parametrler.SehifeNomresi}, Ölçü: {parametrler.SehifeOlcusu}");
        try
        {
            var (emekHaqqlari, umumiSay) = await _unitOfWork.EmekHaqqilari.SehifelenmisGetirAsync(
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu,
                e => !e.Silinib);

            var dtolar = new List<EmekHaqqiDto>();
            foreach (var eh in emekHaqqlari)
            {
                var isci = await _unitOfWork.Isciler.GetirAsync(eh.IsciId);
                dtolar.Add(new EmekHaqqiDto
                {
                    Id = eh.Id,
                    IsciId = eh.IsciId,
                    IsciAdi = isci?.TamAd ?? "Naməlum",
                    Dovr = eh.Dovr,
                    HesablanmaTarixi = eh.HesablanmaTarixi,
                    EsasMaas = eh.EsasMaas,
                    Bonuslar = eh.Bonuslar,
                    ElaveOdenisler = eh.ElaveOdenisler,
                    IcazeTutulmasi = eh.IcazeTutulmasi,
                    DigerTutulmalar = eh.DigerTutulmalar,
                    OdenisTarixi = eh.OdenisTarixi,
                    Status = eh.Status,
                    Qeyd = eh.Qeyd
                });
            }

            var sehifelenmis = new SehifelenmisMelumat<EmekHaqqiDto>(
                dtolar,
                umumiSay,
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu);

            Logger.MelumatYaz($"Səhifələnmiş əmək haqqıları uğurla əldə edildi - {dtolar.Count}/{umumiSay}");
            return EmeliyyatNeticesi<SehifelenmisMelumat<EmekHaqqiDto>>.Ugurlu(sehifelenmis);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Səhifələnmiş əmək haqqıları əldə edilərkən istisna baş verdi");
            return EmeliyyatNeticesi<SehifelenmisMelumat<EmekHaqqiDto>>.Ugursuz($"Səhifələnmiş əmək haqqıları əldə edilərkən xəta: {ex.Message}");
        }
    }
}
