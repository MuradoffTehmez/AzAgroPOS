// Fayl: AzAgroPOS.Mentiq/Yardimcilar/OperationExecutor.cs
using AzAgroPOS.Mentiq.Uslublar;

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
        catch (Mentiq.Exceptions.ValidationException ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Validation xətası: {ex.Message}");
            return EmeliyyatNeticesi<T>.Ugursuz(ex.Message);
        }
        catch (Mentiq.Exceptions.BusinessRuleException ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Business rule xətası: {ex.Message}");
            return EmeliyyatNeticesi<T>.Ugursuz(ex.Message);
        }
        catch (Mentiq.Exceptions.DataNotFoundException ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Məlumat tapılmadı: {ex.Message}");
            return EmeliyyatNeticesi<T>.Ugursuz(ex.Message);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, $"{operationName} zamanı gözlənilməz xəta baş verdi");
            return EmeliyyatNeticesi<T>.Ugursuz($"{operationName} uğursuz oldu: {ex.Message}");
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
        catch (Mentiq.Exceptions.ValidationException ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Validation xətası: {ex.Message}");
            return EmeliyyatNeticesi.Ugursuz(ex.Message);
        }
        catch (Mentiq.Exceptions.BusinessRuleException ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Business rule xətası: {ex.Message}");
            return EmeliyyatNeticesi.Ugursuz(ex.Message);
        }
        catch (Mentiq.Exceptions.DataNotFoundException ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Məlumat tapılmadı: {ex.Message}");
            return EmeliyyatNeticesi.Ugursuz(ex.Message);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, $"{operationName} zamanı gözlənilməz xəta baş verdi");
            return EmeliyyatNeticesi.Ugursuz($"{operationName} uğursuz oldu: {ex.Message}");
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
        catch (Mentiq.Exceptions.ValidationException ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Validation xətası: {ex.Message}");
            return EmeliyyatNeticesi<T>.Ugursuz(ex.Message);
        }
        catch (Mentiq.Exceptions.BusinessRuleException ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Business rule xətası: {ex.Message}");
            return EmeliyyatNeticesi<T>.Ugursuz(ex.Message);
        }
        catch (Mentiq.Exceptions.DataNotFoundException ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Məlumat tapılmadı: {ex.Message}");
            return EmeliyyatNeticesi<T>.Ugursuz(ex.Message);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, $"{operationName} zamanı gözlənilməz xəta baş verdi");
            return EmeliyyatNeticesi<T>.Ugursuz($"{operationName} uğursuz oldu: {ex.Message}");
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
        catch (Mentiq.Exceptions.ValidationException ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Validation xətası: {ex.Message}");
            return EmeliyyatNeticesi.Ugursuz(ex.Message);
        }
        catch (Mentiq.Exceptions.BusinessRuleException ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Business rule xətası: {ex.Message}");
            return EmeliyyatNeticesi.Ugursuz(ex.Message);
        }
        catch (Mentiq.Exceptions.DataNotFoundException ex)
        {
            Logger.XəbərdarlıqYaz($"{operationName} - Məlumat tapılmadı: {ex.Message}");
            return EmeliyyatNeticesi.Ugursuz(ex.Message);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, $"{operationName} zamanı gözlənilməz xəta baş verdi");
            return EmeliyyatNeticesi.Ugursuz($"{operationName} uğursuz oldu: {ex.Message}");
        }
    }
}
