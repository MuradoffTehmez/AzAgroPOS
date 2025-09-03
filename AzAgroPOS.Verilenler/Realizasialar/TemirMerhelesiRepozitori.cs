using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;

namespace AzAgroPOS.Verilenler.Realizasialar
{
    public class TemirMerhelesiRepozitori : Repozitori<TemirMerhelesi>, ITemirMerhelesiRepozitori
    {
        public TemirMerhelesiRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
        {
            // burada əlavə konfiqurasiyalar və ya xüsusi əməliyyatlar əlavə edilə bilər
        }
    }
}