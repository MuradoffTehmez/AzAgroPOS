using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.PL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class WarehouseManagementForm : BaseForm
    {
        private readonly AnbarRepository _anbarRepository;
        private readonly AnbarQalikRepository _anbarQalikRepository;
        private readonly AnbarHereketRepository _anbarHereketRepository;
        private readonly Istifadeci _currentUser;

        public WarehouseManagementForm(Istifadeci currentUser) : base()
        {
            InitializeComponent();
            var context = new AzAgroDbContext();
            _anbarRepository = new AnbarRepository(context);
            _anbarQalikRepository = new AnbarQalikRepository(context);
            _anbarHereketRepository = new AnbarHereketRepository(context);
            _currentUser = currentUser;
        }

        private async void WarehouseManagementForm_Load(object sender, EventArgs e)
        {
            await LoadWarehouses();
            await LoadWarehouseStock();
        }

        private async Task LoadWarehouses()
        {
            await ExecuteAsync(async () =>
            {
                var warehouses = _anbarRepository.GetAll();
                dgvWarehouses.DataSource = warehouses;
                
                // DataGridView sütunlarını nizamla
                if (dgvWarehouses.Columns.Count > 0)
                {
                    dgvWarehouses.Columns["Id"].HeaderText = "ID";
                    dgvWarehouses.Columns["Ad"].HeaderText = "Anbar Adı";
                    dgvWarehouses.Columns["Unvan"].HeaderText = "Ünvan";
                    dgvWarehouses.Columns["Mesul"].HeaderText = "Məsul";
                    dgvWarehouses.Columns["Status"].HeaderText = "Status";
                    dgvWarehouses.Columns["YaradilmaTarixi"].HeaderText = "Yaradılma Tarixi";
                    
                    // Digər sütunları gizlə
                    foreach (DataGridViewColumn column in dgvWarehouses.Columns)
                    {
                        if (!new[] { "Id", "Ad", "Unvan", "Mesul", "Status", "YaradilmaTarixi" }.Contains(column.Name))
                        {
                            column.Visible = false;
                        }
                    }
                }
            }, "Anbarlar yüklənərkən xəta baş verdi");
        }

        private async Task LoadWarehouseStock()
        {
            await ExecuteAsync(async () =>
            {
                var stockItems = await _anbarQalikRepository.GetAllWithDetailsAsync();
                dgvStock.DataSource = stockItems;
                
                // DataGridView sütunlarını nizamla
                if (dgvStock.Columns.Count > 0)
                {
                    dgvStock.Columns["Id"].HeaderText = "ID";
                    if (dgvStock.Columns.Contains("Anbar.Ad")) dgvStock.Columns["Anbar.Ad"].HeaderText = "Anbar";
                    if (dgvStock.Columns.Contains("Mehsul.Ad")) dgvStock.Columns["Mehsul.Ad"].HeaderText = "Məhsul";
                    dgvStock.Columns["MovcudMiqdar"].HeaderText = "Mövcud Miqdar";
                    dgvStock.Columns["MinimumMiqdar"].HeaderText = "Minimum Miqdar";
                    dgvStock.Columns["SonAlısTarixi"].HeaderText = "Son Alış";
                    dgvStock.Columns["SonSatısTarixi"].HeaderText = "Son Satış";
                    dgvStock.Columns["YenilenmeTarixi"].HeaderText = "Yenilənmə Tarixi";
                    
                    // Digər sütunları gizlə
                    foreach (DataGridViewColumn column in dgvStock.Columns)
                    {
                        if (!new[] { "Id", "AnbarId", "MehsulId", "MovcudMiqdar", "MinimumMiqdar", "SonAlısTarixi", "SonSatısTarixi", "YenilenmeTarixi" }.Contains(column.Name))
                        {
                            column.Visible = false;
                        }
                    }
                }
            }, "Anbar qalıqları yüklənərkən xəta baş verdi");
        }

        private async void btnAddWarehouse_Click(object sender, EventArgs e)
        {
            // var addForm = new WarehouseAddForm(_currentUser); // Form not found
            // if (addForm.ShowDialog() == DialogResult.OK)
            {
                await LoadWarehouses();
            }
        }

        private async void btnEditWarehouse_Click(object sender, EventArgs e)
        {
            if (dgvWarehouses.SelectedRows.Count == 0)
            {
                ShowInfo("Redaktə etmək üçün anbar seçin.");
                return;
            }

            var selectedWarehouse = (Anbar)dgvWarehouses.SelectedRows[0].DataBoundItem;
            // var editForm = new WarehouseEditForm(selectedWarehouse, _currentUser); // Form not found
            // if (editForm.ShowDialog() == DialogResult.OK)
            {
                await LoadWarehouses();
            }
        }

        private async void btnDeleteWarehouse_Click(object sender, EventArgs e)
        {
            if (dgvWarehouses.SelectedRows.Count == 0)
            {
                ShowInfo("Silmək üçün anbar seçin.");
                return;
            }

            var selectedWarehouse = (Anbar)dgvWarehouses.SelectedRows[0].DataBoundItem;
            
            if (ShowConfirmation($"'{selectedWarehouse.Ad}' anbarını silmək istədiyinizə əminsiniz?"))
            {
                await ExecuteAsync(async () =>
                {
                    // Anbarda məhsul qalığının olub-olmadığını yoxla
                    var stockItems = _anbarQalikRepository.GetByAnbar(selectedWarehouse.Id);
                    var hasStock = stockItems.Any(s => s.MovcudMiqdar > 0);
                    
                    if (hasStock)
                    {
                        ShowWarning("Bu anbarda məhsul qalığı var. Əvvəlcə məhsulları köçürün və ya bitirin.");
                        return;
                    }

                    // Anbar qalıqlarını sil
                    foreach (var stock in stockItems)
                    {
                        _anbarQalikRepository.Delete(stock.Id);
                    }

                    // Anbar hərəkətlərini sil
                    var movements = _anbarHereketRepository.GetByAnbar(selectedWarehouse.Id);
                    foreach (var movement in movements)
                    {
                        _anbarHereketRepository.Delete(movement.Id);
                    }

                    // Anbarı sil
                    _anbarRepository.Delete(selectedWarehouse.Id);
                    using (var context = new AzAgroDbContext()) { context.SaveChanges(); }

                    ShowSuccess("Anbar uğurla silindi!");
                    await LoadWarehouses();
                    await LoadWarehouseStock();
                }, "Anbar silinərkən xəta baş verdi");
            }
        }

        private async void btnTransferStock_Click(object sender, EventArgs e)
        {
            // var transferForm = new StockTransferForm(_currentUser); // Form not found
            // if (transferForm.ShowDialog() == DialogResult.OK)
            {
                await LoadWarehouseStock();
            }
        }

        private async void btnStockMovements_Click(object sender, EventArgs e)
        {
            // var movementsForm = new StockMovementsForm(_currentUser); // Form not found
            // movementsForm.ShowDialog();
        }

        private async void btnLowStockReport_Click(object sender, EventArgs e)
        {
            await ExecuteAsync(async () =>
            {
                var lowStockItems = await _anbarQalikRepository.GetLowStockItemsAsync();
                dgvStock.DataSource = lowStockItems;
                
                if (lowStockItems.Count == 0)
                {
                    ShowInfo("Az stoklu məhsul tapılmadı.");
                }
                else
                {
                    ShowInfo($"{lowStockItems.Count} az stoklu məhsul tapıldı.");
                }
            }, "Az stoklu məhsullar yüklənərkən xəta baş verdi");
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadWarehouses();
            await LoadWarehouseStock();
        }

        private void dgvWarehouses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditWarehouse_Click(sender, e);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tab dəyişəndə məlumatları yenilə
            if (tabControl.SelectedTab == tabStock)
            {
                await LoadWarehouseStock();
            }
            else if (tabControl.SelectedTab == tabWarehouses)
            {
                await LoadWarehouses();
            }
        }
    }
}