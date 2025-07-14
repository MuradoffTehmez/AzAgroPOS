using AzAgroPOS.DAL;
using AzAgroPOS.Entities.Domain;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class BorcFilterForm : Form
    {
        public string SelectedStatus { get; private set; }
        public int? SelectedCustomerId { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

        private readonly AzAgroDbContext _context;

        public BorcFilterForm()
        {
            InitializeComponent();
            _context = new AzAgroDbContext();
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

        private void LoadStatusOptions()
        {
            cmbStatus.Items.AddRange(new object[] { "Hamısı", "Açıq", "Qismən Ödənilmiş", "Tam Ödənilmiş", "Gecikmiş" });
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
                _context?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}