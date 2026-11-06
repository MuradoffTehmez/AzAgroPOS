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
            Controls.Add(axtaris);
            Controls.SetChildIndex(axtaris, 1);
            tblMelumatlar.AutoScroll = true;
            btnCapEt.Enabled = false;
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
            melumatlar["Yekun"] = $"{_secilmisQebz.YekunMebleg ?? _secilmisQebz.CemiMebleg:N2} AZN";
            QebzMelumatlariniGoster("Satış qəbzi", melumatlar);
            btnCapEt.Enabled = true;
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
                tblMelumatlar.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));

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
