using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using AzAgroPOS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    [RequirePermission(SystemConstants.Permissions.Musteri.View)]
    public partial class MusteriManagementForm : BaseForm
    {
        private readonly MusteriService _musteriService;
        private bool _isLoading = false;

        public MusteriManagementForm(Istifadeci currentUser) : base()
        {
            InitializeComponent();
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            _musteriService = ServiceFactory.CreateMusteriService();
            SetupForm();
            LoadCustomers();
            LoadCustomerGroups();
        }

        private void SetupForm()
        {
            this.BackColor = Color.FromArgb(236, 240, 241);
            SetupDataGridView();
            SetupFilters();
        }

        private void SetupDataGridView()
        {
            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            
            dgvCustomers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvCustomers.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 250);
            
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.ReadOnly = true;
        }

        private void SetupFilters()
        {
            cmbFilter.Items.AddRange(new object[] 
            { 
                "Hamısı", 
                "Aktiv Müştərilər", 
                "VIP Müştərilər",
                "Yeni Müştərilər (30 gün)",
                "Passiv Müştərilər (90 gün)",
                "Borcu Olan Müştərilər",
                "Kredit Limiti Aşılan"
            });
            cmbFilter.SelectedIndex = 1; // Aktiv Müştərilər
        }

        private void LoadCustomers()
        {
            try
            {
                _isLoading = true;
                
                var customers = GetFilteredCustomers().Select(m => new
                {
                    m.Id,
                    MusteriKodu = m.MusteriKoduFormatli,
                    TamAd = m.TamAdVeSirket,
                    m.MusteriTipi,
                    QrupAdi = m.MusteriQrupuAdi,
                    Telefon = m.TelefonBilgisi,
                    m.Email,
                    UmumiAlis = m.UmumiAlis.ToString("C"),
                    CariBorc = m.CariBorc.ToString("C"),
                    KreditLimiti = m.KreditLimitiFormatli,
                    Seviyye = m.MusteriSeviyyesi,
                    SonZiyaret = m.SonZiyaretTarixi.HasValue ? m.SonZiyaretTarixi.Value.ToString("dd.MM.yyyy") : "Heç vaxt",
                    m.Status
                }).ToList();

                dgvCustomers.DataSource = customers;
                
                if (dgvCustomers.Columns.Count > 0)
                {
                    dgvCustomers.Columns["Id"].Visible = false;
                    dgvCustomers.Columns["MusteriKodu"].HeaderText = "Kod";
                    dgvCustomers.Columns["TamAd"].HeaderText = "Ad/Şirkət";
                    dgvCustomers.Columns["MusteriTipi"].HeaderText = "Tip";
                    dgvCustomers.Columns["QrupAdi"].HeaderText = "Qrup";
                    dgvCustomers.Columns["Telefon"].HeaderText = "Telefon";
                    dgvCustomers.Columns["Email"].HeaderText = "Email";
                    dgvCustomers.Columns["UmumiAlis"].HeaderText = "Ümumi Alış";
                    dgvCustomers.Columns["CariBorc"].HeaderText = "Cari Borc";
                    dgvCustomers.Columns["KreditLimiti"].HeaderText = "Kredit Limiti";
                    dgvCustomers.Columns["Seviyye"].HeaderText = "Səviyyə";
                    dgvCustomers.Columns["SonZiyaret"].HeaderText = "Son Ziyarət";
                    dgvCustomers.Columns["Status"].HeaderText = "Status";

                    // Color coding
                    foreach (DataGridViewRow row in dgvCustomers.Rows)
                    {
                        var seviyye = row.Cells["Seviyye"].Value?.ToString();
                        switch (seviyye)
                        {
                            case "VIP":
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 223, 186);
                                break;
                            case "Premium":
                                row.DefaultCellStyle.BackColor = Color.FromArgb(214, 234, 248);
                                break;
                            case "Yeni":
                                row.DefaultCellStyle.BackColor = Color.FromArgb(209, 231, 221);
                                break;
                        }
                    }
                }

                lblTotalCustomers.Text = customers.Count.ToString();
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Müştəri məlumatları yüklənərkən xəta baş verdi.");
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void LoadCustomerGroups()
        {
            try
            {
                var groups = _musteriService.GetAllCustomerGroups().ToList();
                cmbCustomerGroup.Items.Clear();
                cmbCustomerGroup.Items.Add("Hamısı");
                
                foreach (var group in groups)
                {
                    cmbCustomerGroup.Items.Add(group);
                }
                
                cmbCustomerGroup.DisplayMember = "Ad";
                cmbCustomerGroup.ValueMember = "Id";
                cmbCustomerGroup.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Müştəri qrupları yüklənərkən xəta baş verdi.");
            }
        }

        private List<Musteri> GetFilteredCustomers()
        {
            var selectedFilter = cmbFilter.SelectedItem?.ToString();
            var selectedGroup = cmbCustomerGroup.SelectedIndex > 0 ? 
                               ((MusteriQrupu)cmbCustomerGroup.SelectedItem).Id : (int?)null;
            var searchTerm = txtSearch.Text.Trim();

            // Start with materialized data to avoid Entity Framework translation issues
            var customers = _musteriService.GetActiveCustomers().ToList();

            // Apply group filter
            if (selectedGroup.HasValue)
            {
                customers = customers.Where(m => m.MusteriQrupuId == selectedGroup.Value).ToList();
            }

            // Apply search filter
            if (!string.IsNullOrEmpty(searchTerm))
            {
                customers = _musteriService.SearchCustomers(searchTerm).ToList();
            }

            // Apply special filters on materialized data
            switch (selectedFilter)
            {
                case "VIP Müştərilər":
                    customers = customers.Where(m => m.UmumiAlis > 10000).ToList();
                    break;
                case "Yeni Müştərilər (30 gün)":
                    var newDate = DateTime.Now.AddDays(-30);
                    customers = customers.Where(m => m.YaradilmaTarixi >= newDate).ToList();
                    break;
                case "Passiv Müştərilər (90 gün)":
                    var passiveDate = DateTime.Now.AddDays(-90);
                    customers = customers.Where(m => !m.SonZiyaretTarixi.HasValue || m.SonZiyaretTarixi < passiveDate).ToList();
                    break;
                case "Borcu Olan Müştərilər":
                    customers = customers.Where(m => m.CariBorc > 0).ToList();
                    break;
                case "Kredit Limiti Aşılan":
                    customers = customers.Where(m => m.CariBorc > m.KreditLimiti && m.KreditLimiti > 0).ToList();
                    break;
            }

            return customers;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                var addForm = new MusteriAddForm(_currentUser);
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadCustomers();
                    ErrorHandlingService.ShowSuccess("Müştəri uğurla əlavə edildi.");
                }
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Müştəri əlavə edilərkən xəta baş verdi.");
            }
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomers.SelectedRows.Count == 0)
                {
                    ErrorHandlingService.ShowValidationError("Düzəltmək üçün müştəri seçin.");
                    return;
                }

                var customerId = (int)dgvCustomers.SelectedRows[0].Cells["Id"].Value;
                var editForm = new MusteriEditForm(customerId, _currentUser);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadCustomers();
                    ErrorHandlingService.ShowSuccess("Müştəri məlumatları uğurla yeniləndi.");
                }
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Müştəri düzəldilməsi zamanı xəta baş verdi.");
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomers.SelectedRows.Count == 0)
                {
                    ErrorHandlingService.ShowValidationError("Silmək üçün müştəri seçin.");
                    return;
                }

                var customerId = (int)dgvCustomers.SelectedRows[0].Cells["Id"].Value;
                var customerName = dgvCustomers.SelectedRows[0].Cells["TamAd"].Value.ToString();

                if (!ErrorHandlingService.ShowConfirmation($"{customerName} adlı müştərini silmək istədiyinizdən əminsiniz?"))
                    return;

                var result = _musteriService.DeleteCustomer(customerId, _currentUser.Id);
                if (result.Success)
                {
                    LoadCustomers();
                    ErrorHandlingService.ShowSuccess(result.Message);
                }
                else
                {
                    ErrorHandlingService.ShowValidationError(result.Message);
                }
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Müştəri silinərkən xəta baş verdi.");
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomers.SelectedRows.Count == 0)
                {
                    ErrorHandlingService.ShowValidationError("Detalları görmək üçün müştəri seçin.");
                    return;
                }

                var customerId = (int)dgvCustomers.SelectedRows[0].Cells["Id"].Value;
                var detailsForm = new MusteriDetailsForm(customerId);
                detailsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Müştəri detalları göstərilərkən xəta baş verdi.");
            }
        }

        private void btnManageGroups_Click(object sender, EventArgs e)
        {
            try
            {
                var groupsForm = new MusteriGroupManagementForm(_currentUser);
                if (groupsForm.ShowDialog() == DialogResult.OK)
                {
                    LoadCustomerGroups();
                    LoadCustomers();
                }
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Müştəri qrupları idarə edilərkən xəta baş verdi.");
            }
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoading)
                LoadCustomers();
        }

        private void cmbCustomerGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoading)
                LoadCustomers();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!_isLoading)
                LoadCustomers();
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnViewDetails_Click(sender, e);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _musteriService?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}