using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Varliglar;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat
{
    public partial class TemirIdareetmeFormu : BazaForm, ITemirView
    {
        private readonly TemirPresenter _presenter;

        public TemirIdareetmeFormu(TemirManager temirManager, MusteriManager musteriManager, IstifadeciManager istifadeciManager)
        {
            InitializeComponent();
            _presenter = new TemirPresenter(this, temirManager, musteriManager, istifadeciManager);
            StilVerDataGridView(dgvSifarisler);
        }

        #region ITemirView Implementasiyası

        public string MusteriAdi
        {
            get => txtMusteriAdi.Text;
            set => txtMusteriAdi.Text = value;
        }

        public string MusteriTelefonu
        {
            get => txtMusteriTelefonu.Text;
            set => txtMusteriTelefonu.Text = value;
        }

        public string CihazAdi
        {
            get => txtCihazAdi.Text;
            set => txtCihazAdi.Text = value;
        }

        public string ProblemTesviri
        {
            get => txtProblemTesviri.Text;
            set => txtProblemTesviri.Text = value;
        }

        public decimal YekunMebleg
        {
            get => decimal.TryParse(txtYekunMebleg.Text, out var mebleg) ? mebleg : 0;
            set => txtYekunMebleg.Text = value.ToString("N2");
        }

        public event EventHandler FormYuklendi;
        public event EventHandler YeniSifarisYarat_Istek;
        public event EventHandler SifarisYenile_Istek;
        public event EventHandler SifarisSil_Istek;
        public event EventHandler FormuTemizle_Istek;

        public void SifarisleriGoster(List<TemirDto> sifarisler)
        {
            dgvSifarisler.SelectionChanged -= dgvSifarisler_SelectionChanged;
            dgvSifarisler.DataSource = sifarisler;
            dgvSifarisler.SelectionChanged += dgvSifarisler_SelectionChanged;

            if (dgvSifarisler.Columns.Count > 0)
            {
                dgvSifarisler.Columns["Id"].Visible = false;
                dgvSifarisler.Columns["MusteriAdi"].HeaderText = "Müştəri Adı";
                dgvSifarisler.Columns["MusteriTelefonu"].HeaderText = "Telefon";
                dgvSifarisler.Columns["CihazAdi"].HeaderText = "Cihaz Adı";
                dgvSifarisler.Columns["ProblemTesviri"].HeaderText = "Problem Təsviri";
                dgvSifarisler.Columns["QebulTarixi"].HeaderText = "Qəbul Tarixi";
                dgvSifarisler.Columns["Status"].HeaderText = "Status";
                dgvSifarisler.Columns["YekunMebleg"].HeaderText = "Yekun Məbləğ";
            }
        }

        public void MesajGoster(string mesaj, string basliq)
        {
            MessageBox.Show(mesaj, basliq, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void FormuTemizle()
        {
            txtMusteriAdi.Clear();
            txtMusteriTelefonu.Clear();
            txtCihazAdi.Clear();
            txtProblemTesviri.Clear();
            txtYekunMebleg.Clear();
            dgvSifarisler.ClearSelection();
            txtMusteriAdi.Focus();
        }

        #endregion

        private void TemirIdareetmeFormu_Load(object sender, EventArgs e)
        {
            FormYuklendi?.Invoke(this, EventArgs.Empty);
            FormuTemizle();
        }

        private void btnYarat_Click(object sender, EventArgs e)
        {
            YeniSifarisYarat_Istek?.Invoke(this, EventArgs.Empty);
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            SifarisYenile_Istek?.Invoke(this, EventArgs.Empty);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SifarisSil_Istek?.Invoke(this, EventArgs.Empty);
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            FormuTemizle_Istek?.Invoke(this, EventArgs.Empty);
        }

        private void dgvSifarisler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSifarisler.CurrentRow?.DataBoundItem is TemirDto sifaris)
            {
                txtMusteriAdi.Text = sifaris.MusteriAdi;
                txtMusteriTelefonu.Text = sifaris.MusteriTelefonu;
                txtCihazAdi.Text = sifaris.CihazAdi;
                txtProblemTesviri.Text = sifaris.ProblemTesviri;
                txtYekunMebleg.Text = sifaris.YekunMebleg.ToString("N2");
            }
        }
    }
}