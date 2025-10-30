// Fayl: AzAgroPOS.Mentiq/Idareciler/TemirManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;
// using-lər
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
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
    private readonly StokHareketiManager _stokHareketiManager;

    public TemirManager(IUnitOfWork unitOfWork, StokHareketiManager stokHareketiManager)
    {
        _unitOfWork = unitOfWork;
        _stokHareketiManager = stokHareketiManager;
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
                SeriyaNomresi = s.SeriyaNomresi,
                ProblemTesviri = s.ProblemTesviri,
                QebulTarixi = s.QebulTarixi,
                Status = s.Status,
                TemirXerci = s.TemirXerci,
                ServisHaqqi = s.ServisHaqqi,
                YekunMebleg = s.YekunMebleg,
                ZemanetMuddeti = s.ZemanetMuddeti,
                IsciId = s.IsciId
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
                SeriyaNomresi = yeniSifaris.SeriyaNomresi,
                ProblemTesviri = yeniSifaris.ProblemTesviri,
                QebulTarixi = DateTime.Now,
                Status = TemirStatusu.Gözləmədə,
                TemirXerci = yeniSifaris.TemirXerci,
                ServisHaqqi = yeniSifaris.ServisHaqqi,
                YekunMebleg = yeniSifaris.YekunMebleg,
                ZemanetMuddeti = yeniSifaris.ZemanetMuddeti,
                IsciId = yeniSifaris.IsciId
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
            movcudSifaris.SeriyaNomresi = sifarisDto.SeriyaNomresi;
            movcudSifaris.ProblemTesviri = sifarisDto.ProblemTesviri;
            movcudSifaris.TemirXerci = sifarisDto.TemirXerci;
            movcudSifaris.ServisHaqqi = sifarisDto.ServisHaqqi;
            movcudSifaris.YekunMebleg = sifarisDto.YekunMebleg;
            movcudSifaris.ZemanetMuddeti = sifarisDto.ZemanetMuddeti;
            movcudSifaris.IsciId = sifarisDto.IsciId;

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

    /// <summary>
    /// Təmiri tamamlayır və istifadə olunan ehtiyat hissələrini stokdan çıxır.
    /// diqqət: Bu metod təmir sifarişini "Hazırdır" statusuna keçirir və ehtiyat hissələrini stokdan avtomatik çıxır.
    /// qeyd: Ehtiyat hissələri üçün StokHareketiManager istifadə edilir.
    /// rol: Təmir tamamlandıqda anbar qalığı avtomatik yenilənir.
    /// </summary>
    /// <param name="temirId">Tamamlanacaq təmir sifarişinin ID-si</param>
    /// <param name="ehtiyatHissəleri">İstifadə olunan ehtiyat hissələrinin siyahısı</param>
    /// <param name="istifadeciId">Əməliyyatı icra edən istifadəçinin ID-si</param>
    /// <returns>Əməliyyat nəticəsi</returns>
    public async Task<EmeliyyatNeticesi> TemiriTamamlaVeStokCixisEtAsync(
        int temirId,
        List<EhtiyatHissəsiDto> ehtiyatHissəleri,
        int? istifadeciId = null)
    {
        try
        {
            // Təmir sifarişini tap
            var sifaris = await _unitOfWork.TemirSifarisleri.GetirAsync(temirId);
            if (sifaris == null)
                return EmeliyyatNeticesi.Ugursuz("Təmir sifarişi tapılmadı.");

            // Təmiri tamamla
            sifaris.Status = TemirStatusu.Hazırdır;
            sifaris.TamamlanmaTarixi = DateTime.Now;

            _unitOfWork.TemirSifarisleri.Yenile(sifaris);
            await _unitOfWork.EmeliyyatiTesdiqleAsync(); // Təmir ID-ni təmin etmək üçün

            // Ehtiyat hissələrini stokdan çıxar
            if (ehtiyatHissəleri != null && ehtiyatHissəleri.Any())
            {
                foreach (var hisse in ehtiyatHissəleri)
                {
                    // Məhsulun mövcudluğunu yoxla
                    var mehsul = await _unitOfWork.Mehsullar.GetirAsync(hisse.MehsulId);
                    if (mehsul == null)
                    {
                        Logger.XəbərdarlıqYaz($"Ehtiyat hissəsi məhsulu tapılmadı: ID={hisse.MehsulId}");
                        continue; // Bu hissəni atlayıb digərinə keç
                    }

                    // Stokda kifayət qədər məhsul olub-olmadığını yoxla
                    var qaliqNetice = await _stokHareketiManager.MehsulQaliginGetirAsync(hisse.MehsulId);
                    if (!qaliqNetice.UgurluDur || qaliqNetice.Data < (int)hisse.Miqdar)
                    {
                        return EmeliyyatNeticesi.Ugursuz(
                            $"Stokda kifayət qədər '{hisse.MehsulAdi}' yoxdur. " +
                            $"Tələb olunan: {hisse.Miqdar}, Mövcud: {(qaliqNetice.UgurluDur ? qaliqNetice.Data : 0)}");
                    }

                    // Stok çıxışı yarat
                    var stokCixisNetice = await _stokHareketiManager.StokHareketiQeydeAlAsync(
                        StokHareketTipi.Cixis,
                        SenedNovu.Temir,
                        temirId,
                        hisse.MehsulId,
                        (int)hisse.Miqdar,
                        0, // alisQiymeti - təmir üçün 0
                        hisse.Qiymet, // satisQiymeti - ehtiyat hissəsinin qiyməti
                        $"Təmir #{temirId} - {sifaris.CihazAdi} - {sifaris.MusteriAdi}",
                        istifadeciId);

                    if (!stokCixisNetice.UgurluDur)
                    {
                        return EmeliyyatNeticesi.Ugursuz(
                            $"Ehtiyat hissəsi '{hisse.MehsulAdi}' üçün stok çıxışı yaradılarkən xəta baş verdi: {stokCixisNetice.Mesaj}");
                    }
                }

                await _unitOfWork.EmeliyyatiTesdiqleAsync();
            }

            Logger.MelumatYaz($"Təmir tamamlandı və ehtiyat hissələri stokdan çıxıldı: Təmir ID={temirId}");
            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Təmir tamamlanarkən xəta baş verdi");
            return EmeliyyatNeticesi.Ugursuz($"Təmir tamamlanarkən xəta baş verdi: {ex.Message}");
        }
    }

    /// <summary>
    /// Təmirə aid istifadə olunan ehtiyat hissələrinin siyahısını gətirir.
    /// diqqət: Təmir üçün istifadə olunan bütün ehtiyat hissələrini stok hərəkətləri əsasında tapır.
    /// qeyd: Yalnız "Təmir" sənəd növü ilə qeydə alınmış stok çıxışlarını qaytarır.
    /// </summary>
    /// <param name="temirId">Təmir sifarişinin ID-si</param>
    /// <returns>İstifadə olunan ehtiyat hissələrinin siyahısı</returns>
    public async Task<EmeliyyatNeticesi<List<EhtiyatHissəsiDto>>> TemirEhtiyatHisseleriniGetirAsync(int temirId)
    {
        try
        {
            // Təmirə aid stok hərəkətlərini tap
            var hereketlerNetice = await _stokHareketiManager.SenedHereketleriniGetirAsync(SenedNovu.Temir, temirId);
            if (!hereketlerNetice.UgurluDur)
                return EmeliyyatNeticesi<List<EhtiyatHissəsiDto>>.Ugursuz(hereketlerNetice.Mesaj);

            var hereketler = hereketlerNetice.Data;
            var ehtiyatHissəleri = new List<EhtiyatHissəsiDto>();

            // Hər bir hərəkət üçün məhsul məlumatlarını əlavə et
            foreach (var hereket in hereketler)
            {
                var mehsul = await _unitOfWork.Mehsullar.GetirAsync(hereket.MehsulId);
                if (mehsul != null)
                {
                    ehtiyatHissəleri.Add(new EhtiyatHissəsiDto
                    {
                        MehsulId = hereket.MehsulId,
                        MehsulAdi = mehsul.Ad,
                        Miqdar = hereket.Miqdar,
                        Qiymet = hereket.SatisQiymeti
                    });
                }
            }

            Logger.MelumatYaz($"Təmir ehtiyat hissələri tapıldı: Təmir ID={temirId}, Say={ehtiyatHissəleri.Count}");
            return EmeliyyatNeticesi<List<EhtiyatHissəsiDto>>.Ugurlu(ehtiyatHissəleri);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Təmir ehtiyat hissələri əldə edilərkən xəta baş verdi");
            return EmeliyyatNeticesi<List<EhtiyatHissəsiDto>>.Ugursuz($"Təmir ehtiyat hissələri əldə edilərkən xəta: {ex.Message}");
        }
    }
}