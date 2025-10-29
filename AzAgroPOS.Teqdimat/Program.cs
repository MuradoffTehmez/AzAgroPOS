using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Konfiqurasiya;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using Microsoft.Data.SqlClient;
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


            AzAgroPOS.Mentiq.Yardimcilar.Logger.KonfiqurasiyaEt();

            try
            {
                var services = new ServiceCollection();
                ConfigureServices(services);
                ServiceProvider = services.BuildServiceProvider();

                var loginFormu = ServiceProvider.GetRequiredService<LoginFormu>();
                var tehlukesizlikManager = ServiceProvider.GetRequiredService<TehlukesizlikManager>();
                var unitOfWork = ServiceProvider.GetRequiredService<IUnitOfWork>();
                var loginPresenter = new LoginPresenter(loginFormu, tehlukesizlikManager, unitOfWork);
                loginFormu.InitializePresenter(loginPresenter);
                var dialogResult = loginFormu.ShowDialog();

                if (dialogResult == DialogResult.OK && loginFormu.UgurluDaxilOlundu)
                {
                    var anaMenuFormu = ServiceProvider.GetRequiredService<AnaMenuFormu>();
                    Application.Run(anaMenuFormu);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("XƏTA - " + ex.Message + ex.StackTrace , "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    AzAgroPOS.Mentiq.Yardimcilar.Logger.XetaYaz(ex, "Tətbiq səviyyəsində tutulmayan istisna baş verdi");
                    MessageBox.Show("Tətbiqdə gözlənilməyən xəta baş verdi. \nTəfərrüatlar log faylına yazıldı. \n\n" + ex.Message + ex.StackTrace, "Xəta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Tətbiqdə gözlənilməyən xəta baş verdi. Log faylı yaradıla bilmədi.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            try
            {
                IConfiguration configuration = ConnectionStringResolver.BuildConfiguration(AppContext.BaseDirectory);

                string connectionString = ConnectionStringResolver.Resolve(configuration, Sabitler.DefaultConnection);

                EnsureDatabaseAccessible(connectionString);

                services.AddSingleton(configuration);

                services.AddDbContext<AzAgroPOSDbContext>(options =>
                    options.UseSqlServer(connectionString, sql => sql.EnableRetryOnFailure()), ServiceLifetime.Transient);

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
                services.AddTransient<MehsulPresenter>();
                services.AddTransient<MusteriPresenter>();
                services.AddTransient<SatisPresenter>();
                services.AddTransient<TemirPresenter>();
                services.AddTransient<QaytarmaPresenter>();
                services.AddTransient<AlisSenedPresenter>();

                // Interface-lər və onların implementasiyaları
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
                services.AddTransient<IAlisSenedView, AlisSenedFormu>();

                // Login form has a special registration to avoid circular dependency
                services.AddTransient<LoginFormu>();

                // Other forms
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
                services.AddTransient<AlisSenedFormu>(); // Əlavə edildi
            }
            catch (Exception ex)
            {
                // Log the configuration error and rethrow
                AzAgroPOS.Mentiq.Yardimcilar.Logger.XetaYaz(ex, "Servis konfiqurasiya edilərkən xəta baş verdi");
                throw; // Rethrow to be caught by the main try-catch
            }
        }

        private static void EnsureDatabaseAccessible(string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(
                    "Verilənlər bazasına qoşulmaq mümkün olmadı. Zəhmət olmasa appsettings.json faylındakı \"DefaultConnection\" sətirini yeniləyin və ya AZAGROPOS__CONNECTIONSTRING mühit dəyişənini təyin edin.",
                    ex);
            }
        }
    }
}
