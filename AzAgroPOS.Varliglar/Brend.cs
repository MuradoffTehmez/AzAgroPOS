// Fayl: AzAgroPOS.Varliglar/Brend.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Məhsul brendlərini təmsil edən varlıq sinifi.
/// </summary>
public class Brend : BazaVarligi
{
    /// <summary>
    /// Brendin adı.
    /// </summary>
    public string Ad { get; set; } = string.Empty;

    /// <summary>
    /// Brendin ölkəsi.
    /// </summary>
    public string? Olke { get; set; }

    /// <summary>
    /// Brendin veb saytı.
    /// </summary>
    public string? Vebsayt { get; set; }

    /// <summary>
    /// Brendin təsviri.
    /// </summary>
    public string? Tesvir { get; set; }

    /// <summary>
    /// Brendin loqosu fayl yolu.
    /// </summary>
    public string? LoqoFaylYolu { get; set; }

    /// <summary>
    /// Brendin aktivlik statusu.
    /// </summary>
    public bool Aktivdir { get; set; } = true;

    /// <summary>
    /// Bu brendə aid məhsullar.
    /// </summary>
    public ICollection<Mehsul> Mehsullar { get; set; } = new List<Mehsul>();
}