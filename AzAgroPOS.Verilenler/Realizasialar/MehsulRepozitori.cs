using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using AzAgroPOS.Varliglar;

public class MehsulRepozitori : Repozitori<AzAgroPOS.Varliglar.Mehsul>, IMehsulRepozitori
{
    public MehsulRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst) 
    { 
    
    }
}