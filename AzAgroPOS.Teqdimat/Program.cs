// Fayl: AzAgroPOS.Teqdimat/Program.cs
namespace AzAgroPOS.Teqdimat;

/// <summary>
///  əsas proqram sinfidir
/// </summary>
internal static class Program
{
    /// <summary>
    /// baş proqram giriş nöqtəsidir.
    /// </summary>
    [STAThread]
    
    static void Main()
    {
        
        ApplicationConfiguration.Initialize();
        
        //var loginFormu = new LoginFormu();
        //loginFormu.ShowDialog();

         //Yalnız giriş uğurlu olduqda ana menyunu açırıq
        //if (loginFormu.UgurluDaxilOlundu)
        //{
            Application.Run(new MehsulIdareetmeFormu());
        //}
    }
}