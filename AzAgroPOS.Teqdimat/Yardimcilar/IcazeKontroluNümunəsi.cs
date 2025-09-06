// AzAgroPOS.Teqdimat/Yardimcilar/IcazeKontroluNümunəsi.cs
namespace AzAgroPOS.Teqdimat.Yardimcilar;

using AzAgroPOS.Mentiq.Idareciler;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// İcazə yoxlamasının necə tətbiq ediləcəyinə dair nümunə
/// Bu sinif, düymələrin aktiv/və ya qeyri-aktiv edilməsi kimi hallarda istifadə edilə bilər
/// </summary>
public static class IcazeKontroluNümunəsi
{
    /// <summary>
    /// Satış silmə icazəsi olub-olmamasına görə bir düyməni aktiv/qeyri-aktiv edir
    /// </summary>
    /// <param name="form">Form obyekti</param>
    /// <param name="buttonName">Düymənin adı</param>
    /// <param name="icaeManager">İcazə meneceri</param>
    public static async Task SatışSilDüyməsiniYeniləAsync(Form form, string buttonName, IcazeManager icaeManager)
    {
        var button = form.Controls.Find(buttonName, true);
        if (button.Length > 0 && button[0] is Button düymə)
        {
            var icazeVar = await IcazeYoxlayici.IstifadecininIcazesiVarAsync(icaeManager, "CanDeleteSale");
            düymə.Enabled = icazeVar;
        }
    }
    
    /// <summary>
    /// Endirim tətbiq etmə icazəsi olub-olmamasına görə bir menyu elementini aktiv/qeyri-aktiv edir
    /// </summary>
    /// <param name="menuItem">Menyu elementi</param>
    /// <param name="icaeManager">İcazə meneceri</param>
    public static async Task EndirimMenyuElementiniYeniləAsync(ToolStripMenuItem menuItem, IcazeManager icaeManager)
    {
        var icazeVar = await IcazeYoxlayici.IstifadecininIcazesiVarAsync(icaeManager, "CanGiveDiscount");
        menuItem.Enabled = icazeVar;
    }
    
    /// <summary>
    /// Hesabatları görmə icazəsi olub-olmamasına görə bir form elementini gizlədir/göstərir
    /// </summary>
    /// <param name="form">Form obyekti</param>
    /// <param name="controlName">Kontrol elementinin adı</param>
    /// <param name="icaeManager">İcazə meneceri</param>
    public static async Task HesabatElementiniYeniləAsync(Form form, string controlName, IcazeManager icaeManager)
    {
        var controls = form.Controls.Find(controlName, true);
        if (controls.Length > 0)
        {
            var icazeVar = await IcazeYoxlayici.IstifadecininIcazesiVarAsync(icaeManager, "CanViewReports");
            controls[0].Visible = icazeVar;
        }
    }
}