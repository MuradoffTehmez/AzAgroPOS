// Fayl: AzAgroPOS.Varliglar/Interfeysler/IAuditableEntity.cs
namespace AzAgroPOS.Varliglar.Interfeysler;

/// <summary>
/// Audit sahələrini ehtiva edən varlıqlar üçün interfeys.
/// Bu interfeys, varlıqların kim tərəfindən və nə vaxt yaradıldığını və dəyişdirildiyini izləməyə imkan verir.
/// </summary>
public interface IAuditableEntity
{
    /// <summary>
    /// Varlığı yaradan istifadəçinin ID-si
    /// </summary>
    int? YaradanIstifadeciId { get; set; }

    /// <summary>
    /// Varlığın yaradılma tarixi və vaxtı
    /// </summary>
    DateTime YaradilmaTarixi { get; set; }

    /// <summary>
    /// Varlığı son dəyişdirən istifadəçinin ID-si
    /// </summary>
    int? DeyisdirenIstifadeciId { get; set; }

    /// <summary>
    /// Varlığın son dəyişdirilmə tarixi və vaxtı
    /// </summary>
    DateTime? DeyisdirilmeTarixi { get; set; }
}
