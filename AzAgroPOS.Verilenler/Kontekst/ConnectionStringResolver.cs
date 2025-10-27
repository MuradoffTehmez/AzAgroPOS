using System;
using Microsoft.Extensions.Configuration;

namespace AzAgroPOS.Verilenler.Kontekst;

/// <summary>
/// Helper to centralize connection string discovery logic across the solution.
/// </summary>
public static class ConnectionStringResolver
{
    private const string DefaultConnectionName = "DefaultConnection";
    private const string EnvironmentVariableKey = "AZAGROPOS__CONNECTIONSTRING";
    private const string DefaultFallback =
        "Server=(localdb)\\\\MSSQLLocalDB;Database=AzAgroPOS_DB;Trusted_Connection=True;TrustServerCertificate=True;";

    /// <summary>
    /// Builds a configuration root with the standard appsettings chain and optional local overrides.
    /// </summary>
    public static IConfiguration BuildConfiguration(string basePath)
    {
        return new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
            .Build();
    }

    /// <summary>
    /// Resolves the connection string, preferring environment overrides, then configuration, then a sane fallback.
    /// </summary>
    public static string Resolve(IConfiguration configuration, string? connectionName = null)
    {
        var envConnection = Environment.GetEnvironmentVariable(EnvironmentVariableKey);
        if (!string.IsNullOrWhiteSpace(envConnection))
        {
            return envConnection;
        }

        connectionName ??= DefaultConnectionName;

        var configConnection = configuration.GetConnectionString(connectionName);
        if (!string.IsNullOrWhiteSpace(configConnection))
        {
            return configConnection;
        }

        var flatConnection = configuration[connectionName] ?? configuration["ConnectionString"];
        if (!string.IsNullOrWhiteSpace(flatConnection))
        {
            return flatConnection!;
        }

        return DefaultFallback;
    }
}
