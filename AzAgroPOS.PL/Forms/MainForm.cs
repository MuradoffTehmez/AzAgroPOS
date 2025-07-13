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
                btnUserManagement.Visible = isAdmin;
                btnRoleManagement.Visible = isAdmin;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var userAddForm = new UserAddForm();
            userAddForm.ShowDialog();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            MessageBox.Show("İstifadəçi idarəetməsi funksiyası tezliklə əlavə ediləcək.", 
                "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRoleManagement_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rol idarəetməsi funksiyası tezliklə əlavə ediləcək.", 
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
    }
}