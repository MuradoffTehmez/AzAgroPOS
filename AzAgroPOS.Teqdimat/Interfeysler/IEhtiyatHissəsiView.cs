// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IEhtiyatHissəsiView.cs
using AzAgroPOS.Mentiq.DTOs;

namespace AzAgroPOS.Teqdimat.Interfeysler;

/// <summary>
/// Ehtiyat hissəsi formu üçün interfeys. Presenter-in View ilə necə əlaqə quracağını təyin edir.
/// </summary>
public interface IEhtiyatHissəsiView
{
    // View-dan məlumat oxumaq üçün
    string AxtarisMetni { get; }
    string Miqdar { get; }
    MehsulDto SecilmisMehsul { get; }
    List<EhtiyatHissəsiDto> EhtiyatHissələri { get; }

    // Hadisələr
    event EventHandler AxtarIstek;
    event EventHandler ElaveEtIstek;
    event EventHandler SilIstek;
    event EventHandler TamamIstek;
    event EventHandler İmtinaIstek;

    // View-a məlumat göndərmək üçün metodlar
    void MehsullariGoster(List<MehsulDto> mehsullar);
    void SeçilmişMehsullariGoster(List<EhtiyatHissəsiDto> ehtiyatHissələri);
    void FormuTemizle();
    DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon);
    void XetaGoster(Control control, string message);
    void XetaniTemizle(Control control);
    void ButunXetalariTemizle();
}