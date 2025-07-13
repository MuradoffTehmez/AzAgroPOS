using AzAgroPOS.Entities.Domain;
using AzAgroPOS.PL.Forms;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class MainForm : Form
    {
        private readonly Istifadeci _currentUser;

        public MainForm(Istifadeci currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            if (_currentUser != null)
            {
                lblWelcome.Text = $"Xoş gəldiniz, {_currentUser.TamAd}";
                lblRole.Text = $"Rol: {_currentUser.Rol?.Ad ?? "Təyin edilməyib"}";
                
                // Admin roluna əsasən menyu elementlərini göstər/gizlət
                bool isAdmin = _currentUser.Rol?.Ad == "Administrator";
                bool isManager = _currentUser.Rol?.Ad == "Menecer" || isAdmin;
                
                btnUserManagement.Visible = isAdmin;
                btnRoleManagement.Visible = isAdmin;
                btnAddUser.Visible = isAdmin;
                btnCategoryManagement.Visible = isAdmin;
                btnSettings.Visible = isAdmin;
                
                // Məhsul və anbar idarəetməsi bütün istifadəçilər üçün görünür
                btnProductManagement.Visible = true;
                btnWarehouseManagement.Visible = isManager;
                
                // Yeni modullar
                btnDebtManagement.Visible = isManager;
                btnRepairManagement.Visible = true;
                btnPOS.Visible = true;
                btnReports.Visible = isManager;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var userAddForm = new UserAddForm();
            userAddForm.ShowDialog();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            var userManagementForm = new UserManagementForm(_currentUser);
            userManagementForm.ShowDialog();
        }

        private void btnRoleManagement_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rol idarəetməsi funksiyası tezliklə əlavə ediləcək.", 
                "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnProductManagement_Click(object sender, EventArgs e)
        {
            var productManagementForm = new ProductManagementForm(_currentUser);
            productManagementForm.ShowDialog();
        }

        private void btnCategoryManagement_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kateqoriya idarəetməsi funksiyası tezliklə əlavə ediləcək.", 
                "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnWarehouseManagement_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Anbar idarəetməsi funksiyası tezliklə əlavə ediləcək.", 
                "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDebtManagement_Click(object sender, EventArgs e)
        {
            var debtManagementForm = new BorcManagementForm(_currentUser);
            debtManagementForm.ShowDialog();
        }

        private void btnRepairManagement_Click(object sender, EventArgs e)
        {
            var repairManagementForm = new TamirManagementForm(_currentUser);
            repairManagementForm.ShowDialog();
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            var posForm = new POSForm();
            posForm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hesabatlar funksiyası tezliklə əlavə ediləcək.", 
                "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Parametrlər funksiyası tezliklə əlavə ediləcək.", 
                "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sistemdən çıxmaq istədiyinizə əminsiniz?", "Təsdiq", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                var loginForm = new LoginForm();
                loginForm.ShowDialog();
                this.Close();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}