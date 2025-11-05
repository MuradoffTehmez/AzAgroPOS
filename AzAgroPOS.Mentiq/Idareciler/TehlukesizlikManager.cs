// Fayl: AzAgroPOS.Mentiq/Idareciler/TehlukesizlikManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// TehlukesizlikManager, istifadəçi girişini və təhlükəsizlik yoxlamalarını idarə edən menecer.
/// Features: Account lockout, session management, password validation, audit logging
/// </summary>
public class TehlukesizlikManager
{
    private readonly IUnitOfWork _unitOfWork;

    // Security Configuration
    private const int MaksimumUgursuzCehd = 5; // 5 uğursuz cəhddən sonra kilidlənir
    private const int Kilidlenmemuddeti = 30; // 30 dəqiqə kilidlənmə
    private const int SessiyaTimeout = 30; // 30 dəqiqə sessiya timeout

    public TehlukesizlikManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// DaxilOlAsync metodu istifadəçi adı və parol ilə istifadəçi girişini yoxlayır
    /// uğurlu giriş halında istifadəçi məlumatlarını IstifadeciDto formatında qaytarır.
    /// uğursuz giriş halında isə müvafiq xətanı bildirir.
    ///
    /// Security Features:
    /// - Account lockout after 5 failed attempts
    /// - Session management with timeout
    /// - Audit logging for all login attempts
    /// - Account active/inactive status check
    /// </summary>
    /// <param name="istifadeciAdi">İstifadəçi adı</param>
    /// <param name="parol">Şifrə</param>
    /// <param name="ipUnvani">IP ünvanı (optional)</param>
    /// <param name="komputerAdi">Kompüter adı (optional)</param>
    public async Task<EmeliyyatNeticesi<IstifadeciDto>> DaxilOlAsync(
        string istifadeciAdi,
        string parol,
        string? ipUnvani = null,
        string? komputerAdi = null)
    {
        var temizlenmisAd = istifadeciAdi.Trim();
        var temizlenmisParol = parol.Trim();

        if (string.IsNullOrWhiteSpace(temizlenmisAd) || string.IsNullOrWhiteSpace(temizlenmisParol))
        {
            await GirisLoquYaz(temizlenmisAd, false, "Boş istifadəçi adı və ya parol", ipUnvani, komputerAdi);
            return EmeliyyatNeticesi<IstifadeciDto>.Ugursuz("İstifadəçi adı və parol boş ola bilməz.");
        }

        var istifadeci = (await _unitOfWork.Istifadeciler.AxtarAsync(i => i.IstifadeciAdi == temizlenmisAd)).FirstOrDefault();

        if (istifadeci == null)
        {
            await GirisLoquYaz(temizlenmisAd, false, "İstifadəçi tapılmadı", ipUnvani, komputerAdi);
            return EmeliyyatNeticesi<IstifadeciDto>.Ugursuz("İstifadəçi adı və ya parol yanlışdır.");
        }

        // ===== ACCOUNT ACTIVE STATUS CHECK =====
        if (!istifadeci.HesabAktivdir)
        {
            await GirisLoquYaz(temizlenmisAd, false, "Hesab deaktiv edilib", ipUnvani, komputerAdi);
            return EmeliyyatNeticesi<IstifadeciDto>.Ugursuz("Hesabınız deaktiv edilib. Zəhmət olmasa administrator ilə əlaqə saxlayın.");
        }

        // ===== ACCOUNT LOCKOUT CHECK =====
        if (istifadeci.HesabKilidlenmeTarixi.HasValue)
        {
            var kilidAcilmaVaxti = istifadeci.HesabKilidlenmeTarixi.Value.AddMinutes(Kilidlenmemuddeti);

            if (DateTime.Now < kilidAcilmaVaxti)
            {
                var qalanDeqiqe = (int)(kilidAcilmaVaxti - DateTime.Now).TotalMinutes;
                await GirisLoquYaz(temizlenmisAd, false, "Hesab kilidlənib", ipUnvani, komputerAdi);
                return EmeliyyatNeticesi<IstifadeciDto>.Ugursuz($"Hesabınız kilidlənib. {qalanDeqiqe} dəqiqədən sonra yenidən cəhd edin.");
            }
            else
            {
                // Kilid müddəti bitib - kilidləməni aç
                istifadeci.HesabKilidlenmeTarixi = null;
                istifadeci.UgursuzGirisCehdi = 0;
                _unitOfWork.Istifadeciler.Yenile(istifadeci);
                await _unitOfWork.YaddaşaYazAsync();
            }
        }

        // ===== PASSWORD VERIFICATION =====
        bool parolDogrudur = BCrypt.Net.BCrypt.Verify(temizlenmisParol, istifadeci.ParolHash);

        if (!parolDogrudur)
        {
            // Uğursuz cəhd sayını artır
            istifadeci.UgursuzGirisCehdi++;

            // 5 uğursuz cəhddən sonra kilidlə
            if (istifadeci.UgursuzGirisCehdi >= MaksimumUgursuzCehd)
            {
                istifadeci.HesabKilidlenmeTarixi = DateTime.Now;
                _unitOfWork.Istifadeciler.Yenile(istifadeci);
                await _unitOfWork.YaddaşaYazAsync();

                await GirisLoquYaz(temizlenmisAd, false, $"Yanlış parol - Hesab kilidləndi ({MaksimumUgursuzCehd} uğursuz cəhd)", ipUnvani, komputerAdi);
                Logger.XəbərdarlıqYaz($"TƏHLÜKƏSIZLIK: İstifadəçi {temizlenmisAd} hesabı {MaksimumUgursuzCehd} uğursuz cəhddən sonra kilidləndi.");

                return EmeliyyatNeticesi<IstifadeciDto>.Ugursuz($"Yanlış parol. Hesabınız {MaksimumUgursuzCehd} uğursuz cəhd səbəbi ilə {Kilidlenmemuddeti} dəqiqəliyə kilidləndi.");
            }

            _unitOfWork.Istifadeciler.Yenile(istifadeci);
            await _unitOfWork.YaddaşaYazAsync();

            var qalanCehd = MaksimumUgursuzCehd - istifadeci.UgursuzGirisCehdi;
            await GirisLoquYaz(temizlenmisAd, false, "Yanlış parol", ipUnvani, komputerAdi);

            return EmeliyyatNeticesi<IstifadeciDto>.Ugursuz($"İstifadəçi adı və ya parol yanlışdır. Qalan cəhd: {qalanCehd}");
        }

        // ===== SUCCESSFUL LOGIN =====

        // Reset uğursuz cəhd sayını
        istifadeci.UgursuzGirisCehdi = 0;
        istifadeci.SonGirisTarixi = DateTime.Now;
        _unitOfWork.Istifadeciler.Yenile(istifadeci);
        await _unitOfWork.YaddaşaYazAsync();

        // Sessiya yarat
        await SessiyaYaratAsync(istifadeci.Id, ipUnvani, komputerAdi);

        // Giriş loqunu yaz
        await GirisLoquYaz(temizlenmisAd, true, "Uğurlu giriş", ipUnvani, komputerAdi);

        var istifadeciRol = await _unitOfWork.Rollar.GetirAsync(istifadeci.RolId);
        var istifadeciDto = new IstifadeciDto
        {
            Id = istifadeci.Id,
            IstifadeciAdi = istifadeci.IstifadeciAdi,
            TamAd = istifadeci.TamAd,
            RolAdi = istifadeciRol?.Ad ?? "Təyin edilməyib"
        };

        Logger.MelumatYaz($"İstifadəçi uğurla giriş etdi: {istifadeciDto.IstifadeciAdi} ({istifadeciDto.TamAd})");

        return EmeliyyatNeticesi<IstifadeciDto>.Ugurlu(istifadeciDto);
    }

    /// <summary>
    /// Şifrə dəyişdirmə (mürəkkəblik yoxlaması ilə)
    /// </summary>
    public async Task<EmeliyyatNeticesi> SifreDeyisAsync(int istifadeciId, string kohneParol, string yeniParol)
    {
        var istifadeci = await _unitOfWork.Istifadeciler.GetirAsync(istifadeciId);
        if (istifadeci == null)
            return EmeliyyatNeticesi.Ugursuz("İstifadəçi tapılmadı.");

        // Köhnə şifrəni yoxla
        bool parolDogrudur = BCrypt.Net.BCrypt.Verify(kohneParol, istifadeci.ParolHash);
        if (!parolDogrudur)
            return EmeliyyatNeticesi.Ugursuz("Köhnə şifrə yanlışdır.");

        // Yeni şifrəni validate et
        var (kecerlidir, mesaj) = SifreValidator.Yoxla(yeniParol);
        if (!kecerlidir)
            return EmeliyyatNeticesi.Ugursuz(mesaj);

        // Yeni şifrəni hash-lə və yadda saxla
        istifadeci.ParolHash = BCrypt.Net.BCrypt.HashPassword(yeniParol);
        istifadeci.SonSifreDeyismeTarixi = DateTime.Now;
        _unitOfWork.Istifadeciler.Yenile(istifadeci);
        await _unitOfWork.YaddaşaYazAsync();

        Logger.MelumatYaz($"İstifadəçi şifrəsini dəyişdi: {istifadeci.IstifadeciAdi}");

        return EmeliyyatNeticesi.Ugurlu("Şifrə uğurla dəyişdirildi.");
    }

    /// <summary>
    /// Sessiya yaradır
    /// </summary>
    private async Task SessiyaYaratAsync(int istifadeciId, string? ipUnvani, string? komputerAdi)
    {
        // Köhnə aktiv sessiyaları bağla
        var kohnesessiyalar = await _unitOfWork.Repozitoriler["IstifadeciSessiyasi"].AxtarAsync(
            s => ((IstifadeciSessiyasi)s).IstifadeciId == istifadeciId && ((IstifadeciSessiyasi)s).Aktivdir
        );

        foreach (IstifadeciSessiyasi kohnesessiya in kohnesessiyalar)
        {
            kohnesessiya.Aktivdir = false;
            kohnesessiya.BitməTarixi = DateTime.Now;
        }

        // Yeni sessiya
        var sessiya = new IstifadeciSessiyasi
        {
            IstifadeciId = istifadeciId,
            BaslamaTarixi = DateTime.Now,
            SonAktivlikTarixi = DateTime.Now,
            Aktivdir = true,
            IpUnvani = ipUnvani,
            KomputerAdi = komputerAdi
        };

        await _unitOfWork.Repozitoriler["IstifadeciSessiyasi"].ElaveEtAsync(sessiya);
        await _unitOfWork.YaddaşaYazAsync();
    }

    /// <summary>
    /// Giriş audit loqu yazır
    /// </summary>
    private async Task GirisLoquYaz(string istifadeciAdi, bool ugurlu, string? sebeb, string? ipUnvani, string? komputerAdi)
    {
        var loq = new GirisLoquKaydi
        {
            IstifadeciAdi = istifadeciAdi,
            Ugurlu = ugurlu,
            CehdTarixi = DateTime.Now,
            IpUnvani = ipUnvani,
            KomputerAdi = komputerAdi,
            UgursuzluqSebebi = ugurlu ? null : sebeb
        };

        await _unitOfWork.Repozitoriler["GirisLoquKaydi"].ElaveEtAsync(loq);
        await _unitOfWork.YaddaşaYazAsync();
    }

    /// <summary>
    /// Sessiya timeout yoxlaması
    /// </summary>
    public async Task<bool> SessiyaKecerlidirasAsync(int istifadeciId)
    {
        var sessiya = (await _unitOfWork.Repozitoriler["IstifadeciSessiyasi"].AxtarAsync(
            s => ((IstifadeciSessiyasi)s).IstifadeciId == istifadeciId && ((IstifadeciSessiyasi)s).Aktivdir
        )).Cast<IstifadeciSessiyasi>().FirstOrDefault();

        if (sessiya == null)
            return false;

        var timeoutMuddeti = sessiya.SonAktivlikTarixi.AddMinutes(SessiyaTimeout);

        if (DateTime.Now > timeoutMuddeti)
        {
            // Sessiya timeout olub
            sessiya.Aktivdir = false;
            sessiya.BitməTarixi = DateTime.Now;
            await _unitOfWork.YaddaşaYazAsync();
            return false;
        }

        // Aktivliyi yenilə
        sessiya.SonAktivlikTarixi = DateTime.Now;
        await _unitOfWork.YaddaşaYazAsync();

        return true;
    }

    /// <summary>
    /// Sessiyadan çıxış
    /// </summary>
    public async Task CixisAsync(int istifadeciId)
    {
        var sessiya = (await _unitOfWork.Repozitoriler["IstifadeciSessiyasi"].AxtarAsync(
            s => ((IstifadeciSessiyasi)s).IstifadeciId == istifadeciId && ((IstifadeciSessiyasi)s).Aktivdir
        )).Cast<IstifadeciSessiyasi>().FirstOrDefault();

        if (sessiya != null)
        {
            sessiya.Aktivdir = false;
            sessiya.BitməTarixi = DateTime.Now;
            await _unitOfWork.YaddaşaYazAsync();
        }
    }
}