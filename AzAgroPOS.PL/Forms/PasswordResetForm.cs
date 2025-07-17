using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.BLL.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class PasswordResetForm : Form
    {
        private readonly AuthService _authService;
        private readonly Istifadeci _user;

        public PasswordResetForm(Istifadeci user)
        {
            InitializeComponent();
            _authService = ServiceFactory.CreateAuthService(); // AuthService-i yaradırıq
            _user = user;
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            lblUserInfo.Text = $"İstifadəçi: {_user.TamAd} ({_user.Email})";
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                btnReset.Enabled = false;
                btnReset.Text = "Gözləyin...";

                string newPassword = txtNewPassword.Text;

                // Əməliyyatı AuthService üzərindən edirik
                var result = await _authService.ResetPasswordAsync(_user.Id, newPassword);

                if (result.Success)
                {
                    MessageBox.Show(result.Message, "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gözlənilməz xəta baş verdi: {ex.Message}", "Sistem Xətası",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnReset.Enabled = true;
                btnReset.Text = "Şifrəni Sıfırla";
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("Yeni şifrəni daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return false;
            }

            if (txtNewPassword.Text.Length < 8)
            {
                MessageBox.Show("Şifrə ən azı 8 simvoldan ibarət olmalıdır.", "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                txtNewPassword.SelectAll();
                return false;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Şifrələr eyni deyil.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                txtConfirmPassword.SelectAll();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGeneratePassword_Click(object sender, EventArgs e)
        {
            string generatedPassword = GenerateRandomPassword();
            txtNewPassword.Text = generatedPassword;
            txtConfirmPassword.Text = generatedPassword;

            MessageBox.Show($"Avtomatik yaradılan şifrə: {generatedPassword}\n\nLütfən bu şifrəni istifadəçiyə çatdırın.",
                "Avtomatik Şifrə", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GenerateRandomPassword()
        {
            const string lowers = "abcdefghijklmnopqrstuvwxyz";
            const string uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";

            var random = new Random();
            var password = new StringBuilder();

            // Şifrənin mürəkkəblik tələblərinə cavab verməsini təmin edək
            password.Append(lowers[random.Next(lowers.Length)]);
            password.Append(uppers[random.Next(uppers.Length)]);
            password.Append(numbers[random.Next(numbers.Length)]);

            // Qalan simvolları təsadüfi əlavə edək
            const string allChars = lowers + uppers + numbers;
            for (int i = 3; i < 8; i++)
            {
                password.Append(allChars[random.Next(allChars.Length)]);
            }

            // Simvolları qarışdıraq
            return new string(password.ToString().ToCharArray().OrderBy(s => (random.Next(2) % 2) == 0).ToArray());
        }
    }
}