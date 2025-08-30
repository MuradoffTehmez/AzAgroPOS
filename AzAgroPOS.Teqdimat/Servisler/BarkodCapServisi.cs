// Fayl: AzAgroPOS.Teqdimat/Servisler/BarkodCapServisi.cs
namespace AzAgroPOS.Teqdimat.Servisler;

using AzAgroPOS.Mentiq.DTOs;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

public class BarkodCapServisi
{
    private IReadOnlyList<BarkodEtiketDto> _etiketler = new List<BarkodEtiketDto>();
    private int _hazirkiEtiketIndexi;
    private int _hazirkiKopyaIndexi;

    // Fontlar konfiqurasiya olunmuş halda saxlanır
    private readonly Font _adFontu = new("Arial", 8, FontStyle.Regular);
    private readonly Font _qiymetFontu = new("Arial", 11, FontStyle.Bold);
    private readonly Font _barkodFontu = new("Libre Barcode 39", 48, FontStyle.Regular);
    private readonly Font _barkodReqemFontu = new("Arial", 9, FontStyle.Regular);

    private readonly StringFormat _centerFormat = new() { Alignment = StringAlignment.Center };

    public void EtiketleriCapaGonder(IReadOnlyList<BarkodEtiketDto> etiketler)
    {
        if (etiketler == null || etiketler.Count == 0)
            throw new ArgumentException("Çap ediləcək etiket siyahısı boş ola bilməz.");

        _etiketler = etiketler;
        _hazirkiEtiketIndexi = 0;
        _hazirkiKopyaIndexi = 0;

        using PrintDocument pd = new();
        pd.PrintPage += Pd_PrintPage;

        using PrintDialog pDialog = new() { Document = pd };
        if (pDialog.ShowDialog() == DialogResult.OK)
        {
            pd.PrinterSettings = pDialog.PrinterSettings;
            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Çap zamanı xəta baş verdi: {ex.Message}", "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void Pd_PrintPage(object? sender, PrintPageEventArgs e)
    {
        if (e.Graphics == null) return;

        var hazirkiEtiket = _etiketler[_hazirkiEtiketIndexi];
        float en = e.PageBounds.Width;
        float y = 5;

        y = CekAdiniCek(e.Graphics, hazirkiEtiket.MehsulAdi, en, y);
        y = QiymetiCek(e.Graphics, hazirkiEtiket.QiymetStr, en, y);
        y = BarkoduCek(e.Graphics, hazirkiEtiket.Barkod, en, y);

        NövbətiSəhifəHazirla(hazirkiEtiket, e);
    }

    private float CekAdiniCek(Graphics g, string ad, float en, float y)
    {
        RectangleF rect = new(0, y, en, 30);
        g.DrawString(ad, _adFontu, Brushes.Black, rect, _centerFormat);
        return y + 25;
    }

    private float QiymetiCek(Graphics g, string qiymet, float en, float y)
    {
        RectangleF rect = new(0, y, en, 25);
        g.DrawString(qiymet, _qiymetFontu, Brushes.Black, rect, _centerFormat);
        return y + 30;
    }

    private float BarkoduCek(Graphics g, string barkod, float en, float y)
    {
        // Barkod
        string barkodData = $"*{barkod}*";
        RectangleF barkodRect = new(0, y, en, 60);
        g.DrawString(barkodData, _barkodFontu, Brushes.Black, barkodRect, _centerFormat);
        y += 55;

        // Barkod rəqəmləri
        RectangleF reqemRect = new(0, y, en, 20);
        g.DrawString(barkod, _barkodReqemFontu, Brushes.Black, reqemRect, _centerFormat);
        return y + 20;
    }

    private void NövbətiSəhifəHazirla(BarkodEtiketDto etiket, PrintPageEventArgs e)
    {
        _hazirkiKopyaIndexi++;
        if (_hazirkiKopyaIndexi < etiket.CapEdilecekSay)
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