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

        public frmUsers()
        {
            InitializeComponent();
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
        }

        private void SetupUsersGrid()
        {
            if (dgvUsers.Columns.Count == 0) return;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Lazımsız və təhlükəli sütunları gizlədirik
            string[] hiddenColumns = { "Id", "RolId", "ParolHash", "ParolSalt", "SonGirisTarixi", "DeaktivasiyaTarixi" };
            foreach (var colName in hiddenColumns)
            {
                if (dgvUsers.Columns[colName] != null) dgvUsers.Columns[colName].Visible = false;
            }

            // Sütun başlıqlarını dəyişirik
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

            // Düymələrin vəziyyətini tənzimləyirik
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

            // Təhlükəsizlik üçün parol xanaları həmişə boş saxlanılır
            txtPassword.Clear();
            txtPasswordConfirm.Clear();

            // Düymələrin vəziyyətini tənzimləyirik
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

            bool result = _istifadeciBll.Add(user, txtPassword.Text, out string message);
            MessageBox.Show(message, result ? "Uğurlu" : "Xəta", MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (result)
            {
                LoadUsers();
                ClearForm();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == 0) return;

            // Əgər parol xanaları boş deyilsə, onların eyni olmasını yoxlayırıq
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

            // Əgər parol xanası boşdursa, BLL tərəfindən parol yenilənməyəcək
            bool result = _istifadeciBll.Update(user, txtPassword.Text, out string message);
            MessageBox.Show(message, result ? "Uğurlu" : "Xəta", MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (result)
            {
                LoadUsers();
                ClearForm();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == 0) return;

            // İstifadəçinin özünü silməsinin qarşısını alırıq
            if (Program.CurrentUser != null && Program.CurrentUser.Id == _selectedUserId)
            {
                MessageBox.Show("Sistemə daxil olan istifadəçi özünü silə bilməz.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Seçilmiş istifadəçini deaktiv etmək istədiyinizə əminsinizmi?", "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                bool opResult = _istifadeciBll.Delete(_selectedUserId, out string message);
                MessageBox.Show(message);
                if (opResult)
                {
                    LoadUsers();
                    ClearForm();
                }
            }
        }

        #endregion
    }
}