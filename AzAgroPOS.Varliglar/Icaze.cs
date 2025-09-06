// AzAgroPOS.Varliglar/Icaze.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// İstifadəçilərin sahib olduğu ayrı-ayrı icazələri təmsil edir.
/// Hər bir icazə, sistemdə müəyyən bir əməliyyatı yerinə yetirmək imkanı verir.
/// </summary>
public class Icaze : BazaVarligi
{
    /// <summary>
    /// İcazənin adı (məsələn, "CanDeleteSale", "CanGiveDiscount")
    /// </summary>
    public string Ad { get; set; } = string.Empty;

    /// <summary>
    /// İcazənin təsviri (məsələn, "Satış silmək imkanı", "Endirim tətbiq etmək imkanı")
    /// </summary>
    public string Tesvir { get; set; } = string.Empty;

    /// <summary>
    /// Bu icazəyə sahib olan rolların siyahısı
    /// </summary>
    public ICollection<RolIcazesi> Rollar { get; set; } = new List<RolIcazesi>();
}