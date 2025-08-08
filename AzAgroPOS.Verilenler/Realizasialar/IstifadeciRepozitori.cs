using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;

public class IstifadeciRepozitori : Repozitori<AzAgroPOS.Varliglar.Istifadeci>, IIstifadeciRepozitori 
{ 
    public IstifadeciRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst) 
    {
     
    } 
}