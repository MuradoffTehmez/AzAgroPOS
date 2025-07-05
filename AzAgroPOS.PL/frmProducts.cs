using AzAgroPOS.BLL;
using AzAgroPOS.Entities;
using System;
using System.Windows.Forms;
using AzAgroPOS.BLL.Services;

namespace AzAgroPOS.PL
{
    /// <summary>
    /// Məhsulların idarə edilməsi üçün form. Məhsulların əlavə edilməsi, redaktə edilməsi, silinməsi və görüntülənməsi funksionallığını təmin edir.
    /// </summary>
    public partial class frmProducts : Form
    {
        private readonly Istifadeci _currentUser;
        private readonly MehsulBLL _mehsulBll = new MehsulBLL();
        private readonly KateqoriyaBLL _kateqoriyaBll = new KateqoriyaBLL();
        private readonly VahidBLL _vahidBll = new VahidBLL();
        private int _selectedProductId = 0;

        /// <summary>
        /// frmProducts konstruktoru. Daxil olmuş istifadəçi məlumatlarını qəbul edir.
        /// </summary>
        /// <param name="currentUser">Daxil olmuş istifadəçi obyekti</param>
        public frmProducts(Istifadeci currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }

        /// <summary>
        /// Form yüklənərkən işə düşən metod. Kateqoriyaları, vahidləri və məhsulları yükləyir.
        /// </summary>
        private void frmProducts_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadUnits();
            LoadProducts();
        }

        #region Helper Methods

        /// <summary>
        /// Kateqoriyaları yükləyir və comboBox-a doldurur.
        /// </summary>
        private void LoadCategories()
        {
            try
            {
                cmbKateqoriya.DataSource = _kateqoriyaBll.GetAll();
                cmbKateqoriya.DisplayMember = "Ad";
                cmbKateqoriya.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kateqoriyalar yüklənərkən xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Vahidləri yükləyir və comboBox-a doldurur.
        /// </summary>
        private void LoadUnits()
        {
            try
            {
                cmbVahid.DataSource = _vahidBll.GetAll();
                cmbVahid.DisplayMember = "Ad";
                cmbVahid.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vahidlər yüklənərkən xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Məhsulları yükləyir və DataGridView-a doldurur.
        /// </summary>
        private void LoadProducts()
        {
            try
            {
                dgvProducts.DataSource = _mehsulBll.GetAll();
                SetupDataGridColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Məhsullar yüklənərkən xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// DataGridView sütunlarını tənzimləyir. Gizlədilməsi lazım olan sütunları gizlədir.
        /// </summary>
        private void SetupDataGridColumns()
        {
            if (dgvProducts.Columns["Id"] != null) dgvProducts.Columns["Id"].Visible = false;
            if (dgvProducts.Columns["KateqoriyaId"] != null) dgvProducts.Columns["KateqoriyaId"].Visible = false;
            if (dgvProducts.Columns["VahidId"] != null) dgvProducts.Columns["VahidId"].Visible = false;
            // Digər gizlədilməli sütunlar burada əlavə edilə bilər
        }

        /// <summary>
        /// Form sahələrini təmizləyir və seçimləri sıfırlayır.
        /// </summary>
        private void ClearForm()
        {
            txtAd.Clear();
            txtBarkod.Clear();
            txtAlisQiymeti.Text = "0.00";
            txtSatisQiymeti.Text = "0.00";
            txtMinimumStok.Text = "0";
            if (cmbKateqoriya.Items.Count > 0) cmbKateqoriya.SelectedIndex = 0;
            if (cmbVahid.Items.Count > 0) cmbVahid.SelectedIndex = 0;
            dgvProducts.ClearSelection();
            _selectedProductId = 0;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// DataGridView-də seçim dəyişdikdə işə düşən metod. Seçilmiş məhsulun məlumatlarını form sahələrinə doldurur.
        /// </summary>
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;

            Mehsul selectedProduct = (Mehsul)dgvProducts.CurrentRow.DataBoundItem;
            if (selectedProduct == null) return;

            _selectedProductId = selectedProduct.Id;
            txtAd.Text = selectedProduct.Ad;
            txtBarkod.Text = selectedProduct.Barkod;
            txtAlisQiymeti.Text = selectedProduct.AlisQiymeti.ToString("F2");
            txtSatisQiymeti.Text = selectedProduct.SatisQiymeti.ToString("F2");
            txtMinimumStok.Text = selectedProduct.MinimumStok.ToString();
            cmbKateqoriya.SelectedValue = selectedProduct.KateqoriyaId;
            cmbVahid.SelectedValue = selectedProduct.VahidId;
        }

        /// <summary>
        /// Yeni məhsul əlavə etmək üçün düymə klik hadisəsi.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var mehsul = new Mehsul
                {
                    Ad = txtAd.Text,
                    Barkod = txtBarkod.Text,
                    KateqoriyaId = (int)cmbKateqoriya.SelectedValue,
                    VahidId = (int)cmbVahid.SelectedValue,
                    AlisQiymeti = decimal.Parse(txtAlisQiymeti.Text),
                    SatisQiymeti = decimal.Parse(txtSatisQiymeti.Text),
                    MinimumStok = int.Parse(txtMinimumStok.Text),
                    Aktivdir = true
                };

                bool result = _mehsulBll.Add(mehsul, _currentUser, out string message);
                MessageBox.Show(message, result ? "Uğurlu" : "Xəta", MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result)
                {
                    LoadProducts();
                    ClearForm();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Zəhmət olmasa, qiymət və stok sahələrinə düzgün rəqəm daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Anlaşılmayan bir xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Mövcud məhsulu yeniləmək üçün düymə klik hadisəsi.
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedProductId == 0)
            {
                MessageBox.Show("Zəhmət olmasa, yeniləmək üçün cədvəldən bir məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var mehsul = new Mehsul
                {
                    Id = _selectedProductId,
                    Ad = txtAd.Text,
                    Barkod = txtBarkod.Text,
                    KateqoriyaId = (int)cmbKateqoriya.SelectedValue,
                    VahidId = (int)cmbVahid.SelectedValue,
                    AlisQiymeti = decimal.Parse(txtAlisQiymeti.Text),
                    SatisQiymeti = decimal.Parse(txtSatisQiymeti.Text),
                    MinimumStok = int.Parse(txtMinimumStok.Text),
                    Aktivdir = true
                };

                bool result = _mehsulBll.Update(mehsul, _currentUser, out string message);
                MessageBox.Show(message, result ? "Uğurlu" : "Xəta", MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result)
                {
                    LoadProducts();
                    ClearForm();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Zəhmət olmasa, qiymət və stok sahələrinə düzgün rəqəm daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Anlaşılmayan bir xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Məhsulu silmək üçün düymə klik hadisəsi.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedProductId == 0)
            {
                MessageBox.Show("Zəhmət olmasa, silmək üçün cədvəldən bir məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmationResult = MessageBox.Show($"Seçilmiş məhsulu silmək istədiyinizə əminsinizmi? Bu əməliyyat geri qaytarıla bilməz.",
                                                 "Silməyi Təsdiqlə",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (confirmationResult == DialogResult.Yes)
            {
                bool result = _mehsulBll.Delete(_selectedProductId, _currentUser, out string message);
                MessageBox.Show(message, result ? "Uğurlu" : "Xəta", MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result)
                {
                    LoadProducts();
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

        private void btnGenerateBarcode_Click(object sender, EventArgs e)
        {
            // BLL-dəki yeni public metodu çağırırıq
            string newBarcode = _mehsulBll.GenerateNewUniqueBarcode();
            txtBarkod.Text = newBarcode;
        }

        private void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            if (_selectedProductId == 0)
            {
                MessageBox.Show("Zəhmət olmasa, barkodunu çap etmək üçün cədvəldən bir məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçilmiş məhsulu tapırıq
            var product = _mehsulBll.GetById(_selectedProductId);
            if (product == null)
            {
                MessageBox.Show("Məhsul tapılmadı.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Printer seçimi üçün dialoq pəncərəsi açırıq
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var barcodeService = new BarkodService();
                    
                    string zpl = barcodeService.GenerateZplForProduct(product);
                    
                    bool success = barcodeService.PrintZpl(zpl, printDialog.PrinterSettings.PrinterName);

                    if (success)
                    {
                        MessageBox.Show("Barkod uğurla printerə göndərildi.", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Barkod printerə göndərilərkən xəta baş verdi.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Çap zamanı xəta: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}