// AzAgroPOS.Varliglar/EmeliyyatJurnali.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Verilənlər bazasında edilən əməliyyatların jurnalını saxlayır.
/// Hər bir əməliyyat kim tərəfindən, nə vaxt və hansı obyekt üzərində edildiyini qeyd edir.
/// </summary>
public class EmeliyyatJurnali : BazaVarligi
{
    /// <summary>
    /// Əməliyyatı edən istifadəçinin ID-si
    /// </summary>
    public int IstifadeciId { get; set; }
    
    /// <summary>
    /// Əməliyyatın edildiyi tarix və vaxt
    /// </summary>
    public DateTime EmeliyyatTarixi { get; set; }
    
    /// <summary>
    /// Əməliyyatın növü (Əlavə, Yeniləmə, Sil)
    /// </summary>
    public AuditEmeliyyatNovu EmeliyyatNovu { get; set; }
    
    /// <summary>
    /// Əməliyyatın edildiyi cədvəl/obyektin adı (Məsələn: "Mehsul")
    /// </summary>
    public string CədvəlAdi { get; set; } = string.Empty;
    
    /// <summary>
    /// Əməliyyat edilən obyektin ID-si
    /// </summary>
    public int ObyektId { get; set; }
    
    /// <summary>
    /// Əməliyyatın təfərrüatlı izahı
    /// Məsələn: "Admin istifadəçisi, 'Sobsan_Divar_Boyasi' məhsulunun satış qiymətini 15.00-dan 16.50-ə dəyişdi"
    /// </summary>
    public string Aciklama { get; set; } = string.Empty;
}