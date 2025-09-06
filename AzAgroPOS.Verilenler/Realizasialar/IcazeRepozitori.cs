// AzAgroPOS.Verilenler/Realizasialar/IcazeRepozitori.cs
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;

namespace AzAgroPOS.Verilenler.Realizasialar;

public class IcazeRepozitori : Repozitori<Icaze>, IIcazeRepozitori
{
    public IcazeRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
    }
}