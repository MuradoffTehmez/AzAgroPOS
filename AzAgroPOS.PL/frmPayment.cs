using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class frmPayment : Form
    {
        private readonly decimal _subTotal;
        private readonly Musteri _currentCustomer;
        public List<Odenis> Odenisler { get; private set; }
        public decimal DiscountAmount { get; private set; }

        public frmPayment(decimal totalAmount, Musteri customer)
        {
            InitializeComponent();
            _subTotal = totalAmount;
            _currentCustomer = customer;

            lblSubTotal.Text = _subTotal.ToString("F2") + " ₼";

            if (_currentCustomer == null)
            {
                txtNisye.Enabled = false;
                txtNisye.Text = "0.00";
            }
            // İlkin olaraq bütün hesablamaları yeniləyirik
            UpdateTotals();
        }

        private void AnyTextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            decimal.TryParse(txtDiscount.Text, out decimal discountValue);
            decimal.TryParse(txtCash.Text, out decimal cashAmount);
            decimal.TryParse(txtCard.Text, out decimal cardAmount);
            decimal.TryParse(txtNisye.Text, out decimal nisyeAmount);

            // Endirim məbləğini hesabla
            this.DiscountAmount = discountValue; // Sabit məbləğ kimi

            decimal finalTotal = _subTotal - this.DiscountAmount;
            if (finalTotal < 0) finalTotal = 0; // Yekun mənfi ola bilməz

            decimal paidAmount = cashAmount + cardAmount + nisyeAmount;
            decimal change = paidAmount - finalTotal;

            lblTotalAmount.Text = finalTotal.ToString("F2") + " ₼";
            lblPaidAmount.Text = paidAmount.ToString("F2") + " ₼";
            lblChange.Text = change.ToString("F2") + " ₼";
            lblChange.ForeColor = (change < 0) ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }

        private void btnConfirmPayment_Click_1(object sender, EventArgs e)
        {
            decimal finalTotal = _subTotal - this.DiscountAmount;
            if (finalTotal < 0) finalTotal = 0;

            decimal cashAmount, cardAmount, nisyeAmount;
            decimal.TryParse(txtCash.Text, out cashAmount);
            decimal.TryParse(txtCard.Text, out cardAmount);
            decimal.TryParse(txtNisye.Text, out nisyeAmount);
            decimal paidAmount = cashAmount + cardAmount + nisyeAmount;

            if (paidAmount < finalTotal)
            {
                MessageBox.Show("Ödənilən məbləğ yekun məbləğdən az ola bilməz.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nisyeAmount > 0 && _currentCustomer != null)
            {
                decimal newDebt = _currentCustomer.CariNisyeBorcu + nisyeAmount;
                if (newDebt > _currentCustomer.NisyeLimiti)
                {
                    MessageBox.Show("Nisyə limiti keçildi!", "Limit Xətası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Odenisler = new List<Odenis>();
            if (cashAmount > 0) Odenisler.Add(new Odenis { OdenisNovId = 1, OdenisMeblegi = cashAmount });
            if (cardAmount > 0) Odenisler.Add(new Odenis { OdenisNovId = 2, OdenisMeblegi = cardAmount });
            if (nisyeAmount > 0) Odenisler.Add(new Odenis { OdenisNovId = 3, OdenisMeblegi = nisyeAmount });

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}