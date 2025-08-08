// Fayl: AzAgroPOS.Verilenler/Realizasialar/NovbeRepozitori.cs
namespace AzAgroPOS.Verilenler.Realizasialar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
public class NovbeRepozitori : Repozitori<Novbe>, INovbeRepozitori
{
    public NovbeRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst) { }
}