// Fayl: AzAgroPOS.Teqdimat/AlisSifarisFormu.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Teqdimat;
/// <summary>
/// Alış sifarişi (Purchase Order) idarəetmə forması.
/// diqqət: Bu forma MVP pattern istifadə edir və IAlisSifarisView interfeysi implement edir.
/// </summary>
public partial class AlisSifarisFormu : BazaForm, IAlisSifarisView
{
    private AlisSifarisPresenter? _presenter;
    private System.ComponentModel.BindingList<AlisSifarisSetiriDto> _sifarisSetirleri = new();

    public AlisSifarisFormu(AlisManager alisManager, MehsulManager mehsulManager)
    {
        InitializeComponent();

        // Enum combo box-ları başlatırıq
        InitializeEnums();

        // Presenter-i başlatırıq
        _presenter = new AlisSifarisPresenter(this, alisManager, mehsulManager);

        // Form yüklənəndə hadisəni tetikləyirik
        Load += (s, e) => FormYuklendi?.Invoke(s, e);
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
        get => chkTesdiq.Checked ? dtpTesdiqTarixi.Value : null;
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
        get => chkGozlenilenTehvil.Checked ? dtpGozlenilenTehvilTarixi.Value : null;
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
        FormatSifarisGrid();
        dgvSifarisler.DataSource = new System.ComponentModel.BindingList<AlisSifarisDto>(sifarisler);
    }

    public void SifarisSetirleriniGoster(List<AlisSifarisSetiriDto> setirler)
    {
        _sifarisSetirleri = new System.ComponentModel.BindingList<AlisSifarisSetiriDto>(setirler);
        FormatSetirGrid();
        dgvSetirler.DataSource = _sifarisSetirleri;
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
        if (dgvSifarisler.Columns.Count > 0) return;

        dgvSifarisler.AutoGenerateColumns = false;
        
        dgvSifarisler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
        dgvSifarisler.Columns.Add(new DataGridViewTextBoxColumn { Name = "SifarisNomresi", DataPropertyName = "SifarisNomresi", HeaderText = "Sifariş №" });
        dgvSifarisler.Columns.Add(new DataGridViewTextBoxColumn { Name = "TedarukcuAdi", DataPropertyName = "TedarukcuAdi", HeaderText = "Tədarükçü" });
        
        var dateCol1 = new DataGridViewTextBoxColumn { Name = "YaradilmaTarixi", DataPropertyName = "YaradilmaTarixi", HeaderText = "Yaradılma Tarixi" };
        dateCol1.DefaultCellStyle.Format = "dd.MM.yyyy";
        dgvSifarisler.Columns.Add(dateCol1);
        
        var dateCol2 = new DataGridViewTextBoxColumn { Name = "TesdiqTarixi", DataPropertyName = "TesdiqTarixi", HeaderText = "Təsdiq Tarixi" };
        dateCol2.DefaultCellStyle.Format = "dd.MM.yyyy";
        dgvSifarisler.Columns.Add(dateCol2);
        
        var dateCol3 = new DataGridViewTextBoxColumn { Name = "GozlenilenTehvilTarixi", DataPropertyName = "GozlenilenTehvilTarixi", HeaderText = "Gözlənilən Təhvil" };
        dateCol3.DefaultCellStyle.Format = "dd.MM.yyyy";
        dgvSifarisler.Columns.Add(dateCol3);
        
        var dateCol4 = new DataGridViewTextBoxColumn { Name = "FaktikiTehvilTarixi", DataPropertyName = "FaktikiTehvilTarixi", HeaderText = "Faktiki Təhvil" };
        dateCol4.DefaultCellStyle.Format = "dd.MM.yyyy";
        dgvSifarisler.Columns.Add(dateCol4);
        
        var meblegCol = new DataGridViewTextBoxColumn { Name = "UmumiMebleg", DataPropertyName = "UmumiMebleg", HeaderText = "Ümumi Məbləğ" };
        meblegCol.DefaultCellStyle.Format = "N2";
        dgvSifarisler.Columns.Add(meblegCol);
        
        dgvSifarisler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", DataPropertyName = "Status", HeaderText = "Status" });
        dgvSifarisler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Qeydler", DataPropertyName = "Qeydler", HeaderText = "Qeydlər" });

        dgvSifarisler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void FormatSetirGrid()
    {
        if (dgvSetirler.Columns.Count > 0) return;

        dgvSetirler.AutoGenerateColumns = false;
        
        dgvSetirler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
        dgvSetirler.Columns.Add(new DataGridViewTextBoxColumn { Name = "AlisSifarisId", DataPropertyName = "AlisSifarisId", Visible = false });
        dgvSetirler.Columns.Add(new DataGridViewTextBoxColumn { Name = "MehsulId", DataPropertyName = "MehsulId", Visible = false });
        dgvSetirler.Columns.Add(new DataGridViewTextBoxColumn { Name = "MehsulAdi", DataPropertyName = "MehsulAdi", HeaderText = "Məhsul" });
        
        var qtyCol = new DataGridViewTextBoxColumn { Name = "Miqdar", DataPropertyName = "Miqdar", HeaderText = "Miqdar" };
        qtyCol.DefaultCellStyle.Format = "N2";
        dgvSetirler.Columns.Add(qtyCol);
        
        var priceCol = new DataGridViewTextBoxColumn { Name = "BirVahidQiymet", DataPropertyName = "BirVahidQiymet", HeaderText = "Vahid Qiymət" };
        priceCol.DefaultCellStyle.Format = "N2";
        dgvSetirler.Columns.Add(priceCol);
        
        var totalCol = new DataGridViewTextBoxColumn { Name = "CemiMebleg", DataPropertyName = "CemiMebleg", HeaderText = "Cəmi" };
        totalCol.DefaultCellStyle.Format = "N2";
        dgvSetirler.Columns.Add(totalCol);
        
        var tehvilCol = new DataGridViewTextBoxColumn { Name = "TehvilAlinanMiqdar", DataPropertyName = "TehvilAlinanMiqdar", HeaderText = "Təhvil Alınan" };
        tehvilCol.DefaultCellStyle.Format = "N2";
        dgvSetirler.Columns.Add(tehvilCol);

        var qalanCol = new DataGridViewTextBoxColumn { Name = "QalanMiqdar", DataPropertyName = "QalanMiqdar", HeaderText = "Qalan" };
        qalanCol.DefaultCellStyle.Format = "N2";
        dgvSetirler.Columns.Add(qalanCol);

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

        DialogResult tesdiq = MessageBox.Show(
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

        DialogResult tesdiq = MessageBox.Show(
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
        if (dgvSifarisler.SelectedRows.Count == 0)
        {
            return;
        }

        if (dgvSifarisler.SelectedRows[0].DataBoundItem is not AlisSifarisDto seciliSifaris)
        {
            return;
        }

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

        int mehsulId = (int)cmbMehsul.SelectedValue;
        string mehsulAdi = cmbMehsul.Text;
        decimal miqdar = numMiqdar.Value;
        decimal birVahidQiymet = numBirVahidQiymet.Value;
        decimal cemiMebleg = miqdar * birVahidQiymet;

        AlisSifarisSetiriDto setir = new()
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

        if (dgvSetirler.SelectedRows[0].DataBoundItem is AlisSifarisSetiriDto seciliSetir)
        {
            _sifarisSetirleri.Remove(seciliSetir);
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
