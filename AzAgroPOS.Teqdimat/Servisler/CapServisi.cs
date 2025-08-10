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
        // Hansı printerdə çap ediləcəyini təyin etmək üçün PrintDialog göstəririk
        PrintDialog printDialog = new PrintDialog { Document = printDocument };

        // PrintPage hadisəsinə abunə oluruq. Əsas çap məntiqi bu hadisədə baş verir.
        printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);

        // İstifadəçi OK klikləyərsə, çap prosesini başlat
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
        int count = 0;
        float solEsneme = 10;
        float ustEsneme = 10;
        float xettUzunlugu = 280;

        // Başlıq
        g.DrawString("AzAgroPOS", basliqFontu, Brushes.Black, solEsneme + 80, ustEsneme + yPos);
        yPos += basliqFontu.GetHeight();
        g.DrawString("------------------------------", normalFont, Brushes.Black, solEsneme, ustEsneme + yPos);
        yPos += normalFont.GetHeight();

        // Məlumatlar
        g.DrawString($"Qəbz ID: {_satisMelumatlari.SatisId}", kicikFont, Brushes.Black, solEsneme, ustEsneme + yPos);
        yPos += kicikFont.GetHeight();
        g.DrawString($"Kassir: {_satisMelumatlari.KassirAdi}", kicikFont, Brushes.Black, solEsneme, ustEsneme + yPos);
        yPos += kicikFont.GetHeight();
        g.DrawString($"Tarix: {_satisMelumatlari.Tarix:dd.MM.yyyy HH:mm:ss}", kicikFont, Brushes.Black, solEsneme, ustEsneme + yPos);
        yPos += kicikFont.GetHeight();
        g.DrawString("------------------------------", normalFont, Brushes.Black, solEsneme, ustEsneme + yPos);
        yPos += normalFont.GetHeight() + 10;

        // Satılan məhsullar
        foreach (var mehsul in _satisMelumatlari.SatilanMehsullar)
        {
            // Məhsulun adını və sayını yaz
            g.DrawString($"{mehsul.Miqdar} x {mehsul.MehsulAdi}", normalFont, Brushes.Black, solEsneme, ustEsneme + yPos);

            // Məbləği sağa düzləndirərək yaz
            string meblegStr = $"{mehsul.UmumiMebleg:N2}";
            var meblegOlcusu = g.MeasureString(meblegStr, normalFont);
            g.DrawString(meblegStr, normalFont, Brushes.Black, solEsneme + xettUzunlugu - meblegOlcusu.Width, ustEsneme + yPos);

            yPos += normalFont.GetHeight();
        }

        yPos += 10;
        g.DrawString("------------------------------", normalFont, Brushes.Black, solEsneme, ustEsneme + yPos);
        yPos += normalFont.GetHeight();

        // Yekun məbləğ
        string yekunStr = $"CƏMİ: {_satisMelumatlari.CemiMebleg:N2} AZN";
        var yekunOlcu = g.MeasureString(yekunStr, basliqFontu);
        g.DrawString(yekunStr, basliqFontu, Brushes.Black, solEsneme + xettUzunlugu - yekunOlcu.Width, ustEsneme + yPos);
        yPos += basliqFontu.GetHeight() + 20;

        // Alt hissə
        g.DrawString("Bizi seçdiyiniz üçün", normalFont, Brushes.Black, solEsneme + 50, ustEsneme + yPos);
        yPos += normalFont.GetHeight();
        g.DrawString("təşəkkür edirik!", normalFont, Brushes.Black, solEsneme + 60, ustEsneme + yPos);
    }
}