// Fayl: AzAgroPOS.DAL/Helpers/DatabaseHelper.cs

using System;
using System.IO;
using System.Xml;

namespace AzAgroPOS.DAL.Helpers
{
    /// <summary>
    /// Verilənlər bazası ilə bağlı ümumi köməkçi funksiyaları saxlayır.
    /// </summary>
    public static class DatabaseHelper
    {
        /// <summary>
        /// App.config faylını manual olaraq oxuyur və bağlantı sətrini qaytarır.
        /// Bu metod statikdir, yəni onu birbaşa Class adı ilə çağırmaq olar.
        /// </summary>
        public static string GetConnectionString()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                string configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

                if (!File.Exists(configFile))
                {
                    throw new FileNotFoundException("Configuration file not found: " + configFile);
                }

                doc.Load(configFile);

                XmlNode node = doc.SelectSingleNode("/configuration/connectionStrings/add[@name='DefaultConnection']");

                if (node != null)
                {
                    return node.Attributes["connectionString"].Value;
                }
                else
                {
                    throw new Exception("The 'DefaultConnection' connection string was not found in the App.config file.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to read connection string from App.config. Error: " + ex.Message, ex);
            }
        }
    }
}