// Fayl: AzAgroPOS.Teqdimat/Yardimcilar/GozleyenSatis.cs
using AzAgroPOS.Mentiq.DTOs;
using System.Collections.Generic;

namespace AzAgroPOS.Teqdimat.Yardimcilar
{
    public class GozleyenSatis
    {
        public string Ad { get; set; }
        public List<SatisSebetiElementiDto> Sebet { get; set; }

        public GozleyenSatis(string ad, List<SatisSebetiElementiDto> sebet)
        {
            Ad = ad;
            Sebet = sebet;
        }

        public override string ToString() => Ad;
    }
}