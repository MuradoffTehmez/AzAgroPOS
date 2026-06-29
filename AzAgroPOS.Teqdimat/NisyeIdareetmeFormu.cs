// Fayl: AzAgroPOS.Teqdimat/NisyeIdareetmeFormu.cs

// using-lər
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;

namespace AzAgroPOS.Teqdimat;

public partial class NisyeIdareetmeFormu : BazaForm, INisyeView
{
    private readonly NisyePresenter _presenter;

    public NisyeIdareetmeFormu(NisyeManager nisyeManager, MusteriManager musteriManager)
    {
        InitializeComponent();
        _presenter = new NisyePresenter(this, nisyeManager, musteriManager);
        StilVerDataGridView(dgvMusteriler);
        StilVerDataGridView(dgvNisyeHereketleri);
    }

    public int? SecilmisMusteriId => dgvMusteriler.CurrentRow != null && dgvMusteriler.CurrentRow.DataBoundItem is MusteriDto musteri ? musteri.Id : null;

    public decimal OdenisMeblegi => decimal.TryParse(txtOdenisMeblegi.Text, out decimal mebleg) ? mebleg : 0;

    /// <summary>
    /// Ödəniş düyməsinin aktiv/deaktiv olma vəziyyəti
    /// </summary>
    public bool OdenisButtonAktivdir
    {
        get => btnOdenisEt.Enabled;
        set
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => btnOdenisEt.Enabled = value));
            }
            else
            {
                btnOdenisEt.Enabled = value;
            }
        }
    }

    public event EventHandler FormYuklendi;
    public event EventHandler MusteriSecildi;
    public event EventHandler OdenisEdildi;

    public void MusterileriGoster(List<MusteriDto> musteriler)
    {
        if (dgvMusteriler.Columns.Count == 0)
        {
            dgvMusteriler.AutoGenerateColumns = false;
            
            dgvMusteriler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvMusteriler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Unvan", DataPropertyName = "Unvan", Visible = false });
            dgvMusteriler.Columns.Add(new DataGridViewTextBoxColumn { Name = "TamAd", DataPropertyName = "TamAd", HeaderText = "Tam Ad" });
            dgvMusteriler.Columns.Add(new DataGridViewTextBoxColumn { Name = "TelefonNomresi", DataPropertyName = "TelefonNomresi", HeaderText = "Telefon" });
            
            var debtCol = new DataGridViewTextBoxColumn { Name = "UmumiBorc", DataPropertyName = "UmumiBorc", HeaderText = "Ümumi Borc" };
            debtCol.DefaultCellStyle.Format = "N2";
            dgvMusteriler.Columns.Add(debtCol);
            
            var limitCol = new DataGridViewTextBoxColumn { Name = "KreditLimiti", DataPropertyName = "KreditLimiti", HeaderText = "Kredit Limiti" };
            limitCol.DefaultCellStyle.Format = "N2";
            dgvMusteriler.Columns.Add(limitCol);
        }

        dgvMusteriler.DataSource = new System.ComponentModel.BindingList<MusteriDto>(musteriler);
    }

    public void MusteriHereketleriniGoster(List<NisyeHereketiDto> hereketler)
    {
        if (dgvNisyeHereketleri.Columns.Count == 0)
        {
            dgvNisyeHereketleri.AutoGenerateColumns = false;
            
            dgvNisyeHereketleri.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvNisyeHereketleri.Columns.Add(new DataGridViewTextBoxColumn { Name = "MusteriId", DataPropertyName = "MusteriId", Visible = false });
            
            var dateCol = new DataGridViewTextBoxColumn { Name = "Tarix", DataPropertyName = "Tarix", HeaderText = "Tarix" };
            dateCol.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            dgvNisyeHereketleri.Columns.Add(dateCol);
            
            var sumCol = new DataGridViewTextBoxColumn { Name = "Mebleg", DataPropertyName = "Mebleg", HeaderText = "Məbləğ" };
            sumCol.DefaultCellStyle.Format = "N2";
            dgvNisyeHereketleri.Columns.Add(sumCol);
            
            dgvNisyeHereketleri.Columns.Add(new DataGridViewTextBoxColumn { Name = "HereketNovuStr", DataPropertyName = "HereketNovuStr", HeaderText = "Növü" });
            dgvNisyeHereketleri.Columns.Add(new DataGridViewTextBoxColumn { Name = "Qeyd", DataPropertyName = "Qeyd", HeaderText = "Qeyd" });
            dgvNisyeHereketleri.Columns.Add(new DataGridViewTextBoxColumn { Name = "IstifadeciAdi", DataPropertyName = "IstifadeciAdi", HeaderText = "İstifadəçi" });
        }

        dgvNisyeHereketleri.DataSource = new System.ComponentModel.BindingList<NisyeHereketiDto>(hereketler);
    }

    public void MesajGoster(string mesaj, string basliq)
    {
        MessageBox.Show(mesaj, basliq);
    }

    /// <summary>
    /// MessageBox göstərir və istifadəçi cavabını qaytarır
    /// </summary>
    public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons buttons, MessageBoxIcon icon)
    {
        return MessageBox.Show(mesaj, basliq, buttons, icon);
    }

    /// <summary>
    /// Shows a validation error on a control
    /// </summary>
    /// <param name="control">Control to show error on</param>
    /// <param name="message">Error message</param>
    public void XetaGoster(Control control, string message)
    {
        errorProvider1.SetError(control, message);
        errorProvider1.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
        errorProvider1.SetIconPadding(control, 2);
    }

    /// <summary>
    /// Clears validation error from a control
    /// </summary>
    /// <param name="control">Control to clear error from</param>
    public void XetaniTemizle(Control control)
    {
        errorProvider1.SetError(control, string.Empty);
    }

    /// <summary>
    /// Clears all validation errors
    /// </summary>
    public void ButunXetalariTemizle()
    {
        // Clear errors from all controls
        foreach (Control control in Controls)
        {
            ClearErrorsRecursive(control);
        }
    }

    /// <summary>
    /// Recursively clears errors from all controls
    /// </summary>
    /// <param name="control">Control to clear errors from</param>
    private void ClearErrorsRecursive(Control control)
    {
        errorProvider1.SetError(control, string.Empty);
        foreach (Control child in control.Controls)
        {
            ClearErrorsRecursive(child);
        }
    }

    public void FormuTemizle()
    {
        txtOdenisMeblegi.Clear();
        ButunXetalariTemizle();
        txtOdenisMeblegi.Focus();
    }

    private void NisyeIdareetmeFormu_Load(object sender, EventArgs e)
    {
        // Numeric input validation üçün KeyPress event-i əlavə et
        txtOdenisMeblegi.KeyPress += TxtOdenisMeblegi_KeyPress;
        txtOdenisMeblegi.TextChanged += TxtOdenisMeblegi_TextChanged;

        FormYuklendi?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Yalnız rəqəm və ondalık nöqtə daxil edilməsinə icazə verir
    /// </summary>
    private void TxtOdenisMeblegi_KeyPress(object sender, KeyPressEventArgs e)
    {
        // Backspace, Delete və Ctrl+V icazə verilir
        if (char.IsControl(e.KeyChar))
        {
            return;
        }

        // Yalnız rəqəmlər və ondalık separator
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
        {
            e.Handled = true;
            return;
        }

        // Yalnız bir dəfə ondalık separator
        if ((e.KeyChar == '.' || e.KeyChar == ',') &&
            (txtOdenisMeblegi.Text.Contains(".") || txtOdenisMeblegi.Text.Contains(",")))
        {
            e.Handled = true;
        }
    }

    /// <summary>
    /// Məbləğ dəyişdikdə validation error-ları təmizləyir
    /// </summary>
    private void TxtOdenisMeblegi_TextChanged(object sender, EventArgs e)
    {
        XetaniTemizle(txtOdenisMeblegi);
    }

    private void dgvMusteriler_SelectionChanged(object sender, EventArgs e)
    {
        MusteriSecildi?.Invoke(this, EventArgs.Empty);
    }

    private void btnOdenisEt_Click(object sender, EventArgs e)
    {
        OdenisEdildi?.Invoke(this, EventArgs.Empty);
    }
}