// Fayl: AzAgroPOS.Teqdimat/Program.cs
namespace AzAgroPOS.Teqdimat;

/// <summary>
/// 
/// </summary>
internal static class Program
{
    /// <summary>
    /// 
    /// </summary>
    [STAThread]
    
    static void Main()
    {
        
        ApplicationConfiguration.Initialize();
        
        //var loginFormu = new LoginFormu();
        //loginFormu.ShowDialog();

        // Yalnız giriş uğurlu olduqda ana menyunu açırıq
        //if (loginFormu.UgurluDaxilOlundu)
        //{
            Application.Run(new MehsulIdareetmeFormu());
        //}
    }
}