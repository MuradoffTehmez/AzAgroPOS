namespace AzAgroPOS.Mentiq.DTOs
{
    public class SatisSebetiElementiDto
    {
        public int MehsulId { get; set; }
        
        public string MehsulAdi { get; set; } = string.Empty;

        public decimal Miqdar { get; set; }

        public decimal VahidinQiymeti { get; set; }

        public decimal UmumiMebleg => Miqdar * VahidinQiymeti;

        public string QiymetNövü { get; set; } = "Pərakəndə";
    }
}