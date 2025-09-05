using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

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
            // Use a more flexible connection string that can work on different machines
            string connectionString = "Server=MURADOV-TAHMAZ\\TAHMAZ_MURADOV;Database=AzAgroPOS_DB;Trusted_Connection=True;TrustServerCertificate=True;";

            services.AddDbContext<AzAgroPOSDbContext>(options =>
                options.UseSqlServer(connectionString), ServiceLifetime.Transient);

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Menecerlər
            services.AddTransient<TehlukesizlikManager>();
            services.AddTransient<IstifadeciManager>();
            services.AddTransient<MehsulManager>();
            services.AddTransient<MusteriManager>();
            services.AddTransient<SatisManager>();
            services.AddTransient<NisyeManager>();
            services.AddTransient<NovbeManager>();
            services.AddTransient<HesabatManager>();
            services.AddTransient<AnbarManager>();
            services.AddTransient<BarkodCapiManager>();
            services.AddTransient<TemirManager>();
            services.AddTransient<IsciManager>();

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
            services.AddTransient<ZHesabatArxivFormu>();
            services.AddTransient<IsciIdareetmeFormu>();
        }
    }
}