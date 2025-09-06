// Fayl: AzAgroPOS.Varliglar/Novbe.cs
namespace AzAgroPOS.Varliglar;

using System;
using System.Collections.Generic;

public class Novbe : BazaVarligi
{

    public int IsciId { get; set; }

    public Istifadeci? Isci { get; set; }

    public DateTime AcilmaTarixi { get; set; }

    public DateTime? BaglanmaTarixi { get; set; }

    public decimal BaslangicMebleg { get; set; }

    public decimal GozlenilenMebleg { get; set; }

    public decimal FaktikiMebleg { get; set; }

    public NovbeStatusu Status { get; set; }

    public ICollection<Satis> Satislar { get; set; } = new List<Satis>();
}