using AzAgroPOS.Entities;
using AzAgroPOS.BLL.Helpers;

namespace AzAgroPOS.BLL.Services
{
    public class BarkodService
    {
        /// <summary>
        /// Verilmiş məhsul üçün ZPL formatında etiket kodu yaradır.
        /// </summary>
        public string GenerateZplForProduct(Mehsul mehsul)
        {
            string mehsulAdi = mehsul.Ad.Length > 25 ? mehsul.Ad.Substring(0, 25) : mehsul.Ad;
            string qiymet = mehsul.SatisQiymeti.ToString("F2") + " AZN";

            // Sizin təqdim etdiyiniz ZPL şablonuna əsaslanan dinamik kod
            string zplCode =
                "^XA" +
                "^FO50,50^BY2,2,80" + // Barkodun ölçüsü və hündürlüyü
                "^BCN,80,Y,N,N" +    // Code 128 barkodu
                $"^FD{mehsul.Barkod}^FS" +
                $"^FO50,170^A0N,30,30^FD{mehsulAdi}^FS" + // Məhsul adı
                $"^FO50,210^A0N,35,35^FD{qiymet}^FS" + // Məhsul qiyməti
                "^XZ";

            return zplCode;
        }

        /// <summary>
        /// Verilmiş ZPL kodunu seçilmiş printerə göndərir.
        /// </summary>
        public bool PrintZpl(string zplString, string printerName)
        {
            return RawPrinterHelper.SendStringToPrinter(printerName, zplString);
        }
    }
}