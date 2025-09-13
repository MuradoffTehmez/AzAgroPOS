// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IAnaMenuView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

/// <summary>
/// Ana menu formu üçün interfeys. Presenter-in View ilə necə əlaqə quracağını təyin edir.
/// </summary>
public interface IAnaMenuView
{
    // View-dan məlumat oxumaq üçün
    IServiceProvider ServiceProvider { get; }

    // Hadisələr
    event EventHandler FormYuklendi;
    event EventHandler<FormClosingEventArgs> FormBaglaniyor;

    // View-a məlumat göndərmək üçün metodlar
    void UsaqFormuAc<T>() where T : Form;
    void IcazeleriYoxla();
    void MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon);
}