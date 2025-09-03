// Fayl: AzAgroPOS.Mentiq/DTOs/MehsulDto.cs
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Mentiq.DTOs
{
    public class MehsulDto
    {
        public int Id { get; set; }
        public string Ad { get; set; } = string.Empty;
        public string? Barkod { get; set; }
        public string? StokKodu { get; set; }
        public decimal AlisQiymeti { get; set; }
        public decimal PerakendeSatisQiymeti { get; set; }
        public string PerakendeSatisQiymetiStr => $"{PerakendeSatisQiymeti:N2} AZN";
        public decimal TopdanSatisQiymeti { get; set; }
        public decimal TekEdedSatisQiymeti { get; set; }
        public int MovcudSay { get; set; }
        public bool Aktivdir { get; set; }
        public OlcuVahidi OlcuVahidi { get; set; }
        public decimal AnbarMiqdari { get; set; }

        // --- BU SƏTİRLƏR DƏYİŞDİRİLDİ ---
        // public int OlcuVahidiId { get; set; } // Bu sətir silindi
        public string OlcuVahidiAdi => OlcuVahidi.ToString(); // Bu sətir sadələşdirilib
        public string OlcuVahidiStr => OlcuVahidi.ToString();
    }
}