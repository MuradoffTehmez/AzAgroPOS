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
        public decimal AnbarMiqdari { get; set; } 
        public bool Aktivdir { get; set; }
        public int OlcuVahidiId { get; set; }
        public string OlcuVahidiAdi { get; set; } = string.Empty;
    }
}