using AzAgroPOS.Entities;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    /// <summary>
    /// Əsas proqram pəncərəsi. Bütün digər formlar bu pəncərədən idarə olunur.
    /// </summary>
    public partial class frmMain : Form
    {
        // Cari daxil olmuş istifadəçi məlumatlarını saxlayır
        private readonly Istifadeci _currentUser;

        /// <summary>
        /// frmMain konstruktoru. Daxil olmuş istifadəçi məlumatlarını qəbul edir.
        /// </summary>
        /// <param name="user">Daxil olmuş istifadəçi obyekti</param>
        public frmMain(Istifadeci user)
        {
            InitializeComponent();
            _currentUser = user;
        }

        /// <summary>
        /// Form yüklənərkən işə düşən metod. İstifadəçi məlumatlarını göstərir və rol əsaslı giriş nəzarəti tətbiq edir.
        /// </summary>
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Status bar-da istifadəçi məlumatlarını göstərir (Ad, Soyad və Rol)
            lblCurrentUser.Text = $"İstifadəçi: {_currentUser.Ad} {_currentUser.Soyad} ({_currentUser.RolAdi})";

            // Admin olmayan istifadəçilər üçün tənzimləmələr menyusunu gizlədir
            if (_currentUser.RolAdi != "Admin")
            {
                tənzimləmələrToolStripMenuItem.Visible = false;
                // Digər rol əsaslı məhdudiyyətlər burada əlavə edilə bilər
            }
        }

        /// <summary>
        /// Fayl menyusundan Çıxış seçimi üçün hadisə handleri. Proqramı bağlayır.
        /// </summary>
        private void çıxışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
            
        /// <summary>
        /// Təmir menyu elementinə klik üçün hadisə handleri. Təmir formunu açar.
        /// </summary>
        private void təmirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRepairs repairForm = new frmRepairs(_currentUser);
            repairForm.ShowDialog();
        }

        /// <summary>
        /// Tənzimləmələr menyu elementinə klik üçün hadisə handleri. İstifadəçilər formunu açar.
        /// </summary>
        private void tənzimləmələrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers usersForm = new frmUsers(_currentUser);
            usersForm.ShowDialog();
        }

        /// <summary>
        /// Satış menyu elementinə klik üçün hadisə handleri. Satış formunu açar.
        /// </summary>
        private void satışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSales salesForm = new frmSales(_currentUser);
            salesForm.ShowDialog();
        }

        /// <summary>
        /// Hesabatlar menyu elementinə klik üçün hadisə handleri. Satış hesabatları formunu açar.
        /// </summary>
        private void hesabatlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesReport reportForm = new frmSalesReport();
            reportForm.ShowDialog();
        }

        /// <summary>
        /// Müştərilər menyu elementinə klik üçün hadisə handleri. Müştərilər formunu açar.
        /// </summary>
        private void müştərilərToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomers customersForm = new frmCustomers(_currentUser);
            customersForm.ShowDialog();
        }

        /// <summary>
        /// Anbar menyu elementinə klik üçün hadisə handleri. Məhsullar formunu açar.
        /// </summary>

        private void anbarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmProducts productsForm = new frmProducts(_currentUser);
            productsForm.ShowDialog();
        }
    }
}