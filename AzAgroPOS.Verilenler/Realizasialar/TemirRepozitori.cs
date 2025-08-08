// Fayl: AzAgroPOS.Verilenler/Realizasialar/TemirRepozitori.cs
namespace AzAgroPOS.Verilenler.Realizasialar;

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;

public class TemirRepozitori : Repozitori<Temir>, ITemirRepozitori
{
    public TemirRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst) { }
}