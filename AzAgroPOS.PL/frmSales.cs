// Fayl: AzAgroPOS.PL/frmSales.cs
using AzAgroPOS.BLL;
using AzAgroPOS.Entities;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class frmSales : Form
    {
        private readonly Istifadeci _currentUser;
        private readonly MehsulBLL _mehsulBll = new MehsulBLL();
        private readonly SatisBLL _satisBll = new SatisBLL();
        private readonly BindingList<SalesCartItem> _cartItems = new BindingList<SalesCartItem>();
        private Musteri _currentCustomer = null;

        public frmSales(Istifadeci user)
        {
            InitializeComponent();
            _currentUser = user;
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            dgvSalesCart.DataSource = _cartItems;
            SetupDataGrid();
            // Müştəri üçün label-i ilkin vəziyyətə gətiririk
            lblCustomerName.Text = "Qeydiyyatsız Müştəri";
        }

        private void SetupDataGrid()
        {
            dgvSalesCart.Columns["ProductId"].Visible = false;
            dgvSalesCart.Columns["Ad"].HeaderText = "Məhsul Adı";
            dgvSalesCart.Columns["Miqdar"].HeaderText = "Miqdar";
            dgvSalesCart.Columns["VahidQiymet"].HeaderText = "Vahid Qiyməti";
            dgvSalesCart.Columns["YekunMebleg"].HeaderText = "Yekun Məbləğ";
            dgvSalesCart.Columns["Ad"].ReadOnly = true;
            dgvSalesCart.Columns["VahidQiymet"].ReadOnly = true;
            dgvSalesCart.Columns["YekunMebleg"].ReadOnly = true;
            dgvSalesCart.Columns["Miqdar"].ReadOnly = false;
        }

        private void txtBarcodeSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barcode = txtBarcodeSearch.Text.Trim();
                if (string.IsNullOrEmpty(barcode)) return;
                var product = _mehsulBll.GetByBarcode(barcode);
                if (product != null)
                {
                    AddToCart(product);
                }
                else
                {
                    MessageBox.Show("Bu barkoda uyğun məhsul tapılmadı.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                txtBarcodeSearch.Clear();
                txtBarcodeSearch.Focus();
            }
        }

        private void AddToCart(Mehsul product)
        {
            var existingItem = _cartItems.FirstOrDefault(item => item.ProductId == product.Id);
            if (existingItem != null)
            {
                existingItem.Miqdar++;
            }
            else
            {
                _cartItems.Add(new SalesCartItem
                {
                    ProductId = product.Id,
                    Ad = product.Ad,
                    Miqdar = 1,
                    VahidQiymet = product.SatisQiymeti
                });
            }
            RefreshCartDisplay();
        }

        private void RefreshCartDisplay()
        {
            dgvSalesCart.Invalidate();
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            decimal total = _cartItems.Sum(item => item.YekunMebleg);
            lblTotalPrice.Text = total.ToString("F2") + " ₼";
        }

        private void dgvSalesCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            RefreshCartDisplay();
        }

        private void dgvSalesCart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dgvSalesCart.CurrentRow != null)
            {
                var itemToRemove = (SalesCartItem)dgvSalesCart.CurrentRow.DataBoundItem;
                if (itemToRemove != null)
                {
                    var result = MessageBox.Show($"'{itemToRemove.Ad}' adlı məhsulu səbətdən silmək istədiyinizə əminsinizmi?", "Silməyi Təsdiqlə", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        _cartItems.Remove(itemToRemove);
                        UpdateTotals();
                    }
                }
            }
        }

        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            using (frmCustomerSearch searchForm = new frmCustomerSearch())
            {
                if (searchForm.ShowDialog() == DialogResult.OK)
                {
                    _currentCustomer = searchForm.SelectedCustomer;
                    lblCustomerName.Text = $"Müştəri: {_currentCustomer.Ad} {_currentCustomer.Soyad}";
                }
            }
        }

        private void btnCompleteSale_Click(object sender, EventArgs e)
        {
            if (_cartItems.Count == 0)
            {
                MessageBox.Show("Satışı tamamlamaq üçün səbətə məhsul əlavə edin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalAmount = _cartItems.Sum(item => item.YekunMebleg);

            using (var paymentForm = new frmPayment(totalAmount, _currentCustomer))
            {
                if (paymentForm.ShowDialog() == DialogResult.OK)
                {
                    decimal actualPaidAmount = paymentForm.Odenisler.Sum(o => o.OdenisMeblegi);

                    var satis = new Satis
                    {
                        IstifadeciId = _currentUser.Id,
                        MusteriId = _currentCustomer?.Id,
                        YekunMebleg = totalAmount - paymentForm.DiscountAmount, // YEKUN MƏBLƏĞ DƏYİŞDİ
                        EndirimMeblegi = paymentForm.DiscountAmount,
                        OdenmisMebleg = Math.Min(totalAmount - paymentForm.DiscountAmount, paymentForm.Odenisler.Sum(o => o.OdenisMeblegi)),
                        Odenisler = paymentForm.Odenisler
                    };

                    foreach (var item in _cartItems)
                    {
                        satis.SatisMehsullari.Add(new SatisMehsulu
                        {
                            MehsulId = item.ProductId,
                            Miqdar = item.Miqdar,
                            QiymetBirEdede = item.VahidQiymet,
                            EndirimMeblegi = 0
                        });
                    }

                    bool result = _satisBll.Add(satis, out string message);
                    MessageBox.Show(message, result ? "Uğurlu" : "Xəta", MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                    if (result)
                    {
                        _cartItems.Clear();
                        RefreshCartDisplay();
                        _currentCustomer = null;
                        lblCustomerName.Text = "Qeydiyyatsız Müştəri";
                    }
                }
            }
        }
    }
}