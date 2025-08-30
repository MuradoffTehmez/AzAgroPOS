// Fayl: AzAgroPOS.Teqdimat/Servisler/CapServisi.cs
namespace AzAgroPOS.Teqdimat.Servisler;

using AzAgroPOS.Mentiq.DTOs;
using System.Drawing.Printing;

public class CapServisi
{
    private SatisQebzDto? _satisMelumatlari;

    // 80mm kağız üçün optimallaşdırılmış fontlar və formatlar
    private readonly Font _basliqFontu = new("Calibri", 12, FontStyle.Bold);
    private readonly Font _normalFont = new("Calibri", 10, FontStyle.Regular);
    private readonly Font _kicikFont = new("Calibri", 9, FontStyle.Italic);
    private readonly StringFormat _centerFormat = new() { Alignment = StringAlignment.Center };
    private readonly StringFormat _rightFormat = new() { Alignment = StringAlignment.Far };

    /// <summary>
    /// Sual vermədən, birbaşa sistemdəki standart (default) printerə çap əmri göndərir.
    /// </summary>
    public void AftomatikCapaGonder(SatisQebzDto satisMelumatlari)
    {
        _satisMelumatlari = satisMelumatlari;

        using PrintDocument pd = new();
        pd.PrintPage += PrintDocument_PrintPage;

        try
        {
            pd.Print();
        }
        catch (InvalidPrinterException)
        {
            MessageBox.Show("Sistemdə standart printer tapılmadı və ya düzgün qurulmayıb. Zəhmət olmasa, Windows ayarlarından bir printeri standart olaraq təyin edin.", "Çap Xətası", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Çap zamanı naməlum xəta baş verdi: {ex.Message}", "Çap Xətası", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
    {
        if (_satisMelumatlari == null || e.Graphics == null) return;

        Graphics g = e.Graphics;
        float yPos = e.MarginBounds.Top;
        float solMesafe = e.MarginBounds.Left;
        float qebzEni = e.MarginBounds.Width;
        string ayiriciXett = new string('=', (int)(qebzEni / _normalFont.Size * 2.2f));

        // --- Başlıq Hissəsi ---
        yPos = BasligiCapEt(g, yPos, qebzEni, solMesafe);

        // --- Qəbz Məlumatları ---
        yPos = QebzMəlumatlariniCapEt(g, yPos, qebzEni, solMesafe);

        // --- Məhsul Siyahısı ---
        g.DrawString(ayiriciXett, _normalFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, _normalFont.GetHeight()), _centerFormat);
        yPos += _normalFont.GetHeight();
        yPos = MehsulBasliqlariniCapEt(g, yPos, qebzEni, solMesafe);
        g.DrawString(ayiriciXett, _normalFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, _normalFont.GetHeight()), _centerFormat);
        yPos += _normalFont.GetHeight() + 3;

        yPos = MehsullariCapEt(g, yPos, qebzEni, solMesafe);

        // --- Yekun ---
        g.DrawString(ayiriciXett, _normalFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, _normalFont.GetHeight()), _centerFormat);
        yPos += _normalFont.GetHeight();
        yPos = YekunuCapEt(g, yPos, qebzEni, solMesafe);

        // --- Alt Mesaj ---
        string tesekkur = "Bizi seçdiyiniz üçün təşəkkür edirik!";
        g.DrawString(tesekkur, _basliqFontu, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, _basliqFontu.GetHeight()), _centerFormat);

        e.HasMorePages = false;
    }

    private float BasligiCapEt(Graphics g, float yPos, float qebzEni, float solMesafe)
    {
        g.DrawString("AzAgroPOS Market", new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, 25), _centerFormat);
        yPos += 25;
        g.DrawString("Bakı şəh., Nizami küç. 123", _kicikFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, 15), _centerFormat);
        yPos += 15;
        g.DrawString("VÖEN: 1234567890", _kicikFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, 15), _centerFormat);
        yPos += 15 + 10;
        return yPos;
    }

    private float QebzMəlumatlariniCapEt(Graphics g, float yPos, float qebzEni, float solMesafe)
    {
        g.DrawString($"Qəbz ID: {_satisMelumatlari.SatisId}", _normalFont, Brushes.Black, solMesafe, yPos);
        g.DrawString($"Tarix: {_satisMelumatlari.Tarix:dd.MM.yy HH:mm}", _normalFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, _normalFont.GetHeight()), _rightFormat);
        yPos += _normalFont.GetHeight();
        g.DrawString($"Kassir: {_satisMelumatlari.KassirAdi}", _normalFont, Brushes.Black, solMesafe, yPos);
        yPos += _normalFont.GetHeight() + 5;
        return yPos;
    }

    private float MehsulBasliqlariniCapEt(Graphics g, float yPos, float qebzEni, float solMesafe)
    {
        float adX = solMesafe;
        float miqdarX = solMesafe + (qebzEni * 0.50f);
        float vahidQiymetX = solMesafe + (qebzEni * 0.65f);

        g.DrawString("Məhsul Adı", _basliqFontu, Brushes.Black, adX, yPos);
        g.DrawString("Miqdar", _basliqFontu, Brushes.Black, miqdarX, yPos);
        g.DrawString("Qiymət", _basliqFontu, Brushes.Black, vahidQiymetX, yPos);
        g.DrawString("Məbləğ", _basliqFontu, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, _basliqFontu.GetHeight()), _rightFormat);
        yPos += _basliqFontu.GetHeight();
        return yPos;
    }

    private float MehsullariCapEt(Graphics g, float yPos, float qebzEni, float solMesafe)
    {
        float adSutunuEni = qebzEni * 0.48f;
        float miqdarX = solMesafe + (qebzEni * 0.50f);
        float vahidQiymetX = solMesafe + (qebzEni * 0.65f);

        foreach (var mehsul in _satisMelumatlari.SatilanMehsullar)
        {
            RectangleF mehsulAdRect = new RectangleF(solMesafe, yPos, adSutunuEni, 40);
            g.DrawString(mehsul.MehsulAdi, _normalFont, Brushes.Black, mehsulAdRect);

            float mehsulHundurluk = g.MeasureString(mehsul.MehsulAdi, _normalFont, (int)adSutunuEni).Height;

            g.DrawString(mehsul.Miqdar.ToString(), _normalFont, Brushes.Black, miqdarX, yPos);
            g.DrawString($"{mehsul.VahidinQiymeti:N2}", _normalFont, Brushes.Black, vahidQiymetX, yPos);
            g.DrawString($"{mehsul.UmumiMebleg:N2}", _normalFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, _normalFont.GetHeight()), _rightFormat);

            yPos += Math.Max(_normalFont.GetHeight(), mehsulHundurluk) + 2;
        }
        return yPos;
    }

    private float YekunuCapEt(Graphics g, float yPos, float qebzEni, float solMesafe)
    {
        yPos += 5;

        string yekunStr = $"YEKUN MƏBLƏĞ: {_satisMelumatlari.CemiMebleg:N2} AZN";
        g.DrawString(yekunStr, _basliqFontu, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, _basliqFontu.GetHeight()), _rightFormat);
        yPos += _basliqFontu.GetHeight() + 20;
        return yPos;
    }
}