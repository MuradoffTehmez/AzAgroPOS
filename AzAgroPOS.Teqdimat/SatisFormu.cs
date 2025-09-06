using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Teqdimat.Yardimcilar; // Add this using directive
using AzAgroPOS.Mentiq.Idareciler;
using Microsoft.Extensions.DependencyInjection;
using AzAgroPOS.Varliglar;
using MaterialSkin.Controls;
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
        private readonly IServiceProvider _serviceProvider;

        public SatisFormu(SatisManager satisManager, MehsulManager mehsulManager, MusteriManager musteriManager)
        {
            InitializeComponent();
            _presenter = new SatisPresenter(this, satisManager, mehsulManager, musteriManager);
            this.Load += (s, e) => FormYuklendiIstek?.Invoke(this, EventArgs.Empty);
            ConfigureDataGridViewStyles();
            AddCartActionButtons();
        }

        #region ISatisView Implementasiyası

        public string AxtarisMetni => txtAxtaris.Text;
        public string SecilmisMehsulMiqdari => txtMiqdar.Text;
        public MehsulDto? SecilmisAxtarisMehsulu => dgvAxtarisNeticeleri.CurrentRow?.DataBoundItem as MehsulDto;
        public SatisSebetiElementiDto? SecilmisSebetElementi => dgvSebet.CurrentRow?.DataBoundItem as SatisSebetiElementiDto;
        public int? SecilmisMusteriId => (int?)cmbMusteriler.SelectedValue > 0 ? (int?)cmbMusteriler.SelectedValue : null;

        public event EventHandler FormYuklendiIstek;
        public event EventHandler MehsulAxtarIstek;
        public event EventHandler<MehsulDto> SuretliSatisIstek;
        public event EventHandler SebeteElaveEtIstek;
        public event EventHandler SebetdenSilIstek;
        public event EventHandler SebetiTemizleIstek;
        public event EventHandler SatisiGozletIstek;
        public event EventHandler GozleyenSatisiAcIstek;
        public event EventHandler<OdenisMetodu> SatisiTesdiqleIstek;
        public event EventHandler<EndirimParametrləriDto> IndirimIstek;
        public event EventHandler<int> SebetMiqdarArtirIstek;
        public event EventHandler<int> SebetMiqdarAzaltIstek;
        public event EventHandler YeniMusteriFormuAcIstek;
        public event EventHandler MusteriSiyahisiniYenileIstek;

        public void SuretliSatisMehsullariniGoster(List<MehsulDto> mehsullar)
        {
            flpSuretliSatis.Controls.Clear();
            foreach (var mehsul in mehsullar)
            {
                var button = new MaterialButton
                {
                    Text = mehsul.Ad,
                    Tag = mehsul,
                    Width = 125,
                    Height = 70,
                    Margin = new Padding(5)
                };
                button.Click += SuretliSatisButton_Click;
                flpSuretliSatis.Controls.Add(button);
            }
        }

        public void GozleyenSatislarSayiniGuncelle(int say)
        {
            btnGozleyenSatislar.Text = $"Gözləyənlər ({say}) (F5)";
        }

        public void UmumiMebligiGoster(decimal umumiMebleg, decimal endirim, decimal yekunMebleg)
        {
            lblUmumiMebleg.Text = $"{yekunMebleg:N2} AZN";
            toolTip1.SetToolTip(lblUmumiMebleg, $"Cəm: {umumiMebleg:N2} AZN\nEndirim: {endirim:N2} AZN");
        }

        public void MusteriSiyahisiniGoster(List<MusteriDto> musteriler)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => MusteriSiyahisiniGoster(musteriler)));
                return;
            }

            var listDataSource = new List<object> { new { Id = 0, TamAd = "Şəxsi Satış (müştərisiz)" } };
            listDataSource.AddRange(musteriler.Select(m => new { m.Id, TamAd = $"{m.TamAd} (Borc: {m.UmumiBorc:N2})" }).ToList());

            cmbMusteriler.DataSource = listDataSource;
            cmbMusteriler.DisplayMember = "TamAd";
            cmbMusteriler.ValueMember = "Id";
        }

        public void AxtarisNeticeleriniGoster(List<MehsulDto> mehsullar)
        {
            dgvAxtarisNeticeleri.DataSource = mehsullar;
            if (dgvAxtarisNeticeleri.Columns.Count > 0)
            {
                dgvAxtarisNeticeleri.Columns["Ad"].HeaderText = "Məhsul Adı";
                dgvAxtarisNeticeleri.Columns["StokKodu"].HeaderText = "Stok Kodu";
                // Digər sütunları gizlədirik
                string[] gorunenler = { "Ad", "StokKodu" };
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
            AxtarisPaneliniSifirla();
            if (cmbMusteriler.Items.Count > 0) cmbMusteriler.SelectedIndex = 0;
        }

        public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon)
        {
            return MessageBox.Show(this, mesaj, basliq, düymələr, ikon);
        }

        #endregion

        #region Hadisə Ötürücüləri
        private void txtAxtaris_TextChanged(object sender, EventArgs e) => MehsulAxtarIstek?.Invoke(this, EventArgs.Empty);
        private void btnSebeteElaveEt_Click(object sender, EventArgs e) => SebeteElaveEtIstek?.Invoke(this, EventArgs.Empty);
        private void dgvAxtarisNeticeleri_DoubleClick(object sender, EventArgs e) => btnSebeteElaveEt.PerformClick();
        private void SuretliSatisButton_Click(object sender, EventArgs e)
        {
            if (sender is Button { Tag: MehsulDto mehsul })
            {
                SuretliSatisIstek?.Invoke(this, mehsul);
            }
        }
        private void btnSebetdenSil_Click(object sender, EventArgs e) => SebetdenSilIstek?.Invoke(this, EventArgs.Empty);
        private void btnSebetTemizle_Click(object sender, EventArgs e) => SebetiTemizleIstek?.Invoke(this, EventArgs.Empty);
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
        private void btnIndirim_Click(object sender, EventArgs e)
        {
            var secilmisElement = SecilmisSebetElementi;
            using (var endirimFormu = new EndirimFormu(secilmisElement))
            {
                if (endirimFormu.ShowDialog(this) == DialogResult.OK)
                {
                    IndirimIstek?.Invoke(this, endirimFormu.EndirimParametrləri);
                }
            }
        }
        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
            using (var musteriFormu = _serviceProvider.GetRequiredService<MusteriIdareetmeFormu>())
            {
                musteriFormu.ShowDialog();
            }
            MusteriSiyahisiniYenileIstek?.Invoke(this, EventArgs.Empty);
        }
        private void dgvSebet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!(dgvSebet.Rows[e.RowIndex].DataBoundItem is SatisSebetiElementiDto sebetElementi)) return;

            var mehsulId = sebetElementi.MehsulId;

            if (dgvSebet.Columns[e.ColumnIndex].Name == "artir_col")
            {
                SebetMiqdarArtirIstek?.Invoke(this, mehsulId);
            }
            else if (dgvSebet.Columns[e.ColumnIndex].Name == "azalt_col")
            {
                SebetMiqdarAzaltIstek?.Invoke(this, mehsulId);
            }
        }
        private void SatisFormu_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: btnNagd.PerformClick(); break;
                case Keys.F2: btnKart.PerformClick(); break;
                case Keys.F3: btnNisye.PerformClick(); break;
                case Keys.F4: btnSatisiGozlet.PerformClick(); break;
                case Keys.F5: btnGozleyenSatislar.PerformClick(); break;
                case Keys.F6: btnIndirim.PerformClick(); break;
                case Keys.F7: btnSebeteElaveEt.PerformClick(); break;
            }
            e.Handled = true;
        }
        #endregion

       
        private void AddCartActionButtons()
        {
            if (dgvSebet.Columns["artir_col"] == null)
            {
                var artirCol = new DataGridViewButtonColumn
                {
                    Name = "artir_col",
                    Text = "+",
                    UseColumnTextForButtonValue = true,
                    Width = 40,
                    HeaderText = ""
                };
                dgvSebet.Columns.Add(artirCol);
            }

            if (dgvSebet.Columns["azalt_col"] == null)
            {
                var azaltCol = new DataGridViewButtonColumn
                {
                    Name = "azalt_col",
                    Text = "-",
                    UseColumnTextForButtonValue = true,
                    Width = 40,
                    HeaderText = ""
                };
                dgvSebet.Columns.Add(azaltCol);
            }
        }
        #region UI Konfiqurasiyası
        private void ConfigureDataGridViewStyles()
        {
            // Ümumi GridView Parametrləri üçün metod
            void ApplyCommonGridStyle(DataGridView grid, Color headerBack, Color selectionBack, Color altRow)
            {
                grid.BackgroundColor = Color.White;
                grid.BorderStyle = BorderStyle.None;
                grid.RowHeadersVisible = false;
                grid.AllowUserToResizeRows = false;
                grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                grid.GridColor = Color.FromArgb(230, 230, 230);

                // Header
                grid.ColumnHeadersDefaultCellStyle.BackColor = headerBack;
                grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                grid.EnableHeadersVisualStyles = false;
                grid.ColumnHeadersHeight = 40;

                // Hüceyrələr
                grid.DefaultCellStyle.BackColor = Color.White;
                grid.DefaultCellStyle.ForeColor = Color.Black;
                grid.DefaultCellStyle.SelectionBackColor = selectionBack;
                grid.DefaultCellStyle.SelectionForeColor = Color.Black;
                grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                grid.DefaultCellStyle.Padding = new Padding(5, 3, 5, 3);

                // Alternativ sətirlər
                grid.AlternatingRowsDefaultCellStyle.BackColor = altRow;

                // Sətir parametrləri
                grid.RowTemplate.Height = 35;
            }

            // Axtarış Cədvəli Stili (mavi tonlar)
            ApplyCommonGridStyle(
                dgvAxtarisNeticeleri,
                Color.FromArgb(33, 150, 243), // header rəngi (blue)
                Color.FromArgb(187, 222, 251), // selection rəngi (light blue)
                Color.FromArgb(245, 245, 245)  // alternating rəng
            );

            // Səbət Cədvəli Stili (yaşıl tonlar)
            ApplyCommonGridStyle(
                dgvSebet,
                Color.FromArgb(76, 175, 80),  // header rəngi (green)
                Color.FromArgb(200, 230, 201), // selection rəngi (light green)
                Color.FromArgb(245, 245, 245)  // alternating rəng
            );
        }
        #endregion

    }
}