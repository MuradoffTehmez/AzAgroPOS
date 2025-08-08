using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using AzAgroPOS.Varliglar;

public class SatisRepozitori : Repozitori<AzAgroPOS.Varliglar.Satis>, ISatisRepozitori 
{ 
    public SatisRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst) 
    {
        // Burada əlavə konfiqurasiyalar və ya metodlar əlavə edilə bilər
    }
}