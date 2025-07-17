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
    public partial class BorcEditForm : BaseForm
    {
        private readonly int _debtId;
        private readonly AzAgroDbContext _context;
        private readonly BorcService _borcService;
        private MusteriBorc _debt;

        public BorcEditForm(int debtId, Istifadeci currentUser) : base()
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
                ShowError($"Müştəri məlumatları yüklənərkən xəta: {ex.Message}");
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
                ShowError($"Satış sənədləri yüklənərkən xəta: {ex.Message}");
            }
        }

        private void LoadDebtData()
        {
            try
            {
                _debt = _borcService.GetDebtById(_debtId);
                if (_debt == null)
                {
                    ShowError("Borc məlumatı tapılmadı.");
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
                ShowError($"Borc məlumatları yüklənərkən xəta: {ex.Message}");
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
                
                ShowSuccess("Borc uğurla yeniləndi.");
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ShowError($"Borc yenilənərkən xəta: {ex.Message}");
            }
        }

        private bool ValidateInput()
        {
            if (cmbMusteri.SelectedIndex == -1)
            {
                ShowWarning("Zəhmət olmasa müştəri seçin.");
                return false;
            }

            if (string.IsNullOrEmpty(cmbBorcTipi.Text))
            {
                ShowWarning("Zəhmət olmasa borc tipi seçin.");
                return false;
            }

            if (numBorcMeblegi.Value <= 0)
            {
                ShowWarning("Borc məbləği sıfırdan böyük olmalıdır.");
                return false;
            }

            if (dtpSonOdemeTarixi.Value <= dtpBorcTarixi.Value)
            {
                ShowWarning("Son ödəmə tarixi borc tarixindən sonra olmalıdır.");
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