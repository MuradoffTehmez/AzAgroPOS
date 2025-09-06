using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat
{
    public partial class EhtiyatHissəsiFormu : Form
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

        private void StilVerDataGridView(DataGridView grid)
        {
            grid.BorderStyle = BorderStyle.None;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            grid.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(150, 190, 220);
            grid.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            grid.BackgroundColor = Color.White;

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private async void EhtiyatHissəsiFormu_Load(object sender, EventArgs e)
        {
            await MehsullariYukle();
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
    }
}