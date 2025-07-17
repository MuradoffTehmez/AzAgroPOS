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
    public partial class BorcAddForm : BaseForm
    {
        private readonly AzAgroDbContext _context;
        private readonly BorcService _borcService;

        public BorcAddForm(Istifadeci currentUser) : base()
        {
            InitializeComponent();
            _currentUser = currentUser;
            _context = new AzAgroDbContext();
            _borcService = ServiceFactory.CreateBorcService();
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
                cmbSatis.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ShowError($"Satış sənədləri yüklənərkən xəta: {ex.Message}");
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
                
                ShowSuccess("Borc uğurla yaradıldı.");
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ShowError($"Borc yaradılarkən xəta: {ex.Message}");
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