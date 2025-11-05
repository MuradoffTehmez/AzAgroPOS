// Fayl: AzAgroPOS.Mentiq/Yardimcilar/SifreValidator.cs
using System.Text.RegularExpressions;

namespace AzAgroPOS.Mentiq.Yardimcilar;

/// <summary>
/// Şifrə mürəkkəblik tələblərini yoxlayan validator
/// </summary>
public static class SifreValidator
{
    // Şifrə tələbləri
    public const int MinimumUzunluq = 8;
    public const int MaksimumUzunluq = 100;

    /// <summary>
    /// Şifrənin mürəkkəblik tələblərini yoxlayır
    /// Tələblər:
    /// - Minimum 8 simvol
    /// - Ən azı 1 böyük hərf
    /// - Ən azı 1 kiçik hərf
    /// - Ən azı 1 rəqəm
    /// - Ən azı 1 xüsusi simvol (@$!%*?&)
    /// </summary>
    public static (bool Kecerlidir, string Mesaj) Yoxla(string sifre)
    {
        if (string.IsNullOrWhiteSpace(sifre))
        {
            return (false, "Şifrə boş ola bilməz.");
        }

        if (sifre.Length < MinimumUzunluq)
        {
            return (false, $"Şifrə ən azı {MinimumUzunluq} simvoldan ibarət olmalıdır.");
        }

        if (sifre.Length > MaksimumUzunluq)
        {
            return (false, $"Şifrə maksimum {MaksimumUzunluq} simvoldan ibarət ola bilər.");
        }

        if (!Regex.IsMatch(sifre, @"[A-Z]"))
        {
            return (false, "Şifrədə ən azı 1 böyük hərf olmalıdır.");
        }

        if (!Regex.IsMatch(sifre, @"[a-z]"))
        {
            return (false, "Şifrədə ən azı 1 kiçik hərf olmalıdır.");
        }

        if (!Regex.IsMatch(sifre, @"[0-9]"))
        {
            return (false, "Şifrədə ən azı 1 rəqəm olmalıdır.");
        }

        if (!Regex.IsMatch(sifre, @"[@$!%*?&]"))
        {
            return (false, "Şifrədə ən azı 1 xüsusi simvol (@$!%*?&) olmalıdır.");
        }

        return (true, "Şifrə keçərlidir.");
    }

    /// <summary>
    /// Şifrənin güc səviyyəsini hesablayır (0-100)
    /// </summary>
    public static int GucSeviyyesiHesabla(string sifre)
    {
        if (string.IsNullOrWhiteSpace(sifre))
            return 0;

        int guc = 0;

        // Uzunluq (max 40 xal)
        guc += Math.Min(sifre.Length * 4, 40);

        // Böyük hərflər (10 xal)
        if (Regex.IsMatch(sifre, @"[A-Z]"))
            guc += 10;

        // Kiçik hərflər (10 xal)
        if (Regex.IsMatch(sifre, @"[a-z]"))
            guc += 10;

        // Rəqəmlər (10 xal)
        if (Regex.IsMatch(sifre, @"[0-9]"))
            guc += 10;

        // Xüsusi simvollar (10 xal)
        if (Regex.IsMatch(sifre, @"[@$!%*?&]"))
            guc += 10;

        // Müxtəlif simvol növləri (10 xal)
        int simvolNovleri = 0;
        if (Regex.IsMatch(sifre, @"[A-Z]")) simvolNovleri++;
        if (Regex.IsMatch(sifre, @"[a-z]")) simvolNovleri++;
        if (Regex.IsMatch(sifre, @"[0-9]")) simvolNovleri++;
        if (Regex.IsMatch(sifre, @"[@$!%*?&]")) simvolNovleri++;
        guc += simvolNovleri * 5;

        // Tekrar olunan simvolları cəzalandır
        var tekrarSay = sifre.Length - sifre.Distinct().Count();
        guc -= tekrarSay * 2;

        return Math.Clamp(guc, 0, 100);
    }
}
