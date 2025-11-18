// Temporary C# file to generate BCrypt hash
using System;

class Program
{
    static void Main()
    {
        string password = "admin123";

        // Generate BCrypt hash using the same library as the application
        string hash = BCrypt.Net.BCrypt.HashPassword(password);

        Console.WriteLine("Password: " + password);
        Console.WriteLine("BCrypt Hash: " + hash);
        Console.WriteLine();
        Console.WriteLine("SQL Update Command:");
        Console.WriteLine($"UPDATE Istifadeciler SET ParolHash = '{hash}', UgursuzGirisCehdi = 0, HesabKilidlenmeTarixi = NULL WHERE Id = 1;");

        // Verify the hash works
        bool verified = BCrypt.Net.BCrypt.Verify(password, hash);
        Console.WriteLine();
        Console.WriteLine("Verification: " + (verified ? "SUCCESS" : "FAILED"));
    }
}
