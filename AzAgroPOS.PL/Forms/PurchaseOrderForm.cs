using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.PL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class PurchaseOrderForm : BaseForm
    {
        private readonly MehsulService _mehsulService;
        private readonly TedarukcuRepository _tedarukcuRepository;
        private readonly AlisOrderRepository _alisOrderRepository;
        private readonly AlisSenediRepository _alisSenediRepository;
        private readonly Istifadeci _currentUser;
        private List<AlisDetaliItem> _alisDetallari;
        private decimal _vergiOrani = 0.18m; // 18% vergi

        public PurchaseOrderForm(Istifadeci currentUser) : base()
        {
            InitializeComponent();
            var context = new AzAgroDbContext();
            _mehsulService = ServiceFactory.CreateMehsulService();
            _tedarukcuRepository = new TedarukcuRepository(context);
            _alisOrderRepository = new AlisOrderRepository(context);
            _alisSenediRepository = new AlisSenediRepository(context);
            _currentUser = currentUser;
            _alisDetallari = new List<AlisDetaliItem>();
        }

        private async void PurchaseOrderForm_Load(object sender, EventArgs e)
        {
            await LoadSuppliersAsync();
            await LoadProductsAsync();
            InitializeDataGridView();
            UpdateCalculations();
        }

        private async Task LoadSuppliersAsync()
        {
            await ExecuteAsync(async () =>
            {
                var suppliers = await _tedarukcuRepository.GetAllActiveAsync();
                cmbSupplier.DataSource = suppliers;
                cmbSupplier.DisplayMember = \"Ad\";
                cmbSupplier.ValueMember = \"Id\";
                cmbSupplier.SelectedIndex = -1;
            }, \"Tədarükçülər yüklənərkən xəta baş verdi\");
        }

        private async Task LoadProductsAsync()
        {
            await ExecuteAsync(async () =>
            {
                var products = _mehsulService.GetAllActive();
                cmbProduct.DataSource = products;
                cmbProduct.DisplayMember = \"Ad\";
                cmbProduct.ValueMember = \"Id\";
                cmbProduct.SelectedIndex = -1;
            }, \"Məhsullar yüklənərkən xəta baş verdi\");
        }

        private void InitializeDataGridView()
        {
            dgvOrderDetails.Columns.Clear();
            dgvOrderDetails.Columns.Add(\"MehsulAdi\", \"Məhsul Adı\");
            dgvOrderDetails.Columns.Add(\"Miqdar\", \"Miqdar\");
            dgvOrderDetails.Columns.Add(\"VahidQiymeti\", \"Vahid Qiyməti\");
            dgvOrderDetails.Columns.Add(\"UmumiQiymet\", \"Ümumi Qiymət\");
            
            var deleteColumn = new DataGridViewButtonColumn
            {
                Name = \"Delete\",
                HeaderText = \"Əməliyyat\",
                Text = \"Sil\",
                UseColumnTextForButtonValue = true,
                Width = 70
            };
            dgvOrderDetails.Columns.Add(deleteColumn);
            
            dgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderDetails.AllowUserToAddRows = false;
            dgvOrderDetails.ReadOnly = true;
            dgvOrderDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedValue == null)
            {
                ShowWarning(\"Məhsul seçin!\");
                return;
            }

            if (!decimal.TryParse(txtQuantity.Text, out decimal quantity) || quantity <= 0)
            {
                ShowWarning(\"Düzgün miqdar daxil edin!\");
                return;
            }

            if (!decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice) || unitPrice <= 0)
            {
                ShowWarning(\"Düzgün vahid qiymət daxil edin!\");
                return;
            }

            var selectedProduct = (Mehsul)cmbProduct.SelectedItem;
            
            // Əgər məhsul artıq varsa, miqdarı artır
            var existingItem = _alisDetallari.FirstOrDefault(x => x.MehsulId == selectedProduct.Id);
            if (existingItem != null)
            {
                existingItem.Miqdar += quantity;
                existingItem.VahidQiymeti = unitPrice; // Qiyməti yenilə
            }
            else
            {
                _alisDetallari.Add(new AlisDetaliItem
                {
                    MehsulId = selectedProduct.Id,
                    MehsulAdi = selectedProduct.Ad,
                    Miqdar = quantity,
                    VahidQiymeti = unitPrice
                });
            }

            RefreshDataGridView();
            UpdateCalculations();
            ClearProductInputs();
            SystemSounds.Beep.Play();
        }

        private void RefreshDataGridView()
        {
            dgvOrderDetails.Rows.Clear();
            
            foreach (var item in _alisDetallari)
            {
                dgvOrderDetails.Rows.Add(
                    item.MehsulAdi,
                    item.Miqdar.ToString(\"F2\"),
                    item.VahidQiymeti.ToString(\"F2\") + \" ₼\",
                    item.UmumiQiymet.ToString(\"F2\") + \" ₼\"
                );
            }
        }

        private void UpdateCalculations()
        {
            decimal subtotal = _alisDetallari.Sum(x => x.UmumiQiymet);
            decimal discount = decimal.TryParse(txtDiscount.Text, out var d) ? d : 0;
            decimal tax = (subtotal - discount) * _vergiOrani;
            decimal total = subtotal - discount + tax;

            lblSubtotal.Text = subtotal.ToString(\"F2\") + \" ₼\";
            lblTax.Text = tax.ToString(\"F2\") + \" ₼\";
            lblTotal.Text = total.ToString(\"F2\") + \" ₼\";
        }

        private void ClearProductInputs()
        {
            cmbProduct.SelectedIndex = -1;
            txtQuantity.Clear();
            txtUnitPrice.Clear();
            cmbProduct.Focus();
        }

        private void dgvOrderDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvOrderDetails.Columns[\"Delete\"].Index && e.RowIndex >= 0)
            {
                if (ShowConfirmation(\"Bu məhsulu silmək istədiyinizə əminsiniz?\"))
                {
                    _alisDetallari.RemoveAt(e.RowIndex);
                    RefreshDataGridView();
                    UpdateCalculations();
                }
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            UpdateCalculations();
        }

        private async void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (cmbSupplier.SelectedValue == null)
            {
                ShowWarning(\"Tədarükçü seçin!\");
                return;
            }

            if (_alisDetallari.Count == 0)
            {
                ShowWarning(\"Sifariş üçün məhsul əlavə edin!\");
                return;
            }

            await ExecuteAsync(async () =>
            {
                var supplier = (Tedarukcu)cmbSupplier.SelectedItem;
                
                var order = new AlisOrder
                {
                    SifarisNomresi = GenerateOrderNumber(),
                    SifarisTarixi = DateTime.Now,
                    TedarukcuId = supplier.Id,
                    Status = \"Gözləmədə\",
                    UmumiMebleg = _alisDetallari.Sum(x => x.UmumiQiymet),
                    EndirimMeblegi = decimal.TryParse(txtDiscount.Text, out var discount) ? discount : 0,
                    VergiMeblegi = decimal.Parse(lblTax.Text.Replace(\" ₼\", \"\").Trim()),
                    NetMebleg = decimal.Parse(lblTotal.Text.Replace(\" ₼\", \"\").Trim()),
                    Qeydler = txtNotes.Text,
                    YaradanIstifadeciId = _currentUser.Id,
                    YaradilmaTarixi = DateTime.Now,
                    AlisDetallari = _alisDetallari.Select(item => new AlisDetali
                    {
                        MehsulId = item.MehsulId,
                        MehsulAdi = item.MehsulAdi,
                        Miqdar = item.Miqdar,
                        VahidQiymeti = item.VahidQiymeti,
                        UmumiQiymet = item.UmumiQiymet
                    }).ToList()
                };

                await _alisOrderRepository.AddAsync(order);
                await _alisOrderRepository.SaveChangesAsync();

                ShowSuccess($\"Sifariş uğurla yaradıldı!\\nSifariş nömrəsi: {order.SifarisNomresi}\");
                
                // Yeni sifariş üçün formu təmizlə
                ClearForm();
                
            }, \"Sifariş yaradılarkən xəta baş verdi\");
        }

        private async void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            if (cmbSupplier.SelectedValue == null)
            {
                ShowWarning(\"Tədarükçü seçin!\");
                return;
            }

            if (_alisDetallari.Count == 0)
            {
                ShowWarning(\"Sənəd üçün məhsul əlavə edin!\");
                return;
            }

            await ExecuteAsync(async () =>
            {
                var supplier = (Tedarukcu)cmbSupplier.SelectedItem;
                
                var invoice = new AlisSenedi
                {
                    SenedNomresi = GenerateInvoiceNumber(),
                    SenedTarixi = DateTime.Now,
                    TedarukcuId = supplier.Id,
                    Status = \"Tamamlandı\",
                    UmumiMebleg = _alisDetallari.Sum(x => x.UmumiQiymet),
                    EndirimMeblegi = decimal.TryParse(txtDiscount.Text, out var discount) ? discount : 0,
                    VergiMeblegi = decimal.Parse(lblTax.Text.Replace(\" ₼\", \"\").Trim()),
                    NetMebleg = decimal.Parse(lblTotal.Text.Replace(\" ₼\", \"\").Trim()),
                    Qeydler = txtNotes.Text,
                    YaradanIstifadeciId = _currentUser.Id,
                    YaradilmaTarixi = DateTime.Now,
                    AlisDetallari = _alisDetallari.Select(item => new AlisDetali
                    {
                        MehsulId = item.MehsulId,
                        MehsulAdi = item.MehsulAdi,
                        Miqdar = item.Miqdar,
                        VahidQiymeti = item.VahidQiymeti,
                        UmumiQiymet = item.UmumiQiymet
                    }).ToList()
                };

                await _alisSenediRepository.AddAsync(invoice);
                
                // Alış sənədi yaradıldıqda anbar qalıqlarını artır
                foreach (var item in _alisDetallari)
                {
                    var mehsul = _mehsulService.GetById(item.MehsulId);
                    if (mehsul != null)
                    {
                        mehsul.MovcudMiqdar += item.Miqdar;
                        mehsul.YenilenmeTarixi = DateTime.Now;
                        _mehsulService.Update(mehsul);
                    }
                }

                await _alisSenediRepository.SaveChangesAsync();

                ShowSuccess($\"Alış sənədi uğurla yaradıldı!\\nSənəd nömrəsi: {invoice.SenedNomresi}\");
                
                // Yeni sənəd üçün formu təmizlə
                ClearForm();
                
            }, \"Alış sənədi yaradılarkən xəta baş verdi\");
        }

        private void ClearForm()
        {
            cmbSupplier.SelectedIndex = -1;
            _alisDetallari.Clear();
            RefreshDataGridView();
            UpdateCalculations();
            txtDiscount.Text = \"0\";
            txtNotes.Clear();
            ClearProductInputs();
        }

        private string GenerateOrderNumber()
        {
            return $\"ORD-{DateTime.Now:yyyyMMdd}-{DateTime.Now:HHmmss}\";
        }

        private string GenerateInvoiceNumber()
        {
            return $\"INV-{DateTime.Now:yyyyMMdd}-{DateTime.Now:HHmmss}\";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem is Mehsul selectedProduct)
            {
                txtUnitPrice.Text = selectedProduct.AlisQiymeti.ToString(\"F2\");
            }
        }
    }

    public class AlisDetaliItem
    {
        public int MehsulId { get; set; }
        public string MehsulAdi { get; set; }
        public decimal Miqdar { get; set; }
        public decimal VahidQiymeti { get; set; }
        public decimal UmumiQiymet => Miqdar * VahidQiymeti;
    }
}