using AzAgroPOS.Mentiq.DTOs;

namespace AzAgroPOS.Teqdimat.Interfeysler
{
    public interface IMusteriView
    {
        int SecilmisMusteriId { get; }
        string TamAd { get; set; }
        string Telefon { get; set; }
        string Unvan { get; set; }
        string KreditLimiti { get; set; }
        string AxtarisMetni { get; }

        event EventHandler FormYuklendi;
        event EventHandler MusteriSecildi;
        event EventHandler YeniMusteriIstek;
        event EventHandler YaddaSaxlaIstek;
        event EventHandler SilIstek;
        event EventHandler AxtarIstek;
        event EventHandler NovbetiSehifeIstek;
        event EventHandler EvvelkiSehifeIstek;

        void MusterileriGoster(List<MusteriDto> musteriler);
        void FormuTemizle();
        void MesajGoster(string mesaj, string basliq, MessageBoxIcon ikon);
        void SehifeMelumatlariGoster(int cariSehife, int umumiSehife, int umumiQeyd, bool evvelkiVar, bool novbetiVar);
        Task EmeliyyatIcraEtAsync(Func<Task> emeliyyat, string mesaj);

        // Validation methods
        void XetaGoster(Control control, string message);
        void XetaniTemizle(Control control);
        void ButunXetalariTemizle();
    }
}