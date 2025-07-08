using AzAgroPOS.BLL;
using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities;
using AzAgroPOS.PL.Themes;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class frmLogin : BaseForm
    {
        private readonly IstifadeciBLL _istifadeciBll = new IstifadeciBLL();

        /// <summary>
        /// Uğurla daxil olan istifadəçini yadda saxlamaq üçün public xüsusiyyət.
        /// Program.cs bu xüsusiyyətdən istifadə edəcək.
        /// </summary>
        public Istifadeci LoggedInUser { get; private set; }

        public frmLogin()
        {
            InitializeComponent();

            //// Düymələrimizə stil kateqoriyası veririk ki, BaseForm onları rəngləsin
            //btnLogin.Tag = "Success";
            //btnCancel.Tag = "Secondary";
        }

        /// <summary>
        /// BaseForm-dan gələn bu metod, pəncərədəki bütün mətnləri resurs faylından götürür.
        /// </summary>
        protected override void ApplyLocalization()
        {
            //try
            //{
            //    this.Text = Lang.frmLogin_Title;
            //    lblUsername.Text = Lang.UsernameLabel;
            //    lblPassword.Text = Lang.PasswordLabel;
            //    btnLogin.Text = Lang.LoginButtonText;
            //    btnCancel.Text = Lang.CancelButtonText;
            //}
            //catch (Exception ex)
            //{
            //    // Resurs faylında hər hansı bir açar söz tapılmasa, xətanı görmək üçün
            //    MessageBox.Show("Lokalizasiya faylında xəta var: " + ex.Message);
            //}
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // BLL-dəki AuthService-dən bir nümunə yaradırıq
                var authService = new AuthService();

                // TextBox-lardan dəyərləri götürürük
                string email = txtEmail.Text;
                string password = txtPassword.Text;

                // Login metodunu çağırıb nəticəni alırıq
                string netice = authService.Login(email, password);

                // Nəticəni istifadəçiyə göstəririk
                MessageBox.Show(netice, "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Gözlənilməyən bir xəta baş verərsə
                MessageBox.Show($"Xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




            //// 1. TextBox-lardan dəyərləri götürürük
            //string username = txtEmail.Text.Trim();
            //string password = txtPassword.Text;

            //// 2. Sadə yoxlama (boş olmasın)
            //if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            //{
            //    MessageBox.Show(Lang.Login_CredentialsCannotBeEmpty, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //// 3. BLL-dəki Login metodunu çağırırıq
            //Istifadeci user = _istifadeciBll.Login(username, password);

            //// 4. Nəticəni yoxlayırıq
            //if (user != null)
            //{
            //    // Giriş uğurludursa, istifadəçi obyektini public xüsusiyyətə mənimsədirik
            //    this.LoggedInUser = user;
            //    // Formanın nəticəsini OK olaraq təyin edirik ki, Program.cs bunu bilsin
            //    this.DialogResult = DialogResult.OK;
            //    this.Close();
            //}
            //else
            //{
            //    // Giriş uğursuzdur!
            //    MessageBox.Show(Lang.Login_InvalidCredentials, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}