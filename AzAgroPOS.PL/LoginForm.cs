using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.PL.Forms;
using Microsoft.Win32;
using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;
        private readonly IstifadeciRepository _istifadeciRepository;
        private bool _isAutoLoginAttempted = false;

        public LoginForm()
        {
            InitializeComponent();
            var context = new AzAgroDbContext();
            _authService = new AuthService();
            _istifadeciRepository = new IstifadeciRepository(context);
            // Form yükləndikdə avtomatik giriş cəhdini yoxla
            this.Load += async (s, e) => await TryAutoLoginAsync();
        }

        private async Task TryAutoLoginAsync()
        {
            if (_isAutoLoginAttempted) return;
            _isAutoLoginAttempted = true;

            var savedToken = GetSavedToken();
            if (!string.IsNullOrEmpty(savedToken))
            {
                this.Enabled = false;
                lblTitle.Text = "Avtomatik giriş yoxlanılır...";

                var (success, user) = await _authService.LoginWithTokenAsync(savedToken);
                if (success)
                {
                    ShowMainForm(user);
                }
                else
                {
                    // Token səhvdirsə, təmizlə
                    ClearSavedToken();
                    // Əgər formda əvvəldən qalma məlumat varsa, onu yükləyək
                    LoadLastUserEmail();
                }

                this.Enabled = true;
                lblTitle.Text = "🌾 AzAgroPOS Sistemə Giriş";
            }
            else
            {
                LoadLastUserEmail();
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text;

                if (!ValidateInput(email, password)) return;

                btnLogin.Enabled = false;
                btnLogin.Text = "Yoxlanılır...";

                string loginResult = await _authService.LoginAsync(email, password);

                if (loginResult.Contains("Uğurlu"))
                {
                    var user = await _istifadeciRepository.GetByEmailAsync(email);
                    if (user != null)
                    {
                        if (chkRememberMe.Checked)
                        {
                            await HandleRememberMe(user);
                        }
                        else
                        {
                            // Əgər istifadəçi "Məni xatırla" seçimini ləğv edibsə, tokeni silirik
                            await ClearRememberMe(user);
                        }

                        SaveLastUserEmail(email); // Hər girişdə son emaili yadda saxla
                        ShowMainForm(user);
                    }
                }
                else
                {
                    MessageBox.Show(loginResult, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                btnLogin.Text = "🔑 Daxil Ol";
            }
        }

        private void ShowMainForm(Istifadeci user)
        {
            this.Hide();
            var mainForm = new MainForm(user);
            mainForm.ShowDialog();
            this.Close(); // Ana formadan sonra login formunu bağla
        }

        private async Task HandleRememberMe(Istifadeci user)
        {
            var token = GenerateSecureToken();
            user.RememberMeToken = token;
            user.RememberMeTokenExpiry = DateTime.Now.AddDays(30);
            await _istifadeciRepository.UpdateAsync(user);
            SaveTokenToRegistry(token);
        }

        private async Task ClearRememberMe(Istifadeci user)
        {
            user.RememberMeToken = null;
            user.RememberMeTokenExpiry = null;
            await _istifadeciRepository.UpdateAsync(user);
            ClearSavedToken();
        }

        #region Token and Registry Management
        private string GenerateSecureToken()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var tokenData = new byte[32];
                rng.GetBytes(tokenData);
                return Convert.ToBase64String(tokenData);
            }
        }

        private void SaveTokenToRegistry(string token)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AzAgroPOS"))
                {
                    key.SetValue("RememberMeToken", token);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Registry yazma xətası: {ex.Message}");
            }
        }

        private string GetSavedToken()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AzAgroPOS"))
                {
                    return key?.GetValue("RememberMeToken") as string;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Registry oxuma xətası: {ex.Message}");
                return null;
            }
        }

        private void ClearSavedToken()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AzAgroPOS", true))
                {
                    key?.DeleteValue("RememberMeToken", false);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Registry silmə xətası: {ex.Message}");
            }
        }

        private void SaveLastUserEmail(string email)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AzAgroPOS"))
                {
                    key.SetValue("LastEmail", email);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Registry yazma xətası: {ex.Message}");
            }
        }

        private void LoadLastUserEmail()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AzAgroPOS"))
                {
                    var lastEmail = key?.GetValue("LastEmail") as string;
                    if (!string.IsNullOrEmpty(lastEmail))
                    {
                        txtEmail.Text = lastEmail;
                        txtPassword.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Registry oxuma xətası: {ex.Message}");
            }
        }
        #endregion

        #region UI Event Handlers and Helpers
        private async void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string email = ShowInputDialog("Şifrəni sıfırlamaq üçün email ünvanınızı daxil edin:", "Şifrəni Unutmusan?", txtEmail.Text);
            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            {
                MessageBox.Show("Düzgün email ünvanı daxil edilməyib.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = await _istifadeciRepository.GetByEmailAsync(email);
            if (user == null)
            {
                MessageBox.Show("Bu email ünvanı ilə istifadəçi tapılmadı.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resetForm = new PasswordResetForm(user);
            resetForm.ShowDialog();
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerForm = new UserAddForm();
            registerForm.ShowDialog();
        }

        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            // This event handler is required by the designer
            // The checkbox logic is handled in the login button click event
        }

        private bool ValidateInput(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            {
                MessageBox.Show("Düzgün email ünvanı daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Şifrəni daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
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
            Button confirmation = new Button() { Text = "Tamam", Left = 200, Width = 80, Top = 90, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Ləğv et", Left = 290, Width = 80, Top = 90, DialogResult = DialogResult.Cancel };

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
        #endregion
    }
}