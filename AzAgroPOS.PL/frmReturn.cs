using AzAgroPOS.BLL;
using AzAgroPOS.Entities;
using AzAgroPOS.PL.Themes;
using System;
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

            // Düymələrə stil üçün Tag veririk
            btnFindSale.Tag = "Primary";
            btnProcessReturn.Tag = "Danger";
        }

        private void btnFindSale_Click(object sender, EventArgs e)
        {
            ClearForm();
            string chequeNumber = txtChequeNumber.Text.Trim().ToUpper(); // Hərfləri böyük edirik
            if (string.IsNullOrWhiteSpace(chequeNumber)) return;

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
            // Cədvəldə göstərməyə məlumat yoxdursa, metodu dayandırırıq
            if (dgvReturnedItems.Columns.Count == 0) return;

            // Sütunların pəncərənin enini avtomatik olaraq doldurmasını təmin edirik
            dgvReturnedItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Gizlədiləcək texniki sütunların siyahısı
            string[] hiddenColumns = { "Id", "SatisId", "MehsulId" };
            foreach (var colName in hiddenColumns)
            {
                if (dgvReturnedItems.Columns[colName] != null)
                {
                    dgvReturnedItems.Columns[colName].Visible = false;
                }
            }

            // Görünən sütunların başlıqlarını və formatlarını təyin edirik
            if (dgvReturnedItems.Columns["MehsulAdi"] != null)
            {
                dgvReturnedItems.Columns["MehsulAdi"].HeaderText = "Məhsul Adı";
                dgvReturnedItems.Columns["MehsulAdi"].FillWeight = 200; // Ad sütunu daha geniş olsun
            }

            if (dgvReturnedItems.Columns["Miqdar"] != null)
            {
                dgvReturnedItems.Columns["Miqdar"].HeaderText = "Miqdar";
                dgvReturnedItems.Columns["Miqdar"].FillWeight = 70;
            }

            if (dgvReturnedItems.Columns["QiymetBirEdede"] != null)
            {
                dgvReturnedItems.Columns["QiymetBirEdede"].HeaderText = "Vahid Qiyməti (₼)";
                dgvReturnedItems.Columns["QiymetBirEdede"].DefaultCellStyle.Format = "F2"; // İki onluq kəsr
                dgvReturnedItems.Columns["QiymetBirEdede"].FillWeight = 100;
            }

            if (dgvReturnedItems.Columns["EndirimMeblegi"] != null)
            {
                dgvReturnedItems.Columns["EndirimMeblegi"].HeaderText = "Endirim (₼)";
                dgvReturnedItems.Columns["EndirimMeblegi"].DefaultCellStyle.Format = "F2";
                dgvReturnedItems.Columns["EndirimMeblegi"].FillWeight = 80;
            }

            if (dgvReturnedItems.Columns["YekunMebleg"] != null)
            {
                dgvReturnedItems.Columns["YekunMebleg"].HeaderText = "Yekun Məbləğ (₼)";
                dgvReturnedItems.Columns["YekunMebleg"].DefaultCellStyle.Format = "F2";
                dgvReturnedItems.Columns["YekunMebleg"].FillWeight = 110;
            }
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

            var result = MessageBox.Show($"ID: {_foundSale.Id} olan satışı ləğv etmək istədiyinizə əminsinizmi?\nBu əməliyyat anbar qalığını geri qaytaracaq.",
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
    }
}