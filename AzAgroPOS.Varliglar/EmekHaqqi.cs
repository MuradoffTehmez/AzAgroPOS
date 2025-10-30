// Fayl: AzAgroPOS.Varliglar/EmekHaqqi.cs
namespace AzAgroPOS.Varliglar;

using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Əmək haqqı qeydini təmsil edən entity.
/// diqqət: Bu sinif, işçilərin əmək haqqı hesablanması və ödənilməsi qeydlərini saxlayır.
/// qeyd: Hər bir qeyd müəyyən bir dövr üçün bir işçiyə aid olmalıdır.
/// </summary>
public class EmekHaqqi : BazaVarligi
{
    /// <summary>
    /// İşçinin ID-si.
    /// </summary>
    public int IsciId { get; set; }

    /// <summary>
    /// İşçi navigasiya xüsusiyyəti.
    /// </summary>
    public Isci Isci { get; set; } = null!;

    /// <summary>
    /// Əmək haqqı dövrü (məsələn, "2025 Yanvar").
    /// </summary>
    public string Dovr { get; set; } = string.Empty;

    /// <summary>
    /// Əmək haqqının hesablanma tarixi.
    /// </summary>
    public DateTime HesablanmaTarixi { get; set; } = DateTime.Now;

    /// <summary>
    /// Əsas maaş (sabit).
    /// </summary>
    public decimal EsasMaas { get; set; }

    /// <summary>
    /// Bonus və mükafatlar (performans əsasında).
    /// </summary>
    public decimal Bonuslar { get; set; } = 0;

    /// <summary>
    /// Əlavə ödənişlər (gecə növbələri, həftəsonu işi və s.).
    /// </summary>
    public decimal ElaveOdenisler { get; set; } = 0;

    /// <summary>
    /// İcazə günlərinə görə tutulmalar.
    /// </summary>
    public decimal IcazeTutulmasi { get; set; } = 0;

    /// <summary>
    /// Digər tutulmalar (cərimələr, avanslar və s.).
    /// </summary>
    public decimal DigerTutulmalar { get; set; } = 0;

    /// <summary>
    /// Yekun əmək haqqı = Əsas Maaş + Bonuslar + Əlavə Ödənişlər - İcazə Tutulması - Digər Tutulmalar.
    /// Qeyd: Bu hesablanan sahədir və verilənlər bazasına yazılmır.
    /// </summary>
    [NotMapped]
    public decimal YekunEmekHaqqi => EsasMaas + Bonuslar + ElaveOdenisler - IcazeTutulmasi - DigerTutulmalar;

    /// <summary>
    /// Əmək haqqının ödənilməsi tarixi.
    /// </summary>
    public DateTime? OdenisTarixi { get; set; }

    /// <summary>
    /// Əmək haqqının statusu.
    /// </summary>
    public EmekHaqqiStatusu Status { get; set; } = EmekHaqqiStatusu.Hesablanmis;

    /// <summary>
    /// Əlavə qeydlər.
    /// </summary>
    public string? Qeyd { get; set; }

    /// <summary>
    /// Əməliyyatı icra edən istifadəçinin ID-si.
    /// </summary>
    public int? IstifadeciId { get; set; }

    /// <summary>
    /// İstifadəçi navigasiya xüsusiyyəti.
    /// </summary>
    public Istifadeci? Istifadeci { get; set; }
}
