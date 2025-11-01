// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IBazaIdareetmeView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using System;

/// <summary>
/// Baza idarəetmə forması üçün interfeys.
/// Verilənlər bazası backup və restore əməliyyatlarını idarə edir.
/// </summary>
public interface IBazaIdareetmeView
{
    // Baza məlumatları
    string SecilenBackupYolu { get; }

    // View metodları
    void BazaOlcusunuGoster(double olcuMB);
    void SonBackupTarixiniGoster(DateTime? tarix);
    void BackupFayllariniGoster();
    void MesajGoster(string mesaj, string basliq, System.Windows.Forms.MessageBoxButtons duymeler, System.Windows.Forms.MessageBoxIcon ikon);
    System.Windows.Forms.DialogResult TesdiqMesajiGoster(string mesaj, string basliq);
    void UgurluMesajGoster(string mesaj);
    void XetaMesajiGoster(string mesaj, string modul);

    // Hadisələr
    event EventHandler FormYuklendi;
    event EventHandler BackupYarat_Istek;
    event EventHandler RestoreEt_Istek;
    event EventHandler BackupSil_Istek;
    event EventHandler Yenile_Istek;
    event EventHandler QovluguAc_Istek;
}
