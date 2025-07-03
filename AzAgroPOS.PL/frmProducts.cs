// Fayl: AzAgroPOS.PL/frmProducts.cs
using AzAgroPOS.BLL;
using AzAgroPOS.Entities;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class frmProducts : Form
    {
        // BLL siniflərini yaradırıq
        private readonly MehsulBLL _mehsulBll = new MehsulBLL();
        private readonly KateqoriyaBLL _kateqoriyaBll = new KateqoriyaBLL();
        private readonly VahidBLL _vahidBll = new VahidBLL();

        public frmProducts()
        {
            InitializeComponent();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            // Forma yüklənərkən lazımi məlumatları gətiririk
            LoadCategories();
            LoadUnits();
            LoadProducts();
        }

        private void LoadCategories()
        {
            cmbKateqoriya.DataSource = _kateqoriyaBll.GetAll();
            cmbKateqoriya.DisplayMember = "Ad"; // İstifadəçiyə görünən dəyər
            cmbKateqoriya.ValueMember = "Id";   // Arxa planda saxlanan dəyər
        }

        private void LoadUnits()
        {
            cmbVahid.DataSource = _vahidBll.GetAll();
            cmbVahid.DisplayMember = "Ad";
            cmbVahid.ValueMember = "Id";
        }

        private void LoadProducts()
        {
            dgvProducts.DataSource = _mehsulBll.GetAll();
            // Cədvəlin görünüşünü səliqəyə salmaq
            if (dgvProducts.Columns["Id"] != null) dgvProducts.Columns["Id"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Yeni məhsul obyekti yaradırıq və formadakı məlumatlarla doldururuq
            var mehsul = new Mehsul
            {
                Ad = txtAd.Text,
                Barkod = txtBarkod.Text,
                KateqoriyaId = (int)cmbKateqoriya.SelectedValue,
                VahidId = (int)cmbVahid.SelectedValue,
                AlisQiymeti = decimal.Parse(txtAlisQiymeti.Text), // Xəta yoxlaması əlavə edilməlidir
                SatisQiymeti = decimal.Parse(txtSatisQiymeti.Text), // Xəta yoxlaması əlavə edilməlidir
                MinimumStok = int.Parse(txtMinimumStok.Text),   // Xəta yoxlaması əlavə edilməlidir
                Aktivdir = true // Məsələn
            };

            bool result = _mehsulBll.Add(mehsul, out string message);

            MessageBox.Show(message);

            if (result)
            {
                LoadProducts(); // Cədvəli yeniləyirik
                ClearForm();    // Formanı təmizləyirik
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtAd.Clear();
            txtBarkod.Clear();
            txtAlisQiymeti.Text = "0";
            txtSatisQiymeti.Text = "0";
            txtMinimumStok.Text = "0";
            cmbKateqoriya.SelectedIndex = 0;
            cmbVahid.SelectedIndex = 0;
        }

        // dgvProducts_CellClick, btnUpdate_Click və btnDelete_Click hadisələri növbəti addımda yazılacaq.
    }
}