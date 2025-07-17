using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class RoleManagementForm : BaseForm
    {
        private readonly RolRepository _rolRepository;
        // private readonly RolIcazesiRepository _rolIcazesiRepository;
        private readonly Istifadeci _currentUser;

        public RoleManagementForm(Istifadeci currentUser) : base()
        {
            InitializeComponent();
            var context = new AzAgroDbContext();
            _rolRepository = new RolRepository(context);
            // _rolIcazesiRepository = new RolIcazesiRepository(context);
            _currentUser = currentUser;
        }

        private async void RoleManagementForm_Load(object sender, EventArgs e)
        {
            await LoadRolesAsync();
        }

        private async Task LoadRolesAsync()
        {
            await ExecuteAsync(async () =>
            {
                var roles = await _rolRepository.GetAllAsync();
                dgvRoles.DataSource = roles;
                
                // DataGridView sütunlarını nizamla
                if (dgvRoles.Columns.Count > 0)
                {
                    dgvRoles.Columns["Id"].HeaderText = "ID";
                    dgvRoles.Columns["Ad"].HeaderText = "Rol Adı";
                    dgvRoles.Columns["Tesvir"].HeaderText = "Təsvir";
                    dgvRoles.Columns["Status"].HeaderText = "Status";
                    dgvRoles.Columns["YaradilmaTarixi"].HeaderText = "Yaradılma Tarixi";
                    
                    // Digər sütunları gizlə
                    foreach (DataGridViewColumn column in dgvRoles.Columns)
                    {
                        if (!new[] { "Id", "Ad", "Tesvir", "Status", "YaradilmaTarixi" }.Contains(column.Name))
                        {
                            column.Visible = false;
                        }
                    }
                }
            }, "Rollar yüklənərkən xəta baş verdi");
        }

        private async void btnAddRole_Click(object sender, EventArgs e)
        {
            // var addForm = new RoleAddForm(_currentUser); // Form not found
            // if (addForm.ShowDialog() == DialogResult.OK)
            {
                await LoadRolesAsync();
            }
        }

        private async void btnEditRole_Click(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count == 0)
            {
                ShowInfo("Redaktə etmək üçün rol seçin.");
                return;
            }

            var selectedRole = (Rol)dgvRoles.SelectedRows[0].DataBoundItem;
            // var editForm = new RoleEditForm(selectedRole, _currentUser); // Form not found
            // if (editForm.ShowDialog() == DialogResult.OK)
            {
                await LoadRolesAsync();
            }
        }

        private async void btnDeleteRole_Click(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count == 0)
            {
                ShowInfo("Silmək üçün rol seçin.");
                return;
            }

            var selectedRole = (Rol)dgvRoles.SelectedRows[0].DataBoundItem;
            
            if (ShowConfirmation($"'{selectedRole.Ad}' rolunu silmək istədiyinizə əminsiniz?"))
            {
                await ExecuteAsync(async () =>
                {
                    // Rola təyin edilmiş istifadəçilərin olub-olmadığını yoxla
                    var context = new AzAgroDbContext();
                    var istifadeciRepository = new IstifadeciRepository(context);
                    var istifadeciler = istifadeciRepository.GetAll().Where(i => i.RolId == selectedRole.Id).ToList();
                    
                    if (istifadeciler.Any())
                    {
                        ShowWarning($"Bu rol {istifadeciler.Count()} istifadəçiyə təyin edilib. Əvvəlcə onların rolunu dəyişdirin.");
                        return;
                    }

                    // Rola aid icazələri sil - commented out due to missing repository
                    // var icazeler = await _rolIcazesiRepository.GetByRoleIdAsync(selectedRole.Id);
                    // foreach (var icaze in icazeler)
                    // {
                    //     _rolIcazesiRepository.Delete(icaze);
                    // }

                    // Rolu sil
                    await _rolRepository.DeleteAsync(selectedRole.Id);
                    // No SaveChangesAsync needed for RolRepository

                    ShowSuccess("Rol uğurla silindi!");
                    await LoadRolesAsync();
                }, "Rol silinərkən xəta baş verdi");
            }
        }

        private async void btnManagePermissions_Click(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count == 0)
            {
                ShowInfo("İcazələri idarə etmək üçün rol seçin.");
                return;
            }

            var selectedRole = (Rol)dgvRoles.SelectedRows[0].DataBoundItem;
            // var permissionForm = new RolePermissionForm(selectedRole, _currentUser); // Form not found
            // permissionForm.ShowDialog();
        }

        private void dgvRoles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditRole_Click(sender, e);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}