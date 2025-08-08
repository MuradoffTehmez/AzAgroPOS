// Fayl: AzAgroPOS.Teqdimat/LoginFormu.cs
namespace AzAgroPOS.Teqdimat;

using System;
using System.Windows.Forms;
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
        // Yeni test düyməsinin click hadisəsinə abunə oluruq
        this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
    }

    public string IstifadeciAdi => txtIstifadeciAdi.Text;
    public string Parol => txtParol.Text;

    public event EventHandler DaxilOl_Istek;

    public void MesajGoster(string mesaj) => MessageBox.Show(mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
    public void FormuBagla() => this.Close();

    private void btnDaxilOl_Click(object sender, EventArgs e) => DaxilOl_Istek?.Invoke(this, EventArgs.Empty);

    /// <summary>
    /// Bu, bizim son diaqnostik testimizdir.
    /// </summary>
    private void btnTest_Click(object sender, EventArgs e)
    {
        // Daxil edilən parolu və əvvəlki testdə 100% işləyən hash-i götürürük
        string daxilEdilenParol = txtParol.Text; // Bu dəfə Trim() etmədən yoxlayaq
        string duzgunHash = "$2a$11$wvv2PHlk9LWlv4vuz3eEBl.ynUDwxFQSIHWle5nHfS3sL7hTkTQPG"; // "12345" üçün olan hash

        bool netice = false;
        string xeta = "Yoxdur";

        try
        {
            netice = BCrypt.Net.BCrypt.Verify(daxilEdilenParol, duzgunHash);
        }
        catch (Exception ex)
        {
            xeta = ex.Message;
        }

        MessageBox.Show(
            $"Daxil edilən parol: '{daxilEdilenParol}'\n" +
            $"Yoxlanılan Hash: '{duzgunHash}'\n\n" +
            $"Yoxlama Nəticəsi: {netice}\n" +
            $"Xəta: {xeta}",
            "Birbaşa Yoxlama Testi"
        );
    }
}