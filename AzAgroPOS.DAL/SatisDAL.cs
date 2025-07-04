// Fayl: AzAgroPOS.DAL/SatisDAL.cs
using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    public class SatisDAL
    {
        private readonly MusteriDAL _musteriDal = new MusteriDAL();
        private readonly NisyeBorcDAL _nisyeBorcDal = new NisyeBorcDAL();
        private readonly string _connectionString = DatabaseHelper.GetConnectionString();

        public int Add(Satis satis)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    // 1. Əsas satış məlumatını "satislar" cədvəlinə yazırıq
                    var satisQuery = "INSERT INTO satislar (musteri_id, istifadeci_id, yekun_mebleg, odenmis_mebleg) " +
                                     "VALUES (@musteri_id, @istifadeci_id, @yekun_mebleg, @odenmis_mebleg); SELECT SCOPE_IDENTITY();";
                    var satisCommand = new SqlCommand(satisQuery, connection, transaction);
                    // ... (əvvəlki kimi parametrlər)
                    int yeniSatisId = Convert.ToInt32(satisCommand.ExecuteScalar());

                    // 2. Satış məhsullarını yazırıq və anbarı yeniləyirik
                    // ... (əvvəlki kimi foreach döngüsü)

                    // 3. Ödənişləri yazırıq
                    foreach (var odenis in satis.Odenisler)
                    {
                        var odenisQuery = "INSERT INTO odenisler (satis_id, odenis_nov_id, odenis_meblegi, kart_son_dord_reqem) VALUES (@satis_id, @odenis_nov_id, @odenis_meblegi, @kart_son_dord_reqem);";
                        var odenisCommand = new SqlCommand(odenisQuery, connection, transaction);
                        // ... (əvvəlki kimi parametrlər)
                        odenisCommand.ExecuteNonQuery();

                        // 4. ƏGƏR ÖDƏNİŞ NİSYƏDİRSƏ, MÜŞTƏRİ VƏ NİSYƏ CƏDVƏLLƏRİNİ YENİLƏYİRİK
                        if (odenis.OdenisNovId == 3) // 3: Nisyə
                        {
                            // Müştərinin cari borcunu artırırıq
                            _musteriDal.UpdateNisyeBorcu((int)satis.MusteriId, odenis.OdenisMeblegi, connection, transaction);

                            // Nisyə tarixçəsinə yeni qeyd əlavə edirik
                            var yeniBorc = new NisyeBorc
                            {
                                MusteriId = (int)satis.MusteriId,
                                SatishId = yeniSatisId,
                                BorcMeblegi = odenis.OdenisMeblegi,
                                ToplamBorcMeblegi = odenis.OdenisMeblegi, // Faiz yoxdursa eyni qalır
                                OdemeBaslamaTarixi = DateTime.Now,
                                OdemeBitmeTarixi = DateTime.Now.AddMonths(1), // Məsələn, 1 ay sonra
                                Status = "Aktiv"
                            };
                            _nisyeBorcDal.Add(yeniBorc, connection, transaction);
                        }
                    }

                    transaction.Commit();
                    return yeniSatisId;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}