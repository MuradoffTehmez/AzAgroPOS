// Fayl: AzAgroPOS.Verilenler/Realizasialar/TemirRepozitori.cs
namespace AzAgroPOS.Verilenler.Realizasialar;

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;

/// <summary>
/// temir üçün CRUD əməliyyatlarını həyata keçirən repozitoriya.
/// qeyd: Bu sinif, konkret varlıq repozitoriyaları üçün təməl sinif kimi istifadə olunur.
/// </summary>
public class TemirRepozitori : Repozitori<Temir>, ITemirRepozitori
{
    /// <summary>
    /// temirRepozitoriyasını yaratmaq üçün konstruktor.
    /// qeyd: Bu konstruktor, konkret varlıq repozitoriyaları üçün istifadə olunur.
    /// </summary>
    /// <param name="kontekst"></param>
    public TemirRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst) { }
}