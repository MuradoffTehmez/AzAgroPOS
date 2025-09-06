// Fayl: AzAgroPOS.Verilenler/Realizasialar/IsciRepozitori.cs
namespace AzAgroPOS.Verilenler.Realizasialar;

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

/// <summary>
/// Isci varlığı üçün repozitoriya realizasiyası.
/// </summary>
public class IsciRepozitori : Repozitori<Isci>, IIsciRepozitori
{
    /// <summary>
    /// IsciRepozitoriyasını yaratmaq üçün konstruktor.
    /// </summary>
    /// <param name="kontekst">Verilənlər bazası konteksti.</param>
    public IsciRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
        // Burada Isci varlığına xas xüsusi konfiqurasiyalar və ya əməliyyatlar həyata keçirilə bilər.
    }
}