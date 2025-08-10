// Fayl: AzAgroPOS.Teqdimat/Servisler/CapServisi.cs
namespace AzAgroPOS.Teqdimat.Servisler;

using AzAgroPOS.Mentiq.DTOs;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

public class CapServisi
{
    private SatisQebzDto? _satisMelumatlari;

    /// <summary>
    /// Verilmiş satış məlumatları əsasında qəbzi çap edir.
    /// </summary>
    public void SatisiCapEt(SatisQebzDto satisMelumatlari)
    {
        _satisMelumatlari = satisMelumatlari;

        PrintDocument printDocument = new PrintDocument();
        PrintDialog printDialog = new PrintDialog { Document = printDocument };

        // PrintPage hadisəsinə abunə oluruq. Əsas çap məntiqi bu hadisədə baş verir.
        printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);

        // İstifadəçi printer seçib OK klikləyərsə, çap prosesini başlat
        if (printDialog.ShowDialog() == DialogResult.OK)
        {
            printDocument.Print();
        }
    }

    /// <summary>
    /// Bu metod hər səhifə çap edilərkən çağırılır və səhifənin "rəsmini" çəkir.
    /// </summary>
    private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
    {
        if (_satisMelumatlari == null || e.Graphics == null) return;

        // Qrafik obyekt və istifadə edəcəyimiz şriftlər
        Graphics g = e.Graphics;
        Font basliqFontu = new Font("Courier New", 12, FontStyle.Bold);
        Font normalFont = new Font("Courier New", 10, FontStyle.Regular);
        Font kicikFont = new Font("Courier New", 8, FontStyle.Regular);

        float yPos = 0;
        float solMesafe = 10;
        float ustMesafe = 10;
        float qebzEni = 280; // Qəbzin təxmini eni

        // Başlıq hissəsi
        string sirketAdi = "AzAgroPOS Satış Sistemi";
        var olcu = g.MeasureString(sirketAdi, basliqFontu);
        g.DrawString(sirketAdi, basliqFontu, Brushes.Black, solMesafe + (qebzEni - olcu.Width) / 2, ustMesafe + yPos);
        yPos += olcu.Height;

        string ayiriciXett = "------------------------------";
        g.DrawString(ayiriciXett, normalFont, Brushes.Black, solMesafe, ustMesafe + yPos);
        yPos += normalFont.GetHeight();

        // Məlumatlar
        g.DrawString($"Qəbz ID: {_satisMelumatlari.SatisId}", kicikFont, Brushes.Black, solMesafe, ustMesafe + yPos);
        yPos += kicikFont.GetHeight();
        g.DrawString($"Kassir: {_satisMelumatlari.KassirAdi}", kicikFont, Brushes.Black, solMesafe, ustMesafe + yPos);
        yPos += kicikFont.GetHeight();
        g.DrawString($"Tarix: {_satisMelumatlari.Tarix:dd.MM.yyyy HH:mm:ss}", kicikFont, Brushes.Black, solMesafe, ustMesafe + yPos);
        yPos += kicikFont.GetHeight();
        g.DrawString(ayiriciXett, normalFont, Brushes.Black, solMesafe, ustMesafe + yPos);
        yPos += normalFont.GetHeight() + 10;

        // Satılan məhsulların siyahısı
        foreach (var mehsul in _satisMelumatlari.SatilanMehsullar)
        {
            // Məhsulun adını və sayını yazırıq
            g.DrawString($"{mehsul.Miqdar} x {mehsul.MehsulAdi}", normalFont, Brushes.Black, solMesafe, ustMesafe + yPos);

            // Məbləği sağa düzləndirərək yazırıq
            string meblegStr = $"{mehsul.UmumiMebleg:N2}";
            var meblegOlcusu = g.MeasureString(meblegStr, normalFont);
            g.DrawString(meblegStr, normalFont, Brushes.Black, solMesafe + qebzEni - meblegOlcusu.Width, ustMesafe + yPos);

            yPos += normalFont.GetHeight();
        }

        yPos += 10;
        g.DrawString(ayiriciXett, normalFont, Brushes.Black, solMesafe, ustMesafe + yPos);
        yPos += normalFont.GetHeight();

        // Yekun məbləğ
        string yekunStr = $"CƏMİ: {_satisMelumatlari.CemiMebleg:N2} AZN";
        var yekunOlcu = g.MeasureString(yekunStr, basliqFontu);
        g.DrawString(yekunStr, basliqFontu, Brushes.Black, solMesafe + qebzEni - yekunOlcu.Width, ustMesafe + yPos);
        yPos += basliqFontu.GetHeight() + 20;

        // Alt hissə
        string tesekkur = "Bizi seçdiyiniz üçün təşəkkür edirik!";
        olcu = g.MeasureString(tesekkur, normalFont);
        g.DrawString(tesekkur, normalFont, Brushes.Black, solMesafe + (qebzEni - olcu.Width) / 2, ustMesafe + yPos);
    }
}