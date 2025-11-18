# AzAgroPOS Teqdimat Formaları - Texniki Tövsiyyələr və Kod Nümunələri

## Müqəddimə

Bu sənəd backend implementasyon zəifliklərinə dair texniki çözümlər və kod nümunələri ehtiva edir.

---

## 1. QebzFormu - Çap Funksionallığı Implementasiyası

### Cari Vəziyyət (❌ PLACEHOLDER)
```csharp
private void btnCapEt_Click(object sender, EventArgs e)
{
    // Çap funksionallığını tətbiq edin
    MessageBox.Show("Çap funksionallığı hələ tətbiq edilməyib.",
                    "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
}
```

### Tövsiyyə Edən Çözüm

#### 1. Çap Servisi Interface-i
```csharp
// File: Servisler/ICapServisi.cs
namespace AzAgroPOS.Teqdimat.Servisler
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICapServisi
    {
        Task<bool> QebziCapEtAsync(string basliq, Dictionary<string, string> melumatlar);
        List<string> PrinterleriGetir();
        bool PrinterSinama(string printerAdi);
        void PrinterParametrleriSaxla(string printerAdi);
    }
}
```

#### 2. Çap Servisi İmplementasiyası
```csharp
// File: Servisler/CapServisi.cs
namespace AzAgroPOS.Teqdimat.Servisler
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class CapServisi : ICapServisi
    {
        private string _secilenPrinter;
        private Dictionary<string, string> _printData;

        public async Task<bool> QebziCapEtAsync(string basliq, Dictionary<string, string> melumatlar)
        {
            try
            {
                _printData = melumatlar;

                // Print dialog-unu göstərin
                PrintDialog printDialog = new PrintDialog();
                printDialog.PrinterSettings.PrinterName = _secilenPrinter ?? PrinterSettings.InstalledPrinters[0];

                if (printDialog.ShowDialog() != DialogResult.OK)
                    return false;

                PrintDocument printDocument = new PrintDocument();
                printDocument.PrinterSettings = printDialog.PrinterSettings;
                printDocument.PrintPage += (s, e) => PrintPageContent(s, e, basliq);

                await Task.Run(() => printDocument.Print());

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Çap edilərkən xəta: {ex.Message}", ex);
            }
        }

        private void PrintPageContent(object sender, PrintPageEventArgs e, string basliq)
        {
            Font titleFont = new Font("Arial", 14, FontStyle.Bold);
            Font contentFont = new Font("Arial", 10);
            Font labelFont = new Font("Arial", 10, FontStyle.Bold);

            int yPosition = e.MarginBounds.Top;

            // Başlıq
            e.Graphics.DrawString(basliq, titleFont, Brushes.Black,
                                 e.MarginBounds.Left, yPosition);
            yPosition += 30;

            // Məlumatlar
            foreach (var item in _printData)
            {
                string line = $"{item.Key}: {item.Value}";
                e.Graphics.DrawString(line, contentFont, Brushes.Black,
                                     e.MarginBounds.Left, yPosition);
                yPosition += 20;

                if (yPosition > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false;
        }

        public List<string> PrinterleriGetir()
        {
            return PrinterSettings.InstalledPrinters.Cast<string>().ToList();
        }

        public bool PrinterSinama(string printerAdi)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = printerAdi;
                return pd.PrinterSettings.IsValid;
            }
            catch
            {
                return false;
            }
        }

        public void PrinterParametrleriSaxla(string printerAdi)
        {
            _secilenPrinter = printerAdi;
            // Konfiqurasiyaya saxlayın
        }
    }
}
```

#### 3. QebzFormu-da Presenter Qurulması
```csharp
// Updated: QebzFormu.cs
namespace AzAgroPOS.Teqdimat
{
    using AzAgroPOS.Teqdimat.Servisler;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class QebzFormu : Form, IQebzView
    {
        private readonly QebzPresenter _presenter;

        public QebzFormu(ICapServisi capServisi)
        {
            InitializeComponent();
            _presenter = new QebzPresenter(this, capServisi);
        }

        // IQebzView Implementasiyası
        public event EventHandler CapEt_Istek;

        public string Basliq
        {
            get => lblBasliq.Text;
            set => lblBasliq.Text = value;
        }

        public Dictionary<string, string> Melumatlar
        {
            get
            {
                var melumatlar = new Dictionary<string, string>();
                // UI-dan məlumatları topla
                return melumatlar;
            }
        }

        public void MesajGoster(string mesaj, string basliq, bool xetadir)
        {
            MessageBoxIcon icon = xetadir ? MessageBoxIcon.Error : MessageBoxIcon.Information;
            MessageBox.Show(mesaj, basliq, MessageBoxButtons.OK, icon);
        }

        private void btnCapEt_Click(object sender, EventArgs e)
        {
            CapEt_Istek?.Invoke(this, EventArgs.Empty);
        }

        private void btnBagla_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
```

#### 4. QebzPresenter
```csharp
// File: Teqdimatcilar/QebzPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar
{
    using AzAgroPOS.Teqdimat.Interfeysler;
    using AzAgroPOS.Teqdimat.Servisler;
    using System;
    using System.Threading.Tasks;

    public class QebzPresenter
    {
        private readonly IQebzView _view;
        private readonly ICapServisi _capServisi;

        public QebzPresenter(IQebzView view, ICapServisi capServisi)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _capServisi = capServisi ?? throw new ArgumentNullException(nameof(capServisi));

            _view.CapEt_Istek += async (s, e) => await CapEtAsync();
        }

        private async Task CapEtAsync()
        {
            try
            {
                bool netice = await _capServisi.QebziCapEtAsync(_view.Basliq, _view.Melumatlar);

                if (netice)
                {
                    _view.MesajGoster("Qəbz uğurla çap edildi.", "Uğur", false);
                }
                else
                {
                    _view.MesajGoster("Çap ləğv edildi.", "Məlumat", false);
                }
            }
            catch (Exception ex)
            {
                _view.MesajGoster($"Çap xətası: {ex.Message}", "Xəta", true);
            }
        }
    }
}
```

#### 5. IQebzView Interface-i
```csharp
// File: Interfeysler/IQebzView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler
{
    using System;
    using System.Collections.Generic;

    public interface IQebzView
    {
        string Basliq { get; set; }
        Dictionary<string, string> Melumatlar { get; }

        event EventHandler CapEt_Istek;

        void MesajGoster(string mesaj, string basliq, bool xetadir);
    }
}
```

---

## 2. BonusIdareetmeFormu - Architecture Düzəltməsi

### Cari Problem
```csharp
public partial class BonusIdareetmeFormu : BazaForm  // ❌ IBonusIdareetmeView implement etmir
{
    private readonly MusteriManager _musteriManager;  // ❌ Direct manager usage
    // ❌ Presenter istifadə edilmir
}
```

### Düzəltilmiş Versiya

#### 1. Form Interface-i Tətbiq Etmə
```csharp
// File: BonusIdareetmeFormu.cs (DÜZƏLTILMIŞ)
namespace AzAgroPOS.Teqdimat
{
    using AzAgroPOS.Mentiq.DTOs;
    using AzAgroPOS.Mentiq.Idareciler;
    using AzAgroPOS.Teqdimat.Interfeysler;
    using AzAgroPOS.Teqdimat.Teqdimatcilar;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class BonusIdareetmeFormu : BazaForm, IBonusIdareetmeView
    {
        private readonly BonusIdareetmePresenter _presenter;

        public BonusIdareetmeFormu(MusteriManager musteriManager)
        {
            InitializeComponent();

            // Presenter-i initialize et
            _presenter = new BonusIdareetmePresenter(this, musteriManager);

            // Event subscriptions
            this.Load += (s, e) => FormYuklendi?.Invoke(s, e);
            cmbMusteri.SelectedIndexChanged += (s, e) => MusteriSecildi?.Invoke(s, e);
            btnBalElaveEt.Click += (s, e) => BalElaveEt_Istek?.Invoke(s, e);
            btnBalIstifadeEt.Click += (s, e) => BalIstifadeEt_Istek?.Invoke(s, e);
            btnBalLegvEt.Click += (s, e) => BalLegvEt_Istek?.Invoke(s, e);
            btnManualElaveEt.Click += (s, e) => ManualBalElaveEt_Istek?.Invoke(s, e);
            btnYenile.Click += (s, e) => Yenile_Istek?.Invoke(s, e);

            StilVerDataGridView(dgvButunBonuslar);
            StilVerDataGridView(dgvBonusTarixcesi);
        }

        #region IBonusIdareetmeView Implementation

        public int SecilenMusteriId
        {
            get => cmbMusteri.SelectedValue is int id ? id : 0;
        }

        public decimal BalMiqdari
        {
            get => numBalMiqdari.Value;
        }

        public string Aciklama
        {
            get => txtAciklama.Text;
        }

        public MusteriBonus? SecilenMusteriBonus { get; private set; }

        // Events
        public event EventHandler FormYuklendi;
        public event EventHandler MusteriSecildi;
        public event EventHandler BalElaveEt_Istek;
        public event EventHandler BalIstifadeEt_Istek;
        public event EventHandler BalLegvEt_Istek;
        public event EventHandler ManualBalElaveEt_Istek;
        public event EventHandler Yenile_Istek;

        // View Methods
        public void MusterileriGoster(List<MusteriDto> musteriler)
        {
            cmbMusteri.DataSource = null;
            cmbMusteri.DataSource = musteriler;
            cmbMusteri.DisplayMember = "TamAd";
            cmbMusteri.ValueMember = "Id";
        }

        public void ButunBonuslariGoster(List<MusteriBonus> bonuslar)
        {
            dgvButunBonuslar.DataSource = null;
            dgvButunBonuslar.DataSource = bonuslar;
        }

        public void BonusTarixcesiniGoster(List<BonusQeydi> qeydler)
        {
            dgvBonusTarixcesi.DataSource = null;
            dgvBonusTarixcesi.DataSource = qeydler;
        }

        public void MusteriBonusMelumatlariniGoster(MusteriBonus? bonus)
        {
            SecilenMusteriBonus = bonus;
            if (bonus != null)
            {
                lblToplamBalDeyer.Text = bonus.ToplamBal.ToString("N2");
                lblIstifadeBalDeyer.Text = bonus.IstifadeEdilmisBal.ToString("N2");
                lblMovcudBalDeyer.Text = bonus.MovcudBal.ToString("N2");
                lblSeviyye.Text = bonus.Seviyye.ToString();
            }
        }

        public void BonusMelumatlariniTemizle()
        {
            lblToplamBalDeyer.Text = "0.00";
            lblIstifadeBalDeyer.Text = "0.00";
            lblMovcudBalDeyer.Text = "0.00";
            lblSeviyye.Text = "-";
        }

        public void EmeliyyatSaheleriniTemizle()
        {
            numBalMiqdari.Value = 0;
            txtAciklama.Clear();
        }

        public void TablolariDuzenle()
        {
            // DataGrid formatting code
        }

        public void DuymeleriBloklama()
        {
            bool enabled = SecilenMusteriId > 0;
            btnBalElaveEt.Enabled = enabled;
            btnBalIstifadeEt.Enabled = enabled;
            btnBalLegvEt.Enabled = enabled;
            btnManualElaveEt.Enabled = enabled;
        }

        public void MesajGoster(string mesaj, string basliq,
                               MessageBoxButtons duymeler, MessageBoxIcon ikon)
        {
            MessageBox.Show(mesaj, basliq, duymeler, ikon);
        }

        #endregion
    }
}
```

---

## 3. KonfiqurasiyaFormu - Validasyon Framework

### Validasyon Interface-i
```csharp
// File: Konfiqurasiya/IKonfiqurasiyaValidator.cs
namespace AzAgroPOS.Teqdimat.Konfiqurasiya
{
    using System;
    using System.Collections.Generic;

    public interface IKonfiqurasiyaValidator
    {
        ValidationResult ValidateVoen(string voen);
        ValidationResult ValidateEdvOrani(decimal oran);
        ValidationResult ValidateEmail(string email);
        ValidationResult ValidateKonfigurasiyaDto(KonfiqurasiyaDto dto);
        bool ValidateAll(Dictionary<string, string> values, out List<string> errors);
    }

    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
    }
}
```

### Validasyon Implementasiyası
```csharp
// File: Konfiqurasiya/KonfiqurasiyaValidator.cs
namespace AzAgroPOS.Teqdimat.Konfiqurasiya
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class KonfiqurasiyaValidator : IKonfiqurasiyaValidator
    {
        public ValidationResult ValidateVoen(string voen)
        {
            if (string.IsNullOrWhiteSpace(voen))
                return new ValidationResult { IsValid = false, ErrorMessage = "VÖEN boş ola bilməz" };

            if (voen.Length != 10 || !voen.All(char.IsDigit))
                return new ValidationResult { IsValid = false, ErrorMessage = "VÖEN 10 rəqəmdən ibarət olmalıdır" };

            return new ValidationResult { IsValid = true };
        }

        public ValidationResult ValidateEdvOrani(decimal oran)
        {
            if (oran < 0 || oran > 100)
                return new ValidationResult { IsValid = false, ErrorMessage = "ƏDV oranı 0-100 arasında olmalıdır" };

            return new ValidationResult { IsValid = true };
        }

        public ValidationResult ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return new ValidationResult { IsValid = true }; // Optional field

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
                return new ValidationResult { IsValid = false, ErrorMessage = "Email formatı yanlışdır" };

            return new ValidationResult { IsValid = true };
        }

        public ValidationResult ValidateKonfigurasiyaDto(KonfiqurasiyaDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Acar))
                return new ValidationResult { IsValid = false, ErrorMessage = "Parametre adı boş ola bilməz" };

            if (string.IsNullOrWhiteSpace(dto.Deyer))
                return new ValidationResult { IsValid = false, ErrorMessage = "Parametre dəyəri boş ola bilməz" };

            return new ValidationResult { IsValid = true };
        }

        public bool ValidateAll(Dictionary<string, string> values, out List<string> errors)
        {
            errors = new List<string>();
            bool isValid = true;

            if (!string.IsNullOrWhiteSpace(values.GetValueOrDefault("Voen")))
            {
                var result = ValidateVoen(values["Voen"]);
                if (!result.IsValid)
                {
                    errors.Add(result.ErrorMessage);
                    isValid = false;
                }
            }

            if (decimal.TryParse(values.GetValueOrDefault("EdvOrani"), out decimal oran))
            {
                var result = ValidateEdvOrani(oran);
                if (!result.IsValid)
                {
                    errors.Add(result.ErrorMessage);
                    isValid = false;
                }
            }

            return isValid;
        }
    }
}
```

### Presenter-ə Validasyon İntegrasyonu
```csharp
// Updated: Teqdimatcilar/KonfiqurasiyaPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar
{
    using AzAgroPOS.Mentiq.Idareciler;
    using AzAgroPOS.Mentiq.Yardimcilar;
    using AzAgroPOS.Teqdimat.Interfeysler;
    using AzAgroPOS.Teqdimat.Konfiqurasiya;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class KonfiqurasiyaPresenter
    {
        private readonly IKonfiqurasiyaView _view;
        private readonly KonfiqurasiyaManager _konfiqurasiyaManager;
        private readonly IKonfiqurasiyaValidator _validator;

        public KonfiqurasiyaPresenter(IKonfiqurasiyaView view,
                                    KonfiqurasiyaManager konfiqurasiyaManager,
                                    IKonfiqurasiyaValidator validator = null)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _konfiqurasiyaManager = konfiqurasiyaManager ?? throw new ArgumentNullException(nameof(konfiqurasiyaManager));
            _validator = validator ?? new KonfiqurasiyaValidator();
        }

        public async Task SaxlaKonfiqurasiyaParametrleriniAsync(Dictionary<string, string> parametrler)
        {
            try
            {
                // Validasiya
                if (!_validator.ValidateAll(parametrler, out List<string> errors))
                {
                    string errorMessage = string.Join("\n", errors);
                    _view.MesajGoster($"Validasiya Xətası:\n{errorMessage}", "Xəta",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Saxlama
                foreach (var param in parametrler)
                {
                    var dto = new KonfiqurasiyaDto
                    {
                        Acar = param.Key,
                        Deyer = param.Value,
                        Qrup = GetQrupForAcar(param.Key)
                    };

                    await _konfiqurasiyaManager.KonfiqurasiyaElaveEtVəYaYenileAsync(dto);
                }

                _view.MesajGoster("Konfiqurasiya parametrləri uğurla saxlanıldı.", "Uğur",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                _view.FormuYenile();
            }
            catch (Exception ex)
            {
                Logger.XetaYaz(ex, "Konfiqurasiya parametrləri saxlanılarkən xəta");
                _view.MesajGoster($"Xəta: {ex.Message}", "Xəta",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetQrupForAcar(string acar)
        {
            if (acar.StartsWith("Sirket")) return "Şirkət Məlumatları";
            if (acar.StartsWith("Vergi")) return "Vergi Parametrləri";
            if (acar.StartsWith("Printer")) return "Printer Tənzimləmələri";
            if (acar.StartsWith("Davranis")) return "Proqram Davranışı";
            return "Digər";
        }
    }
}
```

---

## 4. MinimumStokMehsullariFormu - Detail Panel

### Detail Panel Component
```csharp
// File: MehsulDetailPanel.cs
namespace AzAgroPOS.Teqdimat
{
    using AzAgroPOS.Mentiq.DTOs;
    using System;
    using System.Windows.Forms;
    using System.Drawing;

    public partial class MehsulDetailPanel : UserControl
    {
        public event EventHandler MinimumStokDegisti;

        private MehsulDto _secilenMehsul;

        public MehsulDetailPanel()
        {
            InitializeComponent();
            SetupControls();
        }

        private void SetupControls()
        {
            // Label oluştur
            Label lblAd = new Label { Text = "Məhsul Adı:", Top = 10, Left = 10, Width = 150 };
            Label lblKodu = new Label { Text = "Stok Kodu:", Top = 40, Left = 10, Width = 150 };
            Label lblMovcud = new Label { Text = "Mövcud Say:", Top = 70, Left = 10, Width = 150 };
            Label lblMinimum = new Label { Text = "Minimum Stok:", Top = 100, Left = 10, Width = 150 };
            Label lblStatus = new Label { Text = "Status:", Top = 130, Left = 10, Width = 150 };

            // TextBox oluştur
            TextBox txtAd = new TextBox { Name = "txtAd", Top = 10, Left = 170, Width = 200, ReadOnly = true };
            TextBox txtKodu = new TextBox { Name = "txtKodu", Top = 40, Left = 170, Width = 200, ReadOnly = true };
            TextBox txtMovcud = new TextBox { Name = "txtMovcud", Top = 70, Left = 170, Width = 200, ReadOnly = true };
            NumericUpDown nudMinimum = new NumericUpDown { Name = "nudMinimum", Top = 100, Left = 170, Width = 200 };
            Label lblStatus2 = new Label { Name = "lblStatus", Top = 130, Left = 170, Width = 200 };

            // Button
            Button btnSaxla = new Button { Text = "Saxla", Top = 160, Left = 170, Width = 100 };
            btnSaxla.Click += BtnSaxla_Click;

            // Controls-u əlavə et
            Controls.Add(lblAd);
            Controls.Add(lblKodu);
            Controls.Add(lblMovcud);
            Controls.Add(lblMinimum);
            Controls.Add(lblStatus);
            Controls.Add(txtAd);
            Controls.Add(txtKodu);
            Controls.Add(txtMovcud);
            Controls.Add(nudMinimum);
            Controls.Add(lblStatus2);
            Controls.Add(btnSaxla);
        }

        public void MehsuluGoster(MehsulDto mehsul)
        {
            _secilenMehsul = mehsul;

            Controls["txtAd"].Text = mehsul.Ad;
            Controls["txtKodu"].Text = mehsul.StokKodu;
            Controls["txtMovcud"].Text = mehsul.MovcudSay.ToString();
            ((NumericUpDown)Controls["nudMinimum"]).Value = mehsul.MinimumStok;

            UpdateStatus(mehsul);
        }

        private void UpdateStatus(MehsulDto mehsul)
        {
            Label lblStatus = (Label)Controls["lblStatus"];

            if (mehsul.MovcudSay <= mehsul.MinimumStok)
            {
                lblStatus.Text = "KRİTİK";
                lblStatus.ForeColor = Color.Red;
                lblStatus.Font = new Font(lblStatus.Font, FontStyle.Bold);
            }
            else if (mehsul.MovcudSay <= mehsul.MinimumStok * 1.5m)
            {
                lblStatus.Text = "RISK";
                lblStatus.ForeColor = Color.Orange;
                lblStatus.Font = new Font(lblStatus.Font, FontStyle.Bold);
            }
            else
            {
                lblStatus.Text = "OK";
                lblStatus.ForeColor = Color.Green;
            }
        }

        private void BtnSaxla_Click(object sender, EventArgs e)
        {
            if (_secilenMehsul == null)
                return;

            _secilenMehsul.MinimumStok = (int)((NumericUpDown)Controls["nudMinimum"]).Value;
            MinimumStokDegisti?.Invoke(this, EventArgs.Empty);

            MessageBox.Show("Minimum stok uğurla güncəlləndi.", "Uğur",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public int GetMinimumStok()
        {
            return (int)((NumericUpDown)Controls["nudMinimum"]).Value;
        }

        public void TemizleDetaylar()
        {
            _secilenMehsul = null;
            Controls["txtAd"].Text = string.Empty;
            Controls["txtKodu"].Text = string.Empty;
            Controls["txtMovcud"].Text = string.Empty;
            ((NumericUpDown)Controls["nudMinimum"]).Value = 0;
            ((Label)Controls["lblStatus"]).Text = "-";
        }
    }
}
```

### Updated MinimumStokMehsullariFormu
```csharp
// Updated: MinimumStokMehsullariFormu.cs
public partial class MinimumStokMehsullariFormu : BazaForm, IMinimumStokMehsullariView
{
    private readonly MinimumStokMehsullariPresenter _presenter;
    private MehsulDetailPanel _detailPanel;

    public MinimumStokMehsullariFormu(MehsulMeneceri mehsulMeneceri)
    {
        InitializeComponent();
        _presenter = new MinimumStokMehsullariPresenter(this, mehsulMeneceri);

        // Detail panel-i əlavə et
        _detailPanel = new MehsulDetailPanel();
        _detailPanel.Dock = DockStyle.Right;
        _detailPanel.Width = 400;
        _detailPanel.MinimumStokDegisti += async (s, e) => await _presenter.MinimumStokYenileAsync();

        this.Controls.Add(_detailPanel);

        StilVerDataGridView(dgvMinimumStokMehsullari);
    }

    private void dgvMinimumStokMehsullari_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvMinimumStokMehsullari.CurrentRow?.DataBoundItem is MehsulDto mehsul)
        {
            _detailPanel.MehsuluGoster(mehsul);
        }
        else
        {
            _detailPanel.TemizleDetaylar();
        }
    }
}
```

---

## 5. ZHesabatArxivFormu - Eksport Funksionallığı

### Hesabat Eksport Servisi
```csharp
// File: Servisler/HesabatExportServisi.cs
namespace AzAgroPOS.Teqdimat.Servisler
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    public interface IHesabatExportServisi
    {
        Task<bool> ExportToPdfAsync(string content, string filePath);
        Task<bool> ExportToExcelAsync(string content, string filePath);
        Task<bool> ExportToTxtAsync(string content, string filePath);
        Task<bool> SendByEmailAsync(string content, string email);
    }

    public class HesabatExportServisi : IHesabatExportServisi
    {
        public async Task<bool> ExportToPdfAsync(string content, string filePath)
        {
            // iText yaxud DevExpress kimi kütüphana istifadə edin
            try
            {
                // PDF generation code
                await Task.Delay(100); // Placeholder
                File.WriteAllText(filePath + ".txt", content); // Temporary
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"PDF ixrac xətası: {ex.Message}", ex);
            }
        }

        public async Task<bool> ExportToExcelAsync(string content, string filePath)
        {
            // ClosedXML yaxud NPOI kimi kütüphana istifadə edin
            try
            {
                // Excel generation code
                await Task.Delay(100); // Placeholder
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Excel ixrac xətası: {ex.Message}", ex);
            }
        }

        public async Task<bool> ExportToTxtAsync(string content, string filePath)
        {
            try
            {
                await Task.Run(() => File.WriteAllText(filePath, content, Encoding.UTF8));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Txt ixrac xətası: {ex.Message}", ex);
            }
        }

        public async Task<bool> SendByEmailAsync(string content, string email)
        {
            try
            {
                // Email sending code
                await Task.Delay(100); // Placeholder
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Email göndərmə xətası: {ex.Message}", ex);
            }
        }
    }
}
```

### Updated ZHesabatArxivFormu
```csharp
// Updated: ZHesabatArxivFormu.cs
public partial class ZHesabatArxivFormu : BazaForm, IZHesabatArxivView
{
    private readonly ZHesabatArxivPresenter _presenter;
    private readonly IHesabatExportServisi _exportServisi;

    public ZHesabatArxivFormu(HesabatManager hesabatManager, IHesabatExportServisi exportServisi)
    {
        InitializeComponent();
        _exportServisi = exportServisi;
        _presenter = new ZHesabatArxivPresenter(this, hesabatManager);
    }

    private async void btnExportPdf_Click(object sender, EventArgs e)
    {
        try
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                DefaultExt = "pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                bool result = await _exportServisi.ExportToPdfAsync(
                    GetHesabatContent(), sfd.FileName);

                if (result)
                    MessageBox.Show("Hesabat uğurla PDF-ə ixrac edildi.", "Uğur",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ixrac xətası: {ex.Message}", "Xəta",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private string GetHesabatContent()
    {
        // Hesabat məlumatını string kimi qaytar
        return "Z-Hesabat Məlumatları...";
    }
}
```

---

## Qlobal Tövsiyyələr

### 1. Dependency Injection Qurulması
```csharp
// Program.cs yaxud Application.cs-də
public static void ConfigureServices(IServiceCollection services)
{
    // Managers
    services.AddScoped<MusteriManager>();
    services.AddScoped<HesabatManager>();
    services.AddScoped<AlisManager>();

    // Services
    services.AddScoped<ICapServisi, CapServisi>();
    services.AddScoped<IHesabatExportServisi, HesabatExportServisi>();

    // Validators
    services.AddScoped<IKonfiqurasiyaValidator, KonfiqurasiyaValidator>();

    // Presenters
    services.AddScoped<QebzPresenter>();
    services.AddScoped<BonusIdareetmePresenter>();
    services.AddScoped<KonfiqurasiyaPresenter>();

    // Forms
    services.AddScoped<QebzFormu>();
    services.AddScoped<BonusIdareetmeFormu>();
    services.AddScoped<KonfiqurasiyaFormu>();
}
```

### 2. Unit Test Nümunəsi
```csharp
// Tests/BonusIdareetmePresenterTests.cs
using Xunit;
using Moq;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;

public class BonusIdareetmePresenterTests
{
    private readonly Mock<IBonusIdareetmeView> _mockView;
    private readonly Mock<MusteriManager> _mockManager;
    private readonly BonusIdareetmePresenter _presenter;

    public BonusIdareetmePresenterTests()
    {
        _mockView = new Mock<IBonusIdareetmeView>();
        _mockManager = new Mock<MusteriManager>();
        _presenter = new BonusIdareetmePresenter(_mockView.Object, _mockManager.Object);
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenViewIsNull()
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() =>
            new BonusIdareetmePresenter(null, _mockManager.Object));
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenManagerIsNull()
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() =>
            new BonusIdareetmePresenter(_mockView.Object, null));
    }
}
```

---

## Xülasə

Bu tövsiyyələr AzAgroPOS formalarının backend implementasiyonunu gücləndirir və MVV pattern-ə daha yaxın hala gətirir.

**Əsas Fokus Nöqtələri:**
1. Presenter pattern-i tam tətbiq edin
2. Interface kontraktlarını düzgün yerinə yetirin
3. Validasyon framework-u quruvlatın
4. Dependency injection istifadə edin
5. Unit testləri əlavə edin
6. Eksport/Print funksionallığını reallaştırın

Hər forma üçün tasvir edilən həll üsulları layihənizin xüsusiyyətinə uyğun tərəfləndiriləbilir.
