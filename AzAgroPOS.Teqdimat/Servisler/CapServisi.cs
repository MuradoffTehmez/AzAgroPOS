// Fayl: AzAgroPOS.Teqdimat/Servisler/CapServisi.cs
namespace AzAgroPOS.Teqdimat.Servisler;

using AzAgroPOS.Mentiq.DTOs;
using System.Drawing.Printing;

public class CapServisi
{
    private SatisQebzDto? _satisMelumatlari;

    public void SatisiCapEt(SatisQebzDto satisMelumatlari)
    {
        _satisMelumatlari = satisMelumatlari;

        PrintDocument printDocument = new PrintDocument();
        PrintDialog printDialog = new PrintDialog { Document = printDocument };

        printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

        if (printDialog.ShowDialog() == DialogResult.OK)
        {
            printDocument.PrinterSettings = printDialog.PrinterSettings;
            try
            {
                printDocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Çap zamanı xəta baş verdi: {ex.Message}", "Çap Xətası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
    {
        if (_satisMelumatlari == null || e.Graphics == null) return;

        Graphics g = e.Graphics;
        Font basliqFontu = new Font("Courier New", 10, FontStyle.Bold);
        Font normalFont = new Font("Courier New", 9, FontStyle.Regular);
        Font kicikFont = new Font("Courier New", 8, FontStyle.Italic);

        float yPos = e.MarginBounds.Top;
        float solMesafe = e.MarginBounds.Left;
        float qebzEni = e.MarginBounds.Width;

        StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center };
        StringFormat rightFormat = new StringFormat { Alignment = StringAlignment.Far };

        // --- Şirkət Məlumatları ---
        string sirketAdi = "AzAgroPOS Market";
        g.DrawString(sirketAdi, basliqFontu, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, basliqFontu.GetHeight()), centerFormat);
        yPos += basliqFontu.GetHeight();

        string unvan = "Bakı şəh., Nizami küç. 123";
        g.DrawString(unvan, kicikFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, kicikFont.GetHeight()), centerFormat);
        yPos += kicikFont.GetHeight();

        string voen = "VÖEN: 1234567890";
        g.DrawString(voen, kicikFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, kicikFont.GetHeight()), centerFormat);
        yPos += kicikFont.GetHeight() + 10;

        // --- Qəbz Məlumatları ---
        string ayiriciXett = new string('-', 40);
        g.DrawString(ayiriciXett, normalFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, normalFont.GetHeight()), centerFormat);
        yPos += normalFont.GetHeight();

        g.DrawString($"Qəbz ID: {_satisMelumatlari.SatisId}", normalFont, Brushes.Black, solMesafe, yPos);
        yPos += normalFont.GetHeight();
        g.DrawString($"Kassir: {_satisMelumatlari.KassirAdi}", normalFont, Brushes.Black, solMesafe, yPos);
        yPos += normalFont.GetHeight();
        g.DrawString($"Tarix: {_satisMelumatlari.Tarix:dd.MM.yyyy HH:mm:ss}", normalFont, Brushes.Black, solMesafe, yPos);
        yPos += normalFont.GetHeight();

        g.DrawString(ayiriciXett, normalFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, normalFont.GetHeight()), centerFormat);
        yPos += normalFont.GetHeight() + 5;

        // --- Məhsul Siyahısının Başlığı ---
        g.DrawString("Məhsul", basliqFontu, Brushes.Black, solMesafe, yPos);
        g.DrawString("Miqdar", basliqFontu, Brushes.Black, solMesafe + 120, yPos);
        g.DrawString("Məbləğ", basliqFontu, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, basliqFontu.GetHeight()), rightFormat);
        yPos += basliqFontu.GetHeight();

        // --- Satılan Məhsulların Siyahısı ---
        foreach (var mehsul in _satisMelumatlari.SatilanMehsullar)
        {
            // Məhsulun adını (uzun olarsa, avtomatik bölünsün)
            RectangleF mehsulAdRect = new RectangleF(solMesafe, yPos, 115, 40);
            g.DrawString(mehsul.MehsulAdi, normalFont, Brushes.Black, mehsulAdRect);

            // Hər bir məhsulun hündürlüyünü hesabla
            float mehsulHundurluk = g.MeasureString(mehsul.MehsulAdi, normalFont, 115).Height;

            // Miqdarı yaz
            g.DrawString(mehsul.Miqdar.ToString(), normalFont, Brushes.Black, solMesafe + 120, yPos);

            // Məbləği sağa düzləndirərək yaz
            string meblegStr = $"{mehsul.UmumiMebleg:N2}";
            g.DrawString(meblegStr, normalFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, normalFont.GetHeight()), rightFormat);

            yPos += Math.Max(normalFont.GetHeight(), mehsulHundurluk);
        }

        yPos += 5;
        g.DrawString(ayiriciXett, normalFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, normalFont.GetHeight()), centerFormat);
        yPos += normalFont.GetHeight();

        // --- Yekun Məbləğ ---
        string yekunStr = $"CƏMİ: {_satisMelumatlari.CemiMebleg:N2} AZN";
        g.DrawString(yekunStr, basliqFontu, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, basliqFontu.GetHeight()), rightFormat);
        yPos += basliqFontu.GetHeight() + 20;

        // --- Alt Hissə ---
        string tesekkur = "Bizi seçdiyiniz üçün təşəkkür edirik!";
        g.DrawString(tesekkur, normalFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, normalFont.GetHeight()), centerFormat);

        // Başqa səhifənin olub-olmadığını yoxlayırıq (bizim halda həmişə false)
        e.HasMorePages = false;
    }
}