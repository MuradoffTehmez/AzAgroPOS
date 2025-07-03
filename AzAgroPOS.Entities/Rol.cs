// Fayl: AzAgroPOS.Entities/Rol.cs
using System;

namespace AzAgroPOS.Entities
{
    public class Rol
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Tesvir { get; set; }
        public DateTime YaradilmaTarixi { get; set; }
        public DateTime? SonDeyisiklik { get; set; } // Nullable DateTime
    }
}