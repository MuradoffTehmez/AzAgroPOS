using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL;
using AzAgroPOS.Entities.Domain;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class TamirWorkerAssignForm : Form
    {
        private readonly int _repairId;
        private readonly Istifadeci _currentUser;
        private readonly AzAgroDbContext _context;
        private readonly TamirService _tamirService;
        private TamirIsi _repair;

        public TamirWorkerAssignForm(int repairId, Istifadeci currentUser)
        {
            InitializeComponent();
            _repairId = repairId;
            _currentUser = currentUser;
            _context = new AzAgroDbContext();
            _tamirService = new TamirService();
            SetupForm();
            LoadRepairInfo();
            LoadWorkers();
        }

        private void SetupForm()
        {
            this.BackColor = Color.FromArgb(236, 240, 241);
        }

        private void LoadRepairInfo()
        {
            try
            {
                _repair = _tamirService.GetRepairById(_repairId);
                if (_repair == null)
                {
                    MessageBox.Show("Təmir məlumatı tapılmadı.", "Xəta", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                lblRepairInfo.Text = $"Təmir: {_repair.TamirNomresiFormatli} - {_repair.MehsulAdi}";
                lblCurrentWorker.Text = _repair.TeyinEdilenIstifadeci?.TamAd ?? "Təyin edilməyib";
                lblPriority.Text = _repair.PrioritetAzerbaycan;
                lblStatus.Text = _repair.StatusAzerbaycan;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Təmir məlumatları yüklənərkən xəta: {ex.Message}", "Xəta", 
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
                
                cmbWorker.Items.Add("Təyin etmə");
                foreach (var worker in workers)
                {
                    cmbWorker.Items.Add(worker);
                }
                cmbWorker.DisplayMember = "TamAd";
                cmbWorker.ValueMember = "Id";
                
                // Set current worker if assigned
                if (_repair?.TeyinEdilenIstifadeciId.HasValue == true)
                {
                    for (int i = 1; i < cmbWorker.Items.Count; i++)
                    {
                        var worker = (Istifadeci)cmbWorker.Items[i];
                        if (worker.Id == _repair.TeyinEdilenIstifadeciId.Value)
                        {
                            cmbWorker.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    cmbWorker.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşçi məlumatları yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int? newWorkerId = null;
                string workerName = "Təyin edilməyib";
                
                if (cmbWorker.SelectedIndex > 0)
                {
                    var selectedWorker = (Istifadeci)cmbWorker.SelectedItem;
                    newWorkerId = selectedWorker.Id;
                    workerName = selectedWorker.TamAd;
                }

                // Check if assignment changed
                if (_repair.TeyinEdilenIstifadeciId == newWorkerId)
                {
                    MessageBox.Show("Yeni təyinat hazırkı təyinatla eynidir.", "Məlumat", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _repair.TeyinEdilenIstifadeciId = newWorkerId;
                _repair.YenilenmeTarixi = DateTime.Now;

                _tamirService.UpdateRepair(_repair, _currentUser.Id);
                
                // Add audit log entry
                string notes = string.IsNullOrEmpty(txtNotes.Text) ? "" : $" - Qeyd: {txtNotes.Text}";
                
                MessageBox.Show($"İşçi təyinatı uğurla yeniləndi: {workerName}{notes}", "Uğur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşçi təyin edərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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