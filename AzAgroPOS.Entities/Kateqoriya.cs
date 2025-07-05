// Fayl: AzAgroPOS.Entities/Kateqoriya.cs

namespace AzAgroPOS.Entities
{
    public class Kateqoriya
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Tesvir { get; set; }
        public int? AnaKateqoriyaId { get; set; }
        public bool Aktivdir { get; set; }
        // Digər xüsusiyyətlər də bura əlavə oluna bilər
    }
}