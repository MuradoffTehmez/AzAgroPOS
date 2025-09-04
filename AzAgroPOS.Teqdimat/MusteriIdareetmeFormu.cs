using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat
{
    public partial class MusteriIdareetmeFormu : BazaForm, IMusteriView
    {
        private readonly MusteriPresenter _presenter;

        public MusteriIdareetmeFormu()
        {
            InitializeComponent();
            _presenter = new MusteriPresenter(this);
            // Form yüklənəndə Presenter-ə xəbər veririk
            this.Load += (s, e) => FormYuklendi?.Invoke(this, EventArgs.Empty);
            StilVerDataGridView(dgvMusteriler);
        }

        #region IMusteriView Implementasiyası

        public int SecilmisMusteriId => dgvMusteriler.CurrentRow?.DataBoundItem is MusteriDto musteri ? musteri.Id : 0;

        public string TamAd { get => txtTamAd.Text; set => txtTamAd.Text = value; }
        public string Telefon { get => txtTelefon.Text; set => txtTelefon.Text = value; }
        public string Unvan { get => txtUnvan.Text; set => txtUnvan.Text = value; }
        public string KreditLimiti { get => txtKreditLimiti.Text; set => txtKreditLimiti.Text = value; }
        public string AxtarisMetni => txtAxtaris.Text;

        public event EventHandler FormYuklendi;
        public event EventHandler MusteriSecildi;
        public event EventHandler YeniMusteriIstek;
        public event EventHandler YaddaSaxlaIstek;
        public event EventHandler SilIstek;
        public event EventHandler AxtarIstek;

        public void MusterileriGoster(List<MusteriDto> musteriler)
        {
            // SelectionChanged hadisəsini müvəqqəti dayandırırıq ki, datanı yükləyəndə təkrar-təkrar işə düşməsin
            dgvMusteriler.SelectionChanged -= dgvMusteriler_SelectionChanged;
            dgvMusteriler.DataSource = musteriler;
            if (dgvMusteriler.Columns.Count > 0)
            {
                dgvMusteriler.Columns["Id"].Visible = false;
                dgvMusteriler.Columns["Unvan"].Visible = false;
                dgvMusteriler.Columns["TamAd"].HeaderText = "Tam Ad";
                dgvMusteriler.Columns["TelefonNomresi"].HeaderText = "Telefon";
                dgvMusteriler.Columns["UmumiBorc"].HeaderText = "Cari Borc";
                dgvMusteriler.Columns["KreditLimiti"].HeaderText = "Kredit Limiti";

                dgvMusteriler.Columns["UmumiBorc"].DefaultCellStyle.Format = "N2";
                dgvMusteriler.Columns["KreditLimiti"].DefaultCellStyle.Format = "N2";
            }
            dgvMusteriler.SelectionChanged += dgvMusteriler_SelectionChanged;
        }

        public void FormuTemizle()
        {
            txtTamAd.Clear();
            txtTelefon.Clear();
            txtUnvan.Clear();
            txtKreditLimiti.Text = "0";
            dgvMusteriler.ClearSelection();
            txtTamAd.Focus();
        }

        public void MesajGoster(string mesaj, string basliq, MessageBoxIcon ikon)
        {
            MessageBox.Show(mesaj, basliq, MessageBoxButtons.OK, ikon);
        }

        #endregion

        #region Hadisə Ötürücüləri

        private void dgvMusteriler_SelectionChanged(object sender, EventArgs e) => MusteriSecildi?.Invoke(sender, e);
        private void btnYeni_Click(object sender, EventArgs e) => YeniMusteriIstek?.Invoke(sender, e);
        private void btnYaddaSaxla_Click(object sender, EventArgs e) => YaddaSaxlaIstek?.Invoke(sender, e);
        private void btnSil_Click(object sender, EventArgs e) => SilIstek?.Invoke(sender, e);
        private void txtAxtaris_TextChanged(object sender, EventArgs e) => AxtarIstek?.Invoke(sender, e);

        #endregion
    }
}