using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using System.Data;

namespace AzAgroPOS.Teqdimat
{
    public partial class EhtiyatHissəsiFormu : Form, IEhtiyatHissəsiView
    {
        private readonly MehsulManager _mehsulManager;
        private readonly List<EhtiyatHissəsiDto> _ehtiyatHissələri;
        public List<EhtiyatHissəsiDto> EhtiyatHissələri => _ehtiyatHissələri;

        public EhtiyatHissəsiFormu(MehsulManager mehsulManager)
        {
            InitializeComponent();
            _mehsulManager = mehsulManager;
            _ehtiyatHissələri = new List<EhtiyatHissəsiDto>();
            StilVerDataGridView(dgvMehsullar);
            StilVerDataGridView(dgvSeçilmişMehsullar);
        }

        // IEhtiyatHissəsiView interface implementasiyası
        public string AxtarisMetni => txtAxtar.Text;

        public string Miqdar => txtMiqdar.Text;

        public MehsulDto SecilmisMehsul => dgvMehsullar.CurrentRow?.DataBoundItem as MehsulDto;

        // Hadisələr
        public event EventHandler AxtarIstek;
        public event EventHandler ElaveEtIstek;
        public event EventHandler SilIstek;
        public event EventHandler TamamIstek;
        public event EventHandler İmtinaIstek;

        private void StilVerDataGridView(DataGridView grid)
        {
            Yardimcilar.DataGridViewHelper.StilVerDataGridView(grid);
        }

        private void EhtiyatHissəsiFormu_Load(object sender, EventArgs e)
        {
            _ = YukleAsync();
        }

        private async Task YukleAsync()
        {
            try
            {
                await MehsullariYukle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Forma yüklənərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task MehsullariYukle()
        {
            var netice = await _mehsulManager.ButunMehsullariGetirAsync();
            if (netice.UgurluDur)
            {
                dgvMehsullar.DataSource = netice.Data;
                if (dgvMehsullar.Columns.Count > 0)
                {
                    dgvMehsullar.Columns["Id"].Visible = false;
                    dgvMehsullar.Columns["Ad"].HeaderText = "Məhsul Adı";
                    dgvMehsullar.Columns["StokKodu"].HeaderText = "Stok Kodu";
                    dgvMehsullar.Columns["AlisQiymeti"].HeaderText = "Alış Qiyməti";
                    dgvMehsullar.Columns["PerakendeSatisQiymeti"].HeaderText = "Pərakəndə Qiyməti";
                    dgvMehsullar.Columns["TopluSatisQiymeti"].HeaderText = "Toplu Qiymət";
                    dgvMehsullar.Columns["MovcudSay"].HeaderText = "Mövcud Say";
                    dgvMehsullar.Columns["MinimumStokSayi"].HeaderText = "Min. Stok";
                }
            }
        }

        private void txtAxtar_TextChanged(object sender, EventArgs e)
        {
            if (dgvMehsullar.DataSource is List<MehsulDto> mehsullar)
            {
                var axtarışMətni = txtAxtar.Text.ToLower();
                var filtrlenmisMehsullar = mehsullar.Where(m =>
                    m.Ad.ToLower().Contains(axtarışMətni) ||
                    m.StokKodu.ToLower().Contains(axtarışMətni)).ToList();

                dgvMehsullar.DataSource = filtrlenmisMehsullar;
            }
        }

        private void btnElaveEt_Click(object sender, EventArgs e)
        {
            if (dgvMehsullar.CurrentRow?.DataBoundItem is MehsulDto mehsul)
            {
                if (decimal.TryParse(txtMiqdar.Text, out decimal miqdar) && miqdar > 0)
                {
                    var ehtiyatHissəsi = new EhtiyatHissəsiDto
                    {
                        MehsulId = mehsul.Id,
                        MehsulAdi = mehsul.Ad,
                        Miqdar = miqdar,
                        Qiymet = mehsul.AlisQiymeti
                    };

                    _ehtiyatHissələri.Add(ehtiyatHissəsi);
                    SeçilmişMehsullariGoster();
                    txtMiqdar.Text = "1";
                }
                else
                {
                    MessageBox.Show("Zəhmət olmasa düzgün miqdar daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void SeçilmişMehsullariGoster()
        {
            dgvSeçilmişMehsullar.DataSource = null;
            dgvSeçilmişMehsullar.DataSource = _ehtiyatHissələri;

            if (dgvSeçilmişMehsullar.Columns.Count > 0)
            {
                dgvSeçilmişMehsullar.Columns["MehsulId"].Visible = false;
                dgvSeçilmişMehsullar.Columns["MehsulAdi"].HeaderText = "Məhsul Adı";
                dgvSeçilmişMehsullar.Columns["Miqdar"].HeaderText = "Miqdar";
                dgvSeçilmişMehsullar.Columns["Qiymet"].HeaderText = "Qiymət";
                dgvSeçilmişMehsullar.Columns["ÜmumiMəbləğ"].HeaderText = "Ümumi Məbləğ";
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvSeçilmişMehsullar.CurrentRow?.DataBoundItem is EhtiyatHissəsiDto ehtiyatHissəsi)
            {
                _ehtiyatHissələri.Remove(ehtiyatHissəsi);
                SeçilmişMehsullariGoster();
            }
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnİmtina_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // IEhtiyatHissəsiView interface implementasiyası
        public void MehsullariGoster(List<MehsulDto> mehsullar)
        {
            dgvMehsullar.DataSource = mehsullar;
            if (dgvMehsullar.Columns.Count > 0)
            {
                dgvMehsullar.Columns["Id"].Visible = false;
                dgvMehsullar.Columns["Ad"].HeaderText = "Məhsul Adı";
                dgvMehsullar.Columns["StokKodu"].HeaderText = "Stok Kodu";
                dgvMehsullar.Columns["AlisQiymeti"].HeaderText = "Alış Qiyməti";
                dgvMehsullar.Columns["PerakendeSatisQiymeti"].HeaderText = "Pərakəndə Qiyməti";
                dgvMehsullar.Columns["TopluSatisQiymeti"].HeaderText = "Toplu Qiymət";
                dgvMehsullar.Columns["MovcudSay"].HeaderText = "Mövcud Say";
                dgvMehsullar.Columns["MinimumStokSayi"].HeaderText = "Min. Stok";
            }
        }

        public void SeçilmişMehsullariGoster(List<EhtiyatHissəsiDto> ehtiyatHissələri)
        {
            dgvSeçilmişMehsullar.DataSource = null;
            dgvSeçilmişMehsullar.DataSource = ehtiyatHissələri;

            if (dgvSeçilmişMehsullar.Columns.Count > 0)
            {
                dgvSeçilmişMehsullar.Columns["MehsulId"].Visible = false;
                dgvSeçilmişMehsullar.Columns["MehsulAdi"].HeaderText = "Məhsul Adı";
                dgvSeçilmişMehsullar.Columns["Miqdar"].HeaderText = "Miqdar";
                dgvSeçilmişMehsullar.Columns["Qiymet"].HeaderText = "Qiymət";
                dgvSeçilmişMehsullar.Columns["ÜmumiMəbləğ"].HeaderText = "Ümumi Məbləğ";
            }
        }

        public void FormuTemizle()
        {
            txtAxtar.Text = string.Empty;
            txtMiqdar.Text = "1";
            dgvMehsullar.DataSource = null;
            dgvSeçilmişMehsullar.DataSource = null;
            ButunXetalariTemizle();
        }

        public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon)
        {
            return MessageBox.Show(mesaj, basliq, düymələr, ikon);
        }
    }
}