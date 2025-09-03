// AzAgroPOS.Varliglar/Mehsul.cs
namespace AzAgroPOS.Varliglar
{
    public class Mehsul : BazaVarligi
    {
        public string Ad { get; set; } = string.Empty;
        public string? Barkod { get; set; }
        public string? StokKodu { get; set; }
        // OlcuVahidiId silindi
        public OlcuVahidi OlcuVahidi { get; set; }
        public decimal AlisQiymeti { get; set; }
        public decimal PerakendeSatisQiymeti { get; set; }
        public decimal TopdanSatisQiymeti { get; set; }
        public decimal TekEdedSatisQiymeti { get; set; }
        public int MovcudSay { get; set; }
        public bool Aktivdir { get; set; } = true;
    }
}