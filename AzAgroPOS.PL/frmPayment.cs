using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    /// <summary>
    /// Ödəniş prosesinin idarə edilməsi üçün form. Nağd, kart və nisyə ödənişlərinin qəbulunu təmin edir.
    /// </summary>
    public partial class frmPayment : Form
    {
        private readonly decimal _subTotal;
        private readonly Musteri _currentCustomer;

        /// <summary>
        /// Edilən ödənişlərin siyahısını saxlayır.
        /// </summary>
        public List<Odenis> Odenisler { get; private set; }

        /// <summary>
        /// Ümumi endirim məbləğini saxlayır.
        /// </summary>
        public decimal DiscountAmount { get; private set; }

        /// <summary>
        /// frmPayment konstruktoru. Ümumi məbləği və müştəri məlumatlarını qəbul edir.
        /// </summary>
        /// <param name="totalAmount">Ümumi satış məbləği</param>
        /// <param name="customer">Müştəri məlumatları (null ola bilər)</param>
        public frmPayment(decimal totalAmount, Musteri customer)
        {
            InitializeComponent();
            _subTotal = totalAmount;
            _currentCustomer = customer;

            // İlkin dəyərləri təyin et
            lblSubTotal.Text = _subTotal.ToString("F2") + " ₼";

            // Müştəri yoxdursa, nisyə ödənişini söndür
            if (_currentCustomer == null)
            {
                txtNisye.Enabled = false;
                txtNisye.Text = "0.00";
            }

            UpdateTotals();
        }

        #region Helper Methods

        /// <summary>
        /// Bütün məbləğləri yenidən hesablayır və interfeysi yeniləyir.
        /// </summary>
        private void UpdateTotals()
        {
            // Məbləğləri oxu
            decimal.TryParse(txtDiscount.Text, out decimal discountValue);
            decimal.TryParse(txtCash.Text, out decimal cashAmount);
            decimal.TryParse(txtCard.Text, out decimal cardAmount);
            decimal.TryParse(txtNisye.Text, out decimal nisyeAmount);

            // Endirim məbləğini təyin et
            this.DiscountAmount = discountValue;

            // Yekun məbləği hesabla
            decimal finalTotal = _subTotal - this.DiscountAmount;
            if (finalTotal < 0) finalTotal = 0;

            // Ödənilən məbləği hesabla
            decimal paidAmount = cashAmount + cardAmount + nisyeAmount;
            decimal change = paidAmount - finalTotal;

            // İnterfeysi yenilə
            lblTotalAmount.Text = finalTotal.ToString("F2") + " ₼";
            lblPaidAmount.Text = paidAmount.ToString("F2") + " ₼";
            lblChange.Text = change.ToString("F2") + " ₼";
            lblChange.ForeColor = (change < 0) ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }
        #endregion

        #region Event Handlers

        /// <summary>
        /// Mətn dəyişdikdə bütün hesablamaları yeniləyir.
        /// </summary>
        private void AnyTextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        
       

        /// <summary>
        /// Ödənişi ləğv etmək üçün düymə klik hadisəsi.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        /// <summary>
        /// Ödənişi təsdiqləmək üçün düymə klik hadisəsi.
        /// </summary>
        private void btnConfirmPayment_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Yekun məbləği hesabla
                decimal finalTotal = _subTotal - this.DiscountAmount;
                if (finalTotal < 0) finalTotal = 0;

                // Ödəniş məbləğlərini oxu
                decimal cashAmount, cardAmount, nisyeAmount;
                decimal.TryParse(txtCash.Text, out cashAmount);
                decimal.TryParse(txtCard.Text, out cardAmount);
                decimal.TryParse(txtNisye.Text, out nisyeAmount);
                decimal paidAmount = cashAmount + cardAmount + nisyeAmount;

                // Validasiya
                if (paidAmount < finalTotal)
                {
                    MessageBox.Show("Ödənilən məbləğ yekun məbləğdən az ola bilməz.",
                                  "Xəta",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    return;
                }

                // Nisyə borcu limit yoxlaması
                if (nisyeAmount > 0 && _currentCustomer != null)
                {
                    decimal newDebt = _currentCustomer.CariNisyeBorcu + nisyeAmount;
                    if (newDebt > _currentCustomer.NisyeLimiti)
                    {
                        MessageBox.Show("Nisyə limiti keçildi!",
                                      "Limit Xətası",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                        return;
                    }
                }

                // Ödənişləri hazırla
                Odenisler = new List<Odenis>();
                if (cashAmount > 0) Odenisler.Add(new Odenis { OdenisNovId = 1, OdenisMeblegi = cashAmount });
                if (cardAmount > 0) Odenisler.Add(new Odenis { OdenisNovId = 2, OdenisMeblegi = cardAmount });
                if (nisyeAmount > 0) Odenisler.Add(new Odenis { OdenisNovId = 3, OdenisMeblegi = nisyeAmount });

                // Formanı bağla
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ödəniş zamanı xəta baş verdi: {ex.Message}",
                              "Xəta",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }
    }
}