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
        private readonly Istifadeci _currentUser;
        private Form _activeForm = null;

        /// <summary>
        /// frmMain konstruktoru. Daxil olmuş istifadəçi məlumatlarını qəbul edir.
        /// </summary>
        /// <param name="user">Daxil olmuş istifadəçi obyekti</param>
        /// <exception cref="ArgumentNullException">user parametri null olduqda baş verir</exception>
        public frmMain(Istifadeci user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "İstifadəçi məlumatları boş ola bilməz");
            }

            InitializeComponent();
            _currentUser = user;
        }

        /// <summary>
        /// Form yüklənərkən işə düşən metod. İstifadəçi məlumatlarını göstərir və rol əsaslı giriş nəzarəti tətbiq edir.
        /// </summary>
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                // İstifadəçi məlumatlarını göstərir
                lblCurrentUser.Text = $"İstifadəçi: {_currentUser.Ad} {_currentUser.Soyad} ({_currentUser.RolAdi})";
                lblTitle.Text = "Ana Səhifə";

                // Rol əsaslı giriş nəzarəti
                if (_currentUser.RolAdi != "Admin")
                {
                    btnSettings.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Form yüklənərkən xəta baş verdi: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Verilmiş pəncərəni əsas məzmun panelinin içində açır.
        /// </summary>
        /// <param name="childForm">Açılacaq form</param>
        private void OpenFormInPanel(Form childForm)
        {
            try
            {
                if (childForm == null)
                {
                    throw new ArgumentNullException(nameof(childForm), "Açılacaq form boş ola bilməz");
                }

                // Əvvəlki formu bağlayır
                if (_activeForm != null)
                {
                    _activeForm.Close();
                }

                _activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;

                // Formu panelə əlavə edir
                panelMainContent.Controls.Add(childForm);
                panelMainContent.Tag = childForm;

                // Formu ön plana gətirir və başlıq mətnini yeniləyir
                childForm.BringToFront();
                childForm.Show();
                lblTitle.Text = childForm.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Form açıla bilmədi: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #region Sidebar Button Click Handlers

        /// <summary>
        /// Satış düyməsinə klik üçün hadisə handleri. Satış formunu açar.
        /// </summary>
        private void btnSales_Click_1(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmSales(_currentUser));
        }

        /// <summary>
        /// Anbar düyməsinə klik üçün hadisə handleri. Məhsullar formunu açar.
        /// </summary>
        private void btnProducts_Click_1(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmProducts(_currentUser));
        }

        /// <summary>
        /// Müştərilər düyməsinə klik üçün hadisə handleri. Müştərilər formunu açar.
        /// </summary>
        private void btnCustomers_Click_1(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmCustomers(_currentUser));
        }

        /// <summary>
        /// Təmir düyməsinə klik üçün hadisə handleri. Təmir formunu açar.
        /// </summary>
        private void btnRepairs_Click_1(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmRepairs(_currentUser));
        }

        /// <summary>
        /// Hesabatlar düyməsinə klik üçün hadisə handleri. Satış hesabatları formunu açar.
        /// </summary>
        private void btnReports_Click_1(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmSalesReport());
        }

        /// <summary>
        /// Tənzimləmələr düyməsinə klik üçün hadisə handleri. İstifadəçilər formunu açar.
        /// </summary>
        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmUsers(_currentUser));
        }

        #endregion

        #region Additional Functionality

        /// <summary>
        /// Satışı qaytarmaq üçün metod. Əlavə funksional kimi saxlanılıb.
        /// </summary>
        private void OpenReturnForm()
        {
            try
            {
                var returnForm = new frmReturn(_currentUser);
                returnForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satış qaytarılarkən xəta: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Əməliyyat jurnalını göstərmək üçün metod. Əlavə funksional kimi saxlanılıb.
        /// </summary>
        private void OpenAuditLogForm()
        {
            try
            {
                var logForm = new frmAuditLog();
                logForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Əməliyyat jurnalı açıla bilmədi: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion

        
    }
}