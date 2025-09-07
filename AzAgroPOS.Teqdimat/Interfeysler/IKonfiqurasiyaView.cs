// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IKonfiqurasiyaView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

/// <summary>
/// Konfiqurasiya formu üçün interfeys. Presenter-in View ilə necə əlaqə quracağını təyin edir.
/// </summary>
public interface IKonfiqurasiyaView
{
    // View-a məlumat göndərmək üçün metodlar
    void MesajGoster(string mesaj, string basliq, System.Windows.Forms.MessageBoxButtons düymələr, System.Windows.Forms.MessageBoxIcon ikon);
    void FormuYenile();
}