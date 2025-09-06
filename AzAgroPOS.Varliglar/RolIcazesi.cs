// AzAgroPOS.Varliglar\RolIcazesi.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Rol və İcazə arasında çoxdan-çoxa əlaqəni təmsil edən əlaqə cədvəli
/// </summary>
public class RolIcazesi : BazaVarligi
{
    /// <summary>
    /// Rolun ID-si
    /// </summary>
    public int RolId { get; set; }

    /// <summary>
    /// Rol obyekti
    /// </summary>
    public Rol? Rol { get; set; }

    /// <summary>
    /// İcazənin ID-si
    /// </summary>
    public int IcazeId { get; set; }

    /// <summary>
    /// İcazə obyekti
    /// </summary>
    public Icaze? Icaze { get; set; }
}