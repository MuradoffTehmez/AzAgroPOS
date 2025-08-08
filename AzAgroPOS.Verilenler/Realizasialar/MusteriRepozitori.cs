using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using AzAgroPOS.Varliglar;

public class MusteriRepozitori : Repozitori<AzAgroPOS.Varliglar.Musteri>, IMusteriRepozitori
{
    public MusteriRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst) 
    {
    
    }
}