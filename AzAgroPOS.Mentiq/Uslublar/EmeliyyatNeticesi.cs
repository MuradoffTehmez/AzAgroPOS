// Fayl: AzAgroPOS.Mentiq/Uslublar/EmeliyyatNeticesi.cs
namespace AzAgroPOS.Mentiq.Uslublar;

/// <summary>
/// Məntiq qatındakı əməliyyatların nəticəsini təmsil edir.
/// Data qaytarmayan əməliyyatlar üçün istifadə olunur (məsələn, Silmə).
/// </summary>
public class EmeliyyatNeticesi
{
    /// <summary>
    /// uğurlu əməliyyatın olub olmadığını göstərir.
    /// diqqət: Bu, əməliyyatın uğurlu olub olmadığını göstərir, məsələn, silmə əməliyyatı uğurlu olubsa true, əks halda false olacaq.
    /// qeyd: Əgər əməliyyat uğursuz olarsa, Mesaj sahəsi istifadə olunur ki, müvafiq xətanı və ya məlumatı göstərsin.
    /// </summary>
    public bool UgurluDur { get; protected set; }
    /// <summary>
    /// müvafiq əməliyyatın uğursuz olması halında istifadə olunan mesaj.
    /// diqqət: Bu sahə əməliyyatın uğursuz olması halında istifadə olunur və əməliyyatın səbəbini göstərir.
    /// qeyd: Əgər əməliyyat uğurlu olarsa, bu sahə boş olacaq.
    /// </summary>
    public string Mesaj { get; protected set; } = string.Empty;
    /// <summary>
    /// Uğurlu əməliyyatın nəticəsini qaytarır. bu metod əməliyyatın uğurlu olduğunu göstərir və UgurluDur sahəsini true olaraq təyin edir.
    /// diqqət: Bu metod əməliyyatın uğurlu olduğunu göstərir və UgurluDur sahəsini true olaraq təyin edir.
    /// qeyd: Əgər əməliyyat uğursuz olarsa, Ugursuz metodundan istifadə olunur ki, müvafiq mesajı göstərsin.
    /// </summary>
    /// <returns></returns>
    public static EmeliyyatNeticesi Ugurlu() => new() { UgurluDur = true };
    /// <summary>
    /// Uğursuz əməliyyatın nəticəsini qaytarır. bu metod əməliyyatın uğursuz olduğunu göstərir və UgurluDur sahəsini false olaraq təyin edir.
    /// </summary>
    /// <param name="mesaj"></param>
    /// <returns></returns>
    public static EmeliyyatNeticesi Ugursuz(string mesaj) => new() { UgurluDur = false, Mesaj = mesaj };
}

/// <summary>
/// Məntiq qatındakı əməliyyatların nəticəsini və qaytarılan datanı təmsil edir.
/// </summary>
/// <typeparam name="T">Qaytarılacaq datanın növü</typeparam>
public class EmeliyyatNeticesi<T> : EmeliyyatNeticesi
{
    /// <summary>
    /// bu sahə əməliyyatın uğurlu olması halında qaytarılan datanı saxlayır.
    /// diqqət: Əgər əməliyyat uğursuz olarsa, bu sahə null olacaq.
    /// qeyd: Bu sahə əməliyyatın uğurlu olması halında istifadə olunur və əməliyyatın nəticəsini göstərir.
    /// </summary>
    public T? Data { get; private set; }
    /// <summary>
    /// Uğurlu əməliyyatın nəticəsini qaytarır. bu metod əməliyyatın uğurlu olduğunu göstərir və UgurluDur sahəsini true olaraq təyin edir.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static EmeliyyatNeticesi<T> Ugurlu(T data) => new() { UgurluDur = true, Data = data };
    /// <summary>
    /// Uğursuz əməliyyatın nəticəsini qaytarır. bu metod əməliyyatın uğursuz olduğunu göstərir və UgurluDur sahəsini false olaraq təyin edir.
    /// </summary>
    /// <param name="mesaj"></param>
    /// <returns></returns>
    public new static EmeliyyatNeticesi<T> Ugursuz(string mesaj) => new() { UgurluDur = false, Mesaj = mesaj };
}