// Fayl: AzAgroPOS.Verilenler/Realizasialar/NisyeHereketiRepozitori.cs
namespace AzAgroPOS.Verilenler.Realizasialar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Varliglar;

public class NisyeHereketiRepozitori : Repozitori<NisyeHereketi>, INisyeHereketiRepozitori
{
    public NisyeHereketiRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst) { }
}