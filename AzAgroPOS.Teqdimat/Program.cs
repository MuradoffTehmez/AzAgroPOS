using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realisasialar;
using AzAgroPOS.Verilenler.Realizasialar;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;

namespace AzAgroPOS.Teqdimat
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        // ─── Exception növləri üçün exit kodları ───────────────────────────
        private const int EXIT_SUCCESS = 0;
        private const int EXIT_UNHANDLED_ERROR = 1;
        private const int EXIT_DB_ERROR = 2;
        private const int EXIT_CONFIG_ERROR = 3;
        private const int EXIT_LOGGER_ERROR = 4;

        [STAThread]
        static void Main()
        {
            // ── 1. Global exception handler-ləri qeydiyyatdan keçir ────────
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.FirstChanceException += FirstChanceException_Handler;

            ApplicationConfiguration.Initialize();

            // ── 2. Logger konfiqurasiyası ──────────────────────────────────
            if (!InitializeLogger())
                return; // kritik: logger olmadan davam etmirik

            // ── 3. DI + Verilənlər bazası + UI ────────────────────────────
            try
            {
                var services = new ServiceCollection();
                ConfigureServices(services);
                ServiceProvider = services.BuildServiceProvider();

                RunApplication();
            }
            catch (InvalidOperationException ex)
                when (ex.InnerException is SqlException sqlEx)
            {
                // Verilənlər bazası bağlantı xətası
                LogAndShow(
                    ex,
                    "VB Bağlantı Xətası",
                    $"SQL Xəta Kodu : {sqlEx.Number}\n" +
                    $"SQL State     : {sqlEx.State}\n" +
                    $"Server        : {sqlEx.Server}\n" +
                    BuildInnerExceptionChain(ex),
                    EXIT_DB_ERROR,
                    terminate: true);
            }
            catch (InvalidOperationException ex)
            {
                // Konfiqurasiya / DI xətaları
                LogAndShow(
                    ex,
                    "Konfiqurasiya Xətası",
                    $"Xəta növü : {ex.GetType().FullName}\n" +
                    BuildInnerExceptionChain(ex),
                    EXIT_CONFIG_ERROR,
                    terminate: true);
            }
            catch (DbUpdateException ex)
            {
                // EF Core-dan gələn VB yeniləmə xətaları
                LogAndShow(
                    ex,
                    "Verilənlər Bazası Yeniləmə Xətası",
                    $"EF Core xətası.\n{BuildInnerExceptionChain(ex)}",
                    EXIT_DB_ERROR,
                    terminate: true);
            }
            catch (COMException ex)
            {
                // COM/Printer xətaları (Xprinter, Zebra vs.)
                LogAndShow(
                    ex,
                    "Printer / COM Xətası",
                    $"HRESULT : 0x{ex.HResult:X8}\n" +
                    $"Xəta Kodu : {ex.ErrorCode}",
                    EXIT_UNHANDLED_ERROR,
                    terminate: false);
            }
            catch (Exception ex)
            {
                // Ümumi tutulmamış istisna
                LogAndShow(
                    ex,
                    "Gözlənilməyən Xəta",
                    $"Xəta növü : {ex.GetType().FullName}\n" +
                    $"Mənbə     : {ex.Source}\n" +
                    BuildInnerExceptionChain(ex),
                    EXIT_UNHANDLED_ERROR,
                    terminate: true);
            }
        }

        // ══════════════════════════════════════════════════════════════════
        //  TƏTBIQ İŞƏ SALMA
        // ══════════════════════════════════════════════════════════════════

        private static void RunApplication()
        {
            var loginFormu = ServiceProvider.GetRequiredService<LoginFormu>();
            var tehlukesizlikManager = ServiceProvider.GetRequiredService<TehlukesizlikManager>();
            var unitOfWork = ServiceProvider.GetRequiredService<IUnitOfWork>();
            var icazeManager = ServiceProvider.GetRequiredService<IcazeManager>();

            using var loginPresenter = new LoginPresenter(
                loginFormu, tehlukesizlikManager, unitOfWork, icazeManager, ServiceProvider);

            loginFormu.InitializePresenter(loginPresenter);

            var dialogResult = loginFormu.ShowDialog();

            if (dialogResult == DialogResult.OK && loginFormu.UgurluDaxilOlundu)
            {
                var anaMenuFormu = ServiceProvider.GetRequiredService<AnaMenuFormu>();
                Application.Run(anaMenuFormu);
            }
        }

        // ══════════════════════════════════════════════════════════════════
        //  LOGGER İNİSİALİZASİYASI
        // ══════════════════════════════════════════════════════════════════

        /// <summary>
        /// Xətanı log edir, istifadəçiyə göstərir və lazım olsa tətbiqi bağlayır.
        /// </summary>
        private static void LogAndShow(
            Exception ex,
            string başlıq,
            string əlavəMəlumat,
            int exitCode,
            bool terminate)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"Xəta növü : {ex.GetType().FullName}");
            sb.AppendLine($"Mesaj     : {ex.Message}");

            if (!string.IsNullOrWhiteSpace(əlavəMəlumat))
            {
                sb.AppendLine();
                sb.AppendLine(əlavəMəlumat);
            }

            if (terminate)
            {
                sb.AppendLine();
                sb.AppendLine("Tətbiq bağlanacaq.");
            }

            string tam = sb.ToString();

            TrySafeLog($"[{başlıq}] {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");

            MessageBox.Show(
                tam,
                başlıq,
                MessageBoxButtons.OK,
                terminate ? MessageBoxIcon.Error : MessageBoxIcon.Warning);

            if (terminate)
                Environment.Exit(exitCode);
        }

        private static bool InitializeLogger()
        {
            try
            {
                AzAgroPOS.Mentiq.Yardimcilar.Logger.KonfiqurasiyaEt();
                AzAgroPOS.Mentiq.Yardimcilar.Logger.MelumatYaz(
                    $"=== AzAgroPOS Başladı | " +
                    $"OS: {Environment.OSVersion} | " +
                    $".NET: {Environment.Version} | " +
                    $"User: {Environment.UserName} ===");
                return true;
            }
            catch (UnauthorizedAccessException ex)
            {
                // Log qovluğuna yazma icazəsi yoxdur
                ShowError(
                    "Logger İcazə Xətası",
                    $"Log qovluğuna yazma icazəniz yoxdur.\n\n" +
                    $"Qovluq: {ex.Message}\n\n" +
                    $"Həll: Tətbiqi Administrator kimi işə salın.");
                Environment.Exit(EXIT_LOGGER_ERROR);
                return false;
            }
            catch (IOException ex)
            {
                ShowError(
                    "Logger I/O Xətası",
                    $"Log faylı yaradıla bilmədi (disk dolu ola bilər).\n\n{ex.Message}");
                // I/O xətasında DAVAM edirik — logger olmadan çalışırıq
                return true;
            }
            catch (Exception ex)
            {
                ShowError(
                    "Logger Xətası",
                    $"Log sistemi başladıla bilmədi:\n{ex.Message}\n\nTətbiq davam edəcək.",
                    isWarning: true);
                return true; // logger xətası kritik deyil
            }
        }

        // ══════════════════════════════════════════════════════════════════
        //  SERVİS KONFİQURASİYASI
        // ══════════════════════════════════════════════════════════════════

        private static void ConfigureServices(IServiceCollection services)
        {
            // ── Konfiqurasiya ──────────────────────────────────────────────
            IConfiguration configuration;
            try
            {
                configuration = ConnectionStringResolver.BuildConfiguration(AppContext.BaseDirectory);
            }
            catch (FileNotFoundException ex)
            {
                throw new InvalidOperationException(
                    $"appsettings.json tapılmadı.\nGözlənilən yer: {ex.FileName}", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    $"Konfiqurasiya faylı oxunarkən xəta baş verdi.", ex);
            }

            // ── Connection String ──────────────────────────────────────────
            string connectionString;
            try
            {
                connectionString = ConnectionStringResolver.Resolve(
                    configuration, Konfiqurasiya.Sabitler.DefaultConnection);

                if (string.IsNullOrWhiteSpace(connectionString))
                    throw new InvalidOperationException(
                        "Connection string boşdur. appsettings.json-da 'DefaultConnection' dəyərini yoxlayın.");
            }
            catch (InvalidOperationException) { throw; }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "Connection string alınarkən gözlənilməyən xəta baş verdi.", ex);
            }

            // ── VB əlçatanlıq yoxlaması ────────────────────────────────────
            EnsureDatabaseAccessible(connectionString);

            // ── Servisləri qeydiyyatdan keçir ─────────────────────────────
            try
            {
                services.AddSingleton(configuration);

                services.AddDbContext<AzAgroPOSDbContext>(options =>
                    options.UseSqlServer(connectionString, sql =>
                    {
                        sql.EnableRetryOnFailure(
                            maxRetryCount: 3,
                            maxRetryDelay: TimeSpan.FromSeconds(5),
                            errorNumbersToAdd: null);
                        sql.CommandTimeout(30);
                    }),
                    ServiceLifetime.Scoped);

                services.AddScoped<IUnitOfWork, UnitOfWork>();

                // Repozitorilər
                services.AddScoped<IStokHareketiRepozitori, StokHareketiRepozitori>();
                services.AddScoped<IXercRepozitori, XercRepozitori>();
                services.AddScoped<IKassaHareketiRepozitori, KassaHareketiRepozitori>();

                // Menecerlər
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
                services.AddScoped<EmekHaqqiManager>();
                services.AddScoped<IsciIzniManager>();
                services.AddScoped<BazaIdareetmeManager>(sp =>
                    new BazaIdareetmeManager(connectionString));

                // Presenterlər
                services.AddTransient<MehsulPresenter>();
                services.AddTransient<QaytarmaPresenter>();
                services.AddTransient<XercPresenter>();
                services.AddTransient<AlisSenedPresenter>();

                // Interface → Form binding-ləri
                services.AddTransient<IAnaMenuView, AnaMenuFormu>();
                services.AddTransient<IIstifadeciView, IstifadeciIdareetmeFormu>();
                services.AddTransient<IAnbarView, AnbarFormu>();
                services.AddTransient<IAnbarQaliqHesabatView, AnbarQaliqHesabatFormu>();
                services.AddTransient<IBarkodCapiView, BarkodCapiFormu>();
                services.AddTransient<IHesabatView, HesabatFormu>();
                services.AddTransient<IMehsulIdareetmeView, MehsulIdareetmeFormu>();
                services.AddTransient<IMehsulSatisHesabatView, MehsulSatisHesabatFormu>();
                services.AddTransient<INisyeView, NisyeIdareetmeFormu>();
                services.AddTransient<INovbeView, NovbeIdareetmesiFormu>();
                services.AddTransient<IEhtiyatHissəsiView, EhtiyatHissəsiFormu>();
                services.AddTransient<IZHesabatArxivView, ZHesabatArxivFormu>();
                services.AddTransient<ITedarukcuView, TedarukcuIdareetmeFormu>();
                services.AddTransient<IIsciView, IsciIdareetmeFormu>();
                services.AddTransient<IQaytarmaView, QaytarmaFormu>();
                services.AddTransient<IXercView, XercIdareetmeFormu>();
                services.AddTransient<IKonfiqurasiyaView, KonfiqurasiyaFormu>();
                services.AddTransient<IAlisSenedView, AlisSenedFormu>();
                services.AddTransient<IMinimumStokMehsullariView, MinimumStokMehsullariFormu>();

                // Formlar
                services.AddTransient<LoginFormu>();
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

                AzAgroPOS.Mentiq.Yardimcilar.Logger.MelumatYaz(
                    $"DI konteyneri uğurla quruldu. " +
                    $"Qeydiyyatlı servis sayı: {services.Count}");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "DI konteyneri qurularkən xəta baş verdi.", ex);
            }
        }

        // ══════════════════════════════════════════════════════════════════
        //  VERİLƏNLƏR BAZASI ƏLÇATANLIQ YOXLAMASI
        // ══════════════════════════════════════════════════════════════════

        private static void EnsureDatabaseAccessible(string connectionString)
        {
            const int maxRetry = 3;
            const int retryDelay = 2000; // ms

            for (int attempt = 1; attempt <= maxRetry; attempt++)
            {
                using var connection = new SqlConnection(connectionString);
                try
                {
                    connection.Open();

                    // Əlavə yoxlama: real sorğu göndər
                    using var cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT @@VERSION";
                    cmd.CommandTimeout = 10;
                    var version = cmd.ExecuteScalar()?.ToString();

                    AzAgroPOS.Mentiq.Yardimcilar.Logger.MelumatYaz(
                        $"VB bağlantısı uğurlu (cəhd #{attempt}). " +
                        $"SQL Server: {version?.Split('\n')[0].Trim()}");
                    return; // uğurlu — çıxırıq
                }
                catch (SqlException ex) when (IsFatalSqlError(ex.Number))
                {
                    // Yenidən cəhd etməyə dəyməyən kritik SQL xətaları
                    throw new InvalidOperationException(BuildSqlErrorMessage(connectionString, ex), ex);
                }
                catch (SqlException ex)
                {
                    AzAgroPOS.Mentiq.Yardimcilar.Logger.XeberdarliqYaz(
                        $"VB bağlantı cəhdi #{attempt} uğursuz oldu. " +
                        $"Kod: {ex.Number}, Mesaj: {ex.Message}");

                    if (attempt == maxRetry)
                        throw new InvalidOperationException(BuildSqlErrorMessage(connectionString, ex), ex);

                    Thread.Sleep(retryDelay);
                }
                catch (InvalidOperationException ex)
                {
                    // Connection string sintaksis xətası
                    throw new InvalidOperationException(
                        $"Connection string düzgün formatda deyil:\n{ex.Message}", ex);
                }
                catch (Exception ex)
                {
                    // Gözlənilməyən xəta (şəbəkə, DNS, socket...)
                    throw new InvalidOperationException(
                        $"Verilənlər bazasına qoşularkən gözlənilməyən xəta:\n" +
                        $"Növ: {ex.GetType().FullName}\n{ex.Message}", ex);
                }
            }
        }

        /// <summary>
        /// Yenidən cəhd etməyə dəyməyən SQL Server xəta kodları
        /// </summary>
        private static bool IsFatalSqlError(int errorNumber) => errorNumber switch
        {
            18456 => true, // Login failed
            4060 => true, // Cannot open database
            18452 => true, // Login from untrusted domain
            547 => true, // Constraint violation (konfigurasiya xətası)
            _ => false
        };

        private static string BuildSqlErrorMessage(string connectionString, SqlException ex)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("═══ VERİLƏNLƏR BAZASI BAĞLANTI XƏTAı ═══");
            sb.AppendLine();
            sb.AppendLine($"Connection String : {MaskConnectionString(connectionString)}");
            sb.AppendLine($"SQL Xəta Kodu     : {ex.Number}");
            sb.AppendLine($"SQL State         : {ex.State}");
            sb.AppendLine($"Server            : {ex.Server}");
            sb.AppendLine($"Prosedur          : {ex.Procedure}");
            sb.AppendLine($"Sətir             : {ex.LineNumber}");
            sb.AppendLine();
            sb.AppendLine($"Xəta mesajı: {ex.Message}");
            sb.AppendLine();
            sb.AppendLine("Həll yolları:");
            sb.AppendLine("  1. SQL Server servisinin işlədiyini yoxlayın (services.msc)");
            sb.AppendLine("  2. appsettings.json-dakı DefaultConnection dəyərini yoxlayın");
            sb.AppendLine($"     Fayl: {Path.Combine(AppContext.BaseDirectory, "appsettings.json")}");
            sb.AppendLine("  3. AZAGROPOS__CONNECTIONSTRING mühit dəyişənini yoxlayın");
            sb.AppendLine("  4. SSMS ilə manual bağlantı test edin");

            if (ex.Number == 18456)
                sb.AppendLine("  5. SQL Server login/şifrəni yoxlayın (Xəta 18456: Login failed)");
            else if (ex.Number == 4060)
                sb.AppendLine("  5. Verilənlər bazasının mövcudluğunu yoxlayın (Xəta 4060)");

            return sb.ToString();
        }

        // ══════════════════════════════════════════════════════════════════
        //  GLOBAL EXCEPTION HANDLER-LƏR
        // ══════════════════════════════════════════════════════════════════

        private static void Application_ThreadException(
            object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleUnhandledException(e.Exception, "UI Thread", isTerminating: false);
        }

        private static void CurrentDomain_UnhandledException(
            object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception exception)
                HandleUnhandledException(exception, "Non-UI Thread", e.IsTerminating);
        }

        /// <summary>
        /// İlk şans exception handler — yalnız log üçün, prosesi dayandırmır.
        /// Development mühitində hansı xətaların baş verdiyini erkən görmək üçündür.
        /// </summary>
        private static void FirstChanceException_Handler(
            object? sender,
            System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            // Yalnız ciddi exception növlərini log et (əks halda çox hay-küy olur)
            if (e.Exception is OutOfMemoryException or StackOverflowException or AccessViolationException)
            {
                TrySafeLog(
                    $"[FIRST_CHANCE] KRİTİK: {e.Exception.GetType().Name} — {e.Exception.Message}");
            }
        }

        private static void HandleUnhandledException(
            Exception exception, string mənbə, bool isTerminating)
        {
            // Xəta növünə görə fərqli reaksiya
            string başlıq = isTerminating ? "Kritik Xəta" : "Xəta";
            string icon_məlumat = isTerminating
                ? "Tətbiq bağlanacaq."
                : "Əməliyyat ləğv edildi, tətbiq davam edir.";

            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"Mənbə    : {mənbə}");
            sb.AppendLine($"Növ      : {exception.GetType().FullName}");
            sb.AppendLine($"Mesaj    : {exception.Message}");
            sb.AppendLine($"Modul    : {exception.Source}");
            sb.AppendLine();
            sb.Append(BuildInnerExceptionChain(exception));
            sb.AppendLine();
            sb.AppendLine(icon_məlumat);

            // 1. Log-a yaz
            TrySafeLog($"[{mənbə}] {exception.GetType().Name}: {exception.Message}\n{exception.StackTrace}");

            // 2. İstifadəçiyə göstər
            try
            {
                MessageBox.Show(
                    sb.ToString(),
                    başlıq,
                    MessageBoxButtons.OK,
                    isTerminating ? MessageBoxIcon.Error : MessageBoxIcon.Warning);
            }
            catch
            {
                // MessageBox belə işləmirsə — son çarə: konsol
                Console.Error.WriteLine($"[{başlıq}] {sb}");
            }

            if (isTerminating)
                Environment.Exit(EXIT_UNHANDLED_ERROR);
        }

        // ══════════════════════════════════════════════════════════════════
        //  KÖMƏKÇİ METODLAR
        // ══════════════════════════════════════════════════════════════════

        /// <summary>
        /// Bütün InnerException zəncirini oxuyaraq mətn şəklində qaytarır.
        /// </summary>
        private static string BuildInnerExceptionChain(Exception ex)
        {
            var sb = new System.Text.StringBuilder();
            var inner = ex.InnerException;
            int səviyyə = 1;

            while (inner != null)
            {
                sb.AppendLine($"Inner [{səviyyə}]: {inner.GetType().Name} — {inner.Message}");

                if (inner is SqlException sqlEx)
                {
                    sb.AppendLine($"  SQL Kodu  : {sqlEx.Number}");
                    sb.AppendLine($"  SQL State : {sqlEx.State}");
                    sb.AppendLine($"  Server    : {sqlEx.Server}");

                    foreach (SqlError error in sqlEx.Errors)
                        sb.AppendLine($"  SQL Error : [{error.Number}] {error.Message} (Proc: {error.Procedure}, Line: {error.LineNumber})");
                }

                inner = inner.InnerException;
                səviyyə++;
            }

            return sb.Length > 0 ? sb.ToString() : string.Empty;
        }

        /// <summary>
        /// Logger özü xəta versə belə çökmədən log etməyə cəhd edir.
        /// </summary>
        private static void TrySafeLog(string məlumat)
        {
            try
            {
                AzAgroPOS.Mentiq.Yardimcilar.Logger.XetaYaz(
                    new Exception(məlumat), məlumat);
            }
            catch
            {
                try
                {
                    // Fallback: faylı birbaşa yaz
                    var logPath = Path.Combine(AppContext.BaseDirectory, "logs", "emergency.log");
                    Directory.CreateDirectory(Path.GetDirectoryName(logPath)!);
                    File.AppendAllText(logPath,
                        $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {məlumat}{Environment.NewLine}");
                }
                catch { /* Son çarə: heç nə — prosesi dayandırmırıq */ }
            }
        }

        private static void ShowError(string başlıq, string məlumat, bool isWarning = false)
        {
            MessageBox.Show(
                məlumat, başlıq,
                MessageBoxButtons.OK,
                isWarning ? MessageBoxIcon.Warning : MessageBoxIcon.Error);
        }

        private static string MaskConnectionString(string connectionString)
        {
            try
            {
                var builder = new SqlConnectionStringBuilder(connectionString);
                if (!string.IsNullOrEmpty(builder.Password))
                    builder.Password = "****";
                return builder.ConnectionString;
            }
            catch
            {
                return "[Connection string parse edilə bilmədi]";
            }
        }
    }
}