// Fayl: AzAgroPOS.Varliglar/Temir.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Təmirə qəbul edilmiş bir sifarişi təmsil edir.
/// </summary>
public class Temir : BazaVarligi
{
    // Müştəri Məlumatları
    public string MusteriAdi { get; set; } = string.Empty;
    public string MusteriTelefonu { get; set; } = string.Empty;

    // Cihaz Məlumatları
    public string CihazAdi { get; set; } = string.Empty;
    public string ProblemTesviri { get; set; } = string.Empty;

    // Təmir Prosesi Məlumatları
    public DateTime QebulTarixi { get; set; }
    public DateTime? TamamlanmaTarixi { get; set; }
    public TemirStatusu Status { get; set; }

    // Xərclər
    public decimal TemirXerci { get; set; }
    public decimal YekunMebleg { get; set; }

    // Əlaqəli İşçi
    public int? IsciId { get; set; }
    public Istifadeci? Isci { get; set; }
}