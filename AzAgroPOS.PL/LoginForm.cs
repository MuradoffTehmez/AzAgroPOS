using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.PL.Forms;
using Microsoft.Win32;
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
            LoadSavedCredentials();
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
                        
                        // Remember Me funksiyasını yoxla
                        if (chkRememberMe.Checked)
                        {
                            SaveCredentials(email, password);
                        }
                        else
                        {
                            ClearSavedCredentials();
                        }
                        
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
            if (!chkRememberMe.Checked)
            {
                txtEmail.Clear();
                txtPassword.Clear();
            }
            else
            {
                txtPassword.Clear();
            }
            txtEmail.Focus();
        }
        
        private async void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string email = ShowInputDialog("Şifrəni sıfırlamaq üçün email ünvanınızı daxil edin:", 
                    "Şifrəni Unutmusan?", txtEmail.Text);

                if (string.IsNullOrWhiteSpace(email))
                    return;

                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Email ünvanının formatı düzgün deyil.", "Xəta", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var user = await _istifadeciRepository.GetByEmailAsync(email);
                if (user == null)
                {
                    MessageBox.Show("Bu email ünvanı ilə istifadəçi tapılmadı.", "Xəta", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var resetForm = new PasswordResetForm(user);
                if (resetForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Şifrəniz uğurla sıfırlandı. Yeni şifrə ilə daxil ola bilərsiniz.", 
                        "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta baş verdi: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private string ShowInputDialog(string text, string caption, string defaultValue = "")
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };
            
            Label textLabel = new Label() { Left = 20, Top = 20, Width = 350, Text = text };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 350, Text = defaultValue };
            Button confirmation = new Button() { Text = "Tamam", Left = 200, Width = 80, Top = 80, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Ləğv et", Left = 290, Width = 80, Top = 80, DialogResult = DialogResult.Cancel };
            
            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancel.Click += (sender, e) => { prompt.Close(); };
            
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;
            
            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
        
        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerForm = new UserAddForm();
            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Qeydiyyat uğurla tamamlandı. İndi daxil ola bilərsiniz.", 
                    "Uğurlu Qeydiyyat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void SaveCredentials(string email, string password)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AzAgroPOS"))
                {
                    key.SetValue("SavedEmail", email);
                    key.SetValue("SavedPassword", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password)));
                    key.SetValue("RememberMe", true);
                }
            }
            catch (Exception ex)
            {
                // Registry xətası olsa da davam et
                System.Diagnostics.Debug.WriteLine($"Registry xətası: {ex.Message}");
            }
        }
        
        private void LoadSavedCredentials()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AzAgroPOS"))
                {
                    if (key != null)
                    {
                        var savedEmail = key.GetValue("SavedEmail") as string;
                        var savedPasswordBase64 = key.GetValue("SavedPassword") as string;
                        var rememberMe = key.GetValue("RememberMe") as bool? ?? false;
                        
                        if (rememberMe && !string.IsNullOrEmpty(savedEmail) && !string.IsNullOrEmpty(savedPasswordBase64))
                        {
                            txtEmail.Text = savedEmail;
                            txtPassword.Text = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(savedPasswordBase64));
                            chkRememberMe.Checked = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registry xətası olsa da davam et
                System.Diagnostics.Debug.WriteLine($"Registry xətası: {ex.Message}");
                // Default məlumatları təyin et
                txtEmail.Text = "admin@azagropos.az";
                txtPassword.Text = "Admin123!";
            }
        }
        
        private void ClearSavedCredentials()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AzAgroPOS", true))
                {
                    if (key != null)
                    {
                        key.DeleteValue("SavedEmail", false);
                        key.DeleteValue("SavedPassword", false);
                        key.SetValue("RememberMe", false);
                    }
                }
            }
            catch (Exception ex)
            {
                // Registry xətası olsa da davam et
                System.Diagnostics.Debug.WriteLine($"Registry xətası: {ex.Message}");
            }
        }

        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            ClearSavedCredentials();
        }
    }
}
