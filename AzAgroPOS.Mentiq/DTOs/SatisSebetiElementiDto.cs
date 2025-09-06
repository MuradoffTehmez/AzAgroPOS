namespace AzAgroPOS.Mentiq.DTOs
{
    public class SatisSebetiElementiDto
    {
        public int MehsulId { get; set; }
        
        public string MehsulAdi { get; set; } = string.Empty;

        public decimal Miqdar { get; set; }

        public decimal VahidinQiymeti { get; set; }

        // Discount properties for individual items
        public decimal EndirimMeblegi { get; set; } // Applied discount amount for this item
        public decimal EndirimliQiymet => VahidinQiymeti - (EndirimMeblegi / (Miqdar > 0 ? Miqdar : 1)); // Price after discount per unit

        // Total amount for the item after discount
        public decimal UmumiMebleg => (VahidinQiymeti * Miqdar) - EndirimMeblegi;

        public string QiymetNövü { get; set; } = "Pərakəndə";
    }
}