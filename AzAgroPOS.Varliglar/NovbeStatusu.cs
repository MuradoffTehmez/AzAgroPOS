// Fayl: AzAgroPOS.Varliglar/NovbeStatusu.cs
namespace AzAgroPOS.Varliglar;
/// <summary>
/// növbənin statusunu təmsil edən enumerasiya (açıq və ya bağlı).
/// Diqqət: Bu enumerasiya, növbənin cari vəziyyətini təmsil edir və növbənin açıq və ya bağlı olduğunu göstərir.
/// Qeyd: Növbə statusu, "Açıq" və ya "Bağlı" ola bilər. Açıq növbə, hələ bağlanmamış və satışların davam etdiyi növbəni göstərir, bağlı növbə isə artıq bağlanmış və satışların tamamlandığı növbəni göstərir.
/// </summary>
public enum NovbeStatusu
{
    /// <summary>
    /// açıq növbə (hələ bağlanmamış və satışların davam etdiyi növbə).
    /// Diqqət: Açıq növbə, hələ bağlanmamış və satışların davam etdiyi növbəni göstərir.
    /// Qeyd: Açıq növbə, kassirin iş gününün başladığı və satışların aktiv olduğu vəziyyəti təmsil edir.
    /// </summary>
    Aciq = 1,
    /// <summary>
    /// bağlı növbə (artıq bağlanmış və satışların tamamlandığı növbə).
    /// diqqət: Bağlı növbə, artıq bağlanmış və satışların tamamlandığı növbəni göstərir.
    /// qeyd: Bağlı növbə, kassirin iş gününün sona çatdığı və satışların dayandığı vəziyyəti təmsil edir.
    /// </summary>
    Bagli = 2
}