using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class UserManagementForm : BaseForm
    {
        private readonly IstifadeciRepository _istifadeciRepository;
        private readonly RolRepository _rolRepository;
        private readonly AuthService _authService;
        private readonly AuditLogService _auditLogService;
        private List<Istifadeci> _filteredUsers;
        private int _currentPageNumber = 1;
        private const int PageSize = 100;

        public UserManagementForm(Istifadeci currentUser) : base()
        {
            InitializeComponent();
            var context = new AzAgroDbContext();
            _istifadeciRepository = new IstifadeciRepository(context);
            _rolRepository = new RolRepository(context);
            _authService = ServiceFactory.CreateAuthService();
            _auditLogService = ServiceFactory.CreateAuditLogService();
            _currentUser = currentUser;
            
            SetupDataGridView();
        }

        protected override async void OnFormLoad()
        {
            await LoadUsersAsync();
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

        private async Task LoadUsersAsync()
        {
            await ExecuteAsync(async () =>
            {
                lblStatus.Text = "İstifadəçilər yüklənir...";
                
                // Get filter values
                string searchTerm = txtSearch?.Text?.Trim();
                string status = cmbStatusFilter?.SelectedItem?.ToString();
                if (status == "Hamısı") status = null;
                
                int? rolId = null;
                if (cmbRoleFilter?.SelectedItem is Rol selectedRole)
                {
                    rolId = selectedRole.Id;
                }
                
                // Load filtered users from database
                _filteredUsers = await _istifadeciRepository.GetFilteredUsersAsync(
                    searchTerm, status, rolId, PageSize, _currentPageNumber);
                
                // Update DataGridView
                dgvUsers.DataSource = _filteredUsers;
                
                // Get total count for status display
                int totalCount = await _istifadeciRepository.GetFilteredUsersCountAsync(
                    searchTerm, status, rolId);
                
                lblStatus.Text = $"Cəmi {totalCount} istifadəçi (Səhifə {_currentPageNumber})";
            }, "İstifadəçilər yüklənərkən xəta baş verdi");
        }

        private async void LoadUsers()
        {
            await LoadUsersAsync();
        }

        private async void FilterUsers()
        {
            await LoadUsersAsync();
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
                    _notificationService.HandleError(ex, "Status dəyişdirilərkən xəta baş verdi");
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
                _notificationService.HandleError(ex, "Roller yüklənərkən xəta baş verdi");
            }
        }
    }
}