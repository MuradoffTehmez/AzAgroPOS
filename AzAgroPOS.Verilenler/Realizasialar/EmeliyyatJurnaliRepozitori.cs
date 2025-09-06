// AzAgroPOS.Verilenler/Realizasialar/EmeliyyatJurnaliRepozitori.cs
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;

namespace AzAgroPOS.Verilenler.Realizasialar;

public class EmeliyyatJurnaliRepozitori : Repozitori<EmeliyyatJurnali>, IEmeliyyatJurnaliRepozitori
{
    public EmeliyyatJurnaliRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
    }
}