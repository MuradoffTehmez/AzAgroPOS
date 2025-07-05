using AzAgroPOS.Entities;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

namespace AzAgroPOS.PL.Printing
{
    public class ChequePrinterService
    {
        private readonly Satis _satisInfo;
        private readonly PrintDocument _printDocument;
        private Font _headerFont = new Font("Arial", 12, FontStyle.Bold);
        private Font _mainFont = new Font("Arial", 10, FontStyle.Regular);
        private Font _boldFont = new Font("Arial", 10, FontStyle.Bold);

        public ChequePrinterService(Satis satisInfo)
        {
            _satisInfo = satisInfo;
            _printDocument = new PrintDocument();
            _printDocument.PrintPage += PrintDocument_PrintPage;
        }

        public void Print()
        {
            // Windows-un standart çap dialoqunu göstəririk
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = _printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                _printDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            float yPos = 0;
            float leftMargin = 5;
            float topMargin = 5;
            float lineHeight = _mainFont.GetHeight(graphics);
            string line;

            // Şirkət məlumatları
            graphics.DrawString("AzAgroPOS", _headerFont, Brushes.Black, leftMargin, yPos += topMargin);
            graphics.DrawString("VÖEN: 1234567890", _mainFont, Brushes.Black, leftMargin, yPos += lineHeight + 5);

            // Ayırıcı xətt
            graphics.DrawString("------------------------------------------", _mainFont, Brushes.Black, leftMargin, yPos += lineHeight);

            // Çek məlumatları
            string chequeNumber = $"CHK-{_satisInfo.SatisTarixi:yyyyMMdd}-{_satisInfo.Id:D6}";
            graphics.DrawString($"Çek Nömrəsi: {chequeNumber}", _mainFont, Brushes.Black, leftMargin, yPos += lineHeight + 5);
            graphics.DrawString($"Tarix: {_satisInfo.SatisTarixi:dd.MM.yyyy HH:mm:ss}", _mainFont, Brushes.Black, leftMargin, yPos += lineHeight);
            graphics.DrawString($"Kassir: {_satisInfo.IstifadeciAdi}", _mainFont, Brushes.Black, leftMargin, yPos += lineHeight);
            if (!string.IsNullOrEmpty(_satisInfo.MusteriAdi))
            {
                graphics.DrawString($"Müştəri: {_satisInfo.MusteriAdi}", _mainFont, Brushes.Black, leftMargin, yPos += lineHeight);
            }

            // Ayırıcı xətt
            graphics.DrawString("------------------------------------------", _mainFont, Brushes.Black, leftMargin, yPos += lineHeight);

            // Məhsul siyahısının başlığı
            graphics.DrawString("Məhsul Adı".PadRight(25) + "Miqdar   Qiymət     Cəm", _boldFont, Brushes.Black, leftMargin, yPos += lineHeight + 5);
            yPos += lineHeight;

            // Məhsullar
            foreach (var item in _satisInfo.SatisMehsullari)
            {
                string productName = item.MehsulAdi.Length > 20 ? item.MehsulAdi.Substring(0, 20) : item.MehsulAdi;
                line = $"{productName.PadRight(22)} {item.Miqdar,5} {item.QiymetBirEdede,8:F2} {item.YekunMebleg,8:F2}";
                graphics.DrawString(line, _mainFont, Brushes.Black, leftMargin, yPos += lineHeight);
            }

            // Ayırıcı xətt
            graphics.DrawString("------------------------------------------", _mainFont, Brushes.Black, leftMargin, yPos += lineHeight);

            // Yekun Məbləğlər
            graphics.DrawString($"Endirim: {_satisInfo.EndirimMeblegi:F2} ₼", _mainFont, Brushes.Black, 150, yPos += lineHeight + 5);
            graphics.DrawString($"YEKUN MƏBLƏĞ: {_satisInfo.YekunMebleg:F2} ₼", _headerFont, Brushes.Black, 100, yPos += lineHeight + 5);

            // Barkod
            try
            {
                var barcodeWriter = new BarcodeWriter
                {
                    Format = BarcodeFormat.CODE_128,
                    Options = new EncodingOptions { Height = 50, Width = 250, PureBarcode = true }
                };
                var bitmap = barcodeWriter.Write(chequeNumber);
                graphics.DrawImage(bitmap, new Point((int)leftMargin + 20, (int)(yPos += lineHeight + 10)));
            }
            catch (Exception) { /* Barkod yaradıla bilməsə, xəta verməsin */ }
        }
    }
}