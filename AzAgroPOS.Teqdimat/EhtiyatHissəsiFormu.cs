using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Teqdimat.Interfeysler;
using System.Data;

namespace AzAgroPOS.Teqdimat
{
    public partial class EhtiyatHissəsiFormu : Form, IEhtiyatHissəsiView
    {
        private readonly MehsulManager _mehsulManager;

        public System.ComponentModel.BindingList<EhtiyatHissəsiDto> EhtiyatHissələri { get; }

        public EhtiyatHissəsiFormu(MehsulManager mehsulManager)
        {
            InitializeComponent();
            _mehsulManager = mehsulManager;
            EhtiyatHissələri = new System.ComponentModel.BindingList<EhtiyatHissəsiDto>();
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
            EmeliyyatNeticesi<IEnumerable<MehsulDto>> netice = await _mehsulManager.ButunMehsullariGetirAsync();
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
                string axtarışMətni = txtAxtar.Text.ToLower();
                List<MehsulDto> filtrlenmisMehsullar = mehsullar.Where(m =>
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
                    EhtiyatHissəsiDto ehtiyatHissəsi = new()
                    {
                        MehsulId = mehsul.Id,
                        MehsulAdi = mehsul.Ad,
                        Miqdar = miqdar,
                        Qiymet = mehsul.AlisQiymeti
                    };

                    EhtiyatHissələri.Add(ehtiyatHissəsi);
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
            foreach (Control control in Controls)
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
            if (dgvSeçilmişMehsullar.Columns.Count == 0)
            {
                dgvSeçilmişMehsullar.AutoGenerateColumns = false;
                dgvSeçilmişMehsullar.Columns.Add(new DataGridViewTextBoxColumn { Name = "MehsulId", DataPropertyName = "MehsulId", Visible = false });
                dgvSeçilmişMehsullar.Columns.Add(new DataGridViewTextBoxColumn { Name = "MehsulAdi", DataPropertyName = "MehsulAdi", HeaderText = "Məhsul Adı" });
                
                var qtyCol = new DataGridViewTextBoxColumn { Name = "Miqdar", DataPropertyName = "Miqdar", HeaderText = "Miqdar" };
                qtyCol.DefaultCellStyle.Format = "N2";
                dgvSeçilmişMehsullar.Columns.Add(qtyCol);
                
                var priceCol = new DataGridViewTextBoxColumn { Name = "Qiymet", DataPropertyName = "Qiymet", HeaderText = "Qiymət" };
                priceCol.DefaultCellStyle.Format = "N2";
                dgvSeçilmişMehsullar.Columns.Add(priceCol);
                
                var sumCol = new DataGridViewTextBoxColumn { Name = "UmumiMebleg", DataPropertyName = "UmumiMebleg", HeaderText = "Ümumi Məbləğ" };
                sumCol.DefaultCellStyle.Format = "N2";
                dgvSeçilmişMehsullar.Columns.Add(sumCol);
            }
            dgvSeçilmişMehsullar.DataSource = EhtiyatHissələri;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvSeçilmişMehsullar.CurrentRow?.DataBoundItem is EhtiyatHissəsiDto ehtiyatHissəsi)
            {
                EhtiyatHissələri.Remove(ehtiyatHissəsi);
            }
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnİmtina_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // IEhtiyatHissəsiView interface implementasiyası
        public void MehsullariGoster(List<MehsulDto> mehsullar)
        {
            if (dgvMehsullar.Columns.Count == 0)
            {
                dgvMehsullar.AutoGenerateColumns = false;
                dgvMehsullar.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
                dgvMehsullar.Columns.Add(new DataGridViewTextBoxColumn { Name = "Ad", DataPropertyName = "Ad", HeaderText = "Ad" });
                dgvMehsullar.Columns.Add(new DataGridViewTextBoxColumn { Name = "StokKodu", DataPropertyName = "StokKodu", HeaderText = "Stok Kodu" });
                dgvMehsullar.Columns.Add(new DataGridViewTextBoxColumn { Name = "Barkod", DataPropertyName = "Barkod", HeaderText = "Barkod" });
                
                var qtyCol = new DataGridViewTextBoxColumn { Name = "MovcudSay", DataPropertyName = "MovcudSay", HeaderText = "Say" };
                qtyCol.DefaultCellStyle.Format = "N2";
                dgvMehsullar.Columns.Add(qtyCol);
                
                var priceCol = new DataGridViewTextBoxColumn { Name = "PerakendeSatisQiymeti", DataPropertyName = "PerakendeSatisQiymeti", HeaderText = "Qiymət" };
                priceCol.DefaultCellStyle.Format = "N2";
                dgvMehsullar.Columns.Add(priceCol);
            }
            dgvMehsullar.DataSource = new System.ComponentModel.BindingList<MehsulDto>(mehsullar);
        }

        public void SeçilmişMehsullariGoster(List<EhtiyatHissəsiDto> ehtiyatHissələri)
        {
            if (dgvSeçilmişMehsullar.Columns.Count == 0)
            {
                dgvSeçilmişMehsullar.AutoGenerateColumns = false;
                dgvSeçilmişMehsullar.Columns.Add(new DataGridViewTextBoxColumn { Name = "MehsulId", DataPropertyName = "MehsulId", Visible = false });
                dgvSeçilmişMehsullar.Columns.Add(new DataGridViewTextBoxColumn { Name = "MehsulAdi", DataPropertyName = "MehsulAdi", HeaderText = "Məhsul Adı" });
                
                var qtyCol = new DataGridViewTextBoxColumn { Name = "Miqdar", DataPropertyName = "Miqdar", HeaderText = "Miqdar" };
                qtyCol.DefaultCellStyle.Format = "N2";
                dgvSeçilmişMehsullar.Columns.Add(qtyCol);
                
                var priceCol = new DataGridViewTextBoxColumn { Name = "Qiymet", DataPropertyName = "Qiymet", HeaderText = "Qiymət" };
                priceCol.DefaultCellStyle.Format = "N2";
                dgvSeçilmişMehsullar.Columns.Add(priceCol);
                
                var sumCol = new DataGridViewTextBoxColumn { Name = "UmumiMebleg", DataPropertyName = "UmumiMebleg", HeaderText = "Ümumi Məbləğ" };
                sumCol.DefaultCellStyle.Format = "N2";
                dgvSeçilmişMehsullar.Columns.Add(sumCol);
            }
            
            dgvSeçilmişMehsullar.DataSource = new System.ComponentModel.BindingList<EhtiyatHissəsiDto>(ehtiyatHissələri);
        }

        public void FormuTemizle()
        {
            txtAxtar.Text = string.Empty;
            txtMiqdar.Text = "1";
            if (dgvMehsullar.DataSource is System.ComponentModel.BindingList<MehsulDto> mList) mList.Clear();
            if (dgvSeçilmişMehsullar.DataSource is System.ComponentModel.BindingList<EhtiyatHissəsiDto> ehList) ehList.Clear();
            EhtiyatHissələri.Clear();
            ButunXetalariTemizle();
        }

        public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon)
        {
            return MessageBox.Show(mesaj, basliq, düymələr, ikon);
        }
    }
}