// Fayl: AzAgroPOS.Teqdimat/MehsulIdareetmeFormu.cs
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Varliglar;
using Microsoft.Extensions.DependencyInjection; // Required for GetRequiredService

namespace AzAgroPOS.Teqdimat
{
    public partial class MehsulIdareetmeFormu : BazaForm, IMehsulIdareetmeView
    {
        private readonly MehsulPresenter _presenter;
        private readonly IServiceProvider _serviceProvider;

        public MehsulIdareetmeFormu(MehsulManager mehsulManager, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _presenter = new MehsulPresenter(this, mehsulManager, serviceProvider);
            _serviceProvider = serviceProvider;
            StilVerDataGridView(dgvMehsullar);

            // Setup auto-complete for ComboBoxes
            SetupComboBoxAutoComplete();

            // Add conditional formatting for low stock products
            dgvMehsullar.CellFormatting += DgvMehsullar_CellFormatting;
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
        public void MehsulDuzelisEt(int mehsulId)
        {
            // Mehsul ID'sini forma üzerindeki alana yerleştir
            txtId.Text = mehsulId.ToString();

            // Seçili satırı güncelle
            if (dgvMehsullar.DataSource is List<MehsulDto> mehsullar)
            {
                var secilmisMehsul = mehsullar.FirstOrDefault(m => m.Id == mehsulId);
                if (secilmisMehsul != null)
                {
                    // Seçili satırı seç
                    foreach (DataGridViewRow row in dgvMehsullar.Rows)
                    {
                        if (row.DataBoundItem is MehsulDto mehsul && mehsul.Id == mehsulId)
                        {
                            dgvMehsullar.ClearSelection();
                            row.Selected = true;
                            dgvMehsullar.FirstDisplayedScrollingRowIndex = row.Index;
                            break;
                        }
                    }

                    // Form alanlarını doldur
                    txtAd.Text = secilmisMehsul.Ad;
                    txtStokKodu.Text = secilmisMehsul.StokKodu;
                    txtBarkod.Text = secilmisMehsul.Barkod;
                    txtPerakendeSatisQiymeti.Text = secilmisMehsul.PerakendeSatisQiymeti.ToString("F2");
                    txtTopdanSatisQiymeti.Text = secilmisMehsul.TopdanSatisQiymeti.ToString("F2");
                    txtTekEdedSatisQiymeti.Text = secilmisMehsul.TekEdedSatisQiymeti.ToString("F2");
                    txtAlisQiymeti.Text = secilmisMehsul.AlisQiymeti.ToString("F2");
                    txtMevcudSay.Text = secilmisMehsul.MovcudSay.ToString();
                    txtMinimumStok.Text = secilmisMehsul.MinimumStok.ToString();

                    // ComboBox seçimlerini ayarla
                    cmbOlcuVahidi.SelectedItem = secilmisMehsul.OlcuVahidi;

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

                    // Buton metnini güncelle
                    btnElaveEt.Text = "Yeni Məhsul";
                    btnKopyala.Enabled = true;
                }
            }
        }

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

                // Format currency columns
                dgvMehsullar.Columns["PerakendeSatisQiymetiStr"].DefaultCellStyle.Format = "c2";

                // Align numeric columns to the right
                dgvMehsullar.Columns["PerakendeSatisQiymetiStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMehsullar.Columns["MovcudSay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon)
        {
            return MessageBox.Show(mesaj, basliq, düymələr, ikon);
        }

        /// <summary>
        /// Shows a validation error on a control
        /// </summary>
        /// <param name="control">Control to show error on</param>
        /// <param name="message">Error message</param>
        public void XetaGoster(Control control, string message)
        {
            errorProvider1.SetError(control, message);
            errorProvider1.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(control, 2);
        }

        /// <summary>
        /// Clears validation error from a control
        /// </summary>
        /// <param name="control">Control to clear error from</param>
        public void XetaniTemizle(Control control)
        {
            errorProvider1.SetError(control, string.Empty);
        }

        /// <summary>
        /// Clears all validation errors
        /// </summary>
        public void ButunXetalariTemizle()
        {
            // Clear errors from all controls
            foreach (Control control in this.Controls)
            {
                ClearErrorsRecursive(control);
            }
        }

        /// <summary>
        /// Recursively clears errors from all controls
        /// </summary>
        /// <param name="control">Control to clear errors from</param>
        private void ClearErrorsRecursive(Control control)
        {
            errorProvider1.SetError(control, string.Empty);
            foreach (Control child in control.Controls)
            {
                ClearErrorsRecursive(child);
            }
        }
        #endregion

        #region Hadisə Ötürücüləri (Event Handlers)
        private void MehsulIdareetmeFormu_Load(object sender, EventArgs e)
        {
            FormYuklendi_Istek?.Invoke(this, EventArgs.Empty);
            SetupTooltips();
        }

        private void SetupTooltips()
        {
            // Add tooltips to form elements
            toolTip1.SetToolTip(txtAd, "Məhsulun tam adını daxil edin");
            toolTip1.SetToolTip(txtStokKodu, "Məhsulun unikal stok kodunu daxil edin və ya yaradın");
            toolTip1.SetToolTip(txtBarkod, "Məhsulun barkodunu daxil edin və ya yaradın");
            toolTip1.SetToolTip(txtAlisQiymeti, "Məhsulun alış qiymətini daxil edin");
            toolTip1.SetToolTip(txtPerakendeSatisQiymeti, "Pərakəndə satış qiymətini daxil edin");
            toolTip1.SetToolTip(txtTopdanSatisQiymeti, "Topdan satış qiymətini daxil edin");
            toolTip1.SetToolTip(txtTekEdedSatisQiymeti, "Tək ədəd satış qiymətini daxil edin");
            toolTip1.SetToolTip(txtMevcudSay, "Anbarda mövcud olan məhsul sayını daxil edin");
            toolTip1.SetToolTip(txtMinimumStok, "Minimum stok səviyyəsini daxil edin");
            toolTip1.SetToolTip(cmbOlcuVahidi, "Məhsulun ölçü vahidini seçin");
            toolTip1.SetToolTip(cmbKateqoriya, "Məhsulun kateqoriyasını seçin");
            toolTip1.SetToolTip(cmbBrend, "Məhsulun brendini seçin");
            toolTip1.SetToolTip(cmbTedarukcu, "Məhsulun tədarükçüsünü seçin");
            toolTip1.SetToolTip(btnStokKoduYarat, "Avtomatik stok kodu yaradın");
            toolTip1.SetToolTip(btnBarkodYarat, "Avtomatik barkod yaradın");
            toolTip1.SetToolTip(btnElaveEt, "Yeni məhsul əlavə edin");
            toolTip1.SetToolTip(btnYenile, "Məhsul məlumatlarını yeniləyin");
            toolTip1.SetToolTip(btnSil, "Seçilmiş məhsulu silin");
            toolTip1.SetToolTip(btnTemizle, "Formu təmizləyin");
            toolTip1.SetToolTip(btnKopyala, "Seçilmiş məhsulu kopyalayın");
            toolTip1.SetToolTip(txtAxtar, "Məhsullar arasında axtarış edin");
        }
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
        private void btnIxracEt_Click(object sender, EventArgs e)
        {
            Yardimcilar.ExportHelper.ShowExportDialog(dgvMehsullar, "mehsullar");
        }
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

        #region Auto-complete Setup
        private void SetupComboBoxAutoComplete()
        {
            // Setup auto-complete for supplier ComboBox
            cmbTedarukcu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbTedarukcu.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Setup auto-complete for category ComboBox
            cmbKateqoriya.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbKateqoriya.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Setup auto-complete for brand ComboBox
            cmbBrend.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbBrend.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Setup auto-complete for unit of measure ComboBox
            cmbOlcuVahidi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbOlcuVahidi.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        #endregion

        /// <summary>
        /// Conditional formatting for products grid - highlights products with low stock
        /// </summary>
        private void DgvMehsullar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMehsullar.Rows[e.RowIndex].DataBoundItem is MehsulDto mehsul)
            {
                // Highlight products with low stock (current quantity less than minimum stock)
                if (mehsul.MovcudSay < mehsul.MinimumStok)
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 235, 235); // Light red background
                    e.CellStyle.ForeColor = Color.FromArgb(183, 28, 28);   // Dark red text
                    e.CellStyle.Font = new Font(dgvMehsullar.Font, FontStyle.Bold);
                }
            }
        }

        #region Context Menu Event Handlers

        private void tsmiMehsulBarkodCapEt_Click(object sender, EventArgs e)
        {
            // Print barcode of selected product
            if (dgvMehsullar.CurrentRow?.DataBoundItem is MehsulDto mehsul)
            {
                try
                {
                    // TODO: Burada barkod çap etmə funksionallığını tətbiq etmək lazımdır
                    // Nümunə:
                    // using (var barkodCapiFormu = _serviceProvider.GetRequiredService<BarkodCapiFormu>())
                    // {
                    //     barkodCapiFormu.BarkodCapEt(mehsul.Barkod, mehsul.Ad, mehsul.PerakendeSatisQiymeti);
                    // }

                    MessageBox.Show($"'{mehsul.Ad}' məhsulunun barkodu çap edilmək üçün hazırdır.\n\nBarkod: {mehsul.Barkod}",
                        "Barkod Çapı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Barkod çap edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsmiMehsulDetallar_Click(object sender, EventArgs e)
        {
            // Show details of selected product
            if (dgvMehsullar.CurrentRow?.DataBoundItem is MehsulDto mehsul)
            {
                MessageBox.Show($"Məhsul Detalları:\n\nAd: {mehsul.Ad}\nBarkod: {mehsul.Barkod}\nStok Kodu: {mehsul.StokKodu}\nAlış Qiyməti: {mehsul.AlisQiymeti:N2} AZN\nPərakəndə Qiyməti: {mehsul.PerakendeSatisQiymeti:N2} AZN\nTopdan Qiyməti: {mehsul.TopdanSatisQiymeti:N2} AZN\nMövcud Say: {mehsul.MovcudSay}",
                    "Məhsul Detalları", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsmiMehsulRedakteEt_Click(object sender, EventArgs e)
        {
            // Edit selected product
            if (dgvMehsullar.CurrentRow?.DataBoundItem is MehsulDto mehsul)
            {
                try
                {
                    using (var mehsulFormu = _serviceProvider.GetRequiredService<MehsulIdareetmeFormu>())
                    {
                        mehsulFormu.MehsulDuzelisEt(mehsul.Id);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Məhsul redaktə edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void tsmiMehsulSil_Click(object sender, EventArgs e)
        {
            // Delete selected product
            if (dgvMehsullar.CurrentRow?.DataBoundItem is MehsulDto mehsul)
            {
                var result = MessageBox.Show($"{mehsul.Ad} məhsulunu silmək istədiyinizə əminsiniz?",
                    "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var _mehsulManager = _serviceProvider.GetRequiredService<MehsulManager>();
                        var silindi = await _mehsulManager.MehsulSilAsync(mehsul.Id);
                        if (silindi.UgurluDur)
                        {
                            MessageBox.Show("Məhsul uğurla silindi.", "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh products list after deletion
                            Axtaris_Istek?.Invoke(this, EventArgs.Empty);
                        }
                        else
                        {
                            MessageBox.Show($"Məhsul silinərkən xəta baş verdi: {silindi.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Məhsul silinərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tsmiAlisDetallar_Click(object sender, EventArgs e)
        {
            // Show details of selected purchase history item
            // Commented out temporarily due to compilation error - need to determine correct DTO type
            /*
            if (dgvAlisTarixcesi.CurrentRow?.DataBoundItem is AlisDto alis)
            {
                MessageBox.Show($"Alış Detalları:\n\nTəchizatçı: {alis.TedarukcuAdi}\nMəhsul: {alis.MehsulAdi}\nAlış Qiyməti: {alis.AlisQiymeti:N2} AZN\nMiqdar: {alis.Miqdar}\nTarix: {alis.AlisTarixi:dd.MM.yyyy HH:mm}",
                    "Alış Detalları", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            */

            // Temporary implementation
            MessageBox.Show("Alış detalları funksionallığı hazırlanır...", "Qeyd", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}