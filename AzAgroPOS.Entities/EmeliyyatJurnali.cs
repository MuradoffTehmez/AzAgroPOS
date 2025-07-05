// Fayl: AzAgroPOS.Entities/EmeliyyatJurnali.cs
using System;

namespace AzAgroPOS.Entities
{
    public class EmeliyyatJurnali
    {
        public int Id { get; set; }
        public int IstifadeciId { get; set; }
        public DateTime EmeliyyatTarixi { get; set; }
        public string EmeliyyatNovu { get; set; }
        public string Tesvir { get; set; }
        public string IstifadeciAdi { get; set; }
        public DateTime Tarix { get; set; }
    }
}