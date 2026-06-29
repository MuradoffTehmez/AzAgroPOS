using AzAgroPOS.Teqdimat.Sabitler;

namespace AzAgroPOS.Teqdimat.Yardimcilar
{
    /// <summary>
    /// Konfiqurasiya validasiyası üçün nəticə
    /// </summary>
    public class ValidasiyaNeticesi
    {
        public bool UgurludurMu { get; set; }
        public List<string> Xetalar { get; set; } = new List<string>();

        public string XetalariGoster()
        {
            return string.Join(Environment.NewLine, Xetalar);
        }
    }

    /// <summary>
    /// Konfiqurasiya parametrlərinin validasiyası
    /// </summary>
    public static class KonfiqurasiyaValidasiyasi
    {
        /// <summary>
        /// Şirkət adını yoxlayır
        /// </summary>
        public static ValidasiyaNeticesi SirketAdiValidet(string ad)
        {
            ValidasiyaNeticesi netice = new() { UgurludurMu = true };

            if (string.IsNullOrWhiteSpace(ad))
            {
                netice.UgurludurMu = false;
                netice.Xetalar.Add("Şirkət adı " + KonfiqurasiyaSabitleri.XetaMesajlari.TelebeXetasi.ToLower());
            }
            else if (ad.Length < 3)
            {
                netice.UgurludurMu = false;
                netice.Xetalar.Add("Şirkət adı ən azı 3 simvoldan ibarət olmalıdır");
            }
            else if (ad.Length > 200)
            {
                netice.UgurludurMu = false;
                netice.Xetalar.Add("Şirkət adı 200 simvoldan çox ola bilməz");
            }

            return netice;
        }

        /// <summary>
        /// VÖEN-i yoxlayır (10 rəqəm)
        /// </summary>
        public static ValidasiyaNeticesi VoenValidet(string voen)
        {
            ValidasiyaNeticesi netice = new() { UgurludurMu = true };

            if (string.IsNullOrWhiteSpace(voen))
            {
                // VÖEN məcburi deyil, boş ola bilər
                return netice;
            }

            if (!KonfiqurasiyaSabitleri.Validasiya.VoenPattern.IsMatch(voen))
            {
                netice.UgurludurMu = false;
                netice.Xetalar.Add(KonfiqurasiyaSabitleri.XetaMesajlari.VoenFormatXetasi);
            }

            return netice;
        }

        /// <summary>
        /// Email ünvanını yoxlayır
        /// </summary>
        public static ValidasiyaNeticesi EmailValidet(string email)
        {
            ValidasiyaNeticesi netice = new() { UgurludurMu = true };

            if (string.IsNullOrWhiteSpace(email))
            {
                // Email məcburi deyil
                return netice;
            }

            if (!KonfiqurasiyaSabitleri.Validasiya.EmailPattern.IsMatch(email))
            {
                netice.UgurludurMu = false;
                netice.Xetalar.Add(KonfiqurasiyaSabitleri.XetaMesajlari.EmailFormatXetasi);
            }

            return netice;
        }

        /// <summary>
        /// Telefon nömrəsini yoxlayır
        /// </summary>
        public static ValidasiyaNeticesi TelefonValidet(string telefon)
        {
            ValidasiyaNeticesi netice = new() { UgurludurMu = true };

            if (string.IsNullOrWhiteSpace(telefon))
            {
                // Telefon məcburi deyil
                return netice;
            }

            if (!KonfiqurasiyaSabitleri.Validasiya.TelefonPattern.IsMatch(telefon))
            {
                netice.UgurludurMu = false;
                netice.Xetalar.Add(KonfiqurasiyaSabitleri.XetaMesajlari.TelefonFormatXetasi);
            }

            return netice;
        }

        /// <summary>
        /// URL-i yoxlayır
        /// </summary>
        public static ValidasiyaNeticesi UrlValidet(string url)
        {
            ValidasiyaNeticesi netice = new() { UgurludurMu = true };

            if (string.IsNullOrWhiteSpace(url))
            {
                // URL məcburi deyil
                return netice;
            }

            if (!KonfiqurasiyaSabitleri.Validasiya.UrlPattern.IsMatch(url))
            {
                netice.UgurludurMu = false;
                netice.Xetalar.Add(KonfiqurasiyaSabitleri.XetaMesajlari.UrlFormatXetasi);
            }

            return netice;
        }

        /// <summary>
        /// ƏDV dərəcəsini yoxlayır
        /// </summary>
        public static ValidasiyaNeticesi EdvDerecesiValidet(decimal derece)
        {
            ValidasiyaNeticesi netice = new() { UgurludurMu = true };

            if (derece is < KonfiqurasiyaSabitleri.Validasiya.EdvMinimum or
                > KonfiqurasiyaSabitleri.Validasiya.EdvMaksimum)
            {
                netice.UgurludurMu = false;
                netice.Xetalar.Add(KonfiqurasiyaSabitleri.XetaMesajlari.EdvDerecesiXetasi);
            }

            return netice;
        }

        /// <summary>
        /// Sessiya timeout-u yoxlayır
        /// </summary>
        public static ValidasiyaNeticesi SessiyaTimeoutValidet(int timeout)
        {
            ValidasiyaNeticesi netice = new() { UgurludurMu = true };

            if (timeout is < KonfiqurasiyaSabitleri.Validasiya.SessiyaTimeoutMinimum or
                > KonfiqurasiyaSabitleri.Validasiya.SessiyaTimeoutMaksimum)
            {
                netice.UgurludurMu = false;
                netice.Xetalar.Add(KonfiqurasiyaSabitleri.XetaMesajlari.SessiyaTimeoutXetasi);
            }

            return netice;
        }

        /// <summary>
        /// Saat formatını yoxlayır (HH:mm)
        /// </summary>
        public static ValidasiyaNeticesi SaatValidet(string saat)
        {
            ValidasiyaNeticesi netice = new() { UgurludurMu = true };

            if (string.IsNullOrWhiteSpace(saat))
            {
                netice.UgurludurMu = false;
                netice.Xetalar.Add("Saat " + KonfiqurasiyaSabitleri.XetaMesajlari.TelebeXetasi.ToLower());
                return netice;
            }

            if (!KonfiqurasiyaSabitleri.Validasiya.SaatPattern.IsMatch(saat))
            {
                netice.UgurludurMu = false;
                netice.Xetalar.Add(KonfiqurasiyaSabitleri.XetaMesajlari.SaatFormatXetasi);
            }

            return netice;
        }

        /// <summary>
        /// Printer adını yoxlayır
        /// </summary>
        public static ValidasiyaNeticesi PrinterValidet(string printerAdi, bool mecburidir = false)
        {
            ValidasiyaNeticesi netice = new() { UgurludurMu = true };

            if (string.IsNullOrWhiteSpace(printerAdi))
            {
                if (mecburidir)
                {
                    netice.UgurludurMu = false;
                    netice.Xetalar.Add("Printer adı " + KonfiqurasiyaSabitleri.XetaMesajlari.TelebeXetasi.ToLower());
                }
                return netice;
            }

            // Printer-in sistemdə olub-olmadığını yoxla
            if (!PrinterHelper.PrinterMovcuddurMu(printerAdi))
            {
                netice.UgurludurMu = false;
                netice.Xetalar.Add(KonfiqurasiyaSabitleri.XetaMesajlari.PrinterTapilmadiXetasi);
            }

            return netice;
        }

        /// <summary>
        /// Bütün konfiqurasiya parametrlərini yoxlayır
        /// </summary>
        public static ValidasiyaNeticesi ButunParametrleriValidet(
            string sirketAdi,
            string sirketUnvani,
            string sirketVoen,
            string sirketTelefon,
            string sirketEmail,
            string sirketVebSayt,
            decimal edvDerecesi,
            string qebzPrinteri,
            string barkodPrinteri,
            string yedeklemeSaati,
            int sessiyaTimeout)
        {
            ValidasiyaNeticesi netice = new() { UgurludurMu = true };

            // Şirkət adı (məcburi)
            ValidasiyaNeticesi sirketAdiNetice = SirketAdiValidet(sirketAdi);
            if (!sirketAdiNetice.UgurludurMu)
            {
                netice.UgurludurMu = false;
                netice.Xetalar.AddRange(sirketAdiNetice.Xetalar);
            }

            // VÖEN (məcburi deyil)
            ValidasiyaNeticesi voenNetice = VoenValidet(sirketVoen);
            if (!voenNetice.UgurludurMu)
            {
                netice.UgurludurMu = false;
                netice.Xetalar.AddRange(voenNetice.Xetalar);
            }

            // Telefon (məcburi deyil)
            ValidasiyaNeticesi telefonNetice = TelefonValidet(sirketTelefon);
            if (!telefonNetice.UgurludurMu)
            {
                netice.UgurludurMu = false;
                netice.Xetalar.AddRange(telefonNetice.Xetalar);
            }

            // Email (məcburi deyil)
            ValidasiyaNeticesi emailNetice = EmailValidet(sirketEmail);
            if (!emailNetice.UgurludurMu)
            {
                netice.UgurludurMu = false;
                netice.Xetalar.AddRange(emailNetice.Xetalar);
            }

            // URL (məcburi deyil)
            if (!string.IsNullOrWhiteSpace(sirketVebSayt))
            {
                ValidasiyaNeticesi urlNetice = UrlValidet(sirketVebSayt);
                if (!urlNetice.UgurludurMu)
                {
                    netice.UgurludurMu = false;
                    netice.Xetalar.AddRange(urlNetice.Xetalar);
                }
            }

            // ƏDV dərəcəsi
            ValidasiyaNeticesi edvNetice = EdvDerecesiValidet(edvDerecesi);
            if (!edvNetice.UgurludurMu)
            {
                netice.UgurludurMu = false;
                netice.Xetalar.AddRange(edvNetice.Xetalar);
            }

            // Printerlər (məcburi deyil, amma doldurulubsa yoxlanmalı)
            if (!string.IsNullOrWhiteSpace(qebzPrinteri))
            {
                ValidasiyaNeticesi qebzPrinterNetice = PrinterValidet(qebzPrinteri, false);
                if (!qebzPrinterNetice.UgurludurMu)
                {
                    netice.UgurludurMu = false;
                    netice.Xetalar.AddRange(qebzPrinterNetice.Xetalar.Select(x => "Qəbz printeri: " + x));
                }
            }

            if (!string.IsNullOrWhiteSpace(barkodPrinteri))
            {
                ValidasiyaNeticesi barkodPrinterNetice = PrinterValidet(barkodPrinteri, false);
                if (!barkodPrinterNetice.UgurludurMu)
                {
                    netice.UgurludurMu = false;
                    netice.Xetalar.AddRange(barkodPrinterNetice.Xetalar.Select(x => "Barkod printeri: " + x));
                }
            }

            // Yedekləmə saatı (məcburi deyil, amma doldurulubsa yoxlanmalı)
            if (!string.IsNullOrWhiteSpace(yedeklemeSaati))
            {
                ValidasiyaNeticesi saatNetice = SaatValidet(yedeklemeSaati);
                if (!saatNetice.UgurludurMu)
                {
                    netice.UgurludurMu = false;
                    netice.Xetalar.AddRange(saatNetice.Xetalar);
                }
            }

            // Sessiya timeout
            ValidasiyaNeticesi timeoutNetice = SessiyaTimeoutValidet(sessiyaTimeout);
            if (!timeoutNetice.UgurludurMu)
            {
                netice.UgurludurMu = false;
                netice.Xetalar.AddRange(timeoutNetice.Xetalar);
            }

            return netice;
        }
    }
}
