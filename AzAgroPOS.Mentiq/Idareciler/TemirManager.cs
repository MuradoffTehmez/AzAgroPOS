// Fayl: AzAgroPOS.Mentiq/Idareciler/TemirManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;
// using-lər
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        try
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
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<List<TemirDto>>.Ugursuz($"Təmir sifarişlərini gətirmək alınmadı: {ex.Message}");
        }
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
    public async Task<EmeliyyatNeticesi<int>> YeniSifarisYaratAsync(TemirDto yeniSifaris)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(yeniSifaris.MusteriAdi) || string.IsNullOrWhiteSpace(yeniSifaris.CihazAdi))
                return EmeliyyatNeticesi<int>.Ugursuz("Müştəri adı və cihaz adı boş ola bilməz.");

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

            return EmeliyyatNeticesi<int>.Ugurlu(sifaris.Id);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<int>.Ugursuz($"Təmir sifarişi yaratmaq alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// bu metod mövcud bir təmir sifarişini yeniləyir.
    /// sifarisDto parametri TemirDto formatında olmalıdır.
    /// diqqət: Müştəri adı və cihaz adı boş olmamalıdır.
    /// qeyd: Təmir sifarişi yeniləndikdə, qəbul tarixi dəyişdirilmir.
    /// rol: Bu metod asinxron olaraq işləyir və təmir sifarişini verilənlər bazasında yeniləyir.
    /// </summary>
    /// <param name="sifarisDto"></param>
    /// <returns></returns>
    public async Task<EmeliyyatNeticesi> SifarisYenileAsync(TemirDto sifarisDto)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(sifarisDto.MusteriAdi) || string.IsNullOrWhiteSpace(sifarisDto.CihazAdi))
                return EmeliyyatNeticesi.Ugursuz("Müştəri adı və cihaz adı boş ola bilməz.");

            var movcudSifaris = await _unitOfWork.TemirSifarisleri.GetirAsync(sifarisDto.Id);
            if (movcudSifaris == null)
                return EmeliyyatNeticesi.Ugursuz("Yenilənmək üçün təmir sifarişi tapılmadı.");

            movcudSifaris.MusteriAdi = sifarisDto.MusteriAdi;
            movcudSifaris.MusteriTelefonu = sifarisDto.MusteriTelefonu;
            movcudSifaris.CihazAdi = sifarisDto.CihazAdi;
            movcudSifaris.ProblemTesviri = sifarisDto.ProblemTesviri;
            movcudSifaris.YekunMebleg = sifarisDto.YekunMebleg;

            _unitOfWork.TemirSifarisleri.Yenile(movcudSifaris);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi.Ugursuz($"Təmir sifarişini yeniləmək alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// bu metod mövcud bir təmir sifarişini silir.
    /// id parametri silinəcək təmir sifarişinin identifikatorudur.
    /// diqqət: Silinəcək təmir sifarişi sistemdə mövcud olmalıdır.
    /// qeyd: Təmir sifarişi silindikdə, onunla əlaqəli bütün məlumatlar da silinir.
    /// rol: Bu metod asinxron olaraq işləyir və təmir sifarişini verilənlər bazasından silir.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<EmeliyyatNeticesi> SifarisSilAsync(int id)
    {
        try
        {
            var sifaris = await _unitOfWork.TemirSifarisleri.GetirAsync(id);
            if (sifaris == null)
                return EmeliyyatNeticesi.Ugursuz("Silinəcək təmir sifarişi tapılmadı.");

            _unitOfWork.TemirSifarisleri.Sil(sifaris);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi.Ugursuz($"Təmir sifarişini silmək alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// bu metod təmir sifarişinin statusunu dəyişir.
    /// id parametri statusu dəyişdiriləcək təmir sifarişinin identifikatorudur.
    /// yeniStatus parametri təmir sifarişinin yeni statusudur.
    /// diqqət: Status dəyişdirilərkən, müvafiq iş qaydalarına əməl olunmalıdır.
    /// qeyd: Status dəyişdirildikdə, sistemdə uyğun qeydlər aparılır.
    /// rol: Bu metod asinxron olaraq işləyir və təmir sifarişinin statusunu yeniləyir.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="yeniStatus"></param>
    /// <returns></returns>
    public async Task<EmeliyyatNeticesi> StatusDeyisAsync(int id, TemirStatusu yeniStatus)
    {
        try
        {
            var sifaris = await _unitOfWork.TemirSifarisleri.GetirAsync(id);
            if (sifaris == null)
                return EmeliyyatNeticesi.Ugursuz("Statusu dəyişdirilmək üçün təmir sifarişi tapılmadı.");

            sifaris.Status = yeniStatus;
            if (yeniStatus == TemirStatusu.Hazırdır)
            {
                sifaris.TamamlanmaTarixi = DateTime.Now;
            }

            _unitOfWork.TemirSifarisleri.Yenile(sifaris);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi.Ugursuz($"Təmir sifarişi statusunu dəyişmək alınmadı: {ex.Message}");
        }
    }
}