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

        // --- YENİ HİSSƏ: Kağız ölçüsünü təyin edirik ---
        // Ölçüləri 1/100 inch olaraq təyin edirik (6cm x 4cm)
        int en = 236; // 6cm
        int hundurluk = 157; // 4cm
        pd.DefaultPageSettings.PaperSize = new PaperSize("Custom Label", en, hundurluk);
        // ---------------------------------------------

        pd.PrintPage += Pd_PrintPage;

        PrintDialog pDialog = new PrintDialog();
        pDialog.Document = pd;

        if (pDialog.ShowDialog() == DialogResult.OK)
        {
            pd.Print();
        }
    }

    private void Pd_PrintPage(object sender, PrintPageEventArgs e)
    {
        if (e.Graphics == null || !_etiketler.Any()) return;

        Graphics g = e.Graphics;

        // --- YENİ HİSSƏ: Elementlərin ölçü və yerlərini yeni kağıza uyğunlaşdırırıq ---
        Font adFontu = new Font("Arial", 8, FontStyle.Bold); // Şrift ölçüsü kiçildildi
        Font qiymetFontu = new Font("Arial", 10, FontStyle.Bold); // Şrift ölçüsü kiçildildi
        Font barkodFontu = new Font("Libre Barcode 39", 24, FontStyle.Regular); // Şrift ölçüsü kiçildildi

        float yPos = 5;
        float solMesafe = 5;
        float etiketEni = e.PageBounds.Width - (solMesafe * 2);

        var hazirkiEtiket = _etiketler[_hazirkiEtiketIndexi];

        // Mərkəzə düzləmək üçün StringFormat obyekti
        StringFormat centerFormat = new StringFormat();
        centerFormat.Alignment = StringAlignment.Center;

        // Məhsulun adını çək (mərkəzə düzlənmiş)
        RectangleF adRect = new RectangleF(solMesafe, yPos, etiketEni, 20);
        g.DrawString(hazirkiEtiket.MehsulAdi, adFontu, Brushes.Black, adRect, centerFormat);
        yPos += 20;

        // Qiyməti çək (mərkəzə düzlənmiş)
        RectangleF qiymetRect = new RectangleF(solMesafe, yPos, etiketEni, 25);
        g.DrawString(hazirkiEtiket.QiymetStr, qiymetFontu, Brushes.Black, qiymetRect, centerFormat);
        yPos += 30;

        // Barkodu çək (mərkəzə düzlənmiş)
        string barkodData = $"*{hazirkiEtiket.Barkod}*";
        RectangleF barkodRect = new RectangleF(solMesafe, yPos, etiketEni, 40);
        g.DrawString(barkodData, barkodFontu, Brushes.Black, barkodRect, centerFormat);
        yPos += 45;

        // Barkodun altındakı rəqəmləri çək (mərkəzə düzlənmiş)
        Font barkodReqemFontu = new Font("Arial", 8, FontStyle.Regular);
        RectangleF barkodReqemRect = new RectangleF(solMesafe, yPos, etiketEni, 15);
        g.DrawString(hazirkiEtiket.Barkod, barkodReqemFontu, Brushes.Black, barkodReqemRect, centerFormat);
        // ---------------------------------------------------------------------------------

        // Növbəti kopyaya və ya etiketə keçid məntiqi (dəyişməz qalıb)
        _hazirkiKopyaIndexi++;
        if (_hazirkiKopyaIndexi < hazirkiEtiket.CapEdilecekSay)
        {
            e.HasMorePages = true;
        }
        else
        {
            _hazirkiKopyaIndexi = 0;
            _hazirkiEtiketIndexi++;
            if (_hazirkiEtiketIndexi < _etiketler.Count)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }
    }
}