// Fayl: AzAgroPOS.Teqdimat/MehsulIdareetmeFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using System.Data;

/// <summary>
/// bu forma məhsul idarəetmə əməliyyatlarını həyata keçirmək üçün istifadə olunur.
/// diqqət: bu forma MaterialSkin kitabxanasından MaterialForm-dan miras alır.
/// qeyd: bu forma IMehsulIdareetmeView interfeysini implementasiya edir.
/// </summary>
public partial class MehsulIdareetmeFormu : BazaForm, IMehsulIdareetmeView
{
    /// <summary>
    /// mehsul idarəetmə əməliyyatlarını həyata keçirmək üçün istifadə olunan presenter obyektidir.
    /// diqqət: bu obyekt formun konstruktorunda yaradılır.
    /// qeyd: bu obyekt IMehsulIdareetmeView interfeysini implementasiya edən formu qəbul edir.
    /// </summary>
    private MehsulPresenter _presenter;

    /// <summary>
    ///  mehsul idarəetmə formunun konstruktoru.
    ///  diqqət: bu konstruktor InitializeComponent metodunu çağırır.
    ///  qeyd: bu konstruktor MehsulPresenter obyektini yaradır və formu ona ötürür.
    /// </summary>
    public MehsulIdareetmeFormu()
    {
        InitializeComponent();
        _presenter = new MehsulPresenter(this);
    }

    // IMehsulIdareetmeView interfeysinin implementasiyası
    #region View Implementasiyası
    /// <summary>
    /// məhsulun unikal identifikatoru (ID).
    /// diqqət: bu xüsusiyyət txtId TextBox-un mətnini oxuyur və yazır.
    /// qeyd: bu xüsusiyyət string tipindədir.
    /// </summary>
    public string MehsulId { get => txtId.Text; set => txtId.Text = value; }
    /// <summary>
    /// mehsulun adını təyin edir textbox vasitəsilə.
    /// diqqət: bu xüsusiyyət txtAd TextBox-un mətnini oxuyur və yazır.
    /// qeyd: bu xüsusiyyət string tipindədir.
    /// </summary>
    public string MehsulAdi { get => txtAd.Text; set => txtAd.Text = value; }
    /// <summary>
    /// stok kodunu təyin edir və ya alır.
    /// diqqət: bu xüsusiyyət txtStokKodu TextBox-un mətnini oxuyur və yazır.
    /// qeyd: bu xüsusiyyət string tipindədir.
    /// </summary>
    public string StokKodu { get => txtStokKodu.Text; set => txtStokKodu.Text = value; }
    /// <summary>
    /// barkodu təyin edir və ya alır.
    /// diqət: bu xüsusiyyət txtBarkod TextBox-un mətnini oxuyur və yazır.
    /// qeyd: bu xüsusiyyət string tipindədir.
    /// </summary>
    public string Barkod { get => txtBarkod.Text; set => txtBarkod.Text = value; }
    /// <summary>
    /// satış qiymətini təyin edir və ya alır.
    /// diqət: bu xüsusiyyət txtSatisQiymeti TextBox-un mətnini oxuyur və yazır.
    /// qeyd: bu xüsusiyyət string tipindədir.
    /// </summary>
    public string SatisQiymeti { get => txtSatisQiymeti.Text; set => txtSatisQiymeti.Text = value; }
    /// <summary>
    /// mövcud sayını təyin edir və ya alır.
    /// diqət: bu xüsusiyyət txtMevcudSay TextBox-un mətnini oxuyur və yazır.
    /// qeyd: bu xüsusiyyət string tipindədir.
    /// </summary>
    public string MovcudSay { get => txtMevcudSay.Text; set => txtMevcudSay.Text = value; }
    /// <summary>
    /// axtarış mətnini təyin edir və ya alır.
    /// diqət: bu xüsusiyyət txtAxtar TextBox-un mətnini oxuyur və yazır.
    /// qeyd: bu xüsusiyyət string tipindədir.
    /// </summary>
    public string AxtarisMetni { get => txtAxtar.Text; set => txtAxtar.Text = value; }

    /// <summary>
    /// form yükləndikdə baş verən hadisə.
    /// diqət: bu hadisə FormYuklendi_Istek adlı EventHandler tipindədir.
    /// qeyd: bu hadisə presenter tərəfindən istifadə olunur.
    /// </summary>
    public event EventHandler FormYuklendi_Istek;
    /// <summary>
    /// məhsul əlavə etmək istənildikdə baş verən hadisə.
    /// diqət: bu hadisə MehsulElaveEt_Istek adlı EventHandler tipindədir.
    /// qeyd: bu hadisə presenter tərəfindən istifadə olunur.
    /// </summary>
    public event EventHandler MehsulElaveEt_Istek;
    /// <summary>
    /// məhsul yeniləmək istənildikdə baş verən hadisə.
    /// diqət: bu hadisə MehsulYenile_Istek adlı EventHandler tipindədir.
    /// qeyd: bu hadisə presenter tərəfindən istifadə olunur.
    /// </summary>
    public event EventHandler MehsulYenile_Istek;
    /// <summary>
    /// Məhsul silmək istənildikdə baş verən hadisə.
    /// diqət: bu hadisə MehsulSil_Istek adlı EventHandler tipindədir.
    /// qeyd: bu hadisə presenter tərəfindən istifadə olunur.
    /// </summary>
    public event EventHandler MehsulSil_Istek;
    /// <summary>
    /// Formu təmizləmək istənildikdə baş verən hadisə.
    /// diqət: bu hadisə FormuTemizle_Istek adlı EventHandler tipindədir.
    /// qeyd: bu hadisə presenter tərəfindən istifadə olunur.
    /// </summary>
    public event EventHandler FormuTemizle_Istek;
    /// <summary>
    /// Cədvəl seçimində dəyişiklik olduqda baş verən hadisə.
    /// diqət: bu hadisə CedvelSecimiDeyisdi_Istek adlı EventHandler tipindədir.
    /// qeyd: bu hadisə presenter tərəfindən istifadə olunur.
    /// </summary>
    public event EventHandler CedvelSecimiDeyisdi_Istek;
    /// <summary>
    /// Axtarış istəyi baş verdikdə tetiklenen hadisə.
    /// Diqət: bu hadisə Axtaris_Istek adlı EventHandler tipindədir.
    /// Qeyd: bu hadisə presenter tərəfindən istifadə olunur.
    /// </summary>
    public event EventHandler Axtaris_Istek;

    /// <summary>
    /// məhsulları DataGridView-də göstərmək üçün istifadə olunur.
    /// Diqqət: bu metod DataGridView-nin DataSource xüsusiyyətini təyin edir.
    /// QEYD - DataSource null ola bilməz, buna görə də null yoxlaması aparılır. Cədvəl boş olduqda belə işləyir.
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
    /// mesaj göstərmək və istifadəçi reaksiyasını almaq üçün istifadə olunur.
    /// diqət: bu metod MessageBox.Show metodunu çağırır. və nəticəni qaytarır. bu nəticə DialogResult tipindədir.
    /// qeyd - bu metod presenter tərəfindən istifadə olunur.
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
    /// MehsulIdareetmeFormu yükləndikdə baş verən hadisə.
    /// diqət: bu hadisə FormYuklendi_Istek adlı EventHandler tipindədir.
    /// qeyd: bu hadisə presenter tərəfindən istifadə olunur.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MehsulIdareetmeFormu_Load(object sender, EventArgs e)
    {
        FormYuklendi_Istek?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// btnElaveEt düyməsinə kliklənildikdə baş verən hadisə.
    /// diqət: bu hadisə MehsulElaveEt_Istek adlı EventHandler tipindədir.
    /// qeyd: bu hadisə presenter tərəfindən istifadə olunur.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnElaveEt_Click(object sender, EventArgs e)
    {
        MehsulElaveEt_Istek?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// btnYenile düyməsinə kliklənildikdə baş verən hadisə.
    /// diqət: bu hadisə MehsulYenile_Istek adlı EventHandler tipindədir.
    /// qeyd: bu hadisə presenter tərəfindən istifadə olunur.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnYenile_Click(object sender, EventArgs e)
    {
        MehsulYenile_Istek?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// btnSil düyməsinə kliklənildikdə baş verən hadisə.
    /// diqət: bu hadisə MehsulSil_Istek adlı EventHandler tipindədir.
    /// qeyd: bu hadisə presenter tərəfindən istifadə olunur.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSil_Click(object sender, EventArgs e)
    {
        MehsulSil_Istek?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// btnTemizle düyməsinə kliklənildikdə baş verən hadisə.
    /// diqət: bu hadisə FormuTemizle_Istek adlı EventHandler tipindədir.
    /// qeyd: bu hadisə presenter tərəfindən istifadə olunur.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnTemizle_Click(object sender, EventArgs e)
    {
        FormuTemizle_Istek?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// dgvMehsullar cədvəlində seçim dəyişdikdə baş verən hadisə.
    /// diqət: bu hadisə CedvelSecimiDeyisdi_Istek adlı EventHandler tipindədir.
    /// qeyd: bu hadisə presenter tərəfindən istifadə olunur.
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
    /// txtAxtar mətnində dəyişiklik olduqda baş verən hadisə.
    /// diqət: bu hadisə Axtaris_Istek adlı EventHandler tipindədir.
    /// qeyd: bu hadisə presenter tərəfindən istifadə olunur.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void txtAxtar_TextChanged(object sender, EventArgs e)
    {
        Axtaris_Istek?.Invoke(this, EventArgs.Empty);
    }
    #endregion
}