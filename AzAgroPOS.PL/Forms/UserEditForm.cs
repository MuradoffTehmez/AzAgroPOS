using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class UserEditForm : Form
    {
        private readonly IstifadeciRepository _istifadeciRepository;
        private readonly RolRepository _rolRepository;
        private readonly Istifadeci _user;

        public UserEditForm(Istifadeci user)
        {
            InitializeComponent();
            _istifadeciRepository = new IstifadeciRepository();
            _rolRepository = new RolRepository();
            _user = user;
            LoadUserData();
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
                
                if (_user.RolId.HasValue)
                {
                    cmbRole.SelectedValue = _user.RolId.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rollar yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserData()
        {
            txtAd.Text = _user.Ad;
            txtSoyad.Text = _user.Soyad;
            txtEmail.Text = _user.Email;
            
            cmbStatus.Items.AddRange(new[] { "Aktiv", "Deaktiv", "Bloklu" });
            cmbStatus.SelectedItem = _user.Status;
            
            lblUserId.Text = $"İstifadəçi ID: {_user.Id}";
            lblCreatedDate.Text = $"Yaradılma Tarixi: {_user.YaradilmaTarixi:dd.MM.yyyy HH:mm}";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                btnSave.Enabled = false;
                btnSave.Text = "Saxlanılır...";

                // Check if email changed and exists
                if (_user.Email != txtEmail.Text.Trim())
                {
                    if (await _istifadeciRepository.EmailExistsAsync(txtEmail.Text.Trim(), _user.Id))
                    {
                        MessageBox.Show("Bu email ünvanı başqa istifadəçi tərəfindən istifadə olunur.", 
                            "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                _user.Ad = txtAd.Text.Trim();
                _user.Soyad = txtSoyad.Text.Trim();
                _user.Email = txtEmail.Text.Trim();
                _user.Status = cmbStatus.SelectedItem.ToString();
                _user.RolId = (int)cmbRole.SelectedValue;

                await _istifadeciRepository.UpdateAsync(_user);

                MessageBox.Show("İstifadəçi məlumatları uğurla yeniləndi.", "Uğurlu", 
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

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Status seçin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}