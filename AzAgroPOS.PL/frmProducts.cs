using AzAgroPOS.BLL;
using AzAgroPOS.Entities;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class frmProducts : Form
    {
        private readonly MehsulBLL _mehsulBll = new MehsulBLL();
        private readonly KateqoriyaBLL _kateqoriyaBll = new KateqoriyaBLL();
        private readonly VahidBLL _vahidBll = new VahidBLL();

        public frmProducts()
        {
            InitializeComponent();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadUnits();
            LoadProducts();
        }

        #region Helper Methods
        private void LoadCategories()
        {
            try
            {
                cmbKateqoriya.DataSource = _kateqoriyaBll.GetAll();
                cmbKateqoriya.DisplayMember = "Ad";
                cmbKateqoriya.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kateqoriyalar yüklənərkən xəta baş verdi: " + ex.Message);
            }
        }

        private void LoadUnits()
        {
            try
            {
                cmbVahid.DataSource = _vahidBll.GetAll();
                cmbVahid.DisplayMember = "Ad";
                cmbVahid.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vahidlər yüklənərkən xəta baş verdi: " + ex.Message);
            }
        }

        private void LoadProducts()
        {
            try
            {
                dgvProducts.DataSource = _mehsulBll.GetAll();
                SetupDataGridColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Məhsullar yüklənərkən xəta baş verdi: " + ex.Message);
            }
        }

        private void SetupDataGridColumns()
        {
            if (dgvProducts.Columns["Id"] != null) dgvProducts.Columns["Id"].Visible = false;
            if (dgvProducts.Columns["KateqoriyaId"] != null) dgvProducts.Columns["KateqoriyaId"].Visible = false;
            if (dgvProducts.Columns["VahidId"] != null) dgvProducts.Columns["VahidId"].Visible = false;
            // ... digər gizlədilməli sütunlar
        }

        private void ClearForm()
        {
            txtAd.Clear();
            txtBarkod.Clear();
            txtAlisQiymeti.Text = "0.00";
            txtSatisQiymeti.Text = "0.00";
            txtMinimumStok.Text = "0";
            if (cmbKateqoriya.Items.Count > 0) cmbKateqoriya.SelectedIndex = 0;
            if (cmbVahid.Items.Count > 0) cmbVahid.SelectedIndex = 0;
            dgvProducts.ClearSelection();
        }
        #endregion

        #region Event Handlers
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;

            Mehsul selectedProduct = (Mehsul)dgvProducts.CurrentRow.DataBoundItem;
            if (selectedProduct == null) return;

            txtAd.Text = selectedProduct.Ad;
            txtBarkod.Text = selectedProduct.Barkod;
            txtAlisQiymeti.Text = selectedProduct.AlisQiymeti.ToString("F2");
            txtSatisQiymeti.Text = selectedProduct.SatisQiymeti.ToString("F2");
            txtMinimumStok.Text = selectedProduct.MinimumStok.ToString();
            cmbKateqoriya.SelectedValue = selectedProduct.KateqoriyaId;
            cmbVahid.SelectedValue = selectedProduct.VahidId;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var mehsul = new Mehsul
                {
                    Ad = txtAd.Text,
                    Barkod = txtBarkod.Text,
                    KateqoriyaId = (int)cmbKateqoriya.SelectedValue,
                    VahidId = (int)cmbVahid.SelectedValue,
                    AlisQiymeti = decimal.Parse(txtAlisQiymeti.Text),
                    SatisQiymeti = decimal.Parse(txtSatisQiymeti.Text),
                    MinimumStok = int.Parse(txtMinimumStok.Text),
                    Aktivdir = true
                };

                bool result = _mehsulBll.Add(mehsul, out string message);
                MessageBox.Show(message, result ? "Uğurlu" : "Xəta", MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result)
                {
                    LoadProducts();
                    ClearForm();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Zəhmət olmasa, qiymət və stok sahələrinə düzgün rəqəm daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Anlaşılmayan bir xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Zəhmət olmasa, yeniləmək üçün cədvəldən bir məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int selectedProductId = ((Mehsul)dgvProducts.CurrentRow.DataBoundItem).Id;
                var mehsul = new Mehsul
                {
                    Id = selectedProductId,
                    Ad = txtAd.Text,
                    Barkod = txtBarkod.Text,
                    KateqoriyaId = (int)cmbKateqoriya.SelectedValue,
                    VahidId = (int)cmbVahid.SelectedValue,
                    AlisQiymeti = decimal.Parse(txtAlisQiymeti.Text),
                    SatisQiymeti = decimal.Parse(txtSatisQiymeti.Text),
                    MinimumStok = int.Parse(txtMinimumStok.Text),
                    Aktivdir = true
                };

                bool result = _mehsulBll.Update(mehsul, out string message);
                MessageBox.Show(message, result ? "Uğurlu" : "Xəta", MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result)
                {
                    LoadProducts();
                    ClearForm();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Zəhmət olmasa, qiymət və stok sahələrinə düzgün rəqəm daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Anlaşılmayan bir xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        #endregion
    }
}