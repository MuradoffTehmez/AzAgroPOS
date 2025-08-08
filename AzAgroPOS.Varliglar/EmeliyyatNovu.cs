// Fayl: AzAgroPOS.Varliglar/EmeliyyatNovu.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Nisyə hərəkətinin növünü təyin edir (borcun artması və ya azalması).
/// </summary>
public enum EmeliyyatNovu
{
    Satis = 1,  // Nisyə satış (borcu artırır)
    Odenis = 2 // Borc ödənişi (borcu azaldır)
}