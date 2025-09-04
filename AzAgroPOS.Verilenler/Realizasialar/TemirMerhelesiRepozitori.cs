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
            // məsələn, təmir mərhələsi ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər, məsələn: müəyyən tarix aralığında təmir mərhələlərini tapmaq, müəyyən avadanlığın təmir mərhələlərini filtrləmək və s.
            // təmir tipi üzrə təmir mərhələlərini tapmaq üçün xüsusi metodlar əlavə edilə bilər.
            // təmir işləri üçün ayri bir ödəniş hesabati üçün xüsusi metodlar əlavə edilə bilər.
        }
    }
}