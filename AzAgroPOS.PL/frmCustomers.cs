using AzAgroPOS.BLL;
using AzAgroPOS.Entities;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class frmCustomers : Form
    {
        private readonly MusteriBLL _musteriBll = new MusteriBLL();
        private int _selectedCustomerId = 0;

        public frmCustomers()
        {
            InitializeComponent();
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            dgvCustomers.DataSource = _musteriBll.GetAll();
            // Burada SetupDataGrid() metodu ilə sütunları səliqəyə sala bilərsiniz.
        }

        private void ClearForm()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtTelefon.Clear();
            txtUnvan.Clear();
            txtEmail.Clear();
            txtNisyeLimiti.Text = "0.00";
            txtEndirimFaizi.Text = "0";
            txtQeyd.Clear();
            chkAktivdir.Checked = true;
            _selectedCustomerId = 0;
            dgvCustomers.ClearSelection();
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null) return;

            var musteri = (Musteri)dgvCustomers.CurrentRow.DataBoundItem;
            _selectedCustomerId = musteri.Id;

            txtAd.Text = musteri.Ad;
            txtSoyad.Text = musteri.Soyad;
            txtTelefon.Text = musteri.Telefon;
            txtUnvan.Text = musteri.Unvan;
            txtEmail.Text = musteri.Email;
            txtNisyeLimiti.Text = musteri.NisyeLimiti.ToString("F2");
            txtEndirimFaizi.Text = musteri.EndirimFaizi.ToString();
            txtQeyd.Text = musteri.Qeyd;
            chkAktivdir.Checked = musteri.Aktivdir;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var musteri = new Musteri
            {
                Ad = txtAd.Text,
                Soyad = txtSoyad.Text,
                Telefon = txtTelefon.Text,
                Unvan = txtUnvan.Text,
                Email = txtEmail.Text,
                NisyeLimiti = decimal.Parse(txtNisyeLimiti.Text),
                EndirimFaizi = decimal.Parse(txtEndirimFaizi.Text),
                Qeyd = txtQeyd.Text,
                Aktivdir = chkAktivdir.Checked
            };

            bool result = _musteriBll.Add(musteri, out string message);
            MessageBox.Show(message);
            if (result)
            {
                LoadCustomers();
                ClearForm();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedCustomerId == 0) return;
            var musteri = new Musteri
            {
                Id = _selectedCustomerId,
                Ad = txtAd.Text,
                Soyad = txtSoyad.Text,
                Telefon = txtTelefon.Text,
                Unvan = txtUnvan.Text,
                Email = txtEmail.Text,
                NisyeLimiti = decimal.Parse(txtNisyeLimiti.Text),
                EndirimFaizi = decimal.Parse(txtEndirimFaizi.Text),
                Qeyd = txtQeyd.Text,
                Aktivdir = chkAktivdir.Checked
            };
            bool result = _musteriBll.Update(musteri, out string message);
            MessageBox.Show(message);
            if (result)
            {
                LoadCustomers();
                ClearForm();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCustomerId == 0) return;
            var result = MessageBox.Show("Müştərini silmək istədiyinizə əminsinizmi?", "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                bool opResult = _musteriBll.Delete(_selectedCustomerId, out string message);
                MessageBox.Show(message);
                if (opResult)
                {
                    LoadCustomers();
                    ClearForm();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}