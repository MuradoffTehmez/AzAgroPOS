// Fayl: AzAgroPOS.Mentiq/Idareciler/TehlukesizlikManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Verilenler.Interfeysler;
using System.Linq;
using System.Threading.Tasks;

public class TehlukesizlikManager
{
    private readonly IUnitOfWork _unitOfWork;
    public TehlukesizlikManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<EmeliyyatNeticesi<IstifadeciDto>> DaxilOlAsync(string istifadeciAdi, string parol)
    {
        // ƏSAS DÜZƏLİŞ: Gələn dəyərləri hər cür artıq simvoldan təmizləyirik
        var temizlenmisAd = istifadeciAdi.Trim();
        var temizlenmisParol = parol.Trim();

        if (string.IsNullOrWhiteSpace(temizlenmisAd) || string.IsNullOrWhiteSpace(temizlenmisParol))
            return EmeliyyatNeticesi<IstifadeciDto>.Ugursuz("İstifadəçi adı və parol boş ola bilməz.");

        var istifadeci = (await _unitOfWork.Istifadeciler.AxtarAsync(i => i.IstifadeciAdi == temizlenmisAd)).FirstOrDefault();

        if (istifadeci == null)
            return EmeliyyatNeticesi<IstifadeciDto>.Ugursuz("İstifadəçi adı və ya parol yanlışdır.");

        // Yoxlamanı təmizlənmiş parol ilə edirik
        bool parolDogrudur = BCrypt.Net.BCrypt.Verify(temizlenmisParol, istifadeci.ParolHash);

        if (!parolDogrudur)
            return EmeliyyatNeticesi<IstifadeciDto>.Ugursuz("İstifadəçi adı və ya parol yanlışdır.");

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