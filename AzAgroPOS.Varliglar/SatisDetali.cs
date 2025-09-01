namespace AzAgroPOS.Varliglar
{
    public class SatisDetali : BazaVarligi
    {
        public int SatisId { get; set; }

        public Satis Satis { get; set; }

        public int MehsulId { get; set; }

        public Mehsul Mehsul { get; set; }

        public decimal Miqdar { get; set; }

        public decimal SatisQiymeti { get; set; }

        public decimal UmumiMebleg { get; set; }
    }
}