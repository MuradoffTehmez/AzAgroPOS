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

        public MusteriEditForm(Musteri musteri, Istifadeci currentUser)
        {
            InitializeComponent();
            _musteri = musteri ?? throw new ArgumentNullException(nameof(musteri));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            _musteriService = new MusteriService();
            
            SetupForm();
            LoadCustomerData();
        }

        private void SetupForm()
        {
            Text = "Müştəri Məlumatlarını Redaktə Et";
        }

        private void LoadCustomerData()
        {
            // TODO: Load customer data into form controls
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: Map form controls to entity properties
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
                ErrorHandlingService.HandleError(ex, "Müştəri yenilənərkən xəta baş verdi.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}