// Fayl: AzAgroPOS.Entities/Odenis.cs
using System;

namespace AzAgroPOS.Entities
{
    public class Odenis
    {
        public int Id { get; set; }
        public int SatisId { get; set; }
        public int OdenisNovId { get; set; }
        public decimal OdenisMeblegi { get; set; }
        public DateTime OdenisTarixi { get; set; }
        public string KartSonDordReqem { get; set; }
    }
}