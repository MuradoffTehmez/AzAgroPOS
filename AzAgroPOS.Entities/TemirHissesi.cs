// Fayl: AzAgroPOS.Entities/TemirHissesi.cs
namespace AzAgroPOS.Entities
{
    public class TemirHissesi
    {
        public int Id { get; set; }
        public int TemirId { get; set; }
        public int MehsulId { get; set; }
        public string MehsulAdi { get; set; }
        public int Miqdar { get; set; }
        public decimal QiymetBirEdede { get; set; }
        public decimal TotalQiymet => Miqdar * QiymetBirEdede;
    }
}