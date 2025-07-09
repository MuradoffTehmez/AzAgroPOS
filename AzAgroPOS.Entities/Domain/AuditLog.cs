using System;

namespace AzAgroPOS.Entities.Domain
{
    public class AuditLog
    {
        public long Id { get; set; }
        public int? IstifadeciId { get; set; }
        public string Emeliyyat { get; set; }
        public string Detal { get; set; }
        public string IP { get; set; }
        public DateTime? Tarix { get; set; }
    }
}