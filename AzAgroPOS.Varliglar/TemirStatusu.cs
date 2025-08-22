// Fayl: AzAgroPOS.Varliglar/TemirStatusu.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Təmir sifarişinin müxtəlif mərhələlərini təmsil edən enumerasiya.
/// Diqqət: Bu enum, təmir prosesinin müxtəlif mərhələlərini və vəziyyətlərini təmsil edir.
/// Qeyd: Hər bir status, təmir prosesinin müəyyən bir mərhələsini və ya vəziyyətini göstərir, məsələn, "Gözləmədə" statusu, təmirin hələ başlamadığını göstərir.
/// </summary>
public enum TemirStatusu
{
    /// <summary>
    /// Gözləmədə - təmir prosesi hələ başlamayıb və müştərinin təsdiqini gözləyir.
    /// Qeyd: Bu status, təmir prosesinin başlanğıc mərhələsini və müştərinin təsdiqini gözlədiyini göstərir.
    /// </summary>
    Gözləmədə = 1,
    /// <summary>
    /// Təmirdə - təmir prosesi aktivdir və cihaz üzərində işlər aparılır.
    /// Qeyd: Bu status, təmir prosesinin aktiv mərhələsini və cihaz üzərində işlərin davam etdiyini göstərir.
    /// </summary>
    Təmirdə = 2,
    /// <summary>
    /// Hazırdır - təmir prosesi tamamlanıb və cihaz müştəriyə qaytarılmağa hazırdır.
    /// Qeyd: Bu status, təmir prosesinin tamamlandığını və cihazın müştəriyə qaytarılmağa hazır olduğunu göstərir.
    /// </summary>
    Hazırdır = 3,
    /// <summary>
    /// Təhvil verildi - cihaz müştəriyə təhvil verilib və təmir prosesi tamamlanıb.
    /// Qeyd: Bu status, təmir prosesinin tam olaraq tamamlandığını və cihazın müştəriyə təhvil verildiyini göstərir.
    /// </summary>
    TəhvilVerildi = 4
}