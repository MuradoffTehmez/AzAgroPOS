using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class MusteriEditForm : Form
    {
        private readonly MusteriService _musteriService;
        private readonly Istifadeci _currentUser;
        private readonly Musteri _musteri;

        public MusteriEditForm(int musteriId, Istifadeci currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            _musteriService = new MusteriService();
            
            _musteri = _musteriService.GetCustomerById(musteriId);
            if (_musteri == null)
                throw new ArgumentException("Müştəri tapılmadı", nameof(musteriId));
            
            SetupForm();
            LoadCustomerData();
        }

        private void SetupForm()
        {
            Text = "Müştəri Məlumatlarını Redaktə Et";
        }

        private void LoadCustomerData()
        {
            txtMusteriKodu.Text = _musteri.MusteriKodu;
            txtAd.Text = _musteri.Ad;
            txtSoyad.Text = _musteri.Soyad;
            txtTelefon.Text = _musteri.MobilTelefon;
            txtEmail.Text = _musteri.Email;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(txtAd.Text))
                {
                    ErrorHandlingService.ShowValidationError("Ad mütləqdir.");
                    txtAd.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSoyad.Text))
                {
                    ErrorHandlingService.ShowValidationError("Soyad mütləqdir.");
                    txtSoyad.Focus();
                    return;
                }

                // Update customer data
                _musteri.Ad = txtAd.Text.Trim();
                _musteri.Soyad = txtSoyad.Text.Trim();
                _musteri.MobilTelefon = txtTelefon.Text.Trim();
                _musteri.Email = txtEmail.Text.Trim();
                
                var result = _musteriService.UpdateCustomer(_musteri, _currentUser.Id);
                
                if (result.Success)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    ErrorHandlingService.ShowValidationError(result.Message);
                }
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Müştəri yenilənərkən xəta baş verdi.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}