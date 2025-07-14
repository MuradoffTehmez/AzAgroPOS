using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL;
using AzAgroPOS.Entities.Domain;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class BorcManagementForm : Form
    {
        private readonly BorcService _borcService;
        private readonly Istifadeci _currentUser;
        private readonly AzAgroDbContext _context;

        public BorcManagementForm(Istifadeci currentUser)
        {
            InitializeComponent();
            _context = new AzAgroDbContext();
            _borcService = new BorcService(_context, new AuditLogService());
            _currentUser = currentUser;
            SetupModernDesign();
        }

        private void BorcManagementForm_Load(object sender, EventArgs e)
        {
            LoadDebts();
            LoadCustomers();
            LoadStatistics();
            SetupDataGridView();
        }

        private void SetupModernDesign()
        {
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.Font = new Font("Segoe UI", 9F);
            
            foreach (Control control in this.Controls)
            {
                if (control is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    btn.Cursor = Cursors.Hand;
                }
                else if (control is Panel panel)
                {
                    panel.BackColor = Color.White;
                }
            }
        }

        private void SetupDataGridView()
        {
            dgvDebts.EnableHeadersVisualStyles = false;
            dgvDebts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvDebts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDebts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvDebts.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 73, 94);
            
            dgvDebts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvDebts.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDebts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 250);
            
            dgvDebts.BorderStyle = BorderStyle.None;
            dgvDebts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDebts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDebts.MultiSelect = false;
            dgvDebts.AllowUserToAddRows = false;
            dgvDebts.AllowUserToDeleteRows = false;
            dgvDebts.ReadOnly = true;
        }

        private void LoadDebts()
        {
            try
            {
                var debts = _borcService.GetAllDebts().Select(d => new
                {
                    d.Id,
                    BorcNomresi = d.BorcNomresiFormatli,
                    MusteriAdi = d.Musteri != null ? d.Musteri.Ad : "Naməlum",
                    BorcMeblegi = d.BorcMeblegi.ToString("C"),
                    QalanBorc = d.QalanBorc.ToString("C"),
                    OdemeYuzdesi = d.OdemeYuzdesi.ToString("F1") + "%",
                    Status = d.StatusAzerbaycan,
                    GecikmeDurumu = d.GecikmeDurumu,
                    BorcTarixi = d.BorcTarixi.ToString("dd.MM.yyyy"),
                    SonOdemeTarixi = d.SonOdemeTarixi.ToString("dd.MM.yyyy")
                }).ToList();

                dgvDebts.DataSource = debts;
                
                dgvDebts.Columns["Id"].Visible = false;
                dgvDebts.Columns["BorcNomresi"].HeaderText = "Borc №";
                dgvDebts.Columns["MusteriAdi"].HeaderText = "Müştəri";
                dgvDebts.Columns["BorcMeblegi"].HeaderText = "Borc Məbləği";
                dgvDebts.Columns["QalanBorc"].HeaderText = "Qalan Borc";
                dgvDebts.Columns["OdemeYuzdesi"].HeaderText = "Ödəniş %";
                dgvDebts.Columns["Status"].HeaderText = "Status";
                dgvDebts.Columns["GecikmeDurumu"].HeaderText = "Gecikməsi";
                dgvDebts.Columns["BorcTarixi"].HeaderText = "Borc Tarixi";
                dgvDebts.Columns["SonOdemeTarixi"].HeaderText = "Son Ödəmə";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Borc məlumatları yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomers()
        {
            try
            {
                var customers = _context.Tedarukciler.Where(t => t.Status == "Aktiv").ToList();
                cmbCustomer.DataSource = customers;
                cmbCustomer.DisplayMember = "Ad";
                cmbCustomer.ValueMember = "Id";
                cmbCustomer.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müştəri məlumatları yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatistics()
        {
            try
            {
                var summary = _borcService.GetDebtSummary();
                
                lblTotalDebt.Text = summary.ContainsKey("UmumiBorc") ? 
                    summary["UmumiBorc"].ToString("C") : "0 ₼";
                lblOverdueDebt.Text = summary.ContainsKey("GecikmisBorc") ? 
                    summary["GecikmisBorc"].ToString("C") : "0 ₼";
                lblTotalInterest.Text = summary.ContainsKey("UmumiFaiz") ? 
                    summary["UmumiFaiz"].ToString("C") : "0 ₼";
                lblCustomerCount.Text = summary.ContainsKey("MusteriSayi") ? 
                    summary["MusteriSayi"].ToString() : "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Statistik məlumatlar yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddDebt_Click(object sender, EventArgs e)
        {
            var addForm = new BorcAddForm(_currentUser);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadDebts();
                LoadStatistics();
            }
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            if (dgvDebts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zəhmət olmasa ödəniş üçün borc seçin.", "Məlumat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedDebtId = (int)dgvDebts.SelectedRows[0].Cells["Id"].Value;
            var paymentForm = new BorcPaymentForm(selectedDebtId, _currentUser);
            if (paymentForm.ShowDialog() == DialogResult.OK)
            {
                LoadDebts();
                LoadStatistics();
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvDebts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zəhmət olmasa təfərrüatlar üçün borc seçin.", "Məlumat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedDebtId = (int)dgvDebts.SelectedRows[0].Cells["Id"].Value;
            var detailsForm = new BorcDetailsForm(selectedDebtId, _currentUser);
            detailsForm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDebts();
            LoadStatistics();
        }

        private void btnFilterByStatus_Click(object sender, EventArgs e)
        {
            var filterForm = new BorcFilterForm();
            if (filterForm.ShowDialog() == DialogResult.OK)
            {
                ApplyFilters(filterForm.SelectedStatus, filterForm.SelectedCustomerId, 
                    filterForm.StartDate, filterForm.EndDate);
            }
        }

        private void ApplyFilters(string status, int? customerId, DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var debts = _borcService.GetAllDebts().AsQueryable();

                if (!string.IsNullOrEmpty(status))
                    debts = debts.Where(d => d.Status == status);

                if (customerId.HasValue)
                    debts = debts.Where(d => d.MusteriId == customerId.Value);

                if (startDate.HasValue)
                    debts = debts.Where(d => d.BorcTarixi >= startDate.Value);

                if (endDate.HasValue)
                    debts = debts.Where(d => d.BorcTarixi <= endDate.Value);

                var filteredDebts = debts.Select(d => new
                {
                    d.Id,
                    BorcNomresi = d.BorcNomresiFormatli,
                    MusteriAdi = d.Musteri != null ? d.Musteri.Ad : "Naməlum",
                    BorcMeblegi = d.BorcMeblegi.ToString("C"),
                    QalanBorc = d.QalanBorc.ToString("C"),
                    OdemeYuzdesi = d.OdemeYuzdesi.ToString("F1") + "%",
                    Status = d.StatusAzerbaycan,
                    GecikmeDurumu = d.GecikmeDurumu,
                    BorcTarixi = d.BorcTarixi.ToString("dd.MM.yyyy"),
                    SonOdemeTarixi = d.SonOdemeTarixi.ToString("dd.MM.yyyy")
                }).ToList();

                dgvDebts.DataSource = filteredDebts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Filtr tətbiq edilərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDebts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnViewDetails_Click(sender, e);
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _context?.Dispose();
        //        components?.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}