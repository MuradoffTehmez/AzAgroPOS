using AzAgroPOS.BLL;
using AzAgroPOS.Entities;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    /// <summary>
    /// Müştərilərin idarə edilməsi üçün form. Müştərilərin əlavə edilməsi, redaktə edilməsi, silinməsi və görüntülənməsi funksionallığını təmin edir.
    /// </summary>
    public partial class frmCustomers : Form
    {
        private readonly Istifadeci _currentUser;
        private readonly MusteriBLL _musteriBll = new MusteriBLL();
        private int _selectedCustomerId = 0;

        /// <summary>
        /// frmCustomers konstruktoru. Daxil olmuş istifadəçi məlumatlarını qəbul edir.
        /// </summary>
        /// <param name="currentUser">Daxil olmuş istifadəçi obyekti</param>
        public frmCustomers(Istifadeci currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }

        /// <summary>
        /// Form yüklənərkən işə düşən metod. Müştəri siyahısını yükləyir.
        /// </summary>
        private void frmCustomers_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        #region Helper Methods

        /// <summary>
        /// Müştəriləri yükləyir və DataGridView-a doldurur.
        /// </summary>
        private void LoadCustomers()
        {
            try
            {
                dgvCustomers.DataSource = _musteriBll.GetAll();
                SetupDataGridColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müştərilər yüklənərkən xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// DataGridView sütunlarını tənzimləyir. Gizlədilməsi lazım olan sütunları gizlədir.
        /// </summary>
        private void SetupDataGridColumns()
        {
            if (dgvCustomers.Columns["Id"] != null) dgvCustomers.Columns["Id"].Visible = false;
            // Digər gizlədilməli sütunlar burada əlavə edilə bilər
        }

        /// <summary>
        /// Form sahələrini təmizləyir və seçimləri sıfırlayır.
        /// </summary>
        private void ClearForm()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtTelefon.Clear();
            txtUnvan.Clear();
            txtEmail.Clear();
            txtNisyeLimiti.Text = "0.00";
            txtEndirimFaizi.Text = "0";
            txtQeyd.Clear();
            chkAktivdir.Checked = true;
            _selectedCustomerId = 0;
            dgvCustomers.ClearSelection();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// DataGridView-də seçim dəyişdikdə işə düşən metod. Seçilmiş müştərinin məlumatlarını form sahələrinə doldurur.
        /// </summary>
        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null) return;

            var musteri = (Musteri)dgvCustomers.CurrentRow.DataBoundItem;
            if (musteri == null) return;

            _selectedCustomerId = musteri.Id;
            txtAd.Text = musteri.Ad;
            txtSoyad.Text = musteri.Soyad;
            txtTelefon.Text = musteri.Telefon;
            txtUnvan.Text = musteri.Unvan;
            txtEmail.Text = musteri.Email;
            txtNisyeLimiti.Text = musteri.NisyeLimiti.ToString("F2");
            txtEndirimFaizi.Text = musteri.EndirimFaizi.ToString();
            txtQeyd.Text = musteri.Qeyd;
            chkAktivdir.Checked = musteri.Aktivdir;
        }

        /// <summary>
        /// Yeni müştəri əlavə etmək üçün düymə klik hadisəsi.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var musteri = new Musteri
                {
                    Ad = txtAd.Text,
                    Soyad = txtSoyad.Text,
                    Telefon = txtTelefon.Text,
                    Unvan = txtUnvan.Text,
                    Email = txtEmail.Text,
                    NisyeLimiti = decimal.Parse(txtNisyeLimiti.Text),
                    EndirimFaizi = decimal.Parse(txtEndirimFaizi.Text),
                    Qeyd = txtQeyd.Text,
                    Aktivdir = chkAktivdir.Checked
                };

                bool result = _musteriBll.Add(musteri, _currentUser, out string message);
                MessageBox.Show(message, result ? "Uğurlu" : "Xəta", MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result)
                {
                    LoadCustomers();
                    ClearForm();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Zəhmət olmasa, nisyə limiti və endirim faizi sahələrinə düzgün rəqəm daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Anlaşılmayan bir xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Mövcud müştərini yeniləmək üçün düymə klik hadisəsi.
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedCustomerId == 0)
            {
                MessageBox.Show("Zəhmət olmasa, yeniləmək üçün cədvəldən bir müştəri seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var musteri = new Musteri
                {
                    Id = _selectedCustomerId,
                    Ad = txtAd.Text,
                    Soyad = txtSoyad.Text,
                    Telefon = txtTelefon.Text,
                    Unvan = txtUnvan.Text,
                    Email = txtEmail.Text,
                    NisyeLimiti = decimal.Parse(txtNisyeLimiti.Text),
                    EndirimFaizi = decimal.Parse(txtEndirimFaizi.Text),
                    Qeyd = txtQeyd.Text,
                    Aktivdir = chkAktivdir.Checked
                };

                bool result = _musteriBll.Update(musteri, _currentUser, out string message);
                MessageBox.Show(message, result ? "Uğurlu" : "Xəta", MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result)
                {
                    LoadCustomers();
                    ClearForm();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Zəhmət olmasa, nisyə limiti və endirim faizi sahələrinə düzgün rəqəm daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Anlaşılmayan bir xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Müştərini silmək üçün düymə klik hadisəsi.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCustomerId == 0)
            {
                MessageBox.Show("Zəhmət olmasa, silmək üçün cədvəldən bir müştəri seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmationResult = MessageBox.Show($"Seçilmiş müştərini silmək istədiyinizə əminsinizmi? Bu əməliyyat geri qaytarıla bilməz.",
                                                 "Silməyi Təsdiqlə",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (confirmationResult == DialogResult.Yes)
            {
                bool result = _musteriBll.Delete(_selectedCustomerId, _currentUser, out string message);
                MessageBox.Show(message, result ? "Uğurlu" : "Xəta", MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result)
                {
                    LoadCustomers();
                    ClearForm();
                }
            }
        }

        /// <summary>
        /// Form sahələrini təmizləmək üçün düymə klik hadisəsi.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        #endregion
    }
}