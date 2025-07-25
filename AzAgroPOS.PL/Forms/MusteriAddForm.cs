using AzAgroPOS.BLL.Services;
using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.Entities.Domain;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    //[RequirePermission(SystemConstants.Permissions.Musteri.Create)]
    public partial class MusteriAddForm : BaseForm
    {
        private readonly MusteriService _musteriService;

        public Musteri CreatedCustomer { get; private set; }

        public MusteriAddForm(Istifadeci currentUser) : base()
        {
            InitializeComponent();
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            _musteriService = ServiceFactory.CreateMusteriService();
            
            SetupForm();
        }

        private void SetupForm()
        {
            // Initialize form controls
            Text = "Yeni Müştəri Əlavə Et";
            Size = new System.Drawing.Size(500, 400);
            // Additional configuration for controls can be done here if needed
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
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
                    MusteriKodu = string.IsNullOrWhiteSpace(txtKod.Text) ? null : txtKod.Text.Trim()
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
                ErrorHandlingService.HandleErrorStatic(ex, "Müştəri yaradılarkən xəta baş verdi.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}