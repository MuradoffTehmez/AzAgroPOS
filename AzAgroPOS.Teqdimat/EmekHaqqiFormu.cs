// Fayl: AzAgroPOS.Teqdimat/EmekHaqqiFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Varliglar;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Əmək haqqı hesablama və idarəetmə forması.
/// Diqqət: Bu forma işçilərin əmək haqqını hesablamaq, ödəmək və tarixçəyə baxmaq üçündür.
/// </summary>
public partial class EmekHaqqiFormu : BazaForm
{
    private readonly EmekHaqqiManager _emekHaqqiManager;
    private readonly IsciManager _isciManager;

    public EmekHaqqiFormu(EmekHaqqiManager emekHaqqiManager, IsciManager isciManager)
    {
        InitializeComponent();
        _emekHaqqiManager = emekHaqqiManager ?? throw new ArgumentNullException(nameof(emekHaqqiManager));
        _isciManager = isciManager ?? throw new ArgumentNullException(nameof(isciManager));

        // Form yüklənəndə işçi siyahısını və tarixçəni yüklə
        this.Load += EmekHaqqiFormu_Load;
    }

    private void EmekHaqqiFormu_Load(object sender, EventArgs e)
    {
        _ = YukleAsync();
    }

    private async Task YukleAsync()
    {
        try
        {
            await IscileriYukle();
            await EmekHaqqiTarixcesiniYukle();

            // Dövr üçün hazırkı ayı təyin et
            dtpDovr.Value = DateTime.Now;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Forma yüklənərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

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
    /// Əmək haqqı tarixçəsini DataGridView-ə yüklə
    /// </summary>
    private async Task EmekHaqqiTarixcesiniYukle()
    {
        try
        {
            var netice = await _emekHaqqiManager.EmekHaqqilariGetirAsync();
            if (netice.UgurluDur && netice.Data != null)
            {
                dgvEmekHaqqlari.DataSource = netice.Data.ToList();
                FormatGrid();
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Əmək Haqqı Tarixçəsi");
        }
    }

    /// <summary>
    /// DataGridView sütunlarını formatla
    /// </summary>
    private void FormatGrid()
    {
        if (dgvEmekHaqqlari.Columns.Count == 0) return;

        dgvEmekHaqqlari.Columns["Id"].Visible = false;
        dgvEmekHaqqlari.Columns["IsciId"].Visible = false;

        dgvEmekHaqqlari.Columns["IsciAdi"].HeaderText = "İşçi";
        dgvEmekHaqqlari.Columns["Dovr"].HeaderText = "Dövr";
        dgvEmekHaqqlari.Columns["EsasMaas"].HeaderText = "Əsas Maaş";
        dgvEmekHaqqlari.Columns["EsasMaas"].DefaultCellStyle.Format = "N2";
        dgvEmekHaqqlari.Columns["Bonuslar"].HeaderText = "Bonuslar";
        dgvEmekHaqqlari.Columns["Bonuslar"].DefaultCellStyle.Format = "N2";
        dgvEmekHaqqlari.Columns["ElaveOdenisler"].HeaderText = "Əlavə Ödənişlər";
        dgvEmekHaqqlari.Columns["ElaveOdenisler"].DefaultCellStyle.Format = "N2";
        dgvEmekHaqqlari.Columns["IcazeTutulmasi"].HeaderText = "İcazə Tutulması";
        dgvEmekHaqqlari.Columns["IcazeTutulmasi"].DefaultCellStyle.Format = "N2";
        dgvEmekHaqqlari.Columns["DigerTutulmalar"].HeaderText = "Digər Tutulmalar";
        dgvEmekHaqqlari.Columns["DigerTutulmalar"].DefaultCellStyle.Format = "N2";
        dgvEmekHaqqlari.Columns["YekunEmekHaqqi"].HeaderText = "Yekun";
        dgvEmekHaqqlari.Columns["YekunEmekHaqqi"].DefaultCellStyle.Format = "N2";
        dgvEmekHaqqlari.Columns["Status"].HeaderText = "Status";
        dgvEmekHaqqlari.Columns["HesablanmaTarixi"].HeaderText = "Hesablama Tarixi";
        dgvEmekHaqqlari.Columns["HesablanmaTarixi"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
        dgvEmekHaqqlari.Columns["OdenmeTarixi"].HeaderText = "Ödəmə Tarixi";
        dgvEmekHaqqlari.Columns["OdenmeTarixi"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";

        dgvEmekHaqqlari.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    /// <summary>
    /// Əmək haqqını hesabla düyməsi
    /// </summary>
    private void btnHesabla_Click(object sender, EventArgs e)
    {
        if (cmbIsci.SelectedValue == null)
        {
            MessageBox.Show("Zəhmət olmasa işçi seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _ = HesablaAsync();
    }

    private async Task HesablaAsync()
    {
        try
        {
            var isciId = (int)cmbIsci.SelectedValue;
            var dovr = dtpDovr.Value.ToString("yyyy MMMM");
            var elaveOdenisler = numElaveOdenisler.Value;
            var digerTutulmalar = numDigerTutulmalar.Value;
            var qeyd = txtQeyd.Text;

            var netice = await _emekHaqqiManager.EmekHaqqiHesablaAsync(
                isciId,
                dovr,
                elaveOdenisler,
                digerTutulmalar,
                qeyd,
                AktivSessiya.AktivIstifadeci?.Id);

            if (netice.UgurluDur)
            {
                XetaGostergeci.UgurluMesajGoster("Əmək haqqı uğurla hesablandı!");
                await EmekHaqqiTarixcesiniYukle();
                FormuTemizle();
            }
            else
            {
                MessageBox.Show($"Xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Əmək Haqqı Hesablama");
        }
    }

    /// <summary>
    /// Ödə düyməsi - seçilmiş əmək haqqını ödə
    /// </summary>
    private void btnOde_Click(object sender, EventArgs e)
    {
        if (dgvEmekHaqqlari.SelectedRows.Count == 0)
        {
            MessageBox.Show("Zəhmət olmasa ödəniləcək əmək haqqını seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var emekHaqqiId = (int)dgvEmekHaqqlari.SelectedRows[0].Cells["Id"].Value;
        var status = dgvEmekHaqqlari.SelectedRows[0].Cells["Status"].Value.ToString();

        if (status == EmekHaqqiStatusu.Odenilmis.ToString())
        {
            MessageBox.Show("Bu əmək haqqı artıq ödənilib!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var tesdiq = MessageBox.Show(
            "Bu əmək haqqını ödəmək istəyirsiniz?",
            "Təsdiq",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (tesdiq != DialogResult.Yes) return;

        _ = OdeAsync(emekHaqqiId);
    }

    private async Task OdeAsync(int emekHaqqiId)
    {
        try
        {
            var netice = await _emekHaqqiManager.EmekHaqqiOdeAsync(emekHaqqiId, AktivSessiya.AktivIstifadeci?.Id);

            if (netice.UgurluDur)
            {
                XetaGostergeci.UgurluMesajGoster("Əmək haqqı uğurla ödənildi!");
                await EmekHaqqiTarixcesiniYukle();
            }
            else
            {
                MessageBox.Show($"Xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Əmək Haqqı Ödənişi");
        }
    }

    /// <summary>
    /// Ləğv et düyməsi
    /// </summary>
    private void btnLegvEt_Click(object sender, EventArgs e)
    {
        if (dgvEmekHaqqlari.SelectedRows.Count == 0)
        {
            MessageBox.Show("Zəhmət olmasa ləğv ediləcək əmək haqqını seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var emekHaqqiId = (int)dgvEmekHaqqlari.SelectedRows[0].Cells["Id"].Value;
        var status = dgvEmekHaqqlari.SelectedRows[0].Cells["Status"].Value.ToString();

        if (status == EmekHaqqiStatusu.Legv.ToString())
        {
            MessageBox.Show("Bu əmək haqqı artıq ləğv edilib!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var tesdiq = MessageBox.Show(
            "Bu əmək haqqını ləğv etmək istəyirsiniz?",
            "Təsdiq",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (tesdiq != DialogResult.Yes) return;

        _ = LegvEtAsync(emekHaqqiId);
    }

    private async Task LegvEtAsync(int emekHaqqiId)
    {
        try
        {
            var netice = await _emekHaqqiManager.EmekHaqqiLegvEtAsync(emekHaqqiId);

            if (netice.UgurluDur)
            {
                XetaGostergeci.UgurluMesajGoster("Əmək haqqı ləğv edildi!");
                await EmekHaqqiTarixcesiniYukle();
            }
            else
            {
                MessageBox.Show($"Xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Əmək Haqqı Ləğvi");
        }
    }

    /// <summary>
    /// Formu təmizlə
    /// </summary>
    private void FormuTemizle()
    {
        cmbIsci.SelectedIndex = -1;
        numElaveOdenisler.Value = 0;
        numDigerTutulmalar.Value = 0;
        txtQeyd.Clear();
    }

    /// <summary>
    /// Yenilə düyməsi
    /// </summary>
    private void btnYenile_Click(object sender, EventArgs e)
    {
        _ = EmekHaqqiTarixcesiniYukle();
    }

    /// <summary>
    /// İşçi seçildikdə onun son əmək haqqı məlumatlarını göstər
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
            var netice = await _emekHaqqiManager.EmekHaqqilariGetirAsync();

            if (netice.UgurluDur && netice.Data != null)
            {
                var isciEmekHaqqlari = netice.Data.Where(eh => eh.IsciId == isciId).ToList();
                if (isciEmekHaqqlari.Any())
                {
                    var sonEmekHaqqi = isciEmekHaqqlari.OrderByDescending(eh => eh.HesablanmaTarixi).First();
                    lblSonMaas.Text = $"Son Maaş: {sonEmekHaqqi.YekunEmekHaqqi:N2} AZN ({sonEmekHaqqi.Dovr})";
                }
                else
                {
                    lblSonMaas.Text = "Son Maaş: ---";
                }
            }
            else
            {
                lblSonMaas.Text = "Son Maaş: ---";
            }
        }
        catch
        {
            lblSonMaas.Text = "Son Maaş: ---";
        }
    }
}
