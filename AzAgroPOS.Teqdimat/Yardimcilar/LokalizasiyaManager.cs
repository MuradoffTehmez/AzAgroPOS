// Fayl: AzAgroPOS.Teqdimat/Yardimcilar/LokalizasiyaManager.cs
namespace AzAgroPOS.Teqdimat.Yardimcilar;

using System.Globalization;
using System.Threading;

public static class LokalizasiyaManager
{
    /// <summary>
    /// Proqramın cari mədəniyyətini (dilini) dəyişir.
    /// </summary>
    /// <param name="cultureCode">Dəyişmək istədiyiniz dilin kodu (məs: "az-AZ" və ya "en-US").</param>
    public static void SetCulture(string cultureCode)
    {
        try
        {
            CultureInfo cultureInfo = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
        catch (CultureNotFoundException)
        {
            CultureInfo defaultCulture = new CultureInfo("az-AZ");
            Thread.CurrentThread.CurrentCulture = defaultCulture;
            Thread.CurrentThread.CurrentUICulture = defaultCulture;
        }
    }
}