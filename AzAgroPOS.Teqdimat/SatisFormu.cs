using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Teqdimat.Xidmetler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Varliglar;
using MaterialSkin.Controls;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace AzAgroPOS.Teqdimat
{
    public partial class SatisFormu : BazaForm, ISatisView
    {
        private ISatisPresenter _presenter;
        private readonly IServiceProvider _serviceProvider;
        private readonly IDialogXidmeti _dialogXidmeti;

        public SatisFormu(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.KeyPreview = true; // Klaviatura hadisələrini forma səviyyəsində qəbul etmək üçün istifade olunur
            _serviceProvider = serviceProvider;
            _dialogXidmeti = new DialogXidmeti();
            this.Load += (s, e) => FormYuklendiIstek?.Invoke(this, EventArgs.Empty);
            this.KeyUp += SatisFormu_KeyUp; // Klaviatura hadisələrini idarə etmək üçün
            ConfigureDataGridViewStyles();
            AddCartActionButtons();
            ConfigureKeyboardShortcutHints();

            StatusMesajiGostericisi.Initialize(toolStripStatusLabel1);
        }

        /// <summary>
        /// Klaviatura qısayolları üçün tooltip-lər təyin edir
        /// </summary>
        private void ConfigureKeyboardShortcutHints()
        {
            toolTip1.SetToolTip(btnYeniMusteri, "Yeni müştəri əlavə et (F10 və ya Ctrl+N)");
            toolTip1.SetToolTip(txtAxtaris, "Məhsul axtarın (Ctrl+F axtarışa fokus verir)");
            toolTip1.SetToolTip(dgvSebet, "Məhsulu silmək üçün Delete və ya F8 düyməsini basın");
        }

        public void InitializePresenter(ISatisPresenter presenter)
        {
            _presenter = presenter;
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
        public event EventHandler OdemeIstek;
        public event EventHandler NisyeEtIstek;
        public event EventHandler TaxirEtIstek;
        public event EventHandler TemizleIstek;
        public event EventHandler SatisEtIstek;
        public event EventHandler YeniMusteriIstek;
        public event EventHandler BarkodCapIstek;

        public void SuretliSatisMehsullariniGoster(List<MehsulDto> mehsullar)
        {
            flpSuretliSatis.Controls.Clear();

            // Sürətli satış başlığı
            var lblBasliq = new Label
            {
                Text = "SÜRƏTLİ SATIŞ",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(97, 97, 97),
                AutoSize = false,
                Width = 380,
                Height = 32,
                TextAlign = ContentAlignment.MiddleLeft,
                Margin = new Padding(4, 8, 4, 8)
            };
            flpSuretliSatis.Controls.Add(lblBasliq);

            foreach (var mehsul in mehsullar)
            {
                var button = new MaterialButton
                {
                    Text = mehsul.Ad,
                    Tag = mehsul,
                    Width = 120,
                    Height = 60,
                    Margin = new Padding(4),
                    AutoSize = false,
                    Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined,
                    HighEmphasis = false
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

            // Endirim varsa, fərqli rəng və tooltip göstər
            if (endirim > 0)
            {
                lblUmumiMebleg.ForeColor = Color.FromArgb(230, 81, 0); // Orange - endirimli
                lblTotalTitle.Text = $"CƏMİ ÖDƏNİLƏCƏK (Endirim: {endirim:N2} AZN)";
            }
            else
            {
                lblUmumiMebleg.ForeColor = Color.FromArgb(46, 125, 50); // Green - normal
                lblTotalTitle.Text = "CƏMİ ÖDƏNİLƏCƏK";
            }

            toolTip1.SetToolTip(lblUmumiMebleg, $"Cəm: {umumiMebleg:N2} AZN\nEndirim: {endirim:N2} AZN\nYekun: {yekunMebleg:N2} AZN");
        }

        public void MusteriSiyahisiniGoster(List<MusteriDto> musteriler)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => MusteriSiyahisiniGoster(musteriler)));
                return;
            }

            var listDataSource = new List<object> { new { Id = 0, TamAd = "Şəxsi Satış (müştərisiz)" } };
            listDataSource.AddRange(musteriler.Select(m => new { m.Id, TamAd = $@"{m.TamAd} (Borc: {m.UmumiBorc:N2})" }).ToList());

            cmbMusteriler.DataSource = listDataSource;
            cmbMusteriler.DisplayMember = "TamAd";
            cmbMusteriler.ValueMember = "Id";

            // Setup autocomplete after data is loaded
            SetupCustomerComboBoxAutoComplete();

            // Add event handler for conditional formatting
            cmbMusteriler.DrawMode = DrawMode.OwnerDrawFixed;
            cmbMusteriler.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMusteriler.DrawItem += CmbMusteriler_DrawItem;
        }

        public void AxtarisNeticeleriniGoster(List<MehsulDto> mehsullar)
        {
            dgvAxtarisNeticeleri.DataSource = mehsullar;
            if (dgvAxtarisNeticeleri.Columns.Count > 0)
            {
                if (dgvAxtarisNeticeleri.Columns["Ad"] != null)
                {
                    dgvAxtarisNeticeleri.Columns["Ad"].HeaderText = "Məhsul Adı";
                    dgvAxtarisNeticeleri.Columns["Ad"].SortMode = DataGridViewColumnSortMode.Automatic;
                }
                if (dgvAxtarisNeticeleri.Columns["StokKodu"] != null)
                {
                    dgvAxtarisNeticeleri.Columns["StokKodu"].HeaderText = "Stok Kodu";
                    dgvAxtarisNeticeleri.Columns["StokKodu"].SortMode = DataGridViewColumnSortMode.Automatic;
                }

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
            // DataSource-u yenilə
            dgvSebet.DataSource = null;
            dgvSebet.DataSource = sebet;

            // Sütunlar avtomatik yaradıldıqdan sonra konfiqurasiya et
            if (dgvSebet.Columns.Count > 0)
            {
                ConfigureSebetColumns();
            }
        }

        /// <summary>
        /// Səbət DataGridView sütunlarını professional şəkildə konfiqurasiya edir
        /// </summary>
        private void ConfigureSebetColumns()
        {
            // Sütun adlarını Azərbaycan dilinə çevir
            if (dgvSebet.Columns.Contains("MehsulAdi"))
            {
                dgvSebet.Columns["MehsulAdi"].HeaderText = "Məhsul Adı";
                dgvSebet.Columns["MehsulAdi"].ReadOnly = true;
                dgvSebet.Columns["MehsulAdi"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgvSebet.Columns["MehsulAdi"].FillWeight = 35;
                dgvSebet.Columns["MehsulAdi"].DisplayIndex = 0;
            }

            if (dgvSebet.Columns.Contains("Miqdar"))
            {
                dgvSebet.Columns["Miqdar"].HeaderText = "Miqdar";
                dgvSebet.Columns["Miqdar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvSebet.Columns["Miqdar"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgvSebet.Columns["Miqdar"].FillWeight = 12;
                dgvSebet.Columns["Miqdar"].DisplayIndex = 1;
            }

            if (dgvSebet.Columns.Contains("VahidinQiymeti"))
            {
                dgvSebet.Columns["VahidinQiymeti"].HeaderText = "Qiymət";
                dgvSebet.Columns["VahidinQiymeti"].ReadOnly = true;
                dgvSebet.Columns["VahidinQiymeti"].DefaultCellStyle.Format = "N2";
                dgvSebet.Columns["VahidinQiymeti"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSebet.Columns["VahidinQiymeti"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgvSebet.Columns["VahidinQiymeti"].FillWeight = 15;
                dgvSebet.Columns["VahidinQiymeti"].DisplayIndex = 2;
            }

            if (dgvSebet.Columns.Contains("EndirimMeblegi"))
            {
                dgvSebet.Columns["EndirimMeblegi"].HeaderText = "Endirim";
                dgvSebet.Columns["EndirimMeblegi"].DefaultCellStyle.Format = "N2";
                dgvSebet.Columns["EndirimMeblegi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSebet.Columns["EndirimMeblegi"].FillWeight = 12;
                dgvSebet.Columns["EndirimMeblegi"].DisplayIndex = 3;
            }

            if (dgvSebet.Columns.Contains("UmumiMebleg"))
            {
                dgvSebet.Columns["UmumiMebleg"].HeaderText = "Cəm";
                dgvSebet.Columns["UmumiMebleg"].ReadOnly = true;
                dgvSebet.Columns["UmumiMebleg"].DefaultCellStyle.Format = "N2";
                dgvSebet.Columns["UmumiMebleg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSebet.Columns["UmumiMebleg"].DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                dgvSebet.Columns["UmumiMebleg"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgvSebet.Columns["UmumiMebleg"].FillWeight = 15;
                dgvSebet.Columns["UmumiMebleg"].DisplayIndex = 4;
            }

            if (dgvSebet.Columns.Contains("QiymetNövü"))
            {
                dgvSebet.Columns["QiymetNövü"].HeaderText = "Tip";
                dgvSebet.Columns["QiymetNövü"].ReadOnly = true;
                dgvSebet.Columns["QiymetNövü"].FillWeight = 10;
                dgvSebet.Columns["QiymetNövü"].DisplayIndex = 5;
            }

            // Gizli sütunlar
            string[] gizliSutunlar = { "MehsulId", "EndirimliQiymet", "EndirimFaizi" };
            foreach (var sutunAdi in gizliSutunlar)
            {
                if (dgvSebet.Columns.Contains(sutunAdi))
                    dgvSebet.Columns[sutunAdi].Visible = false;
            }

            // Artır/Azalt düymələrinin sırasını düzəlt
            if (dgvSebet.Columns.Contains("artir_col"))
            {
                dgvSebet.Columns["artir_col"].DisplayIndex = dgvSebet.Columns.Count - 2;
                dgvSebet.Columns["artir_col"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvSebet.Columns["artir_col"].Width = 45;
            }
            if (dgvSebet.Columns.Contains("azalt_col"))
            {
                dgvSebet.Columns["azalt_col"].DisplayIndex = dgvSebet.Columns.Count - 1;
                dgvSebet.Columns["azalt_col"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvSebet.Columns["azalt_col"].Width = 45;
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

        public void StatusMesajiGoster(string mesaj, StatusMesajiNovu nov)
        {
            switch (nov)
            {
                case StatusMesajiNovu.Ugurlu:
                    StatusMesajiGostericisi.UgurluMesajGoster(mesaj);
                    break;
                case StatusMesajiNovu.Xeta:
                    StatusMesajiGostericisi.XetaMesajiGoster(mesaj);
                    break;
                case StatusMesajiNovu.Melumat:
                    StatusMesajiGostericisi.MelumatMesajiGoster(mesaj);
                    break;
            }
        }

        public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon)
        {
            // Düymə tipinə və ikona görə uyğun dialog metodunu çağır
            if (düymələr == MessageBoxButtons.YesNo && ikon == MessageBoxIcon.Question)
            {
                return _dialogXidmeti.TesdiqSorus(mesaj, basliq) ? DialogResult.Yes : DialogResult.No;
            }
            else if (düymələr == MessageBoxButtons.YesNoCancel)
            {
                return _dialogXidmeti.SecimSorus(mesaj, basliq);
            }
            else
            {
                // MessageBoxIcon-a görə metod seç
                switch (ikon)
                {
                    case MessageBoxIcon.Information:
                        _dialogXidmeti.MelumatGoster(mesaj, basliq);
                        break;
                    case MessageBoxIcon.Error:
                        _dialogXidmeti.XetaGoster(mesaj, basliq);
                        break;
                    case MessageBoxIcon.Warning:
                        _dialogXidmeti.XeberdarligGoster(mesaj, basliq);
                        break;
                    default:
                        _dialogXidmeti.MelumatGoster(mesaj, basliq);
                        break;
                }
                return DialogResult.OK;
            }
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


        public void MusteriEkraniYenile(string mehsulAdi, decimal qiymet, decimal miqdar)
        {
            Console.WriteLine($@"Müştəri ekranı yeniləndi: {mehsulAdi} - Qiymət: {qiymet} AZN - Miqdar: {miqdar}");
        }

        /// <summary>
        /// Müştəri borcuna görə uyğun rəng adını qaytarır
        /// </summary>
        /// <param name="borc">Müştəri borcu</param>
        /// <returns>Rəng adı ("Red", "Orange" və ya "Black")</returns>
        public string GetMusteriBorcRengi(decimal borc)
        {
            if (borc > 5000)
                return "Red";
            else if (borc > 1000)
                return "Orange";
            else
                return "Black";
        }

        public async Task EmeliyyatIcraEtAsync(Func<Task> emeliyyat, string mesaj)
        {
            var gosterici = new YuklemeGostergeci(this);
            await gosterici.EmeliyyatIcraEtAsync(emeliyyat, mesaj);
        }

        #endregion

        #region Hadisə Ötürücüləri
        private void txtAxtaris_TextChanged(object sender, EventArgs e)
        {
            // Debounced axtarış - istifadəçi yazmağı dayandırdıqdan 300ms sonra axtarış başlayır
            AsyncIslemYardimcisi.DebouncedAxtaris("SatisFormu_MehsulAxtaris", async (cancellationToken) =>
            {
                // UI thread-də işləməliyik
                if (InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        MehsulAxtarIstek?.Invoke(this, EventArgs.Empty);
                    }));
                }
                else
                {
                    MehsulAxtarIstek?.Invoke(this, EventArgs.Empty);
                }
            });
        }

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
        private void btn5AZN_Click(object sender, EventArgs e) => SatisiTesdiqleIstek?.Invoke(this, OdenisMetodu.Nağd);
        private void btn10AZN_Click(object sender, EventArgs e) => SatisiTesdiqleIstek?.Invoke(this, OdenisMetodu.Nağd);
        private void btn20AZN_Click(object sender, EventArgs e) => SatisiTesdiqleIstek?.Invoke(this, OdenisMetodu.Nağd);
        private void btn50AZN_Click(object sender, EventArgs e) => SatisiTesdiqleIstek?.Invoke(this, OdenisMetodu.Nağd);
        private void btn100AZN_Click(object sender, EventArgs e) => SatisiTesdiqleIstek?.Invoke(this, OdenisMetodu.Nağd);
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
            using (var endirimFormu = new EndirimFormu(SecilmisSebetElementi))
            {
                if (endirimFormu.ShowDialog() == DialogResult.OK)
                {
                    IndirimIstek?.Invoke(this, endirimFormu.EndirimParametrləri);
                }
            }
        }
        private void btnIxracEt_Click(object sender, EventArgs e)
        {
            Yardimcilar.ExportHelper.ShowExportDialog(dgvSebet, "sebet");
        }
        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
            var musteriFormu = _serviceProvider.GetRequiredService<MusteriIdareetmeFormu>();
            var musteriManager = _serviceProvider.GetRequiredService<MusteriManager>();
            var musteriPresenter = new MusteriPresenter(musteriFormu, musteriManager);
            musteriFormu.InitializePresenter(musteriPresenter);

            if (musteriFormu.ShowDialog() == DialogResult.OK)
            {
                MusteriSiyahisiniYenileIstek?.Invoke(this, EventArgs.Empty);

                if (musteriFormu.SecilenMusteriId > 0)
                {
                    cmbMusteriler.SelectedValue = musteriFormu.SecilenMusteriId;
                }
            }
            else
            {
                MusteriSiyahisiniYenileIstek?.Invoke(this, EventArgs.Empty);
            }
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
            // Əgər TextBox-da yazı yazılırsa, bəzi qısayolları deaktiv et
            bool isTextBoxFocused = ActiveControl is TextBox || ActiveControl is ComboBox;

            switch (e.KeyCode)
            {
                case Keys.F1:
                    btnNagd.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F2:
                    btnKart.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F3:
                    btnNisye.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F4:
                    btnSatisiGozlet.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F5:
                    btnGozleyenSatislar.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F6:
                    btnIndirim.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F7:
                    btnSebeteElaveEt.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F8:
                    btnSebetdenSil.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F9:
                    btnSebetTemizle.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F10:
                    btnYeniMusteri.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.Delete:
                    // Delete açarı yalnız DataGridView-də işləyəcək
                    if (dgvSebet.Focused && !isTextBoxFocused)
                    {
                        btnSebetdenSil.PerformClick();
                        e.Handled = true;
                    }
                    break;
                case Keys.Escape:
                    // ESC açarı formu bağlamır, sadəcə axtarış mətnini təmizləyir
                    if (!isTextBoxFocused)
                    {
                        txtAxtaris.Clear();
                        txtAxtaris.Focus();
                        e.Handled = true;
                    }
                    break;
                case Keys.N:
                    // Ctrl+N: Yeni müştəri
                    if (e.Control)
                    {
                        btnYeniMusteri.PerformClick();
                        e.Handled = true;
                    }
                    break;
                case Keys.F:
                    // Ctrl+F: Axtarış sahəsinə fokus
                    if (e.Control)
                    {
                        txtAxtaris.Focus();
                        txtAxtaris.SelectAll();
                        e.Handled = true;
                    }
                    break;
            }
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

        #region Auto-complete Setup
        private void SetupCustomerComboBoxAutoComplete()
        {
            // Only setup autocomplete if we have items in the list
            if (cmbMusteriler.Items.Count > 0)
            {
                // For DropDownList style, we need to set AutoCompleteSource first, then AutoCompleteMode
                cmbMusteriler.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbMusteriler.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
        }
        #endregion

        #region UI Konfiqurasiyası
        private void ConfigureDataGridViewStyles()
        {
            // Axtarış nəticələri üçün mavi tema
            Yardimcilar.DataGridViewHelper.StilVerDataGridView(
                dgvAxtarisNeticeleri,
                Color.FromArgb(25, 118, 210),    // Primary Blue
                Color.FromArgb(227, 242, 253),   // Light Blue Selection
                Color.FromArgb(255, 255, 255)    // White Background
            );

            // Səbət üçün yaşıl tema
            Yardimcilar.DataGridViewHelper.StilVerDataGridView(
                dgvSebet,
                Color.FromArgb(46, 125, 50),     // Primary Green
                Color.FromArgb(232, 245, 233),   // Light Green Selection
                Color.FromArgb(255, 255, 255)    // White Background
            );

            // Zebra striping effekti üçün alternating row style
            dgvAxtarisNeticeleri.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            dgvSebet.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);

            // Add conditional formatting event handlers
            dgvAxtarisNeticeleri.CellFormatting += DgvAxtarisNeticeleri_CellFormatting;
            dgvSebet.CellFormatting += DgvSebet_CellFormatting;
        }

        /// <summary>
        /// Conditional formatting for search results grid - highlights products with low stock
        /// </summary>
        private void DgvAxtarisNeticeleri_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAxtarisNeticeleri.Rows[e.RowIndex].DataBoundItem is MehsulDto mehsul)
            {
                // Highlight products with low stock (current quantity less than minimum stock)
                if (mehsul.MovcudSay < mehsul.MinimumStok)
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 235, 235); // Light red background
                    e.CellStyle.ForeColor = Color.FromArgb(183, 28, 28);   // Dark red text
                    e.CellStyle.Font = new Font(dgvAxtarisNeticeleri.Font, FontStyle.Bold);
                }
            }
        }

        /// <summary>
        /// Conditional formatting for cart grid - can be extended for additional rules
        /// </summary>
        private void DgvSebet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Currently no special formatting for cart items
            // This method is added for future extensibility
        }

        /// <summary>
        /// Custom drawing for customer combobox to highlight customers with debt exceeding credit limit
        /// </summary>
        private void CmbMusteriler_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            ComboBox cmb = sender as ComboBox;
            var item = cmb.Items[e.Index];

            // Get the customer data
            var customerIdProp = item.GetType().GetProperty("Id");
            var customerId = (int)customerIdProp.GetValue(item);

            // Skip formatting for "Şəxsi Satış" option (Id = 0)
            if (customerId == 0)
            {
                e.Graphics.DrawString(cmb.GetItemText(item), e.Font, Brushes.Black, e.Bounds);
                e.DrawFocusRectangle();
                return;
            }

            // Extract debt from the display text
            // The format is: "Name (Borc: amount)"
            string displayText = cmb.GetItemText(item);
            var match = System.Text.RegularExpressions.Regex.Match(displayText, @"\((Borc|Debt): ([\d,\.]+)\)");
            if (match.Success)
            {
                if (decimal.TryParse(match.Groups[2].Value, out decimal debt))
                {
                    // Get color from presenter based on debt amount
                    string renk = _presenter.GetMusteriBorcRengi(debt);

                    switch (renk)
                    {
                        case "Red":
                            e.Graphics.DrawString(displayText, new Font(e.Font, FontStyle.Bold), Brushes.Red, e.Bounds);
                            break;
                        case "Orange":
                            e.Graphics.DrawString(displayText, new Font(e.Font, FontStyle.Bold), Brushes.Orange, e.Bounds);
                            break;
                        default:
                            e.Graphics.DrawString(displayText, e.Font, Brushes.Black, e.Bounds);
                            break;
                    }
                }
                else
                {
                    e.Graphics.DrawString(displayText, e.Font, Brushes.Black, e.Bounds);
                }
            }
            else
            {
                e.Graphics.DrawString(displayText, e.Font, Brushes.Black, e.Bounds);
            }

            e.DrawFocusRectangle();
        }

        #endregion

        #region Context Menu Event Handlers

        private void tsmiAxtarisDetallar_Click(object sender, EventArgs e)
        {
            // Show details of selected product
            if (dgvAxtarisNeticeleri.CurrentRow?.DataBoundItem is MehsulDto mehsul)
            {
                _dialogXidmeti.MelumatGoster($"Məhsul Detalları:\n\nAd: {mehsul.Ad}\nBarkod: {mehsul.Barkod}\nStok Kodu: {mehsul.StokKodu}\nAlış Qiyməti: {mehsul.AlisQiymeti:N2} AZN\nPərakəndə Qiyməti: {mehsul.PerakendeSatisQiymeti:N2} AZN\nTopdan Qiyməti: {mehsul.TopdanSatisQiymeti:N2} AZN",
                    "Məhsul Detalları");
            }
        }

        private void tsmiAxtarisRedakteEt_Click(object sender, EventArgs e)
        {
            // Edit selected product
            if (dgvAxtarisNeticeleri.CurrentRow?.DataBoundItem is MehsulDto mehsul)
            {
                try
                {
                    using (var mehsulFormu = _serviceProvider.GetRequiredService<MehsulIdareetmeFormu>())
                    {
                        mehsulFormu.MehsulDuzelisEt(mehsul.Id);
                        mehsulFormu.ShowDialog();

                        // Refresh search results after editing
                        MehsulAxtarIstek?.Invoke(this, EventArgs.Empty);
                    }
                }
                catch (Exception ex)
                {
                    _dialogXidmeti.XetaGoster($"Məhsul redaktə edilərkən xəta baş verdi: {ex.Message}", "Xəta");
                }
            }
        }

        private async void tsmiAxtarisSil_Click(object sender, EventArgs e)
        {
            // Delete selected product
            if (dgvAxtarisNeticeleri.CurrentRow?.DataBoundItem is MehsulDto mehsul)
            {
                var tesdiq = _dialogXidmeti.TesdiqSorus($"{mehsul.Ad} məhsulunu silmək istədiyinizə əminsiniz?",
                    "Təsdiq");

                if (tesdiq)
                {
                    try
                    {
                        var silindi = await _presenter.MehsulSilAsync(mehsul.Id);
                        if (silindi)
                        {
                            _dialogXidmeti.UgurGoster("Məhsul uğurla silindi.", "Uğur");

                            // Refresh search results after deletion
                            MehsulAxtarIstek?.Invoke(this, EventArgs.Empty);
                        }
                        else
                        {
                            _dialogXidmeti.XetaGoster("Məhsul silinərkən xəta baş verdi.", "Xəta");
                        }
                    }
                    catch (Exception ex)
                    {
                        _dialogXidmeti.XetaGoster($"Məhsul silinərkən xəta baş verdi: {ex.Message}", "Xəta");
                    }
                }
            }
        }

        private void tsmiSebetDetallar_Click(object sender, EventArgs e)
        {
            // Show details of selected cart item
            if (dgvSebet.CurrentRow?.DataBoundItem is SatisSebetiElementiDto sebetElementi)
            {
                _dialogXidmeti.MelumatGoster($"Səbət Elementi Detalları:\n\nMəhsul: {sebetElementi.MehsulAdi}\nMiqdar: {sebetElementi.Miqdar}\nVahid Qiyməti: {sebetElementi.VahidinQiymeti:N2} AZN\nÜmumi Məbləğ: {sebetElementi.UmumiMebleg:N2} AZN",
                    "Səbət Elementi Detalları");
            }
        }

        private void tsmiSebetRedakteEt_Click(object sender, EventArgs e)
        {
            // Edit quantity of selected cart item
            if (dgvSebet.CurrentRow?.DataBoundItem is SatisSebetiElementiDto sebetElementi)
            {
                // For simplicity, we'll just show a message here
                _dialogXidmeti.MelumatGoster("Səbət elementinin miqdarını dəyişdirmək üçün miqdar sahəsində düzəliş edin.",
                    "İnfo");
            }
        }

        private void tsmiSebetSil_Click(object sender, EventArgs e)
        {
            // Remove selected item from cart
            if (dgvSebet.CurrentRow?.DataBoundItem is SatisSebetiElementiDto)
            {
                SebetdenSilIstek?.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Klaviatura Qısayolları

        private void SatisFormu_KeyUp(object sender, KeyEventArgs e)
        {
            // F1 - Ödəniş ekranı
            if (e.KeyCode == Keys.F1)
            {
                OdemeIstek?.Invoke(this, EventArgs.Empty);
            }
            // F2 - Nisyə
            else if (e.KeyCode == Keys.F2)
            {
                NisyeEtIstek?.Invoke(this, EventArgs.Empty);
            }
            // F3 - Təxirə sal
            else if (e.KeyCode == Keys.F3)
            {
                TaxirEtIstek?.Invoke(this, EventArgs.Empty);
            }
            // F4 - Təmizlə
            else if (e.KeyCode == Keys.F4)
            {
                TemizleIstek?.Invoke(this, EventArgs.Empty);
            }
            // F5 - Axtarışa fokus
            else if (e.KeyCode == Keys.F5)
            {
                txtAxtaris.Focus();
            }
            // F6 - Miqdar sahəsinə fokus
            else if (e.KeyCode == Keys.F6)
            {
                txtMiqdar.Focus();
            }
            // F7 - Səbətə fokus
            else if (e.KeyCode == Keys.F7)
            {
                dgvSebet.Focus();
            }
            // F8 - Səbətdən sil
            else if (e.KeyCode == Keys.F8)
            {
                SebetdenSilIstek?.Invoke(this, EventArgs.Empty);
            }
            // Ctrl+N - Yeni müştəri
            else if (e.Control && e.KeyCode == Keys.N)
            {
                YeniMusteriIstek?.Invoke(this, EventArgs.Empty);
            }
            // Ctrl+S - Satış et
            else if (e.Control && e.KeyCode == Keys.S)
            {
                SatisEtIstek?.Invoke(this, EventArgs.Empty);
            }
            // Ctrl+F - Axtarışa fokus
            else if (e.Control && e.KeyCode == Keys.F)
            {
                txtAxtaris.Focus();
            }
            // Ctrl+P - Barkod çapı
            else if (e.Control && e.KeyCode == Keys.P)
            {
                BarkodCapIstek?.Invoke(this, EventArgs.Empty);
            }
            // Escape - Axtarış sahəsini təmizlə
            else if (e.KeyCode == Keys.Escape)
            {
                txtAxtaris.Clear();
                txtAxtaris.Focus();
            }
        }

        #endregion
    }
}