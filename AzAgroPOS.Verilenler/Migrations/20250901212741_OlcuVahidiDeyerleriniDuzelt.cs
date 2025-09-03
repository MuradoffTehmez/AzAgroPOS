using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class OlcuVahidiDeyerleriniDuzelt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Bu SQL skripti, 'Mehsullar' cədvəlində 'OlcuVahidi' sütununun dəyəri '0' olan
            // bütün sətirləri məhsul adına görə düzgün dəyərlərlə əvəz edir.
            // Bu, köhnə miqrasiyadakı səhvi aradan qaldırmaq üçündür.
            migrationBuilder.Sql(@"
                UPDATE Mehsullar
                SET OlcuVahidi = 
                    CASE 
                        WHEN Ad = N'Çörək' THEN 1 -- Ədəd
                        WHEN Ad = N'Süd 1L' THEN 3 -- Litr
                        WHEN Ad = N'Yumurta (10 ədəd)' THEN 5 -- Paket
                        ELSE 1 -- Digər bütün məhsullar üçün standart dəyər (məsələn, Ədəd)
                    END
                WHERE OlcuVahidi = 0;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Bu miqrasiyanı geri almaq üçün hər hansı bir əməliyyat nəzərdə tutulmayıb,
            // çünki bu, sadəcə səhv datanı düzəldir. Dəyərləri yenidən '0' etmək mənasız olardı.
        }
    }
}