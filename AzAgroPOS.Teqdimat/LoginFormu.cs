using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat
{
    public partial class LoginFormu : BazaForm, ILoginView
    {
        private readonly LoginPresenter _presenter;
        public bool UgurluDaxilOlundu { get; set; } = false;
        public string IstifadeciAdi => txtIstifadeciAdi.Text;

        public string Parol => txtParol.Text;

        public event EventHandler DaxilOl_Istek;

        public LoginFormu(TehlukesizlikManager tehlukesizlikManager)
        {
            InitializeComponent();
            _presenter = new LoginPresenter(this, tehlukesizlikManager);
        }

        public void MesajGoster(string mesaj) => MessageBox.Show(mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void FormuBagla() => this.Close();

        private void btnDaxilOl_Click(object sender, EventArgs e) => DaxilOl_Istek?.Invoke(this, EventArgs.Empty);
    }
}