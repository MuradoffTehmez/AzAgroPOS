using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class IcazeKataloqu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                INSERT INTO dbo.Icazeler (Ad, Tesvir, Silinib, YaradilmaTarixi)
                SELECT v.Ad, v.Ad, 0, SYSUTCDATETIME()
                FROM (VALUES
                    (N'SatisSil'), (N'SatisaEndirimVer'), (N'SatisGoruntule'), (N'SatisYarat'),
                    (N'MehsulElaveEt'), (N'MehsulDeyis'), (N'MehsulSil'), (N'MehsulGoruntule'), (N'MehsulQiymetDeyis'),
                    (N'MusteriElaveEt'), (N'MusteriDeyis'), (N'MusteriSil'), (N'MusteriGoruntule'),
                    (N'NisyeVer'), (N'NisyeOdemeQebulEt'), (N'NisyeHesabatlari'),
                    (N'NovbeAc'), (N'NovbeBagle'), (N'NovbeHesabatlari'),
                    (N'QaytarmaYarat'), (N'QaytarmaGoruntule'),
                    (N'HesabatGoruntule'), (N'MaliyyeHesabatlari'), (N'StokHesabatlari'),
                    (N'IstifadeciElaveEt'), (N'IstifadeciDeyis'), (N'IstifadeciSil'), (N'IstifadeciGoruntule'),
                    (N'KonfiqurasiyaGoruntule'), (N'KonfiqurasiyaDeyis'),
                    (N'AlisSenediYarat'), (N'AlisSenediGoruntule'), (N'AlisSenediDeyis'), (N'AlisSenediSil')
                ) AS v(Ad)
                WHERE NOT EXISTS (SELECT 1 FROM dbo.Icazeler AS i WHERE i.Ad = v.Ad);
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // İcazələr artıq rollara təyin oluna bilər; rollback zamanı istifadəçi
            // hüquqlarını səssizcə silməmək üçün kataloq məlumatlarını saxlayırıq.
        }
    }
}
