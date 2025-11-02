// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/BazaIdareetmePresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Teqdimat.Interfeysler;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Baza idarəetmə forması üçün presenter.
/// Verilənlər bazası backup və restore əməliyyatlarını idarə edir.
/// DİQQƏT: Bu forma yalnız Admin icazəsi olan istifadəçilər daxil ola bilər!
/// </summary>
public class BazaIdareetmePresenter
{
    private readonly IBazaIdareetmeView _view;
    private readonly BazaIdareetmeManager _bazaManager;

    public BazaIdareetmePresenter(IBazaIdareetmeView view, BazaIdareetmeManager bazaManager)
    {
        _view = view ?? throw new ArgumentNullException(nameof(view));
        _bazaManager = bazaManager ?? throw new ArgumentNullException(nameof(bazaManager));

        // Hadisələrə abunə oluruq
        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.BackupYarat_Istek += async (s, e) => await BackupYarat();
        _view.RestoreEt_Istek += async (s, e) => await RestoreEt();
        _view.BackupSil_Istek += (s, e) => BackupSil();
        _view.Yenile_Istek += async (s, e) => await MelumatlarıYenile();
        _view.QovluguAc_Istek += (s, e) => QovluguAc();
    }

    /// <summary>
    /// Formu yükləyir - baza məlumatlarını göstərir
    /// </summary>
    private async Task FormuYukle()
    {
        try
        {
            await MelumatlarıYenile();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Baza idarəetmə formu yüklənərkən xəta");
            _view.MesajGoster($"Forma yüklənərkən xəta: {ex.Message}", "Xəta",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Baza məlumatlarını yeniləyir
    /// </summary>
    private async Task MelumatlarıYenile()
    {
        try
        {
            // Verilənlər bazası ölçüsünü göstəririk
            var ölçüNetice = await _bazaManager.BazaOlcusunuGetirAsync();
            if (ölçüNetice.UgurluDur)
            {
                _view.BazaOlcusunuGoster((double)ölçüNetice.Data);
            }

            // Son backup tarixini göstəririk
            var sonBackupNetice = await _bazaManager.SonBackupTarixiniGetirAsync();
            if (sonBackupNetice.UgurluDur)
            {
                _view.SonBackupTarixiniGoster(sonBackupNetice.Data);
            }

            // Backup fayllarını göstəririk
            _view.BackupFayllariniGoster();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Verilənlər bazası məlumatları yüklənərkən xəta");
            _view.XetaMesajiGoster("Məlumatlar yüklənərkən xəta", "Verilənlər Bazası İdarəetmə");
        }
    }

    /// <summary>
    /// Backup yaradır
    /// </summary>
    private async Task BackupYarat()
    {
        try
        {
            // İstifadəçidən təsdiq alırıq
            var tesdiq = _view.TesdiqMesajiGoster(
                "Verilənlər bazasının ehtiyat nüsxəsini yaratmaq istəyirsiniz?\n\n" +
                "Bu əməliyyat bir neçə dəqiqə çəkə bilər.",
                "Backup Yaratma");

            if (tesdiq != DialogResult.Yes)
                return;

            // Backup yolu view-dan alınır (SaveFileDialog vasitəsilə)
            // Bu hissə view-da implementasiya edilir

            Logger.XetaYaz(null, "Backup yaradılmağa başlanır");
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Backup yaradılarkən xəta");
            _view.XetaMesajiGoster("Backup yaradılarkən xəta baş verdi", "Backup Yaratma");
        }
    }

    /// <summary>
    /// Backup-dan restore edir
    /// </summary>
    private async Task RestoreEt()
    {
        try
        {
            var restoreYolu = _view.SecilenBackupYolu;

            if (string.IsNullOrEmpty(restoreYolu) || !File.Exists(restoreYolu))
            {
                _view.MesajGoster("Backup faylı tapılmadı!", "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Çox ciddi xəbərdarlıq!
            var xeberdarlik = _view.TesdiqMesajiGoster(
                "⚠️ DİQQƏT! ⚠️\n\n" +
                "Bu əməliyyat mövcud verilənlər bazasını SİLƏCƏK və seçilmiş " +
                "backup ilə ƏVƏZ EDƏCƏK!\n\n" +
                "Bütün hazırkı məlumatlar itiriləcək!\n\n" +
                "Davam etmək istəyirsiniz?",
                "Çox Təhlükəli Əməliyyat");

            if (xeberdarlik != DialogResult.Yes)
                return;

            // İkinci təsdiq
            var ikinciTesdiq = _view.TesdiqMesajiGoster(
                "Son dəfə soruşuruq:\n\n" +
                "Həqiqətən restore etmək istəyirsiniz?\n\n" +
                "Proqram bağlanacaq və yenidən açmalısınız!",
                "Son Təsdiq");

            if (ikinciTesdiq != DialogResult.Yes)
                return;

            var netice = await _bazaManager.RestoreEtAsync(restoreYolu);
            if (netice.UgurluDur)
            {
                _view.MesajGoster(
                    "Verilənlər bazası uğurla bərpa edildi!\n\n" +
                    "Proqram indi bağlanacaq. Yenidən açın.",
                    "Uğurlu Restore",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Proqramı bağlamaq view-ın məsuliyyətidir
                // Application.Exit();
            }
            else
            {
                _view.MesajGoster($"Restore xətası: {netice.Mesaj}", "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Restore əməliyyatı xətası");
            _view.XetaMesajiGoster("Restore əməliyyatında xəta baş verdi", "Restore Əməliyyatı");
        }
    }

    /// <summary>
    /// Backup faylını silir
    /// </summary>
    private void BackupSil()
    {
        try
        {
            var secilenFayl = _view.SecilenBackupYolu;

            if (string.IsNullOrEmpty(secilenFayl))
            {
                _view.MesajGoster("Silmək üçün backup faylı seçin!", "Xəbərdarlıq",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(secilenFayl))
            {
                _view.MesajGoster("Fayl tapılmadı!", "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var tesdiq = _view.TesdiqMesajiGoster(
                $"Bu backup faylını silmək istəyirsiniz?\n\n{Path.GetFileName(secilenFayl)}",
                "Backup Silmə");

            if (tesdiq == DialogResult.Yes)
            {
                File.Delete(secilenFayl);
                _view.UgurluMesajGoster("Backup faylı silindi!");
                _view.BackupFayllariniGoster();
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Backup silinərkən xəta");
            _view.XetaMesajiGoster("Backup faylı silinərkən xəta baş verdi", "Backup Silmə");
        }
    }

    /// <summary>
    /// Backup qovluğunu açır
    /// </summary>
    private void QovluguAc()
    {
        try
        {
            var appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var backupQovlugu = Path.Combine(appDirectory, "Backups");

            if (Directory.Exists(backupQovlugu))
            {
                System.Diagnostics.Process.Start("explorer.exe", backupQovlugu);
            }
            else
            {
                _view.MesajGoster("Backup qovluğu tapılmadı!", "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Qovluq açılarkən xəta");
            _view.XetaMesajiGoster("Qovluq açılarkən xəta baş verdi", "Qovluğu Açma");
        }
    }
}
