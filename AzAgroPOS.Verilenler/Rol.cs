// Fayl: AzAgroPOS.Varliglar/Rol.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Sistemdəki istifadəçi rollarını (məsələn, Admin, Kassir) təyin edir.
/// </summary>
public class Rol : BazaVarligi
{
    /// <summary>
    /// Rolun adı.
    /// </summary>
    public string Ad { get; set; } = string.Empty;

    /// <summary>
    /// Bu rola sahib olan istifadəçilərin siyahısı.
    /// </summary>
    public ICollection<Istifadeci> Istifadeciler { get; set; } = new List<Istifadeci>();
}