using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class MusteriDetailsForm : Form
    {
        private readonly MusteriService _musteriService;
        private readonly Musteri _musteri;

        public MusteriDetailsForm(Musteri musteri)
        {
            InitializeComponent();
            _musteri = musteri ?? throw new ArgumentNullException(nameof(musteri));
            _musteriService = new MusteriService();
            
            SetupForm();
            LoadCustomerDetails();
        }

        private void SetupForm()
        {
            Text = "Müştəri Detalları";
        }

        private void LoadCustomerDetails()
        {
            try
            {
                // TODO: Load customer details into form controls
                // Display customer information in read-only mode
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleError(ex, "Müştəri detalları yüklənərkən xəta baş verdi.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}