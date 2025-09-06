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

        // Yeni əlavə edilən sahələr
        public int? KateqoriyaId { get; set; }
        public Kateqoriya? Kateqoriya { get; set; }

        public int? BrendId { get; set; }
        public Brend? Brend { get; set; }

        public int? TedarukcuId { get; set; }
        public Tedarukcu? Tedarukcu { get; set; }

        public int MinimumStok { get; set; } = 0;

        public string? SekilYolu { get; set; }
    }
}