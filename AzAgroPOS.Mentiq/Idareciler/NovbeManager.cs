// Fayl: AzAgroPOS.Mentiq/Idareciler/NovbeManager.cs


using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;

namespace AzAgroPOS.Mentiq.Idareciler;
/// <summary>
/// Növbə idarə etmə meneceri.
/// bu menecer növbə açma, bağlama və aktiv növbəni gətirmə əməliyyatlarını idarə edir.
/// diqqət: Növbə açma və bağlama əməliyyatları üçün istifadəçi ID-si və müvafiq məbləğ lazımdır.
/// kompleks əməliyyatlar üçün EmeliyyatNeticesi tipindən istifadə olunur.
/// </summary>
public class NovbeManager
{
    private readonly IUnitOfWork _unitOfWork;
    public NovbeManager(IUnitOfWork unitOfWork, MaliyyeManager maliyyeManager)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Növbəni ID-sinə görə gətirir.
    /// </summary>
    /// <param name="id">Növbənin ID-si</param>
    /// <returns>Növbə obyekti</returns>
    public async Task<Novbe?> NovbeGetirAsync(int id)
    {
        return await _unitOfWork.Novbeler.GetirAsync(id);
    }

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
        return await _unitOfWork.Novbeler.AktivNovbeniGetirAsync(isciId);
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
        Novbe? aktivNovbe = await AktivNovbeniGetirAsync(isciId);
        if (aktivNovbe != null)
        {
            return EmeliyyatNeticesi<Novbe>.Ugursuz("Bu istifadəçi üçün artıq açıq növbə mövcuddur.");
        }

        Novbe yeniNovbe = new() { IsciId = isciId, AcilmaTarixi = DateTime.Now, BaslangicMebleg = baslangicMebleg, Status = NovbeStatusu.Aciq };
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
        Istifadeci? istifadeci = IcazeYoxlayici.Instance.AktivIstifadeci;
        if (istifadeci != null && istifadeci.RolId != 1)
            return EmeliyyatNeticesi<ZHesabatDto>.Ugursuz("Növbəni əl ilə yalnız administrator bağlaya bilər.");
        return await NovbeBaglaDaxiliAsync(novbeId, faktikiMebleg, true);
    }

    public async Task<EmeliyyatNeticesi<ZHesabatDto>> NovbeAvtomatikBaglaAsync(int novbeId)
        => await NovbeBaglaDaxiliAsync(novbeId, 0, false);

    private async Task<EmeliyyatNeticesi<ZHesabatDto>> NovbeBaglaDaxiliAsync(int novbeId, decimal faktikiMebleg, bool sayimAparilib)
    {
        return await _unitOfWork.ExecuteInTransactionAsync(async () =>
        {
            Novbe novbe = await _unitOfWork.Novbeler.GetirAsync(novbeId);
            if (novbe == null || novbe.Status == NovbeStatusu.Bagli)
            {
                return EmeliyyatNeticesi<ZHesabatDto>.Ugursuz("Növbə tapılmadı və ya artıq bağlıdır.");
            }

            IEnumerable<Satis> novbeSatislar = await _unitOfWork.Satislar.AxtarAsync(s => s.NovbeId == novbeId);
            decimal nagdSatislar = novbeSatislar.Where(s => s.OdenisMetodu == OdenisMetodu.Nağd).Sum(s => s.UmumiMebleg);
            decimal kartSatislar = novbeSatislar.Where(s => s.OdenisMetodu == OdenisMetodu.Kart).Sum(s => s.UmumiMebleg);
            decimal nisyeSatislar = novbeSatislar.Where(s => s.OdenisMetodu == OdenisMetodu.Nisyə).Sum(s => s.UmumiMebleg);
            // Köhnə açıq növbələrdə satışlar hələ jurnala yazılmamış ola bilər.
            List<KassaHareketi> hereketler = (await _unitOfWork.KassaHareketleri
                .AxtarAsync(k => k.NovbeId == novbeId)).ToList();
            foreach (Satis satis in novbeSatislar.Where(s => s.OdenisMetodu is OdenisMetodu.Nağd or OdenisMetodu.Kart))
            {
                if (hereketler.Any(k => k.EmeliyyatNovu == EmeliyyatNovu.Satis && k.EmeliyyatId == satis.Id)) continue;
                KassaHareketi hereket = new()
                {
                    HareketNovu = KassaHareketiNovu.Daxilolma,
                    EmeliyyatNovu = EmeliyyatNovu.Satis,
                    EmeliyyatId = satis.Id,
                    NovbeId = novbeId,
                    OdenisMetodu = satis.OdenisMetodu,
                    Mebleg = satis.UmumiMebleg,
                    Tarix = satis.Tarix,
                    Qeyd = $"Satış #{satis.Id}",
                    IstifadeciId = novbe.IsciId
                };
                await _unitOfWork.KassaHareketleri.ElaveEtAsync(hereket);
                hereketler.Add(hereket);
            }
            IEnumerable<KassaHareketi> borcOdenisleri = hereketler.Where(
                k => k.EmeliyyatNovu == EmeliyyatNovu.Odenis && k.HareketNovu == KassaHareketiNovu.Daxilolma);
            decimal nagdBorcOdenisleri = borcOdenisleri.Where(k => k.OdenisMetodu == OdenisMetodu.Nağd).Sum(k => k.Mebleg);
            decimal kartBorcOdenisleri = borcOdenisleri.Where(k => k.OdenisMetodu == OdenisMetodu.Kart).Sum(k => k.Mebleg);

            novbe.BaglanmaTarixi = DateTime.Now;
            novbe.GozlenilenMebleg = novbe.BaslangicMebleg
                + hereketler.Where(k => k.OdenisMetodu == OdenisMetodu.Nağd && k.HareketNovu == KassaHareketiNovu.Daxilolma).Sum(k => k.Mebleg)
                - hereketler.Where(k => (k.OdenisMetodu == OdenisMetodu.Nağd || k.OdenisMetodu == null) && k.HareketNovu == KassaHareketiNovu.Cixis).Sum(k => k.Mebleg);
            novbe.FaktikiMebleg = sayimAparilib ? faktikiMebleg : novbe.GozlenilenMebleg;
            novbe.SayimAparilib = sayimAparilib;
            novbe.Status = NovbeStatusu.Bagli;
            _unitOfWork.Novbeler.Yenile(novbe);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Istifadeci isci = await _unitOfWork.Istifadeciler.GetirAsync(novbe.IsciId);
            ZHesabatDto hesabat = new()
            {
                AcilmaTarixi = novbe.AcilmaTarixi,
                BaglanmaTarixi = novbe.BaglanmaTarixi.Value,
                KassirAdi = isci?.TamAd ?? "Naməlum",
                BaslangicMebleg = novbe.BaslangicMebleg,
                SatisSayi = novbeSatislar.Count(),
                NagdSatislar = nagdSatislar,
                KartSatislar = kartSatislar,
                NisyeSatislar = nisyeSatislar,
                NagdBorcOdenisleri = nagdBorcOdenisleri,
                KartBorcOdenisleri = kartBorcOdenisleri,
                NagdQaytarmalar = hereketler.Where(k => k.EmeliyyatNovu == EmeliyyatNovu.Qaytarma && k.OdenisMetodu == OdenisMetodu.Nağd).Sum(k => k.Mebleg),
                KartQaytarmalar = hereketler.Where(k => k.EmeliyyatNovu == EmeliyyatNovu.Qaytarma && k.OdenisMetodu == OdenisMetodu.Kart).Sum(k => k.Mebleg),
                NagdXercler = hereketler.Where(k => k.EmeliyyatNovu == EmeliyyatNovu.Xerc && k.HareketNovu == KassaHareketiNovu.Cixis).Sum(k => k.Mebleg),
                TedarukcuOdemeleri = hereketler.Where(k => k.EmeliyyatNovu == EmeliyyatNovu.Odenis && k.HareketNovu == KassaHareketiNovu.Cixis).Sum(k => k.Mebleg),
                GozlenilenMebleg = novbe.GozlenilenMebleg,
                FaktikiMebleg = novbe.FaktikiMebleg,
                SayimAparilib = novbe.SayimAparilib
            };
            return EmeliyyatNeticesi<ZHesabatDto>.Ugurlu(hesabat);
        });
    }
}
