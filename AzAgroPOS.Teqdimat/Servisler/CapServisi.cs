// Fayl: AzAgroPOS.Teqdimat/Servisler/CapServisi.cs
namespace AzAgroPOS.Teqdimat.Servisler;

using AzAgroPOS.Mentiq.DTOs;
using System.Drawing.Printing;

public class CapServisi
{
    private SatisQebzDto? _satisMelumatlari;

    // Fontları və formatları bir dəfə yaradıb təkrar istifadə edirik
    private readonly Font _basliqFontu = new("Courier New", 10, FontStyle.Bold);
    private readonly Font _normalFont = new("Courier New", 9, FontStyle.Regular);
    private readonly Font _kicikFont = new("Courier New", 8, FontStyle.Italic);
    private readonly StringFormat _centerFormat = new() { Alignment = StringAlignment.Center };
    private readonly StringFormat _rightFormat = new() { Alignment = StringAlignment.Far };

    public void SatisiCapEt(SatisQebzDto satisMelumatlari)
    {
        _satisMelumatlari = satisMelumatlari;

        using PrintDocument pd = new();
        pd.PrintPage += PrintDocument_PrintPage;

        using PrintDialog pDialog = new() { Document = pd };
        pDialog.AllowSomePages = false;
        pDialog.AllowSelection = false;

        if (pDialog.ShowDialog() == DialogResult.OK)
        {
            pd.PrinterSettings = pDialog.PrinterSettings;
            try
            {
                pd.Print();
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
        float yPos = e.MarginBounds.Top;
        float solMesafe = e.MarginBounds.Left;
        float qebzEni = e.MarginBounds.Width;
        string ayiriciXett = new string('-', 40);

        // --- Başlıq Hissəsi ---
        yPos = BasligiCapEt(g, yPos, qebzEni, solMesafe);

        // --- Qəbz Məlumatları ---
        yPos = QebzMəlumatlariniCapEt(g, yPos, qebzEni, solMesafe, ayiriciXett);

        // --- Məhsul Siyahısı ---
        yPos = MehsullariCapEt(g, yPos, qebzEni, solMesafe);

        // --- Yekun ---
        yPos = YekunuCapEt(g, yPos, qebzEni, solMesafe, ayiriciXett);

        // --- Alt Mesaj ---
        string tesekkur = "Bizi seçdiyiniz üçün təşəkkür edirik!";
        g.DrawString(tesekkur, _normalFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, _normalFont.GetHeight()), _centerFormat);

        e.HasMorePages = false;
    }

    private float BasligiCapEt(Graphics g, float yPos, float qebzEni, float solMesafe)
    {
        g.DrawString("AzAgroPOS Market", _basliqFontu, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, _basliqFontu.GetHeight()), _centerFormat);
        yPos += _basliqFontu.GetHeight();
        g.DrawString("Bakı şəh., Nizami küç. 123", _kicikFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, _kicikFont.GetHeight()), _centerFormat);
        yPos += _kicikFont.GetHeight();
        g.DrawString("VÖEN: 1234567890", _kicikFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, _kicikFont.GetHeight()), _centerFormat);
        yPos += _kicikFont.GetHeight() + 10;
        return yPos;
    }

    private float QebzMəlumatlariniCapEt(Graphics g, float yPos, float qebzEni, float solMesafe, string ayiriciXett)
    {
        g.DrawString(ayiriciXett, _normalFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, _normalFont.GetHeight()), _centerFormat);
        yPos += _normalFont.GetHeight();

        g.DrawString($"Qəbz ID: {_satisMelumatlari.SatisId}", _normalFont, Brushes.Black, solMesafe, yPos);
        yPos += _normalFont.GetHeight();
        g.DrawString($"Kassir: {_satisMelumatlari.KassirAdi}", _normalFont, Brushes.Black, solMesafe, yPos);
        yPos += _normalFont.GetHeight();
        g.DrawString($"Tarix: {_satisMelumatlari.Tarix:dd.MM.yyyy HH:mm:ss}", _normalFont, Brushes.Black, solMesafe, yPos);
        yPos += _normalFont.GetHeight();

        g.DrawString(ayiriciXett, _normalFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, _normalFont.GetHeight()), _centerFormat);
        yPos += _normalFont.GetHeight() + 5;
        return yPos;
    }

    private float MehsullariCapEt(Graphics g, float yPos, float qebzEni, float solMesafe)
    {
        g.DrawString("Məhsul", _basliqFontu, Brushes.Black, solMesafe, yPos);
        g.DrawString("Miqdar", _basliqFontu, Brushes.Black, solMesafe + 120, yPos);
        g.DrawString("Məbləğ", _basliqFontu, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, _basliqFontu.GetHeight()), _rightFormat);
        yPos += _basliqFontu.GetHeight() + 2;

        foreach (var mehsul in _satisMelumatlari.SatilanMehsullar)
        {
            RectangleF mehsulAdRect = new RectangleF(solMesafe, yPos, 115, 40);
            g.DrawString(mehsul.MehsulAdi, _normalFont, Brushes.Black, mehsulAdRect);

            float mehsulHundurluk = g.MeasureString(mehsul.MehsulAdi, _normalFont, 115).Height;

            g.DrawString(mehsul.Miqdar.ToString(), _normalFont, Brushes.Black, solMesafe + 120, yPos);

            string meblegStr = $"{mehsul.UmumiMebleg:N2}";
            g.DrawString(meblegStr, _normalFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, _normalFont.GetHeight()), _rightFormat);

            yPos += Math.Max(_normalFont.GetHeight(), mehsulHundurluk) + 2;
        }
        return yPos;
    }

    private float YekunuCapEt(Graphics g, float yPos, float qebzEni, float solMesafe, string ayiriciXett)
    {
        yPos += 5;
        g.DrawString(ayiriciXett, _normalFont, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, _normalFont.GetHeight()), _centerFormat);
        yPos += _normalFont.GetHeight();

        string yekunStr = $"CƏMİ: {_satisMelumatlari.CemiMebleg:N2} AZN";
        g.DrawString(yekunStr, _basliqFontu, Brushes.Black, new RectangleF(solMesafe, yPos, qebzEni, _basliqFontu.GetHeight()), _rightFormat);
        yPos += _basliqFontu.GetHeight() + 20;
        return yPos;
    }
}