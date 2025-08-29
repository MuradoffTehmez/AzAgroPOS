// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IAnbarView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using System;
using System.Windows.Forms;

/// <summary>
/// Anbar qeydiyyat formu üçün "müqavilə". Presenter-in View ilə necə əlaqə quracağını təyin edir.
/// </summary>
public interface IAnbarView
{
    // View-dan məlumat oxumaq üçün
    string AxtarisMetni { get; }
    string ElaveOlunanSay { get; }
    int? SecilmisMehsulId { get; }

    // Hadisələr
    event EventHandler AxtarIstek;
    event EventHandler StokArtirIstek;

    // View-a məlumat göndərmək üçün metodlar
    void MehsulMelumatlariniGoster(MehsulDto mehsul);
    void FormuTemizle(bool axtarisQutusuQalsin = false);
    DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon);
}