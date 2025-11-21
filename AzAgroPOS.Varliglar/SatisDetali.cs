// AzAgroPOS.Varliglar/SatisDetali.cs
namespace AzAgroPOS.Varliglar
{
    public class SatisDetali : BazaVarligi
    {
        public int SatisId { get; set; }
        public Satis Satis { get; set; } = null!;
        public int MehsulId { get; set; }
        public Mehsul Mehsul { get; set; } = null!;
        public decimal Miqdar { get; set; }
        public decimal Qiymet { get; set; }
        public decimal UmumiMebleg { get; set; }
    }
}