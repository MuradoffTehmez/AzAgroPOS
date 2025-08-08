// Fayl: AzAgroPOS.Mentiq/Idareciler/NisyeManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

// using-lər
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using Microsoft.EntityFrameworkCore;

public class NisyeManager
{
    private readonly IUnitOfWork _unitOfWork;

    public NisyeManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

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

        await _unitOfWork.EmeliyyatiTesdiqleAsync();

        return EmeliyyatNeticesi.Ugurlu();
    }
}