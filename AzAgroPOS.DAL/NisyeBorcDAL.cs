// Fayl: AzAgroPOS.DAL/NisyeBorcDAL.cs
using AzAgroPOS.Entities;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    public class NisyeBorcDAL
    {
        public void Add(NisyeBorc borc, SqlConnection connection, SqlTransaction transaction)
        {
            var query = "INSERT INTO nisye_borclar (musteri_id, satish_id, borc_meblegi, toplam_borc_meblegi, odeme_baslama_tarixi, odeme_bitme_tarixi, status) " +
                        "VALUES (@musteri_id, @satish_id, @borc_meblegi, @toplam_borc_meblegi, @odeme_baslama_tarixi, @odeme_bitme_tarixi, @status);";

            var command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@musteri_id", borc.MusteriId);
            command.Parameters.AddWithValue("@satish_id", borc.SatishId);
            command.Parameters.AddWithValue("@borc_meblegi", borc.BorcMeblegi);
            command.Parameters.AddWithValue("@toplam_borc_meblegi", borc.ToplamBorcMeblegi);
            command.Parameters.AddWithValue("@odeme_baslama_tarixi", borc.OdemeBaslamaTarixi);
            command.Parameters.AddWithValue("@odeme_bitme_tarixi", borc.OdemeBitmeTarixi);
            command.Parameters.AddWithValue("@status", borc.Status);

            command.ExecuteNonQuery();
        }
    }
}