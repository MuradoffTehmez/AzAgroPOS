// Fayl: AzAgroPOS.Teqdimat/BazaIdareetmeFormu.cs
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using System;
using System.IO;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat
{
    /// <summary>
    /// Verilənlər bazası backup və restore əməliyyatlarını idarə edən form.
    /// DİQQƏT: Bu forma yalnız Admin icazəsi olan istifadəçilər daxil ola bilər!
    /// </summary>
    public partial class BazaIdareetmeFormu : BazaForm
    {
        private readonly BazaIdareetmeManager _bazaManager;
        private readonly string _standartBackupQovlugu;

        public BazaIdareetmeFormu(BazaIdareetmeManager bazaManager)
        {
            InitializeComponent();
            _bazaManager = bazaManager ?? throw new ArgumentNullException(nameof(bazaManager));

            // Standart backup qovluğu tətbiqatın yanında "Backups" qovluğu olacaq
            var appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _standartBackupQovlugu = Path.Combine(appDirectory, "Backups");

            // Qovluğun mövcudluğunu təmin edirik
            if (!Directory.Exists(_standartBackupQovlugu))
            {
                Directory.CreateDirectory(_standartBackupQovlugu);
            }
        }

        private async void BazaIdareetmeFormu_Load(object sender, EventArgs e)
        {
            await MəlumatlarıYenilə();
        }

        private async Task MəlumatlarıYenilə()
        {
            try
            {
                // Verilənlər bazası ölçüsünü göstəririk
                var ölçüNetice = await _bazaManager.BazaOlcusunuGetirAsync();
                if (ölçüNetice.UgurluDur)
                {
                    lblBazaOlcusu.Text = $"Verilənlər Bazası Ölçüsü: {ölçüNetice.Data:N2} MB";
                }

                // Son backup tarixini göstəririk
                var sonBackupNetice = await _bazaManager.SonBackupTarixiniGetirAsync();
                if (sonBackupNetice.UgurluDur)
                {
                    if (sonBackupNetice.Data.HasValue)
                    {
                        lblSonBackup.Text = $"Son Backup: {sonBackupNetice.Data.Value:dd.MM.yyyy HH:mm}";
                        lblSonBackup.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblSonBackup.Text = "Son Backup: Heç backup edilməyib";
                        lblSonBackup.ForeColor = System.Drawing.Color.Red;
                    }
                }

                // Backup qovluğundakı faylları siyahıya salırıq
                BackupFayllariniYukle();
            }
            catch (Exception ex)
            {
                XetaGostergeci.UmumiXetaGoster(ex, "Verilənlər Bazası İdarəetmə");
            }
        }

        private void BackupFayllariniYukle()
        {
            try
            {
                lstBackuplar.Items.Clear();

                if (Directory.Exists(_standartBackupQovlugu))
                {
                    var backupFaylları = Directory.GetFiles(_standartBackupQovlugu, "*.bak");
                    Array.Sort(backupFaylları); // Əlifba sırasına görə
                    Array.Reverse(backupFaylları); // Ən yeni əvvəldə

                    foreach (var fayl in backupFaylları)
                    {
                        var faylInfo = new FileInfo(fayl);
                        var faylAdı = Path.GetFileName(fayl);
                        var faylÖlçüsü = faylInfo.Length / 1024.0 / 1024.0; // MB-da
                        var tarixi = faylInfo.LastWriteTime;

                        var item = new ListViewItem(faylAdı);
                        item.SubItems.Add($"{faylÖlçüsü:N2} MB");
                        item.SubItems.Add(tarixi.ToString("dd.MM.yyyy HH:mm"));
                        item.Tag = fayl; // Tam yolu Tag-də saxlayırıq

                        lstBackuplar.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                XetaGostergeci.UmumiXetaGoster(ex, "Backup Faylları");
            }
        }

        private async void btnBackupYarat_Click(object sender, EventArgs e)
        {
            try
            {
                // İstifadəçidən təsdiq alırıq
                var təsdiq = MessageBox.Show(
                    "Verilənlər bazasının ehtiyat nüsxəsini yaratmaq istəyirsiniz?\n\n" +
                    "Bu əməliyyat bir neçə dəqiqə çəkə bilər.",
                    "Backup Yaratma",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (təsdiq != DialogResult.Yes)
                    return;

                // SaveFileDialog göstəririk
                using var saveDialog = new SaveFileDialog
                {
                    Filter = "Backup Faylları (*.bak)|*.bak",
                    DefaultExt = "bak",
                    InitialDirectory = _standartBackupQovlugu,
                    FileName = BazaIdareetmeManager.StandartBackupAdiYarat(_standartBackupQovlugu)
                };

                if (saveDialog.ShowDialog() != DialogResult.OK)
                    return;

                var backupYolu = saveDialog.FileName;

                // Yükləmə göstəricisi ilə backup yaradırıq
                await YuklemeGostergeci.GosterVeIcraEtAsync(
                    this,
                    "Backup yaradılır...",
                    async () =>
                    {
                        var nəticə = await _bazaManager.BackupYaratAsync(backupYolu);
                        if (!nəticə.UgurluDur)
                        {
                            throw new Exception(nəticə.Mesaj);
                        }
                    });

                XetaGostergeci.UgurluMesajGoster("Backup uğurla yaradıldı!");
                await MəlumatlarıYenilə();
            }
            catch (Exception ex)
            {
                XetaGostergeci.UmumiXetaGoster(ex, "Backup Yaratma");
            }
        }

        private async void btnRestoreEt_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçilmiş backup faylını yoxlayırıq
                string? restoreYolu = null;

                if (lstBackuplar.SelectedItems.Count > 0)
                {
                    restoreYolu = lstBackuplar.SelectedItems[0].Tag as string;
                }
                else
                {
                    // Əgər seçim yoxdursa, OpenFileDialog göstəririk
                    using var openDialog = new OpenFileDialog
                    {
                        Filter = "Backup Faylları (*.bak)|*.bak",
                        InitialDirectory = _standartBackupQovlugu,
                        Title = "Bərpa ediləcək backup faylını seçin"
                    };

                    if (openDialog.ShowDialog() != DialogResult.OK)
                        return;

                    restoreYolu = openDialog.FileName;
                }

                if (string.IsNullOrEmpty(restoreYolu) || !File.Exists(restoreYolu))
                {
                    MessageBox.Show("Backup faylı tapılmadı!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Çox ciddi xəbərdarlıq!
                var xəbərdarlıq = MessageBox.Show(
                    "⚠️ DİQQƏT! ⚠️\n\n" +
                    "Bu əməliyyat mövcud verilənlər bazasını SİLƏCƏK və seçilmiş " +
                    "backup ilə ƏVƏZ EDƏCƏK!\n\n" +
                    "Bütün hazırkı məlumatlar itiriləcək!\n\n" +
                    "Davam etmək istəyirsiniz?",
                    "Çox Təhlükəli Əməliyyat",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (xəbərdarlıq != DialogResult.Yes)
                    return;

                // İkinci təsdiq
                var ikinciTəsdiq = MessageBox.Show(
                    "Son dəfə soruşuruq:\n\n" +
                    "Həqiqətən restore etmək istəyirsiniz?\n\n" +
                    "Proqram bağlanacaq və yenidən açmalısınız!",
                    "Son Təsdiq",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Stop);

                if (ikinciTəsdiq != DialogResult.Yes)
                    return;

                // Restore əməliyyatı
                await YuklemeGostergeci.GosterVeIcraEtAsync(
                    this,
                    "Verilənlər bazası bərpa edilir...\nBu, bir neçə dəqiqə çəkə bilər...",
                    async () =>
                    {
                        var nəticə = await _bazaManager.RestoreEtAsync(restoreYolu);
                        if (!nəticə.UgurluDur)
                        {
                            throw new Exception(nəticə.Mesaj);
                        }
                    });

                MessageBox.Show(
                    "Verilənlər bazası uğurla bərpa edildi!\n\n" +
                    "Proqram indi bağlanacaq. Yenidən açın.",
                    "Uğurlu Restore",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Proqramı bağlayırıq
                Application.Exit();
            }
            catch (Exception ex)
            {
                XetaGostergeci.UmumiXetaGoster(ex, "Restore Əməliyyatı");
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            _ = MəlumatlarıYenilə();
        }

        private void btnQovluguAc_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(_standartBackupQovlugu))
                {
                    System.Diagnostics.Process.Start("explorer.exe", _standartBackupQovlugu);
                }
            }
            catch (Exception ex)
            {
                XetaGostergeci.UmumiXetaGoster(ex, "Qovluğu Açma");
            }
        }

        private void btnBackupSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstBackuplar.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Silmək üçün backup faylı seçin!", "Xəbərdarlıq",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var seçilmişFayl = lstBackuplar.SelectedItems[0].Tag as string;
                if (string.IsNullOrEmpty(seçilmişFayl) || !File.Exists(seçilmişFayl))
                {
                    MessageBox.Show("Fayl tapılmadı!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var təsdiq = MessageBox.Show(
                    $"Bu backup faylını silmək istəyirsiniz?\n\n{Path.GetFileName(seçilmişFayl)}",
                    "Backup Silmə",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (təsdiq == DialogResult.Yes)
                {
                    File.Delete(seçilmişFayl);
                    XetaGostergeci.UgurluMesajGoster("Backup faylı silindi!");
                    BackupFayllariniYukle();
                }
            }
            catch (Exception ex)
            {
                XetaGostergeci.UmumiXetaGoster(ex, "Backup Silmə");
            }
        }
    }
}
