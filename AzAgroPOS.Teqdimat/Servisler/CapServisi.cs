// Fayl: AzAgroPOS.Teqdimat/Servisler/CapServisi.cs
namespace AzAgroPOS.Teqdimat.Servisler;

using AzAgroPOS.Mentiq.DTOs;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

public class CapServisi
{
    private SatisQebzDto? _satisMelumatlari;

    // Fontlar
    private readonly Font _titleFont = new("Segoe UI", 14, FontStyle.Bold);
    private readonly Font _subtitleFont = new("Segoe UI", 9, FontStyle.Italic);
    private readonly Font _headerFont = new("Segoe UI", 10, FontStyle.Bold);
    private readonly Font _normalFont = new("Segoe UI", 9, FontStyle.Regular);
    private readonly Font _footerFont = new("Segoe UI", 9, FontStyle.Bold);

    private readonly StringFormat _center = new() { Alignment = StringAlignment.Center };
    private readonly StringFormat _right = new() { Alignment = StringAlignment.Far };
    private readonly StringFormat _left = new() { Alignment = StringAlignment.Near };

    /// <summary>
    /// Default printerə avtomatik çap göndərir.
    /// </summary>
    public void AftomatikCapaGonder(SatisQebzDto satisMelumatlari)
    {
        _satisMelumatlari = satisMelumatlari;

        using PrintDocument pd = new();
        // 80mm (72.1mm) kağız eni və 297mm hündürlük
        pd.DefaultPageSettings.PaperSize = new PaperSize("Custom80mm", 284, 1169);

        pd.PrintPage += PrintDocument_PrintPage;

        try { pd.Print(); }
        catch (InvalidPrinterException)
        {
            MessageBox.Show("Sistemdə standart printer tapılmadı.", "Çap Xətası", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Çap zamanı xəta: {ex.Message}", "Çap Xətası", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
    {
        if (_satisMelumatlari == null || e.Graphics == null) return;

        Graphics g = e.Graphics;
        float y = 20;
        float w = e.MarginBounds.Width;
        float x = e.MarginBounds.Left;

        // --- Başlıq ---
        g.DrawString("AZAGROPOS MARKET", _titleFont, Brushes.Black, new RectangleF(x, y, w, 25), _center);
        y += 28;
        g.DrawString("Bakı şəh., Nizami küç. 123", _subtitleFont, Brushes.Black, new RectangleF(x, y, w, 20), _center);
        y += 15;
        g.DrawString("VÖEN: 1234567890", _subtitleFont, Brushes.Black, new RectangleF(x, y, w, 20), _center);
        y += 25;

        DrawSeparator(g, ref y, w, x);

        // --- Qəbz məlumatları ---
        g.DrawString("Satış çeki", _headerFont, Brushes.Black, new RectangleF(x, y, w, 20), _center);
        y += 22;
        g.DrawString($"Qəbz №: {_satisMelumatlari.SatisId}", _normalFont, Brushes.Black, x, y);
        g.DrawString($"{_satisMelumatlari.Tarix:dd.MM.yyyy HH:mm}", _normalFont, Brushes.Black, new RectangleF(x, y, w, 20), _right);
        y += 20;
        g.DrawString($"Kassir: {_satisMelumatlari.KassirAdi}", _normalFont, Brushes.Black, x, y);
        y += 25;

        DrawLine(g, ref y, w, x);

        // --- Məhsul Siyahısı Başlıqları ---
        g.DrawString("Məhsul", _headerFont, Brushes.Black, x, y);
        g.DrawString("Miq", _headerFont, Brushes.Black, x + w * 0.45f, y);
        g.DrawString("Qiymət", _headerFont, Brushes.Black, x + w * 0.65f, y);
        g.DrawString("Məbləğ", _headerFont, Brushes.Black, new RectangleF(x, y, w, 20), _right);
        y += 20;

        DrawLine(g, ref y, w, x);

        // --- Məhsullar ---
        foreach (var m in _satisMelumatlari.SatilanMehsullar)
        {
            g.DrawString(m.MehsulAdi, _normalFont, Brushes.Black, new RectangleF(x, y, w * 0.43f, 20), _left);
            g.DrawString(m.Miqdar.ToString(), _normalFont, Brushes.Black, x + w * 0.45f, y);
            g.DrawString($"{m.VahidinQiymeti:N2}", _normalFont, Brushes.Black, x + w * 0.65f, y);
            g.DrawString($"{m.UmumiMebleg:N2}", _normalFont, Brushes.Black, new RectangleF(x, y, w, 20), _right);
            y += 18;
        }

        DrawSeparator(g, ref y, w, x);

        // --- Yekun ---
        g.DrawString("YEKUN:", _headerFont, Brushes.Black, x + w * 0.55f, y);
        g.DrawString($"{_satisMelumatlari.CemiMebleg:N2} AZN", _headerFont, Brushes.Black, new RectangleF(x, y, w, 20), _right);
        y += 25;

        g.DrawString("Ödəniş: Nağd", _normalFont, Brushes.Black, x, y);
        y += 18;
        g.DrawString("ƏDV (18%): daxildir", _normalFont, Brushes.Black, x, y);
        y += 25;

        DrawSeparator(g, ref y, w, x);

        // --- Alt Mesaj ---
        g.DrawString("Bizi seçdiyiniz üçün təşəkkür edirik!", _footerFont, Brushes.Black, new RectangleF(x, y, w, 20), _center);
        y += 22;
        g.DrawString("Oktay Hüseynoglu MMC", _subtitleFont, Brushes.Black, new RectangleF(x, y, w, 20), _center);

        e.HasMorePages = false;
    }

    private void DrawSeparator(Graphics g, ref float y, float w, float x)
    {
        g.DrawString(new string('=', 42), _normalFont, Brushes.Black, new RectangleF(x, y, w, 15), _center);
        y += 18;
    }

    private void DrawLine(Graphics g, ref float y, float w, float x)
    {
        g.DrawLine(Pens.Black, x, y, x + w, y);
        y += 3;
    }
}
