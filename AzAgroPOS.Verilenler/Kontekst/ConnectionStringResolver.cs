using Microsoft.Extensions.Configuration;

namespace AzAgroPOS.Verilenler.Kontekst;

/// <summary>
/// Helper to centralize connection string discovery logic across the solution.
/// </summary>
public static class ConnectionStringResolver
{
    private const string DefaultConnectionName = "DefaultConnection";
    private const string EnvironmentVariableKey = "AZAGROPOS__CONNECTIONSTRING";

    /// <summary>
    /// Builds a configuration root with the standard appsettings chain and optional local overrides.
    /// </summary>
    public static IConfiguration BuildConfiguration(string basePath)
    {
        // dotnet ef may start from the solution directory instead of the data project.
        if (!File.Exists(Path.Combine(basePath, "appsettings.json")))
        {
            string dataProjectPath = Path.Combine(basePath, "AzAgroPOS.Verilenler");
            if (File.Exists(Path.Combine(dataProjectPath, "appsettings.json")))
            {
                basePath = dataProjectPath;
            }
        }

        string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
                          ?? Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                          ?? "Production";

        IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
            .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);

        return builder.Build();
    }

    /// <summary>
    /// Resolves the connection string from environment overrides or configuration.
    /// </summary>
    public static string Resolve(IConfiguration configuration, string? connectionName = null)
    {
        connectionName ??= DefaultConnectionName;

        string[] environmentKeys =
        {
            $"AZAGROPOS__ConnectionStrings__{connectionName}",
            $"ConnectionStrings__{connectionName}",
            EnvironmentVariableKey
        };
        foreach (string key in environmentKeys)
        {
            string? value = Environment.GetEnvironmentVariable(key);
            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }
        }

        string? configConnection = configuration.GetConnectionString(connectionName);
        if (!string.IsNullOrWhiteSpace(configConnection))
        {
            return configConnection;
        }

        string? flatConnection = configuration[connectionName] ?? configuration["ConnectionString"];
        if (!string.IsNullOrWhiteSpace(flatConnection))
        {
            return flatConnection;
        }

        throw new InvalidOperationException(
            $"ConnectionStrings:{connectionName} konfiqurasiyada tapılmadı.");
    }
}
