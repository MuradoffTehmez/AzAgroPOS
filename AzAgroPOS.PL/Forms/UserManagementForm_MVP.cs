using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.PL.Interfaces;
using AzAgroPOS.PL.Presenters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    /// <summary>
    /// MVP Pattern - User Management Form (View)
    /// Bu form yalnız UI elementlərini idarə edir və bütün biznes məntiqi Presenter-də yerləşir
    /// </summary>
    public partial class UserManagementForm : BaseForm, IUserManagementView
    {
        private UserManagementPresenter _presenter;
        private bool _disposed = false;

        public UserManagementForm(Istifadeci currentUser) : base()
        {
            InitializeComponent();
            _currentUser = currentUser;
            
            SetupDataGridView();
            InitializePresenter();
        }

        #region IUserManagementView Implementation

        // Properties
        public string SearchTerm 
        { 
            get => txtSearch?.Text?.Trim(); 
            set { if (txtSearch != null) txtSearch.Text = value; } 
        }

        public string StatusFilter 
        { 
            get => cmbStatusFilter?.SelectedItem?.ToString(); 
            set { if (cmbStatusFilter != null) cmbStatusFilter.SelectedItem = value; } 
        }

        public string RoleFilter 
        { 
            get => cmbRoleFilter?.SelectedItem?.ToString(); 
            set { if (cmbRoleFilter != null) cmbRoleFilter.SelectedItem = value; } 
        }

        public string StatusMessage 
        { 
            get => lblStatus?.Text; 
            set { if (lblStatus != null) lblStatus.Text = value; } 
        }

        public int CurrentPage { get; set; } = 1;

        public List<Istifadeci> UserList 
        { 
            set 
            { 
                if (dgvUsers != null) 
                    dgvUsers.DataSource = value; 
            } 
        }

        public List<string> StatusFilterOptions 
        { 
            set 
            { 
                if (cmbStatusFilter != null) 
                {
                    cmbStatusFilter.Items.Clear();
                    cmbStatusFilter.Items.AddRange(value.ToArray());
                    if (cmbStatusFilter.Items.Count > 0) cmbStatusFilter.SelectedIndex = 0;
                }
            } 
        }

        public List<string> RoleFilterOptions 
        { 
            set 
            { 
                if (cmbRoleFilter != null) 
                {
                    cmbRoleFilter.Items.Clear();
                    cmbRoleFilter.Items.AddRange(value.ToArray());
                    if (cmbRoleFilter.Items.Count > 0) cmbRoleFilter.SelectedIndex = 0;
                }
            } 
        }

        // Events
        public event Action LoadUsersEvent;
        public event Action RefreshEvent;
        public event Action SearchEvent;
        public event Action FilterChangedEvent;
        public event Action<Istifadeci> AddUserEvent;
        public event Action<Istifadeci> EditUserEvent;
        public event Action<Istifadeci> ToggleStatusEvent;
        public event Action<Istifadeci> ResetPasswordEvent;

        // Methods
        public void ShowMessage(string message, string title = "Məlumat", MessageType messageType = MessageType.Information)
        {
            MessageBoxIcon icon = MessageBoxIcon.Information;
            switch (messageType)
            {
                case MessageType.Warning:
                    icon = MessageBoxIcon.Warning;
                    break;
                case MessageType.Error:
                    icon = MessageBoxIcon.Error;
                    break;
                case MessageType.Success:
                    icon = MessageBoxIcon.Information;
                    break;
                case MessageType.Question:
                    icon = MessageBoxIcon.Question;
                    break;
            }
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        public void ShowError(string error)
        {
            ShowMessage(error, "Xəta", MessageType.Error);
        }

        public void ShowSuccess(string message)
        {
            ShowMessage(message, "Uğurlu", MessageType.Success);
        }

        public bool ShowConfirmation(string message, string title = "Təsdiq")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public void EnableControls(bool enabled)
        {
            if (dgvUsers != null) dgvUsers.Enabled = enabled;
            if (txtSearch != null) txtSearch.Enabled = enabled;
            if (cmbStatusFilter != null) cmbStatusFilter.Enabled = enabled;
            if (cmbRoleFilter != null) cmbRoleFilter.Enabled = enabled;
            if (btnAddUser != null) btnAddUser.Enabled = enabled;
            if (btnEditUser != null) btnEditUser.Enabled = enabled;
            if (btnToggleStatus != null) btnToggleStatus.Enabled = enabled;
            if (btnResetPassword != null) btnResetPassword.Enabled = enabled;
            if (btnRefresh != null) btnRefresh.Enabled = enabled;
        }

        public void SetLoadingState(bool isLoading)
        {
            EnableControls(!isLoading);
            if (isLoading)
            {
                this.Cursor = Cursors.WaitCursor;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        public Istifadeci GetSelectedUser()
        {
            if (dgvUsers?.SelectedRows.Count == 0) return null;
            return dgvUsers.SelectedRows[0].DataBoundItem as Istifadeci;
        }

        public void RefreshUserList()
        {
            LoadUsersEvent?.Invoke();
        }

        public void UpdateStatusMessage(string message)
        {
            StatusMessage = message;
        }

        public void CloseView()
        {
            this.Close();
        }

        public void OpenAddUserDialog()
        {
            var addForm = new UserAddForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsersEvent?.Invoke();
            }
        }

        public void OpenEditUserDialog(Istifadeci user)
        {
            var editForm = new UserEditForm(user);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsersEvent?.Invoke();
            }
        }

        public void OpenPasswordResetDialog(Istifadeci user)
        {
            var resetForm = new PasswordResetForm(user);
            if (resetForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsersEvent?.Invoke();
            }
        }

        #endregion

        #region Private Methods

        private void InitializePresenter()
        {
            try
            {
                // Create dependencies
                var context = new AzAgroDbContext();
                var istifadeciRepository = new IstifadeciRepository(context);
                var rolRepository = new RolRepository(context);
                var authService = ServiceFactory.CreateAuthService();
                var auditLogService = ServiceFactory.CreateAuditLogService();

                // Create presenter
                _presenter = new UserManagementPresenter(
                    this, 
                    istifadeciRepository, 
                    rolRepository, 
                    authService, 
                    auditLogService, 
                    _currentUser);
            }
            catch (Exception ex)
            {
                ShowError($"Presenter yaradılarkən xəta: {ex.Message}");
            }
        }

        private void SetupDataGridView()
        {
            if (dgvUsers == null) return;

            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;

            // Clear existing columns
            dgvUsers.Columns.Clear();

            // Add columns
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

        #endregion

        #region Event Handlers

        protected override async void OnFormLoad()
        {
            await _presenter?.InitializeAsync();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUserEvent?.Invoke(null);
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            EditUserEvent?.Invoke(GetSelectedUser());
        }

        private void btnToggleStatus_Click(object sender, EventArgs e)
        {
            ToggleStatusEvent?.Invoke(GetSelectedUser());
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            ResetPasswordEvent?.Invoke(GetSelectedUser());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshEvent?.Invoke();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchEvent?.Invoke();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterChangedEvent?.Invoke();
        }

        private void cmbRoleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterChangedEvent?.Invoke();
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            LoadUsersEvent?.Invoke();
        }

        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _presenter?.Dispose();
                }
                _disposed = true;
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}