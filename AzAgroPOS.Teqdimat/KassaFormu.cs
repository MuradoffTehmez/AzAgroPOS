// Fayl: AzAgroPOS.Teqdimat/KassaFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Varliglar;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Mərkəzi kassa və maliyyə idarəetmə forması.
/// Diqqət: Bu forma xərcləri, kassa hərəkətlərini və maliyyə hesabatlarını idarə edir.
/// </summary>
public partial class KassaFormu : BazaForm
{
    private readonly MaliyyeManager _maliyyeManager;
    private int _seciliXercId = 0;

    public KassaFormu(MaliyyeManager maliyyeManager)
    {
        InitializeComponent();
        _maliyyeManager = maliyyeManager ?? throw new ArgumentNullException(nameof(maliyyeManager));

        // Form yüklənəndə məlumatları yüklə
        this.Load += KassaFormu_Load;
    }

    private async void KassaFormu_Load(object sender, EventArgs e)
    {
        InitializeEnums();
        await XercleriYukle();
        await KassaHareketleriniYukle();
        await MaliyyeXulasesiniYukle();

        // Tarix aralığını cari ay üçün təyin et
        dtpBaslangic.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        dtpBitis.Value = DateTime.Now;

        dtpXesabatBaslangic.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        dtpXesabatBitis.Value = DateTime.Now;
    }

    /// <summary>
    /// Enum ComboBox-larını başlatır
    /// </summary>
    private void InitializeEnums()
    {
        cmbXercNovu.DataSource = Enum.GetValues(typeof(XercNovu));
        cmbXercNovu.SelectedIndex = 0;
    }

    #region Xərc İdarəetməsi

    /// <summary>
    /// Xərcləri DataGridView-ə yüklə
    /// </summary>
    private async Task XercleriYukle()
    {
        try
        {
            var netice = await _maliyyeManager.ButunXercleriDtoFormatindaGetirAsync();
            if (netice.UgurluDur && netice.Data != null)
            {
                dgvXercler.DataSource = netice.Data.ToList();
                FormatXerclerGrid();
            }
            else
            {
                MessageBox.Show($"Xərclər yüklənərkən xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Xərclər Siyahısı");
        }
    }

    /// <summary>
    /// Xərclər DataGridView-ni formatla
    /// </summary>
    private void FormatXerclerGrid()
    {
        if (dgvXercler.Columns.Count == 0) return;

        dgvXercler.Columns["Id"].Visible = false;
        dgvXercler.Columns["IstifadeciId"].Visible = false;

        dgvXercler.Columns["Novu"].HeaderText = "Növ";
        dgvXercler.Columns["Ad"].HeaderText = "Ad";
        dgvXercler.Columns["Mebleg"].HeaderText = "Məbləğ";
        dgvXercler.Columns["Mebleg"].DefaultCellStyle.Format = "N2";
        dgvXercler.Columns["Tarix"].HeaderText = "Tarix";
        dgvXercler.Columns["Tarix"].DefaultCellStyle.Format = "dd.MM.yyyy";
        dgvXercler.Columns["SenedNomresi"].HeaderText = "Sənəd №";
        dgvXercler.Columns["Qeyd"].HeaderText = "Qeyd";
        dgvXercler.Columns["IstifadeciAdi"].HeaderText = "İstifadəçi";

        dgvXercler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    /// <summary>
    /// Xərc yarat düyməsi
    /// </summary>
    private async void btnXercYarat_Click(object sender, EventArgs e)
    {
        if (!ValidateXercForm())
        {
            return;
        }

        try
        {
            var netice = await _maliyyeManager.XercYaratAsync(
                (XercNovu)cmbXercNovu.SelectedItem,
                txtXercAd.Text,
                numXercMebleg.Value,
                dtpXercTarix.Value,
                txtSenedNomresi.Text,
                txtXercQeyd.Text,
                AktivSessiya.AktivIstifadeci?.Id);

            if (netice.UgurluDur)
            {
                XetaGostergeci.UgurluMesajGoster("Xərc uğurla yaradıldı!");
                await XercleriYukle();
                await KassaHareketleriniYukle();
                await MaliyyeXulasesiniYukle();
                XercFormuTemizle();
            }
            else
            {
                MessageBox.Show($"Xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Xərc Yaratma");
        }
    }

    /// <summary>
    /// Xərc yenilə düyməsi
    /// </summary>
    private async void btnXercYenile_Click(object sender, EventArgs e)
    {
        if (_seciliXercId == 0)
        {
            MessageBox.Show("Zəhmət olmasa yeniləmək üçün xərc seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!ValidateXercForm())
        {
            return;
        }

        try
        {
            var netice = await _maliyyeManager.XercYenileAsync(
                _seciliXercId,
                (XercNovu)cmbXercNovu.SelectedItem,
                txtXercAd.Text,
                numXercMebleg.Value,
                dtpXercTarix.Value,
                txtSenedNomresi.Text,
                txtXercQeyd.Text,
                AktivSessiya.AktivIstifadeci?.Id);

            if (netice.UgurluDur)
            {
                XetaGostergeci.UgurluMesajGoster("Xərc uğurla yeniləndi!");
                await XercleriYukle();
                await KassaHareketleriniYukle();
                await MaliyyeXulasesiniYukle();
                XercFormuTemizle();
            }
            else
            {
                MessageBox.Show($"Xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Xərc Yeniləmə");
        }
    }

    /// <summary>
    /// Xərc sil düyməsi
    /// </summary>
    private async void btnXercSil_Click(object sender, EventArgs e)
    {
        if (_seciliXercId == 0)
        {
            MessageBox.Show("Zəhmət olmasa silmək üçün xərc seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var tesdiq = MessageBox.Show(
            "Bu xərci silmək istəyirsiniz?",
            "Təsdiq",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (tesdiq != DialogResult.Yes) return;

        try
        {
            var netice = await _maliyyeManager.XercSilAsync(_seciliXercId);

            if (netice.UgurluDur)
            {
                XetaGostergeci.UgurluMesajGoster("Xərc uğurla silindi!");
                await XercleriYukle();
                await KassaHareketleriniYukle();
                await MaliyyeXulasesiniYukle();
                XercFormuTemizle();
            }
            else
            {
                MessageBox.Show($"Xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Xərc Silmə");
        }
    }

    /// <summary>
    /// Xərclər cədvəlində sətir seçildikdə
    /// </summary>
    private void dgvXercler_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvXercler.SelectedRows.Count == 0)
        {
            _seciliXercId = 0;
            return;
        }

        try
        {
            var seciliXerc = dgvXercler.SelectedRows[0];
            _seciliXercId = (int)seciliXerc.Cells["Id"].Value;

            cmbXercNovu.SelectedItem = seciliXerc.Cells["Novu"].Value;
            txtXercAd.Text = seciliXerc.Cells["Ad"].Value?.ToString() ?? string.Empty;
            numXercMebleg.Value = (decimal)seciliXerc.Cells["Mebleg"].Value;
            dtpXercTarix.Value = (DateTime)seciliXerc.Cells["Tarix"].Value;
            txtSenedNomresi.Text = seciliXerc.Cells["SenedNomresi"].Value?.ToString() ?? string.Empty;
            txtXercQeyd.Text = seciliXerc.Cells["Qeyd"].Value?.ToString() ?? string.Empty;
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Xərc Seçimi");
        }
    }

    /// <summary>
    /// Xərc formu təmizlə düyməsi
    /// </summary>
    private void btnXercTemizle_Click(object sender, EventArgs e)
    {
        XercFormuTemizle();
    }

    /// <summary>
    /// Xərc formunu təmizlə
    /// </summary>
    private void XercFormuTemizle()
    {
        _seciliXercId = 0;
        cmbXercNovu.SelectedIndex = 0;
        txtXercAd.Clear();
        numXercMebleg.Value = 0;
        dtpXercTarix.Value = DateTime.Now;
        txtSenedNomresi.Clear();
        txtXercQeyd.Clear();
    }

    /// <summary>
    /// Xərc formu validasiyası
    /// </summary>
    private bool ValidateXercForm()
    {
        if (string.IsNullOrWhiteSpace(txtXercAd.Text))
        {
            MessageBox.Show("Xərc adı daxil edin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtXercAd.Focus();
            return false;
        }

        if (numXercMebleg.Value <= 0)
        {
            MessageBox.Show("Xərc məbləği 0-dan böyük olmalıdır!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            numXercMebleg.Focus();
            return false;
        }

        return true;
    }

    #endregion

    #region Kassa Hərəkətləri

    /// <summary>
    /// Kassa hərəkətlərini DataGridView-ə yüklə
    /// </summary>
    private async Task KassaHareketleriniYukle()
    {
        try
        {
            var netice = await _maliyyeManager.KassaHareketleriniGetirAsync(
                dtpBaslangic.Value.Date,
                dtpBitis.Value.Date);

            if (netice.UgurluDur && netice.Data != null)
            {
                dgvKassaHareketleri.DataSource = netice.Data.ToList();
                FormatKassaHareketleriGrid();
            }
            else
            {
                MessageBox.Show($"Kassa hərəkətləri yüklənərkən xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Kassa Hərəkətləri");
        }
    }

    /// <summary>
    /// Kassa hərəkətləri DataGridView-ni formatla
    /// </summary>
    private void FormatKassaHareketleriGrid()
    {
        if (dgvKassaHareketleri.Columns.Count == 0) return;

        dgvKassaHareketleri.Columns["Id"].Visible = false;
        dgvKassaHareketleri.Columns["EmeliyyatId"].Visible = false;
        dgvKassaHareketleri.Columns["IstifadeciId"].Visible = false;

        dgvKassaHareketleri.Columns["HareketNovu"].HeaderText = "Hərəkət Növü";
        dgvKassaHareketleri.Columns["EmeliyyatNovu"].HeaderText = "Əməliyyat";
        dgvKassaHareketleri.Columns["Mebleg"].HeaderText = "Məbləğ";
        dgvKassaHareketleri.Columns["Mebleg"].DefaultCellStyle.Format = "N2";
        dgvKassaHareketleri.Columns["Tarix"].HeaderText = "Tarix";
        dgvKassaHareketleri.Columns["Tarix"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
        dgvKassaHareketleri.Columns["Qeyd"].HeaderText = "Qeyd";

        // Hərəkət növünə görə rəng
        foreach (DataGridViewRow row in dgvKassaHareketleri.Rows)
        {
            if (row.Cells["HareketNovu"].Value != null)
            {
                var hareketNovu = (KassaHareketiNovu)row.Cells["HareketNovu"].Value;
                if (hareketNovu == KassaHareketiNovu.Daxilolma)
                {
                    row.DefaultCellStyle.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        dgvKassaHareketleri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    /// <summary>
    /// Kassa hərəkətlərini filtrələ düyməsi
    /// </summary>
    private async void btnFiltrele_Click(object sender, EventArgs e)
    {
        await KassaHareketleriniYukle();
    }

    #endregion

    #region Maliyyə Xülasəsi

    /// <summary>
    /// Maliyyə xülasəsini hesabla və göstər
    /// </summary>
    private async Task MaliyyeXulasesiniYukle()
    {
        try
        {
            var baslangic = dtpXesabatBaslangic.Value.Date;
            var bitis = dtpXesabatBitis.Value.Date;

            // Gəlirləri hesabla
            var kassaHareketleriNetice = await _maliyyeManager.KassaHareketleriniGetirAsync(baslangic, bitis);
            if (kassaHareketleriNetice.UgurluDur && kassaHareketleriNetice.Data != null)
            {
                var gelirler = kassaHareketleriNetice.Data
                    .Where(k => k.HareketNovu == KassaHareketiNovu.Daxilolma)
                    .Sum(k => k.Mebleg);

                lblUmumiGelir.Text = $"Ümumi Gəlir: {gelirler:N2} AZN";
            }

            // Xərcləri hesabla
            var xercCemiNetice = await _maliyyeManager.XercCeminiHesablaAsync(baslangic, bitis);
            if (xercCemiNetice.UgurluDur)
            {
                lblUmumiXerc.Text = $"Ümumi Xərc: {xercCemiNetice.Data:N2} AZN";
            }

            // Mənfəət/Zərəri hesabla
            var menfeetNetice = await _maliyyeManager.MenfeetZerereHesablaAsync(baslangic, bitis);
            if (menfeetNetice.UgurluDur)
            {
                var menfeet = menfeetNetice.Data;
                lblMenfeetZerere.Text = menfeet >= 0
                    ? $"Mənfəət: {menfeet:N2} AZN"
                    : $"Zərər: {Math.Abs(menfeet):N2} AZN";

                lblMenfeetZerere.ForeColor = menfeet >= 0
                    ? System.Drawing.Color.Green
                    : System.Drawing.Color.Red;
            }

            // Cari kassa balansını hesabla (bütün tarixlər üçün)
            var butunHareketlerNetice = await _maliyyeManager.KassaHareketleriniGetirAsync();
            if (butunHareketlerNetice.UgurluDur && butunHareketlerNetice.Data != null)
            {
                var gelirlerCem = butunHareketlerNetice.Data
                    .Where(k => k.HareketNovu == KassaHareketiNovu.Daxilolma)
                    .Sum(k => k.Mebleg);

                var xerclerCem = butunHareketlerNetice.Data
                    .Where(k => k.HareketNovu == KassaHareketiNovu.Cixis)
                    .Sum(k => k.Mebleg);

                var balans = gelirlerCem - xerclerCem;
                lblCariBalans.Text = $"Cari Balans: {balans:N2} AZN";
                lblCariBalans.ForeColor = balans >= 0
                    ? System.Drawing.Color.Green
                    : System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Maliyyə Xülasəsi");
        }
    }

    /// <summary>
    /// Maliyyə hesabatı göstər düyməsi
    /// </summary>
    private async void btnHesabatGoster_Click(object sender, EventArgs e)
    {
        await MaliyyeXulasesiniYukle();
    }

    #endregion

    /// <summary>
    /// Yenilə düyməsi - bütün məlumatları yenidən yüklə
    /// </summary>
    private async void btnYenile_Click(object sender, EventArgs e)
    {
        await XercleriYukle();
        await KassaHareketleriniYukle();
        await MaliyyeXulasesiniYukle();
    }
}
