// Fayl: AzAgroPOS.Teqdimat/Servisler/BarkodCapServisi.cs
namespace AzAgroPOS.Teqdimat.Servisler;

using AzAgroPOS.Mentiq.DTOs;
using System.Drawing.Printing;

public class BarkodCapServisi
{
    private List<BarkodEtiketDto> _etiketler;
    private int _hazirkiEtiketIndexi;
    private int _hazirkiKopyaIndexi;

    public BarkodCapServisi()
    {
        _etiketler = new List<BarkodEtiketDto>();
        _hazirkiEtiketIndexi = 0;
        _hazirkiKopyaIndexi = 0;
    }

    public void EtiketleriCapaGonder(List<BarkodEtiketDto> etiketler)
    {
        _etiketler = etiketler;
        _hazirkiEtiketIndexi = 0;
        _hazirkiKopyaIndexi = 0;

        PrintDocument pd = new PrintDocument();
        pd.PrintPage += Pd_PrintPage;

        PrintDialog pDialog = new PrintDialog();
        pDialog.Document = pd;

        if (pDialog.ShowDialog() == DialogResult.OK)
        {
            pd.PrinterSettings = pDialog.PrinterSettings;

            // Dəyişiklik: Printerin öz standart kağızını istifadə etməsinə icazə veririk.
            // Bizim 6x4cm ölçümüz printerin drayverində artıq "Stock" olaraq qurulub.
            // Bu, uyğunsuzluq riskini azaldır.

            pd.Print();
        }
    }

    private void Pd_PrintPage(object sender, PrintPageEventArgs e)
    {
        if (e.Graphics == null || !_etiketler.Any()) return;

        Graphics g = e.Graphics;

        // --- DƏYİŞİKLİK VƏ TƏKMİLLƏŞDİRMƏLƏR ---

        // Printerin icazə verdiyi real çap sahəsini (kənar boşluqlar çıxılmış) əldə edirik.
        RectangleF capSahəsi = e.MarginBounds;

        // Şriftləri təyin edirik
        Font adFontu = new Font("Arial", 8, FontStyle.Regular);
        Font qiymetFontu = new Font("Arial", 10, FontStyle.Bold);
        Font barkodFontu = new Font("Libre Barcode 39", 32, FontStyle.Regular);
        Font barkodReqemFontu = new Font("Arial", 8, FontStyle.Regular);

        var hazirkiEtiket = _etiketler[_hazirkiEtiketIndexi];

        // Mərkəzə düzləmək üçün obyekt
        StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

        // Y oxu üzrə mövqeni dinamik hesablamaq üçün
        float yPosition = capSahəsi.Top;

        // 1. Məhsul Adı
        // Məhsul adının hündürlüyünü hesablayaq ki, uzun adlar bir neçə sətirə bölünsün
        SizeF adOlcusu = g.MeasureString(hazirkiEtiket.MehsulAdi, adFontu, (int)capSahəsi.Width);
        RectangleF adRect = new RectangleF(capSahəsi.Left, yPosition, capSahəsi.Width, adOlcusu.Height);
        g.DrawString(hazirkiEtiket.MehsulAdi, adFontu, Brushes.Black, adRect, centerFormat);
        yPosition += adOlcusu.Height + 2; // Boşluq

        // 2. Qiymət
        RectangleF qiymetRect = new RectangleF(capSahəsi.Left, yPosition, capSahəsi.Width, 20);
        g.DrawString(hazirkiEtiket.QiymetStr, qiymetFontu, Brushes.Black, qiymetRect, centerFormat);
        yPosition += 20 + 2; // Boşluq

        // 3. Barkod
        string barkodData = $"*{hazirkiEtiket.Barkod}*";
        RectangleF barkodRect = new RectangleF(capSahəsi.Left, yPosition, capSahəsi.Width, 40);
        g.DrawString(barkodData, barkodFontu, Brushes.Black, barkodRect, centerFormat);
        yPosition += 40; // Barkodun hündürlüyü

        // 4. Barkodun altındakı rəqəmlər
        RectangleF barkodReqemRect = new RectangleF(capSahəsi.Left, yPosition, capSahəsi.Width, 15);
        g.DrawString(hazirkiEtiket.Barkod, barkodReqemFontu, Brushes.Black, barkodReqemRect, centerFormat);

        // Növbəti səhifə məntiqi
        _hazirkiKopyaIndexi++;
        if (_hazirkiKopyaIndexi < hazirkiEtiket.CapEdilecekSay)
        {
            e.HasMorePages = true;
        }
        else
        {
            _hazirkiKopyaIndexi = 0;
            _hazirkiEtiketIndexi++;
            e.HasMorePages = _hazirkiEtiketIndexi < _etiketler.Count;
        }
    }
}