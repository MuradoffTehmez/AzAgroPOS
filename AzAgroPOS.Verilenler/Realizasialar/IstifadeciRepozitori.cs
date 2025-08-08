using AzAgroPOS.Verilenler;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;

public class IstifadeciRepozitori : Repozitori<Istifadeci>, IIstifadeciRepozitori 
{ 
    public IstifadeciRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst) 
    {
     
    } 
}