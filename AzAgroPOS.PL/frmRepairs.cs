using AzAgroPOS.BLL;
using AzAgroPOS.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class frmRepairs : Form
    {
        // BLL sinifləri
        private readonly TemirBLL _temirBll = new TemirBLL();
        private readonly TemirStatusuBLL _temirStatusuBll = new TemirStatusuBLL();
        private readonly IstifadeciBLL _istifadeciBll = new IstifadeciBLL();
        private readonly MehsulBLL _mehsulBll = new MehsulBLL();
        private readonly TemirHisseleriBLL _temirHisseleriBll = new TemirHisseleriBLL();

        // Vəziyyəti izləyən sahələr
        private Musteri _selectedCustomer;
        private int _selectedRepairId = 0;
        private Mehsul _foundPart; // Axtarışdan tapılan ehtiyat hissəsi

        public frmRepairs()
        {
            InitializeComponent();
        }

        private void frmRepairs_Load(object sender, EventArgs e)
        {
            LoadInitialData();
            ClearForm(); 
        }

        #region Köməkçi Metodlar

        private void LoadInitialData()
        {
            LoadStatuses();
            LoadTechnicians();
            LoadRepairs();
        }

        private void LoadStatuses()
        {
            try
            {
                cmbStatus.DataSource = _temirStatusuBll.GetAll();
                cmbStatus.DisplayMember = "Ad";
                cmbStatus.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Statuslar yüklənərkən xəta baş verdi: " + ex.Message);
            }
        }

        private void LoadTechnicians()
        {
            try
            {
                var technicians = _istifadeciBll.GetAllByRole("Təmirçi");
                var displayList = technicians.Select(t => new { Id = t.Id, FullName = t.Ad + " " + t.Soyad }).ToList();
                cmbTechnician.DataSource = displayList;
                cmbTechnician.DisplayMember = "FullName";
                cmbTechnician.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Təmirçilər yüklənərkən xəta baş verdi: " + ex.Message);
            }
        }

        private void LoadRepairs()
        {
            try
            {
                dgvRepairs.DataSource = _temirBll.GetAll();
                SetupRepairsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Təmir sifarişləri yüklənərkən xəta baş verdi: " + ex.Message);
            }
        }

        private void SetupRepairsGrid()
        {
            if (dgvRepairs.Columns.Count == 0) return;
            dgvRepairs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            string[] hiddenColumns = { "MusteriId", "TemirciId", "StatusId", "Marka", "Model", "SeriyaNomresi", "ProblemTesviri" };
            foreach (var colName in hiddenColumns)
            {
                if (dgvRepairs.Columns[colName] != null) dgvRepairs.Columns[colName].Visible = false;
            }

            if (dgvRepairs.Columns["Id"] != null) dgvRepairs.Columns["Id"].HeaderText = "Sifariş ID";
            if (dgvRepairs.Columns["QebulTarixi"] != null) dgvRepairs.Columns["QebulTarixi"].HeaderText = "Qəbul Tarixi";
            if (dgvRepairs.Columns["CihazAdi"] != null) dgvRepairs.Columns["CihazAdi"].HeaderText = "Cihaz Adı";
            if (dgvRepairs.Columns["MusteriAdi"] != null) dgvRepairs.Columns["MusteriAdi"].HeaderText = "Müştəri";
            if (dgvRepairs.Columns["StatusAdi"] != null) dgvRepairs.Columns["StatusAdi"].HeaderText = "Status";
            if (dgvRepairs.Columns["TemirciAdi"] != null) dgvRepairs.Columns["TemirciAdi"].HeaderText = "Təmirçi";
        }
        
        private void LoadSpareParts(int repairId)
        {
            try
            {
                dgvSpareParts.DataSource = _temirHisseleriBll.GetByTemirId(repairId);
                SetupSparePartsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ehtiyat hissələri yüklənərkən xəta baş verdi: " + ex.Message);
            }
        }
        
        private void SetupSparePartsGrid()
        {
            if (dgvSpareParts.Columns.Count == 0) return;
            dgvSpareParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            if (dgvSpareParts.Columns["MehsulAdi"] != null) dgvSpareParts.Columns["MehsulAdi"].HeaderText = "Hissənin Adı";
            if (dgvSpareParts.Columns["Miqdar"] != null) dgvSpareParts.Columns["Miqdar"].HeaderText = "Miqdar";
            if (dgvSpareParts.Columns["QiymetBirEdede"] != null) dgvSpareParts.Columns["QiymetBirEdede"].HeaderText = "Vahid Qiyməti";
            if (dgvSpareParts.Columns["TotalQiymet"] != null) dgvSpareParts.Columns["TotalQiymet"].HeaderText = "Yekun Qiymət";

            string[] hiddenColumns = { "Id", "TemirId", "MehsulId", "EndirimMeblegi" }; // Endirimi gələcəkdə əlavə edə bilərik
            foreach (var colName in hiddenColumns)
            {
                if (dgvSpareParts.Columns[colName] != null) dgvSpareParts.Columns[colName].Visible = false;
            }
        }

        private void ClearForm()
        {
            _selectedCustomer = null;
            _selectedRepairId = 0;
            _foundPart = null;
            
            lblSelectedCustomer.Text = "Müştəri seçilməyib";
            txtCihazAdi.Clear();
            txtMarka.Clear();
            txtModel.Clear();
            txtSeriyaNomresi.Clear();
            txtProblem.Clear();
            txtPartSearch.Clear();
            numPartQuantity.Value = 1;

            if (cmbStatus.Items.Count > 0) cmbStatus.SelectedIndex = 0;
            cmbTechnician.SelectedItem = null;
            
            dgvRepairs.ClearSelection();
            dgvSpareParts.DataSource = null;
            
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            tabControl1.TabPages[1].Enabled = false; // Ehtiyat hissələri tabını passiv edirik
        }
        #endregion

        #region Hadisə Metodları (Event Handlers)
        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            using (var searchForm = new frmCustomerSearch())
            {
                if (searchForm.ShowDialog() == DialogResult.OK)
                {
                    _selectedCustomer = searchForm.SelectedCustomer;
                    lblSelectedCustomer.Text = $"{_selectedCustomer.Ad} {_selectedCustomer.Soyad}";
                }
            }
        }

        private void dgvRepairs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRepairs.CurrentRow == null) return;

            var temir = (Temir)dgvRepairs.CurrentRow.DataBoundItem;
            _selectedRepairId = temir.Id;
            _selectedCustomer = new Musteri { Id = temir.MusteriId, Ad = temir.MusteriAdi };

            lblSelectedCustomer.Text = temir.MusteriAdi;
            txtCihazAdi.Text = temir.CihazAdi;
            txtMarka.Text = temir.Marka;
            txtModel.Text = temir.Model;
            txtSeriyaNomresi.Text = temir.SeriyaNomresi;
            txtProblem.Text = temir.ProblemTesviri;
            cmbStatus.SelectedValue = temir.StatusId;

            if (temir.TemirciId.HasValue)
            {
                cmbTechnician.SelectedValue = temir.TemirciId.Value;
            }
            else
            {
                cmbTechnician.SelectedItem = null;
            }

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            tabControl1.TabPages[1].Enabled = true; // Ehtiyat hissələri tabını aktiv edirik
            LoadSpareParts(temir.Id);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null)
            {
                MessageBox.Show("Zəhmət olmasa, müştəri seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var yeniTemir = new Temir
            {
                MusteriId = _selectedCustomer.Id,
                CihazAdi = txtCihazAdi.Text,
                Marka = txtMarka.Text,
                Model = txtModel.Text,
                SeriyaNomresi = txtSeriyaNomresi.Text,
                ProblemTesviri = txtProblem.Text,
                StatusId = (int)cmbStatus.SelectedValue,
                TemirciId = (int?)cmbTechnician.SelectedValue
            };

            bool result = _temirBll.Add(yeniTemir, out string message);
            MessageBox.Show(message);

            if (result)
            {
                LoadRepairs();
                ClearForm();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedRepairId == 0)
            {
                MessageBox.Show("Yeniləmək üçün cədvəldən bir sifariş seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var temir = new Temir
            {
                Id = _selectedRepairId,
                MusteriId = _selectedCustomer.Id,
                CihazAdi = txtCihazAdi.Text,
                Marka = txtMarka.Text,
                Model = txtModel.Text,
                SeriyaNomresi = txtSeriyaNomresi.Text,
                ProblemTesviri = txtProblem.Text,
                StatusId = (int)cmbStatus.SelectedValue,
                TemirciId = (int?)cmbTechnician.SelectedValue
            };

            bool result = _temirBll.Update(temir, out string message);
            MessageBox.Show(message);

            if (result)
            {
                LoadRepairs();
                ClearForm();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedRepairId == 0)
            {
                MessageBox.Show("Silmək üçün cədvəldən sifariş seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Sifariş ID: {_selectedRepairId} olan təmiri silmək istədiyinizə əminsinizmi?", "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                bool opResult = _temirBll.Delete(_selectedRepairId, out string message);
                MessageBox.Show(message);
                if (opResult)
                {
                    LoadRepairs();
                    ClearForm();
                }
            }
        }

        private void txtPartSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txtPartSearch.Text))
            {
                _foundPart = _mehsulBll.GetByBarcode(txtPartSearch.Text);
                if (_foundPart != null)
                {
                    txtPartSearch.Text = $"{_foundPart.Ad} (Stokda: {_foundPart.CariStok})";
                    numPartQuantity.Focus();
                }
                else
                {
                    MessageBox.Show("Bu barkoda uyğun məhsul (ehtiyat hissəsi) tapılmadı.");
                    _foundPart = null;
                }
            }
        }

       
        #endregion

        private void btnAddPart_Click_1(object sender, EventArgs e)
        {

            if (_selectedRepairId == 0)
            {
                MessageBox.Show("Əvvəlcə təmir sifarişini seçin.");
                return;
            }
            if (_foundPart == null)
            {
                MessageBox.Show("Əlavə etmək üçün ehtiyat hissəsi axtarıb tapın.");
                return;
            }
            if (numPartQuantity.Value <= 0)
            {
                MessageBox.Show("Miqdar 0-dan böyük olmalıdır.");
                return;
            }

            var yeniHisse = new TemirHissesi
            {
                TemirId = _selectedRepairId,
                MehsulId = _foundPart.Id,
                Miqdar = (int)numPartQuantity.Value,
                QiymetBirEdede = _foundPart.SatisQiymeti
            };

            bool result = _temirHisseleriBll.Add(yeniHisse, out string message);
            MessageBox.Show(message);

            if (result)
            {
                LoadSpareParts(_selectedRepairId);
                txtPartSearch.Clear();
                numPartQuantity.Value = 1;
                _foundPart = null;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {

        }

        private void btnCompleteRepair_Click(object sender, EventArgs e)
        {

        }
    }
}