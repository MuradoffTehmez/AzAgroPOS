// Fayl: AzAgroPOS.Teqdimat/Servisler/CapServisi.cs
namespace AzAgroPOS.Teqdimat.Servisler;

using AzAgroPOS.Mentiq.DTOs;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

/// <summary>
/// cap servisi, satış qəbzlərini çap etmək üçün istifadə olunur.
/// </summary>
public class CapServisi
{
    /// <summary>
    /// satış məlumatlarını saxlayan dəyişən.
    /// Dto obyektini istifadə edərək satış məlumatlarını saxlayır.
    /// </summary>
    private SatisQebzDto? _satisMelumatlari;

    /// <summary>
    /// bu metod, satış məlumatlarını alır və çap etmə prosesini başlatır.
    /// </summary>
    public void SatisiCapEt(SatisQebzDto satisMelumatlari)
    {
        // Əgər satış məlumatları null-dursa, heç nə etmirik
        _satisMelumatlari = satisMelumatlari;
        // Çap üçün PrintDocument və PrintDialog obyektlərini yaradırıq
        PrintDocument printDocument = new PrintDocument();
        // Çap üçün PrintDialog obyektini yaradırıq
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
    /// printDocument obyektinin PrintPage hadisəsinə abunə olunmuşdur.
    /// və çap ediləcək qəbzin bütün məlumatlarını burada göstəririk.
    /// səhifənin ölçüləri və qrafik obyektləri ilə işləyirik.
    /// dəyişən _satisMelumatlari istifadə edərək satış məlumatlarını çap edirik.
    /// məsələn, şirkət adı, kassir adı, tarix və satılan məhsulların siyahısı kimi məlumatları göstəririk.
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