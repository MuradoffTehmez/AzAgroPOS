// Fayl: AzAgroPOS.Teqdimat/IstifadeciIdareetmeFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Mentiq.Idareciler;

public partial class IstifadeciIdareetmeFormu : BazaForm, IIstifadeciView
{
    private readonly IstifadeciPresenter _presenter;

    public IstifadeciIdareetmeFormu(IstifadeciManager istifadeciManager)
    {
        InitializeComponent();
        _presenter = new IstifadeciPresenter(this, istifadeciManager);
        StilVerDataGridView(dgvIstifadeciler);
    }

    public string IstifadeciId { get => txtId.Text; set => txtId.Text = value; }
    public string IstifadeciAdi { get => txtIstifadeciAdi.Text; set => txtIstifadeciAdi.Text = value; }
    public string TamAd { get => txtTamAd.Text; set => txtTamAd.Text = value; }
    public string Parol { get => txtParol.Text; set => txtParol.Text = value; }
    public int SecilmisRolId => (int)(cmbRollar.SelectedValue ?? 0);

    public event EventHandler FormYuklendi;
    public event EventHandler IstifadeciYarat_Istek;
    public event EventHandler IstifadeciYenile_Istek;
    public event EventHandler IstifadeciSil_Istek;
    public event EventHandler FormuTemizle_Istek;


    public void IstifadecileriGoster(List<IstifadeciDto> istifadeciler)
    {
        dgvIstifadeciler.SelectionChanged -= dgvIstifadeciler_SelectionChanged;
        // Cədvəli yeniləmədən əvvəl seçimi qorumaq üçün
        var secilmisId = string.IsNullOrEmpty(txtId.Text) ? -1 : int.Parse(txtId.Text);

        dgvIstifadeciler.DataSource = istifadeciler;

        // Seçimi bərpa etməyə çalışırıq
        if (secilmisId != -1)
        {
            foreach (DataGridViewRow row in dgvIstifadeciler.Rows)
            {
                if (row.DataBoundItem is IstifadeciDto dto && dto.Id == secilmisId)
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        dgvIstifadeciler.SelectionChanged += dgvIstifadeciler_SelectionChanged;

        if (dgvIstifadeciler.Columns.Count > 0)
        {
            dgvIstifadeciler.Columns["Id"].Visible = false;
            dgvIstifadeciler.Columns["RolId"].Visible = false;
            dgvIstifadeciler.Columns["IstifadeciAdi"].HeaderText = "İstifadəçi Adı";
            dgvIstifadeciler.Columns["TamAd"].HeaderText = "Tam Ad";
            dgvIstifadeciler.Columns["RolAdi"].HeaderText = "Rol";
        }
    }

    public void RollariGoster(List<Rol> rollar)
    {
        cmbRollar.DataSource = rollar;
        cmbRollar.DisplayMember = "Ad";
        cmbRollar.ValueMember = "Id";
    }

    public void MesajGoster(string mesaj, bool xetadir = false)
    {
        MessageBox.Show(mesaj, xetadir ? "Xəta" : "Məlumat", MessageBoxButtons.OK, xetadir ? MessageBoxIcon.Error : MessageBoxIcon.Information);
    }

    public void FormuTemizle()
    {
        txtId.Clear();
        txtIstifadeciAdi.Clear();
        txtIstifadeciAdi.ReadOnly = false;
        txtTamAd.Clear();
        txtParol.Clear();
        if (cmbRollar.Items.Count > 0)
        {
            cmbRollar.SelectedIndex = 0;
        }
        dgvIstifadeciler.ClearSelection();
        txtIstifadeciAdi.Focus();
        btnSil.Enabled = false; // "Yeni" rejimində "Sil" düyməsi deaktiv olsun
    }

    private void IstifadeciIdareetmeFormu_Load(object sender, EventArgs e)
    {
        FormYuklendi?.Invoke(this, EventArgs.Empty);
        FormuTemizle();
    }

    private void btnYarat_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtId.Text))
        {
            IstifadeciYarat_Istek?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            IstifadeciYenile_Istek?.Invoke(this, EventArgs.Empty);
        }
    }

    private void btnSil_Click(object sender, EventArgs e)
    {
        IstifadeciSil_Istek?.Invoke(this, EventArgs.Empty);
    }

    private void btnTemizle_Click(object sender, EventArgs e)
    {
        FormuTemizle_Istek?.Invoke(this, EventArgs.Empty);
    }

    private void dgvIstifadeciler_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvIstifadeciler.CurrentRow?.DataBoundItem is IstifadeciDto istifadeci)
        {
            txtId.Text = istifadeci.Id.ToString();
            txtIstifadeciAdi.Text = istifadeci.IstifadeciAdi;
            txtIstifadeciAdi.ReadOnly = true;
            txtTamAd.Text = istifadeci.TamAd;
            cmbRollar.SelectedValue = istifadeci.RolId;
            txtParol.Clear();
            btnSil.Enabled = true; // "Redakt\u0131" rejimind\u0131 "Sil" d\u00FCym\u0131si aktiv olsun
        }
        else
        {
            btnSil.Enabled = false;
        }
    }
    
    public void MesajGoster(string mesaj, string basliq, MessageBoxIcon ikon)
    {
        MessageBox.Show(mesaj, basliq, MessageBoxButtons.OK, ikon);
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
}