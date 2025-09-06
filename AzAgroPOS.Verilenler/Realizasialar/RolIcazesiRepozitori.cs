// AzAgroPOS.Verilenler/Realizasialar/RolIcazesiRepozitori.cs
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;

namespace AzAgroPOS.Verilenler.Realizasialar;

public class RolIcazesiRepozitori : Repozitori<RolIcazesi>, IRolIcazesiRepozitori
{
    public RolIcazesiRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
    }
}