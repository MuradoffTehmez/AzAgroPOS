// Fayl: AzAgroPOS.Entities/Musteri.cs
using System;

namespace AzAgroPOS.Entities
{
    public class Musteri
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Unvan { get; set; }
        public string Email { get; set; }
        public decimal NisyeLimiti { get; set; }
        public decimal CariNisyeBorcu { get; set; }
        public decimal EndirimFaizi { get; set; }
        public bool Aktivdir { get; set; }
        public string Qeyd { get; set; }
        public DateTime YaradilmaTarixi { get; set; }
    }
}