using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.PL.Forms;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;
        private readonly IstifadeciRepository _istifadeciRepository;

        public LoginForm()
        {
            InitializeComponent();
            _authService = new AuthService();
            _istifadeciRepository = new IstifadeciRepository();
        }

        private async void btnLogin_Click(object sender, System.EventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text;

                if (!ValidateInput(email, password))
                {
                    return;
                }

                btnLogin.Enabled = false;
                btnLogin.Text = "Yoxlanılır...";

                string netice = await _authService.LoginAsync(email, password);

                if (netice.Contains("Uğurlu"))
                {
                    // İstifadəçi məlumatlarını əldə et
                    var istifadeci = await _istifadeciRepository.GetByEmailAsync(email);
                    
                    if (istifadeci != null)
                    {
                        MessageBox.Show(netice, "Uğurlu Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Ana forma keç
                        this.Hide();
                        var mainForm = new MainForm(istifadeci);
                        mainForm.ShowDialog();
                        this.Show();
                        
                        // Form-u təmizlə
                        ClearForm();
                    }
                }
                else
                {
                    MessageBox.Show(netice, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Daxil Ol";
            }
        }

        private bool ValidateInput(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email ünvanını daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Şifrəni daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email ünvanının formatı düzgün deyil.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                txtEmail.SelectAll();
                return false;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Şifrə ən azı 6 simvoldan ibarət olmalıdır.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                txtPassword.SelectAll();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private void ClearForm()
        {
            txtEmail.Clear();
            txtPassword.Clear();
            txtEmail.Focus();
        }
    }
}
