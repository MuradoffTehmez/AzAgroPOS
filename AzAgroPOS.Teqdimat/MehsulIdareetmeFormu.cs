// Fayl: AzAgroPOS.Teqdimat/MehsulIdareetmeFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using System.Data;

public partial class MehsulIdareetmeFormu : BazaForm, IMehsulIdareetmeView
{
    private MehsulPresenter _presenter;

    public MehsulIdareetmeFormu()
    {
        InitializeComponent();
        _presenter = new MehsulPresenter(this);
    }

    // IMehsulIdareetmeView interfeysinin implementasiyası
    #region View Implementasiyası
    public string MehsulId { get => txtId.Text; set => txtId.Text = value; }
    public string MehsulAdi { get => txtAd.Text; set => txtAd.Text = value; }
    public string StokKodu { get => txtStokKodu.Text; set => txtStokKodu.Text = value; }
    public string Barkod { get => txtBarkod.Text; set => txtBarkod.Text = value; }
    public string SatisQiymeti { get => txtSatisQiymeti.Text; set => txtSatisQiymeti.Text = value; }
    public string MovcudSay { get => txtMevcudSay.Text; set => txtMevcudSay.Text = value; }
    public string AxtarisMetni { get => txtAxtar.Text; set => txtAxtar.Text = value; }

    public event EventHandler FormYuklendi_Istek;
    public event EventHandler MehsulElaveEt_Istek;
    public event EventHandler MehsulYenile_Istek;
    public event EventHandler MehsulSil_Istek;
    public event EventHandler FormuTemizle_Istek;
    public event EventHandler CedvelSecimiDeyisdi_Istek;
    public event EventHandler Axtaris_Istek;

    public void MehsullariGoster(IEnumerable<MehsulDto> mehsullar)
    {
        dgvMehsullar.DataSource = mehsullar.ToList();
        // Cədvəlin sütunlarını daha oxunaqlı etmək
        dgvMehsullar.Columns["Id"].Visible = false;
        dgvMehsullar.Columns["Ad"].HeaderText = "Məhsulun Adı";
        dgvMehsullar.Columns["StokKodu"].HeaderText = "Stok Kodu";
        dgvMehsullar.Columns["SatisQiymetiStr"].HeaderText = "Satış Qiyməti";
        dgvMehsullar.Columns["MevcudSay"].HeaderText = "Mövcud Say";
        dgvMehsullar.Columns["SatisQiymeti"].Visible = false;
    }

    public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon)
    {
        return MessageBox.Show(mesaj, basliq, düymələr, ikon);
    }
    #endregion

    // Form hadisələrini Presenter-ə ötürmək
    #region Hadisə Ötürücüləri
    private void MehsulIdareetmeFormu_Load(object sender, EventArgs e)
    {
        FormYuklendi_Istek?.Invoke(this, EventArgs.Empty);
    }

    private void btnElaveEt_Click(object sender, EventArgs e)
    {
        MehsulElaveEt_Istek?.Invoke(this, EventArgs.Empty);
    }

    private void btnYenile_Click(object sender, EventArgs e)
    {
        MehsulYenile_Istek?.Invoke(this, EventArgs.Empty);
    }

    private void btnSil_Click(object sender, EventArgs e)
    {
        MehsulSil_Istek?.Invoke(this, EventArgs.Empty);
    }

    private void btnTemizle_Click(object sender, EventArgs e)
    {
        FormuTemizle_Istek?.Invoke(this, EventArgs.Empty);
    }

    private void dgvMehsullar_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvMehsullar.CurrentRow != null && dgvMehsullar.CurrentRow.DataBoundItem is MehsulDto secilmisMehsul)
        {
            txtId.Text = secilmisMehsul.Id.ToString();
            CedvelSecimiDeyisdi_Istek?.Invoke(this, EventArgs.Empty);
        }
    }

    private void txtAxtar_TextChanged(object sender, EventArgs e)
    {
        Axtaris_Istek?.Invoke(this, EventArgs.Empty);
    }
    #endregion
}