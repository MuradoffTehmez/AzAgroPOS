using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL;
using AzAgroPOS.Entities.Domain;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AzAgroPOS.BLL.Interfaces;

namespace AzAgroPOS.PL.Forms
{
    public partial class TamirAddForm : Form
    {
        private readonly Istifadeci _currentUser;
        private readonly AzAgroDbContext _context;
        private readonly TamirService _tamirService;

        public TamirAddForm(Istifadeci currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _context = new AzAgroDbContext();
            _tamirService = ServiceFactory.CreateTamirService();
            SetupForm();
            LoadData();
        }

        private void SetupForm()
        {
            this.BackColor = Color.FromArgb(236, 240, 241);
            dtpQebulTarixi.Value = DateTime.Now;
            dtpTaxminiBitirmeTarixi.Value = DateTime.Now.AddDays(7);
            numTaxminQiymet.Value = 50;
        }

        private void LoadData()
        {
            LoadCustomers();
            LoadProducts();
            LoadWorkers();
            SetupComboBoxes();
        }

        private void LoadCustomers()
        {
            try
            {
                var customers = _context.Tedarukciler.Where(t => t.Status == "Aktiv").ToList();
                cmbMusteri.DataSource = customers;
                cmbMusteri.DisplayMember = "Ad";
                cmbMusteri.ValueMember = "Id";
                cmbMusteri.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müştəri məlumatları yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                var products = _context.Mehsullar.Where(m => m.Status == "Aktiv").ToList();
                cmbMehsul.DataSource = products;
                cmbMehsul.DisplayMember = "Ad";
                cmbMehsul.ValueMember = "Id";
                cmbMehsul.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsul məlumatları yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadWorkers()
        {
            try
            {
                var workers = _context.Istifadeciler
                    .Where(i => i.Status == "Aktiv" && (i.Role == "Worker" || i.Role == "Manager" || i.Role == "Administrator"))
                    .ToList();
                cmbTeyinEdilenIsci.DataSource = workers;
                cmbTeyinEdilenIsci.DisplayMember = "Ad";
                cmbTeyinEdilenIsci.ValueMember = "Id";
                cmbTeyinEdilenIsci.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşçi məlumatları yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupComboBoxes()
        {
            // Status options
            cmbStatus.Items.AddRange(new object[] { "Qəbul Edildi", "İşlənir", "Hazır", "Təhvil Verildi", "İptal" });
            cmbStatus.SelectedIndex = 0;

            // Priority options
            cmbPrioritet.Items.AddRange(new object[] { "Aşağı", "Orta", "Yüksək", "Təcili" });
            cmbPrioritet.SelectedIndex = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                var tamirIsi = new TamirIsi
                {
                    MusteriId = (int)cmbMusteri.SelectedValue,
                    MehsulId = cmbMehsul.SelectedValue as int?,
                    MehsulAdi = txtMehsulAdi.Text,
                    MehsulModeli = txtMehsulModeli.Text,
                    SeriyaNomresi = txtSeriyaNomresi.Text,
                    ProblemTasviri = txtProblemTasviri.Text,
                    QebulTarixi = dtpQebulTarixi.Value,
                    TaxminiBitirmeTarixi = dtpTaxminiBitirmeTarixi.Value,
                    TaxminQiymet = numTaxminQiymet.Value,
                    Status = GetStatusEnglish(cmbStatus.SelectedItem.ToString()),
                    Prioritet = GetPriorityEnglish(cmbPrioritet.SelectedItem.ToString()),
                    TeyinEdilenIstifadeciId = cmbTeyinEdilenIsci.SelectedValue as int?,
                    MusteriQeydleri = txtMusteriQeydleri.Text,
                    TamirciQeydleri = txtTamirciQeydleri.Text,
                    QebulEdenIstifadeciId = _currentUser.Id
                };

                _tamirService.CreateRepair(tamirIsi);
                
                MessageBox.Show("Təmir işi uğurla yaradıldı.", "Uğur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Təmir işi yaradılarkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetStatusEnglish(string azerbaijaniStatus) => azerbaijaniStatus switch
        {
            "Qəbul Edildi" => "Received",
            "İşlənir" => "InProgress",
            "Hazır" => "Ready",
            "Təhvil Verildi" => "Delivered",
            "İptal" => "Cancelled",
            _ => "Received"
        };

        private string GetPriorityEnglish(string azerbaijaniPriority) => azerbaijaniPriority switch
        {
            "Aşağı" => "Low",
            "Orta" => "Medium",
            "Yüksək" => "High",
            "Təcili" => "Urgent",
            _ => "Medium"
        };

        private bool ValidateInput()
        {
            if (cmbMusteri.SelectedIndex == -1)
            {
                MessageBox.Show("Zəhmət olmasa müştəri seçin.", "Xəbərdarlıq", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMehsulAdi.Text))
            {
                MessageBox.Show("Zəhmət olmasa məhsul adı daxil edin.", "Xəbərdarlıq", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtProblemTasviri.Text))
            {
                MessageBox.Show("Zəhmət olmasa problem təsviri daxil edin.", "Xəbərdarlıq", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpTaxminiBitirmeTarixi.Value <= dtpQebulTarixi.Value)
            {
                MessageBox.Show("Təxmini bitirmə tarixi qəbul tarixindən sonra olmalıdır.", "Xəbərdarlıq", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numTaxminQiymet.Value <= 0)
            {
                MessageBox.Show("Təxmini qiymət sıfırdan böyük olmalıdır.", "Xəbərdarlıq", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbMehsul_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMehsul.SelectedIndex != -1)
            {
                var selectedProduct = (Mehsul)cmbMehsul.SelectedItem;
                txtMehsulAdi.Text = selectedProduct.Ad;
                txtMehsulModeli.Text = selectedProduct.Model ?? "";
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _context?.Dispose();
        //        components?.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}