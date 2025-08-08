// Fayl: AzAgroPOS.Verilenler/Realizasialar/UnitOfWork.cs
namespace AzAgroPOS.Verilenler.Realizasialar;

using System.Threading.Tasks;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Varliglar;

public class UnitOfWork : IUnitOfWork
{
    private readonly AzAgroPOSDbContext _kontekst;

    // Repozitorilərin instansiyaları
    public IMehsulRepozitori Mehsullar { get; private set; }
    public IMusteriRepozitori Musteriler { get; private set; }
    public ISatisRepozitori Satislar { get; private set; }
    public IIstifadeciRepozitori Istifadeciler { get; private set; }
    public IRolRepozitori Rollar { get; private set; }
    public INisyeHereketiRepozitori NisyeHereketleri { get; private set; }
    public ITemirRepozitori TemirSifarisleri { get; private set; }
    public INovbeRepozitori Novbeler { get; private set; }

    public UnitOfWork(AzAgroPOSDbContext kontekst)
    {
        _kontekst = kontekst;

        // Repozitoriləri yaradırıq
        Mehsullar = new MehsulRepozitori(_kontekst);
        Musteriler = new MusteriRepozitori(_kontekst);
        Satislar = new SatisRepozitori(_kontekst);
        Istifadeciler = new IstifadeciRepozitori(_kontekst);
        Rollar = new RolRepozitori(_kontekst);
        NisyeHereketleri = new NisyeHereketiRepozitori(_kontekst);
        TemirSifarisleri = new TemirRepozitori(_kontekst);
        Novbeler = new NovbeRepozitori(_kontekst);
    }

    public async Task<int> EmeliyyatiTesdiqleAsync()
    {
        return await _kontekst.SaveChangesAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await _kontekst.DisposeAsync();
    }
}