// Fayl: AzAgroPOS.Teqdimat/TedarukcuOdemeFormu.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Teqdimat;
/// <summary>
/// Tədarükçü ödənişi idarəetmə forması.
/// diqqət: Bu forma MVP pattern istifadə edir və ITedarukcuOdemeView interfeysi implement edir.
/// </summary>
public partial class TedarukcuOdemeFormu : BazaForm, ITedarukcuOdemeView
{
    private TedarukcuOdemePresenter? _presenter;

    public TedarukcuOdemeFormu(AlisManager alisManager)
    {
        InitializeComponent();

        // Enum combo box-ları başlatırıq
        InicializeEnums();

        // Presenter-i başlatırıq
        _presenter = new TedarukcuOdemePresenter(this, alisManager);

        // Form yüklənəndə hadisəni tetikləyirik
        Load += (s, e) => FormYuklendi?.Invoke(s, e);
    }

    private void InicializeEnums()
    {
        // Ödəniş Üsulu enum-unu ComboBox-a yükləyirik
        cmbOdemeUsulu.DataSource = Enum.GetValues(typeof(OdemeUsulu));
        cmbOdemeUsulu.SelectedIndex = 0;

        // Status enum-unu ComboBox-a yükləyirik
        cmbStatus.DataSource = Enum.GetValues(typeof(OdemeStatusu));
        cmbStatus.SelectedIndex = 0;
    }

    #region ITedarukcuOdemeView Implementation

    public int OdemeId { get; set; }

    public string OdemeNomresi
    {
        get => txtOdemeNomresi.Text;
        set => txtOdemeNomresi.Text = value;
    }

    public DateTime YaradilmaTarixi
    {
        get => dtpYaradilmaTarixi.Value;
        set => dtpYaradilmaTarixi.Value = value;
    }

    public int TedarukcuId
    {
        get => cmbTedarukcu.SelectedValue != null ? (int)cmbTedarukcu.SelectedValue : 0;
        set => cmbTedarukcu.SelectedValue = value;
    }

    public int? AlisSenedId
    {
        get => cmbAlisSened.SelectedValue != null ? (int?)cmbAlisSened.SelectedValue : null;
        set => cmbAlisSened.SelectedValue = value;
    }

    public DateTime OdemeTarixi
    {
        get => dtpOdemeTarixi.Value;
        set => dtpOdemeTarixi.Value = value;
    }

    public decimal Mebleg
    {
        get => numMebleg.Value;
        set => numMebleg.Value = value;
    }

    public string? Qeydler
    {
        get => txtQeydler.Text;
        set => txtQeydler.Text = value ?? string.Empty;
    }

    public string? BankMelumatlari
    {
        get => txtBankMelumatlari.Text;
        set => txtBankMelumatlari.Text = value ?? string.Empty;
    }

    public void TedarukculeriGoster(List<TedarukcuDto> tedarukculer)
    {
        cmbTedarukcu.DataSource = tedarukculer;
        cmbTedarukcu.DisplayMember = "Ad";
        cmbTedarukcu.ValueMember = "Id";
        cmbTedarukcu.SelectedIndex = -1;
    }

    public void SenetleriGoster(List<AlisSenedDto> senetler)
    {
        // "Seçilməyib" seçimi üçün boş bir element əlavə edirik
        List<AlisSenedDto> senetListesi = new()
        {
            new() { Id = 0, SenedNomresi = "-- Seçilməyib --" }
        };
        senetListesi.AddRange(senetler);

        cmbAlisSened.DataSource = senetListesi;
        cmbAlisSened.DisplayMember = "SenedNomresi";
        cmbAlisSened.ValueMember = "Id";
        cmbAlisSened.SelectedIndex = 0;
    }

    public void OdemeleriGoster(List<TedarukcuOdemeDto> odemeler)
    {
        FormatGrid();
        dgvOdemeler.DataSource = new System.ComponentModel.BindingList<TedarukcuOdemeDto>(odemeler);
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
        OdemeId = 0;
        txtOdemeNomresi.Clear();
        dtpYaradilmaTarixi.Value = DateTime.Now;
        cmbTedarukcu.SelectedIndex = -1;
        cmbAlisSened.SelectedIndex = 0;
        dtpOdemeTarixi.Value = DateTime.Now;
        numMebleg.Value = 0;
        cmbOdemeUsulu.SelectedIndex = 0;
        cmbStatus.SelectedIndex = 0;
        txtQeydler.Clear();
        txtBankMelumatlari.Clear();
    }

    public event EventHandler? FormYuklendi;
    public event EventHandler? OdemeYarat_Istek;
    public event EventHandler? OdemeYenile_Istek;
    public event EventHandler? OdemeSil_Istek;
    public event EventHandler? FormuTemizle_Istek;

    #endregion

    #region Helper Methods

    private void FormatGrid()
    {
        if (dgvOdemeler.Columns.Count > 0) return;

        dgvOdemeler.AutoGenerateColumns = false;
        
        dgvOdemeler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
        dgvOdemeler.Columns.Add(new DataGridViewTextBoxColumn { Name = "TedarukcuId", DataPropertyName = "TedarukcuId", Visible = false });
        dgvOdemeler.Columns.Add(new DataGridViewTextBoxColumn { Name = "AlisSenedId", DataPropertyName = "AlisSenedId", Visible = false });
        
        dgvOdemeler.Columns.Add(new DataGridViewTextBoxColumn { Name = "OdemeNomresi", DataPropertyName = "OdemeNomresi", HeaderText = "Ödəniş №" });
        dgvOdemeler.Columns.Add(new DataGridViewTextBoxColumn { Name = "TedarukcuAdi", DataPropertyName = "TedarukcuAdi", HeaderText = "Tədarükçü" });
        dgvOdemeler.Columns.Add(new DataGridViewTextBoxColumn { Name = "AlisSenedNomresi", DataPropertyName = "AlisSenedNomresi", HeaderText = "Alış Sənədi" });
        
        var createDateCol = new DataGridViewTextBoxColumn { Name = "YaradilmaTarixi", DataPropertyName = "YaradilmaTarixi", HeaderText = "Yaradılma Tarixi" };
        createDateCol.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
        dgvOdemeler.Columns.Add(createDateCol);
        
        var dateCol = new DataGridViewTextBoxColumn { Name = "OdemeTarixi", DataPropertyName = "OdemeTarixi", HeaderText = "Ödəniş Tarixi" };
        dateCol.DefaultCellStyle.Format = "dd.MM.yyyy";
        dgvOdemeler.Columns.Add(dateCol);
        
        var sumCol = new DataGridViewTextBoxColumn { Name = "Mebleg", DataPropertyName = "Mebleg", HeaderText = "Məbləğ" };
        sumCol.DefaultCellStyle.Format = "N2";
        dgvOdemeler.Columns.Add(sumCol);
        
        dgvOdemeler.Columns.Add(new DataGridViewTextBoxColumn { Name = "OdemeUsulu", DataPropertyName = "OdemeUsulu", HeaderText = "Ödəniş Üsulu" });
        dgvOdemeler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", DataPropertyName = "Status", HeaderText = "Status" });
        dgvOdemeler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Qeydler", DataPropertyName = "Qeydler", HeaderText = "Qeydlər" });
        dgvOdemeler.Columns.Add(new DataGridViewTextBoxColumn { Name = "BankMelumatlari", DataPropertyName = "BankMelumatlari", HeaderText = "Bank Məlumatları" });

        dgvOdemeler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    #endregion

    #region Event Handlers

    private void btnYarat_Click(object sender, EventArgs e)
    {
        if (ValidateForm())
        {
            OdemeYarat_Istek?.Invoke(sender, e);
        }
    }

    private void btnYenile_Click(object sender, EventArgs e)
    {
        if (ValidateForm())
        {
            OdemeYenile_Istek?.Invoke(sender, e);
        }
    }

    private void btnSil_Click(object sender, EventArgs e)
    {
        if (OdemeId <= 0)
        {
            MessageBox.Show("Silmək üçün cədvəldən ödəniş seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult tesdiq = MessageBox.Show(
            "Bu ödənişi silmək istəyirsiniz?",
            "Təsdiq",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (tesdiq == DialogResult.Yes)
        {
            OdemeSil_Istek?.Invoke(sender, e);
        }
    }

    private void btnTemizle_Click(object sender, EventArgs e)
    {
        FormuTemizle_Istek?.Invoke(sender, e);
    }

    private void dgvOdemeler_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvOdemeler.SelectedRows.Count == 0)
        {
            return;
        }

        if (dgvOdemeler.SelectedRows[0].DataBoundItem is not TedarukcuOdemeDto seciliOdeme)
        {
            return;
        }

        OdemeId = seciliOdeme.Id;
        txtOdemeNomresi.Text = seciliOdeme.OdemeNomresi;
        dtpYaradilmaTarixi.Value = seciliOdeme.YaradilmaTarixi;
        cmbTedarukcu.SelectedValue = seciliOdeme.TedarukcuId;
        cmbAlisSened.SelectedValue = seciliOdeme.AlisSenedId ?? 0;
        dtpOdemeTarixi.Value = seciliOdeme.OdemeTarixi;
        numMebleg.Value = seciliOdeme.Mebleg;
        cmbOdemeUsulu.SelectedItem = seciliOdeme.OdemeUsulu;
        cmbStatus.SelectedItem = seciliOdeme.Status;
        txtQeydler.Text = seciliOdeme.Qeydler ?? string.Empty;
        txtBankMelumatlari.Text = seciliOdeme.BankMelumatlari ?? string.Empty;
    }

    private void cmbOdemeUsulu_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Əgər ödəniş üsulu Bank Köçürməsidirsə, bank məlumatları sahəsini aktiv edirik
        if (cmbOdemeUsulu.SelectedItem is OdemeUsulu usul)
        {
            txtBankMelumatlari.Enabled = usul == OdemeUsulu.BankKocurmesi;
        }
    }

    #endregion

    #region Validation

    private bool ValidateForm()
    {
        if (string.IsNullOrWhiteSpace(txtOdemeNomresi.Text))
        {
            MessageBox.Show("Ödəniş nömrəsi daxil edin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtOdemeNomresi.Focus();
            return false;
        }

        if (cmbTedarukcu.SelectedValue == null || (int)cmbTedarukcu.SelectedValue == 0)
        {
            MessageBox.Show("Tədarükçü seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cmbTedarukcu.Focus();
            return false;
        }

        if (numMebleg.Value <= 0)
        {
            MessageBox.Show("Məbləğ 0-dan böyük olmalıdır!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            numMebleg.Focus();
            return false;
        }

        if (cmbOdemeUsulu.SelectedItem is OdemeUsulu usul && usul == OdemeUsulu.BankKocurmesi)
        {
            if (string.IsNullOrWhiteSpace(txtBankMelumatlari.Text))
            {
                MessageBox.Show("Bank köçürməsi üçün bank məlumatları daxil edin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBankMelumatlari.Focus();
                return false;
            }
        }

        return true;
    }

    #endregion
}
