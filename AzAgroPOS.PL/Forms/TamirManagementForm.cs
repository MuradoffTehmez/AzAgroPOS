using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.BLL.Interfaces;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class TamirManagementForm : BaseForm
    {
        private readonly TamirService _tamirService;
        private readonly AzAgroDbContext _context;

        public TamirManagementForm(Istifadeci currentUser) : base()
        {
            InitializeComponent();
            _currentUser = currentUser;
            _context = new AzAgroDbContext();
            _tamirService = ServiceFactory.CreateTamirService();
            SetupModernDesign();
        }

        private void TamirManagementForm_Load(object sender, EventArgs e)
        {
            LoadRepairs();
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
            dgvRepairs.EnableHeadersVisualStyles = false;
            dgvRepairs.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvRepairs.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRepairs.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvRepairs.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 73, 94);
            
            dgvRepairs.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvRepairs.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvRepairs.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 250);
            
            dgvRepairs.BorderStyle = BorderStyle.None;
            dgvRepairs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRepairs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRepairs.MultiSelect = false;
            dgvRepairs.AllowUserToAddRows = false;
            dgvRepairs.AllowUserToDeleteRows = false;
            dgvRepairs.ReadOnly = true;
        }

        private void LoadRepairs()
        {
            try
            {
                var repairs = _tamirService.GetAllRepairs().Select(r => new
                {
                    r.Id,
                    TamirNomresi = r.TamirNomresiFormatli,
                    MusteriAdi = r.Musteri?.Ad ?? "Naməlum",
                    MehsulAdi = r.MehsulTamBilgisi,
                    ProblemTasviri = r.ProblemTasviri.Length > 50 ? 
                        r.ProblemTasviri.Substring(0, 50) + "..." : r.ProblemTasviri,
                    Status = r.StatusAzerbaycan,
                    Prioritet = r.PrioritetAzerbaycan,
                    TeyinEdilenIsci = r.TeyinEdilenIstifadeci?.Ad ?? "Təyin edilməyib",
                    TamirciQeydleri = !string.IsNullOrEmpty(r.TamirciQeydleri) ? "Var" : "Yoxdur",
                    QebulTarixi = r.QebulTarixi.ToString("dd.MM.yyyy"),
                    TaxminiBitirmeTarixi = r.TaxminiBitirmeTarixi?.ToString("dd.MM.yyyy") ?? "Təyin edilməyib",
                    TaxminQiymet = r.TaxminQiymet.ToString("C"),
                    SonQiymet = r.SonQiymet.ToString("C"),
                    TamamlanmaYuzdesi = r.TamamlanmaYuzdesi.ToString("F1") + "%"
                }).ToList();

                dgvRepairs.DataSource = repairs;
                
                dgvRepairs.Columns["Id"].Visible = false;
                dgvRepairs.Columns["TamirNomresi"].HeaderText = "Təmir №";
                dgvRepairs.Columns["MusteriAdi"].HeaderText = "Müştəri";
                dgvRepairs.Columns["MehsulAdi"].HeaderText = "Məhsul";
                dgvRepairs.Columns["ProblemTasviri"].HeaderText = "Problem";
                dgvRepairs.Columns["Status"].HeaderText = "Status";
                dgvRepairs.Columns["Prioritet"].HeaderText = "Prioritet";
                dgvRepairs.Columns["TeyinEdilenIsci"].HeaderText = "Təyin edilən işçi";
                dgvRepairs.Columns["TamirciQeydleri"].HeaderText = "Qeydlər";
                dgvRepairs.Columns["QebulTarixi"].HeaderText = "Qəbul Tarixi";
                dgvRepairs.Columns["TaxminiBitirmeTarixi"].HeaderText = "Təxmini Bitirmə";
                dgvRepairs.Columns["TaxminQiymet"].HeaderText = "Təxmin Qiymət";
                dgvRepairs.Columns["SonQiymet"].HeaderText = "Son Qiymət";
                dgvRepairs.Columns["TamamlanmaYuzdesi"].HeaderText = "Tamamlanma";

                // Add status-based row coloring
                foreach (DataGridViewRow row in dgvRepairs.Rows)
                {
                    var status = row.Cells["Status"].Value.ToString();
                    switch (status)
                    {
                        case "Qəbul Edildi":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(241, 196, 15);
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;
                        case "İşlənir":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;
                        case "Hazır":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(46, 204, 113);
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;
                        case "Təhvil Verildi":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(149, 165, 166);
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;
                        case "İptal":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(231, 76, 60);
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Təmir məlumatları yüklənərkən xəta: {ex.Message}", "Xəta", 
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
                var summary = _tamirService.GetRepairStatusSummary();
                
                var activeCount = (summary.ContainsKey("İşlənir") ? summary["İşlənir"] : 0) +
                                 (summary.ContainsKey("Təşxis") ? summary["Təşxis"] : 0) +
                                 (summary.ContainsKey("Gözləyir") ? summary["Gözləyir"] : 0) +
                                 (summary.ContainsKey("Qəbul Edildi") ? summary["Qəbul Edildi"] : 0);
                lblActiveRepairs.Text = activeCount.ToString();
                
                lblReadyForDelivery.Text = summary.ContainsKey("Hazır") ? summary["Hazır"].ToString() : "0";
                lblCompletedRepairs.Text = summary.ContainsKey("Təhvil Verildi") ? summary["Təhvil Verildi"].ToString() : "0";
                
                var overdue = _tamirService.GetOverdueRepairs().Count();
                lblOverdueRepairs.Text = overdue.ToString();

                var totalRevenue = _tamirService.GetTotalRevenue(DateTime.Now.AddMonths(-1), DateTime.Now);
                lblMonthlyRevenue.Text = totalRevenue.ToString("C");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Statistik məlumatlar yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewRepair_Click(object sender, EventArgs e)
        {
            var newRepairForm = new TamirAddForm(_currentUser);
            if (newRepairForm.ShowDialog() == DialogResult.OK)
            {
                LoadRepairs();
                LoadStatistics();
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvRepairs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zəhmət olmasa təfərrüatlar üçün təmir işi seçin.", "Məlumat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRepairId = (int)dgvRepairs.SelectedRows[0].Cells["Id"].Value;
            var detailsForm = new TamirDetailsForm(selectedRepairId, _currentUser);
            detailsForm.ShowDialog();
            LoadRepairs();
            LoadStatistics();
        }

        private void btnAssignWorker_Click(object sender, EventArgs e)
        {
            if (dgvRepairs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zəhmət olmasa işçi təyinatı üçün təmir işi seçin.", "Məlumat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRepairId = (int)dgvRepairs.SelectedRows[0].Cells["Id"].Value;
            var assignForm = new TamirWorkerAssignForm(selectedRepairId, _currentUser);
            if (assignForm.ShowDialog() == DialogResult.OK)
            {
                LoadRepairs();
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvRepairs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zəhmət olmasa status yeniləməsi üçün təmir işi seçin.", "Məlumat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRepairId = (int)dgvRepairs.SelectedRows[0].Cells["Id"].Value;
            var statusForm = new TamirStatusForm(selectedRepairId, _currentUser);
            if (statusForm.ShowDialog() == DialogResult.OK)
            {
                LoadRepairs();
                LoadStatistics();
            }
        }

        private void btnDeliverRepair_Click(object sender, EventArgs e)
        {
            if (dgvRepairs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zəhmət olmasa təhvil üçün təmir işi seçin.", "Məlumat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRepairId = (int)dgvRepairs.SelectedRows[0].Cells["Id"].Value;
            try
            {
                _tamirService.DeliverRepair(selectedRepairId, _currentUser.Id);
                MessageBox.Show("Təmir işi müştəriyə təhvil verildi.", "Uğur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRepairs();
                LoadStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Təhvil verərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRepairs();
            LoadStatistics();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var filterForm = new TamirFilterForm();
            if (filterForm.ShowDialog() == DialogResult.OK)
            {
                ApplyFilters(filterForm.SelectedStatus, filterForm.SelectedCustomerId, 
                    filterForm.SelectedPriority, filterForm.StartDate, filterForm.EndDate);
            }
        }

        private void ApplyFilters(string status, int? customerId, string priority, 
            DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var repairs = _tamirService.GetAllRepairs().ToList();

                if (!string.IsNullOrEmpty(status))
                    repairs = repairs.Where(r => r.Status == status).ToList();

                if (customerId.HasValue)
                    repairs = repairs.Where(r => r.MusteriId == customerId.Value).ToList();

                if (!string.IsNullOrEmpty(priority))
                    repairs = repairs.Where(r => r.Prioritet == priority).ToList();

                if (startDate.HasValue)
                    repairs = repairs.Where(r => r.QebulTarixi >= startDate.Value).ToList();

                if (endDate.HasValue)
                    repairs = repairs.Where(r => r.QebulTarixi <= endDate.Value).ToList();

                var filteredRepairs = repairs.Select(r => new
                {
                    r.Id,
                    TamirNomresi = r.TamirNomresiFormatli,
                    MusteriAdi = r.Musteri?.Ad ?? "Naməlum",
                    MehsulAdi = r.MehsulTamBilgisi,
                    ProblemTasviri = r.ProblemTasviri.Length > 50 ? 
                        r.ProblemTasviri.Substring(0, 50) + "..." : r.ProblemTasviri,
                    Status = r.StatusAzerbaycan,
                    Prioritet = r.PrioritetAzerbaycan,
                    TeyinEdilenIsci = r.TeyinEdilenIstifadeci?.Ad ?? "Təyin edilməyib",
                    QebulTarixi = r.QebulTarixi.ToString("dd.MM.yyyy"),
                    TaxminiBitirmeTarixi = r.TaxminiBitirmeTarixi?.ToString("dd.MM.yyyy") ?? "Təyin edilməyib",
                    TaxminQiymet = r.TaxminQiymet.ToString("C"),
                    SonQiymet = r.SonQiymet.ToString("C")
                }).ToList();

                dgvRepairs.DataSource = filteredRepairs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Filtr tətbiq edilərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRepairs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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