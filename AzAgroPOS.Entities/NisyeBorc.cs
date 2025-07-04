// Fayl: AzAgroPOS.Entities/NisyeBorc.cs
using System;

namespace AzAgroPOS.Entities
{
    public class NisyeBorc
    {
        public int Id { get; set; }
        public int MusteriId { get; set; }
        public int? SatishId { get; set; }
        public decimal BorcMeblegi { get; set; }
        public decimal FaizDerecesi { get; set; }
        public decimal ToplamBorcMeblegi { get; set; }
        public DateTime YaradilmaTarixi { get; set; }
        public DateTime OdemeBaslamaTarixi { get; set; }
        public DateTime OdemeBitmeTarixi { get; set; }
        public string Status { get; set; }
    }
}