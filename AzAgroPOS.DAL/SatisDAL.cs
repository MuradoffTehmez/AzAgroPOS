using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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
                    // DƏYİŞİKLİK: endirim_meblegi sütunu və parametri əlavə edildi
                    var satisQuery = "INSERT INTO satislar (musteri_id, istifadeci_id, yekun_mebleg, odenmis_mebleg, endirim_meblegi) " +
                                     "VALUES (@musteri_id, @istifadeci_id, @yekun_mebleg, @odenmis_mebleg, @endirim_meblegi); SELECT SCOPE_IDENTITY();";
                    var satisCommand = new SqlCommand(satisQuery, connection, transaction);

                    satisCommand.Parameters.Add("@musteri_id", SqlDbType.Int).Value = (object)satis.MusteriId ?? DBNull.Value;
                    satisCommand.Parameters.Add("@istifadeci_id", SqlDbType.Int).Value = satis.IstifadeciId;
                    satisCommand.Parameters.Add("@yekun_mebleg", SqlDbType.Decimal).Value = satis.YekunMebleg;
                    satisCommand.Parameters.Add("@odenmis_mebleg", SqlDbType.Decimal).Value = satis.OdenmisMebleg;
                    satisCommand.Parameters.Add("@endirim_meblegi", SqlDbType.Decimal).Value = satis.EndirimMeblegi;

                    int yeniSatisId = Convert.ToInt32(satisCommand.ExecuteScalar());

                    // Satış məhsulları və anbar qalığı (dəyişiklik yoxdur)
                    foreach (var mehsul in satis.SatisMehsullari)
                    {
                        var mehsulQuery = "INSERT INTO satis_mehsullari (satis_id, mehsul_id, miqdar, qiymet_bir_edede, endirim_meblegi) " +
                                          "VALUES (@satis_id, @mehsul_id, @miqdar, @qiymet_bir_edede, @endirim_meblegi);";
                        var mehsulCommand = new SqlCommand(mehsulQuery, connection, transaction);
                        mehsulCommand.Parameters.AddWithValue("@satis_id", yeniSatisId);
                        mehsulCommand.Parameters.AddWithValue("@mehsul_id", mehsul.MehsulId);
                        mehsulCommand.Parameters.AddWithValue("@miqdar", mehsul.Miqdar);
                        mehsulCommand.Parameters.AddWithValue("@qiymet_bir_edede", mehsul.QiymetBirEdede);
                        mehsulCommand.Parameters.AddWithValue("@endirim_meblegi", 0);
                        mehsulCommand.ExecuteNonQuery();

                        var stokQuery = "UPDATE mehsullar SET cari_stok = cari_stok - @miqdar WHERE id = @mehsul_id;";
                        var stokCommand = new SqlCommand(stokQuery, connection, transaction);
                        stokCommand.Parameters.AddWithValue("@miqdar", mehsul.Miqdar);
                        stokCommand.Parameters.AddWithValue("@mehsul_id", mehsul.MehsulId);
                        stokCommand.ExecuteNonQuery();
                    }

                    // Ödənişlər və nisyə (dəyişiklik yoxdur)
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
        
        public List<Satis> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            var satislar = new List<Satis>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"SELECT 
                        s.*, 
                        ISNULL(m.ad + ' ' + m.soyad, 'Qeydiyyatsız') as MusteriAdi, 
                        i.ad + ' ' + i.soyad as IstifadeciAdi 
                      FROM satislar s
                      LEFT JOIN musteriler m ON s.musteri_id = m.id
                      JOIN istifadeciler i ON s.istifadeci_id = i.id
                      WHERE s.satis_tarixi BETWEEN @start_date AND @end_date
                      ORDER BY s.satis_tarixi DESC";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@start_date", startDate);
                command.Parameters.AddWithValue("@end_date", endDate);
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            satislar.Add(new Satis
                            {
                                Id = (int)reader["id"],
                                SatisTarixi = (DateTime)reader["satis_tarixi"],
                                MusteriId = reader["musteri_id"] as int?,
                                IstifadeciId = (int)reader["istifadeci_id"],
                                EndirimMeblegi = (decimal)reader["endirim_meblegi"],
                                YekunMebleg = (decimal)reader["yekun_mebleg"],
                                OdenmisMebleg = (decimal)reader["odenmis_mebleg"],
                                MusteriAdi = reader["MusteriAdi"].ToString(),
                                IstifadeciAdi = reader["IstifadeciAdi"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return satislar;
        }
    }

}