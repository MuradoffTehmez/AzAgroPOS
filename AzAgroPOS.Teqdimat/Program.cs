using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var loginFormu = ServiceProvider.GetRequiredService<LoginFormu>();
            loginFormu.ShowDialog();

            if (loginFormu.UgurluDaxilOlundu)
            {
                var anaMenuFormu = ServiceProvider.GetRequiredService<AnaMenuFormu>();
                Application.Run(anaMenuFormu);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Build configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            // Get connection string from configuration or use fallback
            string connectionString = configuration.GetConnectionString("DefaultConnection") ??
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

            // Formalar (Bütün formaları buraya əlavə edirik)
            services.AddTransient<LoginFormu>();
            services.AddTransient<AnaMenuFormu>();
            services.AddTransient<IstifadeciIdareetmeFormu>();
            services.AddTransient<AnbarFormu>();
            services.AddTransient<AnbarQaliqHesabatFormu>();
            services.AddTransient<BarkodCapiFormu>();
            services.AddTransient<HesabatFormu>();
            services.AddTransient<MehsulIdareetmeFormu>(provider =>
            {
                var mehsulManager = provider.GetRequiredService<MehsulManager>();
                return new MehsulIdareetmeFormu(mehsulManager, provider);
            });
            services.AddTransient<MehsulSatisHesabatFormu>();
            services.AddTransient<MusteriIdareetmeFormu>();
            services.AddTransient<NisyeIdareetmeFormu>();
            services.AddTransient<NovbeIdareetmesiFormu>();
            services.AddTransient<SatisFormu>(provider =>
            {
                var satisManager = provider.GetRequiredService<SatisManager>();
                var mehsulManager = provider.GetRequiredService<MehsulManager>();
                var musteriManager = provider.GetRequiredService<MusteriManager>();
                return new SatisFormu(satisManager, mehsulManager, musteriManager);
            });
            services.AddTransient<TemirIdareetmeFormu>(provider =>
            {
                var temirManager = provider.GetRequiredService<TemirManager>();
                var musteriManager = provider.GetRequiredService<MusteriManager>();
                var istifadeciManager = provider.GetRequiredService<IstifadeciManager>();
                return new TemirIdareetmeFormu(temirManager, musteriManager, istifadeciManager);
            });
            services.AddTransient<ZHesabatArxivFormu>();
            services.AddTransient<TedarukcuIdareetmeFormu>();
            services.AddTransient<IsciIdareetmeFormu>();
            services.AddTransient<QaytarmaFormu>();
            services.AddTransient<QaytarmaPresenter>();
        }
    }
}