using System;
namespace AzAgroPOS.Entities
{
    public class Temir
    {
        public int Id { get; set; }
        public int MusteriId { get; set; }
        public string CihazAdi { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string SeriyaNomresi { get; set; }
        public string ProblemTesviri { get; set; }
        public DateTime QebulTarixi { get; set; }
        public int StatusId { get; set; }
        public int? TemirciId { get; set; }


        public string MusteriAdi { get; set; }
        public string TemirciAdi { get; set; }
        public string StatusAdi { get; set; }
    }
}