using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.PL.Services;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class UserAddForm : BaseForm
    {
        private readonly AuthService _authService;
        private readonly RolRepository _rolRepository;

        public UserAddForm() : base()
        {
            InitializeComponent();
            var context = new AzAgroDbContext();
            _authService = ServiceFactory.CreateAuthService();
            _rolRepository = new RolRepository(context);
            LoadRoles();
        }

        private async void LoadRoles()
        {
            try
            {
                var roles = await _rolRepository.GetAllAsync();
                cmbRole.DataSource = roles.Where(r => r.Status == "Aktiv").ToList();
                cmbRole.DisplayMember = "Ad";
                cmbRole.ValueMember = "Id";
                cmbRole.SelectedIndex = roles.Any(r => r.Ad == "İstifadəçi") ? 
                    roles.FindIndex(r => r.Ad == "İstifadəçi") : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rollar yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                btnSave.Enabled = false;
                btnSave.Text = "Saxlanılır...";

                string ad = txtAd.Text.Trim();
                string soyad = txtSoyad.Text.Trim();
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text;
                int rolId = (int)cmbRole.SelectedValue;

                var result = await _authService.CreateUserAsync(ad, soyad, email, password, rolId);

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
                MessageBox.Show($"Xəta baş verdi: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text = "Saxla";
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text))
            {
                MessageBox.Show("Ad mütləqdir.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAd.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                MessageBox.Show("Soyad mütləqdir.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoyad.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email ünvanını daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Email ünvanının formatı düzgün deyil.", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                txtEmail.SelectAll();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Şifrəni daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Şifrə ən azı 6 simvoldan ibarət olmalıdır.", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                txtPassword.SelectAll();
                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Şifrələr eyni deyil.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                txtConfirmPassword.SelectAll();
                return false;
            }

            if (cmbRole.SelectedValue == null)
            {
                MessageBox.Show("Rol seçin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRole.Focus();
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
            txtAd.Clear();
            txtSoyad.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 0;
            txtAd.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Formu təmizləmək istədiyinizə əminsiniz?", "Təsdiq", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClearForm();
            }
        }
    }
}