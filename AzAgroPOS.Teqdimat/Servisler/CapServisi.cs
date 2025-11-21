// Fayl: AzAgroPOS.Teqdimat/Servisler/CapServisi.cs
namespace AzAgroPOS.Teqdimat.Servisler;

using AzAgroPOS.Mentiq.DTOs;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

/// <summary>
/// 80mm termal printer ucun cek cap servisi.
/// Standart 80mm printer ucun optimize edilib (285px genislik).
/// </summary>
public class CapServisi
{
    #region Constants

    // 80mm termal printer ucun standart genislik (72mm cap sahesi)
    private const int RECEIPT_WIDTH = 285;
    private const int LEFT_MARGIN = 5;
    private const int RIGHT_MARGIN = 5;
    private const int CONTENT_WIDTH = RECEIPT_WIDTH - LEFT_MARGIN - RIGHT_MARGIN;

    // Sutun genislikleri (faiz)
    private const float COL_NAME_WIDTH = 0.42f;
    private const float COL_QTY_WIDTH = 0.12f;
    private const float COL_PRICE_WIDTH = 0.20f;
    private const float COL_TOTAL_WIDTH = 0.26f;

    #endregion

    #region Fields

    private SatisQebzDto? _qebzMelumatlari;
    private string _printerName = string.Empty;

    // Endirim ve bonus melumatlari
    private decimal _umumiEndirim = 0;
    private decimal _bonusIstifade = 0;

    // Magazanin melumatlari (konfiqurasiyadan alinmalidir)
    private string _magazaAdi = "AZAGROPOS MARKET";
    private string _magazaUnvani = "Baki seh., Nizami kuc. 123";
    private string _voen = "1234567890";

    // Fontlar
    private readonly Font _storeTitleFont = new("Segoe UI", 14, FontStyle.Bold);
    private readonly Font _storeInfoFont = new("Segoe UI", 8, FontStyle.Regular);
    private readonly Font _headerFont = new("Segoe UI", 10, FontStyle.Bold);
    private readonly Font _normalFont = new("Segoe UI", 9, FontStyle.Regular);
    private readonly Font _smallFont = new("Segoe UI", 8, FontStyle.Regular);
    private readonly Font _totalFont = new("Segoe UI", 12, FontStyle.Bold);
    private readonly Font _footerFont = new("Segoe UI", 9, FontStyle.Italic);

    // StringFormat-lar
    private readonly StringFormat _centerFormat = new() { Alignment = StringAlignment.Center };
    private readonly StringFormat _rightFormat = new() { Alignment = StringAlignment.Far };
    private readonly StringFormat _leftFormat = new() { Alignment = StringAlignment.Near };
    private readonly StringFormat _wrapFormat = new()
    {
        Alignment = StringAlignment.Near,
        Trimming = StringTrimming.EllipsisCharacter
    };

    #endregion

    #region Public Methods

    /// <summary>
    /// Qebzi secilmis printere cap edir.
    /// </summary>
    /// <param name="data">Satis qebzi melumatlari</param>
    /// <param name="printerName">Printer adi (bos olarsa default printer istifade olunur)</param>
    public void CekiCapEt(SatisQebzDto data, string printerName = "")
    {
        if (data == null)
        {
            MessageBox.Show("Cap ucun melumat yoxdur.", "Xeta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        _qebzMelumatlari = data;
        _printerName = printerName;

        using PrintDocument pd = new();

        // Printer ayarlari
        if (!string.IsNullOrEmpty(printerName))
        {
            pd.PrinterSettings.PrinterName = printerName;
        }

        // 80mm kagiz olcusu (1/100 inch): 285 units = ~72mm
        pd.DefaultPageSettings.PaperSize = new PaperSize("Receipt80mm", 285, 1200);
        pd.DefaultPageSettings.Margins = new Margins(LEFT_MARGIN, RIGHT_MARGIN, 10, 10);

        pd.PrintPage += PrintDocument_PrintPage;

        try
        {
            pd.Print();
        }
        catch (InvalidPrinterException)
        {
            MessageBox.Show("Secilen printer tapilmadi: " + printerName, "Cap Xetasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Cap zamani xeta bas verdi: {ex.Message}", "Cap Xetasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Qebzi default printere avtomatik cap edir.
    /// </summary>
    public void AvtomatikCapaGonder(SatisQebzDto data)
    {
        CekiCapEt(data, string.Empty);
    }

    /// <summary>
    /// Endirim meblegin teyin edir.
    /// </summary>
    public void EndirimTeyinEt(decimal endirim)
    {
        _umumiEndirim = endirim;
    }

    /// <summary>
    /// Bonus istifadesi meblegin teyin edir.
    /// </summary>
    public void BonusIstifadesiTeyinEt(decimal bonus)
    {
        _bonusIstifade = bonus;
    }

    /// <summary>
    /// Magaza melumatlarini teyin edir.
    /// </summary>
    public void MagazaMelumatlariTeyinEt(string magazaAdi, string unvan, string voen)
    {
        _magazaAdi = magazaAdi;
        _magazaUnvani = unvan;
        _voen = voen;
    }

    /// <summary>
    /// Sistemde olan printerlerin siyahisini qaytarir.
    /// </summary>
    public static string[] PrinterSiyahisiniGetir()
    {
        return PrinterSettings.InstalledPrinters.Cast<string>().ToArray();
    }

    /// <summary>
    /// Default printer adini qaytarir.
    /// </summary>
    public static string DefaultPrinterGetir()
    {
        using var pd = new PrintDocument();
        return pd.PrinterSettings.PrinterName;
    }

    #endregion

    #region Private Print Methods

    private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
    {
        if (_qebzMelumatlari == null || e.Graphics == null) return;

        Graphics g = e.Graphics;
        float y = 10;
        float x = LEFT_MARGIN;
        float contentWidth = CONTENT_WIDTH;

        // Anti-aliasing
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

        // === HEADER: Magaza melumatlari ===
        DrawStoreHeader(g, ref y, x, contentWidth);

        // === QEBZ MELUMATLARI ===
        DrawReceiptInfo(g, ref y, x, contentWidth);

        // === MEHSUL SIYAHISI ===
        DrawProductList(g, ref y, x, contentWidth);

        // === YEKUN HESABLAMALAR ===
        DrawTotals(g, ref y, x, contentWidth);

        // === FOOTER ===
        DrawFooter(g, ref y, x, contentWidth);

        e.HasMorePages = false;
    }

    private void DrawStoreHeader(Graphics g, ref float y, float x, float width)
    {
        // Magaza adi (qalin, merkez)
        g.DrawString(_magazaAdi, _storeTitleFont, Brushes.Black,
            new RectangleF(x, y, width, 25), _centerFormat);
        y += 28;

        // Unvan
        g.DrawString(_magazaUnvani, _storeInfoFont, Brushes.Black,
            new RectangleF(x, y, width, 15), _centerFormat);
        y += 15;

        // VOEN
        g.DrawString($"VOEN: {_voen}", _storeInfoFont, Brushes.Black,
            new RectangleF(x, y, width, 15), _centerFormat);
        y += 20;

        // Ayirici xett
        DrawDashedLine(g, ref y, x, width);
    }

    private void DrawReceiptInfo(Graphics g, ref float y, float x, float width)
    {
        // "SATIS QEBZI" basligi
        g.DrawString("SATIS QEBZI", _headerFont, Brushes.Black,
            new RectangleF(x, y, width, 18), _centerFormat);
        y += 22;

        // Qebz nomresi ve tarix (eyni setirde)
        g.DrawString($"Qebz No: {_qebzMelumatlari!.SatisId}", _normalFont, Brushes.Black, x, y);
        g.DrawString($"{_qebzMelumatlari.Tarix:dd.MM.yyyy HH:mm}", _normalFont, Brushes.Black,
            new RectangleF(x, y, width, 18), _rightFormat);
        y += 18;

        // Kassir
        g.DrawString($"Kassir: {_qebzMelumatlari.KassirAdi}", _normalFont, Brushes.Black, x, y);
        y += 22;

        // Ayirici xett
        DrawSolidLine(g, ref y, x, width);
    }

    private void DrawProductList(Graphics g, ref float y, float x, float width)
    {
        // Sutun genislikleri
        float colName = width * COL_NAME_WIDTH;
        float colQty = width * COL_QTY_WIDTH;
        float colPrice = width * COL_PRICE_WIDTH;
        float colTotal = width * COL_TOTAL_WIDTH;

        float posName = x;
        float posQty = x + colName;
        float posPrice = posQty + colQty;
        float posTotal = posPrice + colPrice;

        // Basliqlar
        g.DrawString("Mehsul", _smallFont, Brushes.Black, posName, y);
        g.DrawString("Miq", _smallFont, Brushes.Black, posQty, y);
        g.DrawString("Qiymet", _smallFont, Brushes.Black, posPrice, y);
        g.DrawString("Mebleg", _smallFont, Brushes.Black,
            new RectangleF(posTotal, y, colTotal, 15), _rightFormat);
        y += 16;

        DrawSolidLine(g, ref y, x, width);

        // Mehsullar
        foreach (var mehsul in _qebzMelumatlari!.SatilanMehsullar)
        {
            // Mehsul adi (uzun adlari qisalt)
            string mehsulAdi = TruncateText(mehsul.MehsulAdi, colName - 5, _smallFont, g);
            g.DrawString(mehsulAdi, _smallFont, Brushes.Black,
                new RectangleF(posName, y, colName - 5, 16), _wrapFormat);

            // Miqdar
            g.DrawString(mehsul.Miqdar.ToString("N0"), _smallFont, Brushes.Black, posQty, y);

            // Vahidin qiymeti
            g.DrawString(mehsul.VahidinQiymeti.ToString("N2"), _smallFont, Brushes.Black, posPrice, y);

            // Umumi mebleg
            g.DrawString(mehsul.UmumiMebleg.ToString("N2"), _smallFont, Brushes.Black,
                new RectangleF(posTotal, y, colTotal, 15), _rightFormat);

            y += 16;

            // Eger endirim varsa, goster
            if (mehsul.EndirimMeblegi > 0)
            {
                g.DrawString($"  Endirim: -{mehsul.EndirimMeblegi:N2}", _smallFont, Brushes.Gray, posName, y);
                y += 14;
            }
        }

        // Ayirici
        y += 3;
        DrawDashedLine(g, ref y, x, width);
    }

    private void DrawTotals(Graphics g, ref float y, float x, float width)
    {
        float labelX = x + width * 0.45f;
        float valueX = x + width;
        float valueWidth = width * 0.35f;

        // Ara cem (subtotal)
        decimal araCem = _qebzMelumatlari!.SatilanMehsullar.Sum(m => m.VahidinQiymeti * m.Miqdar);
        g.DrawString("Ara Cem:", _normalFont, Brushes.Black, labelX, y);
        g.DrawString($"{araCem:N2} AZN", _normalFont, Brushes.Black,
            new RectangleF(x, y, width, 18), _rightFormat);
        y += 18;

        // Endirim (eger varsa)
        decimal umumiEndirim = _qebzMelumatlari.SatilanMehsullar.Sum(m => m.EndirimMeblegi) + _umumiEndirim;
        if (umumiEndirim > 0)
        {
            g.DrawString("Endirim:", _normalFont, Brushes.Black, labelX, y);
            g.DrawString($"-{umumiEndirim:N2} AZN", _normalFont, Brushes.Red,
                new RectangleF(x, y, width, 18), _rightFormat);
            y += 18;
        }

        // Bonus istifadesi (eger varsa)
        if (_bonusIstifade > 0)
        {
            g.DrawString("Bonus:", _normalFont, Brushes.Black, labelX, y);
            g.DrawString($"-{_bonusIstifade:N2} AZN", _normalFont, Brushes.Blue,
                new RectangleF(x, y, width, 18), _rightFormat);
            y += 18;
        }

        // Yekun xett
        DrawSolidLine(g, ref y, x, width);

        // YEKUN MEBLEG (boyuk ve qalin)
        decimal yekunMebleg = araCem - umumiEndirim - _bonusIstifade;
        g.DrawString("YEKUN:", _totalFont, Brushes.Black, labelX, y);
        g.DrawString($"{yekunMebleg:N2} AZN", _totalFont, Brushes.Black,
            new RectangleF(x, y, width, 22), _rightFormat);
        y += 26;

        // Odenis metodu
        g.DrawString("Odenis: Nagd", _normalFont, Brushes.Black, x, y);
        y += 18;

        // EDV qeydi
        g.DrawString("EDV (18%) daxildir", _smallFont, Brushes.Gray, x, y);
        y += 20;

        DrawDashedLine(g, ref y, x, width);
    }

    private void DrawFooter(Graphics g, ref float y, float x, float width)
    {
        // Tesekkur mesaji
        g.DrawString("Bizi secdiyiniz ucun tesekkur edirik!", _footerFont, Brushes.Black,
            new RectangleF(x, y, width, 18), _centerFormat);
        y += 20;

        // Sirket adi
        g.DrawString("Oktay Huseynoglu MMC", _smallFont, Brushes.Gray,
            new RectangleF(x, y, width, 15), _centerFormat);
        y += 18;

        // Tarix/saat tekrar
        g.DrawString($"Cap tarixi: {DateTime.Now:dd.MM.yyyy HH:mm:ss}", _smallFont, Brushes.Gray,
            new RectangleF(x, y, width, 15), _centerFormat);
    }

    #endregion

    #region Helper Methods

    /// <summary>
    /// Kesik xett cekir (- - - -)
    /// </summary>
    private void DrawDashedLine(Graphics g, ref float y, float x, float width)
    {
        using var pen = new Pen(Color.Black, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
        g.DrawLine(pen, x, y, x + width, y);
        y += 5;
    }

    /// <summary>
    /// Berk xett cekir (_____)
    /// </summary>
    private void DrawSolidLine(Graphics g, ref float y, float x, float width)
    {
        g.DrawLine(Pens.Black, x, y, x + width, y);
        y += 4;
    }

    /// <summary>
    /// Metni maksimum genislikde qisaldir
    /// </summary>
    private string TruncateText(string text, float maxWidth, Font font, Graphics g)
    {
        if (string.IsNullOrEmpty(text)) return string.Empty;

        var size = g.MeasureString(text, font);
        if (size.Width <= maxWidth) return text;

        // Metni qisalt
        while (text.Length > 3 && g.MeasureString(text + "...", font).Width > maxWidth)
        {
            text = text.Substring(0, text.Length - 1);
        }

        return text + "...";
    }

    #endregion

    #region IDisposable Support

    /// <summary>
    /// Resurslari temizle
    /// </summary>
    public void Dispose()
    {
        _storeTitleFont?.Dispose();
        _storeInfoFont?.Dispose();
        _headerFont?.Dispose();
        _normalFont?.Dispose();
        _smallFont?.Dispose();
        _totalFont?.Dispose();
        _footerFont?.Dispose();
        _centerFormat?.Dispose();
        _rightFormat?.Dispose();
        _leftFormat?.Dispose();
        _wrapFormat?.Dispose();
    }

    #endregion
}
