using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using Microsoft.Extensions.DependencyInjection;

namespace AzAgroPOS.Teqdimat
{
    public partial class MusteriIdareetmeFormu : BazaForm, IMusteriView
    {
        private MusteriPresenter _presenter;
        private readonly IServiceProvider _serviceProvider;
        public int SecilenMusteriId { get; private set; } = 0;

        public MusteriIdareetmeFormu(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            // Form yüklənəndə Presenter-ə xəbər veririk
            this.Load += (s, e) =>
            {
                FormYuklendi?.Invoke(this, EventArgs.Empty);
                SetupTooltips();
            };
            StilVerDataGridView(dgvMusteriler);

            // Add conditional formatting for customers with debt exceeding credit limit
            dgvMusteriler.CellFormatting += DgvMusteriler_CellFormatting;
        }

        public void InitializePresenter(MusteriPresenter presenter)
        {
            _presenter = presenter;
        }

        private void SetupTooltips()
        {
            // Add tooltips to form elements
            toolTip1.SetToolTip(txtTamAd, "Müştərinin tam adını daxil edin");
            toolTip1.SetToolTip(txtTelefon, "Müştərinin telefon nömrəsini daxil edin");
            toolTip1.SetToolTip(txtUnvan, "Müştərinin ünvanını daxil edin");
            toolTip1.SetToolTip(txtKreditLimiti, "Müştərinin kredit limitini daxil edin (0 = Limitsiz)");
            toolTip1.SetToolTip(txtAxtaris, "Müştərilər arasında axtarış edin");
            toolTip1.SetToolTip(btnYeni, "Yeni müştəri əlavə edin və ya formanı təmizləyin");
            toolTip1.SetToolTip(btnYaddaSaxla, "Müştəri məlumatlarını yadda saxlayın");
            toolTip1.SetToolTip(btnSil, "Seçilmiş müştəriyi silin");
        }

        #region IMusteriView Implementasiyası

        public int SecilmisMusteriId => dgvMusteriler.CurrentRow?.DataBoundItem is MusteriDto musteri ? musteri.Id : 0;

        private string _musteriId = "";
        public string MusteriId { get => _musteriId; set => _musteriId = value; }
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
        public event EventHandler Axtar_Istek;

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

                // Format currency columns
                dgvMusteriler.Columns["UmumiBorc"].DefaultCellStyle.Format = "N2";
                dgvMusteriler.Columns["KreditLimiti"].DefaultCellStyle.Format = "N2";

                // Align numeric columns to the right
                dgvMusteriler.Columns["UmumiBorc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMusteriler.Columns["KreditLimiti"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                // Allow sorting
                dgvMusteriler.Columns["TamAd"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgvMusteriler.Columns["TelefonNomresi"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgvMusteriler.Columns["UmumiBorc"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgvMusteriler.Columns["KreditLimiti"].SortMode = DataGridViewColumnSortMode.Automatic;
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

        #region Hadisə Ötürücüləri

        private void dgvMusteriler_SelectionChanged(object sender, EventArgs e)
        {
            MusteriSecildi?.Invoke(sender, e);

            // Update selected customer ID when selection changes
            if (dgvMusteriler.CurrentRow?.DataBoundItem is MusteriDto musteri)
            {
                SecilenMusteriId = musteri.Id;
            }
            else
            {
                SecilenMusteriId = 0;
            }
        }

        private void btnYeni_Click(object sender, EventArgs e) => YeniMusteriIstek?.Invoke(sender, e);
        private void btnYaddaSaxla_Click(object sender, EventArgs e) => YaddaSaxlaIstek?.Invoke(sender, e);
        private void btnSil_Click(object sender, EventArgs e) => SilIstek?.Invoke(sender, e);
        private void txtAxtaris_TextChanged(object sender, EventArgs e) => AxtarIstek?.Invoke(sender, e);
        private void btnIxracEt_Click(object sender, EventArgs e)
        {
            Yardimcilar.ExportHelper.ShowExportDialog(dgvMusteriler, "musteriler");
        }

        // Handle double-click to select customer and close form
        private void dgvMusteriler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMusteriler.CurrentRow?.DataBoundItem is MusteriDto musteri)
            {
                SecilenMusteriId = musteri.Id;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        #endregion

        /// <summary>
        /// Conditional formatting for customers grid - highlights customers with debt exceeding credit limit
        /// </summary>
        private void DgvMusteriler_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMusteriler.Rows[e.RowIndex].DataBoundItem is MusteriDto musteri)
            {
                // Highlight customers whose debt exceeds their credit limit
                if (musteri.UmumiBorc > musteri.KreditLimiti)
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 235, 235); // Light red background
                    e.CellStyle.ForeColor = Color.FromArgb(183, 28, 28);   // Dark red text
                    e.CellStyle.Font = new Font(dgvMusteriler.Font, FontStyle.Bold);
                }
                // Highlight customers whose debt is close to their credit limit (within 10%)
                else if (musteri.UmumiBorc > musteri.KreditLimiti * 0.9m)
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 248, 225); // Light orange background
                    e.CellStyle.ForeColor = Color.FromArgb(245, 124, 0);   // Orange text
                    e.CellStyle.Font = new Font(dgvMusteriler.Font, FontStyle.Bold);
                }
            }
        }

        #region Context Menu Event Handlers

        private void tsmiMusteriDetallar_Click(object sender, EventArgs e)
        {
            // Show details of selected customer
            if (dgvMusteriler.CurrentRow?.DataBoundItem is MusteriDto musteri)
            {
                MessageBox.Show($"Müştəri Detalları:\n\nAd Soyad: {musteri.TamAd}\nTelefon: {musteri.TelefonNomresi}\nÜnvan: {musteri.Unvan}\nCari Borc: {musteri.UmumiBorc:N2} AZN\nKredit Limiti: {musteri.KreditLimiti:N2} AZN",
                    "Müştəri Detalları", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsmiMusteriRedakteEt_Click(object sender, EventArgs e)
        {
            // Edit selected customer
            if (dgvMusteriler.CurrentRow?.DataBoundItem is MusteriDto musteri)
            {
                try
                {
                    // Populate form fields with customer data
                    MusteriId = musteri.Id.ToString();
                    txtTamAd.Text = musteri.TamAd;
                    txtTelefon.Text = musteri.TelefonNomresi;
                    txtUnvan.Text = musteri.Unvan;
                    txtKreditLimiti.Text = musteri.KreditLimiti.ToString("N2");

                    // Enable save button and disable new button
                    btnYeni.Enabled = false;
                    btnYaddaSaxla.Enabled = true;

                    txtTamAd.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Müştəri məlumatları yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsmiMusteriBarkodCapEt_Click(object sender, EventArgs e)
        {
            // Print barcode of selected customer
            if (dgvMusteriler.CurrentRow?.DataBoundItem is MusteriDto musteri)
            {
                try
                {
                    // Barkod çapı formasını açırıq
                    using (var barkodCapiFormu = _serviceProvider.GetRequiredService<BarkodCapiFormu>())
                    {
                        barkodCapiFormu.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Barkod çap edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void tsmiMusteriSil_Click(object sender, EventArgs e)
        {
            // Delete selected customer
            if (dgvMusteriler.CurrentRow?.DataBoundItem is MusteriDto musteri)
            {
                var result = MessageBox.Show($"{musteri.TamAd} müştərisini silmək istədiyinizə əminsiniz?",
                    "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var _musteriManager = _serviceProvider.GetRequiredService<MusteriManager>();
                        var silindi = await _musteriManager.MusteriSilAsync(musteri.Id);
                        if (silindi.UgurluDur)
                        {
                            MessageBox.Show("Müştəri uğurla silindi.", "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh customers list after deletion
                            Axtar_Istek?.Invoke(this, EventArgs.Empty);
                        }
                        else
                        {
                            MessageBox.Show($"Müştəri silinərkən xəta baş verdi: {silindi.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Müştəri silinərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion
    }
}