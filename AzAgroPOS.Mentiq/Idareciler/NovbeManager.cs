// Fayl: AzAgroPOS.Mentiq/Idareciler/NovbeManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;
// Gərəkli using-lər...
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using System;
using System.Linq;
using System.Threading.Tasks;
public class NovbeManager
{
    private readonly IUnitOfWork _unitOfWork;
    public NovbeManager(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

    public async Task<Novbe?> AktivNovbeniGetirAsync(int isciId)
    {
        return (await _unitOfWork.Novbeler.AxtarAsync(n => n.IsciId == isciId && n.Status == NovbeStatusu.Aciq)).FirstOrDefault();
    }

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