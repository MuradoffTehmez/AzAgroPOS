// Fayl: AzAgroPOS.Teqdimat/MehsulIdareetmeFormu.cs
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Varliglar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat
{
    public partial class MehsulIdareetmeFormu : BazaForm, IMehsulIdareetmeView
    {
        private readonly MehsulPresenter _presenter;

        public MehsulIdareetmeFormu(MehsulManager mehsulManager)
        {
            InitializeComponent();
            _presenter = new MehsulPresenter(this, mehsulManager);
            StilVerDataGridView(dgvMehsullar);
        }

        #region View Xassə və Hadisələri (Properties and Events)
        public string MehsulId { get => txtId.Text; set => txtId.Text = value; }
        public string MehsulAdi { get => txtAd.Text; set => txtAd.Text = value; }
        public string StokKodu { get => txtStokKodu.Text; set => txtStokKodu.Text = value; }
        public string Barkod { get => txtBarkod.Text; set => txtBarkod.Text = value; }
        public string PerakendeSatisQiymeti { get => txtPerakendeSatisQiymeti.Text; set => txtPerakendeSatisQiymeti.Text = value; }
        public string TopdanSatisQiymeti { get => txtTopdanSatisQiymeti.Text; set => txtTopdanSatisQiymeti.Text = value; }
        public string TekEdedSatisQiymeti { get => txtTekEdedSatisQiymeti.Text; set => txtTekEdedSatisQiymeti.Text = value; }
        public string AlisQiymeti { get => txtAlisQiymeti.Text; set => txtAlisQiymeti.Text = value; }
        public string MovcudSay { get => txtMevcudSay.Text; set => txtMevcudSay.Text = value; }
        public string MinimumStok { get => txtMinimumStok.Text; set => txtMinimumStok.Text = value; }
        public OlcuVahidi SecilmisOlcuVahidi => (OlcuVahidi)cmbOlcuVahidi.SelectedItem;
        public int? SecilmisKateqoriyaId => cmbKateqoriya.SelectedValue as int?;
        public int? SecilmisBrendId => cmbBrend.SelectedValue as int?;
        public int? SecilmisTedarukcuId => cmbTedarukcu.SelectedValue as int?;
        public string AxtarisMetni { get => txtAxtar.Text; set => txtAxtar.Text = value; }

        public event EventHandler FormYuklendi_Istek;
        public event EventHandler MehsulElaveEt_Istek;
        public event EventHandler MehsulYenile_Istek;
        public event EventHandler MehsulSil_Istek;
        public event EventHandler FormuTemizle_Istek;
        public event EventHandler CedvelSecimiDeyisdi_Istek;
        public event EventHandler Axtaris_Istek;
        public event EventHandler StokKoduGeneralasiyaIstek;
        public event EventHandler BarkodGeneralasiyaIstek;
        public event EventHandler Kopyala_Istek;
        #endregion

        #region View Metodları
        public void OlcuVahidleriniGoster(Array olcuVahidleri)
        {
            cmbOlcuVahidi.DataSource = olcuVahidleri;
            if (cmbOlcuVahidi.Items.Count > 0)
                cmbOlcuVahidi.SelectedIndex = 0;
        }

        public void KateqoriyalariGoster(IEnumerable<KateqoriyaDto> kateqoriyalar)
        {
            cmbKateqoriya.DisplayMember = "Ad";
            cmbKateqoriya.ValueMember = "Id";
            cmbKateqoriya.DataSource = kateqoriyalar.ToList();
            cmbKateqoriya.SelectedIndex = -1;
        }

        public void BrendleriGoster(IEnumerable<BrendDto> brendler)
        {
            cmbBrend.DisplayMember = "Ad";
            cmbBrend.ValueMember = "Id";
            cmbBrend.DataSource = brendler.ToList();
            cmbBrend.SelectedIndex = -1;
        }

        public void TedarukculeriGoster(IEnumerable<TedarukcuDto> tedarukculer)
        {
            cmbTedarukcu.DisplayMember = "Ad";
            cmbTedarukcu.ValueMember = "Id";
            cmbTedarukcu.DataSource = tedarukculer.ToList();
            cmbTedarukcu.SelectedIndex = -1;
        }

        public void MehsullariGoster(IEnumerable<MehsulDto> mehsullar)
        {
            var mehsulSiyahisi = mehsullar?.ToList() ?? new List<MehsulDto>();
            dgvMehsullar.SelectionChanged -= dgvMehsullar_SelectionChanged;
            dgvMehsullar.DataSource = mehsulSiyahisi;
            dgvMehsullar.SelectionChanged += dgvMehsullar_SelectionChanged;

            if (dgvMehsullar.Columns.Count > 0)
            {
                string[] gorunenSutunlar = { "Ad", "StokKodu", "PerakendeSatisQiymetiStr", "MovcudSay", "OlcuVahidiStr" };
                foreach (DataGridViewColumn column in dgvMehsullar.Columns)
                {
                    if (!gorunenSutunlar.Contains(column.Name))
                    {
                        column.Visible = false;
                    }
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }

                dgvMehsullar.Columns["Ad"].HeaderText = "Məhsulun Adı";
                dgvMehsullar.Columns["StokKodu"].HeaderText = "Stok Kodu";
                dgvMehsullar.Columns["PerakendeSatisQiymetiStr"].HeaderText = "Pərakəndə Qiymət";
                dgvMehsullar.Columns["MovcudSay"].HeaderText = "Mövcud Say";
                dgvMehsullar.Columns["OlcuVahidiStr"].HeaderText = "Ölçü Vahidi";
            }
        }

        public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon)
        {
            return MessageBox.Show(mesaj, basliq, düymələr, ikon);
        }
        #endregion

        #region Hadisə Ötürücüləri (Event Handlers)
        private void MehsulIdareetmeFormu_Load(object sender, EventArgs e) => FormYuklendi_Istek?.Invoke(this, EventArgs.Empty);
        private void btnElaveEt_Click(object sender, EventArgs e) => MehsulElaveEt_Istek?.Invoke(this, EventArgs.Empty);
        private void btnYenile_Click(object sender, EventArgs e) => MehsulYenile_Istek?.Invoke(this, EventArgs.Empty);
        private void btnSil_Click(object sender, EventArgs e) => MehsulSil_Istek?.Invoke(this, EventArgs.Empty);
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            FormuTemizle_Istek?.Invoke(this, EventArgs.Empty);
            dgvMehsullar.ClearSelection();
            if (cmbOlcuVahidi.Items.Count > 0) cmbOlcuVahidi.SelectedIndex = 0;
            txtAd.Focus();
            btnElaveEt.Text = "Yeni Məhsulu Yadda Saxla";
            btnKopyala.Enabled = false;
        }
        private void btnStokKoduYarat_Click(object sender, EventArgs e) => StokKoduGeneralasiyaIstek?.Invoke(this, EventArgs.Empty);
        private void btnBarkodYarat_Click(object sender, EventArgs e) => BarkodGeneralasiyaIstek?.Invoke(this, EventArgs.Empty);
        private void btnKopyala_Click(object sender, EventArgs e) => Kopyala_Istek?.Invoke(this, EventArgs.Empty);
        private void dgvMehsullar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMehsullar.CurrentRow != null && dgvMehsullar.CurrentRow.DataBoundItem is MehsulDto secilmisMehsul)
            {
                txtId.Text = secilmisMehsul.Id.ToString();
                cmbOlcuVahidi.SelectedItem = secilmisMehsul.OlcuVahidi;
                // Kateqoriya, Brend və Tedarukçu seçimlərini də təyin edirik
                if (secilmisMehsul.KateqoriyaId.HasValue)
                    cmbKateqoriya.SelectedValue = secilmisMehsul.KateqoriyaId.Value;
                else
                    cmbKateqoriya.SelectedIndex = -1;

                if (secilmisMehsul.BrendId.HasValue)
                    cmbBrend.SelectedValue = secilmisMehsul.BrendId.Value;
                else
                    cmbBrend.SelectedIndex = -1;

                if (secilmisMehsul.TedarukcuId.HasValue)
                    cmbTedarukcu.SelectedValue = secilmisMehsul.TedarukcuId.Value;
                else
                    cmbTedarukcu.SelectedIndex = -1;

                CedvelSecimiDeyisdi_Istek?.Invoke(this, EventArgs.Empty);
                btnElaveEt.Text = "Yeni Məhsul";
                btnKopyala.Enabled = true;
            }
            else
            {
                btnKopyala.Enabled = false;
            }
        }
        private void txtAxtar_TextChanged(object sender, EventArgs e) => Axtaris_Istek?.Invoke(this, EventArgs.Empty);
        #endregion
    }
}