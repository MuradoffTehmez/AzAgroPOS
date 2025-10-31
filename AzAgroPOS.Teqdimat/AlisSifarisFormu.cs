// Fayl: AzAgroPOS.Teqdimat/AlisSifarisFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Varliglar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

/// <summary>
/// Alış sifarişi (Purchase Order) idarəetmə forması.
/// diqqət: Bu forma MVP pattern istifadə edir və IAlisSifarisView interfeysi implement edir.
/// </summary>
public partial class AlisSifarisFormu : BazaForm, IAlisSifarisView
{
    private AlisSifarisPresenter? _presenter;
    private List<AlisSifarisSetiriDto> _sifarisSetirleri = new List<AlisSifarisSetiriDto>();

    public AlisSifarisFormu(AlisManager alisManager, MehsulManager mehsulManager)
    {
        InitializeComponent();

        // Enum combo box-ları başlatırıq
        InitializeEnums();

        // Presenter-i başlatırıq
        _presenter = new AlisSifarisPresenter(this, alisManager, mehsulManager);

        // Form yüklənəndə hadisəni tetikləyirik
        this.Load += (s, e) => FormYuklendi?.Invoke(s, e);
    }

    private void InitializeEnums()
    {
        // Status enum-unu ComboBox-a yükləyirik
        cmbStatus.DataSource = Enum.GetValues(typeof(AlisSifarisStatusu));
        cmbStatus.SelectedIndex = 0;
    }

    #region IAlisSifarisView Implementation

    public int SifarisId { get; set; }

    public string SifarisNomresi
    {
        get => txtSifarisNomresi.Text;
        set => txtSifarisNomresi.Text = value;
    }

    public DateTime YaradilmaTarixi
    {
        get => dtpYaradilmaTarixi.Value;
        set => dtpYaradilmaTarixi.Value = value;
    }

    public DateTime? TesdiqTarixi
    {
        get => chkTesdiq.Checked ? dtpTesdiqTarixi.Value : (DateTime?)null;
        set
        {
            if (value.HasValue)
            {
                chkTesdiq.Checked = true;
                dtpTesdiqTarixi.Value = value.Value;
            }
            else
            {
                chkTesdiq.Checked = false;
            }
        }
    }

    public DateTime? GozlenilenTehvilTarixi
    {
        get => chkGozlenilenTehvil.Checked ? dtpGozlenilenTehvilTarixi.Value : (DateTime?)null;
        set
        {
            if (value.HasValue)
            {
                chkGozlenilenTehvil.Checked = true;
                dtpGozlenilenTehvilTarixi.Value = value.Value;
            }
            else
            {
                chkGozlenilenTehvil.Checked = false;
            }
        }
    }

    public int TedarukcuId
    {
        get => cmbTedarukcu.SelectedValue != null ? (int)cmbTedarukcu.SelectedValue : 0;
        set => cmbTedarukcu.SelectedValue = value;
    }

    public decimal UmumiMebleg
    {
        get => numUmumiMebleg.Value;
        set => numUmumiMebleg.Value = value;
    }

    public string? Qeydler
    {
        get => txtQeydler.Text;
        set => txtQeydler.Text = value ?? string.Empty;
    }

    public void TedarukculeriGoster(List<TedarukcuDto> tedarukculer)
    {
        cmbTedarukcu.DataSource = tedarukculer;
        cmbTedarukcu.DisplayMember = "Ad";
        cmbTedarukcu.ValueMember = "Id";
        cmbTedarukcu.SelectedIndex = -1;
    }

    public void SifarisleriGoster(List<AlisSifarisDto> sifarisler)
    {
        dgvSifarisler.DataSource = sifarisler;
        FormatSifarisGrid();
    }

    public void SifarisSetirleriniGoster(List<AlisSifarisSetiriDto> setirler)
    {
        _sifarisSetirleri = setirler;
        dgvSetirler.DataSource = _sifarisSetirleri;
        FormatSetirGrid();
        HesablaUmumiMebleg();
    }

    public void MehsullariGoster(List<MehsulDto> mehsullar)
    {
        cmbMehsul.DataSource = mehsullar;
        cmbMehsul.DisplayMember = "Ad";
        cmbMehsul.ValueMember = "Id";
        cmbMehsul.SelectedIndex = -1;
    }

    public void MesajGoster(string mesaj, bool xetadir = false)
    {
        if (xetadir)
        {
            MessageBox.Show(mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            MessageBox.Show(mesaj, "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public void FormuTemizle()
    {
        SifarisId = 0;
        txtSifarisNomresi.Clear();
        dtpYaradilmaTarixi.Value = DateTime.Now;
        chkTesdiq.Checked = false;
        chkGozlenilenTehvil.Checked = false;
        cmbTedarukcu.SelectedIndex = -1;
        numUmumiMebleg.Value = 0;
        cmbStatus.SelectedIndex = 0;
        txtQeydler.Clear();
        _sifarisSetirleri.Clear();
        dgvSetirler.DataSource = null;
        dgvSetirler.DataSource = _sifarisSetirleri;
    }

    public event EventHandler? FormYuklendi;
    public event EventHandler? SifarisYarat_Istek;
    public event EventHandler? SifarisYenile_Istek;
    public event EventHandler? SifarisSil_Istek;
    public event EventHandler? SifarisTesdiqle_Istek;
    public event EventHandler? FormuTemizle_Istek;

    #endregion

    #region Helper Methods

    private void FormatSifarisGrid()
    {
        if (dgvSifarisler.Columns.Count == 0) return;

        dgvSifarisler.Columns["Id"].Visible = false;
        dgvSifarisler.Columns["TedarukcuId"].Visible = false;
        dgvSifarisler.Columns["SifarisSetirleri"].Visible = false;

        dgvSifarisler.Columns["SifarisNomresi"].HeaderText = "Sifariş №";
        dgvSifarisler.Columns["TedarukcuAdi"].HeaderText = "Tədarükçü";
        dgvSifarisler.Columns["YaradilmaTarixi"].HeaderText = "Yaradılma Tarixi";
        dgvSifarisler.Columns["YaradilmaTarixi"].DefaultCellStyle.Format = "dd.MM.yyyy";
        dgvSifarisler.Columns["TesdiqTarixi"].HeaderText = "Təsdiq Tarixi";
        dgvSifarisler.Columns["TesdiqTarixi"].DefaultCellStyle.Format = "dd.MM.yyyy";
        dgvSifarisler.Columns["GozlenilenTehvilTarixi"].HeaderText = "Gözlənilən Təhvil";
        dgvSifarisler.Columns["GozlenilenTehvilTarixi"].DefaultCellStyle.Format = "dd.MM.yyyy";
        dgvSifarisler.Columns["FaktikiTehvilTarixi"].HeaderText = "Faktiki Təhvil";
        dgvSifarisler.Columns["FaktikiTehvilTarixi"].DefaultCellStyle.Format = "dd.MM.yyyy";
        dgvSifarisler.Columns["UmumiMebleg"].HeaderText = "Ümumi Məbləğ";
        dgvSifarisler.Columns["UmumiMebleg"].DefaultCellStyle.Format = "N2";
        dgvSifarisler.Columns["Status"].HeaderText = "Status";
        dgvSifarisler.Columns["Qeydler"].HeaderText = "Qeydlər";

        dgvSifarisler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void FormatSetirGrid()
    {
        if (dgvSetirler.Columns.Count == 0) return;

        dgvSetirler.Columns["Id"].Visible = false;
        dgvSetirler.Columns["AlisSifarisId"].Visible = false;
        dgvSetirler.Columns["MehsulId"].Visible = false;

        dgvSetirler.Columns["MehsulAdi"].HeaderText = "Məhsul";
        dgvSetirler.Columns["Miqdar"].HeaderText = "Miqdar";
        dgvSetirler.Columns["Miqdar"].DefaultCellStyle.Format = "N2";
        dgvSetirler.Columns["BirVahidQiymet"].HeaderText = "Vahid Qiymət";
        dgvSetirler.Columns["BirVahidQiymet"].DefaultCellStyle.Format = "N2";
        dgvSetirler.Columns["CemiMebleg"].HeaderText = "Cəmi";
        dgvSetirler.Columns["CemiMebleg"].DefaultCellStyle.Format = "N2";
        dgvSetirler.Columns["TehvilAlinanMiqdar"].HeaderText = "Təhvil Alınan";
        dgvSetirler.Columns["TehvilAlinanMiqdar"].DefaultCellStyle.Format = "N2";
        dgvSetirler.Columns["QalanMiqdar"].HeaderText = "Qalan";
        dgvSetirler.Columns["QalanMiqdar"].DefaultCellStyle.Format = "N2";

        dgvSetirler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void HesablaUmumiMebleg()
    {
        numUmumiMebleg.Value = _sifarisSetirleri.Sum(s => s.CemiMebleg);
    }

    #endregion

    #region Event Handlers

    private void btnYarat_Click(object sender, EventArgs e)
    {
        if (ValidateForm())
        {
            SifarisYarat_Istek?.Invoke(sender, e);
        }
    }

    private void btnYenile_Click(object sender, EventArgs e)
    {
        if (ValidateForm())
        {
            SifarisYenile_Istek?.Invoke(sender, e);
        }
    }

    private void btnSil_Click(object sender, EventArgs e)
    {
        if (SifarisId <= 0)
        {
            MessageBox.Show("Silmək üçün cədvəldən sifariş seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var tesdiq = MessageBox.Show(
            "Bu sifarişi silmək istəyirsiniz?",
            "Təsdiq",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (tesdiq == DialogResult.Yes)
        {
            SifarisSil_Istek?.Invoke(sender, e);
        }
    }

    private void btnTesdiqle_Click(object sender, EventArgs e)
    {
        if (SifarisId <= 0)
        {
            MessageBox.Show("Təsdiqləmək üçün cədvəldən sifariş seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var tesdiq = MessageBox.Show(
            "Bu sifarişi təsdiqləmək istəyirsiniz?",
            "Təsdiq",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (tesdiq == DialogResult.Yes)
        {
            SifarisTesdiqle_Istek?.Invoke(sender, e);
        }
    }

    private void btnTemizle_Click(object sender, EventArgs e)
    {
        FormuTemizle_Istek?.Invoke(sender, e);
    }

    private void dgvSifarisler_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvSifarisler.SelectedRows.Count == 0) return;

        var seciliSifaris = dgvSifarisler.SelectedRows[0].DataBoundItem as AlisSifarisDto;
        if (seciliSifaris == null) return;

        SifarisId = seciliSifaris.Id;
        txtSifarisNomresi.Text = seciliSifaris.SifarisNomresi;
        dtpYaradilmaTarixi.Value = seciliSifaris.YaradilmaTarixi;
        TesdiqTarixi = seciliSifaris.TesdiqTarixi;
        GozlenilenTehvilTarixi = seciliSifaris.GozlenilenTehvilTarixi;
        cmbTedarukcu.SelectedValue = seciliSifaris.TedarukcuId;
        numUmumiMebleg.Value = seciliSifaris.UmumiMebleg;
        cmbStatus.SelectedItem = seciliSifaris.Status;
        txtQeydler.Text = seciliSifaris.Qeydler ?? string.Empty;

        // Sifariş sətirlərini göstər
        SifarisSetirleriniGoster(seciliSifaris.SifarisSetirleri);
    }

    private void btnSetirElaveEt_Click(object sender, EventArgs e)
    {
        if (cmbMehsul.SelectedValue == null || (int)cmbMehsul.SelectedValue == 0)
        {
            MessageBox.Show("Məhsul seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (numMiqdar.Value <= 0)
        {
            MessageBox.Show("Miqdar 0-dan böyük olmalıdır!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (numBirVahidQiymet.Value <= 0)
        {
            MessageBox.Show("Vahid qiymət 0-dan böyük olmalıdır!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var mehsulId = (int)cmbMehsul.SelectedValue;
        var mehsulAdi = cmbMehsul.Text;
        var miqdar = numMiqdar.Value;
        var birVahidQiymet = numBirVahidQiymet.Value;
        var cemiMebleg = miqdar * birVahidQiymet;

        var setir = new AlisSifarisSetiriDto
        {
            MehsulId = mehsulId,
            MehsulAdi = mehsulAdi,
            Miqdar = miqdar,
            BirVahidQiymet = birVahidQiymet,
            CemiMebleg = cemiMebleg,
            TehvilAlinanMiqdar = 0,
            QalanMiqdar = miqdar
        };

        _sifarisSetirleri.Add(setir);
        dgvSetirler.DataSource = null;
        dgvSetirler.DataSource = _sifarisSetirleri;
        FormatSetirGrid();
        HesablaUmumiMebleg();

        // Sətir sahələrini təmizlə
        cmbMehsul.SelectedIndex = -1;
        numMiqdar.Value = 1;
        numBirVahidQiymet.Value = 0;
    }

    private void btnSetirSil_Click(object sender, EventArgs e)
    {
        if (dgvSetirler.SelectedRows.Count == 0)
        {
            MessageBox.Show("Silmək üçün sətir seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var seciliSetir = dgvSetirler.SelectedRows[0].DataBoundItem as AlisSifarisSetiriDto;
        if (seciliSetir != null)
        {
            _sifarisSetirleri.Remove(seciliSetir);
            dgvSetirler.DataSource = null;
            dgvSetirler.DataSource = _sifarisSetirleri;
            FormatSetirGrid();
            HesablaUmumiMebleg();
        }
    }

    private void chkTesdiq_CheckedChanged(object sender, EventArgs e)
    {
        dtpTesdiqTarixi.Enabled = chkTesdiq.Checked;
    }

    private void chkGozlenilenTehvil_CheckedChanged(object sender, EventArgs e)
    {
        dtpGozlenilenTehvilTarixi.Enabled = chkGozlenilenTehvil.Checked;
    }

    #endregion

    #region Validation

    private bool ValidateForm()
    {
        if (string.IsNullOrWhiteSpace(txtSifarisNomresi.Text))
        {
            MessageBox.Show("Sifariş nömrəsi daxil edin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSifarisNomresi.Focus();
            return false;
        }

        if (cmbTedarukcu.SelectedValue == null || (int)cmbTedarukcu.SelectedValue == 0)
        {
            MessageBox.Show("Tədarükçü seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cmbTedarukcu.Focus();
            return false;
        }

        if (_sifarisSetirleri.Count == 0)
        {
            MessageBox.Show("Sifariş sətirlərini əlavə edin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    #endregion
}
