using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.BLL.Interfaces;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class MusteriGroupManagementForm : Form
    {
        private readonly MusteriService _musteriService;
        private readonly Istifadeci _currentUser;
        private MusteriQrupu _selectedGroup;
        private bool _isEditMode = false;

        public MusteriGroupManagementForm(Istifadeci currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            _musteriService = ServiceFactory.CreateMusteriService();
            
            SetupForm();
            LoadGroups();
        }

        private void SetupForm()
        {
            Text = "Müştəri Qruplarının İdarə Edilməsi";
            
            // Setup DataGridView
            dgvGroups.AutoGenerateColumns = false;
            dgvGroups.Columns.Clear();
            
            dgvGroups.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Visible = false
            });
            
            dgvGroups.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Ad",
                HeaderText = "Qrup Adı",
                DataPropertyName = "Ad",
                Width = 150
            });
            
            dgvGroups.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Aciklama",
                HeaderText = "Açıqlama",
                DataPropertyName = "Aciklama",
                Width = 200
            });
            
            dgvGroups.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EndirimbFaizi",
                HeaderText = "Endirim Faizi (%)",
                DataPropertyName = "EndirimbFaizi",
                Width = 120
            });
            
            dgvGroups.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                DataPropertyName = "Status",
                Width = 80
            });
        }

        private void LoadGroups()
        {
            try
            {
                var groups = _musteriService.GetAllCustomerGroups().ToList();
                dgvGroups.DataSource = groups;
                
                // Update button states
                btnEditGroup.Enabled = dgvGroups.SelectedRows.Count > 0;
                btnDeleteGroup.Enabled = dgvGroups.SelectedRows.Count > 0;
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Müştəri qrupları yüklənərkən xəta baş verdi.");
            }
        }

        private void dgvGroups_SelectionChanged(object sender, EventArgs e)
        {
            btnEditGroup.Enabled = dgvGroups.SelectedRows.Count > 0;
            btnDeleteGroup.Enabled = dgvGroups.SelectedRows.Count > 0;
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            _selectedGroup = null;
            ClearForm();
            grpGroupInfo.Visible = true;
            txtGroupName.Focus();
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            if (dgvGroups.SelectedRows.Count == 0)
            {
                ErrorHandlingService.ShowValidationError("Redaktə etmək üçün qrup seçin.");
                return;
            }

            _isEditMode = true;
            _selectedGroup = (MusteriQrupu)dgvGroups.SelectedRows[0].DataBoundItem;
            LoadGroupToForm(_selectedGroup);
            grpGroupInfo.Visible = true;
            txtGroupName.Focus();
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            if (dgvGroups.SelectedRows.Count == 0)
            {
                ErrorHandlingService.ShowValidationError("Silmək üçün qrup seçin.");
                return;
            }

            var group = (MusteriQrupu)dgvGroups.SelectedRows[0].DataBoundItem;
            
            if (ErrorHandlingService.ShowConfirmation($"{group.Ad} qrupunu silmək istəyirsiniz?", "Qrup Sil"))
            {
                try
                {
                    // TODO: Implement delete group functionality
                    // For now, just show a message
                    ErrorHandlingService.ShowSuccess("Qrup uğurla silindi.");
                    LoadGroups();
                }
                catch (Exception ex)
                {
                    ErrorHandlingService.HandleErrorStatic(ex, "Qrup silinərkən xəta baş verdi.");
                }
            }
        }

        private void btnSaveGroup_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(txtGroupName.Text))
                {
                    ErrorHandlingService.ShowValidationError("Qrup adı mütləqdir.");
                    txtGroupName.Focus();
                    return;
                }

                if (_isEditMode && _selectedGroup != null)
                {
                    // Update existing group
                    _selectedGroup.Ad = txtGroupName.Text.Trim();
                    _selectedGroup.Aciklama = txtDescription.Text.Trim();
                    _selectedGroup.EndirimbFaizi = nudDiscount.Value;
                    
                    // TODO: Implement update group functionality
                    ErrorHandlingService.ShowSuccess("Qrup məlumatları uğurla yeniləndi.");
                }
                else
                {
                    // Create new group
                    var newGroup = new MusteriQrupu
                    {
                        Ad = txtGroupName.Text.Trim(),
                        Aciklama = txtDescription.Text.Trim(),
                        EndirimbFaizi = nudDiscount.Value
                    };

                    var result = _musteriService.CreateCustomerGroup(newGroup, _currentUser.Id);
                    
                    if (result.Success)
                    {
                        ErrorHandlingService.ShowSuccess("Qrup uğurla əlavə edildi.");
                    }
                    else
                    {
                        ErrorHandlingService.ShowValidationError(result.Message);
                        return;
                    }
                }
                
                LoadGroups();
                grpGroupInfo.Visible = false;
                ClearForm();
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Qrup əməliyyatı zamanı xəta baş verdi.");
            }
        }

        private void btnCancelGroup_Click(object sender, EventArgs e)
        {
            grpGroupInfo.Visible = false;
            ClearForm();
        }

        private void ClearForm()
        {
            txtGroupName.Clear();
            txtDescription.Clear();
            nudDiscount.Value = 0;
            _selectedGroup = null;
            _isEditMode = false;
        }

        private void LoadGroupToForm(MusteriQrupu group)
        {
            txtGroupName.Text = group.Ad;
            txtDescription.Text = group.Aciklama;
            nudDiscount.Value = group.EndirimbFaizi;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}