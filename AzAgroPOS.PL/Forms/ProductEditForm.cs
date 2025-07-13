using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class ProductEditForm : Form
    {
        private readonly MehsulService _mehsulService;
        private readonly MehsulKateqoriyasiRepository _kateqoriyaRepository;
        private readonly VahidRepository _vahidRepository;
        private readonly Istifadeci _currentUser;
        private readonly Mehsul _product;

        public ProductEditForm(Mehsul product, Istifadeci currentUser)
        {
            InitializeComponent();
            _mehsulService = new MehsulService();
            _kateqoriyaRepository = new MehsulKateqoriyasiRepository();
            _vahidRepository = new VahidRepository();
            _currentUser = currentUser;
            _product = product;
        }

        private async void ProductEditForm_Load(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
            await LoadUnitsAsync();
            LoadProductData();
            UpdateProfitLabels();
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                var categories = await _kateqoriyaRepository.GetAllActiveAsync();
                cmbCategory.DataSource = categories;
                cmbCategory.DisplayMember = "Ad";
                cmbCategory.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kateqoriyalar yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadUnitsAsync()
        {
            try
            {
                var units = await _vahidRepository.GetAllActiveAsync();
                cmbUnit.DataSource = units;
                cmbUnit.DisplayMember = "TamAd";
                cmbUnit.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Vahidlər yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductData()
        {
            txtName.Text = _product.Ad;
            txtDescription.Text = _product.Tesvir;
            txtBarcode.Text = _product.Barkod;
            txtSKU.Text = _product.SKU;
            cmbCategory.SelectedValue = _product.KateqoriyaId;
            cmbUnit.SelectedValue = _product.VahidId;
            txtPurchasePrice.Text = _product.AlisQiymeti.ToString("F2");
            txtSalePrice.Text = _product.SatisQiymeti.ToString("F2");
            txtCurrentStock.Text = _product.MovcudMiqdar.ToString("F2");
            txtMinStock.Text = _product.MinimumMiqdar.ToString("F2");
            txtNotes.Text = _product.Qeydler;
            cmbStatus.SelectedItem = _product.Status;
        }

        private async void btnGenerateBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                var barcode = await _mehsulService.GenerateBarkodAsync();
                txtBarcode.Text = barcode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Barkod yaradılarkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGenerateSKU_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("SKU yaratmaq üçün əvvəlcə məhsul adını daxil edin.", "Məlumat", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Focus();
                    return;
                }

                string categoryCode = "";
                if (cmbCategory.SelectedItem is MehsulKateqoriyasi selectedCategory)
                {
                    categoryCode = selectedCategory.Kod;
                }

                var sku = await _mehsulService.GenerateSKUAsync(txtName.Text, categoryCode);
                txtSKU.Text = sku;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"SKU yaradılarkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrices_TextChanged(object sender, EventArgs e)
        {
            UpdateProfitLabels();
        }

        private void UpdateProfitLabels()
        {
            if (decimal.TryParse(txtPurchasePrice.Text, out decimal purchasePrice) &&
                decimal.TryParse(txtSalePrice.Text, out decimal salePrice))
            {
                decimal profit = salePrice - purchasePrice;
                decimal profitPercent = purchasePrice > 0 ? (profit / purchasePrice) * 100 : 0;

                lblProfit.Text = $"Mənfəət: {profit:F2} AZN";
                lblProfitPercent.Text = $"Mənfəət Faizi: {profitPercent:F1}%";

                if (profit < 0)
                {
                    lblProfit.ForeColor = System.Drawing.Color.Red;
                    lblProfitPercent.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblProfit.ForeColor = System.Drawing.Color.DarkGreen;
                    lblProfitPercent.ForeColor = System.Drawing.Color.DarkBlue;
                }
            }
            else
            {
                lblProfit.Text = "Mənfəət: 0 AZN";
                lblProfitPercent.Text = "Mənfəət Faizi: 0%";
                lblProfit.ForeColor = System.Drawing.Color.DarkGreen;
                lblProfitPercent.ForeColor = System.Drawing.Color.DarkBlue;
            }
        }

        private void txtPrices_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Yalnız rəqəmlər, nöqtə və backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Yalnız bir nöqtə
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Yalnız rəqəmlər, nöqtə və backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Yalnız bir nöqtə
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                btnSave.Enabled = false;
                btnSave.Text = "Saxlanılır...";

                _product.Ad = txtName.Text.Trim();
                _product.Tesvir = txtDescription.Text.Trim();
                _product.Barkod = txtBarcode.Text.Trim();
                _product.SKU = txtSKU.Text.Trim();
                _product.KateqoriyaId = (int)cmbCategory.SelectedValue;
                _product.VahidId = (int)cmbUnit.SelectedValue;
                _product.AlisQiymeti = decimal.Parse(txtPurchasePrice.Text, CultureInfo.InvariantCulture);
                _product.SatisQiymeti = decimal.Parse(txtSalePrice.Text, CultureInfo.InvariantCulture);
                _product.MovcudMiqdar = decimal.Parse(txtCurrentStock.Text, CultureInfo.InvariantCulture);
                _product.MinimumMiqdar = decimal.Parse(txtMinStock.Text, CultureInfo.InvariantCulture);
                _product.Qeydler = txtNotes.Text.Trim();
                _product.Status = cmbStatus.SelectedItem.ToString();

                var result = await _mehsulService.UpdateMehsulAsync(_product, _currentUser.Id);

                if (result.Success)
                {
                    MessageBox.Show(result.Message, "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta baş verdi: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text = "Saxla";
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Məhsul adı mütləqdir.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                MessageBox.Show("Barkod mütləqdir.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBarcode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSKU.Text))
            {
                MessageBox.Show("SKU mütləqdir.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSKU.Focus();
                return false;
            }

            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Kateqoriya seçin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return false;
            }

            if (cmbUnit.SelectedValue == null)
            {
                MessageBox.Show("Vahid seçin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbUnit.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPurchasePrice.Text, out decimal purchasePrice) || purchasePrice < 0)
            {
                MessageBox.Show("Alış qiyməti düzgün daxil edilməyib.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPurchasePrice.Focus();
                return false;
            }

            if (!decimal.TryParse(txtSalePrice.Text, out decimal salePrice) || salePrice <= 0)
            {
                MessageBox.Show("Satış qiyməti düzgün daxil edilməyib.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSalePrice.Focus();
                return false;
            }

            if (salePrice <= purchasePrice)
            {
                MessageBox.Show("Satış qiyməti alış qiymətindən böyük olmalıdır.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSalePrice.Focus();
                return false;
            }

            if (!decimal.TryParse(txtCurrentStock.Text, out decimal currentStock) || currentStock < 0)
            {
                MessageBox.Show("Mövcud miqdar düzgün daxil edilməyib.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrentStock.Focus();
                return false;
            }

            if (!decimal.TryParse(txtMinStock.Text, out decimal minStock) || minStock < 0)
            {
                MessageBox.Show("Minimum miqdar düzgün daxil edilməyib.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMinStock.Focus();
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Status seçin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}