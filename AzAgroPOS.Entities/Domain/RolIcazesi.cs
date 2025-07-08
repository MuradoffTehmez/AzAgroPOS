namespace AzAgroPOS.Entities.Domain
{
    public class RolIcazesi
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public string Modul { get; set; }
        public string Emeliyyat { get; set; }
        public bool IcazeVerilib { get; set; } 
    }
}