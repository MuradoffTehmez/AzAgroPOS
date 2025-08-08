// Fayl: AzAgroPOS.Mentiq/Idareciler/IstifadeciManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class IstifadeciManager
{
    private readonly IUnitOfWork _unitOfWork;
    public IstifadeciManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<EmeliyyatNeticesi<List<IstifadeciDto>>> IstifadecileriGetirAsync()
    {
        var istifadeciler = await _unitOfWork.Istifadeciler.ButununuGetirAsync();
        var rollar = await _unitOfWork.Rollar.ButununuGetirAsync();

        var dtolar = istifadeciler.Select(i => new IstifadeciDto
        {
            Id = i.Id,
            IstifadeciAdi = i.IstifadeciAdi,
            TamAd = i.TamAd,
            RolAdi = rollar.FirstOrDefault(r => r.Id == i.RolId)?.Ad ?? "Təyinatsız"
        }).ToList();

        return EmeliyyatNeticesi<List<IstifadeciDto>>.Ugurlu(dtolar);
    }

    public async Task<EmeliyyatNeticesi> IstifadeciYaratAsync(IstifadeciDto yeniIstifadeci, string parol)
    {
        if (string.IsNullOrWhiteSpace(yeniIstifadeci.IstifadeciAdi) || string.IsNullOrWhiteSpace(parol))
            return EmeliyyatNeticesi.Ugursuz("İstifadəçi adı və parol boş ola bilməz.");

        var movcudIstifadeci = (await _unitOfWork.Istifadeciler.AxtarAsync(i => i.IstifadeciAdi == yeniIstifadeci.IstifadeciAdi)).FirstOrDefault();
        if (movcudIstifadeci != null)
            return EmeliyyatNeticesi.Ugursuz("Bu istifadəçi adı artıq mövcuddur.");

        var istifadeci = new Istifadeci
        {
            IstifadeciAdi = yeniIstifadeci.IstifadeciAdi,
            TamAd = yeniIstifadeci.TamAd,
            RolId = yeniIstifadeci.RolId,
            ParolHash = BCrypt.Net.BCrypt.HashPassword(parol)
        };

        await _unitOfWork.Istifadeciler.ElaveEtAsync(istifadeci);
        await _unitOfWork.EmeliyyatiTesdiqleAsync();

        return EmeliyyatNeticesi.Ugurlu();
    }

    public async Task<EmeliyyatNeticesi> IstifadeciSilAsync(int id)
    {
        if (id == 1) // Əsas admini silməyin qarşısını alırıq
            return EmeliyyatNeticesi.Ugursuz("Əsas Administratoru silmək olmaz.");

        var istifadeci = await _unitOfWork.Istifadeciler.GetirAsync(id);
        if (istifadeci == null)
            return EmeliyyatNeticesi.Ugursuz("İstifadəçi tapılmadı.");

        _unitOfWork.Istifadeciler.Sil(istifadeci);
        await _unitOfWork.EmeliyyatiTesdiqleAsync();

        return EmeliyyatNeticesi.Ugurlu();
    }
}