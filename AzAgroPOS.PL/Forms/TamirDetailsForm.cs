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
    public partial class TamirDetailsForm : BaseForm
    {
        private readonly int _repairId;
        private readonly TamirService _tamirService;
        private TamirIsi _repair;

        public TamirDetailsForm(int repairId, Istifadeci currentUser) : base()
        {
            InitializeComponent();
            _repairId = repairId;
            _currentUser = currentUser;
            _tamirService = ServiceFactory.CreateTamirService();
            SetupForm();
            LoadRepairDetails();
        }

        private void SetupForm()
        {
            this.BackColor = Color.FromArgb(236, 240, 241);
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvSteps.EnableHeadersVisualStyles = false;
            dgvSteps.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvSteps.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSteps.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            
            dgvSteps.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvSteps.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvSteps.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 250);
            
            dgvSteps.BorderStyle = BorderStyle.None;
            dgvSteps.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSteps.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSteps.MultiSelect = false;
            dgvSteps.AllowUserToAddRows = false;
            dgvSteps.AllowUserToDeleteRows = false;
            dgvSteps.ReadOnly = true;
        }

        private void LoadRepairDetails()
        {
            try
            {
                _repair = _tamirService.GetRepairById(_repairId);
                if (_repair == null)
                {
                    ShowError("Təmir məlumatı tapılmadı.");
                    this.Close();
                    return;
                }

                // Load basic repair information
                lblTamirNomresi.Text = _repair.TamirNomresiFormatli;
                lblMusteriAdi.Text = _repair.Musteri?.Ad ?? "Naməlum";
                lblMehsulAdi.Text = _repair.MehsulAdi;
                lblMehsulModeli.Text = _repair.Model ?? "N/A";
                lblSeriNomresi.Text = _repair.SeriNomresi ?? "N/A";
                lblProblemTasviri.Text = _repair.ProblemTasviri;
                lblQebulTarixi.Text = _repair.QebulTarixi.ToString("dd.MM.yyyy");
                lblTaxminiBitirmeTarixi.Text = _repair.TaxminiBitirmeTarixi?.ToString("dd.MM.yyyy") ?? "N/A";
                lblTaxminQiymet.Text = _repair.TaxminQiymet.ToString("C");
                lblSonQiymet.Text = _repair.SonQiymet.ToString("C");
                lblStatus.Text = _repair.StatusAzerbaycan;
                lblPrioritet.Text = _repair.PrioritetAzerbaycan;
                lblTeyinEdilenIsci.Text = _repair.TeyinEdilenIstifadeci?.TamAd ?? "Təyin edilməyib";
                lblMusteriQeydleri.Text = string.IsNullOrEmpty(_repair.MusteriQeydleri) ? "Qeyd yoxdur" : _repair.MusteriQeydleri;
                lblTamirciQeydleri.Text = string.IsNullOrEmpty(_repair.TamirciQeydleri) ? "Qeyd yoxdur" : _repair.TamirciQeydleri;
                
                // Set status color
                switch (_repair.Status)
                {
                    case "Ready":
                        lblStatus.ForeColor = Color.FromArgb(46, 204, 113);
                        break;
                    case "InProgress":
                        lblStatus.ForeColor = Color.FromArgb(241, 196, 15);
                        break;
                    case "Cancelled":
                        lblStatus.ForeColor = Color.FromArgb(231, 76, 60);
                        break;
                    default:
                        lblStatus.ForeColor = Color.FromArgb(52, 73, 94);
                        break;
                }

                LoadRepairSteps();
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Təmir məlumatları yüklənərkən xəta baş verdi.");
            }
        }

        private void LoadRepairSteps()
        {
            try
            {
                var steps = _repair.TamirMerheleri?.Select(s => new
                {
                    s.Id,
                    MerheleAdi = s.MerheleAdi,
                    Aciklama = s.Aciklama,
                    BaslamaTarixi = s.BaslangicTarixi?.ToString("dd.MM.yyyy HH:mm") ?? "Başlamayıb",
                    BitirilmisTarix = s.BitirilmisTarix?.ToString("dd.MM.yyyy HH:mm") ?? "Bitməyib",
                    Status = s.StatusAzerbaycan,
                    MesulIsci = s.TeyinEdilenIstifadeci?.TamAd ?? "Təyin edilməyib"
                }).ToList();

                dgvSteps.DataSource = steps;
                
                if (dgvSteps.Columns.Count > 0)
                {
                    dgvSteps.Columns["Id"].Visible = false;
                    dgvSteps.Columns["MerheleAdi"].HeaderText = "Mərhələ";
                    dgvSteps.Columns["Aciklama"].HeaderText = "Açıqlama";
                    dgvSteps.Columns["BaslamaTarixi"].HeaderText = "Başlama";
                    dgvSteps.Columns["BitirilmisTarix"].HeaderText = "Bitirmə";
                    dgvSteps.Columns["Status"].HeaderText = "Status";
                    dgvSteps.Columns["MesulIsci"].HeaderText = "Mesül";
                }
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Təmir mərhələləri yüklənərkən xəta baş verdi.");
            }
        }

        private void btnEditRepair_Click(object sender, EventArgs e)
        {
            if (_currentUser.Role != SystemConstants.Roles.Administrator && _currentUser.Role != SystemConstants.Roles.Manager)
            {
                MessageBox.Show("Bu əməliyyat üçün icazəniz yoxdur.", "İcazə rədd edildi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Open edit form - would need to create TamirEditForm
            MessageBox.Show("Təmir düzəlt funksiyasi tezliklə əlavə ediləcək.", "Məlumat", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            var statusForm = new TamirStatusForm(_repairId, _currentUser);
            if (statusForm.ShowDialog() == DialogResult.OK)
            {
                LoadRepairDetails();
            }
        }

        private void btnAssignWorker_Click(object sender, EventArgs e)
        {
            var assignForm = new TamirWorkerAssignForm(_repairId, _currentUser);
            if (assignForm.ShowDialog() == DialogResult.OK)
            {
                LoadRepairDetails();
            }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Hesabat çap funksiyasi tezliklə əlavə ediləcək.", "Məlumat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Hesabat yaradılarkən xəta baş verdi.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tamirService?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}