// Fayl: AzAgroPOS.Verilenler/Interfeysler/IEmekHaqqiRepozitori.cs
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Verilenler.Interfeysler
{
    /// <summary>
    /// Əmək haqqı əməliyyatları üçün repozitori interfeysi.
    /// diqqət: Bu interfeys əmək haqqı qeydlərinin verilənlər bazası əməliyyatlarını müəyyən edir.
    /// qeyd: IRepozitori<EmekHaqqi> interfeysini miras alır və baza funksionallığı təmin edir.
    /// </summary>
    public interface IEmekHaqqiRepozitori : IRepozitori<EmekHaqqi>
    {
        // Əlavə xüsusi metodlar lazım olduqda burada əlavə oluna bilər
    }
}
