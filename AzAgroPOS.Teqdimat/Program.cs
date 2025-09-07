using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Konfiqurasiya;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace AzAgroPOS.Teqdimat
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Loggeri konfiqurasiya edirik
            AzAgroPOS.Mentiq.Yardimcilar.Logger.KonfiqurasiyaEt();

            try
            {
                var services = new ServiceCollection();
                ConfigureServices(services);
                ServiceProvider = services.BuildServiceProvider();

                var loginFormu = ServiceProvider.GetRequiredService<LoginFormu>();
                var dialogResult = loginFormu.ShowDialog();

                if (dialogResult == DialogResult.OK && loginFormu.UgurluDaxilOlundu)
                {
                    var anaMenuFormu = ServiceProvider.GetRequiredService<AnaMenuFormu>();
                    Application.Run(anaMenuFormu);
                }
            }
            catch (Exception ex)
            {
                try
                {
                    AzAgroPOS.Mentiq.Yardimcilar.Logger.XetaYaz(ex, "Tətbiq səviyyəsində tutulmayan istisna baş verdi");
                    MessageBox.Show("Tətbiqdə gözlənilməyən xəta baş verdi. Təfərrüatlar log faylına yazıldı.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    // If logging also fails, show a simple message box
                    MessageBox.Show("Tətbiqdə gözlənilməyən xəta baş verdi. Log faylı yaradıla bilmədi.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            try
            {
                // Build configuration
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                IConfiguration configuration = builder.Build();

                // Get connection string from configuration or use fallback
                string connectionString = configuration.GetConnectionString(Sabitler.DefaultConnection) ??
                "Server=.\\SQLEXPRESS;Database=AzAgroPOS_DB;Trusted_Connection=True;TrustServerCertificate=True;";

                services.AddDbContext<AzAgroPOSDbContext>(options =>
                    options.UseSqlServer(connectionString), ServiceLifetime.Transient);

                services.AddTransient<IUnitOfWork, UnitOfWork>();

                // Menecerlər
                services.AddTransient<TehlukesizlikManager>();
                services.AddTransient<IstifadeciManager>();
                services.AddTransient<MehsulManager>();
                services.AddTransient<MehsulMeneceri>(); // Əlavə edildi
                services.AddTransient<MusteriManager>();
                services.AddTransient<SatisManager>();
                services.AddTransient<NisyeManager>();
                services.AddTransient<NovbeManager>();
                services.AddTransient<HesabatManager>();
                services.AddTransient<AnbarManager>();
                services.AddTransient<BarkodCapiManager>();
                services.AddTransient<TemirManager>();
                services.AddTransient<IsciManager>();
                services.AddTransient<AlisManager>();
                services.AddTransient<KateqoriyaMeneceri>(); // Əlavə edildi
                services.AddTransient<BrendMeneceri>(); // Əlavə edildi
                services.AddTransient<TedarukcuMeneceri>(); // Əlavə edildi
                services.AddTransient<KonfiqurasiyaManager>(); // Əlavə edildi
                services.AddTransient<IcazeManager>(); // Əlavə edildi

                // Presenterlər
                services.AddTransient<LoginPresenter>();
                services.AddTransient<MehsulPresenter>();
                services.AddTransient<MusteriPresenter>();
                services.AddTransient<SatisPresenter>();
                services.AddTransient<TemirPresenter>();
                services.AddTransient<QaytarmaPresenter>();

                // Interface-lər və onların implementasiyaları
                services.AddTransient<ILoginView, LoginFormu>();
                services.AddTransient<IAnaMenuView, AnaMenuFormu>();
                services.AddTransient<IIstifadeciView, IstifadeciIdareetmeFormu>();
                services.AddTransient<IAnbarView, AnbarFormu>();
                services.AddTransient<IAnbarQaliqHesabatView, AnbarQaliqHesabatFormu>();
                services.AddTransient<IBarkodCapiView, BarkodCapiFormu>();
                services.AddTransient<IHesabatView, HesabatFormu>();
                services.AddTransient<IMehsulIdareetmeView, MehsulIdareetmeFormu>();
                services.AddTransient<IMehsulSatisHesabatView, MehsulSatisHesabatFormu>();
                services.AddTransient<IMusteriView, MusteriIdareetmeFormu>();
                services.AddTransient<INisyeView, NisyeIdareetmeFormu>();
                services.AddTransient<INovbeView, NovbeIdareetmesiFormu>();
                services.AddTransient<ISatisView, SatisFormu>();
                services.AddTransient<ITemirView, TemirIdareetmeFormu>();
                services.AddTransient<IEhtiyatHissəsiView, EhtiyatHissəsiFormu>();
                services.AddTransient<IZHesabatArxivView, ZHesabatArxivFormu>();
                services.AddTransient<ITedarukcuView, TedarukcuIdareetmeFormu>();
                services.AddTransient<IIsciView, IsciIdareetmeFormu>();
                services.AddTransient<IQaytarmaView, QaytarmaFormu>();
                services.AddTransient<IKonfiqurasiyaView, KonfiqurasiyaFormu>();

                // Formalar (Bütün formaları buraya əlavə edirik)
                services.AddTransient<LoginFormu>();
                services.AddTransient<AnaMenuFormu>();
                services.AddTransient<IstifadeciIdareetmeFormu>();
                services.AddTransient<AnbarFormu>();
                services.AddTransient<AnbarQaliqHesabatFormu>();
                services.AddTransient<BarkodCapiFormu>();
                services.AddTransient<HesabatFormu>();
                services.AddTransient<MehsulIdareetmeFormu>();
                services.AddTransient<MehsulSatisHesabatFormu>();
                services.AddTransient<MusteriIdareetmeFormu>();
                services.AddTransient<NisyeIdareetmeFormu>();
                services.AddTransient<NovbeIdareetmesiFormu>();
                services.AddTransient<SatisFormu>();
                services.AddTransient<TemirIdareetmeFormu>();
                services.AddTransient<EhtiyatHissəsiFormu>();
                services.AddTransient<ZHesabatArxivFormu>();
                services.AddTransient<TedarukcuIdareetmeFormu>();
                services.AddTransient<IsciIdareetmeFormu>();
                services.AddTransient<QaytarmaFormu>();
                services.AddTransient<KonfiqurasiyaFormu>(); // Əlavə edildi
            }
            catch (Exception ex)
            {
                // Log the configuration error and rethrow
                AzAgroPOS.Mentiq.Yardimcilar.Logger.XetaYaz(ex, "Servis konfiqurasiya edilərkən xəta baş verdi");
                throw; // Rethrow to be caught by the main try-catch
            }
        }
    }
}