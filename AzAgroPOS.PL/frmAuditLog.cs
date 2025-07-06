using AzAgroPOS.BLL;
using AzAgroPOS.PL.Themes;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class frmAuditLog : BaseForm
    {
        private readonly EmeliyyatJurnaliBLL _logBll = new EmeliyyatJurnaliBLL();
        private readonly IstifadeciBLL _userBll = new IstifadeciBLL();

        public frmAuditLog()
        {
            InitializeComponent();
        }

        private void frmAuditLog_Load(object sender, EventArgs e)
        {
            LoadUsers();
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Today;
            btnFilter_Click(null, null);
        }

        private void LoadUsers()
        {
            try
            {
                var users = _userBll.GetAll();
                var displayList = users.Select(u => new { Id = u.Id, FullName = u.Ad + " " + u.Soyad }).ToList();

                // Siyahının başına "Bütün İstifadəçilər" seçimi əlavə edirik
                displayList.Insert(0, new { Id = 0, FullName = "Bütün İstifadəçilər" });

                cmbUsers.DataSource = displayList;
                cmbUsers.DisplayMember = "FullName";
                cmbUsers.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("İstifadəçilər yüklənərkən xəta baş verdi: " + ex.Message);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                var startDate = dtpStartDate.Value.Date;
                var endDate = dtpEndDate.Value.Date.AddDays(1).AddTicks(-1);
                var userId = (int)cmbUsers.SelectedValue == 0 ? (int?)null : (int)cmbUsers.SelectedValue;
                var keyword = txtSearch.Text.Trim();

                dgvAuditLog.DataSource = _logBll.Search(startDate, endDate, userId, keyword);
                SetupGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Jurnal yüklənərkən xəta baş verdi: " + ex.Message);
            }
        }

        private void SetupGrid()
        {
            if (dgvAuditLog.Columns.Count == 0) return;
            dgvAuditLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditLog.Columns["Id"].Visible = false;
            dgvAuditLog.Columns["IstifadeciId"].Visible = false;

            dgvAuditLog.Columns["IstifadeciAdi"].HeaderText = "İstifadəçi";
            dgvAuditLog.Columns["EmeliyyatTarixi"].HeaderText = "Tarix";
            dgvAuditLog.Columns["EmeliyyatNovu"].HeaderText = "Əməliyyat Növü";
            dgvAuditLog.Columns["Tesvir"].HeaderText = "Ətraflı Məlumat";

            dgvAuditLog.Columns["EmeliyyatTarixi"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss";
            dgvAuditLog.Columns["Tesvir"].FillWeight = 200; // Təsvir sütunu daha geniş olsun
        }
    }
}