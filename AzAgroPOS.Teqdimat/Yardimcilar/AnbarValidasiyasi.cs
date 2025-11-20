using AzAgroPOS.Teqdimat.Sabitler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AzAgroPOS.Teqdimat.Yardimcilar
{
    /// <summary>
    /// Anbar formu üçün validasiya yardımçı sinfi
    /// </summary>
    public static class AnbarValidasiyasi
    {
        #region Validasiya Nəticəsi

        /// <summary>
        /// Validasiya nəticəsi sinfi
        /// </summary>
        public class ValidasiyaNeticesi
        {
            public bool UgurludurMu { get; set; }
            public List<string> Xetalar { get; set; } = new List<string>();

            public string XetalariGoster()
            {
                return string.Join(Environment.NewLine, Xetalar);
            }

            public void XetaElaveEt(string xeta)
            {
                if (!string.IsNullOrWhiteSpace(xeta))
                {
                    Xetalar.Add(xeta);
                    UgurludurMu = false;
                }
            }
        }

        #endregion

        #region Axtarış Validasiyası

        /// <summary>
        /// Axtarış mətni validasiyası
        /// </summary>
        public static ValidasiyaNeticesi AxtarisMetniValidet(string axtarisMetni)
        {
            var netice = new ValidasiyaNeticesi { UgurludurMu = true };

            // Boş olub-olmadığını yoxla
            if (string.IsNullOrWhiteSpace(axtarisMetni))
            {
                netice.XetaElaveEt(AnbarSabitleri.XetaMesajlari.AxtarisMetniTelebelidir);
                return netice;
            }

            // Format yoxlaması
            if (!AnbarSabitleri.Validasiya.BarkodPattern.IsMatch(axtarisMetni.Trim()))
            {
                netice.XetaElaveEt(AnbarSabitleri.XetaMesajlari.BarkodFormatXetasi);
            }

            return netice;
        }

        #endregion

        #region Say Validasiyası

        /// <summary>
        /// Say input-u validasiya edir
        /// </summary>
        public static ValidasiyaNeticesi SayValidet(string sayMetni, bool telebe = true)
        {
            var netice = new ValidasiyaNeticesi { UgurludurMu = true };

            // Boş olub-olmadığını yoxla
            if (string.IsNullOrWhiteSpace(sayMetni))
            {
                if (telebe)
                {
                    netice.XetaElaveEt(AnbarSabitleri.XetaMesajlari.SayTelebelidir);
                }
                return netice;
            }

            // Rəqəm formatında olub-olmadığını yoxla
            if (!decimal.TryParse(sayMetni.Trim(), out decimal say))
            {
                netice.XetaElaveEt(AnbarSabitleri.XetaMesajlari.SayReqemOlmalidir);
                return netice;
            }

            // Müsbət olub-olmadığını yoxla
            if (say <= 0)
            {
                netice.XetaElaveEt(AnbarSabitleri.XetaMesajlari.SayMusbetOlmalidir);
                return netice;
            }

            // Minimum dəyəri yoxla
            if (say < AnbarSabitleri.Validasiya.MinimumSay)
            {
                netice.XetaElaveEt(string.Format(
                    AnbarSabitleri.XetaMesajlari.SayCoxKicikdir,
                    AnbarSabitleri.Validasiya.MinimumSay));
                return netice;
            }

            // Maksimum dəyəri yoxla
            if (say > AnbarSabitleri.Validasiya.MaksimumSay)
            {
                netice.XetaElaveEt(string.Format(
                    AnbarSabitleri.XetaMesajlari.SayCoxBoyukdur,
                    AnbarSabitleri.Validasiya.MaksimumSay));
                return netice;
            }

            // Format yoxlaması (məs: 10.50, 100.5 qəbul edir, 10.505 qəbul etmir)
            if (!AnbarSabitleri.Validasiya.ReqemPattern.IsMatch(sayMetni.Trim()))
            {
                netice.XetaElaveEt(AnbarSabitleri.XetaMesajlari.SayFormatXetasi);
            }

            return netice;
        }

        /// <summary>
        /// Say input-u decimal olaraq validasiya edir
        /// </summary>
        public static ValidasiyaNeticesi SayValidet(decimal say)
        {
            var netice = new ValidasiyaNeticesi { UgurludurMu = true };

            // Müsbət olub-olmadığını yoxla
            if (say <= 0)
            {
                netice.XetaElaveEt(AnbarSabitleri.XetaMesajlari.SayMusbetOlmalidir);
                return netice;
            }

            // Minimum dəyəri yoxla
            if (say < AnbarSabitleri.Validasiya.MinimumSay)
            {
                netice.XetaElaveEt(string.Format(
                    AnbarSabitleri.XetaMesajlari.SayCoxKicikdir,
                    AnbarSabitleri.Validasiya.MinimumSay));
                return netice;
            }

            // Maksimum dəyəri yoxla
            if (say > AnbarSabitleri.Validasiya.MaksimumSay)
            {
                netice.XetaElaveEt(string.Format(
                    AnbarSabitleri.XetaMesajlari.SayCoxBoyukdur,
                    AnbarSabitleri.Validasiya.MaksimumSay));
                return netice;
            }

            return netice;
        }

        #endregion

        #region Stok Azaltma Validasiyası

        /// <summary>
        /// Stok azaltma əməliyyatı üçün validasiya
        /// </summary>
        public static ValidasiyaNeticesi StokAzaltmaValidet(decimal movcudStok, decimal azaltilacaqSay)
        {
            var netice = new ValidasiyaNeticesi { UgurludurMu = true };

            // Say validasiyası
            var sayNetice = SayValidet(azaltilacaqSay);
            if (!sayNetice.UgurludurMu)
            {
                netice.Xetalar.AddRange(sayNetice.Xetalar);
                netice.UgurludurMu = false;
                return netice;
            }

            // Mövcud stok kifayət edirmi?
            if (azaltilacaqSay > movcudStok)
            {
                netice.XetaElaveEt(string.Format(
                    AnbarSabitleri.XetaMesajlari.MovcudStokKifayetDeyil,
                    movcudStok,
                    azaltilacaqSay));
                return netice;
            }

            // Stok mənfi olacaqmı?
            if (movcudStok - azaltilacaqSay < 0)
            {
                netice.XetaElaveEt(AnbarSabitleri.XetaMesajlari.StokMenfiOlaBilmez);
            }

            return netice;
        }

        #endregion

        #region Qeyd Validasiyası

        /// <summary>
        /// Qeyd/Səbəb validasiyası
        /// </summary>
        public static ValidasiyaNeticesi QeydValidet(string qeyd, bool telebe = false)
        {
            var netice = new ValidasiyaNeticesi { UgurludurMu = true };

            // Boş olub-olmadığını yoxla (tələb olunarsa)
            if (string.IsNullOrWhiteSpace(qeyd))
            {
                if (telebe)
                {
                    netice.XetaElaveEt(AnbarSabitleri.XetaMesajlari.QeydTelebelidir);
                }
                return netice;
            }

            qeyd = qeyd.Trim();

            // Minimum uzunluq yoxlaması
            if (qeyd.Length < AnbarSabitleri.Validasiya.MinimumQeydUzunlugu)
            {
                netice.XetaElaveEt(string.Format(
                    AnbarSabitleri.XetaMesajlari.QeydCoxQisadir,
                    AnbarSabitleri.Validasiya.MinimumQeydUzunlugu));
            }

            // Maksimum uzunluq yoxlaması
            if (qeyd.Length > AnbarSabitleri.Validasiya.MaksimumQeydUzunlugu)
            {
                netice.XetaElaveEt(string.Format(
                    AnbarSabitleri.XetaMesajlari.QeydCoxUzundur,
                    AnbarSabitleri.Validasiya.MaksimumQeydUzunlugu));
            }

            return netice;
        }

        #endregion

        #region Stok Artırma Validasiyası

        /// <summary>
        /// Stok artırma əməliyyatı üçün tam validasiya
        /// </summary>
        public static ValidasiyaNeticesi StokArtirmaValidet(
            string axtarisMetni,
            string sayMetni,
            string qeyd = null)
        {
            var netice = new ValidasiyaNeticesi { UgurludurMu = true };

            // Axtarış mətni validasiyası
            var axtarisNetice = AxtarisMetniValidet(axtarisMetni);
            if (!axtarisNetice.UgurludurMu)
            {
                netice.Xetalar.AddRange(axtarisNetice.Xetalar);
                netice.UgurludurMu = false;
            }

            // Say validasiyası
            var sayNetice = SayValidet(sayMetni);
            if (!sayNetice.UgurludurMu)
            {
                netice.Xetalar.AddRange(sayNetice.Xetalar);
                netice.UgurludurMu = false;
            }

            // Qeyd validasiyası (opsional)
            if (!string.IsNullOrWhiteSpace(qeyd))
            {
                var qeydNetice = QeydValidet(qeyd, false);
                if (!qeydNetice.UgurludurMu)
                {
                    netice.Xetalar.AddRange(qeydNetice.Xetalar);
                    netice.UgurludurMu = false;
                }
            }

            return netice;
        }

        #endregion

        #region Məhsul Seçimi Validasiyası

        /// <summary>
        /// Məhsulun seçilmiş olub-olmadığını yoxlayır
        /// </summary>
        public static ValidasiyaNeticesi MehsulSecilmisValidet(int? mehsulId)
        {
            var netice = new ValidasiyaNeticesi { UgurludurMu = true };

            if (!mehsulId.HasValue || mehsulId.Value <= 0)
            {
                netice.XetaElaveEt(AnbarSabitleri.XetaMesajlari.MehsulSecilmeyib);
            }

            return netice;
        }

        #endregion

        #region Stok Düzəliş Validasiyası

        /// <summary>
        /// Stok düzəliş əməliyyatı validasiyası
        /// </summary>
        public static ValidasiyaNeticesi StokDuzelisValidet(
            decimal yeniStok,
            string qeyd)
        {
            var netice = new ValidasiyaNeticesi { UgurludurMu = true };

            // Yeni stok mənfi ola bilməz
            if (yeniStok < 0)
            {
                netice.XetaElaveEt(AnbarSabitleri.XetaMesajlari.StokMenfiOlaBilmez);
            }

            // Maksimum stok yoxlaması
            if (yeniStok > AnbarSabitleri.Validasiya.MaksimumSay)
            {
                netice.XetaElaveEt(string.Format(
                    AnbarSabitleri.XetaMesajlari.SayCoxBoyukdur,
                    AnbarSabitleri.Validasiya.MaksimumSay));
            }

            // Qeyd mütləq olmalıdır stok düzəliş üçün
            var qeydNetice = QeydValidet(qeyd, true);
            if (!qeydNetice.UgurludurMu)
            {
                netice.Xetalar.AddRange(qeydNetice.Xetalar);
                netice.UgurludurMu = false;
            }

            return netice;
        }

        #endregion

        #region Xəbərdarlıq Yoxlamaları

        /// <summary>
        /// Stok sıfır olacaq xəbərdarlığı
        /// </summary>
        public static bool StokSifirOlacaqmi(decimal movcudStok, decimal azaltilacaqSay)
        {
            return movcudStok - azaltilacaqSay == 0;
        }

        /// <summary>
        /// Böyük miqdar azaltma xəbərdarlığı
        /// </summary>
        public static bool BoyukMiqdarAzaltmami(decimal movcudStok, decimal azaltilacaqSay)
        {
            // Əgər azaltma mövcud stokun 50%-dən çoxudursa
            return azaltilacaqSay > (movcudStok * 0.5m);
        }

        /// <summary>
        /// Minimum stok xəbərdarlığı
        /// </summary>
        public static bool MinimumStokSeviyyesiAltindami(decimal yeniStok, decimal minimumStok)
        {
            return minimumStok > 0 && yeniStok < minimumStok;
        }

        #endregion

        #region Yardımçı Metodlar

        /// <summary>
        /// String-i decimal-a çevirir, əgər mümkün deyilsə null qaytarır
        /// </summary>
        public static decimal? StringiDecimalaCevir(string metn)
        {
            if (string.IsNullOrWhiteSpace(metn))
                return null;

            if (decimal.TryParse(metn.Trim(), out decimal netice))
                return netice;

            return null;
        }

        /// <summary>
        /// Say input-unu təmizləyir (yalnız rəqəm və nöqtə saxlayır)
        /// </summary>
        public static string SayInputuTemizle(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Yalnız rəqəm, nöqtə və mənfi işarəsi saxla
            return new string(input.Where(c => char.IsDigit(c) || c == '.' || c == ',').ToArray())
                .Replace(',', '.'); // Vergülü nöqtəyə çevir
        }

        #endregion
    }
}
