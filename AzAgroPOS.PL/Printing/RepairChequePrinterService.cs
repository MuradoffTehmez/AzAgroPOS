using AzAgroPOS.Entities;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = System.Drawing.Font;

namespace AzAgroPOS.PL.Printing
{
    public class RepairChequePrinterService
    {
        private readonly Temir _temirInfo;
        private readonly PrintDocument _printDocument;
        private Font _headerFont = new Font("Arial", 12, FontStyle.Bold);
        private Font _mainFont = new Font("Arial", 10, FontStyle.Regular);
        private Font _boldFont = new Font("Arial", 10, FontStyle.Bold);

        public RepairChequePrinterService(Temir temirInfo)
        {
            _temirInfo = temirInfo;
            _printDocument = new PrintDocument();
            _printDocument.PrintPage += PrintDocument_PrintPage;
        }

        public void Print()
        {
            PrintDialog printDialog = new PrintDialog { Document = _printDocument };
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                _printDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float yPos = 5;
            float leftMargin = 5;
            float lineHeight = _mainFont.GetHeight(g);

            // Başlıq
            g.DrawString("TƏMİR SİFARİŞİ QƏBZİ", _headerFont, Brushes.Black, leftMargin, yPos);
            yPos += lineHeight * 2;

            // Sifariş və Müştəri məlumatları
            string chequeNumber = $"TMR-{_temirInfo.QebulTarixi:yyyyMMdd}-{_temirInfo.Id:D6}";
            g.DrawString($"Sifariş Nömrəsi: {chequeNumber}", _mainFont, Brushes.Black, leftMargin, yPos += lineHeight);
            g.DrawString($"Qəbul Tarixi: {_temirInfo.QebulTarixi:dd.MM.yyyy HH:mm}", _mainFont, Brushes.Black, leftMargin, yPos += lineHeight);
            g.DrawString($"Müştəri: {_temirInfo.MusteriAdi}", _boldFont, Brushes.Black, leftMargin, yPos += lineHeight);
            yPos += lineHeight;

            // Cihaz məlumatları
            g.DrawString("Cihaz Məlumatları", _boldFont, Brushes.Black, leftMargin, yPos += lineHeight);
            g.DrawString($"Cihaz: {_temirInfo.CihazAdi}", _mainFont, Brushes.Black, leftMargin + 10, yPos += lineHeight);
            g.DrawString($"Marka/Model: {_temirInfo.Marka} {_temirInfo.Model}", _mainFont, Brushes.Black, leftMargin + 10, yPos += lineHeight);
            g.DrawString($"Problem: {_temirInfo.ProblemTesviri}", _mainFont, Brushes.Black, new RectangleF(leftMargin + 10, yPos += lineHeight, 250, 100));
            yPos += lineHeight * 3;

            // Ehtiyat hissələri (əgər varsa)
            if (_temirInfo.Hisseler.Count > 0)
            {
                g.DrawString("İstifadə Olunan Hissələr", _boldFont, Brushes.Black, leftMargin, yPos += lineHeight);
                yPos += lineHeight;
                foreach (var hisse in _temirInfo.Hisseler)
                {
                    g.DrawString($"- {hisse.MehsulAdi} (x{hisse.Miqdar})", _mainFont, Brushes.Black, leftMargin + 10, yPos += lineHeight);
                }
            }

            // İmza üçün yer
            yPos += lineHeight * 3;
            g.DrawString("Müştərinin imzası: ___________________", _mainFont, Brushes.Black, leftMargin, yPos += lineHeight);
        }
    }
}