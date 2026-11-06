using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Teqdimat.Sabitler;
using AzAgroPOS.Teqdimat.Servisler;
using System.Globalization;

namespace AzAgroPOS.Teqdimat
{
    public partial class QebzFormu : Form
    {
        private readonly SatisManager _satisManager;
        private readonly KonfiqurasiyaManager _konfiqurasiyaManager;
        private readonly CapServisi _capServisi = new();
        private readonly TextBox _satisNomresi = new();
        private readonly TableLayoutPanel _qebzKart = new();
        private SatisQebzDto? _secilmisQebz;

        public QebzFormu(SatisManager satisManager, KonfiqurasiyaManager konfiqurasiyaManager)
        {
            InitializeComponent();
            _satisManager = satisManager;
            _konfiqurasiyaManager = konfiqurasiyaManager;
            Panel axtaris = new() { Dock = DockStyle.Top, Height = 48, Padding = new Padding(10, 8, 10, 8) };
            _satisNomresi.PlaceholderText = "Satış / qəbz nömrəsi";
            _satisNomresi.Dock = DockStyle.Fill;
            Button tap = new() { Text = "Axtar", Dock = DockStyle.Right, Width = 90 };
            tap.Click += async (_, _) => await QebziAxtarAsync();
            axtaris.Controls.Add(_satisNomresi);
            axtaris.Controls.Add(tap);
            Controls.Remove(lblBasliq);
            Controls.Remove(tblMelumatlar);
            Controls.Remove(panel1);
            _qebzKart.ColumnCount = 1;
            _qebzKart.RowCount = 4;
            _qebzKart.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            _qebzKart.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));
            _qebzKart.RowStyles.Add(new RowStyle(SizeType.Absolute, 52));
            _qebzKart.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            _qebzKart.RowStyles.Add(new RowStyle(SizeType.Absolute, 56));
            _qebzKart.BackColor = Color.White;
            _qebzKart.Controls.Add(lblBasliq, 0, 0);
            _qebzKart.Controls.Add(axtaris, 0, 1);
            _qebzKart.Controls.Add(tblMelumatlar, 0, 2);
            _qebzKart.Controls.Add(panel1, 0, 3);
            Controls.Add(_qebzKart);
            BackColor = Color.FromArgb(241, 246, 242);
            lblBasliq.BackColor = Color.FromArgb(40, 115, 55);
            panel1.BackColor = Color.White;
            panel1.Resize += (_, _) =>
            {
                btnBagla.Left = Math.Max(8, panel1.ClientSize.Width - btnBagla.Width - 12);
                btnCapEt.Left = Math.Max(8, btnBagla.Left - btnCapEt.Width - 8);
            };
            Resize += (_, _) => QebzKartiniYerlesdir();
            QebzKartiniYerlesdir();
            tblMelumatlar.AutoScroll = true;
            btnCapEt.Enabled = false;
        }

        private void QebzKartiniYerlesdir()
        {
            int width = Math.Min(680, Math.Max(320, ClientSize.Width - 32));
            int height = Math.Min(720, Math.Max(340, ClientSize.Height - 32));
            _qebzKart.SetBounds(Math.Max(0, (ClientSize.Width - width) / 2),
                Math.Max(0, (ClientSize.Height - height) / 2), width, height);
        }

        private async Task QebziAxtarAsync()
        {
            _secilmisQebz = null;
            btnCapEt.Enabled = false;
            EmeliyyatNeticesi<SatisQebzDto> netice = await _satisManager.SatisGetirAsync(_satisNomresi.Text);
            if (!netice.UgurluDur)
            {
                MessageBox.Show(netice.Mesaj, "Qəbz tapılmadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _secilmisQebz = netice.Data;
            Dictionary<string, string> melumatlar = new()
            {
                ["Satış №"] = _secilmisQebz.SatisId.ToString(),
                ["Tarix"] = _secilmisQebz.Tarix.ToString("dd.MM.yyyy HH:mm"),
                ["Kassir"] = _secilmisQebz.KassirAdi,
                ["Ödəniş"] = _secilmisQebz.OdenisMetodu.ToString()
            };
            for (int i = 0; i < _secilmisQebz.SatilanMehsullar.Count; i++)
            {
                SatisSebetiElementiDto mehsul = _secilmisQebz.SatilanMehsullar[i];
                melumatlar[$"{i + 1}. {mehsul.MehsulAdi}"] = $"{mehsul.Miqdar:N0} × {mehsul.VahidinQiymeti:N2} = {mehsul.UmumiMebleg:N2} AZN";
            }
            if (_secilmisQebz.SatilanMehsullar.Count == 0)
                melumatlar["Məhsullar"] = "Bu satışda məhsul sətirləri tapılmadı. Çap dayandırıldı.";
            melumatlar["Yekun"] = $"{_secilmisQebz.YekunMebleg ?? _secilmisQebz.CemiMebleg:N2} AZN";
            QebzMelumatlariniGoster("Satış qəbzi", melumatlar);
            btnCapEt.Enabled = _secilmisQebz.SatilanMehsullar.Count > 0;
        }

        public void QebzMelumatlariniGoster(string basliq, Dictionary<string, string> melumatlar)
        {
            lblBasliq.Text = basliq;

            // Mevcud satırları təmizləyirik
            tblMelumatlar.Controls.Clear();
            tblMelumatlar.RowStyles.Clear();
            tblMelumatlar.RowCount = melumatlar.Count;

            // Yeni məlumatları əlavə edirik
            int satir = 0;
            foreach (KeyValuePair<string, string> melumat in melumatlar)
            {
                tblMelumatlar.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));

                Label lblAcar = new();
                lblAcar.Text = melumat.Key + ":";
                lblAcar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
                lblAcar.Dock = DockStyle.Fill;
                lblAcar.TextAlign = ContentAlignment.MiddleLeft;
                tblMelumatlar.Controls.Add(lblAcar, 0, satir);

                Label lblDeyer = new();
                lblDeyer.Text = melumat.Value;
                lblDeyer.Font = new Font("Microsoft Sans Serif", 10F);
                lblDeyer.Dock = DockStyle.Fill;
                lblDeyer.TextAlign = ContentAlignment.MiddleLeft;
                tblMelumatlar.Controls.Add(lblDeyer, 1, satir);

                satir++;
            }
        }

        private async void btnCapEt_Click(object sender, EventArgs e)
        {
            if (_secilmisQebz == null) return;
            string sirket = await _konfiqurasiyaManager.GetirAsync(KonfiqurasiyaSabitleri.Acarlar.SirketAdi, KonfiqurasiyaSabitleri.VarsayilanDeyerler.SirketAdi);
            string unvan = await _konfiqurasiyaManager.GetirAsync(KonfiqurasiyaSabitleri.Acarlar.SirketUnvani);
            string voen = await _konfiqurasiyaManager.GetirAsync(KonfiqurasiyaSabitleri.Acarlar.SirketVoen);
            string edv = await _konfiqurasiyaManager.GetirAsync(KonfiqurasiyaSabitleri.Acarlar.VergiEdvDerecesi, "18");
            string printer = await _konfiqurasiyaManager.GetirAsync(KonfiqurasiyaSabitleri.Acarlar.PrinterQebz);
            _capServisi.MagazaMelumatlariTeyinEt(sirket, unvan, voen);
            if (decimal.TryParse(edv, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal derece))
                _capServisi.EdvDerecesiTeyinEt(derece);
            _capServisi.CekiCapEt(_secilmisQebz, printer);
        }

        private void btnBagla_Click(object sender, EventArgs e)
        {
            Close();
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
    }
}
