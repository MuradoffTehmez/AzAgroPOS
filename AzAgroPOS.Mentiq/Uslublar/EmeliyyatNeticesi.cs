// Fayl: AzAgroPOS.Mentiq/Uslublar/EmeliyyatNeticesi.cs
namespace AzAgroPOS.Mentiq.Uslublar;

/// <summary>
/// Məntiq qatındakı əməliyyatların nəticəsini təmsil edir.
/// Data qaytarmayan əməliyyatlar üçün istifadə olunur (məsələn, Silmə).
/// </summary>
public class EmeliyyatNeticesi
{
    public bool UgurluDur { get; protected set; }
    public string Mesaj { get; protected set; } = string.Empty;

    public static EmeliyyatNeticesi Ugurlu() => new() { UgurluDur = true };
    public static EmeliyyatNeticesi Ugursuz(string mesaj) => new() { UgurluDur = false, Mesaj = mesaj };
}

/// <summary>
/// Məntiq qatındakı əməliyyatların nəticəsini və qaytarılan datanı təmsil edir.
/// </summary>
/// <typeparam name="T">Qaytarılacaq datanın növü</typeparam>
public class EmeliyyatNeticesi<T> : EmeliyyatNeticesi
{
    public T? Data { get; private set; }

    public static EmeliyyatNeticesi<T> Ugurlu(T data) => new() { UgurluDur = true, Data = data };
    public new static EmeliyyatNeticesi<T> Ugursuz(string mesaj) => new() { UgurluDur = false, Mesaj = mesaj };
}