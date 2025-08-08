// Fayl: AzAgroPOS.Verilenler/Realizasialar/RolRepozitori.cs
namespace AzAgroPOS.Verilenler.Realizasialar;

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;

public class RolRepozitori : Repozitori<Rol>, IRolRepozitori
{
    public RolRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst) { }
}