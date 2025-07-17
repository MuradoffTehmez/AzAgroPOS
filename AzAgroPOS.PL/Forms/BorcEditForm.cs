using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL;
using AzAgroPOS.Entities.Domain;
using System;
using System.Drawing;
using System.Linq;
using AzAgroPOS.BLL.Interfaces;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class BorcEditForm : Form
    {
        private readonly int _debtId;
        private readonly Istifadeci _currentUser;
        private readonly AzAgroDbContext _context;
        private readonly BorcService _borcService;
        private MusteriBorc _debt;

        public BorcEditForm(int debtId, Istifadeci currentUser)
        {
            InitializeComponent();
            _debtId = debtId;
            _currentUser = currentUser;
            _context = new AzAgroDbContext();
            _borcService = ServiceFactory.CreateBorcService();
            SetupForm();
            LoadDebtData();
        }

        private void SetupForm()
        {
            this.BackColor = Color.FromArgb(236, 240, 241);
            LoadCustomers();
            LoadSalesDocuments();
        }

        private void LoadCustomers()
        {
            try
            {
                var customers = _context.Tedarukciler.Where(t => t.Status == "Aktiv").ToList();
                cmbMusteri.DataSource = customers;
                cmbMusteri.DisplayMember = "Ad";
                cmbMusteri.ValueMember = "Id";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satış sənədləri yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDebtData()
        {
            try
            {
                _debt = _borcService.GetDebtById(_debtId);
                if (_debt == null)
                {
                    MessageBox.Show("Borc məlumatı tapılmadı.", "Xəta", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Populate form fields
                cmbMusteri.SelectedValue = _debt.MusteriId;
                cmbBorcTipi.Text = _debt.BorcTipi;
                if (_debt.SatisId.HasValue)
                    cmbSatis.SelectedValue = _debt.SatisId.Value;
                numBorcMeblegi.Value = _debt.BorcMeblegi;
                dtpBorcTarixi.Value = _debt.BorcTarixi;
                dtpSonOdemeTarixi.Value = _debt.SonOdemeTarixi;
                numFaizDerecesi.Value = _debt.FaizDerecesi;
                txtAciklama.Text = _debt.Aciklama ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Borc məlumatları yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                _debt.MusteriId = (int)cmbMusteri.SelectedValue;
                _debt.BorcTipi = cmbBorcTipi.SelectedItem.ToString();
                _debt.SatisId = cmbSatis.SelectedValue as int?;
                _debt.BorcMeblegi = numBorcMeblegi.Value;
                _debt.BorcTarixi = dtpBorcTarixi.Value;
                _debt.SonOdemeTarixi = dtpSonOdemeTarixi.Value;
                _debt.FaizDerecesi = numFaizDerecesi.Value;
                _debt.Aciklama = txtAciklama.Text;

                _borcService.UpdateDebt(_debt);
                
                MessageBox.Show("Borc uğurla yeniləndi.", "Uğur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Borc yenilənərkən xəta: {ex.Message}", "Xəta", 
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