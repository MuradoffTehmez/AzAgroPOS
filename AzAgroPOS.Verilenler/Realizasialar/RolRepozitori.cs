// Fayl: AzAgroPOS.Verilenler/Realizasialar/RolRepozitori.cs
namespace AzAgroPOS.Verilenler.Realizasialar;

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;

/// <summary>
/// bu sinif, Rol üçün CRUD əməliyyatlarını həyata keçirən repozitoriyadır.
/// bu siniflə CRUD əməliyyatlarını (Yarat, Oxu, Yenilə, Sil) ümumi şəkildə həyata keçirir.
/// </summary>
public class RolRepozitori : Repozitori<Rol>, IRolRepozitori
{
    /// <summary>
    /// rolRepozitoriyasını yaratmaq üçün konstruktordur və verilənlər bazası kontekstini bazaya ötürür.
    /// qeyd: Bu konstruktor, konkret varlıq repozitoriyaları üçün istifadə olunur və əlavə konfiqurasiya və ya başlanğıc əməliyyatları həyata keçirmək üçün istifadə oluna bilər.
    /// </summary>
    /// <param name="kontekst"></param>
    public RolRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst) 
    {
        // burda əlavə konfiqurasiya və ya başlanğıc əməliyyatları həyata keçirilə bilər
        // rol ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər, məsələn: İstifadəçiyə görə rolları tapmaq, rola görə istifadəçiləri filtrləmək və s.
        // gələcəkdə xususi rollar yaradıla və sistemə əlavə edilə bilər.
        // təmirçi, menecer, anbarçı , mühasibat və s. kimi xüsusi rollar əlavə edilə bilər.
    }
}