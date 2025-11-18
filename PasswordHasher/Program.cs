using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== BCrypt Password Hash Generator ===");
        Console.WriteLine();

        // Generate hash for "admin123"
        string password = "admin123";
        string hash = BCrypt.Net.BCrypt.HashPassword(password);

        Console.WriteLine($"Password: {password}");
        Console.WriteLine($"BCrypt Hash: {hash}");
        Console.WriteLine();

        // Verify it works
        bool verified = BCrypt.Net.BCrypt.Verify(password, hash);
        Console.WriteLine($"Verification Test: {(verified ? "SUCCESS ✓" : "FAILED ✗")}");
        Console.WriteLine();

        // Generate SQL update command
        Console.WriteLine("=== SQL Update Command ===");
        Console.WriteLine($"UPDATE Istifadeciler SET ParolHash = '{hash}', UgursuzGirisCehdi = 0, HesabKilidlenmeTarixi = NULL, SonSifreDeyismeTarixi = GETDATE() WHERE Id = 1;");
        Console.WriteLine();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
