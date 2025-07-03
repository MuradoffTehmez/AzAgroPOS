// Fayl: AzAgroPOS.Entities/Istifadeci.cs
using System;

namespace AzAgroPOS.Entities
{
    public class Istifadeci
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string IstifadeciAdi { get; set; }
        public string ParolHash { get; set; }
        public string ParolSalt { get; set; }
        public int RolId { get; set; }
        public bool Aktivdir { get; set; }
        public DateTime? SonGirisTarixi { get; set; }
        public DateTime YaradilmaTarixi { get; set; }
        public DateTime? DeaktivasiyaTarixi { get; set; }
    }
}