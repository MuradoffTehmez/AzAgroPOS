// Fayl: AzAgroPOS.Mentiq/DTOs/BaglanmisNovbeDto.cs

namespace AzAgroPOS.Mentiq.DTOs;
/// <summary>
/// Z-Hesabat arxivində hər bir bağlanmış növbənin qısa məlumatını saxlayır.
/// </summary>
public class BaglanmisNovbeDto
{
    public int NovbeId { get; set; }
    public string KassirAdi { get; set; } = string.Empty;
    public DateTime BaglanmaTarixi { get; set; }
    public DateTime AcilmaTarixi { get; set; }
    public decimal NagdSatis { get; set; }
    public decimal KartSatis { get; set; }
    public decimal CemiSatis => NagdSatis + KartSatis;
}
