// Fayl: AzAgroPOS.Mentiq/Idareciler/TemirManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;
// using-lər
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
/// <summary>
/// temir meneceri, təmir sifarişləri ilə bağlı əməliyyatları
/// rol modelini idarə edən menecer.
/// qed: Bu menecer təmir sifarişlərinin yaradılması, yenilənməsi və statuslarının dəyişdirilməsi ilə bağlı əməliyyatları həyata keçirir.
/// diqqət: TemirManager, IUnitOfWork interfeysini istifadə edərək verilənlər bazası əməliyyatlarını həyata keçirir.
/// </summary>
public class TemirManager
{
    private readonly IUnitOfWork _unitOfWork;
    public TemirManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    /// <summary>
    /// bütün təmir sifarişlərini gətirir və TemirDto formatına çevirir.
    /// temir sifarişləri, müştəri adı, telefon, cihaz adı, problem təsviri,qəbul tarixi, status və yekun məbləğ kimi məlumatları ehtiva edir.
    /// diqqət: Bu metod asinxron olaraq işləyir və sifarişləri tarixə görə azalan sırada qaytarır.
    /// qeyd: TemirDto, təmir sifarişlərinin məlumatlarını daşıyan bir Data Transfer Object (DTO) sinifidir.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// bu metod yeni bir təmir sifarişi yaradır.
    /// yeniSifaris parametri TemirDto formatında olmalıdır.
    /// diqqət: Müştəri adı və cihaz adı boş olmamalıdır.
    /// qeyd: Yeni təmir sifarişi yaradıldıqda, qəbul tarixi avtomatik olaraq indiki tarixə təyin edilir və status "Gözləmədə" olaraq təyin edilir.
    /// rol: Bu metod asinxron olaraq işləyir və yeni təmir sifarişini verilənlər bazasına əlavə edir.
    /// </summary>
    /// <param name="yeniSifaris"></param>
    /// <returns></returns>
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