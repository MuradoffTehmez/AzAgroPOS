using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class UserManagementForm : Form
    {
        private readonly IstifadeciRepository _istifadeciRepository;
        private readonly RolRepository _rolRepository;
        private readonly AuthService _authService;
        private readonly AuditLogService _auditLogService;
        private readonly Istifadeci _currentUser;
        private List<Istifadeci> _allUsers;

        public UserManagementForm(Istifadeci currentUser)
        {
            InitializeComponent();
            _istifadeciRepository = new IstifadeciRepository();
            _rolRepository = new RolRepository();
            _authService = new AuthService();
            _auditLogService = new AuditLogService();
            _currentUser = currentUser;
            
            LoadUsers();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;

            // Columns
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "Id", 
                HeaderText = "ID", 
                Width = 50,
                Visible = false
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "TamAd", 
                HeaderText = "Ad Soyad", 
                Width = 150
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "Email", 
                HeaderText = "Email", 
                Width = 200
            });

            var rolColumn = new DataGridViewTextBoxColumn 
            { 
                HeaderText = "Rol", 
                Width = 120
            };
            rolColumn.DataPropertyName = "Rol.Ad";
            dgvUsers.Columns.Add(rolColumn);

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "Status", 
                HeaderText = "Status", 
                Width = 80
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "YaradilmaTarixi", 
                HeaderText = "Yaradılma Tarixi", 
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" }
            });

            // Row color based on status
            dgvUsers.CellFormatting += DgvUsers_CellFormatting;
        }

        private void DgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvUsers.Columns[e.ColumnIndex].HeaderText == "Status")
            {
                var user = dgvUsers.Rows[e.RowIndex].DataBoundItem as Istifadeci;
                if (user != null)
                {
                    switch (user.Status)
                    {
                        case "Aktiv":
                            dgvUsers.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                            break;
                        case "Deaktiv":
                            dgvUsers.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                            break;
                        case "Bloklu":
                            dgvUsers.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                            break;
                    }
                }
            }
        }

        private async void LoadUsers()
        {
            try
            {
                lblStatus.Text = "İstifadəçilər yüklənir...";
                _allUsers = await _istifadeciRepository.GetAllAsync();
                FilterUsers();
                lblStatus.Text = $"Cəmi {_allUsers.Count} istifadəçi";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İstifadəçilər yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Xəta baş verdi";
            }
        }

        private void FilterUsers()
        {
            if (_allUsers == null) return;

            var filteredUsers = _allUsers.AsEnumerable();

            // Status filter
            if (cmbStatusFilter.SelectedItem != null && cmbStatusFilter.SelectedItem.ToString() != "Hamısı")
            {
                filteredUsers = filteredUsers.Where(u => u.Status == cmbStatusFilter.SelectedItem.ToString());
            }

            // Role filter
            if (cmbRoleFilter.SelectedItem != null && cmbRoleFilter.SelectedItem.ToString() != "Hamısı")
            {
                filteredUsers = filteredUsers.Where(u => u.Rol?.Ad == cmbRoleFilter.SelectedItem.ToString());
            }

            // Search filter
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                var searchTerm = txtSearch.Text.ToLower();
                filteredUsers = filteredUsers.Where(u => 
                    u.Ad.ToLower().Contains(searchTerm) ||
                    u.Soyad.ToLower().Contains(searchTerm) ||
                    u.Email.ToLower().Contains(searchTerm)
                );
            }

            dgvUsers.DataSource = filteredUsers.ToList();
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            var addForm = new UserAddForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
                await _auditLogService.LogAsync(_currentUser.Id, "İstifadəçi", "Yeni istifadəçi əlavə edildi", GetClientInfo());
            }
        }

        private async void btnEditUser_Click(object sender, EventArgs e)
        {
            var selectedUser = GetSelectedUser();
            if (selectedUser == null)
            {
                MessageBox.Show("Redaktə etmək üçün istifadəçi seçin.", "Məlumat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var editForm = new UserEditForm(selectedUser);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
                await _auditLogService.LogAsync(_currentUser.Id, "İstifadəçi", 
                    $"İstifadəçi redaktə edildi: {selectedUser.Email}", GetClientInfo());
            }
        }

        private async void btnToggleStatus_Click(object sender, EventArgs e)
        {
            var selectedUser = GetSelectedUser();
            if (selectedUser == null)
            {
                MessageBox.Show("Status dəyişmək üçün istifadəçi seçin.", "Məlumat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (selectedUser.Id == _currentUser.Id)
            {
                MessageBox.Show("Öz statusunuzu dəyişə bilməzsiniz.", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newStatus = selectedUser.Status == "Aktiv" ? "Deaktiv" : "Aktiv";
            var result = MessageBox.Show($"İstifadəçinin statusunu '{newStatus}' etmək istədiyinizə əminsiniz?", 
                "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    selectedUser.Status = newStatus;
                    await _istifadeciRepository.UpdateAsync(selectedUser);
                    LoadUsers();
                    await _auditLogService.LogAsync(_currentUser.Id, "İstifadəçi", 
                        $"İstifadəçi statusu dəyişdirildi: {selectedUser.Email} -> {newStatus}", GetClientInfo());
                    MessageBox.Show("Status uğurla dəyişdirildi.", "Uğurlu", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Status dəyişdirilərkən xəta: {ex.Message}", "Xəta", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnResetPassword_Click(object sender, EventArgs e)
        {
            var selectedUser = GetSelectedUser();
            if (selectedUser == null)
            {
                MessageBox.Show("Şifrə sıfırlamaq üçün istifadəçi seçin.", "Məlumat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var resetForm = new PasswordResetForm(selectedUser);
            if (resetForm.ShowDialog() == DialogResult.OK)
            {
                await _auditLogService.LogAsync(_currentUser.Id, "İstifadəçi", 
                    $"İstifadəçi şifrəsi sıfırlandı: {selectedUser.Email}", GetClientInfo());
                MessageBox.Show("Şifrə uğurla sıfırlandı.", "Uğurlu", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterUsers();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterUsers();
        }

        private void cmbRoleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterUsers();
        }

        private Istifadeci GetSelectedUser()
        {
            if (dgvUsers.SelectedRows.Count == 0) return null;
            return dgvUsers.SelectedRows[0].DataBoundItem as Istifadeci;
        }

        private string GetClientInfo()
        {
            return $"IP: {System.Net.Dns.GetHostName()}, Platform: Windows";
        }

        private async void UserManagementForm_Load(object sender, EventArgs e)
        {
            // Load filter data
            cmbStatusFilter.Items.AddRange(new[] { "Hamısı", "Aktiv", "Deaktiv", "Bloklu" });
            cmbStatusFilter.SelectedIndex = 0;

            try
            {
                var roles = await _rolRepository.GetAllAsync();
                cmbRoleFilter.Items.Add("Hamısı");
                foreach (var role in roles.Where(r => r.Status == "Aktiv"))
                {
                    cmbRoleFilter.Items.Add(role.Ad);
                }
                cmbRoleFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Roller yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}