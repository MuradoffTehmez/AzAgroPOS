// Fayl: AzAgroPOS.Mentiq/Yardimcilar/OperationExecutor.cs
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Istisnalar;

namespace AzAgroPOS.Mentiq.Yardimcilar;

/// <summary>
/// Generic operation executor - təkrarlanan try-catch-log pattern-ini aradan qaldırır
/// Bu class bütün Manager-lərdə olan təkrarlanan kodu azaldır və exception handling-i standartlaşdırır
/// </summary>
public static class OperationExecutor
{
    /// <summary>
    /// Sinxron əməliyyat icra edir və nəticəni geri qaytarır
    /// </summary>
    public static EmeliyyatNeticesi<T> Execute<T>(
        string operationName,
        Func<T> operation,
        string? successMessage = null)
    {
        Logger.MelumatYaz($"{operationName} əməliyyatı başladı");

        try
        {
            var result = operation();

            if (successMessage != null)
            {
                Logger.MelumatYaz(successMessage);
            }

            return EmeliyyatNeticesi<T>.Ugurlu(result);
        }
        catch (TesdiqIstisnasi ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Validasiya xətası: {ex.IstifadeciMesaji}");
            return EmeliyyatNeticesi<T>.Ugursuz(ex.IstifadeciMesaji);
        }
        catch (BiznesQaydasiIstisnasi ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Biznes qaydası pozuldu: {ex.IstifadeciMesaji}");
            return EmeliyyatNeticesi<T>.Ugursuz(ex.IstifadeciMesaji);
        }
        catch (MelumatTapilmadiIstisnasi ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Məlumat tapılmadı: {ex.IstifadeciMesaji}");
            return EmeliyyatNeticesi<T>.Ugursuz(ex.IstifadeciMesaji);
        }
        catch (TehlukesizlikIstisnasi ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Təhlükəsizlik xətası: {ex.IstifadeciMesaji}");
            return EmeliyyatNeticesi<T>.Ugursuz(ex.IstifadeciMesaji);
        }
        catch (VerilenlerBazasiIstisnasi ex)
        {
            Logger.XetaYaz(ex, $"{operationName} - Verilənlər bazası xətası");
            return EmeliyyatNeticesi<T>.Ugursuz(ex.IstifadeciMesaji);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, $"{operationName} zamanı gözlənilməz xəta baş verdi");
            return EmeliyyatNeticesi<T>.Ugursuz("Əməliyyat zamanı gözlənilməz xəta baş verdi. Zəhmət olmasa administrator ilə əlaqə saxlayın.");
        }
    }

    /// <summary>
    /// Sinxron əməliyyat icra edir (nəticəsiz)
    /// </summary>
    public static EmeliyyatNeticesi Execute(
        string operationName,
        Action operation,
        string? successMessage = null)
    {
        Logger.MelumatYaz($"{operationName} əməliyyatı başladı");

        try
        {
            operation();

            if (successMessage != null)
            {
                Logger.MelumatYaz(successMessage);
            }

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (TesdiqIstisnasi ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Validasiya xətası: {ex.IstifadeciMesaji}");
            return EmeliyyatNeticesi.Ugursuz(ex.IstifadeciMesaji);
        }
        catch (BiznesQaydasiIstisnasi ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Biznes qaydası pozuldu: {ex.IstifadeciMesaji}");
            return EmeliyyatNeticesi.Ugursuz(ex.IstifadeciMesaji);
        }
        catch (MelumatTapilmadiIstisnasi ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Məlumat tapılmadı: {ex.IstifadeciMesaji}");
            return EmeliyyatNeticesi.Ugursuz(ex.IstifadeciMesaji);
        }
        catch (TehlukesizlikIstisnasi ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Təhlükəsizlik xətası: {ex.IstifadeciMesaji}");
            return EmeliyyatNeticesi.Ugursuz(ex.IstifadeciMesaji);
        }
        catch (VerilenlerBazasiIstisnasi ex)
        {
            Logger.XetaYaz(ex, $"{operationName} - Verilənlər bazası xətası");
            return EmeliyyatNeticesi.Ugursuz(ex.IstifadeciMesaji);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, $"{operationName} zamanı gözlənilməz xəta baş verdi");
            return EmeliyyatNeticesi.Ugursuz("Əməliyyat zamanı gözlənilməz xəta baş verdi. Zəhmət olmasa administrator ilə əlaqə saxlayın.");
        }
    }

    /// <summary>
    /// Asinxron əməliyyat icra edir və nəticəni geri qaytarır
    /// </summary>
    public static async Task<EmeliyyatNeticesi<T>> ExecuteAsync<T>(
        string operationName,
        Func<Task<T>> operation,
        string? successMessage = null)
    {
        Logger.MelumatYaz($"{operationName} əməliyyatı başladı");

        try
        {
            var result = await operation();

            if (successMessage != null)
            {
                Logger.MelumatYaz(successMessage);
            }

            return EmeliyyatNeticesi<T>.Ugurlu(result);
        }
        catch (TesdiqIstisnasi ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Validasiya xətası: {ex.IstifadeciMesaji}");
            return EmeliyyatNeticesi<T>.Ugursuz(ex.IstifadeciMesaji);
        }
        catch (BiznesQaydasiIstisnasi ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Biznes qaydası pozuldu: {ex.IstifadeciMesaji}");
            return EmeliyyatNeticesi<T>.Ugursuz(ex.IstifadeciMesaji);
        }
        catch (MelumatTapilmadiIstisnasi ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Məlumat tapılmadı: {ex.IstifadeciMesaji}");
            return EmeliyyatNeticesi<T>.Ugursuz(ex.IstifadeciMesaji);
        }
        catch (TehlukesizlikIstisnasi ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Təhlükəsizlik xətası: {ex.IstifadeciMesaji}");
            return EmeliyyatNeticesi<T>.Ugursuz(ex.IstifadeciMesaji);
        }
        catch (VerilenlerBazasiIstisnasi ex)
        {
            Logger.XetaYaz(ex, $"{operationName} - Verilənlər bazası xətası");
            return EmeliyyatNeticesi<T>.Ugursuz(ex.IstifadeciMesaji);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, $"{operationName} zamanı gözlənilməz xəta baş verdi");
            return EmeliyyatNeticesi<T>.Ugursuz("Əməliyyat zamanı gözlənilməz xəta baş verdi. Zəhmət olmasa administrator ilə əlaqə saxlayın.");
        }
    }

    /// <summary>
    /// Asinxron əməliyyat icra edir (nəticəsiz)
    /// </summary>
    public static async Task<EmeliyyatNeticesi> ExecuteAsync(
        string operationName,
        Func<Task> operation,
        string? successMessage = null)
    {
        Logger.MelumatYaz($"{operationName} əməliyyatı başladı");

        try
        {
            await operation();

            if (successMessage != null)
            {
                Logger.MelumatYaz(successMessage);
            }

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (TesdiqIstisnasi ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Validasiya xətası: {ex.IstifadeciMesaji}");
            return EmeliyyatNeticesi.Ugursuz(ex.IstifadeciMesaji);
        }
        catch (BiznesQaydasiIstisnasi ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Biznes qaydası pozuldu: {ex.IstifadeciMesaji}");
            return EmeliyyatNeticesi.Ugursuz(ex.IstifadeciMesaji);
        }
        catch (MelumatTapilmadiIstisnasi ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Məlumat tapılmadı: {ex.IstifadeciMesaji}");
            return EmeliyyatNeticesi.Ugursuz(ex.IstifadeciMesaji);
        }
        catch (TehlukesizlikIstisnasi ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Təhlükəsizlik xətası: {ex.IstifadeciMesaji}");
            return EmeliyyatNeticesi.Ugursuz(ex.IstifadeciMesaji);
        }
        catch (VerilenlerBazasiIstisnasi ex)
        {
            Logger.XetaYaz(ex, $"{operationName} - Verilənlər bazası xətası");
            return EmeliyyatNeticesi.Ugursuz(ex.IstifadeciMesaji);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, $"{operationName} zamanı gözlənilməz xəta baş verdi");
            return EmeliyyatNeticesi.Ugursuz("Əməliyyat zamanı gözlənilməz xəta baş verdi. Zəhmət olmasa administrator ilə əlaqə saxlayın.");
        }
    }
}
