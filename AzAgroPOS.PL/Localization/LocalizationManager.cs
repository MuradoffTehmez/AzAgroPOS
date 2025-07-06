using System;
using System.Globalization;
using System.Threading;

// Namespace-in düzgün olduğundan əmin olun
namespace AzAgroPOS.PL.Localization
{
    /// <summary>
    /// Proqramın dilini mərkəzləşdirilmiş şəkildə idarə edir və dəyişiklik barədə xəbər verir.
    /// </summary>
    // Sinifin public və static olduğundan əmin olun
    public static class LocalizationManager
    {
        public static event Action LanguageChanged;

        /// <summary>
        /// Proqramın hazırkı UI dilini təyin edir və abunəçilərə xəbər verir.
        /// </summary>
        /// <param name="culture">Tətbiq ediləcək dilin kodu (məs. "en" və ya "az-Latn-AZ").</param>
        public static void SetLanguage(string culture)
        {
            if (string.IsNullOrEmpty(culture))
            {
                culture = "az-Latn-AZ"; // Standart dil
            }

            try
            {
                var cultureInfo = new CultureInfo(culture);
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = cultureInfo;

                // Dil dəyişdikdən sonra hadisəni (event) işə salırıq
                LanguageChanged?.Invoke();
            }
            catch (CultureNotFoundException)
            {
                // Əgər yaddaşda səhv bir kod varsa, standart dilə qayıdırıq
                SetLanguage("az-Latn-AZ");
            }
        }
    }
}