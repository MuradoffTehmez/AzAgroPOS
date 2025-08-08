// Fayl: AzAgroPOS.Verilenler/Realizasialar/IstifadeciRepozitori.cs
namespace AzAgroPOS.Verilenler.Realizasialar;

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;

public class IstifadeciRepozitori : Repozitori<Istifadeci>, IIstifadeciRepozitori
{
    public IstifadeciRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst) { }
}