using AzAgroPOS.Varliglar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzAgroPOS.Mentiq.DTOs
{
    internal class KassaHareketiDto
    {
        public int Id { get; set; }
        public DateTime Tarix { get; set; }=DateTime.Now;
        public string Tesvir { get; set; } = "";
        public decimal Mebleg { get; set; }=0;
        public KassaHareketiNovu Novu { get; set; }
        public KassaHareketi hareketler { get; set; }
        public string SenedNomresi { get; set; }="";
        public string Qeyd { get; set; }="";
    }
}
