using AzAgroPOS.Mentiq.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat.Interfeysler
{
    public interface IQaytarmaView
    {
        string SatisNomresi { get; }
        string QaytarmaSebebi { get; }
        List<SatisSebetiElementiDto> SecilmisMehsullar { get; }

        event EventHandler SatisAxtarIstek;
        event EventHandler QaytarmaEmeliyyatiIstek;

        void SatisMehsullariniGoster(List<SatisSebetiElementiDto> mehsullar);
        DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons buttons, MessageBoxIcon icon);
    }
}