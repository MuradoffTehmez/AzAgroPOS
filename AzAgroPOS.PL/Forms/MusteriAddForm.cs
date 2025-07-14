using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class MusteriAddForm : Form
    {
        private readonly MusteriService _musteriService;
        private readonly Istifadeci _currentUser;

        public Musteri CreatedCustomer { get; private set; }

        public MusteriAddForm(Istifadeci currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            _musteriService = new MusteriService();
            
            SetupForm();
        }

        private void SetupForm()
        {
            // Initialize form controls
            Text = "Yeni Müştəri Əlavə Et";
            
            // TODO: Add form controls and event handlers
            // This is a placeholder implementation
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

                var musteri = new Musteri
                {
                    Ad = txtAd.Text.Trim(),
                    Soyad = txtSoyad.Text.Trim(),
                    MobilTelefon = txtTelefon.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    MusteriKodu = GenerateCustomerCode()
                };

                var result = _musteriService.CreateCustomer(musteri, _currentUser.Id);
                
                if (result.Success)
                {
                    CreatedCustomer = result.Customer;
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
                ErrorHandlingService.HandleError(ex, "Müştəri yaradılarkən xəta baş verdi.");
            }
        }

        private string GenerateCustomerCode()
        {
            return "MST" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}