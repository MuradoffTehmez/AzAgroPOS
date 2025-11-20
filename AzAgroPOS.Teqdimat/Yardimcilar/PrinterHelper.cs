using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat.Yardimcilar
{
    /// <summary>
    /// Printer əməliyyatları üçün yardımçı sinif
    /// </summary>
    public static class PrinterHelper
    {
        /// <summary>
        /// Sistemdə quraşdırılmış bütün printerləri qaytarır
        /// </summary>
        public static List<string> QurasdirilanPrinterleriGetir()
        {
            var printerler = new List<string>();

            try
            {
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    printerler.Add(printer);
                }
            }
            catch (Exception)
            {
                // Printerlərə giriş mümkün deyil
            }

            return printerler;
        }

        /// <summary>
        /// Printer mövcuddurmu yoxlayır
        /// </summary>
        public static bool PrinterMovcuddurMu(string printerAdi)
        {
            if (string.IsNullOrWhiteSpace(printerAdi))
                return false;

            try
            {
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    if (printer.Equals(printerAdi, StringComparison.OrdinalIgnoreCase))
                        return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        /// <summary>
        /// Varsayılan printer-i qaytarır
        /// </summary>
        public static string VarsayilanPrinteriGetir()
        {
            try
            {
                var printDoc = new PrintDocument();
                return printDoc.PrinterSettings.PrinterName;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Printer seçmə dialoqu göstərir
        /// </summary>
        public static string PrinterSecDialoquGoster(string hazirkiPrinter = null)
        {
            using (var dialog = new PrinterSecDialog(hazirkiPrinter))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.SecilmisPrinter;
                }
            }

            return null;
        }

        /// <summary>
        /// Test səhifəsi çap edir
        /// </summary>
        public static bool TestSehifesiCap(string printerAdi)
        {
            if (!PrinterMovcuddurMu(printerAdi))
                return false;

            try
            {
                var printDoc = new PrintDocument();
                printDoc.PrinterSettings.PrinterName = printerAdi;
                printDoc.DocumentName = "Test Səhifəsi";

                printDoc.PrintPage += (sender, e) =>
                {
                    var font = new Font("Arial", 12);
                    var brush = Brushes.Black;
                    var yPos = 50;

                    e.Graphics.DrawString("=== AzAgroPOS Test Səhifəsi ===",
                        new Font("Arial", 16, FontStyle.Bold), brush, 50, yPos);
                    yPos += 40;

                    e.Graphics.DrawString($"Printer: {printerAdi}", font, brush, 50, yPos);
                    yPos += 30;

                    e.Graphics.DrawString($"Tarix: {DateTime.Now:dd.MM.yyyy HH:mm:ss}", font, brush, 50, yPos);
                    yPos += 30;

                    e.Graphics.DrawString("Status: Printer normal işləyir ✓",
                        new Font("Arial", 12, FontStyle.Bold), Brushes.Green, 50, yPos);
                    yPos += 50;

                    // Test mətn
                    e.Graphics.DrawString("Test mətn: AaBbCcŞşÜüƏəİıÖöĞğ 0123456789", font, brush, 50, yPos);
                    yPos += 30;

                    // Barkod simulyasiyası
                    e.Graphics.DrawString("||||  ||  ||||||  ||||  ||||",
                        new Font("Courier New", 14), brush, 50, yPos);
                    yPos += 30;

                    e.Graphics.DrawString("Barkod: 1234567890",
                        new Font("Arial", 10), brush, 50, yPos);
                };

                printDoc.Print();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    /// <summary>
    /// Printer seçmə dialoqu
    /// </summary>
    internal class PrinterSecDialog : Form
    {
        private ListBox lstPrinters;
        private Button btnSec;
        private Button btnLegvEt;
        private Button btnTest;
        private Label lblBasliq;

        public string SecilmisPrinter { get; private set; }

        public PrinterSecDialog(string hazirkiPrinter = null)
        {
            InitializeComponent();
            PrinterleriYukle();

            if (!string.IsNullOrWhiteSpace(hazirkiPrinter))
            {
                int index = lstPrinters.Items.IndexOf(hazirkiPrinter);
                if (index >= 0)
                {
                    lstPrinters.SelectedIndex = index;
                }
            }
        }

        private void InitializeComponent()
        {
            this.Text = "Printer Seçin";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Başlıq
            lblBasliq = new Label
            {
                Text = "Sistemdə quraşdırılmış printerlər:",
                Location = new Point(20, 20),
                Size = new Size(450, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            this.Controls.Add(lblBasliq);

            // Printer siyahısı
            lstPrinters = new ListBox
            {
                Location = new Point(20, 50),
                Size = new Size(450, 240),
                Font = new Font("Segoe UI", 10)
            };
            lstPrinters.DoubleClick += (s, e) => SecVeQapat();
            this.Controls.Add(lstPrinters);

            // Düymələr
            btnTest = new Button
            {
                Text = "Test Çap Et",
                Location = new Point(20, 310),
                Size = new Size(120, 35),
                Font = new Font("Segoe UI", 9)
            };
            btnTest.Click += BtnTest_Click;
            this.Controls.Add(btnTest);

            btnSec = new Button
            {
                Text = "Seç",
                Location = new Point(270, 310),
                Size = new Size(100, 35),
                Font = new Font("Segoe UI", 9)
            };
            btnSec.Click += (s, e) => SecVeQapat();
            this.Controls.Add(btnSec);

            btnLegvEt = new Button
            {
                Text = "Ləğv Et",
                Location = new Point(380, 310),
                Size = new Size(90, 35),
                Font = new Font("Segoe UI", 9)
            };
            btnLegvEt.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            this.Controls.Add(btnLegvEt);

            this.AcceptButton = btnSec;
            this.CancelButton = btnLegvEt;
        }

        private void PrinterleriYukle()
        {
            lstPrinters.Items.Clear();
            var printerler = PrinterHelper.QurasdirilanPrinterleriGetir();

            if (printerler.Count == 0)
            {
                lstPrinters.Items.Add("(Printer tapılmadı)");
                btnSec.Enabled = false;
                btnTest.Enabled = false;
            }
            else
            {
                foreach (var printer in printerler)
                {
                    lstPrinters.Items.Add(printer);
                }

                // Varsayılan printer-i seç
                var varsayilan = PrinterHelper.VarsayilanPrinteriGetir();
                if (!string.IsNullOrEmpty(varsayilan))
                {
                    int index = lstPrinters.Items.IndexOf(varsayilan);
                    if (index >= 0)
                    {
                        lstPrinters.SelectedIndex = index;
                    }
                }
                else if (lstPrinters.Items.Count > 0)
                {
                    lstPrinters.SelectedIndex = 0;
                }
            }
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            if (lstPrinters.SelectedItem == null)
            {
                MessageBox.Show("Zəhmət olmasa printer seçin", "Xəbərdarlıq",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var printerAdi = lstPrinters.SelectedItem.ToString();
            btnTest.Enabled = false;
            btnTest.Text = "Çap edilir...";

            try
            {
                var netice = PrinterHelper.TestSehifesiCap(printerAdi);

                if (netice)
                {
                    MessageBox.Show("Test səhifəsi uğurla göndərildi", "Uğurlu",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Test səhifəsi çap edilə bilmədi", "Xəta",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                btnTest.Enabled = true;
                btnTest.Text = "Test Çap Et";
            }
        }

        private void SecVeQapat()
        {
            if (lstPrinters.SelectedItem != null)
            {
                SecilmisPrinter = lstPrinters.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
