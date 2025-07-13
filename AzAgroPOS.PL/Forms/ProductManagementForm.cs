using AzAgroPOS.BLL.Services;
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
        private List<Mehsul> _allProducts;
        private List<Mehsul> _filteredProducts;

        public ProductManagementForm(Istifadeci currentUser)
        {
            InitializeComponent();
            _mehsulService = new MehsulService();
            _mehsulRepository = new MehsulRepository();
            _kateqoriyaRepository = new MehsulKateqoriyasiRepository();
            _currentUser = currentUser;
        }

        private async void ProductManagementForm_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            SetupDataGridView();
            await LoadFiltersAsync();
            await LoadStatisticsAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                _allProducts = await _mehsulRepository.GetAllAsync();
                _filteredProducts = _allProducts.ToList();
                LoadProductsToGrid();
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

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "Id",
                Width = 50,
                Visible = false
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Ad",
                HeaderText = "Məhsul Adı",
                Name = "Ad",
                Width = 200
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SKU",
                HeaderText = "SKU",
                Name = "SKU",
                Width = 120
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Barkod",
                HeaderText = "Barkod",
                Name = "Barkod",
                Width = 120
            });

            var categoryColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Kateqoriya",
                Name = "Kateqoriya",
                Width = 150
            };
            dgvProducts.Columns.Add(categoryColumn);

            var unitColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Vahid",
                Name = "Vahid",
                Width = 80
            };
            dgvProducts.Columns.Add(unitColumn);

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AlisQiymeti",
                HeaderText = "Alış Qiyməti",
                Name = "AlisQiymeti",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "F2" }
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SatisQiymeti",
                HeaderText = "Satış Qiyməti",
                Name = "SatisQiymeti",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "F2" }
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MovcudMiqdar",
                HeaderText = "Stok",
                Name = "MovcudMiqdar",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "F2" }
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Status",
                Name = "Status",
                Width = 80
            });

            // Low stock indicator
            var lowStockColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Stok Vəziyyəti",
                Name = "StokVeziyyeti",
                Width = 100
            };
            dgvProducts.Columns.Add(lowStockColumn);
        }

        private void LoadProductsToGrid()
        {
            dgvProducts.Rows.Clear();

            if (_filteredProducts == null || !_filteredProducts.Any())
            {
                // Boş məhsul siyahısı halında xəta göstərməyin, sadəcə boş grid-i göstərin
                return;
            }

            foreach (var product in _filteredProducts)
            {
                var row = new DataGridViewRow();
                row.CreateCells(dgvProducts);

                row.Cells["Id"].Value = product.Id;
                row.Cells["Ad"].Value = product.Ad;
                row.Cells["SKU"].Value = product.SKU;
                row.Cells["Barkod"].Value = product.Barkod;
                row.Cells["Kateqoriya"].Value = product.Kateqoriya?.Ad ?? "N/A";
                row.Cells["Vahid"].Value = product.Vahid?.QisaAd ?? "N/A";
                row.Cells["AlisQiymeti"].Value = product.AlisQiymeti;
                row.Cells["SatisQiymeti"].Value = product.SatisQiymeti;
                row.Cells["MovcudMiqdar"].Value = product.MovcudMiqdar;
                row.Cells["Status"].Value = product.Status;

                string stokVeziyyeti = product.StoktanKenarda ? "Az Stok" : "Normal";
                row.Cells["StokVeziyyeti"].Value = stokVeziyyeti;

                if (product.StoktanKenarda)
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightSalmon;
                }
                else if (product.Status == "Deaktiv")
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                }

                dgvProducts.Rows.Add(row);
            }
        }

        private async Task LoadFiltersAsync()
        {
            try
            {
                // Categories
                var categories = await _kateqoriyaRepository.GetAllActiveAsync();
                cmbCategory.Items.Clear();
                cmbCategory.Items.Add(new { Id = 0, Ad = "Bütün Kateqoriyalar" });
                foreach (var category in categories)
                {
                    cmbCategory.Items.Add(new { Id = category.Id, Ad = category.Ad });
                }
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
                int? categoryId = cmbCategory.SelectedValue as int? == 0 ? null : cmbCategory.SelectedValue as int?;
                string status = cmbStatus.SelectedItem?.ToString() == "Hamısı" ? null : cmbStatus.SelectedItem?.ToString();

                _filteredProducts = await _mehsulService.GetMehsullarByFiltersAsync(searchTerm, categoryId, status);
                LoadProductsToGrid();
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

            var selectedId = (int)dgvProducts.SelectedRows[0].Cells["Id"].Value;
            var product = await _mehsulRepository.GetByIdAsync(selectedId);
            
            if (product != null)
            {
                var editForm = new ProductEditForm(product, _currentUser);
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

            var selectedId = (int)dgvProducts.SelectedRows[0].Cells["Id"].Value;
            var productName = dgvProducts.SelectedRows[0].Cells["Ad"].Value.ToString();

            if (MessageBox.Show($"'{productName}' məhsulunu silmək istədiyinizə əminsiniz?", "Təsdiq", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = await _mehsulService.DeleteMehsulAsync(selectedId, _currentUser.Id);
                
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
                _filteredProducts = lowStockProducts;
                LoadProductsToGrid();

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