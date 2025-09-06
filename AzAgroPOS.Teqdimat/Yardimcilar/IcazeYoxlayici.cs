// AzAgroPOS.Teqdimat/Yardimcilar/IcazeYoxlayici.cs
namespace AzAgroPOS.Teqdimat.Yardimcilar;

using AzAgroPOS.Mentiq.Idareciler;
using System.Threading.Tasks;

/// <summary>
/// İstifadəçilərin icazələrini yoxlamaq üçün köməkçi sinif
/// </summary>
public static class IcazeYoxlayici
{
    /// <summary>
    /// Hazırkı istifadəçinin müəyyən bir icazəyə sahib olub-olmadığını yoxlayır
    /// </summary>
    /// <param name="icaeManager">İcazə meneceri</param>
    /// <param name="icaeAdi">Yoxlanılacaq icazənin adı</param>
    /// <returns>İstifadəçinin icazəyə sahib olub-olmaması</returns>
    public static async Task<bool> IstifadecininIcazesiVarAsync(IcazeManager icaeManager, string icaeAdi)
    {
        // Aktiv sessiya yoxdur və ya istifadəçi təyin edilməyib
        if (AktivSessiya.AktivIstifadeci == null)
        {
            return false;
        }
        
        // Admin istifadəçisinin bütün icazələri var
        if (AktivSessiya.AktivIstifadeci.RolId == 1)
        {
            return true;
        }
        
        var netice = await icaeManager.IstifadecininIcazesiVarAsync(
            AktivSessiya.AktivIstifadeci.Id, 
            icaeAdi);
        
        return netice.UgurluDur && netice.Data;
    }
}