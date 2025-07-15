using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class TamirFilterForm : Form
    {
        public string SelectedStatus { get; private set; }
        public int? SelectedCustomerId { get; private set; }
        public string SelectedPriority { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public int? SelectedWorkerId { get; private set; }

        private readonly TedarukcuService _tedarukcuService;
        private readonly AuthService _authService;

        public TamirFilterForm()
        {
            InitializeComponent();
            _tedarukcuService = new TedarukcuService();
            _authService = new AuthService();
            SetupForm();
        }

        private void SetupForm()
        {
            this.BackColor = Color.FromArgb(236, 240, 241);
            LoadCustomers();
            LoadWorkers();
            LoadStatusOptions();
            LoadPriorityOptions();
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

        private void LoadWorkers()
        {
            try
            {
                var workers = _authService.GetActiveWorkers();
                cmbWorker.Items.Add("Hamısı");
                foreach (var worker in workers)
                {
                    cmbWorker.Items.Add(worker);
                }
                cmbWorker.DisplayMember = "TamAd";
                cmbWorker.ValueMember = "Id";
                cmbWorker.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "İşçi məlumatları yüklənərkən xəta baş verdi.");
            }
        }

        private void LoadStatusOptions()
        {
            cmbStatus.Items.AddRange(new object[] { 
                "Hamısı", 
                SystemConstants.RepairStatusAzerbaijani.Received, 
                SystemConstants.RepairStatusAzerbaijani.InProgress, 
                SystemConstants.RepairStatusAzerbaijani.Ready, 
                SystemConstants.RepairStatusAzerbaijani.Delivered, 
                SystemConstants.RepairStatusAzerbaijani.Cancelled 
            });
            cmbStatus.SelectedIndex = 0;
        }

        private void LoadPriorityOptions()
        {
            cmbPriority.Items.AddRange(new object[] { 
                "Hamısı", 
                SystemConstants.PriorityAzerbaijani.Low, 
                SystemConstants.PriorityAzerbaijani.Medium, 
                SystemConstants.PriorityAzerbaijani.High, 
                SystemConstants.PriorityAzerbaijani.Urgent 
            });
            cmbPriority.SelectedIndex = 0;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SelectedStatus = cmbStatus.SelectedItem.ToString() == "Hamısı" ? null : GetStatusEnglish(cmbStatus.SelectedItem.ToString());
            SelectedPriority = cmbPriority.SelectedItem.ToString() == "Hamısı" ? null : GetPriorityEnglish(cmbPriority.SelectedItem.ToString());
            SelectedCustomerId = cmbCustomer.SelectedIndex == 0 ? (int?)null : ((Tedarukcu)cmbCustomer.SelectedItem).Id;
            SelectedWorkerId = cmbWorker.SelectedIndex == 0 ? (int?)null : ((Istifadeci)cmbWorker.SelectedItem).Id;
            StartDate = chkStartDate.Checked ? dtpStartDate.Value : (DateTime?)null;
            EndDate = chkEndDate.Checked ? dtpEndDate.Value : (DateTime?)null;
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private string GetStatusEnglish(string azerbaijaniStatus) => azerbaijaniStatus switch
        {
            SystemConstants.RepairStatusAzerbaijani.Received => SystemConstants.RepairStatus.Received,
            SystemConstants.RepairStatusAzerbaijani.InProgress => SystemConstants.RepairStatus.InProgress,
            SystemConstants.RepairStatusAzerbaijani.Ready => SystemConstants.RepairStatus.Ready,
            SystemConstants.RepairStatusAzerbaijani.Delivered => SystemConstants.RepairStatus.Delivered,
            SystemConstants.RepairStatusAzerbaijani.Cancelled => SystemConstants.RepairStatus.Cancelled,
            _ => null
        };

        private string GetPriorityEnglish(string azerbaijaniPriority) => azerbaijaniPriority switch
        {
            SystemConstants.PriorityAzerbaijani.Low => SystemConstants.Priority.Low,
            SystemConstants.PriorityAzerbaijani.Medium => SystemConstants.Priority.Medium,
            SystemConstants.PriorityAzerbaijani.High => SystemConstants.Priority.High,
            SystemConstants.PriorityAzerbaijani.Urgent => SystemConstants.Priority.Urgent,
            _ => null
        };

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0;
            cmbPriority.SelectedIndex = 0;
            cmbCustomer.SelectedIndex = 0;
            cmbWorker.SelectedIndex = 0;
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
                _authService?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}