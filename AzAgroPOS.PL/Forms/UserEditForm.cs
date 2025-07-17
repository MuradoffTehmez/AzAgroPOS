using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class UserEditForm : BaseForm
    {
        private readonly IstifadeciRepository _istifadeciRepository;
        private readonly RolRepository _rolRepository;
        private readonly Istifadeci _user;

        public UserEditForm(Istifadeci user) : base()
        {
            InitializeComponent();
            var context = new AzAgroDbContext();
            _istifadeciRepository = new IstifadeciRepository(context);
            _rolRepository = new RolRepository(context);
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
                ShowError($"Rollar yüklənərkən xəta: {ex.Message}");
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
                        ShowWarning("Bu email ünvanı başqa istifadəçi tərəfindən istifadə olunur.");
                        return;
                    }
                }

                _user.Ad = txtAd.Text.Trim();
                _user.Soyad = txtSoyad.Text.Trim();
                _user.Email = txtEmail.Text.Trim();
                _user.Status = cmbStatus.SelectedItem.ToString();
                _user.RolId = (int)cmbRole.SelectedValue;

                await _istifadeciRepository.UpdateAsync(_user);

                ShowSuccess("İstifadəçi məlumatları uğurla yeniləndi.");
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ShowError($"Xəta baş verdi: {ex.Message}");
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
                ShowWarning("Ad mütləqdir.");
                txtAd.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                ShowWarning("Soyad mütləqdir.");
                txtSoyad.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ShowWarning("Email ünvanını daxil edin.");
                txtEmail.Focus();
                return false;
            }

            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                ShowWarning("Email ünvanının formatı düzgün deyil.");
                txtEmail.Focus();
                txtEmail.SelectAll();
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                ShowWarning("Status seçin.");
                cmbStatus.Focus();
                return false;
            }

            if (cmbRole.SelectedValue == null)
            {
                ShowWarning("Rol seçin.");
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