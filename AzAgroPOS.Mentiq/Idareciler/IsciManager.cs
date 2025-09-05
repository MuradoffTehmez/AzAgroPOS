// Fayl: AzAgroPOS.Mentiq/Idareciler/IsciManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// İşçilərlə bağlı biznes məntiqini idarə edən menecer.
/// </summary>
public class IsciManager
{
    private readonly IUnitOfWork _unitOfWork;

    public IsciManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Bütün işçiləri DTO formatında gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<IsciDto>>> ButunIscileriGetirAsync()
    {
        var isciler = await _unitOfWork.Isciler.ButununuGetirAsync();
        var dtolar = isciler.Select(i => new IsciDto
        {
            Id = i.Id,
            TamAd = i.TamAd,
            DogumTarixi = i.DogumTarixi,
            TelefonNomresi = i.TelefonNomresi,
            Unvan = i.Unvan,
            Email = i.Email,
            IseBaslamaTarixi = i.IseBaslamaTarixi,
            Maas = i.Maas,
            Vezife = i.Vezife,
            Departament = i.Departament,
            Status = i.Status,
            SvsNo = i.SvsNo,
            QeydiyyatUnvani = i.QeydiyyatUnvani,
            BankMəlumatları = i.BankMəlumatları,
            SistemIstifadeciAdi = i.SistemIstifadecisi?.IstifadeciAdi
        }).ToList();

        return EmeliyyatNeticesi<List<IsciDto>>.Ugurlu(dtolar);
    }

    /// <summary>
    /// Verilmiş ID-yə görə işçi məlumatlarını gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<IsciDto>> IsciGetirAsync(int id)
    {
        var isci = await _unitOfWork.Isciler.GetirAsync(id);
        if (isci == null)
            return EmeliyyatNeticesi<IsciDto>.Ugursuz("İşçi tapılmadı.");

        var dto = new IsciDto
        {
            Id = isci.Id,
            TamAd = isci.TamAd,
            DogumTarixi = isci.DogumTarixi,
            TelefonNomresi = isci.TelefonNomresi,
            Unvan = isci.Unvan,
            Email = isci.Email,
            IseBaslamaTarixi = isci.IseBaslamaTarixi,
            Maas = isci.Maas,
            Vezife = isci.Vezife,
            Departament = isci.Departament,
            Status = isci.Status,
            SvsNo = isci.SvsNo,
            QeydiyyatUnvani = isci.QeydiyyatUnvani,
            BankMəlumatları = isci.BankMəlumatları,
            SistemIstifadeciAdi = isci.SistemIstifadecisi?.IstifadeciAdi
        };

        return EmeliyyatNeticesi<IsciDto>.Ugurlu(dto);
    }

    /// <summary>
    /// Yeni işçi yaradır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> IsciYaratAsync(IsciDto dto)
    {
        // Validasiya
        if (string.IsNullOrWhiteSpace(dto.TamAd))
            return EmeliyyatNeticesi<int>.Ugursuz("İşçinin tam adı boş ola bilməz.");

        if (dto.Maas < 0)
            return EmeliyyatNeticesi<int>.Ugursuz("Maaş mənfi ola bilməz.");

        // Yeni işçi obyekti yaradırıq
        var yeniIsci = new Isci
        {
            TamAd = dto.TamAd,
            DogumTarixi = dto.DogumTarixi,
            TelefonNomresi = dto.TelefonNomresi,
            Unvan = dto.Unvan,
            Email = dto.Email,
            IseBaslamaTarixi = dto.IseBaslamaTarixi,
            Maas = dto.Maas,
            Vezife = dto.Vezife,
            Departament = dto.Departament,
            Status = dto.Status,
            SvsNo = dto.SvsNo,
            QeydiyyatUnvani = dto.QeydiyyatUnvani,
            BankMəlumatları = dto.BankMəlumatları
        };

        await _unitOfWork.Isciler.ElaveEtAsync(yeniIsci);
        await _unitOfWork.EmeliyyatiTesdiqleAsync();

        return EmeliyyatNeticesi<int>.Ugurlu(yeniIsci.Id);
    }

    /// <summary>
    /// Mövcud işçinin məlumatlarını yeniləyir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> IsciYenileAsync(IsciDto dto)
    {
        var movcudIsci = await _unitOfWork.Isciler.GetirAsync(dto.Id);
        if (movcudIsci == null)
            return EmeliyyatNeticesi.Ugursuz("Yenilənmək üçün işçi tapılmadı.");

        // Validasiya
        if (string.IsNullOrWhiteSpace(dto.TamAd))
            return EmeliyyatNeticesi.Ugursuz("İşçinin tam adı boş ola bilməz.");

        if (dto.Maas < 0)
            return EmeliyyatNeticesi.Ugursuz("Maaş mənfi ola bilməz.");

        // Məlumatları yeniləyirik
        movcudIsci.TamAd = dto.TamAd;
        movcudIsci.DogumTarixi = dto.DogumTarixi;
        movcudIsci.TelefonNomresi = dto.TelefonNomresi;
        movcudIsci.Unvan = dto.Unvan;
        movcudIsci.Email = dto.Email;
        movcudIsci.IseBaslamaTarixi = dto.IseBaslamaTarixi;
        movcudIsci.Maas = dto.Maas;
        movcudIsci.Vezife = dto.Vezife;
        movcudIsci.Departament = dto.Departament;
        movcudIsci.Status = dto.Status;
        movcudIsci.SvsNo = dto.SvsNo;
        movcudIsci.QeydiyyatUnvani = dto.QeydiyyatUnvani;
        movcudIsci.BankMəlumatları = dto.BankMəlumatları;

        _unitOfWork.Isciler.Yenile(movcudIsci);
        await _unitOfWork.EmeliyyatiTesdiqleAsync();

        return EmeliyyatNeticesi.Ugurlu();
    }

    /// <summary>
    /// İşçi silir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> IsciSilAsync(int id)
    {
        var isci = await _unitOfWork.Isciler.GetirAsync(id);
        if (isci == null)
            return EmeliyyatNeticesi.Ugursuz("Silinəcək işçi tapılmadı.");

        _unitOfWork.Isciler.Sil(isci);
        await _unitOfWork.EmeliyyatiTesdiqleAsync();

        return EmeliyyatNeticesi.Ugurlu();
    }
}