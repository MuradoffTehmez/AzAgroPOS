using System;
using System.Data.SqlClient;

class DatabaseTest
{
    static void Main()
    {
        // Test connection string
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=AzAgroPOS_DB;Trusted_Connection=true;TrustServerCertificate=True;";
        
        try
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connection successful!");
                Console.WriteLine($"Server Version: {connection.ServerVersion}");
                Console.WriteLine($"Database: {connection.Database}");
                connection.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Connection failed: {ex.Message}");
            
            // Try alternative connection strings
            TestAlternativeConnections();
        }
        
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
    
    static void TestAlternativeConnections()
    {
        string[] connectionStrings = {
            @"Server=.\SQLEXPRESS;Database=AzAgroPOS_DB;Trusted_Connection=True;TrustServerCertificate=True;",
            @"Server=(localdb)\MSSQLLocalDB;Database=master;Trusted_Connection=true;TrustServerCertificate=True;",
            @"Server=localhost;Database=AzAgroPOS_DB;Trusted_Connection=true;TrustServerCertificate=True;"
        };
        
        string[] descriptions = {
            "SQL Server Express",
            "LocalDB master database",
            "Localhost connection"
        };
        
        for (int i = 0; i < connectionStrings.Length; i++)
        {
            try
            {
                using (var connection = new SqlConnection(connectionStrings[i]))
                {
                    connection.Open();
                    Console.WriteLine($"Alternative connection successful: {descriptions[i]}");
                    Console.WriteLine($"Server Version: {connection.ServerVersion}");
                    connection.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Alternative connection failed [{descriptions[i]}]: {ex.Message}");
            }
        }
    }
}