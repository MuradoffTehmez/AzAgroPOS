using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;

public class RolRepozitori : Repozitori<AzAgroPOS.Varliglar.Rol>, IRolRepozitori 
{ public RolRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst) 
    {
        // Burada əlavə konfiqurasiyalar və ya metodlar əlavə edilə bilər
    }
}