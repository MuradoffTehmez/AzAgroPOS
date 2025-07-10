using AzAgroPOS.BLL.Services;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
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

                // Əgər giriş uğurludursa, bu pəncərəni bağlayıb ana pəncərəni aça bilərik
                // Bu hissəni gələcəkdə əlavə edəcəyik.
            }
            catch (Exception ex)
            {
                // Gözlənilməyən bir xəta baş verərsə
                MessageBox.Show($"Xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
