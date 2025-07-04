// Fayl: AzAgroPOS.Entities/SatisMehsulu.cs
namespace AzAgroPOS.Entities
{
    public class SatisMehsulu
    {
        public int Id { get; set; }
        public int SatisId { get; set; }
        public int MehsulId { get; set; }
        public string MehsulAdi { get; set; } 
        public decimal Miqdar { get; set; }
        public decimal QiymetBirEdede { get; set; }
        public decimal EndirimMeblegi { get; set; }
    }
}