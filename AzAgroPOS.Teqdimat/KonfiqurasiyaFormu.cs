// AzAgroPOS.Teqdimat/KonfiqurasiyaFormu.cs
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Teqdimat.Yardimcilar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat
{
    /// <summary>
    /// Konfiqurasiya forması - IKonfiqurasiyaView interface-ini implement edir
    /// MVP pattern-in View hissəsi
    /// </summary>
    public partial class KonfiqurasiyaFormu : BazaForm, IKonfiqurasiyaView
    {
        private readonly KonfiqurasiyaPresenter _presenter;
        private bool _isDirty = false;
        private bool _isLoading = false;
        private bool _suppressEvents = false;

        #region Constructor

        public KonfiqurasiyaFormu(KonfiqurasiyaManager konfiqurasiyaManager)
        {
            InitializeComponent();

            // Presenter-i yaradırıq
            _presenter = new KonfiqurasiyaPresenter(this, konfiqurasiyaManager);

            // Event handler-ları quraşdırırıq
            WireUpEventHandlers();
        }

        #endregion

        #region Event Wiring

        private void WireUpEventHandlers()
        {
            // Form events
            this.Load += (s, e) => FormYuklendi?.Invoke(this, EventArgs.Empty);

            // Button events
            btnSaxla.Click += (s, e) => YaddaSaxlaClick?.Invoke(this, EventArgs.Empty);
            btnLegvEt.Click += (s, e) => LegvEtClick?.Invoke(this, EventArgs.Empty);
            btnQebzPrinterSec.Click += (s, e) => QebzPrinterSecClick?.Invoke(this, EventArgs.Empty);
            btnBarkodPrinterSec.Click += (s, e) => BarkodPrinterSecClick?.Invoke(this, EventArgs.Empty);
            btnLogoSec.Click += (s, e) => LogoSecClick?.Invoke(this, EventArgs.Empty);

            // Text change events
            txtSirketAdi.TextChanged += (s, e) => { if (!_suppressEvents) DeyerDeyisdi?.Invoke(this, EventArgs.Empty); };
            txtSirketUnvani.TextChanged += (s, e) => { if (!_suppressEvents) DeyerDeyisdi?.Invoke(this, EventArgs.Empty); };
            txtSirketVoen.TextChanged += (s, e) => { if (!_suppressEvents) DeyerDeyisdi?.Invoke(this, EventArgs.Empty); };
            txtSirketTelefon.TextChanged += (s, e) => { if (!_suppressEvents) DeyerDeyisdi?.Invoke(this, EventArgs.Empty); };
            txtSirketEmail.TextChanged += (s, e) => { if (!_suppressEvents) DeyerDeyisdi?.Invoke(this, EventArgs.Empty); };
            txtSirketVebSayt.TextChanged += (s, e) => { if (!_suppressEvents) DeyerDeyisdi?.Invoke(this, EventArgs.Empty); };
            txtYedeklemeSaati.TextChanged += (s, e) => { if (!_suppressEvents) DeyerDeyisdi?.Invoke(this, EventArgs.Empty); };
            txtTarixFormati.TextChanged += (s, e) => { if (!_suppressEvents) DeyerDeyisdi?.Invoke(this, EventArgs.Empty); };
            txtReqemFormati.TextChanged += (s, e) => { if (!_suppressEvents) DeyerDeyisdi?.Invoke(this, EventArgs.Empty); };

            // Numeric change events
            nudEdvDerecesi.ValueChanged += (s, e) => { if (!_suppressEvents) DeyerDeyisdi?.Invoke(this, EventArgs.Empty); };
            nudSessiyaTimeout.ValueChanged += (s, e) => { if (!_suppressEvents) DeyerDeyisdi?.Invoke(this, EventArgs.Empty); };

            // Checkbox change events
            chkQebzAvtoCap.CheckedChanged += (s, e) => { if (!_suppressEvents) DeyerDeyisdi?.Invoke(this, EventArgs.Empty); };
            chkAvtomatikYedekleme.CheckedChanged += (s, e) => { if (!_suppressEvents) DeyerDeyisdi?.Invoke(this, EventArgs.Empty); };

            // ComboBox change events
            cmbKagizOlcusu.SelectedIndexChanged += (s, e) => { if (!_suppressEvents) DeyerDeyisdi?.Invoke(this, EventArgs.Empty); };
            cmbDil.SelectedIndexChanged += (s, e) => { if (!_suppressEvents) DeyerDeyisdi?.Invoke(this, EventArgs.Empty); };
            cmbValyuta.SelectedIndexChanged += (s, e) => { if (!_suppressEvents) DeyerDeyisdi?.Invoke(this, EventArgs.Empty); };
            cmbTema.SelectedIndexChanged += (s, e) => { if (!_suppressEvents) DeyerDeyisdi?.Invoke(this, EventArgs.Empty); };
        }

        #endregion

        #region IKonfiqurasiyaView Properties - Şirkət Məlumatları

        public string SirketAdi
        {
            get => txtSirketAdi.Text;
            set => txtSirketAdi.Text = value;
        }

        public string SirketUnvani
        {
            get => txtSirketUnvani.Text;
            set => txtSirketUnvani.Text = value;
        }

        public string SirketVoen
        {
            get => txtSirketVoen.Text;
            set => txtSirketVoen.Text = value;
        }

        public string SirketTelefon
        {
            get => txtSirketTelefon.Text;
            set => txtSirketTelefon.Text = value;
        }

        public string SirketEmail
        {
            get => txtSirketEmail.Text;
            set => txtSirketEmail.Text = value;
        }

        public string SirketVebSayt
        {
            get => txtSirketVebSayt.Text;
            set => txtSirketVebSayt.Text = value;
        }

        public string SirketLogo { get; set; }

        #endregion

        #region IKonfiqurasiyaView Properties - Vergi

        public decimal EdvDerecesi
        {
            get => nudEdvDerecesi.Value;
            set => nudEdvDerecesi.Value = value;
        }

        #endregion

        #region IKonfiqurasiyaView Properties - Printer

        public string QebzPrinteri
        {
            get => txtQebzPrinteri.Text;
            set => txtQebzPrinteri.Text = value;
        }

        public string BarkodPrinteri
        {
            get => txtBarkodPrinteri.Text;
            set => txtBarkodPrinteri.Text = value;
        }

        public string PrinterKagizOlcusu
        {
            get => cmbKagizOlcusu.SelectedItem?.ToString() ?? "";
            set
            {
                var index = cmbKagizOlcusu.Items.IndexOf(value);
                if (index >= 0)
                    cmbKagizOlcusu.SelectedIndex = index;
            }
        }

        #endregion

        #region IKonfiqurasiyaView Properties - Davranış

        public bool QebzAvtoCap
        {
            get => chkQebzAvtoCap.Checked;
            set => chkQebzAvtoCap.Checked = value;
        }

        public bool AvtomatikYedekleme
        {
            get => chkAvtomatikYedekleme.Checked;
            set => chkAvtomatikYedekleme.Checked = value;
        }

        public string YedeklemeSaati
        {
            get => txtYedeklemeSaati.Text;
            set => txtYedeklemeSaati.Text = value;
        }

        #endregion

        #region IKonfiqurasiyaView Properties - Sistem

        public string SistemDil
        {
            get => cmbDil.SelectedValue?.ToString() ?? "";
            set
            {
                if (cmbDil.Items.Count > 0)
                {
                    cmbDil.SelectedValue = value;
                }
            }
        }

        public string SistemValyuta
        {
            get => cmbValyuta.SelectedItem?.ToString() ?? "";
            set
            {
                var index = cmbValyuta.Items.IndexOf(value);
                if (index >= 0)
                    cmbValyuta.SelectedIndex = index;
            }
        }

        public string SistemTarixFormati
        {
            get => txtTarixFormati.Text;
            set => txtTarixFormati.Text = value;
        }

        public string SistemReqemFormati
        {
            get => txtReqemFormati.Text;
            set => txtReqemFormati.Text = value;
        }

        public string SistemTema
        {
            get => cmbTema.SelectedItem?.ToString() ?? "";
            set
            {
                var index = cmbTema.Items.IndexOf(value);
                if (index >= 0)
                    cmbTema.SelectedIndex = index;
            }
        }

        public int SistemSessiyaTimeout
        {
            get => (int)nudSessiyaTimeout.Value;
            set => nudSessiyaTimeout.Value = value;
        }

        #endregion

        #region IKonfiqurasiyaView Properties - State

        public bool IsDirty
        {
            get => _isDirty;
            set => _isDirty = value;
        }

        public bool IsLoading => _isLoading;

        #endregion

        #region IKonfiqurasiyaView Methods - UI Control

        public void MesajGoster(string mesaj, string basliq, MessageBoxButtons duymeler, MessageBoxIcon ikon)
        {
            MessageBox.Show(mesaj, basliq, duymeler, ikon);
        }

        public void ValidasiyaXetalariGoster(string xetalar)
        {
            MessageBox.Show(xetalar, "Validasiya Xətaları", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void UgurMesajiGoster(string mesaj)
        {
            MessageBox.Show(mesaj, "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void XetaMesajiGoster(string mesaj)
        {
            MessageBox.Show(mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void XeberdarlikMesajiGoster(string mesaj)
        {
            MessageBox.Show(mesaj, "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public bool TesdiqSorusu(string mesaj)
        {
            var netice = MessageBox.Show(mesaj, "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return netice == DialogResult.Yes;
        }

        #endregion

        #region IKonfiqurasiyaView Methods - Loading State

        public void YuklemeGoster(string mesaj = "Yüklənir...")
        {
            _isLoading = true;
            _suppressEvents = true; // Event-ləri suppress et yükləmə zamanı
            base.YuklemeGoster();
        }

        public void YuklemeGizle()
        {
            _isLoading = false;
            _suppressEvents = false; // Event-ləri yenidən aktiv et
            base.YuklemeGizle();
        }

        #endregion

        #region IKonfiqurasiyaView Methods - Button State

        public void YaddaSaxlaDuymesiniBiraktir(bool aktiv)
        {
            btnSaxla.Enabled = aktiv;
        }

        public void LegvEtDuymesiniBiraktir(bool aktiv)
        {
            btnLegvEt.Enabled = aktiv;
        }

        public void DaxiletmeSaheleriniAktivlesdirme(bool aktiv)
        {
            // Şirkət tab
            txtSirketAdi.Enabled = aktiv;
            txtSirketUnvani.Enabled = aktiv;
            txtSirketVoen.Enabled = aktiv;
            txtSirketTelefon.Enabled = aktiv;
            txtSirketEmail.Enabled = aktiv;
            txtSirketVebSayt.Enabled = aktiv;
            btnLogoSec.Enabled = aktiv;

            // Vergi tab
            nudEdvDerecesi.Enabled = aktiv;

            // Printer tab
            btnQebzPrinterSec.Enabled = aktiv;
            btnBarkodPrinterSec.Enabled = aktiv;
            cmbKagizOlcusu.Enabled = aktiv;

            // Davranış tab
            chkQebzAvtoCap.Enabled = aktiv;
            chkAvtomatikYedekleme.Enabled = aktiv;
            txtYedeklemeSaati.Enabled = aktiv;

            // Sistem tab
            cmbDil.Enabled = aktiv;
            cmbValyuta.Enabled = aktiv;
            txtTarixFormati.Enabled = aktiv;
            txtReqemFormati.Enabled = aktiv;
            cmbTema.Enabled = aktiv;
            nudSessiyaTimeout.Enabled = aktiv;
        }

        #endregion

        #region IKonfiqurasiyaView Methods - Printer

        public string PrinterSecDialoquGoster(string hazirkiPrinter)
        {
            return PrinterHelper.PrinterSecDialoquGoster(hazirkiPrinter);
        }

        public bool PrinterTestCap(string printerAdi)
        {
            return PrinterHelper.TestSehifesiCap(printerAdi);
        }

        public List<string> QurasdirilanPrinterleriGetir()
        {
            return PrinterHelper.QurasdirilanPrinterleriGetir();
        }

        #endregion

        #region IKonfiqurasiyaView Methods - Logo

        public string LogoSecDialoquGoster()
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Şirkət Loqosunu Seçin";
                openFileDialog.Filter = "Şəkil Faylları (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
            }

            return null;
        }

        public void LogoGoster(string logoYolu)
        {
            if (string.IsNullOrWhiteSpace(logoYolu) || !File.Exists(logoYolu))
            {
                picLogo.Image = null;
                return;
            }

            try
            {
                // Əvvəlki şəkli təmizlə
                if (picLogo.Image != null)
                {
                    var oldImage = picLogo.Image;
                    picLogo.Image = null;
                    oldImage.Dispose();
                }

                // Yeni şəkli yüklə
                using (var stream = new FileStream(logoYolu, FileMode.Open, FileAccess.Read))
                {
                    picLogo.Image = Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                XetaMesajiGoster($"Logo yüklənərkən xəta: {ex.Message}");
            }
        }

        #endregion

        #region IKonfiqurasiyaView Methods - Data Refresh

        public void FormuYenile()
        {
            // Presenter vasitəsilə yenidən yüklə
            FormYuklendi?.Invoke(this, EventArgs.Empty);
        }

        public void FormuSifirla()
        {
            // Şirkət tab
            txtSirketAdi.Clear();
            txtSirketUnvani.Clear();
            txtSirketVoen.Clear();
            txtSirketTelefon.Clear();
            txtSirketEmail.Clear();
            txtSirketVebSayt.Clear();
            picLogo.Image = null;

            // Vergi tab
            nudEdvDerecesi.Value = 18;

            // Printer tab
            txtQebzPrinteri.Clear();
            txtBarkodPrinteri.Clear();
            if (cmbKagizOlcusu.Items.Count > 0)
                cmbKagizOlcusu.SelectedIndex = 0;

            // Davranış tab
            chkQebzAvtoCap.Checked = false;
            chkAvtomatikYedekleme.Checked = false;
            txtYedeklemeSaati.Text = "02:00";

            // Sistem tab
            if (cmbDil.Items.Count > 0)
                cmbDil.SelectedIndex = 0;
            if (cmbValyuta.Items.Count > 0)
                cmbValyuta.SelectedIndex = 0;
            txtTarixFormati.Text = "dd.MM.yyyy";
            txtReqemFormati.Text = "N2";
            if (cmbTema.Items.Count > 0)
                cmbTema.SelectedIndex = 0;
            nudSessiyaTimeout.Value = 30;

            IsDirty = false;
        }

        public void VarsayilanDeyerleriYukle()
        {
            FormuSifirla();
        }

        #endregion

        #region IKonfiqurasiyaView Methods - ComboBox Population

        public void DilComboBoxDoldur(Dictionary<string, string> diller, string secilmisDil)
        {
            cmbDil.Items.Clear();
            cmbDil.DisplayMember = "Value";
            cmbDil.ValueMember = "Key";

            foreach (var dil in diller)
            {
                cmbDil.Items.Add(new KeyValuePair<string, string>(dil.Key, dil.Value));
            }

            if (!string.IsNullOrEmpty(secilmisDil))
            {
                for (int i = 0; i < cmbDil.Items.Count; i++)
                {
                    var item = (KeyValuePair<string, string>)cmbDil.Items[i];
                    if (item.Key == secilmisDil)
                    {
                        cmbDil.SelectedIndex = i;
                        break;
                    }
                }
            }
            else if (cmbDil.Items.Count > 0)
            {
                cmbDil.SelectedIndex = 0;
            }
        }

        public void ValyutaComboBoxDoldur(List<string> valyutalar, string secilmisValyuta)
        {
            cmbValyuta.Items.Clear();

            foreach (var valyuta in valyutalar)
            {
                cmbValyuta.Items.Add(valyuta);
            }

            if (!string.IsNullOrEmpty(secilmisValyuta))
            {
                var index = cmbValyuta.Items.IndexOf(secilmisValyuta);
                if (index >= 0)
                    cmbValyuta.SelectedIndex = index;
            }
            else if (cmbValyuta.Items.Count > 0)
            {
                cmbValyuta.SelectedIndex = 0;
            }
        }

        public void KagizOlcusuComboBoxDoldur(List<string> olculer, string secilmisOlcu)
        {
            cmbKagizOlcusu.Items.Clear();

            foreach (var olcu in olculer)
            {
                cmbKagizOlcusu.Items.Add(olcu);
            }

            if (!string.IsNullOrEmpty(secilmisOlcu))
            {
                var index = cmbKagizOlcusu.Items.IndexOf(secilmisOlcu);
                if (index >= 0)
                    cmbKagizOlcusu.SelectedIndex = index;
            }
            else if (cmbKagizOlcusu.Items.Count > 0)
            {
                cmbKagizOlcusu.SelectedIndex = 0;
            }
        }

        public void TemaComboBoxDoldur(List<string> temalar, string secilmisTema)
        {
            cmbTema.Items.Clear();

            foreach (var tema in temalar)
            {
                cmbTema.Items.Add(tema);
            }

            if (!string.IsNullOrEmpty(secilmisTema))
            {
                var index = cmbTema.Items.IndexOf(secilmisTema);
                if (index >= 0)
                    cmbTema.SelectedIndex = index;
            }
            else if (cmbTema.Items.Count > 0)
            {
                cmbTema.SelectedIndex = 0;
            }
        }

        #endregion

        #region IKonfiqurasiyaView Events

        public event EventHandler YaddaSaxlaClick;
        public event EventHandler LegvEtClick;
        public event EventHandler QebzPrinterSecClick;
        public event EventHandler BarkodPrinterSecClick;
        public event EventHandler LogoSecClick;
        public event EventHandler DeyerDeyisdi;
        public event EventHandler FormYuklendi;

        #endregion
    }
}
