using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;

namespace AzAgroPOS.Teqdimat
{
    public partial class LoginFormu : BazaForm, ILoginView
    {
        private readonly LoginPresenter _presenter;
        public bool UgurluDaxilOlundu { get; set; } = false;
        public string IstifadeciAdi => txtIstifadeciAdi.Text;

        public string Parol => txtParol.Text;

        public event EventHandler DaxilOl_Istek;

        public LoginFormu(LoginPresenter loginPresenter)
        {
            InitializeComponent();
            _presenter = loginPresenter;
        }

        public void MesajGoster(string mesaj) => MessageBox.Show(mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void FormuBagla() => this.Close();

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

        private void btnDaxilOl_Click(object sender, EventArgs e) => DaxilOl_Istek?.Invoke(this, EventArgs.Empty);
    }
}