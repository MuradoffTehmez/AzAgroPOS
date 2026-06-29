// AzAgroPOS.Teqdimat/Yardimcilar/IcazeKontroluNümunəsi.cs

using AzAgroPOS.Mentiq.Idareciler;

namespace AzAgroPOS.Teqdimat.Yardimcilar;
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
        Control[] button = form.Controls.Find(buttonName, true);
        if (button.Length > 0 && button[0] is Button düymə)
        {
            bool icazeVar = await IcazeYoxlayici.IstifadecininIcazesiVarAsync(icaeManager, "CanDeleteSale");
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
        bool icazeVar = await IcazeYoxlayici.IstifadecininIcazesiVarAsync(icaeManager, "CanGiveDiscount");
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
        Control[] controls = form.Controls.Find(controlName, true);
        if (controls.Length > 0)
        {
            bool icazeVar = await IcazeYoxlayici.IstifadecininIcazesiVarAsync(icaeManager, "CanViewReports");
            controls[0].Visible = icazeVar;
        }
    }
}