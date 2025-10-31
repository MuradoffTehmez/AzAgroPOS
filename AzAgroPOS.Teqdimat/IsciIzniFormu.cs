// Fayl: AzAgroPOS.Teqdimat/IsciIzniFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Varliglar;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// İşçi izni idarəetmə forması.
/// Diqqət: Bu forma işçilərin məzuniyyət, xəstəlik icazəsi və digər izinlərini idarə edir.
/// </summary>
public partial class IsciIzniFormu : BazaForm
{
    private readonly IsciIzniManager _izniManager;
    private readonly IsciManager _isciManager;
    private int _seciliIzinId = 0;

    public IsciIzniFormu(IsciIzniManager izniManager, IsciManager isciManager)
    {
        InitializeComponent();
        _izniManager = izniManager ?? throw new ArgumentNullException(nameof(izniManager));
        _isciManager = isciManager ?? throw new ArgumentNullException(nameof(isciManager));

        // Form yüklənəndə məlumatları yüklə
        this.Load += IsciIzniFormu_Load;
    }

    private void IsciIzniFormu_Load(object sender, EventArgs e)
    {
        _ = YukleAsync();
    }

    private async Task YukleAsync()
    {
        try
        {
            InitializeEnums();
            await IscileriYukle();
            await IzinleriYukle();

            // Tarixləri təyin et
            dtpBaslamaTarixi.Value = DateTime.Now;
            dtpBitmeTarixi.Value = DateTime.Now.AddDays(1);
            HesablaIzinGunu();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Forma yüklənərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Enum ComboBox-larını başlatır
    /// </summary>
    private void InitializeEnums()
    {
        cmbIzinNovu.DataSource = Enum.GetValues(typeof(IzinNovu));
        cmbIzinNovu.SelectedIndex = 0;

        cmbStatusFiltre.Items.Add("Hamısı");
        cmbStatusFiltre.Items.AddRange(Enum.GetValues(typeof(IzinStatusu)).Cast<object>().ToArray());
        cmbStatusFiltre.SelectedIndex = 0;
    }

    #region İşçi və İzin Yükləmə

    /// <summary>
    /// Aktiv işçiləri ComboBox-a yüklə
    /// </summary>
    private async Task IscileriYukle()
    {
        try
        {
            var netice = await _isciManager.ButunIscileriGetirAsync();
            if (netice.UgurluDur && netice.Data != null)
            {
                var aktivIsciler = netice.Data.Where(i => i.Status == IsciStatusu.Aktiv).ToList();
                cmbIsci.DataSource = aktivIsciler;
                cmbIsci.DisplayMember = "TamAd";
                cmbIsci.ValueMember = "Id";
                cmbIsci.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show($"İşçi siyahısı yüklənərkən xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "İşçi Siyahısı");
        }
    }

    /// <summary>
    /// İzinləri DataGridView-ə yüklə
    /// </summary>
    private async Task IzinleriYukle()
    {
        try
        {
            var netice = await _izniManager.ButunIzinleriDtoFormatindaGetirAsync();
            if (netice.UgurluDur && netice.Data != null)
            {
                dgvIzinler.DataSource = netice.Data.ToList();
                FormatGrid();
            }
            else
            {
                MessageBox.Show($"İzinlər yüklənərkən xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "İzin Siyahısı");
        }
    }

    /// <summary>
    /// DataGridView sütunlarını formatla
    /// </summary>
    private void FormatGrid()
    {
        if (dgvIzinler.Columns.Count == 0) return;

        dgvIzinler.Columns["Id"].Visible = false;
        dgvIzinler.Columns["IsciId"].Visible = false;
        dgvIzinler.Columns["TesdiqEdenIsciId"].Visible = false;

        dgvIzinler.Columns["IsciAdi"].HeaderText = "İşçi";
        dgvIzinler.Columns["IzinNovu"].HeaderText = "İzin Növü";
        dgvIzinler.Columns["BaslamaTarixi"].HeaderText = "Başlama";
        dgvIzinler.Columns["BaslamaTarixi"].DefaultCellStyle.Format = "dd.MM.yyyy";
        dgvIzinler.Columns["BitmeTarixi"].HeaderText = "Bitmə";
        dgvIzinler.Columns["BitmeTarixi"].DefaultCellStyle.Format = "dd.MM.yyyy";
        dgvIzinler.Columns["IzinGunu"].HeaderText = "Gün";
        dgvIzinler.Columns["Sebeb"].HeaderText = "Səbəb";
        dgvIzinler.Columns["Status"].HeaderText = "Status";
        dgvIzinler.Columns["TesdiqEdenIsciAdi"].HeaderText = "Təsdiqləyən";
        dgvIzinler.Columns["TesdiqTarixi"].HeaderText = "Təsdiq Tarixi";
        dgvIzinler.Columns["TesdiqTarixi"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
        dgvIzinler.Columns["Qeydler"].HeaderText = "Qeydlər";

        dgvIzinler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    #endregion

    #region İzin Əməliyyatları

    /// <summary>
    /// İzin gününü hesabla
    /// </summary>
    private void HesablaIzinGunu()
    {
        var izinGunu = (dtpBitmeTarixi.Value.Date - dtpBaslamaTarixi.Value.Date).Days + 1;
        numIzinGunu.Value = izinGunu > 0 ? izinGunu : 0;
    }

    /// <summary>
    /// İzin yarat düyməsi
    /// </summary>
    private void btnYarat_Click(object sender, EventArgs e)
    {
        if (!ValidateForm())
        {
            return;
        }

        _ = YaratAsync();
    }

    private async Task YaratAsync()
    {
        try
        {
            var netice = await _izniManager.IzinYaratAsync(
                (int)cmbIsci.SelectedValue,
                (IzinNovu)cmbIzinNovu.SelectedItem,
                dtpBaslamaTarixi.Value,
                dtpBitmeTarixi.Value,
                txtSebeb.Text,
                txtQeydler.Text);

            if (netice.UgurluDur)
            {
                XetaGostergeci.UgurluMesajGoster("İzin uğurla yaradıldı!");
                await IzinleriYukle();
                FormuTemizle();
            }
            else
            {
                MessageBox.Show($"Xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "İzin Yaratma");
        }
    }

    /// <summary>
    /// İzin yenilə düyməsi
    /// </summary>
    private void btnYenile_Click(object sender, EventArgs e)
    {
        if (_seciliIzinId == 0)
        {
            MessageBox.Show("Zəhmət olmasa yeniləmək üçün izin seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!ValidateForm())
        {
            return;
        }

        _ = YenileAsync();
    }

    private async Task YenileAsync()
    {
        try
        {
            var netice = await _izniManager.IzinYenileAsync(
                _seciliIzinId,
                (IzinNovu)cmbIzinNovu.SelectedItem,
                dtpBaslamaTarixi.Value,
                dtpBitmeTarixi.Value,
                txtSebeb.Text,
                txtQeydler.Text);

            if (netice.UgurluDur)
            {
                XetaGostergeci.UgurluMesajGoster("İzin uğurla yeniləndi!");
                await IzinleriYukle();
                FormuTemizle();
            }
            else
            {
                MessageBox.Show($"Xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "İzin Yeniləmə");
        }
    }

    /// <summary>
    /// İzin sil düyməsi
    /// </summary>
    private void btnSil_Click(object sender, EventArgs e)
    {
        if (_seciliIzinId == 0)
        {
            MessageBox.Show("Zəhmət olmasa silmək üçün izin seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var tesdiq = MessageBox.Show(
            "Bu izni silmək istəyirsiniz?",
            "Təsdiq",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (tesdiq != DialogResult.Yes) return;

        _ = SilAsync();
    }

    private async Task SilAsync()
    {
        try
        {
            var netice = await _izniManager.IzinSilAsync(_seciliIzinId);

            if (netice.UgurluDur)
            {
                XetaGostergeci.UgurluMesajGoster("İzin uğurla silindi!");
                await IzinleriYukle();
                FormuTemizle();
            }
            else
            {
                MessageBox.Show($"Xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "İzin Silmə");
        }
    }

    /// <summary>
    /// İzni təsdiqlə düyməsi
    /// </summary>
    private void btnTesdiqle_Click(object sender, EventArgs e)
    {
        if (_seciliIzinId == 0)
        {
            MessageBox.Show("Zəhmət olmasa təsdiqləmək üçün izin seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var tesdiq = MessageBox.Show(
            "Bu izni təsdiqləmək istəyirsiniz?",
            "Təsdiq",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (tesdiq != DialogResult.Yes) return;

        _ = TesdiqleAsync();
    }

    private async Task TesdiqleAsync()
    {
        try
        {
            var netice = await _izniManager.IzinTesdiqleAsync(_seciliIzinId, AktivSessiya.AktivIstifadeci?.Id ?? 0);

            if (netice.UgurluDur)
            {
                XetaGostergeci.UgurluMesajGoster("İzin uğurla təsdiqləndi!");
                await IzinleriYukle();
                FormuTemizle();
            }
            else
            {
                MessageBox.Show($"Xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "İzin Təsdiqləmə");
        }
    }

    /// <summary>
    /// İzni rədd et düyməsi
    /// </summary>
    private void btnReddEt_Click(object sender, EventArgs e)
    {
        if (_seciliIzinId == 0)
        {
            MessageBox.Show("Zəhmət olmasa rədd etmək üçün izin seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Rədd səbəbini soruş
        var reddSebebi = Microsoft.VisualBasic.Interaction.InputBox(
            "Rədd səbəbini daxil edin:",
            "İzin Rəddi",
            "",
            -1,
            -1);

        if (string.IsNullOrWhiteSpace(reddSebebi))
        {
            MessageBox.Show("Rədd səbəbi daxil edilməlidir!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _ = ReddEtAsync(reddSebebi);
    }

    private async Task ReddEtAsync(string reddSebebi)
    {
        try
        {
            var netice = await _izniManager.IzinReddEtAsync(_seciliIzinId, AktivSessiya.AktivIstifadeci?.Id ?? 0, reddSebebi);

            if (netice.UgurluDur)
            {
                XetaGostergeci.UgurluMesajGoster("İzin rədd edildi!");
                await IzinleriYukle();
                FormuTemizle();
            }
            else
            {
                MessageBox.Show($"Xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "İzin Rəddi");
        }
    }

    /// <summary>
    /// İzni ləğv et düyməsi
    /// </summary>
    private void btnLegvEt_Click(object sender, EventArgs e)
    {
        if (_seciliIzinId == 0)
        {
            MessageBox.Show("Zəhmət olmasa ləğv etmək üçün izin seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var tesdiq = MessageBox.Show(
            "Bu izni ləğv etmək istəyirsiniz?",
            "Təsdiq",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (tesdiq != DialogResult.Yes) return;

        _ = LegvEtAsync();
    }

    private async Task LegvEtAsync()
    {
        try
        {
            var netice = await _izniManager.IzinLegvEtAsync(_seciliIzinId);

            if (netice.UgurluDur)
            {
                XetaGostergeci.UgurluMesajGoster("İzin ləğv edildi!");
                await IzinleriYukle();
                FormuTemizle();
            }
            else
            {
                MessageBox.Show($"Xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "İzin Ləğvi");
        }
    }

    #endregion

    #region Cədvəl Əməliyyatları

    /// <summary>
    /// İzinlər cədvəlində sətir seçildikdə
    /// </summary>
    private void dgvIzinler_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvIzinler.SelectedRows.Count == 0)
        {
            _seciliIzinId = 0;
            return;
        }

        try
        {
            var seciliIzin = dgvIzinler.SelectedRows[0];
            _seciliIzinId = (int)seciliIzin.Cells["Id"].Value;

            cmbIsci.SelectedValue = seciliIzin.Cells["IsciId"].Value;
            cmbIzinNovu.SelectedItem = seciliIzin.Cells["IzinNovu"].Value;
            dtpBaslamaTarixi.Value = (DateTime)seciliIzin.Cells["BaslamaTarixi"].Value;
            dtpBitmeTarixi.Value = (DateTime)seciliIzin.Cells["BitmeTarixi"].Value;
            numIzinGunu.Value = (int)seciliIzin.Cells["IzinGunu"].Value;
            txtSebeb.Text = seciliIzin.Cells["Sebeb"].Value?.ToString() ?? string.Empty;
            txtQeydler.Text = seciliIzin.Cells["Qeydler"].Value?.ToString() ?? string.Empty;

            // Status məlumatını göstər
            var status = (IzinStatusu)seciliIzin.Cells["Status"].Value;
            lblStatusMelumat.Text = $"Status: {status}";
            lblStatusMelumat.ForeColor = status switch
            {
                IzinStatusu.Tesdiqlenib => System.Drawing.Color.Green,
                IzinStatusu.Reddedilib => System.Drawing.Color.Red,
                IzinStatusu.LegvEdilib => System.Drawing.Color.Orange,
                _ => System.Drawing.Color.Blue
            };
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "İzin Seçimi");
        }
    }

    /// <summary>
    /// Status filtri dəyişdikdə
    /// </summary>
    private void cmbStatusFiltre_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbStatusFiltre.SelectedIndex == 0) // Hamısı
        {
            _ = IzinleriYukle();
        }
        else
        {
            _ = FiltreAsync();
        }
    }

    private async Task FiltreAsync()
    {
        try
        {
            var status = (IzinStatusu)cmbStatusFiltre.SelectedItem;
            var netice = await _izniManager.StatusaGoreGetirAsync(status);

            if (netice.UgurluDur && netice.Data != null)
            {
                dgvIzinler.DataSource = netice.Data.ToList();
                FormatGrid();
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Filtrələmə");
        }
    }

    /// <summary>
    /// İşçi seçildikdə onun izinlərini göstər
    /// </summary>
    private void cmbIsci_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbIsci.SelectedValue == null) return;

        _ = IsciSecildiAsync();
    }

    private async Task IsciSecildiAsync()
    {
        try
        {
            var isciId = (int)cmbIsci.SelectedValue;
            var netice = await _izniManager.IsciUcunIzinleriGetirAsync(isciId);

            if (netice.UgurluDur && netice.Data != null)
            {
                var tesdiqlenibIzinler = netice.Data.Where(i => i.Status == IzinStatusu.Tesdiqlenib).ToList();
                var cemiGun = tesdiqlenibIzinler.Sum(i => i.IzinGunu);
                lblIsciIzinMelumati.Text = $"Təsdiqlənmiş izin günləri: {cemiGun}";
            }
        }
        catch
        {
            lblIsciIzinMelumati.Text = "İzin məlumatı: ---";
        }
    }

    #endregion

    #region Köməkçi Metodlar

    /// <summary>
    /// Tarix dəyişiklikləri
    /// </summary>
    private void dtpBaslamaTarixi_ValueChanged(object sender, EventArgs e)
    {
        HesablaIzinGunu();
    }

    private void dtpBitmeTarixi_ValueChanged(object sender, EventArgs e)
    {
        HesablaIzinGunu();
    }

    /// <summary>
    /// Formu təmizlə düyməsi
    /// </summary>
    private void btnTemizle_Click(object sender, EventArgs e)
    {
        FormuTemizle();
    }

    /// <summary>
    /// Formu təmizlə
    /// </summary>
    private void FormuTemizle()
    {
        _seciliIzinId = 0;
        cmbIsci.SelectedIndex = -1;
        cmbIzinNovu.SelectedIndex = 0;
        dtpBaslamaTarixi.Value = DateTime.Now;
        dtpBitmeTarixi.Value = DateTime.Now.AddDays(1);
        numIzinGunu.Value = 1;
        txtSebeb.Clear();
        txtQeydler.Clear();
        lblStatusMelumat.Text = "Status: ---";
        lblStatusMelumat.ForeColor = System.Drawing.Color.Black;
        lblIsciIzinMelumati.Text = "İzin məlumatı: ---";
    }

    /// <summary>
    /// Form validasiyası
    /// </summary>
    private bool ValidateForm()
    {
        if (cmbIsci.SelectedValue == null)
        {
            MessageBox.Show("İşçi seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cmbIsci.Focus();
            return false;
        }

        if (dtpBaslamaTarixi.Value >= dtpBitmeTarixi.Value)
        {
            MessageBox.Show("Başlama tarixi bitmə tarixindən kiçik olmalıdır!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtpBaslamaTarixi.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtSebeb.Text))
        {
            MessageBox.Show("İzin səbəbi daxil edin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSebeb.Focus();
            return false;
        }

        return true;
    }

    /// <summary>
    /// Bütün izinləri yenilə düyməsi
    /// </summary>
    private void btnYenileHamisi_Click(object sender, EventArgs e)
    {
        _ = YenileHamisiAsync();
    }

    private async Task YenileHamisiAsync()
    {
        try
        {
            await IzinleriYukle();
            FormuTemizle();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"İzinlər yenilənərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    #endregion
}
