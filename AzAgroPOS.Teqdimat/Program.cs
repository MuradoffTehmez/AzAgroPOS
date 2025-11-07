using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Konfiqurasiya;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realisasialar;
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
            // Global exception handler-lər
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            ApplicationConfiguration.Initialize();

            try
            {
                AzAgroPOS.Mentiq.Yardimcilar.Logger.KonfiqurasiyaEt();
            }
            catch (Exception logEx)
            {
                // Logger konfiqurasiyası uğursuz olsa belə, davam edirik
                MessageBox.Show(
                    $"Log sistemi konfiqurasiya edilərkən xəta baş verdi:\n{logEx.Message}\n\nTətbiq davam edəcək, lakin loglar yazılmayacaq.",
                    "Xəbərdarlıq",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            try
            {
                var services = new ServiceCollection();
                ConfigureServices(services);
                ServiceProvider = services.BuildServiceProvider();

                var loginFormu = ServiceProvider.GetRequiredService<LoginFormu>();
                var tehlukesizlikManager = ServiceProvider.GetRequiredService<TehlukesizlikManager>();
                var unitOfWork = ServiceProvider.GetRequiredService<IUnitOfWork>();
                var icazeManager = ServiceProvider.GetRequiredService<IcazeManager>();

                using (var loginPresenter = new LoginPresenter(loginFormu, tehlukesizlikManager, unitOfWork, icazeManager))
                {
                    loginFormu.InitializePresenter(loginPresenter);
                    var dialogResult = loginFormu.ShowDialog();

                    if (dialogResult == DialogResult.OK && loginFormu.UgurluDaxilOlundu)
                    {
                        var anaMenuFormu = ServiceProvider.GetRequiredService<AnaMenuFormu>();
                        Application.Run(anaMenuFormu);
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    AzAgroPOS.Mentiq.Yardimcilar.Logger.XetaYaz(ex, "Tətbiq səviyyəsində tutulmayan istisna baş verdi");
                    MessageBox.Show(
                        $"Tətbiqdə gözlənilməyən xəta baş verdi.\n\nXəta: {ex.Message}\n\nTəfərrüatlar log faylına yazıldı.",
                        "Xəta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch
                {
                    // Logger işləmirsə, tam xəta məlumatını göstər
                    MessageBox.Show(
                        $"Tətbiqdə gözlənilməyən xəta baş verdi və log faylı yaradıla bilmədi.\n\nXəta: {ex.Message}\n\nStackTrace:\n{ex.StackTrace}",
                        "Kritik Xəta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
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
                    options.UseSqlServer(connectionString, sql => sql.EnableRetryOnFailure()), ServiceLifetime.Scoped);

                services.AddScoped<IUnitOfWork, UnitOfWork>();

                // Repozitorilər
                services.AddScoped<IStokHareketiRepozitori, StokHareketiRepozitori>();
                services.AddScoped<IXercRepozitori, XercRepozitori>();
                services.AddScoped<IKassaHareketiRepozitori, KassaHareketiRepozitori>();

                // Menecerlər (Scoped çünki DbContext Scoped-dir)
                services.AddScoped<TehlukesizlikManager>();
                services.AddScoped<IstifadeciManager>();
                services.AddScoped<MehsulManager>();
                services.AddScoped<MehsulMeneceri>();
                services.AddScoped<MusteriManager>();
                services.AddScoped<SatisManager>();
                services.AddScoped<NisyeManager>();
                services.AddScoped<NovbeManager>();
                services.AddScoped<HesabatManager>();
                services.AddScoped<AnbarManager>();
                services.AddScoped<BarkodCapiManager>();
                services.AddScoped<TemirManager>();
                services.AddScoped<IsciManager>();
                services.AddScoped<AlisManager>();
                services.AddScoped<KateqoriyaMeneceri>();
                services.AddScoped<BrendMeneceri>();
                services.AddScoped<TedarukcuMeneceri>();
                services.AddScoped<KonfiqurasiyaManager>();
                services.AddScoped<IcazeManager>();
                services.AddScoped<StokHareketiManager>();
                services.AddScoped<QaytarmaManager>();
                services.AddScoped<MaliyyeManager>();

                // Presenterlər
                services.AddTransient<MehsulPresenter>();
                // MusteriPresenter is now manually created to avoid circular dependency
                // SatisPresenter and TemirPresenter are now manually created in AnaMenuFormu to avoid circular dependency
                services.AddTransient<QaytarmaPresenter>();
                services.AddTransient<XercPresenter>();
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
                // IMusteriView removed to avoid circular dependency with MusteriPresenter
                services.AddTransient<INisyeView, NisyeIdareetmeFormu>();
                services.AddTransient<INovbeView, NovbeIdareetmesiFormu>();
                // ISatisView and ITemirView removed to avoid circular dependency
                services.AddTransient<IEhtiyatHissəsiView, EhtiyatHissəsiFormu>();
                services.AddTransient<IZHesabatArxivView, ZHesabatArxivFormu>();
                services.AddTransient<ITedarukcuView, TedarukcuIdareetmeFormu>();
                services.AddTransient<IIsciView, IsciIdareetmeFormu>();
                services.AddTransient<IQaytarmaView, QaytarmaFormu>();
                services.AddTransient<IXercView, XercIdareetmeFormu>();
                services.AddTransient<IKonfiqurasiyaView, KonfiqurasiyaFormu>();
                services.AddTransient<IAlisSenedView, AlisSenedFormu>();
                services.AddTransient<IMinimumStokMehsullariView, MinimumStokMehsullariFormu>();

                // Login form has a special registration to avoid circular dependency
                services.AddTransient<LoginFormu>();

                // Other forms
                services.AddTransient<AnaMenuFormu>();
                services.AddTransient<MinimumStokMehsullariFormu>();
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
                services.AddTransient<XercIdareetmeFormu>();
                services.AddTransient<KonfiqurasiyaFormu>();
                services.AddTransient<AlisSenedFormu>();
                services.AddTransient<EmekHaqqiFormu>();
                services.AddTransient<IsciIzniFormu>();
                services.AddTransient<KassaFormu>();
                services.AddTransient<QebzFormu>();
                services.AddTransient<BazaIdareetmeFormu>();
                services.AddTransient<TedarukcuOdemeFormu>();
                services.AddTransient<AlisSifarisFormu>();
                services.AddTransient<BonusIdareetmeFormu>();
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
                AzAgroPOS.Mentiq.Yardimcilar.Logger.MelumatYaz("Verilənlər bazasına uğurla qoşuldu");
            }
            catch (SqlException ex)
            {
                string detailedMessage = $"Verilənlər bazasına qoşulmaq mümkün olmadı.\n\n" +
                    $"İstifadə edilən connection string: {MaskConnectionString(connectionString)}\n\n" +
                    $"Xəta kodu: {ex.Number}\n" +
                    $"Xəta mesajı: {ex.Message}\n\n" +
                    $"Həll yolları:\n" +
                    $"1. SQL Server (LocalDB) quraşdırılıb və işləyir?\n" +
                    $"   - Visual Studio ilə gəlir və ya ayrıca quraşdırıla bilər\n" +
                    $"   - Yoxlamaq üçün: Services.msc-də 'SQL Server' axtarın\n\n" +
                    $"2. appsettings.json faylındakı \"DefaultConnection\" sətirini yoxlayın\n" +
                    $"   Fayl yolu: {Path.Combine(AppContext.BaseDirectory, "appsettings.json")}\n\n" +
                    $"3. Və ya AZAGROPOS__CONNECTIONSTRING mühit dəyişənini təyin edin\n\n" +
                    $"4. SQL Server Management Studio (SSMS) ilə bağlantını test edin";

                throw new InvalidOperationException(detailedMessage, ex);
            }
        }

        private static string MaskConnectionString(string connectionString)
        {
            // Password-u gizlətmək üçün
            var builder = new SqlConnectionStringBuilder(connectionString);
            if (!string.IsNullOrEmpty(builder.Password))
            {
                builder.Password = "****";
            }
            return builder.ConnectionString;
        }

        /// <summary>
        /// UI thread-də baş verən tutulmamış istisnaları idarə edir
        /// </summary>
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleUnhandledException(e.Exception, "UI Thread Exception");
        }

        /// <summary>
        /// Non-UI thread-də baş verən tutulmamış istisnaları idarə edir
        /// </summary>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception exception)
            {
                HandleUnhandledException(exception, "Non-UI Thread Exception", e.IsTerminating);
            }
        }

        /// <summary>
        /// Tutulmamış istisnaları log edir və istifadəçiyə bildirir
        /// </summary>
        private static void HandleUnhandledException(Exception exception, string source, bool isTerminating = false)
        {
            try
            {
                // Xətanı log-a yaz
                AzAgroPOS.Mentiq.Yardimcilar.Logger.XetaYaz(exception, $"{source} - Tutulmamış istisna baş verdi");

                // İstifadəçiyə mesaj göstər
                string message = isTerminating
                    ? $"Tətbiqdə kritik xəta baş verdi və tətbiq bağlanacaq.\n\nXəta: {exception.Message}\n\nTəfərrüatlar log faylına yazıldı."
                    : $"Tətbiqdə gözlənilməyən xəta baş verdi.\n\nXəta: {exception.Message}\n\nTəfərrüatlar log faylına yazıldı.";

                MessageBox.Show(
                    message,
                    "Xəta",
                    MessageBoxButtons.OK,
                    isTerminating ? MessageBoxIcon.Error : MessageBoxIcon.Warning);
            }
            catch
            {
                // Əgər log yazmaq belə uğursuz olarsa, ən azı MessageBox göstər
                try
                {
                    MessageBox.Show(
                        $"Tətbiqdə kritik xəta baş verdi və log faylı yaradıla bilmədi.\n\nXəta: {exception.Message}",
                        "Kritik Xəta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch
                {
                    // Son çarə - heç nə etmə, tətbiqi çökməyə qoy
                }
            }

            // Əgər terminating isə, tətbiqi bağla
            if (isTerminating)
            {
                Environment.Exit(1);
            }
        }
    }
}
