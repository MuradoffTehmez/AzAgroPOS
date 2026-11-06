// Fayl: AzAgroPOS.Mentiq/Idareciler/NisyeManager.cs

// using-lər
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;

namespace AzAgroPOS.Mentiq.Idareciler;
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
        IEnumerable<Musteri> musteriler = await _unitOfWork.Musteriler.ButununuGetirAsync();
        List<MusteriDto> dtolar = musteriler.Select(m => new MusteriDto
        {
            Id = m.Id,
            TamAd = m.TamAd,
            TelefonNomresi = m.TelefonNomresi,
            Unvan = m.Unvan,
            UmumiBorc = m.UmumiBorc,
            KreditLimiti = m.KreditLimiti
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
        IEnumerable<NisyeHereketi> hereketler = await _unitOfWork.NisyeHereketleri
                                          .AxtarAsync(h => h.MusteriId == musteriId);

        List<NisyeHereketiDto> dtolar = hereketler.OrderByDescending(h => h.Tarix)
                               .Select(h => new NisyeHereketiDto
                               {
                                   Tarix = h.Tarix,
                                   EmeliyyatNovu = h.EmeliyyatNovu == EmeliyyatNovu.IlkinBorc
                                       ? "Əvvəlki borc"
                                       : h.EmeliyyatNovu.ToString(),
                                   Mebleg = h.Mebleg,
                                   Qeyd = h.Qeyd ?? ""
                               }).ToList();

        return EmeliyyatNeticesi<List<NisyeHereketiDto>>.Ugurlu(dtolar);
    }

    /// <summary>
    /// Proqramdan əvvəl yaranmış borcu satış yaratmadan müştərinin hesabına keçirir.
    /// Borc qalığı və tarixçə eyni SaveChanges əməliyyatında yazılır.
    /// </summary>
    public async Task<EmeliyyatNeticesi> EvvelkiBorcElaveEtAsync(
        int musteriId, decimal mebleg, string? qeyd, int istifadeciId, DateTime borcunTarixi)
    {
        if (mebleg <= 0)
        {
            return EmeliyyatNeticesi.Ugursuz("Əvvəlki borcun məbləği müsbət olmalıdır.");
        }

        if (decimal.Round(mebleg, 2) != mebleg)
        {
            return EmeliyyatNeticesi.Ugursuz("Məbləğ iki onluq rəqəmdən artıq ola bilməz.");
        }
        if (borcunTarixi.Date > DateTime.Today || borcunTarixi == default)
            return EmeliyyatNeticesi.Ugursuz("Borcun tarixi gələcəkdə və ya boş ola bilməz.");
        if (string.IsNullOrWhiteSpace(qeyd))
            return EmeliyyatNeticesi.Ugursuz("Köhnə borcun mənbəyini qeyd edin.");

        try
        {
            Istifadeci? istifadeci = await _unitOfWork.Istifadeciler.GetirAsync(istifadeciId);
            if (istifadeci == null)
                return EmeliyyatNeticesi.Ugursuz("Aktiv istifadəçi tapılmadı.");
            if (istifadeci.RolId != 1)
            {
                int[] rolIcazeIdleri = (await _unitOfWork.RolIcazeleri.AxtarAsync(ri => ri.RolId == istifadeci.RolId))
                    .Select(ri => ri.IcazeId).ToArray();
                if (!(await _unitOfWork.Icazeler.AxtarAsync(i => rolIcazeIdleri.Contains(i.Id) && i.Ad == SistemIcazeleri.NisyeVer)).Any())
                    return EmeliyyatNeticesi.Ugursuz("Bu əməliyyat üçün NisyeVer icazəsi tələb olunur.");
            }
            Musteri? musteri = await _unitOfWork.Musteriler.GetirAsync(musteriId);
            if (musteri == null)
            {
                return EmeliyyatNeticesi.Ugursuz("Müştəri tapılmadı.");
            }

            musteri.UmumiBorc += mebleg;
            _unitOfWork.Musteriler.Yenile(musteri);
            await _unitOfWork.NisyeHereketleri.ElaveEtAsync(new NisyeHereketi
            {
                MusteriId = musteriId,
                Tarix = borcunTarixi,
                YaradanIstifadeciId = istifadeciId,
                EmeliyyatNovu = EmeliyyatNovu.IlkinBorc,
                Mebleg = mebleg,
                Qeyd = $"Proqramdan əvvəlki borc: {qeyd.Trim()}"
            });
            await _unitOfWork.EmeliyyatiTesdiqleAsync();
            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Əvvəlki borc əlavə edilərkən xəta baş verdi");
            return EmeliyyatNeticesi.Ugursuz($"Əvvəlki borc əlavə edilə bilmədi: {ex.Message}");
        }
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
    public async Task<EmeliyyatNeticesi> BorcOdenisiEtAsync(
        int musteriId, decimal odenenMebleg, int novbeId, OdenisMetodu odenisMetodu, int? istifadeciId)
    {
        try
        {
            if (odenenMebleg <= 0 || decimal.Round(odenenMebleg, 2) != odenenMebleg)
            {
                return EmeliyyatNeticesi.Ugursuz("Ödəniş məbləği müsbət və iki onluq dəqiqlikdə olmalıdır.");
            }
            if (odenisMetodu != OdenisMetodu.Nağd && odenisMetodu != OdenisMetodu.Kart)
            {
                return EmeliyyatNeticesi.Ugursuz("Borc ödənişi üçün nağd və ya kart seçin.");
            }
            return await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                Novbe? novbe = await _unitOfWork.Novbeler.GetirAsync(novbeId);
                if (novbe == null || novbe.Status != NovbeStatusu.Aciq)
                    return EmeliyyatNeticesi.Ugursuz("Borc ödənişi üçün açıq növbə tələb olunur.");

                Musteri? musteri = await _unitOfWork.Musteriler.GetirAsync(musteriId);
                if (musteri == null)
                    return EmeliyyatNeticesi.Ugursuz("Müştəri tapılmadı.");
                if (odenenMebleg > musteri.UmumiBorc)
                    return EmeliyyatNeticesi.Ugursuz($"Ödəniş mövcud borcdan ({musteri.UmumiBorc:N2} AZN) çox ola bilməz.");

                musteri.UmumiBorc -= odenenMebleg;
                _unitOfWork.Musteriler.Yenile(musteri);
                NisyeHereketi hereket = new()
                {
                    MusteriId = musteriId,
                    Tarix = DateTime.Now,
                    EmeliyyatNovu = EmeliyyatNovu.Odenis,
                    Mebleg = odenenMebleg,
                    Qeyd = $"{odenisMetodu} borc ödənişi, növbə #{novbeId}"
                };
                await _unitOfWork.NisyeHereketleri.ElaveEtAsync(hereket);
                await _unitOfWork.EmeliyyatiTesdiqleAsync();

                await _unitOfWork.KassaHareketleri.ElaveEtAsync(new KassaHareketi
                {
                    HareketNovu = KassaHareketiNovu.Daxilolma,
                    EmeliyyatNovu = EmeliyyatNovu.Odenis,
                    EmeliyyatId = hereket.Id,
                    NovbeId = novbeId,
                    OdenisMetodu = odenisMetodu,
                    Mebleg = odenenMebleg,
                    Tarix = hereket.Tarix,
                    Qeyd = $"Müştəri #{musteriId} borc ödənişi ({odenisMetodu})",
                    IstifadeciId = istifadeciId
                });
                await _unitOfWork.EmeliyyatiTesdiqleAsync();
                return EmeliyyatNeticesi.Ugurlu();
            });
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Borc ödənişi zamanı xəta baş verdi");
            return EmeliyyatNeticesi.Ugursuz($"Ödəniş zamanı xəta baş verdi: {ex.Message}");
        }
    }

    /// <summary>
    /// Nisyə olaraq həyata keçirilən satışı müştərinin borc hesabına əlavə edir.
    /// Diqqət: Bu metod SatisManager tərəfindən vahid tranzaksiya daxilində çağırılmalıdır.
    /// </summary>
    public async Task<EmeliyyatNeticesi> NisyeyeSatisElaveEtAsync(Satis satis)
    {
        if (!satis.MusteriId.HasValue)
        {
            return EmeliyyatNeticesi.Ugursuz("Nisyə satış üçün müştəri seçilməlidir.");
        }

        Musteri musteri = await _unitOfWork.Musteriler.GetirAsync(satis.MusteriId.Value);
        if (musteri == null)
        {
            return EmeliyyatNeticesi.Ugursuz("Müştəri tapılmadı.");
        }

        musteri.UmumiBorc += satis.UmumiMebleg;
        _unitOfWork.Musteriler.Yenile(musteri);

        NisyeHereketi hereket = new()
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

    /// <summary>
    /// Səhifələnmiş müştəri siyahısını əldə edir.
    /// Diqqət: Bu metod böyük məlumat bazaları üçün əlverişlidir.
    /// </summary>
    /// <param name="parametrler">Səhifələmə parametrləri</param>
    /// <returns>Səhifələnmiş müştəri məlumatları</returns>
    public async Task<EmeliyyatNeticesi<SehifelenmisMelumat<MusteriDto>>> MusterileriSehifelenmisGetirAsync(SehifeParametrleri parametrler)
    {
        Logger.MelumatYaz($"Səhifələnmiş müştərilər əldə edilir - Səhifə: {parametrler.SehifeNomresi}, Ölçü: {parametrler.SehifeOlcusu}");
        try
        {
            (IEnumerable<Musteri>? musteriler, int umumiSay) = await _unitOfWork.Musteriler.SehifelenmisGetirAsync(
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu,
                m => true);

            List<MusteriDto> dtolar = musteriler.Select(m => new MusteriDto
            {
                Id = m.Id,
                TamAd = m.TamAd,
                TelefonNomresi = m.TelefonNomresi,
                Unvan = m.Unvan,
                UmumiBorc = m.UmumiBorc
            }).ToList();

            SehifelenmisMelumat<MusteriDto> sehifelenmis = new(
                dtolar, umumiSay, parametrler.SehifeNomresi, parametrler.SehifeOlcusu);

            Logger.MelumatYaz($"Səhifələnmiş müştərilər uğurla əldə edildi - {dtolar.Count}/{umumiSay}");
            return EmeliyyatNeticesi<SehifelenmisMelumat<MusteriDto>>.Ugurlu(sehifelenmis);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Səhifələnmiş müştərilər əldə edilərkən istisna baş verdi");
            return EmeliyyatNeticesi<SehifelenmisMelumat<MusteriDto>>.Ugursuz($"Səhifələnmiş müştərilər əldə edilərkən xəta: {ex.Message}");
        }
    }
}
