using AzAgroPOS.BLL;
using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

namespace AzAgroPOS.PL
{
    /// <summary>
    /// Məhsulların idarə edilməsi üçün Windows Form. Bu form vasitəsilə məhsulların əlavə edilməsi,
    /// redaktə edilməsi, silinməsi, barkod generasiyası və çapı kimi əməliyyatlar həyata keçirilir.
    /// </summary>
    public partial class frmProducts : Form
    {
        private readonly Istifadeci _currentUser;
        private readonly MehsulBLL _mehsulBll = new MehsulBLL();
        private readonly KateqoriyaBLL _kateqoriyaBll = new KateqoriyaBLL();
        private readonly VahidBLL _vahidBll = new VahidBLL();
        private int _selectedProductId = 0;

        /// <summary>
        /// frmProducts sinifinin konstruktoru. Formun işə düşməsi üçün lazım olan ilkin parametrləri qəbul edir.
        /// </summary>
        /// <param name="currentUser">Sistemə daxil olmuş istifadəçinin məlumatlarını ehtiva edən Istifadeci obyekti</param>
        /// <exception cref="ArgumentNullException">currentUser parametri null olduqda baş verir</exception>
        public frmProducts(Istifadeci currentUser)
        {
            if (currentUser == null)
            {
                throw new ArgumentNullException(nameof(currentUser), "İstifadəçi məlumatları boş ola bilməz");
            }

            InitializeComponent();
            _currentUser = currentUser;
        }

        /// <summary>
        /// Form yüklənərkən işə düşən hadisə metodu. Kateqoriya, vahid və məhsul məlumatlarını yükləyir.
        /// </summary>
        /// <param name="sender">Hadisəni başlatmış obyekt</param>
        /// <param name="e">Hadisə məlumatlarını ehtiva edən arqument</param>
        private void frmProducts_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCategories();
                LoadUnits();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Form yüklənərkən gözlənilməz xəta baş verdi: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #region Köməkçi Metodlar

        /// <summary>
        /// Verilənlər bazasından kateqoriya məlumatlarını yükləyir və comboBox-a doldurur.
        /// </summary>
        /// <exception cref="ApplicationException">Kateqoriyalar yüklənərkən xəta baş verərsə</exception>
        private void LoadCategories()
        {
            try
            {
                cmbKateqoriya.DataSource = _kateqoriyaBll.GetAll();
                cmbKateqoriya.DisplayMember = "Ad";
                cmbKateqoriya.ValueMember = "Id";
                cmbKateqoriya.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Kateqoriyalar yüklənərkən xəta baş verdi", ex);
            }
        }

        /// <summary>
        /// Verilənlər bazasından vahid məlumatlarını yükləyir və comboBox-a doldurur.
        /// </summary>
        /// <exception cref="ApplicationException">Vahidlər yüklənərkən xəta baş verərsə</exception>
        private void LoadUnits()
        {
            try
            {
                cmbVahid.DataSource = _vahidBll.GetAll();
                cmbVahid.DisplayMember = "Ad";
                cmbVahid.ValueMember = "Id";
                cmbVahid.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Vahidlər yüklənərkən xəta baş verdi", ex);
            }
        }

        /// <summary>
        /// Verilənlər bazasından məhsul məlumatlarını yükləyir və DataGridView-a doldurur.
        /// </summary>
        /// <exception cref="ApplicationException">Məhsullar yüklənərkən xəta baş verərsə</exception>
        private void LoadProducts()
        {
            try
            {
                dgvProducts.DataSource = _mehsulBll.GetAll();
                SetupDataGridColumns();
                dgvProducts.ClearSelection();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Məhsullar yüklənərkən xəta baş verdi", ex);
            }
        }

        /// <summary>
        /// DataGridView sütunlarını tənzimləyir. Gizlədilməsi lazım olan sütunları gizlədir.
        /// </summary>
        private void SetupDataGridColumns()
        {
            try
            {
                if (dgvProducts.Columns["Id"] != null)
                    dgvProducts.Columns["Id"].Visible = false;

                if (dgvProducts.Columns["KateqoriyaId"] != null)
                    dgvProducts.Columns["KateqoriyaId"].Visible = false;

                if (dgvProducts.Columns["VahidId"] != null)
                    dgvProducts.Columns["VahidId"].Visible = false;

                if (dgvProducts.Columns["Aktivdir"] != null)
                    dgvProducts.Columns["Aktivdir"].Visible = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DataGridView sütunları tənzimlənərkən xəta: {ex.Message}");
            }
        }

        /// <summary>
        /// Verilmiş mətni Code128 formatında barkod şəklinə çevirir və PictureBox-da göstərir.
        /// </summary>
        /// <param name="barcodeText">Barkod şəklində çevriləcək mətn</param>
        private void GenerateBarcodePreview(string barcodeText)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(barcodeText))
                {
                    pictureBoxBarcode.Image = null;
                    return;
                }

                var barcodeWriter = new BarcodeWriter
                {
                    Format = BarcodeFormat.CODE_128,
                    Options = new EncodingOptions
                    {
                        Height = 80,
                        Width = 300,
                        Margin = 10,
                        PureBarcode = false
                    }
                };

                pictureBoxBarcode.Image = barcodeWriter.Write(barcodeText);
            }
            catch (Exception ex)
            {
                pictureBoxBarcode.Image = null;
                System.Diagnostics.Debug.WriteLine($"Barkod şəkli yaradıla bilmədi: {ex.Message}");
            }
        }

        /// <summary>
        /// Form sahələrini təmizləyir və seçimləri sıfırlayır.
        /// </summary>
        private void ClearForm()
        {
            try
            {
                txtAd.Clear();
                txtBarkod.Clear();
                txtAlisQiymeti.Text = "0.00";
                txtSatisQiymeti.Text = "0.00";
                txtMinimumStok.Text = "0";

                if (cmbKateqoriya.Items.Count > 0)
                    cmbKateqoriya.SelectedIndex = -1;

                if (cmbVahid.Items.Count > 0)
                    cmbVahid.SelectedIndex = -1;

                dgvProducts.ClearSelection();
                _selectedProductId = 0;
                pictureBoxBarcode.Image = null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Form təmizlənərkən xəta: {ex.Message}");
            }
        }

        #endregion

        #region Hadisə Metodları

        /// <summary>
        /// DataGridView-də seçim dəyişdikdə işə düşən metod. Seçilmiş məhsulun məlumatlarını form sahələrinə doldurur.
        /// </summary>
        /// <param name="sender">Hadisəni başlatmış obyekt</param>
        /// <param name="e">Hadisə məlumatlarını ehtiva edən arqument</param>
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvProducts.CurrentRow == null || dgvProducts.CurrentRow.DataBoundItem == null)
                {
                    ClearForm();
                    return;
                }

                var selectedProduct = (Mehsul)dgvProducts.CurrentRow.DataBoundItem;
                _selectedProductId = selectedProduct.Id;

                txtAd.Text = selectedProduct.Ad;
                txtBarkod.Text = selectedProduct.Barkod;
                txtAlisQiymeti.Text = selectedProduct.AlisQiymeti.ToString("F2");
                txtSatisQiymeti.Text = selectedProduct.SatisQiymeti.ToString("F2");
                txtMinimumStok.Text = selectedProduct.MinimumStok.ToString();

                if (cmbKateqoriya.Items.Count > 0)
                    cmbKateqoriya.SelectedValue = selectedProduct.KateqoriyaId;

                if (cmbVahid.Items.Count > 0)
                    cmbVahid.SelectedValue = selectedProduct.VahidId;

                GenerateBarcodePreview(selectedProduct.Barkod);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsul məlumatları yüklənərkən xəta: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Yeni məhsul əlavə etmək üçün düymə klik hadisəsi.
        /// </summary>
        /// <param name="sender">Hadisəni başlatmış obyekt</param>
        /// <param name="e">Hadisə məlumatlarını ehtiva edən arqument</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAd.Text))
                {
                    MessageBox.Show("Məhsul adı boş ola bilməz", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAd.Focus();
                    return;
                }

                var mehsul = new Mehsul
                {
                    Ad = txtAd.Text.Trim(),
                    Barkod = txtBarkod.Text.Trim(),
                    KateqoriyaId = (int)cmbKateqoriya.SelectedValue,
                    VahidId = (int)cmbVahid.SelectedValue,
                    AlisQiymeti = decimal.Parse(txtAlisQiymeti.Text),
                    SatisQiymeti = decimal.Parse(txtSatisQiymeti.Text),
                    MinimumStok = int.Parse(txtMinimumStok.Text),
                    Aktivdir = true
                };

                bool result = _mehsulBll.Add(mehsul, _currentUser, out string message);

                MessageBox.Show(message,
                    result ? "Uğurlu" : "Xəta",
                    MessageBoxButtons.OK,
                    result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result)
                {
                    LoadProducts();
                    ClearForm();
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Zəhmət olmasa, qiymət və stok sahələrinə düzgün rəqəm daxil edin.",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsul əlavə edilərkən xəta: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Mövcud məhsulu yeniləmək üçün düymə klik hadisəsi.
        /// </summary>
        /// <param name="sender">Hadisəni başlatmış obyekt</param>
        /// <param name="e">Hadisə məlumatlarını ehtiva edən arqument</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedProductId == 0)
                {
                    MessageBox.Show("Yeniləmək üçün məhsul seçin",
                        "Xəbərdarlıq",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAd.Text))
                {
                    MessageBox.Show("Məhsul adı boş ola bilməz",
                        "Xəbərdarlıq",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtAd.Focus();
                    return;
                }

                var mehsul = new Mehsul
                {
                    Id = _selectedProductId,
                    Ad = txtAd.Text.Trim(),
                    Barkod = txtBarkod.Text.Trim(),
                    KateqoriyaId = (int)cmbKateqoriya.SelectedValue,
                    VahidId = (int)cmbVahid.SelectedValue,
                    AlisQiymeti = decimal.Parse(txtAlisQiymeti.Text),
                    SatisQiymeti = decimal.Parse(txtSatisQiymeti.Text),
                    MinimumStok = int.Parse(txtMinimumStok.Text),
                    Aktivdir = true
                };

                bool result = _mehsulBll.Update(mehsul, _currentUser, out string message);

                MessageBox.Show(message,
                    result ? "Uğurlu" : "Xəta",
                    MessageBoxButtons.OK,
                    result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result)
                {
                    LoadProducts();
                    ClearForm();
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Zəhmət olmasa, qiymət və stok sahələrinə düzgün rəqəm daxil edin.",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsul yenilənərkən xəta: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Məhsulu silmək üçün düymə klik hadisəsi.
        /// </summary>
        /// <param name="sender">Hadisəni başlatmış obyekt</param>
        /// <param name="e">Hadisə məlumatlarını ehtiva edən arqument</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedProductId == 0)
                {
                    MessageBox.Show("Silmək üçün məhsul seçin",
                        "Xəbərdarlıq",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var confirmationResult = MessageBox.Show(
                    "Seçilmiş məhsulu silmək istədiyinizə əminsinizmi?\nBu əməliyyat geri qaytarıla bilməz.",
                    "Silməyi Təsdiqlə",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (confirmationResult == DialogResult.Yes)
                {
                    bool result = _mehsulBll.Delete(_selectedProductId, _currentUser, out string message);

                    MessageBox.Show(message,
                        result ? "Uğurlu" : "Xəta",
                        MessageBoxButtons.OK,
                        result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                    if (result)
                    {
                        LoadProducts();
                        ClearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsul silinərkən xəta: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Form sahələrini təmizləmək üçün düymə klik hadisəsi.
        /// </summary>
        /// <param name="sender">Hadisəni başlatmış obyekt</param>
        /// <param name="e">Hadisə məlumatlarını ehtiva edən arqument</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Form təmizlənərkən xəta: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Yeni unikal barkod generasiyası üçün düymə klik hadisəsi.
        /// </summary>
        /// <param name="sender">Hadisəni başlatmış obyekt</param>
        /// <param name="e">Hadisə məlumatlarını ehtiva edən arqument</param>
        private void btnGenerateBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                string newBarcode = _mehsulBll.GenerateNewUniqueBarcode();
                txtBarkod.Text = newBarcode;
                GenerateBarcodePreview(newBarcode);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Barkod generasiyası zamanı xəta: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Seçilmiş məhsulun barkodunu çap etmək üçün düymə klik hadisəsi.
        /// </summary>
        /// <param name="sender">Hadisəni başlatmış obyekt</param>
        /// <param name="e">Hadisə məlumatlarını ehtiva edən arqument</param>
        private void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedProductId == 0)
                {
                    MessageBox.Show("Barkod çapı üçün məhsul seçin",
                        "Xəbərdarlıq",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var product = _mehsulBll.GetById(_selectedProductId);
                if (product == null)
                {
                    MessageBox.Show("Məhsul tapılmadı",
                        "Xəta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                using (PrintDialog printDialog = new PrintDialog())
                {
                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        var barcodeService = new BarkodService();
                        string zpl = barcodeService.GenerateZplForProduct(product);
                        bool success = barcodeService.PrintZpl(zpl, printDialog.PrinterSettings.PrinterName);

                        MessageBox.Show(success ? "Barkod uğurla printerə göndərildi" : "Barkod çapı uğursuz oldu",
                            success ? "Uğurlu" : "Xəta",
                            MessageBoxButtons.OK,
                            success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Barkod çapı zamanı xəta: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnPrintSelectedBarcodes_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zəhmət olmasa, barkodunu çap etmək üçün cədvəldən bir və ya bir neçə məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçilmiş sətirlərin sayını göstərərək təsdiq istəyirik
            var confirmation = MessageBox.Show($"{dgvProducts.SelectedRows.Count} ədəd barkod çapa göndəriləcək. Davam etmək istəyirsinizmi?",
                                               "Toplu Çap Təsdiqi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.No) return;


            // Printer seçimi üçün dialoq pəncərəsini yalnız bir dəfə açırıq
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var barcodeService = new BarkodService();
                    var zplList = new List<string>();

                    // Bütün seçilmiş sətirləri dövrə alırıq
                    foreach (DataGridViewRow row in dgvProducts.SelectedRows)
                    {
                        var product = (Mehsul)row.DataBoundItem;
                        if (product != null)
                        {
                            // Hər məhsul üçün ZPL kodunu yaradıb siyahıya əlavə edirik
                            zplList.Add(barcodeService.GenerateZplForProduct(product));
                        }
                    }

                    // Bütün ZPL kodlarını ehtiva edən siyahını çapa göndəririk
                    bool success = barcodeService.Print(zplList, printDialog.PrinterSettings.PrinterName);

                    if (success)
                    {
                        MessageBox.Show($"{zplList.Count} ədəd barkod uğurla printerə göndərildi.", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Barkodlar printerə göndərilərkən xəta baş verdi.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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