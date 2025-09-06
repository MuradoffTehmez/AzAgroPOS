// Fayl: AzAgroPOS.Teqdimat/NovbeIdareetmesiFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.Idareciler;
// using-lər...
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Teqdimat.Yardimcilar;
using System;
using System.Windows.Forms;
/// <summary>
///  bu class, növbə idarəetməsi üçün istifadə olunan formu təmsil edir.
///  diqqət - bu form, MaterialSkin kitabxanasından MaterialForm sinifindən törədilmişdir.
///  qeyd - bu form, INovbeView interfeysini həyata keçirir və növbə əməliyyatlarını idarə etmək üçün NovbePresenter ilə əlaqələndirilir.
/// </summary>
public partial class NovbeIdareetmesiFormu : BazaForm, INovbeView
{
    /// <summary>
    /// növbə əməliyyatlarını idarə etmək üçün istifadə olunan presenter.
    /// diqqət - bu presenter, INovbeView interfeysini alır və NovbeManager ilə əlaqələndirir.
    /// qeyd - bu presenter, növbə açmaq, bağlamaq və hesabat göstərmək üçün metodlar və hadisələr təyin edir.
    /// </summary>
    private readonly NovbePresenter _presenter;
    /// <summary>
    /// NovbeIdareetmesiFormu konstruktoru, formu ilkin vəziyyətə gətirir və presenter-i yaradır.
    /// diqqət - InitializeComponent metodu, formun komponentlərini ilkin vəziyyətə gətirir.
    /// qeyd - NovbePresenter, INovbeView interfeysini alır və növbə əməliyyatlarını idarə etmək üçün NovbeManager ilə əlaqələndirir.
    /// </summary>
    public NovbeIdareetmesiFormu(NovbeManager novbeManager, IstifadeciManager istifadeciManager)
    {
        InitializeComponent();
        _presenter = new NovbePresenter(this, novbeManager, istifadeciManager);
    }
    /// <summary>
    /// Başlanğıc məbləği, növbə açmaq üçün istifadə olunan məbləğdir.
    /// diqqət - bu məbləğ, istifadəçi tərəfindən txtBaslangicMebleg adlı TextBox-a daxil edilir.
    /// qeyd - əgər daxil edilən məbləğ düzgün formatda deyilsə, 0 qaytarılır.
    /// </summary>
    public decimal BaslangicMebleg => decimal.TryParse(txtBaslangicMebleg.Text, out var m) ? m : 0;
    /// <summary>
    /// Faktiki məbləğ, növbə bağlamaq üçün istifadə olunan məbləğdir.
    /// Diqqət - bu məbləğ, istifadəçi tərəfindən txtFaktikiMebleg adlı TextBox-a daxil edilir.
    /// Qeyd - əgər daxil edilən məbləğ düzgün formatda deyilsə, 0 qaytarılır.
    /// </summary>
    public decimal FaktikiMebleg => decimal.TryParse(txtFaktikiMebleg.Text, out var m) ? m : 0;
    /// <summary>
    /// Növbə açmaq üçün istifadə olunan hadisə.
    /// Diqqət - bu hadisə, istifadəçi btnNovbeAc adlı düyməni kliklədikdə tetiklenir.
    /// Qeyd - bu hadisə, NovbePresenter tərəfindən dinlənilir və növbə açmaq üçün istifadə olunur.
    /// </summary>
    public event EventHandler NovbeAc_Istek;
    /// <summary>
    /// Növbə bağlamaq üçün istifadə olunan hadisə.
    /// Diqqət - bu hadisə, istifadəçi btnNovbeBagla adlı düyməni kliklədikdə tetiklenir.
    /// Qeyd - bu hadisə, NovbePresenter tərəfindən dinlənilir və növbə bağlamaq üçün istifadə olunur.
    /// </summary>
    public event EventHandler NovbeBagla_Istek;
    /// <summary>
    /// Növbənin açıq olduğunu göstərir.
    /// Diqqət - bu metod, istifadəçi adı və açılış tarixini qəbul edir və lblNovbeMelumat adlı Label-a göstərir.
    /// Qeyd - əgər bu metod başqa bir iplikdən çağırılırsa, Invoke metodu ilə əsas iplikdə çağırılır.
    /// TARIX FORMAT: dd.MM.yyyy HH:mm
    /// açılışTarixi - növbənin açıldığı tarix və saatı göstərir.
    /// </summary>
    /// <param name="isci"></param>
    /// <param name="acilisTarixi"></param>
    public void NovbeAciqdirGoster(string isci, DateTime acilisTarixi)
    {
        if (this.InvokeRequired) { this.Invoke(() => NovbeAciqdirGoster(isci, acilisTarixi)); return; }
        cardNovbeAc.Visible = false;
        cardNovbeBagla.Visible = true;
        lblNovbeMelumat.Text = $"{isci} tərəfindən {acilisTarixi:dd.MM.yyyy HH:mm}-də açılmış növbə aktivdir.";
    }
    /// <summary>
    /// növbənin bağlandığını göstərir.
    /// diqqət - bu metod, cardNovbeAc adlı kartı görünən edir və cardNovbeBagla adlı kartı gizlədir.
    /// qeyd - əgər bu metod başqa bir iplikdən çağırılırsa, Invoke metodu ilə əsas iplikdə çağırılır.
    /// </summary>
    public void NovbeBaxlidirGoster()
    {
        if (this.InvokeRequired) { this.Invoke(() => NovbeBaxlidirGoster()); return; }
        cardNovbeAc.Visible = true;
        cardNovbeBagla.Visible = false;
        txtFaktikiMebleg.Text = "0";
        txtBaslangicMebleg.Text = "0";
    }
    /// <summary>
    /// hesabatı göstərir.
    /// diqqət - bu metod, hesabat mətnini qəbul edir və MessageBox ilə göstərir.
    /// qeyd - əgər bu metod başqa bir iplikdən çağırılırsa, Invoke metodu ilə əsas iplikdə çağırılır.
    /// </summary>
    /// <param name="hesabatMetni"></param>
    public void HesabatGoster(string hesabatMetni)
    {
        if (this.InvokeRequired) { this.Invoke(() => HesabatGoster(hesabatMetni)); return; }
        MessageBox.Show(hesabatMetni, "Z-Hesabatı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    /// <summary>
    /// btnNovbeAc düyməsi klikləndikdə tetiklenen hadisə.
    /// diqqət - bu metod, NovbeAc_Istek hadisəsini tetikler.
    /// qeyd - bu metod, növbə açmaq üçün istifadə olunur.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnNovbeAc_Click(object sender, EventArgs e) => NovbeAc_Istek?.Invoke(this, EventArgs.Empty);
    /// <summary>
    /// btnNovbeBagla düyməsi klikləndikdə tetiklenen hadisə.
    /// diqqət - bu metod, NovbeBagla_Istek hadisəsini tetikler.
    /// qeyd - bu metod, növbə bağlamaq üçün istifadə olunur.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnNovbeBagla_Click(object sender, EventArgs e) => NovbeBagla_Istek?.Invoke(this, EventArgs.Empty);
}