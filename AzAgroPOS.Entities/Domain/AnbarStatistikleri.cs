using System;

namespace AzAgroPOS.Entities.Domain
{
    public class AnbarStatistikleri
    {
        public int UmumiMehsulSayi { get; set; }
        public decimal UmumiMehsulMiqdari { get; set; }
        public decimal UmumiDeger { get; set; }
        public int MinimumSeviyyeAltindaMehsulSayi { get; set; }
        public int MaksimumSeviyyeUstundeMehsulSayi { get; set; }
        public int StoktanKenardaMehsulSayi { get; set; }
        public DateTime? SonHereketTarixi { get; set; }
    }
}