using AzAgroPOS.BLL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzAgroPOS.BLL.Services
{
    /// <summary>
    /// Barkod generasiyası və çapı ilə bağlı xidmətləri təmin edir.
    /// </summary>
    public class BarkodService
    {
        /// <summary>
        /// Verilmiş məhsul üçün ZPL (Zebra Programming Language) formatında etiket kodu yaradır.
        /// </summary>
        /// <param name="mehsul">Barkodu yaradılacaq məhsul</param>
        /// <returns>Yaradılmış ZPL kodu</returns>
        /// <exception cref="ArgumentNullException">mehsul parametri null olduqda baş verir</exception>
        public string GenerateZplForProduct(Mehsul mehsul)
        {
            if (mehsul == null)
            {
                throw new ArgumentNullException(nameof(mehsul), "Məhsul məlumatları boş ola bilməz");
            }

            try
            {
                // Məhsul adını 25 simvoldan çoxdursa qısaldırıq
                string mehsulAdi = mehsul.Ad.Length > 25 ? mehsul.Ad.Substring(0, 25) : mehsul.Ad;
                string qiymet = mehsul.SatisQiymeti.ToString("F2") + " AZN";

                // ZPL kodu yaradırıq
                string zplCode =
                    "^XA" + // ZPL kodu başlanğıcı
                    "^FO50,50^BY2,2,80" + // Barkodun yeri və ölçüsü
                    "^BCN,80,Y,N,N" + // Code 128 barkod növü
                    $"^FD{mehsul.Barkod}^FS" + // Barkod məlumatı
                    $"^FO50,170^A0N,30,30^FD{mehsulAdi}^FS" + // Məhsul adı
                    $"^FO50,210^A0N,35,35^FD{qiymet}^FS" + // Məhsul qiyməti
                    "^XZ"; // ZPL kodu sonu

                return zplCode;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ZPL kodu yaradılarkən xəta: {ex.Message}");
                throw new ApplicationException("ZPL kodu yaradıla bilmədi", ex);
            }
        }

        /// <summary>
        /// Verilmiş ZPL kodunu seçilmiş printerə göndərir.
        /// </summary>
        /// <param name="zplString">Çap ediləcək ZPL kodu</param>
        /// <param name="printerName">Printerin adı</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı</returns>
        /// <exception cref="ArgumentException">zplString boş və ya null olduqda baş verir</exception>
        public bool PrintZpl(string zplString, string printerName)
        {
            if (string.IsNullOrWhiteSpace(zplString))
            {
                throw new ArgumentException("ZPL kodu boş ola bilməz", nameof(zplString));
            }

            try
            {
                return RawPrinterHelper.SendStringToPrinter(printerName, zplString);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Çap zamanı xəta: {ex.Message}");
                throw new ApplicationException("Çap uğursuz oldu", ex);
            }
        }

        /// <summary>
        /// Bir siyahı dolusu ZPL kodunu birləşdirərək tək bir tapşırıqla printerə göndərir.
        /// </summary>
        /// <param name="zplStrings">Çap ediləcək ZPL kodlarının siyahısı</param>
        /// <param name="printerName">Printerin adı</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı</returns>
        /// <exception cref="ArgumentNullException">zplStrings parametri null olduqda baş verir</exception>
        public bool Print(List<string> zplStrings, string printerName)
        {
            if (zplStrings == null)
            {
                throw new ArgumentNullException(nameof(zplStrings), "ZPL kodlarının siyahısı boş ola bilməz");
            }

            if (zplStrings.Count == 0)
            {
                return false;
            }

            try
            {
                // Bütün ZPL kodlarını tək bir mətnə birləşdiririk
                StringBuilder fullZpl = new StringBuilder();
                foreach (var zpl in zplStrings)
                {
                    if (!string.IsNullOrWhiteSpace(zpl))
                    {
                        fullZpl.Append(zpl);
                    }
                }

                return RawPrinterHelper.SendStringToPrinter(printerName, fullZpl.ToString());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Toplu çap zamanı xəta: {ex.Message}");
                throw new ApplicationException("Toplu çap uğursuz oldu", ex);
            }
        }
    }
}