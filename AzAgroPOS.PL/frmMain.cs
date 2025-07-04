// Fayl: AzAgroPOS.PL/frmMain.cs

using AzAgroPOS.Entities;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class frmMain : Form
    {
        // Daxil olan istifadəçini yadda saxlamaq üçün private sahə.
        private readonly Istifadeci _currentUser;

        // Constructor daxil olan istifadəçini qəbul edir.
        public frmMain(Istifadeci loggedInUser)
        {
            InitializeComponent();
            _currentUser = loggedInUser;
        }

        // Forma yüklənərkən bu hadisə işə düşür.
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Status zolağındakı mətni yeniləyirik.
            // Dizayn tərəfində StatusStrip-ə əlavə etdiyiniz label-in adı "lblCurrentUser" olmalıdır.
            if (lblCurrentUser != null && _currentUser != null)
            {
                lblCurrentUser.Text = $"İstifadəçi: {_currentUser.Ad} {_currentUser.Soyad}";
            }
        }

        // Fayl -> Çıxış menyusuna kliklədikdə proqramı bağlayırıq.
        // Bunu etmək üçün frmMain dizayn pəncərəsində Fayl->Çıxış menyusuna iki dəfə klikləyib bu kodu yazın.
        private void çıxışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void anbarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmProducts productsForm = new frmProducts();
            productsForm.ShowDialog();
        }

        private void satışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSales salesForm = new frmSales(_currentUser);
            salesForm.ShowDialog();
        }

        private void müştərilərToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomers customersForm = new frmCustomers();
            customersForm.ShowDialog();
        }

        private void hesabatlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesReport reportForm = new frmSalesReport();
            reportForm.ShowDialog();
        }

        private void təmirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRepairs repairForm = new frmRepairs();
            repairForm.ShowDialog();
        }
    }
}