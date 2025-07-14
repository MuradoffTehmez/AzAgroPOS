using AzAgroPOS.DAL;
using AzAgroPOS.Entities.Domain;
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

        private readonly AzAgroDbContext _context;

        public TamirFilterForm()
        {
            InitializeComponent();
            _context = new AzAgroDbContext();
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
                var customers = _context.Tedarukciler.Where(t => t.Status == "Aktiv").ToList();
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
                MessageBox.Show($"Müştəri məlumatları yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadWorkers()
        {
            try
            {
                var workers = _context.Istifadeciler
                    .Where(i => i.Status == "Aktiv" && (i.Rol.Ad == "Worker" || i.Rol.Ad == "Manager" || i.Rol.Ad == "Administrator"))
                    .ToList();
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
                MessageBox.Show($"İşçi məlumatları yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatusOptions()
        {
            cmbStatus.Items.AddRange(new object[] { "Hamısı", "Qəbul Edildi", "İşlənir", "Hazır", "Təhvil Verildi", "İptal" });
            cmbStatus.SelectedIndex = 0;
        }

        private void LoadPriorityOptions()
        {
            cmbPriority.Items.AddRange(new object[] { "Hamısı", "Aşağı", "Orta", "Yüksək", "Təcili" });
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

        private string GetStatusEnglish(string azerbaijaniStatus)
        {
            return azerbaijaniStatus switch
            {
                "Qəbul Edildi" => "Received",
                "İşlənir" => "InProgress",
                "Hazır" => "Ready",
                "Təhvil Verildi" => "Delivered",
                "İptal" => "Cancelled",
                _ => null
            };
        }

        private string GetPriorityEnglish(string azerbaijaniPriority)
        {
            return azerbaijaniPriority switch
            {
                "Aşağı" => "Low",
                "Orta" => "Medium",
                "Yüksək" => "High",
                "Təcili" => "Urgent",
                _ => null
            };
        }

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
                _context?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}