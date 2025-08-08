// Fayl: AzAgroPOS.Mentiq/DTOs/IstifadeciDto.cs
public class IstifadeciDto
{
    public int Id { get; set; }
    public string IstifadeciAdi { get; set; } = string.Empty;
    public string TamAd { get; set; } = string.Empty;
    public string RolAdi { get; set; } = string.Empty;
    public int RolId { get; set; } // Bu, ComboBox-da rol seçimi üçün lazımdır
}