using AzAgroPOS.BLL;
using AzAgroPOS.Entities;
using AzAgroPOS.PL.Themes;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    /// <summary>
    /// Müştəri axtarışı və seçimi üçün form. Müştəriləri ad, soyad və ya telefon nömrəsinə görə axtarmaq və seçmək imkanı verir.
    /// </summary>
    public partial class frmCustomerSearch : BaseForm
    {
        private readonly MusteriBLL _musteriBll = new MusteriBLL();

        /// <summary>
        /// Seçilmiş müştəri məlumatlarını saxlayır.
        /// </summary>
        public Musteri SelectedCustomer { get; private set; }

        /// <summary>
        /// frmCustomerSearch konstruktoru.
        /// </summary>
        public frmCustomerSearch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form yüklənərkən işə düşən metod. İlkin müştəri siyahısını yükləyir.
        /// </summary>
        private void frmCustomerSearch_Load(object sender, EventArgs e)
        {
            dgvCustomers.AutoGenerateColumns = true;
            PerformSearch();
        }

        #region Helper Methods

        /// <summary>
        /// Müştəriləri axtarış mətninə görə yükləyir və cədvəldə göstərir.
        /// </summary>
        private void PerformSearch()
        {
            try
            {
                var customerList = _musteriBll.SearchByNameOrPhone(txtSearch.Text);
                dgvCustomers.DataSource = customerList;
                SetupDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müştərilər yüklənərkən xəta baş verdi: " + ex.Message,
                              "Xəta",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// DataGridView sütunlarını tənzimləyir. Gizlədilməsi lazım olan sütunları gizlədir və başlıqları dəyişdirir.
        /// </summary>
        private void SetupDataGrid()
        {
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string[] hiddenColumns = {
                "Id", "NisyeLimiti", "EndirimFaizi", "Aktivdir",
                "Qeyd", "YaradilmaTarixi", "Unvan", "Email"
            };

            foreach (string colName in hiddenColumns)
            {
                if (dgvCustomers.Columns[colName] != null)
                {
                    dgvCustomers.Columns[colName].Visible = false;
                }
            }

            if (dgvCustomers.Columns["Ad"] != null)
                dgvCustomers.Columns["Ad"].HeaderText = "Ad";
            if (dgvCustomers.Columns["Soyad"] != null)
                dgvCustomers.Columns["Soyad"].HeaderText = "Soyad";
            if (dgvCustomers.Columns["Telefon"] != null)
                dgvCustomers.Columns["Telefon"].HeaderText = "Telefon Nömrəsi";
            if (dgvCustomers.Columns["CariNisyeBorcu"] != null)
                dgvCustomers.Columns["CariNisyeBorcu"].HeaderText = "Cari Borc";
        }

        /// <summary>
        /// Cari sətrdəki müştərini seçir və formu bağlayır.
        /// </summary>
        private void SelectAndClose()
        {
            if (dgvCustomers.CurrentRow != null)
            {
                SelectedCustomer = (Musteri)dgvCustomers.CurrentRow.DataBoundItem;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Zəhmət olmasa, bir müştəri seçin.",
                              "Xəbərdarlıq",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Event Handlers

        /// <summary>
        /// Axtarış mətnində dəyişiklik olduqda işə düşən metod.
        /// </summary>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        /// <summary>
        /// DataGridView-də cərgəyə iki dəfə klik edildikdə işə düşən metod.
        /// </summary>
        private void dgvCustomers_DoubleClick(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        /// <summary>
        /// Seç düyməsinə klik edildikdə işə düşən metod.
        /// </summary>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        /// <summary>
        /// Ləğv et düyməsinə klik edildikdə işə düşən metod.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion
    }
}