// Fayl: AzAgroPOS.Mentiq/Yardimcilar/AsyncIslemYardimcisi.cs

using System;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace AzAgroPOS.Mentiq.Yardimcilar;
/// <summary>
/// Asinxron əməliyyatların idarə edilməsi üçün yardımçı sinif
/// diqqət: Bu sinif uzun çəkən əməliyyatlar zamanı UI-u dondurmağı qarşısını alır
/// qeyd: Background əməliyyatlar və istifadəçi geribildirimi üçün nəzərdə tutulub
/// </summary>
public static class AsyncIslemYardimcisi
{
    /// <summary>
    /// Asinxron əməliyyatı icra edir və UI-u bloklamadan nəticəni qaytarır
    /// diqqət: Əməliyyat zamanı göstərici və ya mesaj göstərə bilər
    /// qeyd: Task geri qaytaran metodlar üçün nəzərdə tutulub
    /// </summary>
    /// <typeparam name="T">Əməliyyatın nəticə tipi</typeparam>
    /// <param name="emeliyyat">İcra ediləcək asinxron əməliyyat</param>
    /// <param name="baslamaMesaji">Əməliyyat başlayarkən göstəriləcək mesaj</param>
    /// <param name="bitmeMesaji">Əməliyyat bitərkən göstəriləcək mesaj</param>
    /// <returns>Əməliyyat nəticəsi</returns>
    public static async Task<T> IslemIcraEtAsync<T>(
        Func<Task<T>> emeliyyat, 
        string? baslamaMesaji = null, 
        string? bitmeMesaji = null)
    {
        try
        {
            // Əməliyyat başlayır
            if (!string.IsNullOrWhiteSpace(baslamaMesaji))
            {
                Logger.MelumatYaz(baslamaMesaji);
            }

            var netice = await emeliyyat();

            // Əməliyyat bitdi
            if (!string.IsNullOrWhiteSpace(bitmeMesaji))
            {
                Logger.MelumatYaz(bitmeMesaji);
            }

            return netice;
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Asinxron əməliyyat zamanı xəta baş verdi");
            throw; // Xətayı yenidən atırıq ki, çağırıcı tərəf bunu idarə edə bilsin
        }
    }

    /// <summary>
    /// Void qaytaran asinxron əməliyyatı icra edir
    /// diqqət: Əməliyyat zamanı göstərici və ya mesaj göstərə bilər
    /// qeyd: Task dönüşü olmayan metodlar üçün nəzərdə tutulub
    /// </summary>
    /// <param name="emeliyyat">İcra ediləcək asinxron əməliyyat</param>
    /// <param name="baslamaMesaji">Əməliyyat başlayarkən göstəriləcək mesaj</param>
    /// <param name="bitmeMesaji">Əməliyyat bitərkən göstəriləcək mesaj</param>
    public static async Task IslemIcraEtAsync(
        Func<Task> emeliyyat, 
        string? baslamaMesaji = null, 
        string? bitmeMesaji = null)
    {
        try
        {
            // Əməliyyat başlayır
            if (!string.IsNullOrWhiteSpace(baslamaMesaji))
            {
                Logger.MelumatYaz(baslamaMesaji);
            }

            await emeliyyat();

            // Əməliyyat bitdi
            if (!string.IsNullOrWhiteSpace(bitmeMesaji))
            {
                Logger.MelumatYaz(bitmeMesaji);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Asinxron əməliyyat zamanı xəta baş verdi");
            throw; // Xətayı yenidən atırıq ki, çağırıcı tərəf bunu idarə edə bilsin
        }
    }

    /// <summary>
    /// Asinxron əməliyyatı icra edir və UI-u bloklamadan nəticəni qaytarır
    /// diqqət: Əməliyyat zamanı göstərici və ya mesaj göstərə bilər
    /// qeyd: BackgroundWorker-in asinxron versiyası kimi istifadə olunur
    /// </summary>
    /// <typeparam name="T">Əməliyyatın nəticə tipi</typeparam>
    /// <param name="emeliyyat">İcra ediləcək əməliyyat</param>
    /// <param name="yuklemeBasladi">Yükləmə başladıqda çağırılacaq metod (UI thread)</param>
    /// <param name="yuklemeBitti">Yükləmə bitdikdə çağırılacaq metod (UI thread)</param>
    /// <param name="yuklemeXeta">Xəta baş verdikdə çağırılacaq metod (UI thread)</param>
    /// <returns>Əməliyyat nəticəsi</returns>
    public static async Task<T?> IslemIcraEtAsync<T>(
        Func<Task<T>> emeliyyat,
        Action? yuklemeBasladi = null,
        Action<T>? yuklemeBitti = null,
        Action<Exception>? yuklemeXeta = null)
    {
        try
        {
            // Yükləmə başladı
            yuklemeBasladi?.Invoke();

            var netice = await emeliyyat();

            // Yükləmə bitdi
            yuklemeBitti?.Invoke(netice);

            return netice;
        }
        catch (Exception ex)
        {
            // Xəta baş verdi
            yuklemeXeta?.Invoke(ex);
            Logger.XetaYaz(ex, "Asinxron əməliyyat zamanı xəta baş verdi");
            return default(T); // Və ya uyğun nəticə qaytarılır
        }
    }
}