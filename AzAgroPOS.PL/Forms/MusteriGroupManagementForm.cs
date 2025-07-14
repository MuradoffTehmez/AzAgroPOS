using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class MusteriGroupManagementForm : Form
    {
        private readonly MusteriService _musteriService;
        private readonly Istifadeci _currentUser;

        public MusteriGroupManagementForm(Istifadeci currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            _musteriService = new MusteriService();
            
            SetupForm();
            LoadGroups();
        }

        private void SetupForm()
        {
            Text = "Müştəri Qruplarının İdarə Edilməsi";
        }

        private void LoadGroups()
        {
            try
            {
                // TODO: Load customer groups into grid or list
                var groups = _musteriService.GetAllCustomerGroups();
                // Populate UI with groups
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleError(ex, "Müştəri qrupları yüklənərkən xəta baş verdi.");
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: Show add group dialog
                var newGroup = new MusteriQrupu
                {
                    Ad = "Yeni Qrup",
                    Aciklama = "Yeni qrup açıqlaması"
                };

                var result = _musteriService.CreateCustomerGroup(newGroup, _currentUser.Id);
                
                if (result.Success)
                {
                    LoadGroups();
                    ErrorHandlingService.ShowSuccess("Qrup uğurla əlavə edildi.");
                }
                else
                {
                    ErrorHandlingService.ShowValidationError(result.Message);
                }
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleError(ex, "Qrup əlavə edilərkən xəta baş verdi.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}