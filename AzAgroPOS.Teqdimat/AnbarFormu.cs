// Fayl: AzAgroPOS.Teqdimat/AnbarFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
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