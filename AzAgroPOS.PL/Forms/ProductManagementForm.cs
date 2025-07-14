using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class ProductManagementForm : Form
    {
        private readonly MehsulService _mehsulService;
        private readonly MehsulRepository _mehsulRepository;
        private readonly MehsulKateqoriyasiRepository _kateqoriyaRepository;
        private readonly Istifadeci _currentUser;

        public ProductManagementForm(Istifadeci currentUser)
        {
            InitializeComponent();
            var context = new AzAgroDbContext();
            _mehsulService = new MehsulService();
            _mehsulRepository = new MehsulRepository(context);
            _kateqoriyaRepository = new MehsulKateqoriyasiRepository(context);
            _currentUser = currentUser;
        }

        private async void ProductManagementForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            await LoadDataAsync();
            await LoadFiltersAsync();
            await LoadStatisticsAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var allProducts = await _mehsulRepository.GetAllAsync();
                dgvProducts.DataSource = allProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsullar yüklənərkən xəta: {ex.Message}", "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();
            dgvProducts.DataSource = null;

            // Data-bound columns
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Name = "Id", Visible = false });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Ad", HeaderText = "Məhsul Adı", Name = "Ad", Width = 200 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SKU", HeaderText = "SKU", Name = "SKU", Width = 120 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Barkod", HeaderText = "Barkod", Name = "Barkod", Width = 120 });

            // Custom-handled columns
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Kateqoriya", Name = "Kateqoriya", Width = 150 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Vahid", Name = "Vahid", Width = 80 });

            // Data-bound columns
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AlisQiymeti", HeaderText = "Alış Qiyməti", Name = "AlisQiymeti", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "F2" } });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SatisQiymeti", HeaderText = "Satış Qiyməti", Name = "SatisQiymeti", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "F2" } });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MovcudMiqdar", HeaderText = "Stok", Name = "MovcudMiqdar", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "F2" } });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status", Name = "Status", Width = 80 });

            // Custom-handled columns
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Stok Vəziyyəti", Name = "StokVeziyyeti", Width = 100 });

            // CellFormatting hadisəsini bağlayırıq
            dgvProducts.CellFormatting += DgvProducts_CellFormatting;
        }

        private void DgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dgv = (DataGridView)sender;
            var product = (Mehsul)dgv.Rows[e.RowIndex].DataBoundItem;
            if (product == null) return;

            // Xüsusi xanaları doldururuq
            if (dgv.Columns[e.ColumnIndex].Name == "Kateqoriya")
            {
                e.Value = product.Kateqoriya?.Ad ?? "N/A";
            }
            else if (dgv.Columns[e.ColumnIndex].Name == "Vahid")
            {
                e.Value = product.Vahid?.QisaAd ?? "N/A";
            }
            else if (dgv.Columns[e.ColumnIndex].Name == "StokVeziyyeti")
            {
                e.Value = product.StoktanKenarda ? "Az Stok" : "Normal";
            }

            // Sətir rənglənməsi
            if (product.StoktanKenarda)
            {
                e.CellStyle.BackColor = System.Drawing.Color.LightSalmon;
            }
            else if (product.Status == "Deaktiv")
            {
                e.CellStyle.BackColor = System.Drawing.Color.LightGray;
            }
            else
            {
                e.CellStyle.BackColor = dgv.DefaultCellStyle.BackColor;
            }
        }

        private async Task LoadFiltersAsync()
        {
            try
            {
                // Categories
                var categories = await _kateqoriyaRepository.GetAllActiveAsync();
                var categoryList = new List<object> { new { Id = 0, Ad = "Bütün Kateqoriyalar" } };
                categoryList.AddRange(categories.Select(c => new { Id = c.Id, Ad = c.Ad }).ToList());

                cmbCategory.DataSource = categoryList;
                cmbCategory.DisplayMember = "Ad";
                cmbCategory.ValueMember = "Id";
                cmbCategory.SelectedIndex = 0;

                // Status
                cmbStatus.Items.Clear();
                cmbStatus.Items.Add("Hamısı");
                cmbStatus.Items.Add("Aktiv");
                cmbStatus.Items.Add("Deaktiv");
                cmbStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Filterlər yüklənərkən xəta: {ex.Message}", "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadStatisticsAsync()
        {
            try
            {
                var stats = await _mehsulService.GetMehsulStatistikalarAsync();
                var stockValue = await _mehsulService.HesablaUmumiStokDegeriAsync();

                lblTotalCount.Text = $"Cəmi: {stats["UmumiMehsulSayi"]}";
                lblActiveCount.Text = $"Aktiv: {stats["AktivMehsulSayi"]}";
                lblLowStockCount.Text = $"Az Stoklu: {stats["StoktanKenardaMehsulSayi"]}";
                lblStockValue.Text = $"Stok Dəyəri: {stockValue:F2} AZN";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Statistikalar yüklənərkən xəta: {ex.Message}", "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await ApplyFiltersAsync();
        }

        private async void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await ApplyFiltersAsync();
            }
        }

        private async Task ApplyFiltersAsync()
        {
            try
            {
                string searchTerm = txtSearch.Text.Trim();
                int categoryId = (int)cmbCategory.SelectedValue;
                string status = cmbStatus.SelectedItem?.ToString();

                var filteredProducts = await _mehsulService.GetMehsullarByFiltersAsync(
                    searchTerm,
                    categoryId == 0 ? (int?)null : categoryId,
                    status == "Hamısı" ? null : status);

                dgvProducts.DataSource = filteredProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Filterlənərkən xəta: {ex.Message}", "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbCategory.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            await LoadDataAsync();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new ProductAddForm(_currentUser);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                await LoadDataAsync();
                await LoadStatisticsAsync();
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Düzəliş etmək üçün məhsul seçin.", "Məlumat",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedProduct = (Mehsul)dgvProducts.SelectedRows[0].DataBoundItem;

            if (selectedProduct != null)
            {
                var editForm = new ProductEditForm(selectedProduct, _currentUser);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    await LoadDataAsync();
                    await LoadStatisticsAsync();
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silmək üçün məhsul seçin.", "Məlumat",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedProduct = (Mehsul)dgvProducts.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"'{selectedProduct.Ad}' məhsulunu silmək istədiyinizə əminsiniz?", "Təsdiq",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = await _mehsulService.DeleteMehsulAsync(selectedProduct.Id, _currentUser.Id);

                if (result.Success)
                {
                    MessageBox.Show(result.Message, "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    await LoadStatisticsAsync();
                }
                else
                {
                    MessageBox.Show(result.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private async void btnLowStock_Click(object sender, EventArgs e)
        {
            try
            {
                var lowStockProducts = await _mehsulService.GetStoktanKenardaMehsullarAsync();
                dgvProducts.DataSource = lowStockProducts;

                if (lowStockProducts.Count == 0)
                {
                    MessageBox.Show("Az stoklu məhsul tapılmadı.", "Məlumat",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Az stoklu məhsullar yüklənərkən xəta: {ex.Message}", "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Excel export funksiyası tezliklə əlavə ediləcək.", "Məlumat",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}