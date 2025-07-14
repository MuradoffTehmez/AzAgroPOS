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
                
                btnSettings.Visible = isAdmin;
                btnReports.Visible = isManager;
                btnInventory.Visible = isManager;
                
                // Müştəri idarəetməsi və POS bütün istifadəçilər üçün görünür
                btnCustomerManagement.Visible = true;
                btnPOS.Visible = true;
                btnDashboard.Visible = true;
                
                // Initialize dashboard as default view
                dashboardPanel.Visible = true;
                customerSubmenu.Visible = false;
                btnDashboard.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            dashboardPanel.Visible = true;
            dashboardPanel.BringToFront();
            
            // Hide customer submenu
            customerSubmenu.Visible = false;
            
            // Update button appearance
            ResetButtonColors();
            btnDashboard.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
        }

        private void btnCustomerManagement_Click(object sender, EventArgs e)
        {
            customerSubmenu.Visible = !customerSubmenu.Visible;
            
            // Update button appearance
            ResetButtonColors();
            btnCustomerManagement.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
        }

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            var customerAddForm = new MusteriAddForm(_currentUser);
            customerAddForm.ShowDialog();
        }

        private void btnCustomerList_Click(object sender, EventArgs e)
        {
            var customerListForm = new MusteriManagementForm(_currentUser);
            customerListForm.ShowDialog();
        }

        private void btnCustomerGroups_Click(object sender, EventArgs e)
        {
            var customerGroupsForm = new MusteriGroupManagementForm(_currentUser);
            customerGroupsForm.ShowDialog();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            var productManagementForm = new ProductManagementForm(_currentUser);
            productManagementForm.ShowDialog();
        }

        private void ResetButtonColors()
        {
            btnDashboard.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            btnCustomerManagement.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            btnInventory.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            btnReports.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            btnSettings.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
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
            // Initialize dashboard with mock data
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            // Mock data for dashboard - In real implementation, this would come from services
            lblTotalCustomers.Text = "👥 Müştərilər\n\n1,234";
            lblTotalProducts.Text = "📦 Məhsullar\n\n567";
            lblTodaySales.Text = "🛒 Bugünkü Satış\n\n89";
            lblTotalValue.Text = "💰 Ümumi Dəyər\n\n₼12,345";
        }
    }
}