using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL;
using AzAgroPOS.Entities.Domain;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class TamirStatusForm : Form
    {
        private readonly int _repairId;
        private readonly Istifadeci _currentUser;
        private readonly AzAgroDbContext _context;
        private readonly TamirService _tamirService;
        private TamirIsi _repair;

        public TamirStatusForm(int repairId, Istifadeci currentUser)
        {
            InitializeComponent();
            _repairId = repairId;
            _currentUser = currentUser;
            _context = new AzAgroDbContext();
            _tamirService = new TamirService();
            SetupForm();
            LoadRepairInfo();
        }

        private void SetupForm()
        {
            this.BackColor = Color.FromArgb(236, 240, 241);
            LoadStatusOptions();
        }

        private void LoadStatusOptions()
        {
            cmbNewStatus.Items.AddRange(new object[] { "Qəbul Edildi", "İşlənir", "Hazır", "Təhvil Verildi", "İptal" });
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
                lblCurrentStatus.Text = _repair.StatusAzerbaycan;
                
                // Set current status in combo box
                string currentStatusAz = _repair.StatusAzerbaycan;
                for (int i = 0; i < cmbNewStatus.Items.Count; i++)
                {
                    if (cmbNewStatus.Items[i].ToString() == currentStatusAz)
                    {
                        cmbNewStatus.SelectedIndex = i;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbNewStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Zəhmət olmasa yeni status seçin.", "Xəbərdarlıq", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string newStatusEnglish = GetStatusEnglish(cmbNewStatus.SelectedItem.ToString());
                
                if (_repair.Status == newStatusEnglish)
                {
                    MessageBox.Show("Yeni status hazırkı statusla eynidir.", "Məlumat", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _repair.Status = newStatusEnglish;
                _repair.YenilenmeTarixi = DateTime.Now;
                
                // Set completion date if status is Ready or Delivered
                if (newStatusEnglish == "Ready" || newStatusEnglish == "Delivered")
                {
                    _repair.EmeliBitirmeTarixi = DateTime.Now;
                }
                
                // Set delivery date if status is Delivered
                if (newStatusEnglish == "Delivered")
                {
                    _repair.TehvilTarixi = DateTime.Now;
                    _repair.TehvilEdenIstifadeciId = _currentUser.Id;
                }

                _tamirService.UpdateRepair(_repair, _currentUser.Id);
                
                // Add audit log entry
                string notes = string.IsNullOrEmpty(txtNotes.Text) ? "" : $" - Qeyd: {txtNotes.Text}";
                
                MessageBox.Show($"Status uğurla yeniləndi.{notes}", "Uğur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Status yenilənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetStatusEnglish(string azerbaijaniStatus) => azerbaijaniStatus switch
        {
            "Qəbul Edildi" => "Received",
            "İşlənir" => "InProgress",
            "Hazır" => "Ready",
            "Təhvil Verildi" => "Delivered",
            "İptal" => "Cancelled",
            _ => "Received"
        };

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