// Fayl: AzAgroPOS.Teqdimat/NisyeIdareetmeFormu.cs
namespace AzAgroPOS.Teqdimat;

// using-lər
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;

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

    public int? SecilmisMusteriId
    {
        get
        {
            if (dgvMusteriler.CurrentRow != null && dgvMusteriler.CurrentRow.DataBoundItem is MusteriDto musteri)
            {
                return musteri.Id;
            }
            return null;
        }
    }

    public decimal OdenisMeblegi => decimal.TryParse(txtOdenisMeblegi.Text, out var mebleg) ? mebleg : 0;

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
        dgvMusteriler.DataSource = musteriler;
        // Sütunları konfiqurasiya et
        if (dgvMusteriler.Columns.Count > 0)
        {
            // İstənilən sütunları gizlət
            if (dgvMusteriler.Columns.Contains("Id"))
                dgvMusteriler.Columns["Id"].Visible = false;
        }
    }

    public void MusteriHereketleriniGoster(List<NisyeHereketiDto> hereketler)
    {
        dgvNisyeHereketleri.DataSource = hereketler;
        // Sütunları konfiqurasiya et
        if (dgvNisyeHereketleri.Columns.Count > 0)
        {
            // İstənilən sütunları gizlət
            if (dgvNisyeHereketleri.Columns.Contains("Id"))
                dgvNisyeHereketleri.Columns["Id"].Visible = false;
            if (dgvNisyeHereketleri.Columns.Contains("MusteriId"))
                dgvNisyeHereketleri.Columns["MusteriId"].Visible = false;
        }
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
        foreach (Control control in this.Controls)
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