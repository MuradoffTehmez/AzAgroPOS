// Fayl: AzAgroPOS.Varliglar/OdenisMetodu.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Satış zamanı istifadə oluna biləcək ödəniş metodlarını təyin edir.
/// diqqət: Bu enum, satış əməliyyatlarında istifadə olunan ödəniş üsullarını təmsil edir.
/// qeyd: Hər bir ödəniş metodu, satışın necə ödənildiyini göstərir, məsələn, nağd pul, kart və ya köçürmə ilə ödəniş.
/// </summary>
public enum OdenisMetodu
{
    /// <summary>
    /// Nağd ödəniş metodu.
    /// diqqət: Bu metod, müştərinin ödənişi nağd pul ilə etdiyini göstərir.
    /// qeyd: Nağd ödəniş, müştərinin satış zamanı nağd pul verərək ödəniş etməsini təmsil edir, məsələn, "50.00" AZN.
    /// </summary>
    Nağd = 1,
    /// <summary>
    /// Kart ödəniş metodu.
    /// diqqət: Bu metod, müştərinin ödənişi bank kartı ilə etdiyini göstərir.
    /// qeyd: Kart ödənişi, müştərinin satış zamanı bank kartı istifadə edərək ödəniş etməsini təmsil edir, məsələn, "100.00" AZN kartla ödəniş.
    /// </summary>
    Kart = 2,
    /// <summary>
    /// Köçürmə ödəniş metodu.
    /// diqqət: Bu metod, müştərinin ödənişi bank köçürməsi ilə etdiyini göstərir.
    /// qeyd: Köçürmə ödənişi, müştərinin satış zamanı bank hesabından digər bir hesaba pul köçürərək ödəniş etməsini təmsil edir, məsələn, "200.00" AZN köçürmə ilə ödəniş.
    /// </summary>
    Köçürmə = 3,
    /// <summary>
    /// Nisyə ödəniş metodu.
    /// diqqət: Bu metod, müştərinin ödənişi borc olaraq etdiyini və ya gələcəkdə ödəyəcəyini göstərir.
    /// qeyd: Nisyə ödənişi, müştərinin satış zamanı məhsulu alıb, amma ödənişi gələcəkdə etməsini təmsil edir, məsələn, "300.00" AZN nisyə ilə ödəniş.
    /// </summary>
    Nisyə = 4
}