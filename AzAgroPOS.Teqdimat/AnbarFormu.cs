// Fayl: AzAgroPOS.Teqdimat/AnbarFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Mentiq.Idareciler;

public partial class AnbarFormu : BazaForm, IAnbarView
{
    private readonly AnbarPresenter _presenter;

    public AnbarFormu(AnbarManager anbarManager)
    {
        InitializeComponent();
        _presenter = new AnbarPresenter(this, anbarManager);
    }

    public string AxtarisMetni => txtAxtaris.Text;
    public string ElaveOlunanSay => txtElaveOlunanSay.Text;
    public int? SecilmisMehsulId => int.TryParse(lblMehsulId.Text, out int id) ? id : null;

    public event EventHandler AxtarIstek;
    public event EventHandler StokArtirIstek;

    public void MehsulMelumatlariniGoster(MehsulDto mehsul)
    {
        lblMehsulId.Text = mehsul.Id.ToString();
        lblMehsulMelumat.Text = $"{mehsul.Ad}\nMövcud Say: {mehsul.MovcudSay}";
        pnlMelumat.Visible = true;
        txtElaveOlunanSay.Focus();
    }

    public void FormuTemizle(bool axtarisQutusuQalsin = false)
    {
        if (!axtarisQutusuQalsin)
        {
            txtAxtaris.Clear();
        }
        txtElaveOlunanSay.Clear();
        lblMehsulId.Text = "";
        lblMehsulMelumat.Text = "";
        pnlMelumat.Visible = false;
        txtAxtaris.Focus();
    }

    public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon)
    {
        return MessageBox.Show(this, mesaj, basliq, düymələr, ikon);
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

    private void btnAxtar_Click(object sender, EventArgs e)
    {
        AxtarIstek?.Invoke(this, EventArgs.Empty);
    }

    private void btnTesdiqle_Click(object sender, EventArgs e)
    {
        StokArtirIstek?.Invoke(this, EventArgs.Empty);
    }

    private void txtAxtaris_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            AxtarIstek?.Invoke(this, EventArgs.Empty);
            e.SuppressKeyPress = true; // "ding" səsini bloklamaq üçün
        }
    }
}