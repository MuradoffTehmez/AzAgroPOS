using AzAgroPOS.BLL;
using AzAgroPOS.Entities;
using AzAgroPOS.PL.Themes;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class frmReturn : BaseForm
    {
        private readonly Istifadeci _currentUser;
        private readonly SatisBLL _satisBll = new SatisBLL();
        private Satis _foundSale;

        public frmReturn(Istifadeci currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }

        private void btnFindSale_Click(object sender, EventArgs e)
        {
            ClearForm();
            string chequeNumber = txtChequeNumber.Text.Trim();
            if (string.IsNullOrWhiteSpace(chequeNumber)) return;

            // Çek nömrəsindən ID-ni çıxarırıq (məs: CHK-20250705-000012 -> 12)
            try
            {
                int saleId = int.Parse(chequeNumber.Split('-')[2]);
                _foundSale = _satisBll.GetById(saleId);

                if (_foundSale != null)
                {
                    if (_foundSale.Qaytarilib)
                    {
                        MessageBox.Show("Bu satış artıq daha əvvəl ləğv edilib/qaytarılıb.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _foundSale = null;
                        return;
                    }
                    DisplaySaleInfo();
                }
                else
                {
                    MessageBox.Show("Bu nömrəyə uyğun satış tapılmadı.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Daxil edilən çek nömrəsi düzgün formatda deyil. Nümunə: CHK-20250705-000012", "Format Xətası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplaySaleInfo()
        {
            lblTarix.Text = "Tarix: " + _foundSale.SatisTarixi.ToString("dd.MM.yyyy HH:mm");
            lblMusteri.Text = "Müştəri: " + _foundSale.MusteriAdi;
            lblKassir.Text = "Kassir: " + _foundSale.IstifadeciAdi;

            dgvReturnedItems.DataSource = _foundSale.SatisMehsullari;
            SetupGrid();
            btnProcessReturn.Enabled = true;
        }

        private void SetupGrid()
        {
            // ... Sütunları səliqəyə salmaq üçün kod ...
        }

        private void ClearForm()
        {
            _foundSale = null;
            lblTarix.Text = "Tarix:";
            lblMusteri.Text = "Müştəri:";
            lblKassir.Text = "Kassir:";
            dgvReturnedItems.DataSource = null;
            btnProcessReturn.Enabled = false;
        }

        private void btnProcessReturn_Click(object sender, EventArgs e)
        {
            if (_foundSale == null) return;

            var result = MessageBox.Show($"ID: {_foundSale.Id} olan satışı ləğv etmək istədiyinizə əminsinizmi? Bu əməliyyat anbar qalığını geri qaytaracaq.",
                                         "Qaytarmanı Təsdiqlə",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bool opResult = _satisBll.Cancel(_foundSale.Id, _currentUser, out string message);
                MessageBox.Show(message, opResult ? "Uğurlu" : "Xəta", MessageBoxButtons.OK, opResult ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (opResult)
                {
                    ClearForm();
                    txtChequeNumber.Clear();
                }
            }
        }

        private void frmReturn_Load(object sender, EventArgs e)
        {

        }
    }
}