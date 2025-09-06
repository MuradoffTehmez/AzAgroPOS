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

    public event EventHandler FormYuklendi;
    public event EventHandler MusteriSecildi;
    public event EventHandler OdenisEdildi;

    public void MusterileriGoster(List<MusteriDto> musteriler)
    {
        dgvMusteriler.DataSource = musteriler;
        // Sütunları konfiqurasiya et
    }

    public void MusteriHereketleriniGoster(List<NisyeHereketiDto> hereketler)
    {
        dgvNisyeHereketleri.DataSource = hereketler;
        // Sütunları konfiqurasiya et
    }

    public void MesajGoster(string mesaj, string basliq)
    {
        MessageBox.Show(mesaj, basliq);
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
    }

    private void NisyeIdareetmeFormu_Load(object sender, EventArgs e)
    {
        FormYuklendi?.Invoke(this, EventArgs.Empty);
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