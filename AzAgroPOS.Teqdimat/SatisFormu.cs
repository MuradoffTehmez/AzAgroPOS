// Fayl: AzAgroPOS.Teqdimat/SatisFormu.cs
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Varliglar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat
{
    public partial class SatisFormu : BazaForm, ISatisView
    {
        private readonly SatisPresenter _presenter;

        public SatisFormu()
        {
            InitializeComponent();
            _presenter = new SatisPresenter(this);
            // Form yüklənərkən hadisəni (event) çağırırıq
            this.Load += SatisFormu_Load;

            // DataGridView-lərin stilini konfiqurasiya edirik
            ConfigureDataGridViewStyles();
        }

        #region View Implementasiyası (ISatisView)
        public string AxtarisMetni => txtAxtaris.Text;
        public string SecilmisMehsulMiqdari => txtMiqdar.Text;
        public MehsulDto? SecilmisAxtarisMehsulu => dgvAxtarisNeticeleri.CurrentRow?.DataBoundItem as MehsulDto;
        public SatisSebetiElementiDto? SecilmisSebetElementi => dgvSebet.CurrentRow?.DataBoundItem as SatisSebetiElementiDto;
        public int? SecilmisMusteriId => (int?)cmbMusteriler.SelectedValue > 0 ? (int?)cmbMusteriler.SelectedValue : null;

        public event EventHandler FormYuklendiIstek;
        public event EventHandler MehsulAxtarIstek;
        public event EventHandler SebeteElaveEtIstek;
        public event EventHandler SebetdenSilIstek;
        public event EventHandler SebetiTemizleIstek;
        public event EventHandler MiqdariDeyisIstek;
        public event EventHandler SatisiGozletIstek;
        public event EventHandler GozleyenSatisiAcIstek;
        public event EventHandler<OdenisMetodu> SatisiTesdiqleIstek;

        public void AxtarisNeticeleriniGoster(List<MehsulDto> mehsullar)
        {
            dgvAxtarisNeticeleri.DataSource = mehsullar;
            if (dgvAxtarisNeticeleri.Columns.Count > 0)
            {
                dgvAxtarisNeticeleri.Columns["Ad"].HeaderText = "Məhsul Adı";
                dgvAxtarisNeticeleri.Columns["StokKodu"].HeaderText = "Stok Kodu";
                dgvAxtarisNeticeleri.Columns["PerakendeSatisQiymetiStr"].HeaderText = "Qiymət";

                string[] gorunenler = { "Ad", "StokKodu", "PerakendeSatisQiymetiStr" };
                foreach (DataGridViewColumn col in dgvAxtarisNeticeleri.Columns)
                {
                    if (!gorunenler.Contains(col.Name)) col.Visible = false;
                }
            }
        }

        public void AxtarisPaneliniSifirla()
        {
            txtAxtaris.Clear();
            txtMiqdar.Text = "1";
            txtAxtaris.Focus();
        }

        public void SebeteMehsullariGoster(BindingList<SatisSebetiElementiDto> sebet)
        {
            dgvSebet.DataSource = sebet;
            if (dgvSebet.Columns.Count > 0)
            {
                dgvSebet.Columns["MehsulAdi"].HeaderText = "Məhsul Adı";
                dgvSebet.Columns["Miqdar"].HeaderText = "Miqdar";
                dgvSebet.Columns["VahidinQiymeti"].HeaderText = "Qiymət";
                dgvSebet.Columns["QiymetNövü"].HeaderText = "Qiymət Növü";
                dgvSebet.Columns["UmumiMebleg"].HeaderText = "Cəmi Məbləğ";

                dgvSebet.Columns["MehsulId"].Visible = false;
                dgvSebet.Columns["VahidinQiymeti"].ReadOnly = true;
                dgvSebet.Columns["UmumiMebleg"].ReadOnly = true;
                dgvSebet.Columns["MehsulAdi"].ReadOnly = true;
                dgvSebet.Columns["QiymetNövü"].ReadOnly = true;
            }
        }

        public void UmumiMebligiGoster(decimal mebleg)
        {
            lblUmumiMebleg.Text = $"{mebleg:N2} AZN";
        }

        public void MusteriSiyahisiniGoster(List<MusteriDto> musteriler)
        {
            if (InvokeRequired)
            {
                Invoke(() => MusteriSiyahisiniGoster(musteriler));
                return;
            }

            var listDataSource = new List<object> { new { Id = 0, TamAd = "Şəxsi Satış (müştərisiz)" } };
            listDataSource.AddRange(musteriler.Select(m => new { m.Id, TamAd = $"{m.TamAd} (Borc: {m.UmumiBorc:N2})" }).ToList());

            cmbMusteriler.DataSource = listDataSource;
            cmbMusteriler.DisplayMember = "TamAd";
            cmbMusteriler.ValueMember = "Id";
        }

        public void GozleyenSatislarMenyusunuGoster(List<GozleyenSatis> gozleyenSatislar)
        {
            contextMenuStripGozleyenler.Items.Clear();
            if (!gozleyenSatislar.Any())
            {
                contextMenuStripGozleyenler.Items.Add("Gözləyən satış yoxdur.").Enabled = false;
            }
            else
            {
                foreach (var satis in gozleyenSatislar)
                {
                    var menuItem = new ToolStripMenuItem(satis.Ad) { Tag = satis };
                    contextMenuStripGozleyenler.Items.Add(menuItem);
                }
            }
            contextMenuStripGozleyenler.Show(btnGozleyenSatislar, new Point(0, btnGozleyenSatislar.Height));
        }

        public void FormuTamSifirla()
        {
            (dgvSebet.DataSource as BindingList<SatisSebetiElementiDto>)?.Clear();
            AxtarisPaneliniSifirla();
            if (cmbMusteriler.Items.Count > 0) cmbMusteriler.SelectedIndex = 0;
            UmumiMebligiGoster(0);
        }

        public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon)
        {
            return MessageBox.Show(this, mesaj, basliq, düymələr, ikon);
        }
        #endregion

        #region Hadisə Ötürücüləri (Event Handlers)
        private void SatisFormu_Load(object sender, EventArgs e) => FormYuklendiIstek?.Invoke(this, EventArgs.Empty);
        private void txtAxtaris_TextChanged(object sender, EventArgs e) => MehsulAxtarIstek?.Invoke(this, EventArgs.Empty);
        private void btnSebeteElaveEt_Click(object sender, EventArgs e) => SebeteElaveEtIstek?.Invoke(this, EventArgs.Empty);
        private void btnSebetdenSil_Click(object sender, EventArgs e) => SebetdenSilIstek?.Invoke(this, EventArgs.Empty);
        private void btnSebetTemizle_Click(object sender, EventArgs e) => SebetiTemizleIstek?.Invoke(this, EventArgs.Empty);
        private void dgvSebet_CellEndEdit(object sender, DataGridViewCellEventArgs e) => MiqdariDeyisIstek?.Invoke(this, EventArgs.Empty);
        private void btnNagd_Click(object sender, EventArgs e) => SatisiTesdiqleIstek?.Invoke(this, OdenisMetodu.Nağd);
        private void btnKart_Click(object sender, EventArgs e) => SatisiTesdiqleIstek?.Invoke(this, OdenisMetodu.Kart);
        private void btnNisye_Click(object sender, EventArgs e) => SatisiTesdiqleIstek?.Invoke(this, OdenisMetodu.Nisyə);
        private void btnSatisiGozlet_Click(object sender, EventArgs e) => SatisiGozletIstek?.Invoke(this, EventArgs.Empty);
        private void btnGozleyenSatislar_Click(object sender, EventArgs e) => GozleyenSatisiAcIstek?.Invoke(this, EventArgs.Empty);

        private void contextMenuStripGozleyenler_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem?.Tag is GozleyenSatis secilmisSatis)
            {
                _presenter.GozleyenSatisiSec(secilmisSatis);
            }
        }

        private void dgvAxtarisNeticeleri_DoubleClick(object sender, EventArgs e) => btnSebeteElaveEt.PerformClick();

        private void SatisFormu_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: btnNagd.PerformClick(); break;
                case Keys.F2: btnKart.PerformClick(); break;
                case Keys.F3: btnNisye.PerformClick(); break;
                case Keys.F4: btnSatisiGozlet.PerformClick(); break;
                case Keys.F5: btnGozleyenSatislar.PerformClick(); break;
                case Keys.F7: btnSebeteElaveEt.PerformClick(); break;
            }
        }
        #endregion

        #region UI Konfiqurasiyası
        private void ConfigureDataGridViewStyles()
        {
            // Axtarış Cədvəli Stili
            var searchGrid = dgvAxtarisNeticeleri;
            searchGrid.BackgroundColor = Color.FromArgb(245, 245, 245);
            searchGrid.BorderStyle = BorderStyle.None;
            searchGrid.RowHeadersVisible = false;
            searchGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(63, 81, 181);
            searchGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            searchGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            searchGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            searchGrid.EnableHeadersVisualStyles = false;
            searchGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 200, 230);
            searchGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            searchGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            searchGrid.RowTemplate.Height = 30;

            // Səbət Cədvəli Stili
            var cartGrid = dgvSebet;
            cartGrid.BackgroundColor = Color.FromArgb(245, 245, 245);
            cartGrid.BorderStyle = BorderStyle.None;
            cartGrid.RowHeadersVisible = false;
            cartGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(76, 175, 80);
            cartGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            cartGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            cartGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            cartGrid.EnableHeadersVisualStyles = false;
            cartGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 230, 201);
            cartGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            cartGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            cartGrid.RowTemplate.Height = 30;
        }
        #endregion
    }
}