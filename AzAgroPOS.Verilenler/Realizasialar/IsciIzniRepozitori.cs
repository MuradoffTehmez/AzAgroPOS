// Fayl: AzAgroPOS.Verilenler/Realizasialar/IsciIzniRepozitori.cs
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
/// IsciIzni varlığı üçün repozitoriya realizasiyası.
/// </summary>
public class IsciIzniRepozitori : Repozitori<IsciIzni>, IIsciIzniRepozitori
{
    /// <summary>
    /// IsciIzniRepozitoriyasını yaratmaq üçün konstruktor.
    /// </summary>
    /// <param name="kontekst">Verilənlər bazası konteksti.</param>
    public IsciIzniRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
        // Burada IsciIzni varlığına xas xüsusi konfiqurasiyalar və ya əməliyyatlar həyata keçirilə bilər.
    }
}