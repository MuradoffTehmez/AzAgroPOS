using System;
using System.Configuration;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Security
{
    /// <summary>
    /// ConfigProtector-un düzgün işlədiyini test etmək üçün köməkçi sinif
    /// Debug və test məqsədilə istifadə olunur
    /// </summary>
    public static class ConfigProtectionTest
    {
        /// <summary>
        /// Connection string-in şifrələnmə vəziyyətini yoxlayır və ekranda göstərir
        /// </summary>
        public static void ShowProtectionStatus()
        {
            try
            {
                bool isProtected = ConfigProtector.IsConnectionStringProtected();
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString ?? "Tapılmadı";
                
                string message = $"Connection String Qoruma Statusu:\n\n" +
                               $"Şifrələnib: {(isProtected ? "✅ BƏLİ" : "❌ XEYİR")}\n\n" +
                               $"Connection String:\n{connectionString}\n\n" +
                               $"Qeyd: Şifrələnmiş connection string-lər oxunaqlı deyil, " +
                               $"amma sistem daxilində düzgün işləyir.";

                MessageBox.Show(message, "ConfigProtector Test", MessageBoxButtons.OK, 
                              isProtected ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Test zamanı xəta:\n{ex.Message}", "Test Xətası", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// App.config faylının mövcudluğunu və connection string bölməsini yoxlayır
        /// </summary>
        public static void ValidateConfigFile()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                
                if (config == null)
                {
                    MessageBox.Show("❌ Configuration fayl tapılmadı!", "Validation Xətası", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var connectionStringsSection = config.GetSection("connectionStrings");
                if (connectionStringsSection == null)
                {
                    MessageBox.Show("❌ ConnectionStrings bölməsi tapılmadı!", "Validation Xətası", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var defaultConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"];
                if (defaultConnection == null)
                {
                    MessageBox.Show("❌ 'DefaultConnection' adlı connection string tapılmadı!", "Validation Xətası", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("✅ Configuration fayl düzgün qurulub!\n\n" +
                              $"Config fayl yolu: {config.FilePath}\n" +
                              $"Connection adı: {defaultConnection.Name}\n" +
                              $"Provider: {defaultConnection.ProviderName}", 
                              "Validation Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Validation zamanı xəta:\n{ex.Message}", "Validation Xətası", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// DPAPI-nin sistemdə işlədiyini yoxlayır
        /// </summary>
        public static void TestDPAPI()
        {
            try
            {
                // Sadə DPAPI test
                string testData = "AzAgroPOS DPAPI Test " + DateTime.Now.ToString();
                
                // Şifrələ
                byte[] originalData = System.Text.Encoding.UTF8.GetBytes(testData);
                byte[] encryptedData = System.Security.Cryptography.ProtectedData.Protect(
                    originalData, null, System.Security.Cryptography.DataProtectionScope.LocalMachine);
                
                // Şifrəni aç
                byte[] decryptedData = System.Security.Cryptography.ProtectedData.Unprotect(
                    encryptedData, null, System.Security.Cryptography.DataProtectionScope.LocalMachine);
                string decryptedText = System.Text.Encoding.UTF8.GetString(decryptedData);
                
                if (testData == decryptedText)
                {
                    MessageBox.Show("✅ DPAPI düzgün işləyir!\n\n" +
                                  $"Test məlumatı: {testData}\n" +
                                  $"Şifrələnmiş ölçü: {encryptedData.Length} byte\n" +
                                  $"Açılmış məlumat: {decryptedText}", 
                                  "DPAPI Test Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("❌ DPAPI test uğursuz!\nMəlumatlar uyğun deyil.", 
                                  "DPAPI Test Uğursuz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ DPAPI test xətası:\n{ex.Message}", "DPAPI Test Xətası", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}