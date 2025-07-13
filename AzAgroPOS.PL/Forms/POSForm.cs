using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.BLL.Services;

namespace AzAgroPOS.PL.Forms
{
    public partial class POSForm : Form
    {
        private readonly MehsulService _mehsulService;
        private readonly SatisService _satisService;
        private List<Mehsul> _mehsullar;
        private List<SatisDetaliItem> _satisDetallari;
        private decimal _vergiOrani = 0.18m; // 18% vergi

        public POSForm()
        {
            InitializeComponent();
            _mehsulService = new MehsulService();
            _satisService = new SatisService();
            _satisDetallari = new List<SatisDetaliItem>();
            InitializeForm();
        }

        private void InitializeForm()
        {
            this.KeyPreview = true;
            this.KeyDown += POSForm_KeyDown;
            
            // Event handlers
            btnClose.Click += (s, e) => this.Close();
            btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            
            txtBarkod.KeyDown += TxtBarkod_KeyDown;
            btnBarkodOxu.Click += BtnBarkodOxu_Click;
            
            txtMehsulAxtaris.TextChanged += TxtMehsulAxtaris_TextChanged;
            lstMehsullar.DoubleClick += LstMehsullar_DoubleClick;
            
            txtEndirim.TextChanged += TxtEndirim_TextChanged;
            txtEndirim.Leave += TxtEndirim_Leave;
            
            btnSatisıTamamla.Click += BtnSatisiTamamla_Click;
            btnYeniSatis.Click += BtnYeniSatis_Click;
            btnQezbCap.Click += BtnQezbCap_Click;
            
            dgvSatisDetallari.CellContentClick += DgvSatisDetallari_CellContentClick;
            dgvSatisDetallari.CellValueChanged += DgvSatisDetallari_CellValueChanged;
            
            LoadMehsullar();
            YenileSatisHesablamalar();
            
            // Focus on barcode textbox
            txtBarkod.Focus();
        }

        private void POSForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    txtBarkod.Focus();
                    e.Handled = true;
                    break;
                case Keys.F2:
                    txtMehsulAxtaris.Focus();
                    e.Handled = true;
                    break;
                case Keys.F9:
                    BtnSatisiTamamla_Click(sender, e);
                    e.Handled = true;
                    break;
                case Keys.F12:
                    BtnYeniSatis_Click(sender, e);
                    e.Handled = true;
                    break;
                case Keys.Escape:
                    this.Close();
                    e.Handled = true;
                    break;
            }
        }

        private void LoadMehsullar()
        {
            try
            {
                _mehsullar = _mehsulService.GetAllActive();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsullar yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _mehsullar = new List<Mehsul>();
            }
        }

        private void TxtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnBarkodOxu_Click(sender, e);
                e.Handled = true;
            }
        }

        private void BtnBarkodOxu_Click(object sender, EventArgs e)
        {
            string barkod = txtBarkod.Text.Trim();
            if (string.IsNullOrEmpty(barkod))
            {
                SystemSounds.Beep.Play();
                return;
            }

            var mehsul = _mehsullar.FirstOrDefault(m => m.Barkod == barkod);
            if (mehsul == null)
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("Barkod tapılmadı!", "Məhsul Tapılmadı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBarkod.SelectAll();
                return;
            }

            MehsuluElavEt(mehsul);
            txtBarkod.Clear();
            txtBarkod.Focus();
        }

        private void TxtMehsulAxtaris_TextChanged(object sender, EventArgs e)
        {
            string axtarisMetni = txtMehsulAxtaris.Text.Trim().ToLower();
            
            if (string.IsNullOrEmpty(axtarisMetni))
            {
                lstMehsullar.Items.Clear();
                return;
            }

            var filteredMehsullar = _mehsullar
                .Where(m => m.Ad.ToLower().Contains(axtarisMetni) || 
                           m.Barkod.ToLower().Contains(axtarisMetni) ||
                           m.SKU.ToLower().Contains(axtarisMetni))
                .Take(10)
                .ToList();

            lstMehsullar.Items.Clear();
            foreach (var mehsul in filteredMehsullar)
            {
                lstMehsullar.Items.Add(new MehsulListItem(mehsul));
            }
        }

        private void LstMehsullar_DoubleClick(object sender, EventArgs e)
        {
            if (lstMehsullar.SelectedItem is MehsulListItem selectedItem)
            {
                MehsuluElavEt(selectedItem.Mehsul);
                txtMehsulAxtaris.Clear();
                lstMehsullar.Items.Clear();
                txtBarkod.Focus();
            }
        }

        private void MehsuluElavEt(Mehsul mehsul, decimal miqdar = 1)
        {
            if (mehsul.MovcudMiqdar < miqdar)
            {
                MessageBox.Show($"Kifayət qədər stok yoxdur! Mövcud: {mehsul.MovcudMiqdar}", 
                    "Stok Çatışmazlığı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var mevcudItem = _satisDetallari.FirstOrDefault(d => d.MehsulId == mehsul.Id);
            
            if (mevcudItem != null)
            {
                decimal yeniMiqdar = mevcudItem.Miqdar + miqdar;
                if (mehsul.MovcudMiqdar < yeniMiqdar)
                {
                    MessageBox.Show($"Kifayət qədər stok yoxdur! Mövcud: {mehsul.MovcudMiqdar}", 
                        "Stok Çatışmazlığı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                mevcudItem.Miqdar = yeniMiqdar;
            }
            else
            {
                _satisDetallari.Add(new SatisDetaliItem
                {
                    MehsulId = mehsul.Id,
                    Barkod = mehsul.Barkod,
                    MehsulAdi = mehsul.Ad,
                    Miqdar = miqdar,
                    VahidQiymeti = mehsul.SatisQiymeti
                });
            }

            YenileDataGridView();
            YenileSatisHesablamalar();
            SystemSounds.Beep.Play();
        }

        private void YenileDataGridView()
        {
            dgvSatisDetallari.Rows.Clear();
            
            foreach (var item in _satisDetallari)
            {
                dgvSatisDetallari.Rows.Add(
                    item.Barkod,
                    item.MehsulAdi,
                    item.Miqdar.ToString("F2"),
                    item.VahidQiymeti.ToString("F2") + " ₼",
                    item.CemMebleg.ToString("F2") + " ₼",
                    "Sil"
                );
            }
        }

        private void DgvSatisDetallari_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSatisDetallari.Columns["colSil"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Bu məhsulu silmək istədiyinizə əminsiniz?", "Təsdiq", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _satisDetallari.RemoveAt(e.RowIndex);
                    YenileDataGridView();
                    YenileSatisHesablamalar();
                }
            }
        }

        private void DgvSatisDetallari_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSatisDetallari.Columns["colMiqdar"].Index && e.RowIndex >= 0)
            {
                if (decimal.TryParse(dgvSatisDetallari.Rows[e.RowIndex].Cells["colMiqdar"].Value?.ToString(), 
                    out decimal yeniMiqdar) && yeniMiqdar > 0)
                {
                    var item = _satisDetallari[e.RowIndex];
                    var mehsul = _mehsullar.First(m => m.Id == item.MehsulId);
                    
                    if (mehsul.MovcudMiqdar >= yeniMiqdar)
                    {
                        item.Miqdar = yeniMiqdar;
                        YenileDataGridView();
                        YenileSatisHesablamalar();
                    }
                    else
                    {
                        MessageBox.Show($"Kifayət qədər stok yoxdur! Mövcud: {mehsul.MovcudMiqdar}", 
                            "Stok Çatışmazlığı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        YenileDataGridView();
                    }
                }
                else
                {
                    YenileDataGridView();
                }
            }
        }

        private void TxtEndirim_TextChanged(object sender, EventArgs e)
        {
            YenileSatisHesablamalar();
        }

        private void TxtEndirim_Leave(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtEndirim.Text, out decimal endirim) || endirim < 0)
            {
                txtEndirim.Text = "0.00";
            }
            else
            {
                txtEndirim.Text = endirim.ToString("F2");
            }
        }

        private void YenileSatisHesablamalar()
        {
            decimal umumiMebleg = _satisDetallari.Sum(item => item.CemMebleg);
            decimal endirimMeblegi = 0;
            
            if (decimal.TryParse(txtEndirim.Text, out decimal endirim))
            {
                endirimMeblegi = endirim;
            }

            decimal endirimdenSonra = umumiMebleg - endirimMeblegi;
            decimal vergiMeblegi = endirimdenSonra * _vergiOrani;
            decimal netMebleg = endirimdenSonra + vergiMeblegi;

            lblUmumiMeblegValue.Text = umumiMebleg.ToString("F2") + " ₼";
            lblVergiValue.Text = vergiMeblegi.ToString("F2") + " ₼";
            lblNetMeblegValue.Text = netMebleg.ToString("F2") + " ₼";

            btnSatisıTamamla.Enabled = _satisDetallari.Count > 0;
        }

        private void BtnSatisiTamamla_Click(object sender, EventArgs e)
        {
            if (_satisDetallari.Count == 0)
            {
                MessageBox.Show("Satış üçün məhsul əlavə edin!", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string odemeNovu = rbNagd.Checked ? "Nağd" : 
                                  rbKart.Checked ? "Kart" : "Nisyə";

                var satis = new Satis
                {
                    SatisNomresi = GenerateSatisNomresi(),
                    SatisTarixi = DateTime.Now,
                    UmumiMebleg = _satisDetallari.Sum(item => item.CemMebleg),
                    EndirimMeblegi = decimal.Parse(txtEndirim.Text),
                    VergiMeblegi = decimal.Parse(lblVergiValue.Text.Replace(" ₼", "")),
                    NetMebleg = decimal.Parse(lblNetMeblegValue.Text.Replace(" ₼", "")),
                    OdemeNovu = odemeNovu,
                    OdemeDetali = txtOdemeDetali.Text,
                    KassirId = 1, // TODO: Get from current user session
                    SatisDetallari = _satisDetallari.Select(item => new SatisDetali
                    {
                        MehsulId = item.MehsulId,
                        MehsulAdi = item.MehsulAdi,
                        MehsulBarkod = item.Barkod,
                        Miqdar = item.Miqdar,
                        VahidQiymeti = item.VahidQiymeti,
                        UmumiQiymet = item.CemMebleg,
                        NetQiymet = item.CemMebleg,
                        VahidAdi = "Ədəd"
                    }).ToList()
                };

                int satisId = _satisService.CreateSatis(satis);

                MessageBox.Show($"Satış uğurla tamamlandı!\nSatış nömrəsi: {satis.SatisNomresi}", 
                    "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Auto print receipt
                BtnQezbCap_Click(sender, e);
                
                BtnYeniSatis_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satış tamamlanarkən xəta baş verdi: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnYeniSatis_Click(object sender, EventArgs e)
        {
            _satisDetallari.Clear();
            YenileDataGridView();
            YenileSatisHesablamalar();
            txtEndirim.Text = "0.00";
            txtOdemeDetali.Clear();
            rbNagd.Checked = true;
            txtBarkod.Clear();
            txtMehsulAxtaris.Clear();
            lstMehsullar.Items.Clear();
            txtBarkod.Focus();
        }

        private void BtnQezbCap_Click(object sender, EventArgs e)
        {
            if (_satisDetallari.Count == 0)
            {
                MessageBox.Show("Çap üçün satış məlumatı yoxdur!", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var receiptService = new ReceiptPrintService();
                string receiptContent = GenerateReceiptContent();
                receiptService.PrintReceipt(receiptContent);
                
                toolStripStatusLabel.Text = "Qəbz uğurla çap edildi";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Qəbz çap edilərkən xəta: {ex.Message}", "Çap Xətası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateSatisNomresi()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private string GenerateReceiptContent()
        {
            var receipt = new System.Text.StringBuilder();
            receipt.AppendLine("================================");
            receipt.AppendLine("         AzAgro POS");
            receipt.AppendLine("================================");
            receipt.AppendLine($"Tarix: {DateTime.Now:dd.MM.yyyy HH:mm}");
            receipt.AppendLine($"Kassir: Admin"); // TODO: Get from session
            receipt.AppendLine("--------------------------------");
            
            foreach (var item in _satisDetallari)
            {
                receipt.AppendLine($"{item.MehsulAdi}");
                receipt.AppendLine($"  {item.Miqdar:F2} x {item.VahidQiymeti:F2} = {item.CemMebleg:F2} ₼");
            }
            
            receipt.AppendLine("--------------------------------");
            receipt.AppendLine($"Ümumi:     {lblUmumiMeblegValue.Text}");
            if (decimal.Parse(txtEndirim.Text) > 0)
                receipt.AppendLine($"Endirim:   -{txtEndirim.Text} ₼");
            receipt.AppendLine($"Vergi:     {lblVergiValue.Text}");
            receipt.AppendLine($"NET:       {lblNetMeblegValue.Text}");
            receipt.AppendLine("================================");
            receipt.AppendLine($"Ödəmə: {(rbNagd.Checked ? "Nağd" : rbKart.Checked ? "Kart" : "Nisyə")}");
            receipt.AppendLine("================================");
            receipt.AppendLine("    Təşəkkür edirik!");
            receipt.AppendLine();
            
            return receipt.ToString();
        }
    }

    public class SatisDetaliItem
    {
        public int MehsulId { get; set; }
        public string Barkod { get; set; }
        public string MehsulAdi { get; set; }
        public decimal Miqdar { get; set; }
        public decimal VahidQiymeti { get; set; }
        public decimal CemMebleg => Miqdar * VahidQiymeti;
    }

    public class MehsulListItem
    {
        public Mehsul Mehsul { get; set; }
        
        public MehsulListItem(Mehsul mehsul)
        {
            Mehsul = mehsul;
        }
        
        public override string ToString()
        {
            return $"{Mehsul.Ad} - {Mehsul.SatisQiymeti:F2} ₼ (Stok: {Mehsul.MovcudMiqdar})";
        }
    }
}