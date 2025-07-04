// Fayl: AzAgroPOS.PL/frmSales.cs
using AzAgroPOS.BLL;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
       public partial class frmSales : Form
    {
        private readonly MehsulBLL _mehsulBll = new MehsulBLL();
        // Səbətdəki məhsulları yadda saxlamaq üçün List
        private BindingList<SalesCartItem> _cartItems = new BindingList<SalesCartItem>();

        public frmSales()
        {
            InitializeComponent();
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            // Cədvəli (DataGridView) səbətimizə bağlayırıq
            dgvSalesCart.DataSource = _cartItems;
            SetupDataGrid();
        }

        private void SetupDataGrid()
        {
            // Sütunların adlarını və görünüşünü dəyişirik
            dgvSalesCart.Columns["ProductId"].Visible = false;
            dgvSalesCart.Columns["Ad"].HeaderText = "Məhsul Adı";
            dgvSalesCart.Columns["Miqdar"].HeaderText = "Miqdar";
            dgvSalesCart.Columns["VahidQiymet"].HeaderText = "Vahid Qiyməti";
            dgvSalesCart.Columns["YekunMebleg"].HeaderText = "Yekun Məbləğ";
        }

        private void txtBarcodeSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // Yalnız Enter düyməsinə basıldıqda işləsin
            if (e.KeyCode == Keys.Enter)
            {
                string barcode = txtBarcodeSearch.Text.Trim();
                if (string.IsNullOrEmpty(barcode)) return;

                // Barkoda görə məhsulu axtarırıq
                var product = _mehsulBll.GetByBarcode(barcode);

                if (product != null)
                {
                    // Məhsul tapılıbsa, səbətə əlavə edirik
                    AddToCart(product);
                }
                else
                {
                    MessageBox.Show("Bu barkoda uyğun məhsul tapılmadı.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Axtarış xanasını təmizləyirik və fokusu qaytarırıq
                txtBarcodeSearch.Clear();
                txtBarcodeSearch.Focus();
            }
        }

        private void AddToCart(Mehsul product)
        {
            // Məhsulun səbətdə olub-olmadığını yoxlayırıq
            var existingItem = _cartItems.FirstOrDefault(item => item.ProductId == product.Id);

            if (existingItem != null)
            {
                // Əgər varsa, sayını bir artırırıq
                existingItem.Miqdar++;
            }
            else
            {
                // Yoxdursa, yeni bir sətir olaraq əlavə edirik
                _cartItems.Add(new SalesCartItem
                {
                    ProductId = product.Id,
                    Ad = product.Ad,
                    Miqdar = 1,
                    VahidQiymet = product.SatisQiymeti
                });
            }

            // Cədvəli və yekun məbləği yeniləyirik
            RefreshCartDisplay();
        }

        private void RefreshCartDisplay()
        {
            dgvSalesCart.Refresh();
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            decimal total = _cartItems.Sum(item => item.YekunMebleg);
            lblTotalPrice.Text = total.ToString("F2") + " ₼";
        }

        private void btnCompleteSale_Click(object sender, EventArgs e)
        {

        }
    }
}