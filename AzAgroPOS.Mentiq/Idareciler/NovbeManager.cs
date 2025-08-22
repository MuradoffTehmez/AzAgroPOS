// Fayl: AzAgroPOS.Mentiq/Idareciler/NovbeManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;


using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using System;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Növbə idarə etmə meneceri.
/// bu menecer növbə açma, bağlama və aktiv növbəni gətirmə əməliyyatlarını idarə edir.
/// diqqət: Növbə açma və bağlama əməliyyatları üçün istifadəçi ID-si və müvafiq məbləğ lazımdır.
/// kompleks əməliyyatlar üçün EmeliyyatNeticesi tipindən istifadə olunur.
/// </summary>
public class NovbeManager
{
    private readonly IUnitOfWork _unitOfWork;
    public NovbeManager(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

    /// <summary>
    /// Aktiv növbəni gətirir. 
    /// diqqət: Bu metod yalnız açıq növbəni gətirir, yəni statusu "Açıq" olan növbələri axtarır.
    /// burada isçi ID-si ilə axtarış aparılır və yalnız birinci tapılan açıq növbə qaytarılır.
    /// Asinxron olaraq işləyir və Novbe tipində nəticə qaytarır.
    /// </summary>
    /// <param name="isciId"></param>
    /// <returns></returns>
    public async Task<Novbe?> AktivNovbeniGetirAsync(int isciId)
    {
        return (await _unitOfWork.Novbeler.AxtarAsync(n => n.IsciId == isciId && n.Status == NovbeStatusu.Aciq)).FirstOrDefault();
    }
    /// <summary>
    /// Növbə açma əməliyyatını həyata keçirir.
    /// diqqət: Bu metod yeni bir növbə açır və istifadəçi ID-si ilə birlikdə başlanğıc məbləği tələb edir.
    /// Asinxron olaraq işləyir və EmeliyyatNeticesi tipində nəticə qaytarır.
    /// isciId - açmaq istədiyiniz istifadəçinin ID-sini, baslangicMebleg - növbənin başlanğıc məbləğini göstərir.
    /// 
    /// </summary>
    /// <param name="isciId"></param>
    /// <param name="baslangicMebleg"></param>
    /// <returns></returns>
    public async Task<EmeliyyatNeticesi<Novbe>> NovbeAcAsync(int isciId, decimal baslangicMebleg)
    {
        var aktivNovbe = await AktivNovbeniGetirAsync(isciId);
        if (aktivNovbe != null)
            return EmeliyyatNeticesi<Novbe>.Ugursuz("Bu istifadəçi üçün artıq açıq növbə mövcuddur.");
        var yeniNovbe = new Novbe { IsciId = isciId, AcilmaTarixi = DateTime.Now, BaslangicMebleg = baslangicMebleg, Status = NovbeStatusu.Aciq };
        await _unitOfWork.Novbeler.ElaveEtAsync(yeniNovbe);
        await _unitOfWork.EmeliyyatiTesdiqleAsync();
        return EmeliyyatNeticesi<Novbe>.Ugurlu(yeniNovbe);
    }

    /// <summary>
    /// növbəni bağlama əməliyyatını həyata keçirir.
    /// növbə bağlama zamanı faktiki məbləğ və növbə ID-si tələb olunur.
    /// diqqət: Bu metod növbənin statusunu "Bağlı" olaraq dəyişir və bağlanma tarixini təyin edir.
    /// asinxron olaraq işləyir və EmeliyyatNeticesi tipində ZHesabatDto qaytarır.
    /// novbeId - bağlamaq istədiyiniz növbənin ID-sini, faktikiMebleg - bağlanma zamanı kassada olan faktiki məbləği göstərir.
    /// faktikiMebleg - bağlanma zamanı kassada olan faktiki məbləği göstərir.
    /// aktiv növbə bağlanır və satışlar hesablanır.
    /// </summary>
    /// <param name="novbeId"></param>
    /// <param name="faktikiMebleg"></param>
    /// <returns></returns>
    public async Task<EmeliyyatNeticesi<ZHesabatDto>> NovbeBaglaAsync(int novbeId, decimal faktikiMebleg)
    {
        var novbe = await _unitOfWork.Novbeler.GetirAsync(novbeId);
        if (novbe == null || novbe.Status == NovbeStatusu.Bagli)
            return EmeliyyatNeticesi<ZHesabatDto>.Ugursuz("Növbə tapılmadı və ya artıq bağlıdır.");

        var novbeSatislar = await _unitOfWork.Satislar.AxtarAsync(s => s.NovbeId == novbeId);
        decimal nagdSatislar = novbeSatislar.Where(s => s.OdenisMetodu == OdenisMetodu.Nağd).Sum(s => s.UmumiMebleg);
        decimal kartSatislar = novbeSatislar.Where(s => s.OdenisMetodu == OdenisMetodu.Kart).Sum(s => s.UmumiMebleg);

        novbe.BaglanmaTarixi = DateTime.Now;
        novbe.FaktikiMebleg = faktikiMebleg;
        novbe.GozlenilenMebleg = novbe.BaslangicMebleg + nagdSatislar;
        novbe.Status = NovbeStatusu.Bagli;
        _unitOfWork.Novbeler.Yenile(novbe);
        await _unitOfWork.EmeliyyatiTesdiqleAsync();

        var isci = await _unitOfWork.Istifadeciler.GetirAsync(novbe.IsciId);
        var hesabat = new ZHesabatDto
        {
            AcilmaTarixi = novbe.AcilmaTarixi,
            BaglanmaTarixi = novbe.BaglanmaTarixi.Value,
            KassirAdi = isci?.TamAd ?? "Naməlum",
            BaslangicMebleg = novbe.BaslangicMebleg,
            SatisSayi = novbeSatislar.Count(),
            NagdSatislar = nagdSatislar,
            KartSatislar = kartSatislar,
            GozlenilenMebleg = novbe.GozlenilenMebleg,
            FaktikiMebleg = novbe.FaktikiMebleg
        };
        return EmeliyyatNeticesi<ZHesabatDto>.Ugurlu(hesabat);
    }
}