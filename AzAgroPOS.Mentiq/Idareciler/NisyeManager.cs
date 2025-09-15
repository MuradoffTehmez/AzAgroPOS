// Fayl: AzAgroPOS.Mentiq/Idareciler/NisyeManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

// using-lər
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;

/// <summary>
/// Nisye (borc) əməliyyatlarını idarə edən menecer.
/// </summary>
public class NisyeManager
{
    private readonly IUnitOfWork _unitOfWork;

    public NisyeManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Müştərilərin siyahısını DTO formatında gətirir.
    /// bu metod bütün müştəriləri gətirir və onların ID, tam adı, telefon nömrəsi, ünvanı və ümumi borcunu göstərir.
    /// diqqət: Müştərilərin borcunu hesablamaq üçün NisyeHereketleri cədvəlindən istifadə olunur.
    /// listəki hər müştəri üçün ümumi borc, onun bütün borc əməliyyatlarının cəmi ilə hesablanır.
    /// </summary>
    /// <returns></returns>
    public async Task<EmeliyyatNeticesi<List<MusteriDto>>> MusterileriGetirAsync()
    {
        var musteriler = await _unitOfWork.Musteriler.ButununuGetirAsync();
        var dtolar = musteriler.Select(m => new MusteriDto
        {
            Id = m.Id,
            TamAd = m.TamAd,
            TelefonNomresi = m.TelefonNomresi,
            Unvan = m.Unvan,
            UmumiBorc = m.UmumiBorc
        }).ToList();
        return EmeliyyatNeticesi<List<MusteriDto>>.Ugurlu(dtolar);
    }

    /// <summary>
    /// Müştəriyə yeni borc əməliyyatı əlavə edir.
    /// Diqqət: Bu metod müştərinin ID-sini, əməliyyat növünü (borc və ya ödəniş), məbləği və qeydi alır.
    /// Qeyd: Əməliyyat növü "Borc" və ya "Odenis" olmalıdır.
    /// listəki hər müştəri üçün ümumi borc, onun bütün borc əməliyyatlarının cəmi ilə hesablanır.
    /// </summary>
    /// <param name="musteriId"></param>
    /// <returns></returns>
    public async Task<EmeliyyatNeticesi<List<NisyeHereketiDto>>> MusteriHereketleriniGetirAsync(int musteriId)
    {
        var hereketler = await _unitOfWork.NisyeHereketleri
                                          .AxtarAsync(h => h.MusteriId == musteriId);

        var dtolar = hereketler.OrderByDescending(h => h.Tarix)
                               .Select(h => new NisyeHereketiDto
                               {
                                   Tarix = h.Tarix,
                                   EmeliyyatNovu = h.EmeliyyatNovu.ToString(),
                                   Mebleg = h.Mebleg,
                                   Qeyd = h.Qeyd ?? ""
                               }).ToList();

        return EmeliyyatNeticesi<List<NisyeHereketiDto>>.Ugurlu(dtolar);
    }

    /// <summary>
    /// Borc əməliyyatını müştəri üçün qeydə alır.
    /// bu metod müştərinin ID-sini, əməliyyat növünü (borc və ya ödəniş), məbləği və qeydi alır.
    /// ödəniş məbləği müsbət olmalıdır və müştərinin ümumi borcundan çox olmamalıdır.
    /// ödəniş əməliyyatı üçün müştərinin ümumi borcu azaldılır və yeni hərəkət qeydə alınır.
    /// borc əməliyyatı üçün müştərinin ümumi borcu artırılır və yeni hərəkət qeydə alınır.
    /// diqqət: Əməliyyat növü "Borc" və ya "Odenis" olmalıdır.
    /// </summary>
    /// <param name="musteriId"></param>
    /// <param name="odenenMebleg"></param>
    /// <returns></returns>
    public async Task<EmeliyyatNeticesi> BorcOdenisiEtAsync(int musteriId, decimal odenenMebleg)
    {
        if (odenenMebleg <= 0)
            return EmeliyyatNeticesi.Ugursuz("Ödəniş məbləği müsbət olmalıdır.");

        var musteri = await _unitOfWork.Musteriler.GetirAsync(musteriId);
        if (musteri == null)
            return EmeliyyatNeticesi.Ugursuz("Müştəri tapılmadı.");

        if (odenenMebleg > musteri.UmumiBorc)
            return EmeliyyatNeticesi.Ugursuz("Ödəniş məbləği mövcud borcdan çox ola bilməz.");

        // Borcu azalt
        musteri.UmumiBorc -= odenenMebleg;
        _unitOfWork.Musteriler.Yenile(musteri);

        // Hərəkəti qeydə al
        var hereket = new NisyeHereketi
        {
            MusteriId = musteriId,
            Tarix = DateTime.Now,
            EmeliyyatNovu = EmeliyyatNovu.Odenis,
            Mebleg = odenenMebleg,
            Qeyd = "Nağd ödəniş"
        };
        await _unitOfWork.NisyeHereketleri.ElaveEtAsync(hereket);

        // Qeyd: Tranzaksiya idarəsi çağıran metod tərəfindən həyata keçirilir
        return EmeliyyatNeticesi.Ugurlu();
    }

    /// <summary>
    /// Nisyə olaraq həyata keçirilən satışı müştərinin borc hesabına əlavə edir.
    /// Diqqət: Bu metod SatisManager tərəfindən vahid tranzaksiya daxilində çağırılmalıdır.
    /// </summary>
    public async Task<EmeliyyatNeticesi> NisyeyeSatisElaveEtAsync(Satis satis)
    {
        if (!satis.MusteriId.HasValue)
            return EmeliyyatNeticesi.Ugursuz("Nisyə satış üçün müştəri seçilməlidir.");

        var musteri = await _unitOfWork.Musteriler.GetirAsync(satis.MusteriId.Value);
        if (musteri == null)
            return EmeliyyatNeticesi.Ugursuz("Müştəri tapılmadı.");

        musteri.UmumiBorc += satis.UmumiMebleg;
        _unitOfWork.Musteriler.Yenile(musteri);

        var hereket = new NisyeHereketi
        {
            MusteriId = musteri.Id,
            Tarix = satis.Tarix,
            EmeliyyatNovu = EmeliyyatNovu.Satis,
            Mebleg = satis.UmumiMebleg,
            SatisId = satis.Id,
            Qeyd = $"Satış #{satis.Id}"
        };
        await _unitOfWork.NisyeHereketleri.ElaveEtAsync(hereket);

        return EmeliyyatNeticesi.Ugurlu();
    }
}