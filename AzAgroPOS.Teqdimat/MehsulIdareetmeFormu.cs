// Fayl: AzAgroPOS.Teqdimat/MehsulIdareetmeFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using System.Data;

/// <summary>
/// B
/// </summary>
public partial class MehsulIdareetmeFormu : BazaForm, IMehsulIdareetmeView
{
    /// <summary>
    /// 
    /// </summary>
    private MehsulPresenter _presenter;

    /// <summary>
    ///  
    /// </summary>
    public MehsulIdareetmeFormu()
    {
        InitializeComponent();
        _presenter = new MehsulPresenter(this);
    }

    // IMehsulIdareetmeView interfeysinin implementasiyası
    #region View Implementasiyası
    /// <summary>
    /// 
    /// </summary>
    public string MehsulId { get => txtId.Text; set => txtId.Text = value; }
    /// <summary>
    /// 
    /// </summary>
    public string MehsulAdi { get => txtAd.Text; set => txtAd.Text = value; }
    /// <summary>
    /// 
    /// </summary>
    public string StokKodu { get => txtStokKodu.Text; set => txtStokKodu.Text = value; }
    /// <summary>
    /// 
    /// </summary>
    public string Barkod { get => txtBarkod.Text; set => txtBarkod.Text = value; }
    /// <summary>
    /// 
    /// </summary>
    public string SatisQiymeti { get => txtSatisQiymeti.Text; set => txtSatisQiymeti.Text = value; }
    /// <summary>
    /// 
    /// </summary>
    public string MovcudSay { get => txtMevcudSay.Text; set => txtMevcudSay.Text = value; }
    /// <summary>
    /// 
    /// </summary>
    public string AxtarisMetni { get => txtAxtar.Text; set => txtAxtar.Text = value; }

    /// <summary>
    /// 
    /// </summary>
    public event EventHandler FormYuklendi_Istek;
    /// <summary>
    /// 
    /// </summary>
    public event EventHandler MehsulElaveEt_Istek;
    /// <summary>
    /// 
    /// </summary>
    public event EventHandler MehsulYenile_Istek;
    /// <summary>
    /// 
    /// </summary>
    public event EventHandler MehsulSil_Istek;
    /// <summary>
    /// 
    /// </summary>
    public event EventHandler FormuTemizle_Istek;
    /// <summary>
    /// 
    /// </summary>
    public event EventHandler CedvelSecimiDeyisdi_Istek;
    /// <summary>
    /// 
    /// </summary>
    public event EventHandler Axtaris_Istek;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mehsullar"></param>
    public void MehsullariGoster(IEnumerable<MehsulDto> mehsullar)
    {
        // Mümkün null vəziyyətlərinə qarşı DataSource-u təhlükəsiz şəkildə təyin edirik.
        // Əgər "mehsullar" null-dırsa, boş bir siyahı yaradırıq.
        var mehsulSiyahisi = mehsullar?.ToList() ?? new List<MehsulDto>();
        dgvMehsullar.DataSource = mehsulSiyahisi;

        // DİQQƏT: Yalnız cədvəldə sütunlar həqiqətən yaranıbsa, onlara müraciət edirik.
        if (dgvMehsullar.Columns.Count > 0)
        {
            // Cədvəlin sütunlarını daha oxunaqlı etmək
            dgvMehsullar.Columns["Id"].Visible = false;
            dgvMehsullar.Columns["Ad"].HeaderText = "Məhsulun Adı";
            dgvMehsullar.Columns["StokKodu"].HeaderText = "Stok Kodu";
            dgvMehsullar.Columns["SatisQiymetiStr"].HeaderText = "Satış Qiyməti";
            dgvMehsullar.Columns["MovcudSay"].HeaderText = "Mövcud Say";

            // Bu sütunu gizlədirik, çünki formatlanmış "SatisQiymetiStr" sütununu istifadə edirik.
            dgvMehsullar.Columns["SatisQiymeti"].Visible = false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mesaj"></param>
    /// <param name="basliq"></param>
    /// <param name="düymələr"></param>
    /// <param name="ikon"></param>
    /// <returns></returns>
    public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon)
    {
        return MessageBox.Show(mesaj, basliq, düymələr, ikon);
    }
    #endregion

    // Form hadisələrini Presenter-ə ötürmək
    #region Hadisə Ötürücüləri
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MehsulIdareetmeFormu_Load(object sender, EventArgs e)
    {
        FormYuklendi_Istek?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnElaveEt_Click(object sender, EventArgs e)
    {
        MehsulElaveEt_Istek?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnYenile_Click(object sender, EventArgs e)
    {
        MehsulYenile_Istek?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSil_Click(object sender, EventArgs e)
    {
        MehsulSil_Istek?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnTemizle_Click(object sender, EventArgs e)
    {
        FormuTemizle_Istek?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void dgvMehsullar_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvMehsullar.CurrentRow != null && dgvMehsullar.CurrentRow.DataBoundItem is MehsulDto secilmisMehsul)
        {
            txtId.Text = secilmisMehsul.Id.ToString();
            CedvelSecimiDeyisdi_Istek?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void txtAxtar_TextChanged(object sender, EventArgs e)
    {
        Axtaris_Istek?.Invoke(this, EventArgs.Empty);
    }
    #endregion
}