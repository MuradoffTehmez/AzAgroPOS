// Fayl: AzAgroPOS.Mentiq/Idareciler/TehlukesizlikManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Verilenler.Interfeysler;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// TehlukesizlikManager, istifadəçi girişini və təhlükəsizlik yoxlamalarını idarə edən menecer.
/// </summary>
public class TehlukesizlikManager
{
    private readonly IUnitOfWork _unitOfWork;
    public TehlukesizlikManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    /// <summary>
    /// DaxilOlAsync metodu istifadəçi adı və parol ilə istifadəçi girişini yoxlayır
    /// uğurlu giriş halında istifadəçi məlumatlarını IstifadeciDto formatında qaytarır.
    /// uğursuz giriş halında isə müvafiq xətanı bildirir.
    /// rol: Bu metod asinxron olaraq işləyir və istifadəçi adı və parolun düzgünlüyünü yoxlayır.
    /// diqqət: İstifadəçi adı və parol boş ola bilməz, əgər boşdursa müvafiq xəta mesajı qaytarılır.
    /// qeyd: İstifadəçi adı və parol yoxlanarkən, istifadəçi adı ilə verilən parolun hash dəyəri müqayisə edilir.
    /// </summary>
    /// <param name="istifadeciAdi"></param>
    /// <param name="parol"></param>
    /// <returns></returns>
    public async Task<EmeliyyatNeticesi<IstifadeciDto>> DaxilOlAsync(string istifadeciAdi, string parol)
    {

        var temizlenmisAd = istifadeciAdi.Trim();
        var temizlenmisParol = parol.Trim();

        if (string.IsNullOrWhiteSpace(temizlenmisAd) || string.IsNullOrWhiteSpace(temizlenmisParol))
            return EmeliyyatNeticesi<IstifadeciDto>.Ugursuz("İstifadəçi adı və parol boş ola bilməz.");


        // Removed hardcoded admin check - all users including admin should be verified through database


        var istifadeci = (await _unitOfWork.Istifadeciler.AxtarAsync(i => i.IstifadeciAdi == temizlenmisAd)).FirstOrDefault();

        if (istifadeci == null)
            return EmeliyyatNeticesi<IstifadeciDto>.Ugursuz("İstifadəçi adı və ya parol yanlışdır.");

        // Yoxlamanı təmizlənmiş parol ilə edirik
        bool parolDogrudur = BCrypt.Net.BCrypt.Verify(temizlenmisParol, istifadeci.ParolHash);

        if (!parolDogrudur)
            return EmeliyyatNeticesi<IstifadeciDto>.Ugursuz("İstifadəçi adı və ya parol yanlışdır.");

        var istifadeciRol = await _unitOfWork.Rollar.GetirAsync(istifadeci.RolId);
        var istifadeciDto = new IstifadeciDto
        {
            Id = istifadeci.Id,
            IstifadeciAdi = istifadeci.IstifadeciAdi,
            TamAd = istifadeci.TamAd,
            RolAdi = istifadeciRol?.Ad ?? "Təyin edilməyib"
        };

        return EmeliyyatNeticesi<IstifadeciDto>.Ugurlu(istifadeciDto);
    }
}