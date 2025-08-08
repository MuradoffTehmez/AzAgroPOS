// Fayl: AzAgroPOS.Mentiq/Idareciler/TehlukesizlikManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Verilenler.Interfeysler;
using Microsoft.EntityFrameworkCore;

public class TehlukesizlikManager
{
    private readonly IUnitOfWork _unitOfWork;
    public TehlukesizlikManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<EmeliyyatNeticesi<IstifadeciDto>> DaxilOlAsync(string istifadeciAdi, string parol)
    {
        if (string.IsNullOrWhiteSpace(istifadeciAdi) || string.IsNullOrWhiteSpace(parol))
            return EmeliyyatNeticesi<IstifadeciDto>.Ugursuz("İstifadəçi adı və parol boş ola bilməz.");

        // İstifadəçini tapırıq və rolunu da birlikdə gətiririk
        var istifadeci = (await _unitOfWork.Istifadeciler.AxtarAsync(i => i.IstifadeciAdi == istifadeciAdi)).FirstOrDefault();

        if (istifadeci == null)
            return EmeliyyatNeticesi<IstifadeciDto>.Ugursuz("İstifadəçi adı və ya parol yanlışdır.");

        // Parolu yoxlayırıq
        bool parolDogrudur = BCrypt.Net.BCrypt.Verify(parol, istifadeci.ParolHash);

        if (!parolDogrudur)
            return EmeliyyatNeticesi<IstifadeciDto>.Ugursuz("İstifadəçi adı və ya parol yanlışdır.");

        // Rol adını da əldə edək
        var rol = await _unitOfWork.Rollar.GetirAsync(istifadeci.RolId);

        var istifadeciDto = new IstifadeciDto
        {
            Id = istifadeci.Id,
            IstifadeciAdi = istifadeci.IstifadeciAdi,
            TamAd = istifadeci.TamAd,
            RolAdi = rol?.Ad ?? "Təyin edilməyib"
        };

        return EmeliyyatNeticesi<IstifadeciDto>.Ugurlu(istifadeciDto);
    }
}