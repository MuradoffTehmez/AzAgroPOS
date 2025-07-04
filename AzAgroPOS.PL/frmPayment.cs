// Fayl: AzAgroPOS.PL/frmPayment.cs
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class frmPayment : Form
    {
        private readonly decimal _totalAmount;
        public List<Odenis> Odenisler { get; private set; }

        public frmPayment(decimal totalAmount)
        {
            InitializeComponent();
            _totalAmount = totalAmount;
            lblTotalAmount.Text = _totalAmount.ToString("F2") + " ₼";
            // İlkin olaraq nağd xanasına tam məbləği yazırıq
            txtCash.Text = _totalAmount.ToString("F2");
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            decimal.TryParse(txtCash.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal cashAmount);
            decimal.TryParse(txtCard.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal cardAmount);

            decimal paidAmount = cashAmount + cardAmount;
            decimal change = paidAmount - _totalAmount;

            lblPaidAmount.Text = paidAmount.ToString("F2") + " ₼";
            lblChange.Text = change.ToString("F2") + " ₼";

            if (change < 0)
            {
                lblChange.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblChange.ForeColor = System.Drawing.Color.Green;
            }
        }

      

        private void btnConfirmPayment_Click_1(object sender, EventArgs e)
        {
            decimal.TryParse(txtCash.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal cashAmount);
            decimal.TryParse(txtCard.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal cardAmount);

            decimal paidAmount = cashAmount + cardAmount;

            if (paidAmount < _totalAmount)
            {
                MessageBox.Show("Ödənilən məbləğ yekun məbləğdən az ola bilməz.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Odenisler = new List<Odenis>();

            if (cashAmount > 0)
            {
                Odenisler.Add(new Odenis { OdenisNovId = 1, OdenisMeblegi = cashAmount }); // 1: Nağd
            }
            if (cardAmount > 0)
            {
                Odenisler.Add(new Odenis { OdenisNovId = 2, OdenisMeblegi = cardAmount }); // 2: Kart
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}