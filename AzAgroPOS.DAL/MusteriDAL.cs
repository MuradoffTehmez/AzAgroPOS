using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    public class MusteriDAL
    {
        private readonly string _connectionString = DatabaseHelper.GetConnectionString();

        public List<Musteri> GetAll()
        {
            var musteriler = new List<Musteri>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM musteriler WHERE aktivdir = 1";
                var command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            musteriler.Add(MapMusteri(reader));
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return musteriler;
        }

        public List<Musteri> SearchByNameOrPhone(string searchTerm)
        {
            var musteriler = new List<Musteri>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM musteriler WHERE (ad LIKE @term OR soyad LIKE @term OR telefon LIKE @term) AND aktivdir = 1";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@term", "%" + searchTerm + "%");
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            musteriler.Add(MapMusteri(reader));
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return musteriler;
        }

        public int Add(Musteri musteri)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO musteriler (ad, soyad, telefon, unvan, email, nisye_limiti, endirim_faizi, qeyd, aktivdir) " +
                            "VALUES (@ad, @soyad, @telefon, @unvan, @email, @nisye_limiti, @endirim_faizi, @qeyd, @aktivdir); SELECT SCOPE_IDENTITY();";
                var command = new SqlCommand(query, connection);
                AddParameters(command, musteri);
                try
                {
                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex) { throw; }
            }
        }

        public bool Update(Musteri musteri)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE musteriler SET ad=@ad, soyad=@soyad, telefon=@telefon, unvan=@unvan, email=@email, " +
                            "nisye_limiti=@nisye_limiti, endirim_faizi=@endirim_faizi, qeyd=@qeyd, aktivdir=@aktivdir WHERE id=@id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", musteri.Id);
                AddParameters(command, musteri);
                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex) { throw; }
            }
        }

        public bool Delete(int musteriId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE musteriler SET aktivdir = 0 WHERE id=@id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", musteriId);
                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex) { throw; }
            }
        }

        // Köməkçi metodlar
        private void AddParameters(SqlCommand command, Musteri musteri)
        {
            command.Parameters.Add("@ad", SqlDbType.NVarChar).Value = musteri.Ad;
            command.Parameters.Add("@soyad", SqlDbType.NVarChar).Value = musteri.Soyad;
            command.Parameters.Add("@telefon", SqlDbType.NVarChar).Value = musteri.Telefon;
            command.Parameters.Add("@unvan", SqlDbType.NVarChar).Value = (object)musteri.Unvan ?? DBNull.Value;
            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = (object)musteri.Email ?? DBNull.Value;
            command.Parameters.Add("@nisye_limiti", SqlDbType.Decimal).Value = musteri.NisyeLimiti;
            command.Parameters.Add("@endirim_faizi", SqlDbType.Decimal).Value = musteri.EndirimFaizi;
            command.Parameters.Add("@qeyd", SqlDbType.NVarChar).Value = (object)musteri.Qeyd ?? DBNull.Value;
            command.Parameters.Add("@aktivdir", SqlDbType.Bit).Value = musteri.Aktivdir;
        }

        private Musteri MapMusteri(SqlDataReader reader)
        {
            return new Musteri
            {
                Id = (int)reader["id"],
                Ad = reader["ad"].ToString(),
                Soyad = reader["soyad"].ToString(),
                Telefon = reader["telefon"].ToString(),
                Unvan = reader["unvan"].ToString(),
                Email = reader["email"].ToString(),
                NisyeLimiti = (decimal)reader["nisye_limiti"],
                CariNisyeBorcu = (decimal)reader["cari_nisye_borcu"],
                EndirimFaizi = (decimal)reader["endirim_faizi"],
                Aktivdir = (bool)reader["aktivdir"],
                Qeyd = reader["qeyd"].ToString(),
                YaradilmaTarixi = (DateTime)reader["yaradilma_tarixi"]
            };
        }
    }
}