using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.BLL.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class PasswordResetForm : BaseForm
    {
        private readonly AuthService _authService;
        private readonly Istifadeci _user;

        public PasswordResetForm(Istifadeci user) : base()
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
                    ShowSuccess(result.Message);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ShowWarning(result.Message);
                }
            }
            catch (Exception ex)
            {
                ShowError($"Gözlənilməz xəta baş verdi: {ex.Message}");
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
                ShowWarning("Yeni şifrəni daxil edin.");
                txtNewPassword.Focus();
                return false;
            }

            if (txtNewPassword.Text.Length < 8)
            {
                ShowWarning("Şifrə ən azı 8 simvoldan ibarət olmalıdır.");
                txtNewPassword.Focus();
                txtNewPassword.SelectAll();
                return false;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                ShowWarning("Şifrələr eyni deyil.");
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

            ShowInfo($"Avtomatik yaradılan şifrə: {generatedPassword}\n\nLütfən bu şifrəni istifadəçiyə çatdırın.");
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