using System;

namespace AzAgroPOS.Varliglar
{
    public class TemirMerhelesi : BazaVarligi
    {
        public int TemirId { get; set; }
        public virtual Temir Temir { get; set; }
        public DateTime Tarix { get; set; }
        public string Aciqlama { get; set; }
        public TemirStatusu Status { get; set; }
    }
}