// Fayl: AzAgroPOS.Mentiq/Idareciler/TemirManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;
// using-lər
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;

public class TemirManager
{
    private readonly IUnitOfWork _unitOfWork;
    public TemirManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<EmeliyyatNeticesi<List<TemirDto>>> ButunSifarisleriGetirAsync()
    {
        var sifarisler = await _unitOfWork.TemirSifarisleri.ButununuGetirAsync();
        var dtolar = sifarisler.Select(s => new TemirDto
        {
            Id = s.Id,
            MusteriAdi = s.MusteriAdi,
            MusteriTelefonu = s.MusteriTelefonu,
            CihazAdi = s.CihazAdi,
            ProblemTesviri = s.ProblemTesviri,
            QebulTarixi = s.QebulTarixi,
            Status = s.Status,
            YekunMebleg = s.YekunMebleg
        }).OrderByDescending(s => s.QebulTarixi).ToList();

        return EmeliyyatNeticesi<List<TemirDto>>.Ugurlu(dtolar);
    }

    public async Task<EmeliyyatNeticesi> YeniSifarisYaratAsync(TemirDto yeniSifaris)
    {
        if (string.IsNullOrWhiteSpace(yeniSifaris.MusteriAdi) || string.IsNullOrWhiteSpace(yeniSifaris.CihazAdi))
            return EmeliyyatNeticesi.Ugursuz("Müştəri adı və cihaz adı boş ola bilməz.");

        var sifaris = new Temir
        {
            MusteriAdi = yeniSifaris.MusteriAdi,
            MusteriTelefonu = yeniSifaris.MusteriTelefonu,
            CihazAdi = yeniSifaris.CihazAdi,
            ProblemTesviri = yeniSifaris.ProblemTesviri,
            QebulTarixi = DateTime.Now,
            Status = TemirStatusu.Gözləmədə,
            YekunMebleg = yeniSifaris.YekunMebleg
        };

        await _unitOfWork.TemirSifarisleri.ElaveEtAsync(sifaris);
        await _unitOfWork.EmeliyyatiTesdiqleAsync();

        return EmeliyyatNeticesi.Ugurlu();
    }

    // Gələcəkdə SifarişYenile, StatusDeyis kimi metodlar bura əlavə ediləcək.
}