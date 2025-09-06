// Fayl: AzAgroPOS.Verilenler/Realizasialar/IsciPerformansRepozitori.cs
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
/// IsciPerformans varlığı üçün repozitoriya realizasiyası.
/// </summary>
public class IsciPerformansRepozitori : Repozitori<IsciPerformans>, IIsciPerformansRepozitori
{
    /// <summary>
    /// IsciPerformansRepozitoriyasını yaratmaq üçün konstruktor.
    /// </summary>
    /// <param name="kontekst">Verilənlər bazası konteksti.</param>
    public IsciPerformansRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
        // Burada IsciPerformans varlığına xas xüsusi konfiqurasiyalar və ya əməliyyatlar həyata keçirilə bilər.
    }
}