// Fayl: AzAgroPOS.Mentiq/Idareciler/StokHareketiManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;

/// <summary>
/// Anbar stok hərəkətləri ilə bağlı biznes məntiqini idarə edir
/// diqqət: Bu sinif, stok hərəkətlərinin qeydiyyatı və anbar qalıqlarının hesablanması üçün mərkəzi mənbədir.
/// qeyd: Bütün alış, satış, qaytarma və inventarizasiya əməliyyatları bu Manager vasitəsilə qeydə alınır.
/// rol: Anbar uçotunun dəqiqliyini təmin edir və stok tarixini izləyir.
/// </summary>
public class StokHareketiManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStokHareketiRepozitori _stokHareketiRepo;

    public StokHareketiManager(IUnitOfWork unitOfWork, IStokHareketiRepozitori stokHareketiRepo)
    {
        _unitOfWork = unitOfWork;
        _stokHareketiRepo = stokHareketiRepo;
    }

    /// <summary>
    /// Yeni stok hərəkəti qeydə alır
    /// diqqət: Bu metod, məhsulun anbara daxil olması və ya anbardançıxması hallarını qeydə alır.
    /// qeyd: Hərəkət qeydə alındıqdan sonra avtomatik olaraq verilənlər bazasına yazılır (UnitOfWork.Save() çağırılmalıdır).
    /// </summary>
    /// <param name="hareketTipi">Hərəkət tipi (Daxilolma və ya Çıxış)</param>
    /// <param name="senedNovu">Sənədin növü (Alış, Satış və s.)</param>
    /// <param name="senedId">Sənədin ID-si (nullable)</param>
    /// <param name="mehsulId">Məhsulun ID-si</param>
    /// <param name="miqdar">Hərəkət edilən miqdar (həmişə müsbət)</param>
    /// <param name="alisQiymeti">Məhsulun vahid alış qiyməti (daxilolma üçün)</param>
    /// <param name="satisQiymeti">Məhsulun vahid satış qiyməti (çıxış üçün)</param>
    /// <param name="qeyd">Əlavə qeyd (nullable)</param>
    /// <param name="istifadeciId">İstifadəçinin ID-si (nullable)</param>
    /// <returns>Əməliyyat nəticəsi</returns>
    public async Task<EmeliyyatNeticesi<int>> StokHareketiQeydeAlAsync(
        StokHareketTipi hareketTipi,
        SenedNovu senedNovu,
        int? senedId,
        int mehsulId,
        int miqdar,
        decimal alisQiymeti,
        decimal satisQiymeti,
        string? qeyd = null,
        int? istifadeciId = null)
    {
        Logger.MelumatYaz($"Stok hərəkəti qeydə alınır: MəhsulId={mehsulId}, Tip={hareketTipi}, Miqdar={miqdar}");

        try
        {
            // Validasiya
            if (mehsulId <= 0)
            {
                Logger.XəbərdarlıqYaz("Mehsul ID düzgün deyil");
                return EmeliyyatNeticesi<int>.Ugursuz("Məhsul ID-si düzgün deyil.");
            }

            if (miqdar <= 0)
            {
                Logger.XəbərdarlıqYaz("Miqdar müsbət olmalıdır");
                return EmeliyyatNeticesi<int>.Ugursuz("Miqdar müsbət olmalıdır.");
            }

            // Məhsulun mövcudluğunu yoxla
            var mehsul = await _unitOfWork.Mehsullar.GetirAsync(mehsulId);
            if (mehsul == null)
            {
                Logger.XəbərdarlıqYaz($"Məhsul tapılmadı: ID={mehsulId}");
                return EmeliyyatNeticesi<int>.Ugursuz("Məhsul tapılmadı.");
            }

            // Yeni stok hərəkəti yarat
            var stokHareketi = new StokHareketi
            {
                HareketTipi = hareketTipi,
                SenedNovu = senedNovu,
                SenedId = senedId,
                MehsulId = mehsulId,
                Miqdar = miqdar,
                AlisQiymeti = alisQiymeti,
                SatisQiymeti = satisQiymeti,
                Tarix = DateTime.Now,
                Qeyd = qeyd,
                IstifadeciId = istifadeciId
            };

            await _stokHareketiRepo.ElaveEtAsync(stokHareketi);
            // QEYD: UnitOfWork.Save() çağıran tərəf tərəfindən həyata keçirilməlidir

            Logger.MelumatYaz($"Stok hərəkəti uğurla qeydə alındı: ID={stokHareketi.Id}");
            return EmeliyyatNeticesi<int>.Ugurlu(stokHareketi.Id);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Stok hərəkəti qeydə alınarkən xəta baş verdi");
            return EmeliyyatNeticesi<int>.Ugursuz($"Stok hərəkəti qeydə alınarkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Məhsulun cari anbar qalığını hesablayır
    /// diqqət: Bu metod, məhsulun bütün stok hərəkətlərini təhlil edərək qalığı hesablayır.
    /// qeyd: Qalıq = Daxilolmalar - Çıxışlar
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> MehsulQaliginGetirAsync(int mehsulId)
    {
        Logger.MelumatYaz($"Məhsul qalığı hesablanır: MəhsulId={mehsulId}");

        try
        {
            var qaliq = await _stokHareketiRepo.MehsulQaliginHesabla(mehsulId);

            Logger.MelumatYaz($"Məhsul qalığı hesablandı: Qalıq={qaliq}");
            return EmeliyyatNeticesi<int>.Ugurlu(qaliq);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Məhsul qalığı hesablanarkən xəta baş verdi");
            return EmeliyyatNeticesi<int>.Ugursuz($"Qalıq hesablanarkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Məhsulun stok hərəkətləri tarixçəsini gətirir
    /// diqqət: Tarix aralığı verilməzsə, bütün hərəkətlər qaytarılır.
    /// qeyd: Hesabat və audit üçün istifadə olunur.
    /// </summary>
    public async Task<EmeliyyatNeticesi<IEnumerable<StokHareketi>>> MehsulHereketTarixcesiniGetirAsync(
        int mehsulId,
        DateTime? baslangicTarixi = null,
        DateTime? bitisTarixi = null)
    {
        Logger.MelumatYaz($"Məhsul hərəkət tarixçəsi əldə edilir: MəhsulId={mehsulId}");

        try
        {
            var hereketler = await _stokHareketiRepo.MehsulHereketleriniGetir(mehsulId, baslangicTarixi, bitisTarixi);

            Logger.MelumatYaz($"Məhsul hərəkət tarixçəsi əldə edildi: Say={hereketler.Count()}");
            return EmeliyyatNeticesi<IEnumerable<StokHareketi>>.Ugurlu(hereketler);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Məhsul hərəkət tarixçəsi əldə edilərkən xəta baş verdi");
            return EmeliyyatNeticesi<IEnumerable<StokHareketi>>.Ugursuz($"Hərəkət tarixçəsi əldə edilərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Sənədə aid stok hərəkətlərini gətirir
    /// diqqət: Bu metod, müəyyən sənədin (alış, satış və s.) anbar təsirini izləyir.
    /// qeyd: Sənədin geri qaytarılması və ya düzəlişi zamanı istifadə olunur.
    /// </summary>
    public async Task<EmeliyyatNeticesi<IEnumerable<StokHareketi>>> SenedHereketleriniGetirAsync(
        SenedNovu senedNovu,
        int senedId)
    {
        Logger.MelumatYaz($"Sənəd hərəkətləri əldə edilir: Növ={senedNovu}, ID={senedId}");

        try
        {
            var hereketler = await _stokHareketiRepo.SenedHereketleriniGetir(senedNovu, senedId);

            Logger.MelumatYaz($"Sənəd hərəkətləri əldə edildi: Say={hereketler.Count()}");
            return EmeliyyatNeticesi<IEnumerable<StokHareketi>>.Ugurlu(hereketler);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Sənəd hərəkətləri əldə edilərkən xəta baş verdi");
            return EmeliyyatNeticesi<IEnumerable<StokHareketi>>.Ugursuz($"Sənəd hərəkətləri əldə edilərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Bütün məhsulların anbar qalıqlarını hesablayır
    /// diqqət: Bu əməliyyat resource-intensive olduğundan ehtiyatla istifadə edilməlidir.
    /// qeyd: Anbar qalıq hesabatı üçün istifadə olunur.
    /// </summary>
    public async Task<EmeliyyatNeticesi<Dictionary<int, int>>> ButunMehsulQaliqlariniGetirAsync()
    {
        Logger.MelumatYaz("Bütün məhsul qalıqları hesablanır");

        try
        {
            var qaliqlar = await _stokHareketiRepo.ButunMehsulQaliqlariniHesabla();

            Logger.MelumatYaz($"Bütün məhsul qalıqları hesablandı: Say={qaliqlar.Count}");
            return EmeliyyatNeticesi<Dictionary<int, int>>.Ugurlu(qaliqlar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Bütün məhsul qalıqları hesablanarkən xəta baş verdi");
            return EmeliyyatNeticesi<Dictionary<int, int>>.Ugursuz($"Qalıqlar hesablanarkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// İnventarizasiya düzəlişi yaradır
    /// diqqət: Fiziki sayım nəticəsində sistem stoku ilə real stok arasındakı fərqi düzəldir.
    /// qeyd: Fərq müsbətdirsə Daxilolma, mənfidirsə Çıxış hərəkəti yaradılır.
    /// </summary>
    /// <param name="mehsulId">Məhsulun ID-si</param>
    /// <param name="fizikiQaliq">Fiziki sayım nəticəsi</param>
    /// <param name="qeyd">İzahat</param>
    /// <param name="istifadeciId">İstifadəçinin ID-si</param>
    /// <returns>Əməliyyat nəticəsi</returns>
    public async Task<EmeliyyatNeticesi<int>> InventarizasiyaDuzelisinYaradAsync(
        int mehsulId,
        int fizikiQaliq,
        string? qeyd,
        int? istifadeciId)
    {
        Logger.MelumatYaz($"İnventarizasiya düzəlişi yaradılır: MəhsulId={mehsulId}, Fiziki={fizikiQaliq}");

        try
        {
            // Sistem qalığını hesabla
            var sistemQaliqi = await _stokHareketiRepo.MehsulQaliginHesabla(mehsulId);

            // Fərqi hesabla
            var ferq = fizikiQaliq - sistemQaliqi;

            if (ferq == 0)
            {
                Logger.MelumatYaz("İnventarizasiya fərqi yoxdur - düzəliş tələb olunmur");
                return EmeliyyatNeticesi<int>.Ugurlu(0);
            }

            // Fərqə görə hərəkət tipi müəyyən et
            var hareketTipi = ferq > 0 ? StokHareketTipi.Daxilolma : StokHareketTipi.Cixis;
            var miqdar = Math.Abs(ferq);
            var senedNovu = ferq > 0 ? SenedNovu.DuzeltmeArtirim : SenedNovu.DuzeltmeAzalma;

            var qeydMetni = $"İnventarizasiya düzəlişi. Sistem: {sistemQaliqi}, Fiziki: {fizikiQaliq}, Fərq: {ferq}";
            if (!string.IsNullOrWhiteSpace(qeyd))
            {
                qeydMetni += $" - {qeyd}";
            }

            // Stok hərəkəti yarat
            var netice = await StokHareketiQeydeAlAsync(
                hareketTipi,
                senedNovu,
                null, // Sənəd ID-si yoxdur
                mehsulId,
                miqdar,
                0, // alisQiymeti
                0, // satisQiymeti
                qeydMetni,
                istifadeciId);

            if (netice.UgurluDur)
            {
                Logger.MelumatYaz($"İnventarizasiya düzəlişi yaradıldı: Fərq={ferq}");
            }

            return netice;
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İnventarizasiya düzəlişi yaradılarkən xəta baş verdi");
            return EmeliyyatNeticesi<int>.Ugursuz($"İnventarizasiya düzəlişi xətası: {ex.Message}");
        }
    }

    /// <summary>
    /// Məhsul üçün mənfəət hesablayır
    /// diqqət: Bu metod, məhsulun alış qiyməti və satış qiyməti əsasında mənfəəti hesablayır.
    /// qeyd: Mənfəət = Satış Qiyməti - Alış Qiyməti
    /// </summary>
    /// <param name="mehsulId">Məhsulun ID-si</param>
    /// <param name="baslangicTarixi">Hesablama üçün başlanğıc tarixi (nullable)</param>
    /// <param name="bitisTarixi">Hesablama üçün bitmə tarixi (nullable)</param>
    /// <returns>Mənfəət nəticəsi</returns>
    public async Task<EmeliyyatNeticesi<decimal>> MehsulMenfeetiHesablaAsync(
        int mehsulId,
        DateTime? baslangicTarixi = null,
        DateTime? bitisTarixi = null)
    {
        Logger.MelumatYaz($"Məhsul mənfəəti hesablanır: MəhsulId={mehsulId}");

        try
        {
            var filter = baslangicTarixi.HasValue && bitisTarixi.HasValue
                ? (Func<StokHareketi, bool>)(sh => sh.MehsulId == mehsulId &&
                                                sh.Tarix.Date >= baslangicTarixi.Value.Date &&
                                                sh.Tarix.Date <= bitisTarixi.Value.Date)
                : baslangicTarixi.HasValue
                    ? (Func<StokHareketi, bool>)(sh => sh.MehsulId == mehsulId &&
                                                    sh.Tarix.Date >= baslangicTarixi.Value.Date)
                    : bitisTarixi.HasValue
                        ? (Func<StokHareketi, bool>)(sh => sh.MehsulId == mehsulId &&
                                                        sh.Tarix.Date <= bitisTarixi.Value.Date)
                        : (Func<StokHareketi, bool>)(sh => sh.MehsulId == mehsulId);

            var hereketler = (await _stokHareketiRepo.ButununuGetirAsync()).Where(filter).ToList();

            decimal menfeetToplami = 0;

            foreach (var hereket in hereketler)
            {
                // Mənfəət hərəkətə görə hesablanır
                if (hereket.HareketTipi == StokHareketTipi.Cixis &&
                   (hereket.SenedNovu == SenedNovu.Satis || hereket.SenedNovu == SenedNovu.Qaytarma))
                {
                    // Satış və ya qaytarma çıxışı - gəlir qazanılır
                    menfeetToplami += hereket.UmumiDeyer; // Miqdar * SatisQiymeti
                }
                else if (hereket.HareketTipi == StokHareketTipi.Daxilolma &&
                        (hereket.SenedNovu == SenedNovu.Alis || hereket.SenedNovu == SenedNovu.Qaytarma))
                {
                    // Alış və ya qaytarma daxilolması - xərc tutulur
                    menfeetToplami -= hereket.UmumiDeyer; // Miqdar * AlisQiymeti
                }
            }

            Logger.MelumatYaz($"Məhsul mənfəəti hesablandı: MəhsulId={mehsulId}, Mənfəət={menfeetToplami}");
            return EmeliyyatNeticesi<decimal>.Ugurlu(menfeetToplami);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Məhsul mənfəəti hesablanarkən xəta baş verdi");
            return EmeliyyatNeticesi<decimal>.Ugursuz($"Mənfəət hesablanarkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Ümumi mənfəəti hesablayır
    /// diqqət: Bu metod, bütün məhsullar üçün ümumi mənfəəti hesablayır.
    /// qeyd: Mənfəət = Satış Qiyməti - Alış Qiyməti
    /// </summary>
    public async Task<EmeliyyatNeticesi<decimal>> UmumiMenfeetiHesablaAsync(
        DateTime? baslangicTarixi = null,
        DateTime? bitisTarixi = null)
    {
        Logger.MelumatYaz("Ümumi mənfəət hesablanır");

        try
        {
            var filter = baslangicTarixi.HasValue && bitisTarixi.HasValue
                ? (Func<StokHareketi, bool>)(sh => sh.Tarix.Date >= baslangicTarixi.Value.Date &&
                                                sh.Tarix.Date <= bitisTarixi.Value.Date)
                : baslangicTarixi.HasValue
                    ? (Func<StokHareketi, bool>)(sh => sh.Tarix.Date >= baslangicTarixi.Value.Date)
                    : bitisTarixi.HasValue
                        ? (Func<StokHareketi, bool>)(sh => sh.Tarix.Date <= bitisTarixi.Value.Date)
                        : (Func<StokHareketi, bool>)(sh => true);

            var hereketler = (await _stokHareketiRepo.ButununuGetirAsync()).Where(filter).ToList();

            decimal menfeetToplami = 0;

            foreach (var hereket in hereketler)
            {
                // Mənfəət hərəkətə görə hesablanır
                if (hereket.HareketTipi == StokHareketTipi.Cixis &&
                   (hereket.SenedNovu == SenedNovu.Satis || hereket.SenedNovu == SenedNovu.Qaytarma))
                {
                    // Satış və ya qaytarma çıxışı - gəlir qazanılır
                    menfeetToplami += hereket.UmumiDeyer; // Miqdar * SatisQiymeti
                }
                else if (hereket.HareketTipi == StokHareketTipi.Daxilolma &&
                        (hereket.SenedNovu == SenedNovu.Alis || hereket.SenedNovu == SenedNovu.Qaytarma))
                {
                    // Alış və ya qaytarma daxilolması - xərc tutulur
                    menfeetToplami -= hereket.UmumiDeyer; // Miqdar * AlisQiymeti
                }
            }

            Logger.MelumatYaz($"Ümumi mənfəət hesablandı: Mənfəət={menfeetToplami}");
            return EmeliyyatNeticesi<decimal>.Ugurlu(menfeetToplami);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Ümumi mənfəət hesablanarkən xəta baş verdi");
            return EmeliyyatNeticesi<decimal>.Ugursuz($"Mənfəət hesablanarkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Səhifələnmiş stok hərəkətləri siyahısını əldə edir.
    /// Diqqət: Bu metod böyük məlumat bazaları üçün əlverişlidir.
    /// </summary>
    /// <param name="parametrler">Səhifələmə parametrləri</param>
    /// <returns>Səhifələnmiş stok hərəkəti məlumatları</returns>
    public async Task<EmeliyyatNeticesi<SehifelenmisMelumat<StokHareketi>>> StokHereketleriniSehifelenmisGetirAsync(SehifeParametrleri parametrler)
    {
        Logger.MelumatYaz($"Səhifələnmiş stok hərəkətləri əldə edilir - Səhifə: {parametrler.SehifeNomresi}, Ölçü: {parametrler.SehifeOlcusu}");
        try
        {
            var (hereketler, umumiSay) = await _stokHareketiRepo.SehifelenmisGetirAsync(
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu,
                sh => true);

            var sehifelenmis = new SehifelenmisMelumat<StokHareketi>(
                hereketler.ToList(), umumiSay, parametrler.SehifeNomresi, parametrler.SehifeOlcusu);

            Logger.MelumatYaz($"Səhifələnmiş stok hərəkətləri uğurla əldə edildi - {hereketler.Count()}/{umumiSay}");
            return EmeliyyatNeticesi<SehifelenmisMelumat<StokHareketi>>.Ugurlu(sehifelenmis);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Səhifələnmiş stok hərəkətləri əldə edilərkən istisna baş verdi");
            return EmeliyyatNeticesi<SehifelenmisMelumat<StokHareketi>>.Ugursuz($"Səhifələnmiş stok hərəkətləri əldə edilərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Stok hərəkətlərini DTO formatında qaytarır (UI üçün)
    /// </summary>
    /// <param name="mehsulId">Məhsul ID (null olarsa bütün məhsullar)</param>
    /// <param name="limit">Maksimum qeyd sayı</param>
    /// <returns>StokHareketiDto siyahısı</returns>
    public async Task<EmeliyyatNeticesi<List<DTOs.StokHareketiDto>>> StokHereketleriniDtoFormatindaGetirAsync(
        int? mehsulId = null,
        int limit = 50)
    {
        Logger.MelumatYaz($"Stok hərəkətləri DTO formatında əldə edilir - MəhsulId: {mehsulId}, Limit: {limit}");

        try
        {
            IEnumerable<StokHareketi> hereketler;

            if (mehsulId.HasValue)
            {
                // Məhsul üzrə hərəkətlər
                hereketler = await _stokHareketiRepo.MehsulHereketleriniGetir(mehsulId.Value);
            }
            else
            {
                // Bütün hərəkətlər
                hereketler = await _stokHareketiRepo.ButununuGetirAsync();
            }

            // Entity-ləri DTO-ya çevir
            var dtolar = hereketler
                .OrderByDescending(h => h.Tarix)
                .Take(limit)
                .Select(h => new DTOs.StokHareketiDto
                {
                    Id = h.Id,
                    Tarix = h.Tarix,
                    IstifadeciAdi = h.Istifadeci != null ? h.Istifadeci.TamAd : "Sistem",
                    EmeliyyatNovu = h.SenedNovu.ToString(),
                    MehsulId = h.MehsulId,
                    MehsulAdi = h.Mehsul != null ? h.Mehsul.Ad : "N/A",
                    Qeyd = h.Qeyd ?? "",
                    // Köhnə stok, dəyişiklik və yeni stoku hesablamaq üçün
                    // Bu məlumatlar entity-də yoxdur, ona görə 0 qoyuruq
                    // Real hesabat üçün bu məlumatları ayrıca hesablamaq lazımdır
                    KohneStok = 0,
                    DeyisiklikMiqdari = h.HareketTipi == StokHareketTipi.Daxilolma ? h.Miqdar : -h.Miqdar,
                    YeniStok = 0
                })
                .ToList();

            Logger.MelumatYaz($"Stok hərəkətləri DTO formatında əldə edildi. Say: {dtolar.Count}");
            return EmeliyyatNeticesi<List<DTOs.StokHareketiDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Stok hərəkətləri DTO formatında əldə edilərkən xəta baş verdi");
            return EmeliyyatNeticesi<List<DTOs.StokHareketiDto>>.Ugursuz($"Stok hərəkətləri əldə edilərkən xəta: {ex.Message}");
        }
    }
}
