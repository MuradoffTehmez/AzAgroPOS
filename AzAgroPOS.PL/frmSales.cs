using AzAgroPOS.BLL;
using AzAgroPOS.Entities;
using AzAgroPOS.PL.Printing;
using AzAgroPOS.PL.Themes;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    /// <summary>
    /// Satış əməliyyatlarının idarə edilməsi üçün form. Məhsulların satışı, müştəri seçimi və ödəniş prosesini təmin edir.
    /// </summary>
    public partial class frmSales : BaseForm
    {
        #region Private Fields
        private readonly Istifadeci _currentUser;
        private readonly MehsulBLL _mehsulBll = new MehsulBLL();
        private readonly SatisBLL _satisBll = new SatisBLL();
        private readonly BindingList<SalesCartItem> _cartItems = new BindingList<SalesCartItem>();
        private Musteri _currentCustomer = null;
        #endregion

        /// <summary>
        /// frmSales konstruktoru. Daxil olmuş istifadəçi məlumatlarını qəbul edir.
        /// </summary>
        /// <param name="currentUser">Daxil olmuş istifadəçi obyekti</param>
        /// <exception cref="ArgumentNullException">currentUser parametri null olduqda baş verir</exception>
        public frmSales(Istifadeci currentUser)
        {
            if (currentUser == null)
            {
                throw new ArgumentNullException(nameof(currentUser), "İstifadəçi məlumatları boş ola bilməz");
            }

            InitializeComponent();
            _currentUser = currentUser;
        }

        /// <summary>
        /// Form yüklənərkən işə düşən metod. İlkin tənzimləmələri edir.
        /// </summary>
        private void frmSales_Load(object sender, EventArgs e)
        {
            try
            {
                dgvSalesCart.DataSource = _cartItems;
                SetupDataGrid();
                lblCustomerName.Text = "Qeydiyyatsız Müştəri";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Form yüklənərkən xəta baş verdi: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #region Helper Methods

        /// <summary>
        /// DataGridView sütunlarını tənzimləyir. Gizlədilməsi lazım olan sütunları gizlədir.
        /// </summary>
        private void SetupDataGrid()
        {
            try
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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DataGridView tənzimləmə xətası: {ex.Message}");
            }
        }

        /// <summary>
        /// Məhsulu səbətə əlavə edir. Əgər məhsul artıq səbətdədirsə, miqdarını artırır.
        /// </summary>
        /// <param name="product">Əlavə ediləcək məhsul</param>
        /// <exception cref="ArgumentNullException">product parametri null olduqda baş verir</exception>
        private void AddToCart(Mehsul product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Məhsul məlumatları boş ola bilməz");
            }

            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsul səbətə əlavə edilərkən xəta: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Səbətin görüntüsünü yeniləyir.
        /// </summary>
        private void RefreshCartDisplay()
        {
            try
            {
                dgvSalesCart.Invalidate();
                UpdateTotals();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Səbət yeniləmə xətası: {ex.Message}");
            }
        }

        /// <summary>
        /// Ümumi məbləği hesablayır və göstərir.
        /// </summary>
        private void UpdateTotals()
        {
            try
            {
                decimal total = _cartItems.Sum(item => item.YekunMebleg);
                lblTotalPrice.Text = total.ToString("F2") + " ₼";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ümumi məbləğ hesablanarkən xəta: {ex.Message}");
            }
        }
        #endregion

        #region Event Handlers

        /// <summary>
        /// Barkod axtarış sahəsində Enter düyməsinə basıldıqda işə düşən metod.
        /// </summary>
        private void txtBarcodeSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
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
                        MessageBox.Show("Bu barkoda uyğun məhsul tapılmadı.",
                            "Məlumat",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    txtBarcodeSearch.Clear();
                    txtBarcodeSearch.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Axtarış zamanı xəta: {ex.Message}",
                        "Xəta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Səbət cədvəlində dəyər dəyişdikdə işə düşən metod.
        /// </summary>
        private void dgvSalesCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                RefreshCartDisplay();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Səbət yeniləmə xətası: {ex.Message}");
            }
        }

        /// <summary>
        /// Səbət cədvəlində Delete düyməsinə basıldıqda işə düşən metod.
        /// </summary>
        private void dgvSalesCart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dgvSalesCart.CurrentRow != null)
            {
                try
                {
                    var itemToRemove = (SalesCartItem)dgvSalesCart.CurrentRow.DataBoundItem;
                    if (itemToRemove != null)
                    {
                        var result = MessageBox.Show($"'{itemToRemove.Ad}' adlı məhsulu səbətdən silmək istədiyinizə əminsinizmi?",
                                                  "Silməyi Təsdiqlə",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            _cartItems.Remove(itemToRemove);
                            UpdateTotals();
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
        }

        /// <summary>
        /// Müştəri seçmək üçün düymə klik hadisəsi.
        /// </summary>
        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Müştəri seçimi zamanı xəta: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Satışı tamamlamaq üçün düymə klik hadisəsi.
        /// </summary>
        private void btnCompleteSale_Click(object sender, EventArgs e)
        {
            try
            {
                if (_cartItems.Count == 0)
                {
                    MessageBox.Show("Satışı tamamlamaq üçün səbətə məhsul əlavə edin.",
                        "Xəbərdarlıq",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                decimal totalAmount = _cartItems.Sum(item => item.YekunMebleg);

                using (var paymentForm = new frmPayment(totalAmount, _currentCustomer))
                {
                    if (paymentForm.ShowDialog() == DialogResult.OK)
                    {
                        decimal actualPaidAmount = paymentForm.Odenisler.Sum(o => o.OdenisMeblegi);
                        decimal discountAmount = paymentForm.DiscountAmount;
                        decimal finalAmount = totalAmount - discountAmount;

                        var satis = new Satis
                        {
                            IstifadeciId = _currentUser.Id,
                            MusteriId = _currentCustomer?.Id,
                            EndirimMeblegi = discountAmount,
                            YekunMebleg = finalAmount,
                            OdenmisMebleg = Math.Min(finalAmount, actualPaidAmount),
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

                        bool result = _satisBll.Add(satis, _currentUser, out string message);

                        if (result)
                        {
                            var printResult = MessageBox.Show(message + "\n\nÇeki çap etmək istəyirsinizmi?",
                                "Uğurlu Satış",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information);

                            if (printResult == DialogResult.Yes)
                            {
                                var fullSatisInfo = _satisBll.GetById(satis.Id);
                                if (fullSatisInfo != null)
                                {
                                    var printer = new ChequePrinterService(fullSatisInfo);
                                    printer.Print();
                                }
                            }

                            _cartItems.Clear();
                            RefreshCartDisplay();
                            _currentCustomer = null;
                            lblCustomerName.Text = "Qeydiyyatsız Müştəri";
                        }
                        else
                        {
                            MessageBox.Show(message,
                                "Xəta",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satış zamanı xəta: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Məhsul miqdarını artırmaq üçün düymə klik hadisəsi.
        /// </summary>
        private void btnIncreaseQty_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSalesCart.CurrentRow != null)
                {
                    var item = (SalesCartItem)dgvSalesCart.CurrentRow.DataBoundItem;
                    if (item != null)
                    {
                        item.Miqdar++;
                        RefreshCartDisplay();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Miqdar artırılarkən xəta: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Məhsul miqdarını azaltmaq üçün düymə klik hadisəsi.
        /// </summary>
        private void btnDecreaseQty_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSalesCart.CurrentRow != null)
                {
                    var item = (SalesCartItem)dgvSalesCart.CurrentRow.DataBoundItem;
                    if (item != null && item.Miqdar > 1)
                    {
                        item.Miqdar--;
                        RefreshCartDisplay();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Miqdar azaldılarkən xəta: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Məhsulu səbətdən silmək üçün düymə klik hadisəsi.
        /// </summary>
        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSalesCart.CurrentRow != null)
                {
                    var itemToRemove = (SalesCartItem)dgvSalesCart.CurrentRow.DataBoundItem;
                    if (itemToRemove != null)
                    {
                        var result = MessageBox.Show($"'{itemToRemove.Ad}' adlı məhsulu səbətdən silmək istədiyinizə əminsinizmi?",
                                                  "Silməyi Təsdiqlə",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            _cartItems.Remove(itemToRemove);
                            UpdateTotals();
                        }
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
        #endregion
    }
}