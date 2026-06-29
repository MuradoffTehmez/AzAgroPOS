// Fayl: AzAgroPOS.Mentiq/Idareciler/HesabatManager.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;

namespace AzAgroPOS.Mentiq.Idareciler;
/// <summary>
/// Hesabatların hazırlanması ilə bağlı biznes məntiqini idarə edir.
/// </summary>
public class HesabatManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly StokHareketiManager _stokHareketiManager;
    private readonly MaliyyeManager _maliyyeManager;

    public HesabatManager(IUnitOfWork unitOfWork, StokHareketiManager stokHareketiManager, MaliyyeManager maliyyeManager)
    {
        _unitOfWork = unitOfWork;
        _stokHareketiManager = stokHareketiManager;
        _maliyyeManager = maliyyeManager;
    }

    /// <summary>
    /// Verilmiş tarix üçün günlük satış hesabatını hazırlayır.
    /// </summary>
    /// <param name="tarix">Hesabatın hazırlanacağı gün.</param>
    public async Task<EmeliyyatNeticesi<GunlukSatisHesabatDto>> GunlukSatisHesabatiGetirAsync(DateTime tarix)
    {
        Logger.MelumatYaz($"Günlük satış hesabatı üçün tarix: {tarix:d}");
        try
        {
            DateTime gununBasi = tarix.Date;
            DateTime gununSonu = gununBasi.AddDays(1).AddTicks(-1);

            // Verilənlər bazasından həmin günə aid satışları müştəri məlumatları ilə birlikdə çəkirik.
            IEnumerable<Satis> satislar = await _unitOfWork.Satislar
                .AxtarAsync(s => s.Tarix >= gununBasi && s.Tarix <= gununSonu);

            // Müştəri məlumatlarını əlavə etmək üçün ayrıca sorğu
            List<int> musteriIds = satislar.Where(s => s.MusteriId.HasValue).Select(s => s.MusteriId.Value).Distinct().ToList();
            Dictionary<int, string> musteriler = (await _unitOfWork.Musteriler.AxtarAsync(m => musteriIds.Contains(m.Id)))
                             .ToDictionary(m => m.Id, m => m.TamAd);


            if (!satislar.Any())
            {
                return EmeliyyatNeticesi<GunlukSatisHesabatDto>.Ugursuz("Seçilmiş tarix üçün heç bir satış tapılmadı.");
            }

            GunlukSatisHesabatDto hesabat = new()
            {
                HesabatTarixi = gununBasi,
                UmumiDovriyye = satislar.Sum(s => s.UmumiMebleg),
                CemiSatisSayi = satislar.Count(),
                NagdSatisCemi = satislar.Where(s => s.OdenisMetodu == OdenisMetodu.Nağd).Sum(s => s.UmumiMebleg),
                KartSatisCemi = satislar.Where(s => s.OdenisMetodu == OdenisMetodu.Kart).Sum(s => s.UmumiMebleg),
                NisyeSatisCemi = satislar.Where(s => s.OdenisMetodu == OdenisMetodu.Nisyə).Sum(s => s.UmumiMebleg),
                SatislarinSiyahisi = satislar.Select(s => new GunlukSatisDetayDto
                {
                    SatisId = s.Id,
                    Tarix = s.Tarix,
                    UmumiMebleg = s.UmumiMebleg,
                    OdenisMetodu = s.OdenisMetodu.ToString(),
                    MusteriAdi = s.MusteriId.HasValue && musteriler.ContainsKey(s.MusteriId.Value)
                                 ? musteriler[s.MusteriId.Value]
                                 : "N/A"
                }).OrderBy(s => s.Tarix).ToList()
            };

            return EmeliyyatNeticesi<GunlukSatisHesabatDto>.Ugurlu(hesabat);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Hesabat hazırlanarkən xəta baş verdi: "); // Xətanı qeyd etmək üçün
            return EmeliyyatNeticesi<GunlukSatisHesabatDto>.Ugursuz($"Hesabat hazırlanarkən xəta baş verdi: {ex.Message} + {ex.StackTrace}");
        }
    }
    /// <summary>
    /// Verilmiş tarix aralığı üçün məhsul üzrə satış hesabatını hazırlayır.
    /// </summary>
    /// <param name="baslangic">Hesabatın başlanğıc tarixi.</param>
    /// <param name="bitis">Hesabatın bitiş tarixi.</param>
    public async Task<EmeliyyatNeticesi<List<MehsulUzreSatisDetayDto>>> MehsulUzreSatisHesabatiGetirAsync(DateTime baslangic, DateTime bitis)
    {
        Logger.MelumatYaz($"Məhsul üzrə satış hesabatı üçün tarix aralığı: {baslangic:d} - {bitis:d}");
        try
        {
            DateTime baslangicTarixi = baslangic.Date;
            DateTime bitisTarixi = bitis.Date.AddDays(1).AddTicks(-1);

            IEnumerable<Satis> satisDetallari = await _unitOfWork.Satislar.AxtarAsync(s => s.Tarix >= baslangicTarixi && s.Tarix <= bitisTarixi);

            List<int> mehsulIds = satisDetallari.SelectMany(s => s.SatisDetallari).Select(d => d.MehsulId).Distinct().ToList();
            Dictionary<int, Mehsul> mehsullar = (await _unitOfWork.Mehsullar.AxtarAsync(m => mehsulIds.Contains(m.Id)))
                            .ToDictionary(m => m.Id);


            if (!satisDetallari.Any())
            {
                return EmeliyyatNeticesi<List<MehsulUzreSatisDetayDto>>.Ugursuz("Seçilmiş tarix aralığı üçün heç bir satış tapılmadı.");
            }

            List<MehsulUzreSatisDetayDto> hesabat = satisDetallari
                .SelectMany(s => s.SatisDetallari)
                .GroupBy(d => d.MehsulId)
                .Select(g => new MehsulUzreSatisDetayDto
                {
                    StokKodu = mehsullar.ContainsKey(g.Key) ? mehsullar[g.Key].StokKodu : "Bilinmir",
                    MehsulAdi = mehsullar.ContainsKey(g.Key) ? mehsullar[g.Key].Ad : "Silinmiş Məhsul",
                    CemiSatilanMiqdar = g.Sum(d => d.Miqdar),
                    CemiMebleg = g.Sum(d => d.Miqdar * d.Qiymet)
                })
                .OrderByDescending(x => x.CemiMebleg)
                .ToList();

            return EmeliyyatNeticesi<List<MehsulUzreSatisDetayDto>>.Ugurlu(hesabat);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Hesabat hazırlanarkən xəta baş verdi: "); // Xətanı qeyd etmək üçün
            return EmeliyyatNeticesi<List<MehsulUzreSatisDetayDto>>.Ugursuz($"Hesabat hazırlanarkən xəta baş verdi: {ex.Message}+ {ex.StackTrace}");
        }
    }


    /// <summary>
    /// Anbarda miqdarı göstərilən limitdən az və ya bərabər olan məhsulları tapır.
    /// </summary>
    /// <param name="limitSay">Anbar qalığı üçün maksimum limit.</param>
    public async Task<EmeliyyatNeticesi<List<AnbarQaliqDetayDto>>> AnbarQaliqHesabatiGetirAsync(int limitSay)
    {
        Logger.MelumatYaz($"Anbar qalıq hesabatı üçün limit: {limitSay}");
        try
        {
            IEnumerable<Mehsul> mehsullar = await _unitOfWork.Mehsullar.AxtarAsync(m => m.MovcudSay <= limitSay);

            if (!mehsullar.Any())
            {
                return EmeliyyatNeticesi<List<AnbarQaliqDetayDto>>.Ugursuz($"Anbarda sayı {limitSay}-dən az olan məhsul tapılmadı.");
            }

            List<AnbarQaliqDetayDto> hesabat = mehsullar
                .Select(m => new AnbarQaliqDetayDto
                {
                    StokKodu = m.StokKodu,
                    MehsulAdi = m.Ad,
                    MovcudSay = m.MovcudSay
                })
                .OrderBy(r => r.MovcudSay)
                .ToList();

            return EmeliyyatNeticesi<List<AnbarQaliqDetayDto>>.Ugurlu(hesabat);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Hesabat hazırlanarkən xəta baş verdi: "); // Xətanı qeyd etmək üçün
            return EmeliyyatNeticesi<List<AnbarQaliqDetayDto>>.Ugursuz($"Hesabat hazırlanarkən xəta baş verdi: {ex.Message}+ {ex.StackTrace}");
        }
    }
    /// <summary>
    /// Bütün bağlanmış növbələrin siyahısını gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<BaglanmisNovbeDto>>> BaglanmisNovbeleriGetirAsync()
    {
        Logger.MelumatYaz("Bağlanmış növbələr gətirilir.");
        try
        {
            IEnumerable<Novbe> novbeler = await _unitOfWork.Novbeler.AxtarAsync(n => n.Status == NovbeStatusu.Bagli);

            List<int> isciIds = novbeler.Select(n => n.IsciId).Distinct().ToList();
            Dictionary<int, string> isciler = (await _unitOfWork.Istifadeciler.AxtarAsync(i => isciIds.Contains(i.Id)))
                          .ToDictionary(i => i.Id, i => i.TamAd);

            if (!novbeler.Any())
            {
                return EmeliyyatNeticesi<List<BaglanmisNovbeDto>>.Ugursuz("Heç bir bağlanmış növbə tapılmadı.");
            }

            List<BaglanmisNovbeDto> dtoSiyahisi = novbeler
                .Select(n => new BaglanmisNovbeDto
                {
                    NovbeId = n.Id,
                    KassirAdi = isciler.ContainsKey(n.IsciId) ? isciler[n.IsciId] : "Naməlum",
                    BaglanmaTarixi = n.BaglanmaTarixi.GetValueOrDefault()
                })
                .OrderByDescending(n => n.BaglanmaTarixi)
                .ToList();

            return EmeliyyatNeticesi<List<BaglanmisNovbeDto>>.Ugurlu(dtoSiyahisi);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Növbələr gətirilərkən xəta baş verdi: "); // Xətanı qeyd etmək üçün
            return EmeliyyatNeticesi<List<BaglanmisNovbeDto>>.Ugursuz($"Növbələr gətirilərkən xəta baş verdi: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Seçilmiş bir növbənin Z-Hesabatını yenidən yaradır.
    /// </summary>
    /// <param name="novbeId">Hesabatı tələb olunan növbənin ID-si.</param>
    public async Task<EmeliyyatNeticesi<ZHesabatDto>> ZHesabatTekrarGetirAsync(int novbeId)
    {
        Logger.MelumatYaz($"Z-Hesabat üçün növbə ID-si: {novbeId}");
        try
        {
            Novbe novbe = await _unitOfWork.Novbeler.GetirAsync(novbeId);
            if (novbe == null || novbe.Status == NovbeStatusu.Aciq)
            {
                return EmeliyyatNeticesi<ZHesabatDto>.Ugursuz("Bağlanmış növbə tapılmadı.");
            }

            IEnumerable<Satis> novbeSatislar = await _unitOfWork.Satislar.AxtarAsync(s => s.NovbeId == novbeId);
            Istifadeci isci = await _unitOfWork.Istifadeciler.GetirAsync(novbe.IsciId);

            ZHesabatDto hesabat = new()
            {
                AcilmaTarixi = novbe.AcilmaTarixi,
                BaglanmaTarixi = novbe.BaglanmaTarixi.Value,
                KassirAdi = isci?.TamAd ?? "Naməlum",
                BaslangicMebleg = novbe.BaslangicMebleg,
                SatisSayi = novbeSatislar.Count(),
                NagdSatislar = novbeSatislar.Where(s => s.OdenisMetodu == OdenisMetodu.Nağd).Sum(s => s.UmumiMebleg),
                KartSatislar = novbeSatislar.Where(s => s.OdenisMetodu == OdenisMetodu.Kart).Sum(s => s.UmumiMebleg),
                GozlenilenMebleg = novbe.GozlenilenMebleg,
                FaktikiMebleg = novbe.FaktikiMebleg
            };

            return EmeliyyatNeticesi<ZHesabatDto>.Ugurlu(hesabat);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Z-Hesabat hazırlanarkən xəta baş verdi: "); // Xətanı qeyd etmək üçün
            return EmeliyyatNeticesi<ZHesabatDto>.Ugursuz($"Z-Hesabat hazırlanarkən xəta baş verdi: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Mənfəət və Zərər (P&L - Profit & Loss) hesabatını hazırlayır.
    /// diqqət: Bu hesabat satış gəlirlərini, COGS-u (Cost of Goods Sold), və ümumi xərcləri birləşdirir.
    /// qeyd: Hesabat müəyyən tarix aralığı üçün hazırlanır.
    /// rol: Maliyyə təhlili və qərar qəbuletmə üçün əsas göstəricidir.
    /// </summary>
    /// <param name="baslangic">Hesabatın başlanğıc tarixi</param>
    /// <param name="bitis">Hesabatın bitmə tarixi</param>
    /// <returns>P&L hesabat məlumatları</returns>
    public async Task<EmeliyyatNeticesi<MenfeetZererHesabatDto>> MenfeetZererHesabatiGetirAsync(DateTime baslangic, DateTime bitis)
    {
        Logger.MelumatYaz($"Mənfəət və Zərər hesabatı hazırlanır: {baslangic:d} - {bitis:d}");
        try
        {
            DateTime baslangicTarixi = baslangic.Date;
            DateTime bitisTarixi = bitis.Date.AddDays(1).AddTicks(-1);

            // 1. Ümumi Satış Gəlirini hesabla
            IEnumerable<Satis> satislar = await _unitOfWork.Satislar.AxtarAsync(s => s.Tarix >= baslangicTarixi && s.Tarix <= bitisTarixi);
            decimal umumiSatisGeliri = satislar.Sum(s => s.UmumiMebleg);

            // 2. Satılan Malların Maya Dəyərini (COGS) hesabla
            // COGS = Satılan məhsulların alış qiymətlərinin cəmi
            decimal cogs = 0;
            foreach (Satis satis in satislar)
            {
                // Satış detallarını əldə et
                ICollection<SatisDetali> satisDetallari = satis.SatisDetallari;
                foreach (SatisDetali detal in satisDetallari)
                {
                    // Məhsulun alış qiymətini tap
                    Mehsul mehsul = await _unitOfWork.Mehsullar.GetirAsync(detal.MehsulId);
                    if (mehsul != null && mehsul.AlisQiymeti > 0)
                    {
                        cogs += detal.Miqdar * mehsul.AlisQiymeti;
                    }
                }
            }

            // 3. Əməliyyat Xərclərini hesabla (Xərc cədvəlindən)
            EmeliyyatNeticesi<List<Xerc>> xerclerNetice = await _maliyyeManager.ButunXercleriGetirAsync(baslangicTarixi, bitisTarixi);
            decimal emeliyyatXercleri = xerclerNetice.UgurluDur
                ? xerclerNetice.Data.Where(x => x.Novu != XercNovu.EmekHaqqi).Sum(x => x.Mebleg)
                : 0;

            // 4. Əmək Haqqı Xərclərini hesabla
            decimal emekHaqqiXercleri = xerclerNetice.UgurluDur
                ? xerclerNetice.Data.Where(x => x.Novu == XercNovu.EmekHaqqi).Sum(x => x.Mebleg)
                : 0;

            // 5. Hesabatı yarat
            MenfeetZererHesabatDto hesabat = new()
            {
                BaslangicTarixi = baslangicTarixi,
                BitisTarixi = bitisTarixi,
                UmumiSatisGeliri = umumiSatisGeliri,
                SatilanMallarinMayaDeyeri = cogs,
                EmeliyyatXercleri = emeliyyatXercleri,
                EmekHaqqiXercleri = emekHaqqiXercleri
            };

            Logger.MelumatYaz($"Mənfəət və Zərər hesabatı hazırlandı: Gəlir={umumiSatisGeliri}, COGS={cogs}, Xərclər={hesabat.UmumiXercler}, Nəticə={hesabat.YekunMenfeetZerer}");
            return EmeliyyatNeticesi<MenfeetZererHesabatDto>.Ugurlu(hesabat);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Mənfəət və Zərər hesabatı hazırlanarkən xəta baş verdi");
            return EmeliyyatNeticesi<MenfeetZererHesabatDto>.Ugursuz($"Mənfəət və Zərər hesabatı hazırlanarkən xəta baş verdi: {ex.Message}");
        }
    }
}