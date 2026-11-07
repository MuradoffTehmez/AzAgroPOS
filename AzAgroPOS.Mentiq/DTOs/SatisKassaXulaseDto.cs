namespace AzAgroPOS.Mentiq.DTOs;

/// <summary>Seçilmiş dövrdə satışlardan qaytarmalar çıxıldıqdan sonrakı göstəricilər.</summary>
public sealed class SatisKassaXulaseDto
{
    public decimal SatilanMiqdar { get; init; }
    public decimal SatisDeyeri { get; init; }
    public decimal AlisDeyeri { get; init; }
    public bool MayaDeyeriTamdir { get; init; }
    public decimal NagdSatis { get; init; }
    public decimal KartSatis { get; init; }
    public decimal NisyeSatis { get; init; }
    public decimal QaytarmaMeblegi { get; init; }
    public decimal UmumiQazanc => SatisDeyeri - AlisDeyeri;
}
