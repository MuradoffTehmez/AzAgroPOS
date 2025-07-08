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
        //public DateTime? TemirBitisTarixi { get; set; }
        //public string QebulEdilenCihaz { get; set; }
        //public string QaytarilanCihaz { get; set; }
        //public string QebulEdilenSeriyaNomresi { get; set; }
        //public string QaytarilanSeriyaNomresi { get; set; }
        //public string QebulEdilenProblem { get; set; }
        //public string QaytarilanProblem { get; set; }
        //public DateTime? QaytarilmaTarixi { get; set; }
        //public string QaytarilmaSebepleri { get; set; }
        //public bool Qaytarilib { get; set; }
        //public string QaytarilmaSebepleriTesviri { get; set; }
        //public string QaytarilmaSebepleriTesviri2 { get; set; }
        //public string QaytarilmaSebepleriTesviri3 { get; set; }
        //public string QaytarilmaSebepleriTesviri4 { get; set; }
        //public string QaytarilmaSebepleriTesviri5 { get; set; }

        public System.Collections.Generic.List<TemirHissesi> Hisseler
        { get; set; } = new System.Collections.Generic.List<TemirHissesi>();
    }
}