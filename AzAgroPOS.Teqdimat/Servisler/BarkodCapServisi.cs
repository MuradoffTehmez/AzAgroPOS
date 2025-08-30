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
            pd.Print();
        }
    }

    private void Pd_PrintPage(object sender, PrintPageEventArgs e)
    {
        if (e.Graphics == null || !_etiketler.Any()) return;

        Graphics g = e.Graphics;
        Font adFontu = new Font("Arial", 10, FontStyle.Bold);
        Font qiymetFontu = new Font("Arial", 12, FontStyle.Bold);
        Font barkodFontu = new Font("Libre Barcode 39", 28, FontStyle.Regular);

        float yPos = 5; // Yuxarıdan boşluq

        var hazirkiEtiket = _etiketler[_hazirkiEtiketIndexi];

        // Məhsulun adını çək
        g.DrawString(hazirkiEtiket.MehsulAdi, adFontu, Brushes.Black, 10, yPos);
        yPos += 20;

        // Qiyməti çək
        g.DrawString(hazirkiEtiket.QiymetStr, qiymetFontu, Brushes.Black, 10, yPos);
        yPos += 25;

        // Barkodu çək (* işarələri skanerin oxuması üçün vacibdir)
        g.DrawString($"*{hazirkiEtiket.Barkod}*", barkodFontu, Brushes.Black, 10, yPos);

        // Növbəti kopyaya və ya etiketə keçid
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