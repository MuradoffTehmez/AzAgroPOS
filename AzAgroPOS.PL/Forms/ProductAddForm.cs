using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.BLL.Interfaces;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class ProductAddForm : Form
    {
        private readonly MehsulService _mehsulService;
        private readonly MehsulKateqoriyasiRepository _kateqoriyaRepository;
        private readonly VahidRepository _vahidRepository;
        private readonly Istifadeci _currentUser;

        public ProductAddForm(Istifadeci currentUser)
        {
            InitializeComponent();
            var context = new AzAgroDbContext();
            _mehsulService = ServiceFactory.CreateMehsulService();
            _kateqoriyaRepository = new MehsulKateqoriyasiRepository(context);
            _vahidRepository = new VahidRepository(context);
            _currentUser = currentUser;
        }

        private async void ProductAddForm_Load(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
            await LoadUnitsAsync();
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
                cmbCategory.SelectedIndex = -1;
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
                cmbUnit.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Vahidlər yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // SKU avtomatik yenilənməsi üçün
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // SKU avtomatik yenilənməsi üçün
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

                var mehsul = new Mehsul
                {
                    Ad = txtName.Text.Trim(),
                    Tesvir = txtDescription.Text.Trim(),
                    Barkod = txtBarcode.Text.Trim(),
                    SKU = txtSKU.Text.Trim(),
                    KateqoriyaId = (int)cmbCategory.SelectedValue,
                    VahidId = (int)cmbUnit.SelectedValue,
                    AlisQiymeti = decimal.Parse(txtPurchasePrice.Text, CultureInfo.InvariantCulture),
                    SatisQiymeti = decimal.Parse(txtSalePrice.Text, CultureInfo.InvariantCulture),
                    MovcudMiqdar = decimal.Parse(txtCurrentStock.Text, CultureInfo.InvariantCulture),
                    MinimumMiqdar = decimal.Parse(txtMinStock.Text, CultureInfo.InvariantCulture),
                    Qeydler = txtNotes.Text.Trim(),
                    Status = "Aktiv"
                };

                var result = await _mehsulService.CreateMehsulAsync(mehsul, _currentUser.Id);

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

            return true;
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtDescription.Clear();
            txtBarcode.Clear();
            txtSKU.Clear();
            cmbCategory.SelectedIndex = -1;
            cmbUnit.SelectedIndex = -1;
            txtPurchasePrice.Clear();
            txtSalePrice.Clear();
            txtCurrentStock.Text = "0";
            txtMinStock.Text = "0";
            txtNotes.Clear();
            UpdateProfitLabels();
            txtName.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Formu təmizləmək istədiyinizə əminsiniz?", "Təsdiq", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClearForm();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}