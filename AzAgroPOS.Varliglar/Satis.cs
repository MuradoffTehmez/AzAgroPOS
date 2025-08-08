// Fayl: AzAgroPOS.Varliglar/Satis.cs
namespace AzAgroPOS.Varliglar;

using System;
using System.Collections.Generic;

/// <summary>
/// Bir satış əməliyyatının başlığını təmsil edir.
/// Ümumi məbləğ, tarix və müştəri kimi məlumatları saxlayır.
/// </summary>
public class Satis : BazaVarligi
{
    public DateTime Tarix { get; set; }


    /// <summary>
    /// 
    public decimal UmumiMebleg { get; set; }

    /// <summary>
    /// 
    public OdenisMetodu OdenisMetodu { get; set; }

    /// <summary>
    public int? MusteriId { get; set; }

    /// <summary>
    public Musteri? Musteri { get; set; }

    /// <summary>
    public int NovbeId { get; set; }

    /// <summary>
    public Novbe? Novbe { get; set; }

    /// <summary>
    
    public ICollection<SatisDetali> SatisDetallari { get; set; } = new List<SatisDetali>();
}