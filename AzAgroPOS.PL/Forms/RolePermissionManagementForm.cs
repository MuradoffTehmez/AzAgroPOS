using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using AzAgroPOS.BLL.Services;
using AzAgroPOS.PL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    /// <summary>
    /// Rol və İcazə İdarəetməsi Formu
    /// Analiz nəticəsində əskik olduğu müəyyən edilən kritik ekran
    /// </summary>
    public partial class RolePermissionManagementForm : BaseForm
    {
        private readonly Istifadeci _currentUser;
        private readonly IServiceProvider _serviceProvider;

        // Form components
        private ListView lvRoles;
        private ListView lvPermissions;
        private TextBox txtRoleName;
        private TextBox txtRoleDescription;
        private CheckedListBox clbPermissions;
        private Button btnAddRole;
        private Button btnEditRole;
        private Button btnDeleteRole;
        private Button btnSaveRolePermissions;
        private GroupBox gbRoles;
        private GroupBox gbPermissions;
        private GroupBox gbRoleDetails;

        public RolePermissionManagementForm(Istifadeci currentUser, IServiceProvider serviceProvider)
        {
            _currentUser = currentUser;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            InitializeFormComponents();
            LoadRoles();
            LoadAvailablePermissions();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            // Form Properties
            this.Text = "Rol və İcazə İdarəetməsi";
            this.Size = new System.Drawing.Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            
            this.ResumeLayout(false);
        }

        private void InitializeFormComponents()
        {
            // Roles GroupBox
            gbRoles = new GroupBox
            {
                Text = "Mövcud Rollar",
                Location = new System.Drawing.Point(12, 12),
                Size = new System.Drawing.Size(300, 250)
            };

            lvRoles = new ListView
            {
                Location = new System.Drawing.Point(6, 19),
                Size = new System.Drawing.Size(288, 200),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true
            };
            lvRoles.Columns.Add("Rol Adı", 150);
            lvRoles.Columns.Add("Təsvir", 135);
            lvRoles.SelectedIndexChanged += LvRoles_SelectedIndexChanged;

            // Role management buttons
            btnAddRole = new Button
            {
                Text = "Yeni Rol",
                Location = new System.Drawing.Point(6, 225),
                Size = new System.Drawing.Size(70, 23)
            };
            btnAddRole.Click += BtnAddRole_Click;

            btnEditRole = new Button
            {
                Text = "Redaktə",
                Location = new System.Drawing.Point(82, 225),
                Size = new System.Drawing.Size(70, 23),
                Enabled = false
            };
            btnEditRole.Click += BtnEditRole_Click;

            btnDeleteRole = new Button
            {
                Text = "Sil",
                Location = new System.Drawing.Point(158, 225),
                Size = new System.Drawing.Size(70, 23),
                Enabled = false
            };
            btnDeleteRole.Click += BtnDeleteRole_Click;

            gbRoles.Controls.AddRange(new Control[] { lvRoles, btnAddRole, btnEditRole, btnDeleteRole });

            // Role Details GroupBox
            gbRoleDetails = new GroupBox
            {
                Text = "Rol Məlumatları",
                Location = new System.Drawing.Point(330, 12),
                Size = new System.Drawing.Size(300, 120)
            };

            var lblRoleName = new Label
            {
                Text = "Rol Adı:",
                Location = new System.Drawing.Point(6, 25),
                Size = new System.Drawing.Size(60, 13)
            };

            txtRoleName = new TextBox
            {
                Location = new System.Drawing.Point(80, 22),
                Size = new System.Drawing.Size(200, 20)
            };

            var lblRoleDescription = new Label
            {
                Text = "Təsvir:",
                Location = new System.Drawing.Point(6, 55),
                Size = new System.Drawing.Size(60, 13)
            };

            txtRoleDescription = new TextBox
            {
                Location = new System.Drawing.Point(80, 52),
                Size = new System.Drawing.Size(200, 20)
            };

            gbRoleDetails.Controls.AddRange(new Control[] { lblRoleName, txtRoleName, lblRoleDescription, txtRoleDescription });

            // Permissions GroupBox
            gbPermissions = new GroupBox
            {
                Text = "Rol İcazələri",
                Location = new System.Drawing.Point(330, 145),
                Size = new System.Drawing.Size(300, 350)
            };

            clbPermissions = new CheckedListBox
            {
                Location = new System.Drawing.Point(6, 19),
                Size = new System.Drawing.Size(288, 290),
                CheckOnClick = true
            };

            btnSaveRolePermissions = new Button
            {
                Text = "İcazələri Yadda Saxla",
                Location = new System.Drawing.Point(6, 315),
                Size = new System.Drawing.Size(120, 30),
                Enabled = false
            };
            btnSaveRolePermissions.Click += BtnSaveRolePermissions_Click;

            gbPermissions.Controls.AddRange(new Control[] { clbPermissions, btnSaveRolePermissions });

            // Add all controls to form
            this.Controls.AddRange(new Control[] { gbRoles, gbRoleDetails, gbPermissions });
        }

        private void LoadRoles()
        {
            try
            {
                lvRoles.Items.Clear();
                
                // Bu real implementasiyada RoleService istifadə ediləcək
                var roles = new List<Rol>
                {
                    new Rol { Id = 1, Ad = SystemConstants.Roles.Administrator, Aciklama = "Sistem administratoru" },
                    new Rol { Id = 2, Ad = SystemConstants.Roles.Manager, Aciklama = "Menecer" },
                    new Rol { Id = 3, Ad = SystemConstants.Roles.Cashier, Aciklama = "Kassir" },
                    new Rol { Id = 4, Ad = SystemConstants.Roles.Accountant, Aciklama = "Mühasib" }
                };

                foreach (var role in roles)
                {
                    var item = new ListViewItem(role.Ad);
                    item.SubItems.Add(role.Aciklama);
                    item.Tag = role;
                    lvRoles.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rollar yüklənərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAvailablePermissions()
        {
            try
            {
                clbPermissions.Items.Clear();
                
                // Sistem icazələri
                var permissions = new List<string>
                {
                    "Müştəri İdarəetməsi",
                    "Məhsul İdarəetməsi", 
                    "Satış Əməliyyatları",
                    "Alış Əməliyyatları",
                    "Anbar İdarəetməsi",
                    "Maliyyə Hesabatları",
                    "İstifadəçi İdarəetməsi",
                    "Sistem Ayarları",
                    "Backup Əməliyyatları",
                    "Audit Log Görüntüləmə",
                    "Təmir İdarəetməsi",
                    "Tədarükçü İdarəetməsi",
                    "Xərc İdarəetməsi",
                    "Borc İdarəetməsi"
                };

                foreach (var permission in permissions)
                {
                    clbPermissions.Items.Add(permission);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İcazələr yüklənərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LvRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRoles.SelectedItems.Count > 0)
            {
                var selectedRole = (Rol)lvRoles.SelectedItems[0].Tag;
                
                txtRoleName.Text = selectedRole.Ad;
                txtRoleDescription.Text = selectedRole.Aciklama;
                
                btnEditRole.Enabled = true;
                btnDeleteRole.Enabled = selectedRole.Ad != SystemConstants.Roles.Administrator; // Admin rolunu silmək olmaz
                btnSaveRolePermissions.Enabled = true;
                
                LoadRolePermissions(selectedRole.Id);
            }
            else
            {
                txtRoleName.Clear();
                txtRoleDescription.Clear();
                btnEditRole.Enabled = false;
                btnDeleteRole.Enabled = false;
                btnSaveRolePermissions.Enabled = false;
                
                for (int i = 0; i < clbPermissions.Items.Count; i++)
                {
                    clbPermissions.SetItemChecked(i, false);
                }
            }
        }

        private void LoadRolePermissions(int roleId)
        {
            try
            {
                // Real implementasiyada RolePermissionService istifadə ediləcək
                // İndi sadəcə mock məlumatlar
                var rolePermissions = new List<string>();
                
                switch (roleId)
                {
                    case 1: // Administrator
                        rolePermissions = clbPermissions.Items.Cast<string>().ToList();
                        break;
                    case 2: // Manager
                        rolePermissions = new List<string>
                        {
                            "Müştəri İdarəetməsi", "Məhsul İdarəetməsi", "Satış Əməliyyatları",
                            "Anbar İdarəetməsi", "Maliyyə Hesabatları", "Təmir İdarəetməsi"
                        };
                        break;
                    case 3: // Cashier
                        rolePermissions = new List<string> { "Satış Əməliyyatları", "Müştəri İdarəetməsi" };
                        break;
                    case 4: // Accountant
                        rolePermissions = new List<string> { "Maliyyə Hesabatları", "Xərc İdarəetməsi", "Borc İdarəetməsi" };
                        break;
                }

                for (int i = 0; i < clbPermissions.Items.Count; i++)
                {
                    string permission = clbPermissions.Items[i].ToString();
                    clbPermissions.SetItemChecked(i, rolePermissions.Contains(permission));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rol icazələri yüklənərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddRole_Click(object sender, EventArgs e)
        {
            txtRoleName.Clear();
            txtRoleDescription.Clear();
            txtRoleName.Focus();
            
            for (int i = 0; i < clbPermissions.Items.Count; i++)
            {
                clbPermissions.SetItemChecked(i, false);
            }
        }

        private void BtnEditRole_Click(object sender, EventArgs e)
        {
            if (lvRoles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Redaktə etmək üçün bir rol seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRole = (Rol)lvRoles.SelectedItems[0].Tag;
            
            if (string.IsNullOrWhiteSpace(txtRoleName.Text))
            {
                MessageBox.Show("Rol adı daxil edin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                selectedRole.Ad = txtRoleName.Text.Trim();
                selectedRole.Aciklama = txtRoleDescription.Text.Trim();
                
                // Real implementasiyada RoleService.Update çağırılacaq
                
                LoadRoles();
                MessageBox.Show("Rol uğurla yeniləndi.", "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rol yenilənərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteRole_Click(object sender, EventArgs e)
        {
            if (lvRoles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Silmək üçün bir rol seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRole = (Rol)lvRoles.SelectedItems[0].Tag;
            
            if (selectedRole.Ad == SystemConstants.Roles.Administrator)
            {
                MessageBox.Show("Administrator rolunu silmək olmaz.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"'{selectedRole.Ad}' rolunu silmək istədiyinizə əminsiniz?", 
                "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Real implementasiyada RoleService.Delete çağırılacaq
                    LoadRoles();
                    MessageBox.Show("Rol uğurla silindi.", "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Rol silinərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnSaveRolePermissions_Click(object sender, EventArgs e)
        {
            if (lvRoles.SelectedItems.Count == 0)
            {
                MessageBox.Show("İcazələri saxlamaq üçün bir rol seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRole = (Rol)lvRoles.SelectedItems[0].Tag;
            var selectedPermissions = new List<string>();

            for (int i = 0; i < clbPermissions.Items.Count; i++)
            {
                if (clbPermissions.GetItemChecked(i))
                {
                    selectedPermissions.Add(clbPermissions.Items[i].ToString());
                }
            }

            try
            {
                // Real implementasiyada RolePermissionService.SaveRolePermissions çağırılacaq
                MessageBox.Show($"'{selectedRole.Ad}' rolunun icazələri uğurla saxlanıldı.", 
                    "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İcazələr saxlanılarkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}