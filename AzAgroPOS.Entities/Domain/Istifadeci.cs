namespace AzAgroPOS.Entities.Domain
{
    public class Istifadeci
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string ParolHash { get; set; }
        public int? RolId { get; set; }
        public int? TemaId { get; set; }
        public string Status { get; set; }
    }
}