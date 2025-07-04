// Fayl: AzAgroPOS.PL/frmPayment.cs (Tam Yenilənmiş Versiya)
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
        private readonly decimal _totalAmount;
        private readonly Musteri _currentCustomer;
        public List<Odenis> Odenisler { get; private set; }

        public frmPayment(decimal totalAmount, Musteri customer)
        {
            InitializeComponent();
            _totalAmount = totalAmount;
            _currentCustomer = customer;
            lblTotalAmount.Text = _totalAmount.ToString("F2") + " ₼";
            txtCash.Text = _totalAmount.ToString("F2");

            // Əgər müştəri seçilməyibsə, nisyə xanasını deaktiv edirik
            if (_currentCustomer == null)
            {
                txtNisye.Enabled = false;
                txtNisye.Text = "0.00";
            }
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            decimal.TryParse(txtCash.Text, out decimal cashAmount);
            decimal.TryParse(txtCard.Text, out decimal cardAmount);
            decimal.TryParse(txtNisye.Text, out decimal nisyeAmount);

            decimal paidAmount = cashAmount + cardAmount + nisyeAmount;
            decimal change = paidAmount - _totalAmount;

            lblPaidAmount.Text = paidAmount.ToString("F2") + " ₼";
            lblChange.Text = change.ToString("F2") + " ₼";
            lblChange.ForeColor = (change < 0) ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            decimal.TryParse(txtCash.Text, out decimal cashAmount);
            decimal.TryParse(txtCard.Text, out decimal cardAmount);
            decimal.TryParse(txtNisye.Text, out decimal nisyeAmount);

            decimal paidAmount = cashAmount + cardAmount + nisyeAmount;

            if (paidAmount < _totalAmount)
            {
                MessageBox.Show("Ödənilən məbləğ yekun məbləğdən az ola bilməz (nisyə istisna olmaqla).", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nisyə limitini yoxlayırıq
            if (nisyeAmount > 0 && _currentCustomer != null)
            {
                decimal newDebt = _currentCustomer.CariNisyeBorcu + nisyeAmount;
                if (newDebt > _currentCustomer.NisyeLimiti)
                {
                    MessageBox.Show($"Nisyə limiti keçildi! Mövcud limit: {_currentCustomer.NisyeLimiti} ₼, Cari borc: {_currentCustomer.CariNisyeBorcu} ₼", "Limit Xətası", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}