// Fayl: AzAgroPOS.Varliglar/Mehsul.cs
namespace AzAgroPOS.Varliglar;

public class Mehsul : BazaVarligi
{
    public string Ad { get; set; } = string.Empty;

    public string StokKodu { get; set; } = string.Empty;
    
    public string Barkod { get; set; } = string.Empty;
    
    public decimal PerakendeSatisQiymeti { get; set; } 
    
    public decimal TopdanSatisQiymeti { get; set; }
    
    public decimal TekEdedSatisQiymeti { get; set; }
    
    public decimal AlisQiymeti { get; set; }

    /// <summary>
    /// Məhsulun ölçü vahidi (ədəd, kq, litr və s.).
    /// </summary>
    public OlcuVahidi OlcuVahidi { get; set; } = OlcuVahidi.Ədəd;


    public int MovcudSay { get; set; }
}