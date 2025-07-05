using AzAgroPOS.BLL;
using AzAgroPOS.Entities;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class frmUsers : Form
    {
        private readonly IstifadeciBLL _istifadeciBll = new IstifadeciBLL();
        private readonly RolBLL _rolBll = new RolBLL();
        private int _selectedUserId = 0;
        private readonly Istifadeci _activeUser; // Pəncərəni açan istifadəçi

        public frmUsers(Istifadeci activeUser)
        {
            InitializeComponent();
            _activeUser = activeUser;
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRoles();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Məlumatlar yüklənərkən xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Köməkçi Metodlar

        private void LoadRoles()
        {
            cmbRole.DataSource = _rolBll.GetAll();
            cmbRole.DisplayMember = "Ad";
            cmbRole.ValueMember = "Id";
        }

        private void LoadUsers()
        {
            dgvUsers.DataSource = _istifadeciBll.GetAll();
            SetupUsersGrid();
            ClearForm();
        }

        private void SetupUsersGrid()
        {
            if (dgvUsers.Columns.Count == 0) return;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string[] hiddenColumns = { "Id", "RolId", "ParolHash", "ParolSalt", "SonGirisTarixi", "DeaktivasiyaTarixi" };
            foreach (var colName in hiddenColumns)
            {
                if (dgvUsers.Columns[colName] != null) dgvUsers.Columns[colName].Visible = false;
            }

            if (dgvUsers.Columns["Ad"] != null) dgvUsers.Columns["Ad"].HeaderText = "Ad";
            if (dgvUsers.Columns["Soyad"] != null) dgvUsers.Columns["Soyad"].HeaderText = "Soyad";
            if (dgvUsers.Columns["IstifadeciAdi"] != null) dgvUsers.Columns["IstifadeciAdi"].HeaderText = "İstifadəçi Adı";
            if (dgvUsers.Columns["RolAdi"] != null) dgvUsers.Columns["RolAdi"].HeaderText = "Rol";
            if (dgvUsers.Columns["Aktivdir"] != null) dgvUsers.Columns["Aktivdir"].HeaderText = "Aktivdir";
            if (dgvUsers.Columns["YaradilmaTarixi"] != null) dgvUsers.Columns["YaradilmaTarixi"].HeaderText = "Yaradılma Tarixi";
        }

        private void ClearForm()
        {
            _selectedUserId = 0;
            txtFirstName.Clear();
            txtLastName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtPasswordConfirm.Clear();
            if (cmbRole.Items.Count > 0) cmbRole.SelectedIndex = 0;
            chkIsActive.Checked = true;
            dgvUsers.ClearSelection();

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        #endregion

        #region Hadisə Metodları (Event Handlers)

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;

            var user = (Istifadeci)dgvUsers.CurrentRow.DataBoundItem;
            _selectedUserId = user.Id;

            txtFirstName.Text = user.Ad;
            txtLastName.Text = user.Soyad;
            txtUsername.Text = user.IstifadeciAdi;
            cmbRole.SelectedValue = user.RolId;
            chkIsActive.Checked = user.Aktivdir;

            txtPassword.Clear();
            txtPasswordConfirm.Clear();

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                MessageBox.Show("Daxil edilən parollar eyni deyil!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var user = new Istifadeci
            {
                Ad = txtFirstName.Text,
                Soyad = txtLastName.Text,
                IstifadeciAdi = txtUsername.Text,
                RolId = (int)cmbRole.SelectedValue,
                Aktivdir = chkIsActive.Checked
            };

            
            bool result = _istifadeciBll.Add(user, txtPassword.Text, _activeUser, out string message);
            MessageBox.Show(message, result ? "Uğurlu" : "Xəta", MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            if (result) { LoadUsers(); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == 0) return;

            if (!string.IsNullOrWhiteSpace(txtPassword.Text) && txtPassword.Text != txtPasswordConfirm.Text)
            {
                MessageBox.Show("Daxil edilən yeni parollar eyni deyil!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var user = new Istifadeci
            {
                Id = _selectedUserId,
                Ad = txtFirstName.Text,
                Soyad = txtLastName.Text,
                IstifadeciAdi = txtUsername.Text,
                RolId = (int)cmbRole.SelectedValue,
                Aktivdir = chkIsActive.Checked
            };

            bool result = _istifadeciBll.Update(user, txtPassword.Text, _activeUser, out string message);
            MessageBox.Show(message, result ? "Uğurlu" : "Xəta", MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Error);
           
            if (result) 
            {
                LoadUsers();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == 0)
            {
                MessageBox.Show("Silmək üçün cədvəldən istifadəçi seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_activeUser != null && _activeUser.Id == _selectedUserId)
            {
                MessageBox.Show("Sistemə daxil olan istifadəçi özünü silə (deaktiv edə) bilməz.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Seçilmiş istifadəçini deaktiv etmək istədiyinizə əminsinizmi?", "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                bool opResult = _istifadeciBll.Delete(_selectedUserId, _activeUser, out string message);
                MessageBox.Show(message);
                if (opResult)
                { 
                    LoadUsers(); 
                }
            }
        }

        #endregion
    }
}