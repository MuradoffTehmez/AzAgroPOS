using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL;
using AzAgroPOS.Entities.Domain;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class BorcAddForm : Form
    {
        private readonly Istifadeci _currentUser;
        private readonly AzAgroDbContext _context;
        private readonly BorcService _borcService;

        public BorcAddForm(Istifadeci currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _context = new AzAgroDbContext();
            _borcService = new BorcService(_context, new AuditLogService());
            SetupForm();
        }

        private void SetupForm()
        {
            this.BackColor = Color.FromArgb(236, 240, 241);
            LoadCustomers();
            LoadSalesDocuments();
            dtpBorcTarixi.Value = DateTime.Now;
            dtpSonOdemeTarixi.Value = DateTime.Now.AddDays(30);
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

        private void LoadSalesDocuments()
        {
            try
            {
                var sales = _context.Satislar.Where(s => s.Status == "Tamamlanmış").ToList();
                cmbSatis.DataSource = sales;
                cmbSatis.DisplayMember = "SatisNomresi";
                cmbSatis.ValueMember = "Id";
                cmbSatis.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satış sənədləri yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                var musteriBorc = new MusteriBorc
                {
                    MusteriId = (int)cmbMusteri.SelectedValue,
                    BorcTipi = cmbBorcTipi.SelectedItem.ToString(),
                    SatisId = cmbSatis.SelectedValue as int?,
                    BorcMeblegi = numBorcMeblegi.Value,
                    BorcTarixi = dtpBorcTarixi.Value,
                    SonOdemeTarixi = dtpSonOdemeTarixi.Value,
                    FaizDerecesi = numFaizDerecesi.Value,
                    Aciklama = txtAciklama.Text,
                    YaradanIstifadeciId = _currentUser.Id
                };

                _borcService.CreateDebt(musteriBorc);
                
                MessageBox.Show("Borc uğurla yaradıldı.", "Uğur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Borc yaradılarkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (cmbMusteri.SelectedIndex == -1)
            {
                MessageBox.Show("Zəhmət olmasa müştəri seçin.", "Xəbərdarlıq", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(cmbBorcTipi.Text))
            {
                MessageBox.Show("Zəhmət olmasa borc tipi seçin.", "Xəbərdarlıq", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numBorcMeblegi.Value <= 0)
            {
                MessageBox.Show("Borc məbləği sıfırdan böyük olmalıdır.", "Xəbərdarlıq", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpSonOdemeTarixi.Value <= dtpBorcTarixi.Value)
            {
                MessageBox.Show("Son ödəmə tarixi borc tarixindən sonra olmalıdır.", "Xəbərdarlıq", 
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