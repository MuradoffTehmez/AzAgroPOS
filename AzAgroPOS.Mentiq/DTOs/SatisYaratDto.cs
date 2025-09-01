using AzAgroPOS.Varliglar;
using System.Collections.Generic;

namespace AzAgroPOS.Mentiq.DTOs
{
    public class SatisYaratDto
    {
        public List<SatisSebetiElementiDto> SebetElementleri { get; set; } = new List<SatisSebetiElementiDto>();
        public OdenisMetodu OdenisMetodu { get; set; }

        public int NovbeId { get; set; }
        
        public int? MusteriId { get; set; }
        
        public decimal UmumiMebleg { get; set; }
        
        public decimal Endirim { get; set; }
        
        public decimal YekunMebleg { get; set; }
    }
}