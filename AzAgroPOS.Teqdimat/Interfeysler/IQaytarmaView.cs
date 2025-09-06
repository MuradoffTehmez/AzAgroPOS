using AzAgroPOS.Mentiq.DTOs;

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