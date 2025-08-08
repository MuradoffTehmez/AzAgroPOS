// Fayl: AzAgroPOS.Teqdimat/Program.cs
namespace AzAgroPOS.Teqdimat;
internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        var loginFormu = new LoginFormu();
        loginFormu.ShowDialog();
        if (loginFormu.UgurluDaxilOlundu)
        {
            Application.Run(new AnaMenuFormu());
        }
    }
}