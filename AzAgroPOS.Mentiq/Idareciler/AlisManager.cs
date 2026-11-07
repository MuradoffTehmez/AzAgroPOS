// Fayl: AzAgroPOS.Mentiq/Idareciler/AlisManager.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using Microsoft.Extensions.DependencyInjection;

namespace AzAgroPOS.Mentiq.Idareciler;
/// <summary>
/// Alış prosesini idarə edən menecer.
/// Bu menecer tədarükçülərin qeydiyyatı, alış sifarişlərinin yaradılması, 
/// mal qəbulu və tədarükçülərə olan borcların uçotunu həyata keçirir.
/// </summary>
public class AlisManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly StokHareketiManager _stokHareketiManager;
    private readonly IServiceProvider _serviceProvider;

    public AlisManager(IUnitOfWork unitOfWork, StokHareketiManager stokHareketiManager, IServiceProvider serviceProvider)
    {
        _unitOfWork = unitOfWork;
        _stokHareketiManager = stokHareketiManager;
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Ayrı DbContext scope-unda əməliyyat icra edir.
    /// Bu, paralel sorğuların eyni DbContext instance-ını istifadə etməməsini təmin edir.
    /// </summary>
    private async Task<T> ExecuteInSeparateScope<T>(Func<IUnitOfWork, Task<T>> operation)
    {
        await using AsyncServiceScope scope = _serviceProvider.CreateAsyncScope();
        IUnitOfWork unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        return await operation(unitOfWork);
    }

    #region Tədarükçü Əməliyyatları

    /// <summary>
    /// Bütün tədarükçüləri DTO formatında gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<TedarukcuDto>>> ButunTedarukculeriGetirAsync()
    {
        Logger.MelumatYaz("ButunTedarukculeriGetirAsync metodu çağırıldı.");
        try
        {
            IEnumerable<Tedarukcu> tedarukculer = await _unitOfWork.Tedarukculer.ButununuGetirAsync();
            List<TedarukcuDto> dtolar = tedarukculer.Select(t => new TedarukcuDto
            {
                Id = t.Id,
                Ad = t.Ad,
                Voen = t.Voen,
                Unvan = t.Unvan,
                Telefon = t.Telefon,
                Email = t.Email,
                BankHesabi = t.BankHesabi,
                Aktivdir = t.Aktivdir
            }).ToList();

            return EmeliyyatNeticesi<List<TedarukcuDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Tədarükçüləri gətirmək alınmadı");
            return EmeliyyatNeticesi<List<TedarukcuDto>>.Ugursuz($"Tədarükçüləri gətirmək alınmadı: {ex.Message} + {ex.StackTrace} ");
        }
    }

    /// <summary>
    /// Verilmiş ID-yə görə tədarükçü məlumatlarını gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<TedarukcuDto>> TedarukcuGetirAsync(int id)
    {
        Logger.MelumatYaz($"TedarukcuGetirAsync metodu çağırıldı. ID: {id}");
        try
        {
            Tedarukcu tedarukcu = await _unitOfWork.Tedarukculer.GetirAsync(id);
            if (tedarukcu == null)
            {
                return EmeliyyatNeticesi<TedarukcuDto>.Ugursuz("Tədarükçü tapılmadı.");
            }

            TedarukcuDto dto = new()
            {
                Id = tedarukcu.Id,
                Ad = tedarukcu.Ad,
                Voen = tedarukcu.Voen,
                Unvan = tedarukcu.Unvan,
                Telefon = tedarukcu.Telefon,
                Email = tedarukcu.Email,
                BankHesabi = tedarukcu.BankHesabi,
                Aktivdir = tedarukcu.Aktivdir
            };

            return EmeliyyatNeticesi<TedarukcuDto>.Ugurlu(dto);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Tədarükçü məlumatlarını gətirmək alınmadı");
            return EmeliyyatNeticesi<TedarukcuDto>.Ugursuz($"Tədarükçü məlumatlarını gətirmək alınmadı: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Yeni tədarükçü yaradır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> TedarukcuYaratAsync(TedarukcuDto dto)
    {
        Logger.MelumatYaz("TedarukcuYaratAsync metodu çağırıldı.");
        try
        {
            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.Ad))
            {
                return EmeliyyatNeticesi<int>.Ugursuz("Tədarükçü adı boş ola bilməz.");
            }

            // Yeni tədarükçü obyekti yaradırıq
            Tedarukcu yeniTedarukcu = new()
            {
                Ad = dto.Ad,
                Voen = dto.Voen,
                Unvan = dto.Unvan,
                Telefon = dto.Telefon,
                Email = dto.Email,
                BankHesabi = dto.BankHesabi,
                Aktivdir = dto.Aktivdir
            };

            await _unitOfWork.Tedarukculer.ElaveEtAsync(yeniTedarukcu);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi<int>.Ugurlu(yeniTedarukcu.Id);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Tədarükçüləri yaratmaq alınmadı");
            return EmeliyyatNeticesi<int>.Ugursuz($"Tədarükçü yaratmaq alınmadı: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Mövcud tədarükçünün məlumatlarını yeniləyir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> TedarukcuYenileAsync(TedarukcuDto dto)
    {
        Logger.MelumatYaz($"TedarukcuYenileAsync metodu çağırıldı. ID: {dto.Id}");
        try
        {
            Tedarukcu movcudTedarukcu = await _unitOfWork.Tedarukculer.GetirAsync(dto.Id);
            if (movcudTedarukcu == null)
            {
                return EmeliyyatNeticesi.Ugursuz("Yenilənmək üçün tədarükçü tapılmadı.");
            }

            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.Ad))
            {
                return EmeliyyatNeticesi.Ugursuz("Tədarükçü adı boş ola bilməz.");
            }

            // Məlumatları yeniləyirik
            movcudTedarukcu.Ad = dto.Ad;
            movcudTedarukcu.Voen = dto.Voen;
            movcudTedarukcu.Unvan = dto.Unvan;
            movcudTedarukcu.Telefon = dto.Telefon;
            movcudTedarukcu.Email = dto.Email;
            movcudTedarukcu.BankHesabi = dto.BankHesabi;
            movcudTedarukcu.Aktivdir = dto.Aktivdir;

            _unitOfWork.Tedarukculer.Yenile(movcudTedarukcu);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Tədarükçüləri məlumatlarını yeniləmək alınmadı");
            return EmeliyyatNeticesi.Ugursuz($"Tədarükçü məlumatlarını yeniləmək alınmadı: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Tədarükçü silir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> TedarukcuSilAsync(int id)
    {
        Logger.MelumatYaz($"TedarukcuSilAsync metodu çağırıldı. ID: {id}");
        try
        {
            Tedarukcu tedarukcu = await _unitOfWork.Tedarukculer.GetirAsync(id);
            if (tedarukcu == null)
            {
                return EmeliyyatNeticesi.Ugursuz("Silinəcək tədarükçü tapılmadı.");
            }

            _unitOfWork.Tedarukculer.Sil(tedarukcu);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Tədarükçüləri silmək alınmadı");
            return EmeliyyatNeticesi.Ugursuz($"Tədarükçü silmək alınmadı: {ex.Message}");
        }
    }

    #endregion

    #region Alış Sifarişi Əməliyyatları

    /// <summary>
    /// Bütün alış sifarişlərini DTO formatında gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<AlisSifarisDto>>> ButunAlisSifarisleriniGetirAsync()
    {
        Logger.MelumatYaz("ButunAlisSifarisleriniGetirAsync metodu çağırıldı.");
        try
        {
            // Parallel execution with separate DbContext instances - performance optimization
            // Hər sorğu ayrı scope-da icra olunur ki, DbContext concurrency xətası yaranmasın
            Task<IEnumerable<AlisSifaris>> sifarislerTask = ExecuteInSeparateScope(uow => uow.AlisSifarisleri.ButununuGetirAsync());
            Task<IEnumerable<Tedarukcu>> tedarukculerTask = ExecuteInSeparateScope(uow => uow.Tedarukculer.ButununuGetirAsync());
            await Task.WhenAll(sifarislerTask, tedarukculerTask);

            IEnumerable<AlisSifaris> sifarisler = await sifarislerTask;
            IEnumerable<Tedarukcu> tedarukculer = await tedarukculerTask;

            List<AlisSifarisDto> dtolar = sifarisler.Select(s => new AlisSifarisDto
            {
                Id = s.Id,
                SifarisNomresi = s.SifarisNomresi,
                YaradilmaTarixi = s.YaradilmaTarixi,
                TesdiqTarixi = s.TesdiqTarixi,
                GozlenilenTehvilTarixi = s.GozlenilenTehvilTarixi,
                FaktikiTehvilTarixi = s.FaktikiTehvilTarixi,
                TedarukcuId = s.TedarukcuId,
                TedarukcuAdi = tedarukculer.FirstOrDefault(t => t.Id == s.TedarukcuId)?.Ad ?? "Naməlum",
                UmumiMebleg = s.UmumiMebleg,
                Status = s.Status,
                Qeydler = s.Qeydler
            }).ToList();

            return EmeliyyatNeticesi<List<AlisSifarisDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Alış sifarişlərini gətirmək alınmadı");
            return EmeliyyatNeticesi<List<AlisSifarisDto>>.Ugursuz($"Alış sifarişlərini gətirmək alınmadı: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Verilmiş ID-yə görə alış sifarişi məlumatlarını gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<AlisSifarisDto>> AlisSifarisGetirAsync(int id)
    {
        Logger.MelumatYaz($"AlisSifarisGetirAsync metodu çağırıldı. ID: {id}");
        try
        {
            AlisSifaris sifaris = await _unitOfWork.AlisSifarisleri.GetirAsync(id);
            if (sifaris == null)
            {
                return EmeliyyatNeticesi<AlisSifarisDto>.Ugursuz("Alış sifarişi tapılmadı.");
            }

            // Parallel execution with separate DbContext instances - performance optimization
            // Hər sorğu ayrı scope-da icra olunur ki, DbContext concurrency xətası yaranmasın
            Task<Tedarukcu> tedarukcuTask = ExecuteInSeparateScope(uow => uow.Tedarukculer.GetirAsync(sifaris.TedarukcuId));
            Task<IEnumerable<AlisSifarisSetiri>> sifarisSetirTask = ExecuteInSeparateScope(uow => uow.AlisSifarisSetirleri.AxtarAsync(s => s.AlisSifarisId == sifaris.Id));
            Task<IEnumerable<Mehsul>> mehsullarTask = ExecuteInSeparateScope(uow => uow.Mehsullar.ButununuGetirAsync());
            await Task.WhenAll(tedarukcuTask, sifarisSetirTask, mehsullarTask);

            Tedarukcu tedarukcu = await tedarukcuTask;
            IEnumerable<AlisSifarisSetiri> sifarisSetirleri = await sifarisSetirTask;
            IEnumerable<Mehsul> mehsullar = await mehsullarTask;

            AlisSifarisDto dto = new()
            {
                Id = sifaris.Id,
                SifarisNomresi = sifaris.SifarisNomresi,
                YaradilmaTarixi = sifaris.YaradilmaTarixi,
                TesdiqTarixi = sifaris.TesdiqTarixi,
                GozlenilenTehvilTarixi = sifaris.GozlenilenTehvilTarixi,
                FaktikiTehvilTarixi = sifaris.FaktikiTehvilTarixi,
                TedarukcuId = sifaris.TedarukcuId,
                TedarukcuAdi = tedarukcu?.Ad ?? "Naməlum",
                UmumiMebleg = sifaris.UmumiMebleg,
                Status = sifaris.Status,
                Qeydler = sifaris.Qeydler,
                SifarisSetirleri = sifarisSetirleri.Select(s => new AlisSifarisSetiriDto
                {
                    Id = s.Id,
                    AlisSifarisId = s.AlisSifarisId,
                    MehsulId = s.MehsulId,
                    MehsulAdi = mehsullar.FirstOrDefault(m => m.Id == s.MehsulId)?.Ad ?? "Naməlum",
                    Miqdar = s.Miqdar,
                    BirVahidQiymet = s.BirVahidQiymet,
                    CemiMebleg = s.CemiMebleg,
                    TehvilAlinanMiqdar = s.TehvilAlinanMiqdar,
                    QalanMiqdar = s.QalanMiqdar
                }).ToList()
            };

            return EmeliyyatNeticesi<AlisSifarisDto>.Ugurlu(dto);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Alış sifarişi məlumatlarını gətirmək alınmadı");
            return EmeliyyatNeticesi<AlisSifarisDto>.Ugursuz($"Alış sifarişi məlumatlarını gətirmək alınmadı: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Yeni alış sifarişi yaradır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> AlisSifarisYaratAsync(AlisSifarisDto dto)
    {
        if (!IcazeYoxlayici.Instance.IcazeVarmi(SistemIcazeleri.AlisSenediYarat))
            return EmeliyyatNeticesi<int>.Ugursuz("Alış sifarişi yaratmağa icazəniz yoxdur.");
        Logger.MelumatYaz("AlisSifarisYaratAsync metodu çağırıldı.");
        try
        {
            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.SifarisNomresi))
            {
                return EmeliyyatNeticesi<int>.Ugursuz("Sifariş nömrəsi boş ola bilməz.");
            }

            if (dto.TedarukcuId <= 0)
            {
                return EmeliyyatNeticesi<int>.Ugursuz("Tədarükçü seçilməlidir.");
            }

            if (dto.SifarisSetirleri == null || dto.SifarisSetirleri.Count == 0 ||
                dto.SifarisSetirleri.Any(s => s.MehsulId <= 0 || s.Miqdar <= 0 || s.BirVahidQiymet < 0 ||
                    s.CemiMebleg != decimal.Round(s.Miqdar * s.BirVahidQiymet, 2, MidpointRounding.AwayFromZero)))
                return EmeliyyatNeticesi<int>.Ugursuz("Sifariş sətirləri və məbləğləri düzgün deyil.");
            if (dto.UmumiMebleg != dto.SifarisSetirleri.Sum(s => s.CemiMebleg))
                return EmeliyyatNeticesi<int>.Ugursuz("Sifariş yekunu sətirlərin cəminə uyğun deyil.");

            return await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
            // Yeni alış sifarişi obyekti yaradırıq
            AlisSifaris yeniSifaris = new()
            {
                SifarisNomresi = dto.SifarisNomresi,
                YaradilmaTarixi = dto.YaradilmaTarixi,
                TesdiqTarixi = dto.TesdiqTarixi,
                GozlenilenTehvilTarixi = dto.GozlenilenTehvilTarixi,
                TedarukcuId = dto.TedarukcuId,
                UmumiMebleg = dto.UmumiMebleg,
                Status = dto.Status,
                Qeydler = dto.Qeydler
            };

            await _unitOfWork.AlisSifarisleri.ElaveEtAsync(yeniSifaris);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            // Sifariş sətirlərini yaradırıq
            foreach (AlisSifarisSetiriDto setirDto in dto.SifarisSetirleri)
            {
                AlisSifarisSetiri setir = new()
                {
                    AlisSifarisId = yeniSifaris.Id,
                    MehsulId = setirDto.MehsulId,
                    Miqdar = setirDto.Miqdar,
                    BirVahidQiymet = setirDto.BirVahidQiymet,
                    CemiMebleg = setirDto.CemiMebleg,
                    TehvilAlinanMiqdar = setirDto.TehvilAlinanMiqdar
                };

                await _unitOfWork.AlisSifarisSetirleri.ElaveEtAsync(setir);
            }

            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi<int>.Ugurlu(yeniSifaris.Id);
            });
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Alış sifarişi yaratmaq alınmadı");
            return EmeliyyatNeticesi<int>.Ugursuz($"Alış sifarişi yaratmaq alınmadı: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Mövcud alış sifarişini yeniləyir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> AlisSifarisYenileAsync(AlisSifarisDto dto)
    {
        if (!IcazeYoxlayici.Instance.IcazeVarmi(SistemIcazeleri.AlisSenediDeyis))
            return EmeliyyatNeticesi.Ugursuz("Alış sifarişini dəyişməyə icazəniz yoxdur.");
        Logger.MelumatYaz($"AlisSifarisYenileAsync metodu çağırıldı. ID: {dto.Id}");
        try
        {
            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.SifarisNomresi))
            {
                return EmeliyyatNeticesi.Ugursuz("Sifariş nömrəsi boş ola bilməz.");
            }

            if (dto.TedarukcuId <= 0)
            {
                return EmeliyyatNeticesi.Ugursuz("Tədarükçü seçilməlidir.");
            }

            // Mövcud alış sifarişini axtarırıq
            AlisSifaris movcudSifaris = await _unitOfWork.AlisSifarisleri.GetirAsync(dto.Id);
            if (movcudSifaris == null)
            {
                return EmeliyyatNeticesi.Ugursuz("Yenilənmək üçün alış sifarişi tapılmadı.");
            }

            // Məlumatları yeniləyirik
            movcudSifaris.SifarisNomresi = dto.SifarisNomresi;
            movcudSifaris.YaradilmaTarixi = dto.YaradilmaTarixi;
            movcudSifaris.TesdiqTarixi = dto.TesdiqTarixi;
            movcudSifaris.GozlenilenTehvilTarixi = dto.GozlenilenTehvilTarixi;
            movcudSifaris.TedarukcuId = dto.TedarukcuId;
            movcudSifaris.UmumiMebleg = dto.UmumiMebleg;
            movcudSifaris.Status = dto.Status;
            movcudSifaris.Qeydler = dto.Qeydler;

            _unitOfWork.AlisSifarisleri.Yenile(movcudSifaris);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Alış sifarişini yeniləmək alınmadı");
            return EmeliyyatNeticesi.Ugursuz($"Alış sifarişini yeniləmək alınmadı: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Alış sifarişini silir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> AlisSifarisSilAsync(int id)
    {
        if (!IcazeYoxlayici.Instance.IcazeVarmi(SistemIcazeleri.AlisSenediSil))
            return EmeliyyatNeticesi.Ugursuz("Alış sifarişini silməyə icazəniz yoxdur.");
        Logger.MelumatYaz($"AlisSifarisSilAsync metodu çağırıldı. ID: {id}");
        try
        {
            // Mövcud alış sifarişini axtarırıq
            AlisSifaris movcudSifaris = await _unitOfWork.AlisSifarisleri.GetirAsync(id);
            if (movcudSifaris == null)
            {
                return EmeliyyatNeticesi.Ugursuz("Silinəcək alış sifarişi tapılmadı.");
            }

            _unitOfWork.AlisSifarisleri.Sil(movcudSifaris);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Alış sifarişini silmək alınmadı");
            return EmeliyyatNeticesi.Ugursuz($"Alış sifarişini silmək alınmadı: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Alış sifarişini təsdiqləyir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> AlisSifarisiniTesdiqleAsync(int id)
    {
        if (!IcazeYoxlayici.Instance.IcazeVarmi(SistemIcazeleri.AlisSenediDeyis))
            return EmeliyyatNeticesi.Ugursuz("Alış sifarişini təsdiqləməyə icazəniz yoxdur.");
        Logger.MelumatYaz($"AlisSifarisiniTesdiqleAsync metodu çağırıldı. ID: {id}");
        try
        {
            AlisSifaris sifaris = await _unitOfWork.AlisSifarisleri.GetirAsync(id);
            if (sifaris == null)
            {
                return EmeliyyatNeticesi.Ugursuz("Təsdiqlənmək üçün alış sifarişi tapılmadı.");
            }

            if (sifaris.Status != AlisSifarisStatusu.Yaradildi)
            {
                return EmeliyyatNeticesi.Ugursuz("Yalnız yaradılmış sifarişləri təsdiqləmək olar.");
            }

            sifaris.Status = AlisSifarisStatusu.Tesdiqlendi;
            sifaris.TesdiqTarixi = DateTime.Now;

            _unitOfWork.AlisSifarisleri.Yenile(sifaris);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Alış sifarişini təsdiqləmək alınmadı");
            return EmeliyyatNeticesi.Ugursuz($"Alış sifarişini təsdiqləmək alınmadı: {ex.Message}+ {ex.StackTrace}");
        }
    }

    #endregion

    #region Alış Sənədi Əməliyyatları

    /// <summary>
    /// Bütün alış sənədlərini DTO formatında gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<AlisSenedDto>>> ButunAlisSenetleriniGetirAsync()
    {
        Logger.MelumatYaz("ButunAlisSenetleriniGetirAsync metodu çağırıldı.");
        try
        {
            IEnumerable<AlisSened> senetler = await _unitOfWork.AlisSenetleri.ButununuGetirAsync();
            IEnumerable<Tedarukcu> tedarukculer = await _unitOfWork.Tedarukculer.ButununuGetirAsync();
            List<int> senedIdleri = senetler.Select(s => s.Id).ToList();
            List<AlisSenedSetiri> butunSetirler = (await _unitOfWork.AlisSenedSetirleri
                .AxtarAsync(s => senedIdleri.Contains(s.AlisSenedId))).ToList();
            List<int> mehsulIdleri = butunSetirler.Select(s => s.MehsulId).Distinct().ToList();
            Dictionary<int, string> mehsulAdlari = (await _unitOfWork.Mehsullar
                .AxtarAsync(m => mehsulIdleri.Contains(m.Id))).ToDictionary(m => m.Id, m => m.Ad);

            List<AlisSenedDto> dtolar = senetler.Select(s => new AlisSenedDto
            {
                Id = s.Id,
                SenedNomresi = s.SenedNomresi,
                YaradilmaTarixi = s.YaradilmaTarixi,
                TedarukcuId = s.TedarukcuId,
                TedarukcuAdi = tedarukculer.FirstOrDefault(t => t.Id == s.TedarukcuId)?.Ad ?? "Naməlum",
                TehvilTarixi = s.TehvilTarixi,
                UmumiMebleg = s.UmumiMebleg,
                Status = s.Status,
                Qeydler = s.Qeydler,
                SenedSetirleri = butunSetirler.Where(setir => setir.AlisSenedId == s.Id)
                    .Select(setir => new AlisSenedSetiriDto
                    {
                        Id = setir.Id,
                        AlisSenedId = setir.AlisSenedId,
                        MehsulId = setir.MehsulId,
                        MehsulAdi = mehsulAdlari.GetValueOrDefault(setir.MehsulId, "Naməlum"),
                        Miqdar = setir.Miqdar,
                        BirVahidQiymet = setir.BirVahidQiymet,
                        CemiMebleg = setir.CemiMebleg,
                        AlisSifarisSetiriId = setir.AlisSifarisSetiriId
                    }).ToList()
            }).ToList();

            return EmeliyyatNeticesi<List<AlisSenedDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Alış sənədlərini gətirmək alınmadı");
            return EmeliyyatNeticesi<List<AlisSenedDto>>.Ugursuz($"Alış sənədlərini gətirmək alınmadı: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Yeni alış sənədi yaradır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> AlisSenedYaratAsync(AlisSenedDto dto)
    {
        if (!IcazeYoxlayici.Instance.IcazeVarmi(SistemIcazeleri.AlisSenediYarat))
            return EmeliyyatNeticesi<int>.Ugursuz("Alış sənədi yaratmağa icazəniz yoxdur.");
        Logger.MelumatYaz("AlisSenedYaratAsync metodu çağırıldı.");
        try
        {
            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.SenedNomresi))
            {
                return EmeliyyatNeticesi<int>.Ugursuz("Sənəd nömrəsi boş ola bilməz.");
            }

            if (dto.TedarukcuId <= 0)
            {
                return EmeliyyatNeticesi<int>.Ugursuz("Tədarükçü seçilməlidir.");
            }

            if (dto.SenedSetirleri.Count == 0 || dto.SenedSetirleri.Any(s => s.Miqdar <= 0 || s.Miqdar != decimal.Round(s.Miqdar, 3)))
                return EmeliyyatNeticesi<int>.Ugursuz("Alış sənədində müsbət və ən çox üç onluq dəqiqlikdə miqdar olmalıdır.");
            var alinanMehsulIdleri = dto.SenedSetirleri.Select(s => s.MehsulId).Distinct().ToList();
            var alinanMehsullar = (await _unitOfWork.Mehsullar.AxtarAsync(m => alinanMehsulIdleri.Contains(m.Id)))
                .ToDictionary(m => m.Id);
            if (alinanMehsullar.Count != alinanMehsulIdleri.Count || dto.SenedSetirleri.Any(s =>
                (alinanMehsullar[s.MehsulId].OlcuVahidi == OlcuVahidi.Ədəd || alinanMehsullar[s.MehsulId].OlcuVahidi == OlcuVahidi.Paket) &&
                s.Miqdar != decimal.Truncate(s.Miqdar)))
                return EmeliyyatNeticesi<int>.Ugursuz("Məhsul tapılmadı və ya ədəd/paket miqdarı kəsrlidir.");
            if (dto.SenedSetirleri.Any(s => s.MehsulId <= 0 || s.BirVahidQiymet < 0 ||
                s.CemiMebleg != decimal.Round(s.Miqdar * s.BirVahidQiymet, 2, MidpointRounding.AwayFromZero)) ||
                dto.UmumiMebleg != dto.SenedSetirleri.Sum(s => s.CemiMebleg))
                return EmeliyyatNeticesi<int>.Ugursuz("Alış sənədinin məbləği sətirlərin cəminə uyğun deyil.");
            if (dto.Status == AlisSenedStatusu.LegvEdildi)
                return EmeliyyatNeticesi<int>.Ugursuz("Ləğv edilmiş sənədlə stok artırıla bilməz.");

            return await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
            // Yeni alış sənədi obyekti yaradırıq
            AlisSened yeniSened = new()
            {
                SenedNomresi = dto.SenedNomresi,
                YaradilmaTarixi = dto.YaradilmaTarixi,
                TedarukcuId = dto.TedarukcuId,
                TehvilTarixi = dto.TehvilTarixi,
                UmumiMebleg = dto.UmumiMebleg,
                Status = AlisSenedStatusu.Tesdiqlendi,
                Qeydler = dto.Qeydler
            };

            await _unitOfWork.AlisSenetleri.ElaveEtAsync(yeniSened);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            // Sənəd sətirlərini yaradırıq
            foreach (AlisSenedSetiriDto setirDto in dto.SenedSetirleri)
            {
                AlisSenedSetiri setir = new()
                {
                    AlisSenedId = yeniSened.Id,
                    MehsulId = setirDto.MehsulId,
                    Miqdar = setirDto.Miqdar,
                    BirVahidQiymet = setirDto.BirVahidQiymet,
                    CemiMebleg = setirDto.CemiMebleg,
                    AlisSifarisSetiriId = setirDto.AlisSifarisSetiriId
                };

                await _unitOfWork.AlisSenedSetirleri.ElaveEtAsync(setir);

                // Stok hərəkətini qeydə alırıq (Daxilolma)
                EmeliyyatNeticesi<int> stokNeticesi = await _stokHareketiManager.StokHareketiQeydeAlAsync(
                    StokHareketTipi.Daxilolma,
                    SenedNovu.Alis,
                    yeniSened.Id,
                    setirDto.MehsulId,
                    setirDto.Miqdar,
                    setirDto.BirVahidQiymet, // Alış qiyməti
                    setirDto.BirVahidQiymet, // Satış qiyməti (alımda təyin olunmur, ona görə eyni qoyuruq)
                    $"Alış sənədi: {dto.SenedNomresi}",
                    null // İstifadəçi ID-si
                );

                if (!stokNeticesi.UgurluDur)
                {
                    Logger.XəbərdarlıqYaz($"Stok hərəkəti qeydə alınarkən xəta: {stokNeticesi.Mesaj}");
                    throw new InvalidOperationException($"Stok hərəkəti qeydə alınarkən xəta: {stokNeticesi.Mesaj}");
                }
                await _unitOfWork.EmeliyyatiTesdiqleAsync();
            }

            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi<int>.Ugurlu(yeniSened.Id);
            });
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Alış sənədi yaratmaq alınmadı");
            return EmeliyyatNeticesi<int>.Ugursuz($"Alış sənədi yaratmaq alınmadı: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Mövcud alış sənədini yeniləyir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> AlisSenedYenileAsync(AlisSenedDto dto)
    {
        if (!IcazeYoxlayici.Instance.IcazeVarmi(SistemIcazeleri.AlisSenediDeyis))
            return EmeliyyatNeticesi.Ugursuz("Alış sənədini dəyişməyə icazəniz yoxdur.");
        Logger.MelumatYaz($"AlisSenedYenileAsync metodu çağırıldı. ID: {dto.Id}");
        try
        {
            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.SenedNomresi))
            {
                return EmeliyyatNeticesi.Ugursuz("Sənəd nömrəsi boş ola bilməz.");
            }

            if (dto.TedarukcuId <= 0)
            {
                return EmeliyyatNeticesi.Ugursuz("Tədarükçü seçilməlidir.");
            }

            // Mövcud alış sənədini axtarırıq
            AlisSened movcudSened = await _unitOfWork.AlisSenetleri.GetirAsync(dto.Id);
            if (movcudSened == null)
            {
                return EmeliyyatNeticesi.Ugursuz("Yenilənmək üçün alış sənədi tapılmadı.");
            }

            if (movcudSened.Status != AlisSenedStatusu.Tesdiqlendi ||
                dto.TedarukcuId != movcudSened.TedarukcuId ||
                dto.UmumiMebleg != movcudSened.UmumiMebleg ||
                dto.Status != movcudSened.Status)
                return EmeliyyatNeticesi.Ugursuz("Təsdiqlənmiş alışın tədarükçüsü, məbləği və statusu dəyişdirilə bilməz. Səhv qəbulu ləğv edib yenisini yaradın.");
            if (dto.SenedSetirleri.Count > 0)
            {
                List<AlisSenedSetiri> setirler = (await _unitOfWork.AlisSenedSetirleri
                    .AxtarAsync(s => s.AlisSenedId == dto.Id)).ToList();
                if (dto.SenedSetirleri.Count != setirler.Count || dto.SenedSetirleri.Any(s =>
                    !setirler.Any(k => k.Id == s.Id && k.MehsulId == s.MehsulId &&
                        k.Miqdar == s.Miqdar && k.BirVahidQiymet == s.BirVahidQiymet)))
                    return EmeliyyatNeticesi.Ugursuz("Təsdiqlənmiş alışın məhsul sətirləri dəyişdirilə bilməz. Səhv qəbulu ləğv edib yenisini yaradın.");
            }

            // Məlumatları yeniləyirik
            movcudSened.SenedNomresi = dto.SenedNomresi;
            movcudSened.YaradilmaTarixi = dto.YaradilmaTarixi;
            movcudSened.TehvilTarixi = dto.TehvilTarixi;
            movcudSened.Qeydler = dto.Qeydler;

            _unitOfWork.AlisSenetleri.Yenile(movcudSened);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Alış sənədini yeniləmək alınmadı");
            return EmeliyyatNeticesi.Ugursuz($"Alış sənədini yeniləmək alınmadı: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Alış sənədini silir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> AlisSenedSilAsync(int id)
    {
        if (!IcazeYoxlayici.Instance.IcazeVarmi(SistemIcazeleri.AlisSenediSil))
            return EmeliyyatNeticesi.Ugursuz("Alış sənədini ləğv etməyə icazəniz yoxdur.");
        Logger.MelumatYaz($"AlisSenedSilAsync metodu çağırıldı. ID: {id}");
        try
        {
            // Mövcud alış sənədini axtarırıq
            AlisSened movcudSened = await _unitOfWork.AlisSenetleri.GetirAsync(id);
            if (movcudSened == null)
            {
                return EmeliyyatNeticesi.Ugursuz("Silinəcək alış sənədi tapılmadı.");
            }
            if (movcudSened.Status == AlisSenedStatusu.LegvEdildi)
                return EmeliyyatNeticesi.Ugursuz("Alış sənədi artıq ləğv edilib.");
            if ((await _unitOfWork.TedarukcuOdemeleri.AxtarAsync(o =>
                o.AlisSenedId == id && o.Status != OdemeStatusu.LegvEdildi)).Any())
                return EmeliyyatNeticesi.Ugursuz("Ödənişi olan alış sənədini ləğv etmək olmaz.");
            decimal tedarukcuOdenisleri = (await _unitOfWork.TedarukcuOdemeleri.AxtarAsync(o =>
                o.TedarukcuId == movcudSened.TedarukcuId && o.Status != OdemeStatusu.LegvEdildi)).Sum(o => o.Mebleg);
            decimal digerSenetler = (await _unitOfWork.AlisSenetleri.AxtarAsync(s =>
                s.TedarukcuId == movcudSened.TedarukcuId && s.Id != id && s.Status != AlisSenedStatusu.LegvEdildi))
                .Sum(s => s.UmumiMebleg);
            if (tedarukcuOdenisleri > digerSenetler)
                return EmeliyyatNeticesi.Ugursuz("Bu sənəd ləğv edilərsə tədarükçü ödənişləri alış borcunu keçəcək.");

            return await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                List<AlisSenedSetiri> setirler = (await _unitOfWork.AlisSenedSetirleri
                    .AxtarAsync(s => s.AlisSenedId == id)).ToList();
                foreach (AlisSenedSetiri setir in setirler)
                {
                    EmeliyyatNeticesi<int> hereket = await _stokHareketiManager.StokHareketiQeydeAlAsync(
                        StokHareketTipi.Cixis, SenedNovu.Alis, id, setir.MehsulId,
                        setir.Miqdar, setir.BirVahidQiymet, setir.BirVahidQiymet,
                        $"Alış sənədi #{id} ləğv edildi", null);
                    if (!hereket.UgurluDur) throw new InvalidOperationException(hereket.Mesaj);
                }
                movcudSened.Status = AlisSenedStatusu.LegvEdildi;
                _unitOfWork.AlisSenetleri.Yenile(movcudSened);
                await _unitOfWork.EmeliyyatiTesdiqleAsync();
                return EmeliyyatNeticesi.Ugurlu();
            });
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Alış sənədini silmək alınmadı");
            return EmeliyyatNeticesi.Ugursuz($"Alış sənədini silmək alınmadı: {ex.Message}+ {ex.StackTrace}");
        }
    }

    #endregion

    #region Tədarükçü Ödənişi Əməliyyatları

    /// <summary>
    /// Bütün tədarükçü ödənişlərini DTO formatında gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<TedarukcuOdemeDto>>> ButunTedarukcuOdemeleriniGetirAsync()
    {
        Logger.MelumatYaz("ButunTedarukcuOdemeleriniGetirAsync metodu çağırıldı.");
        try
        {
            IEnumerable<TedarukcuOdeme> odemeler = await _unitOfWork.TedarukcuOdemeleri.ButununuGetirAsync();
            IEnumerable<Tedarukcu> tedarukculer = await _unitOfWork.Tedarukculer.ButununuGetirAsync();
            IEnumerable<AlisSened> senetler = await _unitOfWork.AlisSenetleri.ButununuGetirAsync();

            List<TedarukcuOdemeDto> dtolar = odemeler.Select(o => new TedarukcuOdemeDto
            {
                Id = o.Id,
                OdemeNomresi = o.OdemeNomresi,
                YaradilmaTarixi = o.YaradilmaTarixi,
                TedarukcuId = o.TedarukcuId,
                TedarukcuAdi = tedarukculer.FirstOrDefault(t => t.Id == o.TedarukcuId)?.Ad ?? "Naməlum",
                AlisSenedId = o.AlisSenedId,
                AlisSenedNomresi = o.AlisSenedId.HasValue ? senetler.FirstOrDefault(s => s.Id == o.AlisSenedId.Value)?.SenedNomresi : null,
                OdemeTarixi = o.OdemeTarixi,
                Mebleg = o.Mebleg,
                OdemeUsulu = o.OdemeUsulu,
                Status = o.Status,
                Qeydler = o.Qeydler,
                BankMelumatlari = o.BankMelumatlari
            }).ToList();

            return EmeliyyatNeticesi<List<TedarukcuOdemeDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Tədarükçü ödənişlərini gətirmək alınmadı");
            return EmeliyyatNeticesi<List<TedarukcuOdemeDto>>.Ugursuz($"Tədarükçü ödənişlərini gətirmək alınmadı: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Yeni tədarükçü ödənişi yaradır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> TedarukcuOdemeYaratAsync(TedarukcuOdemeDto dto)
    {
        if (!IcazeYoxlayici.Instance.IcazeVarmi(SistemIcazeleri.AlisSenediDeyis))
            return EmeliyyatNeticesi<int>.Ugursuz("Tədarükçü ödənişi yaratmağa icazəniz yoxdur.");
        Logger.MelumatYaz("TedarukcuOdemeYaratAsync metodu çağırıldı.");
        try
        {
            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.OdemeNomresi))
            {
                return EmeliyyatNeticesi<int>.Ugursuz("Ödəniş nömrəsi boş ola bilməz.");
            }

            if (dto.TedarukcuId <= 0)
            {
                return EmeliyyatNeticesi<int>.Ugursuz("Tədarükçü seçilməlidir.");
            }

            if (dto.Mebleg <= 0)
            {
                return EmeliyyatNeticesi<int>.Ugursuz("Ödəniş məbləği müsbət olmalıdır.");
            }

            return await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
            List<AlisSened> senetler = (await _unitOfWork.AlisSenetleri
                .AxtarAsync(s => s.TedarukcuId == dto.TedarukcuId && s.Status != AlisSenedStatusu.LegvEdildi)).ToList();
            if (dto.AlisSenedId.HasValue && !senetler.Any(s => s.Id == dto.AlisSenedId.Value))
                return EmeliyyatNeticesi<int>.Ugursuz("Seçilmiş alış sənədi bu tədarükçüyə aid deyil.");
            decimal odenilen = (await _unitOfWork.TedarukcuOdemeleri
                .AxtarAsync(o => o.TedarukcuId == dto.TedarukcuId && o.Status != OdemeStatusu.LegvEdildi))
                .Sum(o => o.Mebleg);
            if (dto.Mebleg > senetler.Sum(s => s.UmumiMebleg) - odenilen)
                return EmeliyyatNeticesi<int>.Ugursuz("Ödəniş tədarükçünün qalan borcunu keçir.");

            // Yeni tədarükçü ödənişi obyekti yaradırıq
            TedarukcuOdeme yeniOdeme = new()
            {
                OdemeNomresi = dto.OdemeNomresi,
                YaradilmaTarixi = dto.YaradilmaTarixi,
                TedarukcuId = dto.TedarukcuId,
                AlisSenedId = dto.AlisSenedId,
                OdemeTarixi = dto.OdemeTarixi,
                Mebleg = dto.Mebleg,
                OdemeUsulu = dto.OdemeUsulu,
                Status = OdemeStatusu.Tesdiqlendi,
                Qeydler = dto.Qeydler,
                BankMelumatlari = dto.BankMelumatlari
            };

            await _unitOfWork.TedarukcuOdemeleri.ElaveEtAsync(yeniOdeme);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            if (dto.OdemeUsulu == OdemeUsulu.Naqd)
            {
                int? istifadeciId = IcazeYoxlayici.Instance.AktivIstifadeci?.Id;
                Novbe? novbe = istifadeciId.HasValue
                    ? await _unitOfWork.Novbeler.AktivNovbeniGetirAsync(istifadeciId.Value) : null;
                await _unitOfWork.KassaHareketleri.ElaveEtAsync(new KassaHareketi
                {
                    HareketNovu = KassaHareketiNovu.Cixis,
                    EmeliyyatNovu = EmeliyyatNovu.Odenis,
                    EmeliyyatId = yeniOdeme.Id,
                    NovbeId = novbe?.Id,
                    OdenisMetodu = OdenisMetodu.Nağd,
                    Mebleg = dto.Mebleg,
                    Tarix = dto.OdemeTarixi,
                    Qeyd = $"Tədarükçü ödənişi #{yeniOdeme.Id}",
                    IstifadeciId = istifadeciId
                });
                await _unitOfWork.EmeliyyatiTesdiqleAsync();
            }

            return EmeliyyatNeticesi<int>.Ugurlu(yeniOdeme.Id);
            });
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Tədarükçü ödənişi yaratmaq alınmadı");
            return EmeliyyatNeticesi<int>.Ugursuz($"Tədarükçü ödənişi yaratmaq alınmadı: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Mövcud tədarükçü ödənişini yeniləyir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> TedarukcuOdemeYenileAsync(TedarukcuOdemeDto dto)
    {
        if (!IcazeYoxlayici.Instance.IcazeVarmi(SistemIcazeleri.AlisSenediDeyis))
            return EmeliyyatNeticesi.Ugursuz("Tədarükçü ödənişini dəyişməyə icazəniz yoxdur.");
        Logger.MelumatYaz($"TedarukcuOdemeYenileAsync metodu çağırıldı. ID: {dto.Id}");
        try
        {
            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.OdemeNomresi))
            {
                return EmeliyyatNeticesi.Ugursuz("Ödəniş nömrəsi boş ola bilməz.");
            }

            if (dto.TedarukcuId <= 0)
            {
                return EmeliyyatNeticesi.Ugursuz("Tədarükçü seçilməlidir.");
            }

            if (dto.Mebleg <= 0)
            {
                return EmeliyyatNeticesi.Ugursuz("Ödəniş məbləği müsbət olmalıdır.");
            }

            // Mövcud tədarükçü ödənişini axtarırıq
            TedarukcuOdeme movcudOdeme = await _unitOfWork.TedarukcuOdemeleri.GetirAsync(dto.Id);
            if (movcudOdeme == null)
            {
                return EmeliyyatNeticesi.Ugursuz("Yenilənmək üçün tədarükçü ödənişi tapılmadı.");
            }
            if (movcudOdeme.Status == OdemeStatusu.LegvEdildi ||
                dto.TedarukcuId != movcudOdeme.TedarukcuId ||
                dto.AlisSenedId != movcudOdeme.AlisSenedId ||
                dto.Mebleg != movcudOdeme.Mebleg ||
                dto.OdemeUsulu != movcudOdeme.OdemeUsulu)
                return EmeliyyatNeticesi.Ugursuz("Təsdiqlənmiş ödənişin məbləği və əlaqələri dəyişdirilə bilməz. Ödənişi ləğv edib yenisini yaradın.");

            // Məlumatları yeniləyirik
            movcudOdeme.OdemeNomresi = dto.OdemeNomresi;
            movcudOdeme.YaradilmaTarixi = dto.YaradilmaTarixi;
            movcudOdeme.OdemeTarixi = dto.OdemeTarixi;
            movcudOdeme.Qeydler = dto.Qeydler;
            movcudOdeme.BankMelumatlari = dto.BankMelumatlari;

            _unitOfWork.TedarukcuOdemeleri.Yenile(movcudOdeme);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Tədarükçü ödənişini yeniləmək alınmadı");
            return EmeliyyatNeticesi.Ugursuz($"Tədarükçü ödənişini yeniləmək alınmadı: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Tədarükçü ödənişini silir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> TedarukcuOdemeSilAsync(int id)
    {
        if (!IcazeYoxlayici.Instance.IcazeVarmi(SistemIcazeleri.AlisSenediSil))
            return EmeliyyatNeticesi.Ugursuz("Tədarükçü ödənişini ləğv etməyə icazəniz yoxdur.");
        Logger.MelumatYaz($"TedarukcuOdemeSilAsync metodu çağırıldı. ID: {id}");
        try
        {
            // Mövcud tədarükçü ödənişini axtarırıq
            TedarukcuOdeme movcudOdeme = await _unitOfWork.TedarukcuOdemeleri.GetirAsync(id);
            if (movcudOdeme == null)
            {
                return EmeliyyatNeticesi.Ugursuz("Silinəcək tədarükçü ödənişi tapılmadı.");
            }
            if (movcudOdeme.Status == OdemeStatusu.LegvEdildi)
                return EmeliyyatNeticesi.Ugursuz("Ödəniş artıq ləğv edilib.");

            List<KassaHareketi> odemeHereketleri = (await _unitOfWork.KassaHareketleri.AxtarAsync(k =>
                k.EmeliyyatNovu == EmeliyyatNovu.Odenis && k.EmeliyyatId == id &&
                k.Qeyd != null && k.Qeyd.StartsWith("Tədarükçü ödənişi"))).ToList();
            foreach (KassaHareketi hereket in odemeHereketleri.Where(k => k.NovbeId.HasValue))
            {
                Novbe? novbe = await _unitOfWork.Novbeler.GetirAsync(hereket.NovbeId!.Value);
                if (novbe?.Status == NovbeStatusu.Bagli)
                    return EmeliyyatNeticesi.Ugursuz("Bağlı növbənin ödənişini silmək olmaz; ayrıca düzəliş əməliyyatı aparılmalıdır.");
            }

            return await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                foreach (KassaHareketi hereket in odemeHereketleri)
                    _unitOfWork.KassaHareketleri.Sil(hereket);
                movcudOdeme.Status = OdemeStatusu.LegvEdildi;
                _unitOfWork.TedarukcuOdemeleri.Yenile(movcudOdeme);
                await _unitOfWork.EmeliyyatiTesdiqleAsync();
                return EmeliyyatNeticesi.Ugurlu();
            });
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Tədarükçü ödənişini silmək alınmadı");
            return EmeliyyatNeticesi.Ugursuz($"Tədarükçü ödənişini silmək alınmadı: {ex.Message}");
        }
    }
    #endregion

    #region Səhifələmə Əməliyyatları

    /// <summary>
    /// Səhifələnmiş tədarükçü siyahısını əldə edir.
    /// Diqqət: Bu metod böyük məlumat bazaları üçün əlverişlidir.
    /// </summary>
    /// <param name="parametrler">Səhifələmə parametrləri</param>
    /// <returns>Səhifələnmiş tədarükçü məlumatları</returns>
    public async Task<EmeliyyatNeticesi<SehifelenmisMelumat<TedarukcuDto>>> TedarukculeriSehifelenmisGetirAsync(SehifeParametrleri parametrler)
    {
        Logger.MelumatYaz($"Səhifələnmiş tədarükçülər əldə edilir - Səhifə: {parametrler.SehifeNomresi}, Ölçü: {parametrler.SehifeOlcusu}");
        try
        {
            (IEnumerable<Tedarukcu>? tedarukculer, int umumiSay) = await _unitOfWork.Tedarukculer.SehifelenmisGetirAsync(
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu,
                t => t.Aktivdir);

            List<TedarukcuDto> dtolar = tedarukculer.Select(t => new TedarukcuDto
            {
                Id = t.Id,
                Ad = t.Ad,
                Voen = t.Voen,
                Unvan = t.Unvan,
                Telefon = t.Telefon,
                Email = t.Email,
                BankHesabi = t.BankHesabi,
                Aktivdir = t.Aktivdir
            }).ToList();

            SehifelenmisMelumat<TedarukcuDto> sehifelenmis = new(
                dtolar,
                umumiSay,
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu);

            Logger.MelumatYaz($"Səhifələnmiş tədarükçülər uğurla əldə edildi - {dtolar.Count}/{umumiSay}");
            return EmeliyyatNeticesi<SehifelenmisMelumat<TedarukcuDto>>.Ugurlu(sehifelenmis);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Səhifələnmiş tədarükçülər əldə edilərkən istisna baş verdi");
            return EmeliyyatNeticesi<SehifelenmisMelumat<TedarukcuDto>>.Ugursuz($"Səhifələnmiş tədarükçülər əldə edilərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Səhifələnmiş alış sifarişi siyahısını əldə edir.
    /// Diqqət: Bu metod böyük məlumat bazaları üçün əlverişlidir.
    /// </summary>
    /// <param name="parametrler">Səhifələmə parametrləri</param>
    /// <returns>Səhifələnmiş alış sifarişi məlumatları</returns>
    public async Task<EmeliyyatNeticesi<SehifelenmisMelumat<AlisSifarisDto>>> AlisSifarisleriniSehifelenmisGetirAsync(SehifeParametrleri parametrler)
    {
        Logger.MelumatYaz($"Səhifələnmiş alış sifarişləri əldə edilir - Səhifə: {parametrler.SehifeNomresi}, Ölçü: {parametrler.SehifeOlcusu}");
        try
        {
            (IEnumerable<AlisSifaris>? sifarisler, int umumiSay) = await _unitOfWork.AlisSifarisleri.SehifelenmisGetirAsync(
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu,
                a => !a.Silinib);

            IEnumerable<Tedarukcu> tedarukculer = await _unitOfWork.Tedarukculer.ButununuGetirAsync();

            List<AlisSifarisDto> dtolar = sifarisler.Select(s => new AlisSifarisDto
            {
                Id = s.Id,
                SifarisNomresi = s.SifarisNomresi,
                YaradilmaTarixi = s.YaradilmaTarixi,
                TesdiqTarixi = s.TesdiqTarixi,
                GozlenilenTehvilTarixi = s.GozlenilenTehvilTarixi,
                FaktikiTehvilTarixi = s.FaktikiTehvilTarixi,
                TedarukcuId = s.TedarukcuId,
                TedarukcuAdi = tedarukculer.FirstOrDefault(t => t.Id == s.TedarukcuId)?.Ad ?? "Naməlum",
                UmumiMebleg = s.UmumiMebleg,
                Status = s.Status,
                Qeydler = s.Qeydler
            }).ToList();

            SehifelenmisMelumat<AlisSifarisDto> sehifelenmis = new(
                dtolar,
                umumiSay,
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu);

            Logger.MelumatYaz($"Səhifələnmiş alış sifarişləri uğurla əldə edildi - {dtolar.Count}/{umumiSay}");
            return EmeliyyatNeticesi<SehifelenmisMelumat<AlisSifarisDto>>.Ugurlu(sehifelenmis);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Səhifələnmiş alış sifarişləri əldə edilərkən istisna baş verdi");
            return EmeliyyatNeticesi<SehifelenmisMelumat<AlisSifarisDto>>.Ugursuz($"Səhifələnmiş alış sifarişləri əldə edilərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Səhifələnmiş alış sənədi siyahısını əldə edir.
    /// Diqqət: Bu metod böyük məlumat bazaları üçün əlverişlidir.
    /// </summary>
    /// <param name="parametrler">Səhifələmə parametrləri</param>
    /// <returns>Səhifələnmiş alış sənədi məlumatları</returns>
    public async Task<EmeliyyatNeticesi<SehifelenmisMelumat<AlisSenedDto>>> AlisSenetleriniSehifelenmisGetirAsync(SehifeParametrleri parametrler)
    {
        Logger.MelumatYaz($"Səhifələnmiş alış sənədləri əldə edilir - Səhifə: {parametrler.SehifeNomresi}, Ölçü: {parametrler.SehifeOlcusu}");
        try
        {
            (IEnumerable<AlisSened>? senetler, int umumiSay) = await _unitOfWork.AlisSenetleri.SehifelenmisGetirAsync(
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu,
                a => !a.Silinib);

            IEnumerable<Tedarukcu> tedarukculer = await _unitOfWork.Tedarukculer.ButununuGetirAsync();

            List<AlisSenedDto> dtolar = senetler.Select(s => new AlisSenedDto
            {
                Id = s.Id,
                SenedNomresi = s.SenedNomresi,
                YaradilmaTarixi = s.YaradilmaTarixi,
                TedarukcuId = s.TedarukcuId,
                TedarukcuAdi = tedarukculer.FirstOrDefault(t => t.Id == s.TedarukcuId)?.Ad ?? "Naməlum",
                TehvilTarixi = s.TehvilTarixi,
                UmumiMebleg = s.UmumiMebleg,
                Status = s.Status,
                Qeydler = s.Qeydler
            }).ToList();

            SehifelenmisMelumat<AlisSenedDto> sehifelenmis = new(
                dtolar,
                umumiSay,
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu);

            Logger.MelumatYaz($"Səhifələnmiş alış sənədləri uğurla əldə edildi - {dtolar.Count}/{umumiSay}");
            return EmeliyyatNeticesi<SehifelenmisMelumat<AlisSenedDto>>.Ugurlu(sehifelenmis);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Səhifələnmiş alış sənədləri əldə edilərkən istisna baş verdi");
            return EmeliyyatNeticesi<SehifelenmisMelumat<AlisSenedDto>>.Ugursuz($"Səhifələnmiş alış sənədləri əldə edilərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Səhifələnmiş tədarükçü ödənişi siyahısını əldə edir.
    /// Diqqət: Bu metod böyük məlumat bazaları üçün əlverişlidir.
    /// </summary>
    /// <param name="parametrler">Səhifələmə parametrləri</param>
    /// <returns>Səhifələnmiş tədarükçü ödənişi məlumatları</returns>
    public async Task<EmeliyyatNeticesi<SehifelenmisMelumat<TedarukcuOdemeDto>>> TedarukcuOdemeleriniSehifelenmisGetirAsync(SehifeParametrleri parametrler)
    {
        Logger.MelumatYaz($"Səhifələnmiş tədarükçü ödənişləri əldə edilir - Səhifə: {parametrler.SehifeNomresi}, Ölçü: {parametrler.SehifeOlcusu}");
        try
        {
            (IEnumerable<TedarukcuOdeme>? odemeler, int umumiSay) = await _unitOfWork.TedarukcuOdemeleri.SehifelenmisGetirAsync(
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu,
                o => !o.Silinib);

            IEnumerable<Tedarukcu> tedarukculer = await _unitOfWork.Tedarukculer.ButununuGetirAsync();
            IEnumerable<AlisSened> senetler = await _unitOfWork.AlisSenetleri.ButununuGetirAsync();

            List<TedarukcuOdemeDto> dtolar = odemeler.Select(o => new TedarukcuOdemeDto
            {
                Id = o.Id,
                OdemeNomresi = o.OdemeNomresi,
                YaradilmaTarixi = o.YaradilmaTarixi,
                TedarukcuId = o.TedarukcuId,
                TedarukcuAdi = tedarukculer.FirstOrDefault(t => t.Id == o.TedarukcuId)?.Ad ?? "Naməlum",
                AlisSenedId = o.AlisSenedId,
                AlisSenedNomresi = o.AlisSenedId.HasValue ? senetler.FirstOrDefault(s => s.Id == o.AlisSenedId.Value)?.SenedNomresi : null,
                OdemeTarixi = o.OdemeTarixi,
                Mebleg = o.Mebleg,
                OdemeUsulu = o.OdemeUsulu,
                Status = o.Status,
                Qeydler = o.Qeydler,
                BankMelumatlari = o.BankMelumatlari
            }).ToList();

            SehifelenmisMelumat<TedarukcuOdemeDto> sehifelenmis = new(
                dtolar,
                umumiSay,
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu);

            Logger.MelumatYaz($"Səhifələnmiş tədarükçü ödənişləri uğurla əldə edildi - {dtolar.Count}/{umumiSay}");
            return EmeliyyatNeticesi<SehifelenmisMelumat<TedarukcuOdemeDto>>.Ugurlu(sehifelenmis);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Səhifələnmiş tədarükçü ödənişləri əldə edilərkən istisna baş verdi");
            return EmeliyyatNeticesi<SehifelenmisMelumat<TedarukcuOdemeDto>>.Ugursuz($"Səhifələnmiş tədarükçü ödənişləri əldə edilərkən xəta: {ex.Message}");
        }
    }

    #endregion
}
