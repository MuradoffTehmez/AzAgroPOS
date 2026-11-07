// Fayl: AzAgroPOS.Teqdimat/Yardimcilar/GozleyenSatis.cs
using AzAgroPOS.Mentiq.DTOs;

namespace AzAgroPOS.Teqdimat.Yardimcilar
{
    public class GozleyenSatis
    {
        public string Ad { get; set; }
        public List<SatisSebetiElementiDto> Sebet { get; set; }
        public int? MusteriId { get; set; }
        public decimal SebetEndirimi { get; set; }
        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;

        public GozleyenSatis()
        {
            Ad = string.Empty;
            Sebet = new List<SatisSebetiElementiDto>();
        }

        public GozleyenSatis(string ad, List<SatisSebetiElementiDto> sebet)
        {
            Ad = ad;
            Sebet = sebet;
        }

        public override string ToString()
        {
            return Ad;
        }
    }
}
