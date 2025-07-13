using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class PasswordResetForm : Form
    {
        private readonly IstifadeciRepository _istifadeciRepository;
        private readonly Istifadeci _user;

        public PasswordResetForm(Istifadeci user)
        {
            InitializeComponent();
            _istifadeciRepository = new IstifadeciRepository();
            _user = user;
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            lblUserInfo.Text = $"İstifadəçi: {_user.TamAd} ({_user.Email})";
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                btnReset.Enabled = false;
                btnReset.Text = "Saxlanılır...";

                string newPassword = txtNewPassword.Text;
                string hashedPassword = ComputeSha256Hash(newPassword);

                _user.ParolHash = hashedPassword;
                await _istifadeciRepository.UpdateAsync(_user);

                MessageBox.Show("Şifrə uğurla sıfırlandı.", "Uğurlu", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta baş verdi: {ex.Message}", "Xəta", 
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

            if (txtNewPassword.Text.Length < 6)
            {
                MessageBox.Show("Şifrə ən azı 6 simvoldan ibarət olmalıdır.", "Xəta", 
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

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
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
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#$%";
            var random = new Random();
            var password = new StringBuilder();
            
            for (int i = 0; i < 8; i++)
            {
                password.Append(chars[random.Next(chars.Length)]);
            }
            
            return password.ToString();
        }
    }
}