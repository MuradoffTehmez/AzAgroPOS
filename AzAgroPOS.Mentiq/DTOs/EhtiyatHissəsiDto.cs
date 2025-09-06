using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzAgroPOS.Mentiq.DTOs
{
    public class EhtiyatHissəsiDto
    {
        public int MehsulId { get; set; }
        public string MehsulAdi { get; set; } = string.Empty;
        public decimal Miqdar { get; set; }
        public decimal Qiymet { get; set; }
        public decimal ÜmumiMəbləğ => Miqdar * Qiymet;
    }
}