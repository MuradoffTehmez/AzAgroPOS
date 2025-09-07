using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Varliglar;
using MaterialSkin.Controls;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace AzAgroPOS.Teqdimat
{
    public partial class SatisFormu : BazaForm, ISatisView
    {
        private readonly SatisPresenter _presenter;
        private readonly IServiceProvider _serviceProvider;

        public SatisFormu(SatisPresenter satisPresenter, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _presenter = satisPresenter;
            _serviceProvider = serviceProvider;
            this.Load += (s, e) => FormYuklendiIstek?.Invoke(this, EventArgs.Empty);
            ConfigureDataGridViewStyles();
            AddCartActionButtons();

            StatusMesajiGostericisi.Initialize(toolStripStatusLabel1);
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
                dgvAxtarisNeticeleri.Columns["Ad"].HeaderText = "Məhsul Adı";
                dgvAxtarisNeticeleri.Columns["StokKodu"].HeaderText = "Stok Kodu";

                string[] gorunenler = { "Ad", "StokKodu" };
                foreach (DataGridViewColumn col in dgvAxtarisNeticeleri.Columns)
                {
                    if (!gorunenler.Contains(col.Name)) col.Visible = false;
                }

                dgvAxtarisNeticeleri.Columns["Ad"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgvAxtarisNeticeleri.Columns["StokKodu"].SortMode = DataGridViewColumnSortMode.Automatic;
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

                dgvSebet.Columns["VahidinQiymeti"].DefaultCellStyle.Format = "c2";
                dgvSebet.Columns["UmumiMebleg"].DefaultCellStyle.Format = "c2";

                dgvSebet.Columns["Miqdar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSebet.Columns["VahidinQiymeti"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSebet.Columns["UmumiMebleg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvSebet.Columns["MehsulAdi"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgvSebet.Columns["Miqdar"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgvSebet.Columns["VahidinQiymeti"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgvSebet.Columns["UmumiMebleg"].SortMode = DataGridViewColumnSortMode.Automatic;
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
            return MessageBox.Show(this, mesaj, basliq, düymələr, ikon);
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
            Console.WriteLine($"Müştəri ekranı yeniləndi: {mehsulAdi} - Qiymət: {qiymet} AZN - Miqdar: {miqdar}");
        }

        public void MehsulDuzelisEt(int mehsulId)
        {
            // Bu metod satis formasinda mehsul duzelis etmek ucun istifade olunmur
            // Ancaq compiler xetasi vermemesi ucun burada bos bir implementasiya var
        }

        #endregion

        #region Hadisə Ötürücüləri
        private async void txtAxtaris_TextChanged(object sender, EventArgs e) =>
            await AsyncIslemYardimcisi.IslemiIcraEt(this, async () =>
            {
                await Task.Run(() => MehsulAxtarIstek?.Invoke(this, EventArgs.Empty));
            });
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
            Yardimcilar.DataGridViewHelper.StilVerDataGridView(
                dgvAxtarisNeticeleri,
                Color.FromArgb(33, 150, 243),
                Color.FromArgb(187, 222, 251),
                Color.FromArgb(245, 245, 245)
            );

            Yardimcilar.DataGridViewHelper.StilVerDataGridView(
                dgvSebet,
                Color.FromArgb(76, 175, 80),
                Color.FromArgb(200, 230, 201),
                Color.FromArgb(245, 245, 245)
            );

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

            // Extract debt and credit limit from the display text
            // The format is: "Name (Borc: amount)"
            string displayText = cmb.GetItemText(item);
            var match = System.Text.RegularExpressions.Regex.Match(displayText, @"\((Borc|Debt): ([\d,\.]+)\)");
            if (match.Success)
            {
                if (decimal.TryParse(match.Groups[2].Value, out decimal debt))
                {
                    // Check if debt exceeds a reasonable threshold (e.g., 5000 AZN)
                    if (debt > 5000)
                    {
                        e.Graphics.DrawString(displayText, new Font(e.Font, FontStyle.Bold), Brushes.Red, e.Bounds);
                    }
                    else if (debt > 1000)
                    {
                        e.Graphics.DrawString(displayText, new Font(e.Font, FontStyle.Bold), Brushes.Orange, e.Bounds);
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
                MessageBox.Show($"Məhsul Detalları:\n\nAd: {mehsul.Ad}\nBarkod: {mehsul.Barkod}\nStok Kodu: {mehsul.StokKodu}\nAlış Qiyməti: {mehsul.AlisQiymeti:N2} AZN\nPərakəndə Qiyməti: {mehsul.PerakendeSatisQiymeti:N2} AZN\nTopdan Qiyməti: {mehsul.TopdanSatisQiymeti:N2} AZN",
                    "Məhsul Detalları", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show($"Məhsul redaktə edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsmiAxtarisSil_Click(object sender, EventArgs e)
        {
            // Delete selected product
            if (dgvAxtarisNeticeleri.CurrentRow?.DataBoundItem is MehsulDto mehsul)
            {
                var result = MessageBox.Show($"{mehsul.Ad} məhsulunu silmək istədiyinizə əminsiniz?",
                    "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var silindi = _presenter.MehsulSilAsync(mehsul.Id).Result;
                        if (silindi)
                        {
                            MessageBox.Show("Məhsul uğurla silindi.", "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh search results after deletion
                            MehsulAxtarIstek?.Invoke(this, EventArgs.Empty);
                        }
                        else
                        {
                            MessageBox.Show("Məhsul silinərkən xəta baş verdi.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Məhsul silinərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tsmiSebetDetallar_Click(object sender, EventArgs e)
        {
            // Show details of selected cart item
            if (dgvSebet.CurrentRow?.DataBoundItem is SatisSebetiElementiDto sebetElementi)
            {
                MessageBox.Show($"Səbət Elementi Detalları:\n\nMəhsul: {sebetElementi.MehsulAdi}\nMiqdar: {sebetElementi.Miqdar}\nVahid Qiyməti: {sebetElementi.VahidinQiymeti:N2} AZN\nÜmumi Məbləğ: {sebetElementi.UmumiMebleg:N2} AZN",
                    "Səbət Elementi Detalları", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsmiSebetRedakteEt_Click(object sender, EventArgs e)
        {
            // Edit quantity of selected cart item
            if (dgvSebet.CurrentRow?.DataBoundItem is SatisSebetiElementiDto sebetElementi)
            {
                // For simplicity, we'll just show a message here
                MessageBox.Show("Səbət elementinin miqdarını dəyişdirmək üçün miqdar sahəsində düzəliş edin.",
                    "İnfo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}