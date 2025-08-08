// Fayl: AzAgroPOS.Teqdimat/LoginFormu.cs
namespace AzAgroPOS.Teqdimat;
// using-lər
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;

public partial class LoginFormu : BazaForm, ILoginView
{
    public bool UgurluDaxilOlundu { get; set; } = false;
    private readonly LoginPresenter _presenter;

    public LoginFormu()
    {
        InitializeComponent();
        _presenter = new LoginPresenter(this);
    }

    public string IstifadeciAdi => txtIstifadeciAdi.Text;
    public string Parol => txtParol.Text;

    public event EventHandler DaxilOl_Istek;

    public void MesajGoster(string mesaj) => MessageBox.Show(mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
    public void FormuBagla() => this.Close();

    private void btnDaxilOl_Click(object sender, EventArgs e) => DaxilOl_Istek?.Invoke(this, EventArgs.Empty);
}