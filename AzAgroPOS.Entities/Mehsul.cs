// Fayl: AzAgroPOS.Entities/Mehsul.cs

using System;

namespace AzAgroPOS.Entities
{
    public class Mehsul
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Barkod { get; set; }
        public int KateqoriyaId { get; set; }
        public int VahidId { get; set; }
        public decimal AlisQiymeti { get; set; }
        public decimal SatisQiymeti { get; set; }
        public int MinimumStok { get; set; }
        public int CariStok { get; set; }
        public int? TedarukcuId { get; set; } // Nullable ola bilər
        public string Tesvir { get; set; }
        public bool Aktivdir { get; set; }
        public bool Silinib { get; set; }

        // Bu xüsusiyyətlər View-dan gələcək, birbaşa cədvəldə yoxdur
        public string KateqoriyaAdi { get; set; }
        public string VahidAdi { get; set; }
    }
}