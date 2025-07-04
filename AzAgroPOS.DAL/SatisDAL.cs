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

                    // --- DÜZƏLİŞ BURADADIR: Çatışmayan parametrləri əlavə edirik ---
                    satisCommand.Parameters.Add("@musteri_id", SqlDbType.Int).Value = (object)satis.MusteriId ?? DBNull.Value;
                    satisCommand.Parameters.Add("@istifadeci_id", SqlDbType.Int).Value = satis.IstifadeciId;
                    satisCommand.Parameters.Add("@yekun_mebleg", SqlDbType.Decimal).Value = satis.YekunMebleg;
                    satisCommand.Parameters.Add("@odenmis_mebleg", SqlDbType.Decimal).Value = satis.OdenmisMebleg;
                    // --- DÜZƏLİŞİN SONU ---

                    int yeniSatisId = Convert.ToInt32(satisCommand.ExecuteScalar());

                    // 2. Hər bir məhsulu "satis_mehsullari" cədvəlinə yazırıq və anbarı yeniləyirik
                    foreach (var mehsul in satis.SatisMehsullari)
                    {
                        var mehsulQuery = "INSERT INTO satis_mehsullari (satis_id, mehsul_id, miqdar, qiymet_bir_edede, endirim_meblegi) " +
                                          "VALUES (@satis_id, @mehsul_id, @miqdar, @qiymet_bir_edede, @endirim_meblegi);";
                        var mehsulCommand = new SqlCommand(mehsulQuery, connection, transaction);
                        mehsulCommand.Parameters.AddWithValue("@satis_id", yeniSatisId);
                        mehsulCommand.Parameters.AddWithValue("@mehsul_id", mehsul.MehsulId);
                        mehsulCommand.Parameters.AddWithValue("@miqdar", mehsul.Miqdar);
                        mehsulCommand.Parameters.AddWithValue("@qiymet_bir_edede", mehsul.QiymetBirEdede);
                        mehsulCommand.Parameters.AddWithValue("@endirim_meblegi", mehsul.EndirimMeblegi);
                        mehsulCommand.ExecuteNonQuery();

                        var stokQuery = "UPDATE mehsullar SET cari_stok = cari_stok - @miqdar WHERE id = @mehsul_id;";
                        var stokCommand = new SqlCommand(stokQuery, connection, transaction);
                        stokCommand.Parameters.AddWithValue("@miqdar", mehsul.Miqdar);
                        stokCommand.Parameters.AddWithValue("@mehsul_id", mehsul.MehsulId);
                        stokCommand.ExecuteNonQuery();
                    }

                    // 3. Hər bir ödənişi "odenisler" cədvəlinə yazırıq
                    foreach (var odenis in satis.Odenisler)
                    {
                        var odenisQuery = "INSERT INTO odenisler (satis_id, odenis_nov_id, odenis_meblegi, kart_son_dord_reqem) " +
                                          "VALUES (@satis_id, @odenis_nov_id, @odenis_meblegi, @kart_son_dord_reqem);";
                        var odenisCommand = new SqlCommand(odenisQuery, connection, transaction);
                        odenisCommand.Parameters.AddWithValue("@satis_id", yeniSatisId);
                        odenisCommand.Parameters.AddWithValue("@odenis_nov_id", odenis.OdenisNovId);
                        odenisCommand.Parameters.AddWithValue("@odenis_meblegi", odenis.OdenisMeblegi);
                        odenisCommand.Parameters.AddWithValue("@kart_son_dord_reqem", (object)odenis.KartSonDordReqem ?? DBNull.Value);
                        odenisCommand.ExecuteNonQuery();

                        // 4. ƏGƏR ÖDƏNİŞ NİSYƏDİRSƏ, MÜŞTƏRİ VƏ NİSYƏ CƏDVƏLLƏRİNİ YENİLƏYİRİK
                        if (odenis.OdenisNovId == 3) // 3: Nisyə
                        {
                            _musteriDal.UpdateNisyeBorcu((int)satis.MusteriId, odenis.OdenisMeblegi, connection, transaction);

                            var yeniBorc = new NisyeBorc
                            {
                                MusteriId = (int)satis.MusteriId,
                                SatishId = yeniSatisId,
                                BorcMeblegi = odenis.OdenisMeblegi,
                                ToplamBorcMeblegi = odenis.OdenisMeblegi,
                                OdemeBaslamaTarixi = DateTime.Now,
                                OdemeBitmeTarixi = DateTime.Now.AddMonths(1),
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