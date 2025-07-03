// Fayl: AzAgroPOS.DAL/IstifadeciDAL.cs

using AzAgroPOS.Entities;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

namespace AzAgroPOS.DAL
{
    /// <summary>
    /// İstifadəçilərlə bağlı bütün verilənlər bazası əməliyyatlarını həyata keçirir.
    /// </summary>
    public class IstifadeciDAL
    {
        private readonly string _connectionString;

        /// <summary>
        /// Constructor: DAL obyekti yaranan kimi App.config-dən bağlantı sətrini oxuyur.
        /// </summary>
        public IstifadeciDAL()
        {
            // Alternativ üsul: App.config faylını birbaşa XML kimi oxuyuruq
            _connectionString = GetConnectionStringFromAppConfig();
        }

        /// <summary>
        /// Verilmiş istifadəçi adına görə verilənlər bazasından istifadəçini tapır.
        /// </summary>
        /// <param name="istifadeciAdi">Axtarılan istifadəçinin adı.</param>
        /// <returns>Tapılarsa Istifadeci obyekti, tapılmazsa null qaytarır.</returns>
        public Istifadeci GetByUsername(string istifadeciAdi)
        {
            Istifadeci istifadeci = null;

            // 'using' bloku bağlantının hər zaman düzgün bağlanmasını təmin edir.
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // SQL Injection hücumlarına qarşı parametrləşdirilmiş sorğu istifadə edirik.
                string query = "SELECT id, ad, soyad, istifadeci_adi, parol_hash, parol_salt, rol_id, aktivdir, son_giris_tarixi, yaradilma_tarixi, deaktivasiya_tarixi " +
                               "FROM istifadeciler WHERE istifadeci_adi = @istifadeci_adi";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@istifadeci_adi", istifadeciAdi);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Əgər nəticə varsa (istifadəçi tapılıbsa)
                        {
                            // Reader-dən gələn məlumatları Istifadeci obyektinə doldururuq.
                            istifadeci = new Istifadeci
                            {
                                Id = (int)reader["id"],
                                Ad = reader["ad"].ToString(),
                                Soyad = reader["soyad"].ToString(),
                                IstifadeciAdi = reader["istifadeci_adi"].ToString(),
                                ParolHash = reader["parol_hash"].ToString(),
                                ParolSalt = reader["parol_salt"].ToString(),
                                RolId = (int)reader["rol_id"],
                                Aktivdir = (bool)reader["aktivdir"],
                                // DBNull-a qarşı yoxlama
                                SonGirisTarixi = reader["son_giris_tarixi"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["son_giris_tarixi"],
                                YaradilmaTarixi = (DateTime)reader["yaradilma_tarixi"],
                                DeaktivasiyaTarixi = reader["deaktivasiya_tarixi"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["deaktivasiya_tarixi"]
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Real tətbiqdə burada xətaları log faylına yazmaq vacibdir.
                    // Hələlik sadəcə xətanı yenidən yuxarıya ötürürük.
                    throw new Exception("An error occurred while getting user by username.", ex);
                }
            }

            return istifadeci;
        }

        // --- Gələcək Metodlar Üçün Yer ---
        // public void Add(Istifadeci istifadeci) { /* Yeni istifadəçi əlavə etmək üçün kod */ }
        // public void Update(Istifadeci istifadeci) { /* İstifadəçini yeniləmək üçün kod */ }
        // public void UpdateLastLogin(int istifadeciId) { /* Son giriş tarixini yeniləmək üçün kod */ }


        /// <summary>
        /// App.config faylını manual olaraq XML kimi oxuyur və bağlantı sətrini tapır.
        /// </summary>
        /// <returns>Bağlantı sətrini qaytarır.</returns>
        private string GetConnectionStringFromAppConfig()
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                // İşə düşən proqramın (PL layihəsinin) config faylının tam yolunu tapır
                string configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

                if (!File.Exists(configFile))
                {
                    throw new FileNotFoundException("Configuration file not found: " + configFile);
                }

                doc.Load(configFile);

                // XPath istifadə edərək adı "DefaultConnection" olan elementi axtarırıq
                XmlNode node = doc.SelectSingleNode("/configuration/connectionStrings/add[@name='DefaultConnection']");

                if (node != null)
                {
                    // Elementin 'connectionString' atributunun dəyərini götürürük
                    string connStr = node.Attributes["connectionString"].Value;
                    return connStr;
                }
                else
                {
                    throw new Exception("The 'DefaultConnection' connection string was not found in the App.config file.");
                }
            }
            catch (Exception ex)
            {
                // Hər hansı bir xəta baş verərsə, daha aydın məlumatla proqramı dayandırırıq
                throw new Exception("Failed to read connection string from App.config. Error: " + ex.Message, ex);
            }
        }
    }
}