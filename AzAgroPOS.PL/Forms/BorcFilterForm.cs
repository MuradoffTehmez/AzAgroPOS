using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using AzAgroPOS.BLL.Interfaces;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class BorcFilterForm : BaseForm
    {
        public string SelectedStatus { get; private set; }
        public int? SelectedCustomerId { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

        private readonly TedarukcuService _tedarukcuService;

        public BorcFilterForm() : base()
        {
            InitializeComponent();
            _tedarukcuService = ServiceFactory.CreateTedarukcuService();
            SetupForm();
        }

        private void SetupForm()
        {
            this.BackColor = Color.FromArgb(236, 240, 241);
            LoadCustomers();
            LoadStatusOptions();
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;
        }

        private void LoadCustomers()
        {
            try
            {
                var customers = _tedarukcuService.GetActiveCustomers();
                cmbCustomer.Items.Add("Hamısı");
                foreach (var customer in customers)
                {
                    cmbCustomer.Items.Add(customer);
                }
                cmbCustomer.DisplayMember = "Ad";
                cmbCustomer.ValueMember = "Id";
                cmbCustomer.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Müştəri məlumatları yüklənərkən xəta baş verdi.");
            }
        }

        private void LoadStatusOptions()
        {
            cmbStatus.Items.AddRange(new object[] { 
                "Hamısı", 
                SystemConstants.DebtStatus.Open, 
                SystemConstants.DebtStatus.PartiallyPaid, 
                SystemConstants.DebtStatus.FullyPaid, 
                SystemConstants.DebtStatus.Overdue 
            });
            cmbStatus.SelectedIndex = 0;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SelectedStatus = cmbStatus.SelectedItem.ToString() == "Hamısı" ? null : cmbStatus.SelectedItem.ToString();
            SelectedCustomerId = cmbCustomer.SelectedIndex == 0 ? (int?)null : ((Tedarukcu)cmbCustomer.SelectedItem).Id;
            StartDate = chkStartDate.Checked ? dtpStartDate.Value : (DateTime?)null;
            EndDate = chkEndDate.Checked ? dtpEndDate.Value : (DateTime?)null;
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0;
            cmbCustomer.SelectedIndex = 0;
            chkStartDate.Checked = false;
            chkEndDate.Checked = false;
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tedarukcuService?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}