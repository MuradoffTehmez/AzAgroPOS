using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseIndexOptimization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Novbeler_IsciId",
                table: "Novbeler");

            migrationBuilder.RenameIndex(
                name: "IX_Satislar_NovbeId",
                table: "Satislar",
                newName: "IX_Satis_NovbeId");

            migrationBuilder.RenameIndex(
                name: "IX_Satislar_MusteriId",
                table: "Satislar",
                newName: "IX_Satis_MusteriId");

            migrationBuilder.RenameIndex(
                name: "IX_SatisDetallari_MehsulId",
                table: "SatisDetallari",
                newName: "IX_SatisDetali_MehsulId");

            migrationBuilder.RenameIndex(
                name: "IX_NisyeHereketleri_MusteriId",
                table: "NisyeHereketleri",
                newName: "IX_NisyeHereketi_MusteriId");

            migrationBuilder.RenameIndex(
                name: "IX_Mehsullar_KateqoriyaId",
                table: "Mehsullar",
                newName: "IX_Mehsul_KateqoriyaId");

            migrationBuilder.RenameIndex(
                name: "IX_Mehsullar_BrendId",
                table: "Mehsullar",
                newName: "IX_Mehsul_BrendId");

            migrationBuilder.RenameIndex(
                name: "IX_Qaytarmalar_SatisId",
                table: "Qaytarmalar",
                newName: "IX_Qaytarma_SatisId");

            migrationBuilder.RenameIndex(
                name: "IX_Qaytarmalar_KassirId",
                table: "Qaytarmalar",
                newName: "IX_Qaytarma_KassirId");

            migrationBuilder.RenameIndex(
                name: "IX_QaytarmaDetallari_MehsulId",
                table: "QaytarmaDetallari",
                newName: "IX_QaytarmaDetali_MehsulId");

            migrationBuilder.RenameIndex(
                name: "IX_KassaHareketleri_IstifadeciId",
                table: "KassaHareketleri",
                newName: "IX_KassaHareketi_IstifadeciId");

            migrationBuilder.RenameIndex(
                name: "IX_IstifadeciSessiyalari_IstifadeciId",
                table: "IstifadeciSessiyalari",
                newName: "IX_IstifadeciSessiyasi_IstifadeciId");

            migrationBuilder.RenameIndex(
                name: "IX_Istifadeciler_RolId",
                table: "Istifadeciler",
                newName: "IX_Istifadeci_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_IsciPerformanslari_IsciId",
                table: "IsciPerformanslari",
                newName: "IX_IsciPerformans_IsciId");

            migrationBuilder.RenameIndex(
                name: "IX_IsciIznleri_IsciId",
                table: "IsciIznleri",
                newName: "IX_IsciIzni_IsciId");

            migrationBuilder.RenameIndex(
                name: "IX_Xercler_IstifadeciId",
                table: "Xercler",
                newName: "IX_Xerc_IstifadeciId");

            migrationBuilder.RenameIndex(
                name: "IX_AlisSifarisleri_TedarukcuId",
                table: "AlisSifarisleri",
                newName: "IX_AlisSifaris_TedarukcuId");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Tedarukculer",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TelefonNomresi",
                table: "Musteriler",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TamAd",
                table: "Musteriler",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "StokKodu",
                table: "Mehsullar",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Barkod",
                table: "Mehsullar",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Mehsullar",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Kateqoriyalar",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IstifadeciAdi",
                table: "Istifadeciler",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TamAd",
                table: "Isciler",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IstifadeciAdi",
                table: "GirisLoquKaydlari",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Brendler",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Tedarukcu_Ad",
                table: "Tedarukculer",
                column: "Ad");

            migrationBuilder.CreateIndex(
                name: "IX_Tedarukcu_Aktivdir",
                table: "Tedarukculer",
                column: "Aktivdir");

            migrationBuilder.CreateIndex(
                name: "IX_Satis_OdenisMetodu",
                table: "Satislar",
                column: "OdenisMetodu");

            migrationBuilder.CreateIndex(
                name: "IX_Satis_Silinib",
                table: "Satislar",
                column: "Silinib");

            migrationBuilder.CreateIndex(
                name: "IX_Satis_Silinib_Tarix_MusteriId",
                table: "Satislar",
                columns: new[] { "Silinib", "Tarix", "MusteriId" });

            migrationBuilder.CreateIndex(
                name: "IX_Satis_Tarix",
                table: "Satislar",
                column: "Tarix");

            migrationBuilder.CreateIndex(
                name: "IX_SatisDetali_Silinib",
                table: "SatisDetallari",
                column: "Silinib");

            migrationBuilder.CreateIndex(
                name: "IX_Novbe_IsciId_Status",
                table: "Novbeler",
                columns: new[] { "IsciId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_Novbe_Status",
                table: "Novbeler",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_NisyeHereketi_Tarix",
                table: "NisyeHereketleri",
                column: "Tarix");

            migrationBuilder.CreateIndex(
                name: "IX_Musteri_TamAd",
                table: "Musteriler",
                column: "TamAd");

            migrationBuilder.CreateIndex(
                name: "IX_Musteri_TelefonNomresi",
                table: "Musteriler",
                column: "TelefonNomresi");

            migrationBuilder.CreateIndex(
                name: "IX_Musteri_UmumiBorc",
                table: "Musteriler",
                column: "UmumiBorc");

            migrationBuilder.CreateIndex(
                name: "IX_Mehsul_Ad",
                table: "Mehsullar",
                column: "Ad");

            migrationBuilder.CreateIndex(
                name: "IX_Mehsul_Aktivdir",
                table: "Mehsullar",
                column: "Aktivdir");

            migrationBuilder.CreateIndex(
                name: "IX_Mehsul_Aktivdir_Id",
                table: "Mehsullar",
                columns: new[] { "Aktivdir", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Mehsul_Barkod",
                table: "Mehsullar",
                column: "Barkod");

            migrationBuilder.CreateIndex(
                name: "IX_Mehsul_StokKodu",
                table: "Mehsullar",
                column: "StokKodu");

            migrationBuilder.CreateIndex(
                name: "IX_Qaytarma_Tarix",
                table: "Qaytarmalar",
                column: "Tarix");

            migrationBuilder.CreateIndex(
                name: "IX_Kateqoriya_Ad",
                table: "Kateqoriyalar",
                column: "Ad");

            migrationBuilder.CreateIndex(
                name: "IX_Kateqoriya_Aktivdir",
                table: "Kateqoriyalar",
                column: "Aktivdir");

            migrationBuilder.CreateIndex(
                name: "IX_IstifadeciSessiyasi_BaslamaTarixi",
                table: "IstifadeciSessiyalari",
                column: "BaslamaTarixi");

            migrationBuilder.CreateIndex(
                name: "IX_Istifadeci_HesabAktivdir",
                table: "Istifadeciler",
                column: "HesabAktivdir");

            migrationBuilder.CreateIndex(
                name: "IX_Istifadeci_IstifadeciAdi",
                table: "Istifadeciler",
                column: "IstifadeciAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Istifadeci_SonGirisTarixi",
                table: "Istifadeciler",
                column: "SonGirisTarixi");

            migrationBuilder.CreateIndex(
                name: "IX_Isci_Silinib_Status_TamAd",
                table: "Isciler",
                columns: new[] { "Silinib", "Status", "TamAd" });

            migrationBuilder.CreateIndex(
                name: "IX_Isci_Status",
                table: "Isciler",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Isci_TamAd",
                table: "Isciler",
                column: "TamAd");

            migrationBuilder.CreateIndex(
                name: "IX_IsciIzni_BaslamaTarixi",
                table: "IsciIznleri",
                column: "BaslamaTarixi");

            migrationBuilder.CreateIndex(
                name: "IX_GirisLoquKaydi_CehdTarixi",
                table: "GirisLoquKaydlari",
                column: "CehdTarixi");

            migrationBuilder.CreateIndex(
                name: "IX_GirisLoquKaydi_IstifadeciAdi",
                table: "GirisLoquKaydlari",
                column: "IstifadeciAdi");

            migrationBuilder.CreateIndex(
                name: "IX_Brend_Ad",
                table: "Brendler",
                column: "Ad");

            migrationBuilder.CreateIndex(
                name: "IX_Brend_Aktivdir",
                table: "Brendler",
                column: "Aktivdir");

            migrationBuilder.CreateIndex(
                name: "IX_AlisSifaris_Silinib",
                table: "AlisSifarisleri",
                column: "Silinib");

            migrationBuilder.CreateIndex(
                name: "IX_AlisSifaris_YaradilmaTarixi",
                table: "AlisSifarisleri",
                column: "YaradilmaTarixi");

            migrationBuilder.CreateIndex(
                name: "IX_AlisSened_YaradilmaTarixi",
                table: "AlisSenetleri",
                column: "YaradilmaTarixi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tedarukcu_Ad",
                table: "Tedarukculer");

            migrationBuilder.DropIndex(
                name: "IX_Tedarukcu_Aktivdir",
                table: "Tedarukculer");

            migrationBuilder.DropIndex(
                name: "IX_Satis_OdenisMetodu",
                table: "Satislar");

            migrationBuilder.DropIndex(
                name: "IX_Satis_Silinib",
                table: "Satislar");

            migrationBuilder.DropIndex(
                name: "IX_Satis_Silinib_Tarix_MusteriId",
                table: "Satislar");

            migrationBuilder.DropIndex(
                name: "IX_Satis_Tarix",
                table: "Satislar");

            migrationBuilder.DropIndex(
                name: "IX_SatisDetali_Silinib",
                table: "SatisDetallari");

            migrationBuilder.DropIndex(
                name: "IX_Novbe_IsciId_Status",
                table: "Novbeler");

            migrationBuilder.DropIndex(
                name: "IX_Novbe_Status",
                table: "Novbeler");

            migrationBuilder.DropIndex(
                name: "IX_NisyeHereketi_Tarix",
                table: "NisyeHereketleri");

            migrationBuilder.DropIndex(
                name: "IX_Musteri_TamAd",
                table: "Musteriler");

            migrationBuilder.DropIndex(
                name: "IX_Musteri_TelefonNomresi",
                table: "Musteriler");

            migrationBuilder.DropIndex(
                name: "IX_Musteri_UmumiBorc",
                table: "Musteriler");

            migrationBuilder.DropIndex(
                name: "IX_Mehsul_Ad",
                table: "Mehsullar");

            migrationBuilder.DropIndex(
                name: "IX_Mehsul_Aktivdir",
                table: "Mehsullar");

            migrationBuilder.DropIndex(
                name: "IX_Mehsul_Aktivdir_Id",
                table: "Mehsullar");

            migrationBuilder.DropIndex(
                name: "IX_Mehsul_Barkod",
                table: "Mehsullar");

            migrationBuilder.DropIndex(
                name: "IX_Mehsul_StokKodu",
                table: "Mehsullar");

            migrationBuilder.DropIndex(
                name: "IX_Qaytarma_Tarix",
                table: "Qaytarmalar");

            migrationBuilder.DropIndex(
                name: "IX_Kateqoriya_Ad",
                table: "Kateqoriyalar");

            migrationBuilder.DropIndex(
                name: "IX_Kateqoriya_Aktivdir",
                table: "Kateqoriyalar");

            migrationBuilder.DropIndex(
                name: "IX_IstifadeciSessiyasi_BaslamaTarixi",
                table: "IstifadeciSessiyalari");

            migrationBuilder.DropIndex(
                name: "IX_Istifadeci_HesabAktivdir",
                table: "Istifadeciler");

            migrationBuilder.DropIndex(
                name: "IX_Istifadeci_IstifadeciAdi",
                table: "Istifadeciler");

            migrationBuilder.DropIndex(
                name: "IX_Istifadeci_SonGirisTarixi",
                table: "Istifadeciler");

            migrationBuilder.DropIndex(
                name: "IX_Isci_Silinib_Status_TamAd",
                table: "Isciler");

            migrationBuilder.DropIndex(
                name: "IX_Isci_Status",
                table: "Isciler");

            migrationBuilder.DropIndex(
                name: "IX_Isci_TamAd",
                table: "Isciler");

            migrationBuilder.DropIndex(
                name: "IX_IsciIzni_BaslamaTarixi",
                table: "IsciIznleri");

            migrationBuilder.DropIndex(
                name: "IX_GirisLoquKaydi_CehdTarixi",
                table: "GirisLoquKaydlari");

            migrationBuilder.DropIndex(
                name: "IX_GirisLoquKaydi_IstifadeciAdi",
                table: "GirisLoquKaydlari");

            migrationBuilder.DropIndex(
                name: "IX_Brend_Ad",
                table: "Brendler");

            migrationBuilder.DropIndex(
                name: "IX_Brend_Aktivdir",
                table: "Brendler");

            migrationBuilder.DropIndex(
                name: "IX_AlisSifaris_Silinib",
                table: "AlisSifarisleri");

            migrationBuilder.DropIndex(
                name: "IX_AlisSifaris_YaradilmaTarixi",
                table: "AlisSifarisleri");

            migrationBuilder.DropIndex(
                name: "IX_AlisSened_YaradilmaTarixi",
                table: "AlisSenetleri");

            migrationBuilder.RenameIndex(
                name: "IX_Satis_NovbeId",
                table: "Satislar",
                newName: "IX_Satislar_NovbeId");

            migrationBuilder.RenameIndex(
                name: "IX_Satis_MusteriId",
                table: "Satislar",
                newName: "IX_Satislar_MusteriId");

            migrationBuilder.RenameIndex(
                name: "IX_SatisDetali_MehsulId",
                table: "SatisDetallari",
                newName: "IX_SatisDetallari_MehsulId");

            migrationBuilder.RenameIndex(
                name: "IX_NisyeHereketi_MusteriId",
                table: "NisyeHereketleri",
                newName: "IX_NisyeHereketleri_MusteriId");

            migrationBuilder.RenameIndex(
                name: "IX_Mehsul_KateqoriyaId",
                table: "Mehsullar",
                newName: "IX_Mehsullar_KateqoriyaId");

            migrationBuilder.RenameIndex(
                name: "IX_Mehsul_BrendId",
                table: "Mehsullar",
                newName: "IX_Mehsullar_BrendId");

            migrationBuilder.RenameIndex(
                name: "IX_Qaytarma_SatisId",
                table: "Qaytarmalar",
                newName: "IX_Qaytarmalar_SatisId");

            migrationBuilder.RenameIndex(
                name: "IX_Qaytarma_KassirId",
                table: "Qaytarmalar",
                newName: "IX_Qaytarmalar_KassirId");

            migrationBuilder.RenameIndex(
                name: "IX_QaytarmaDetali_MehsulId",
                table: "QaytarmaDetallari",
                newName: "IX_QaytarmaDetallari_MehsulId");

            migrationBuilder.RenameIndex(
                name: "IX_KassaHareketi_IstifadeciId",
                table: "KassaHareketleri",
                newName: "IX_KassaHareketleri_IstifadeciId");

            migrationBuilder.RenameIndex(
                name: "IX_IstifadeciSessiyasi_IstifadeciId",
                table: "IstifadeciSessiyalari",
                newName: "IX_IstifadeciSessiyalari_IstifadeciId");

            migrationBuilder.RenameIndex(
                name: "IX_Istifadeci_RolId",
                table: "Istifadeciler",
                newName: "IX_Istifadeciler_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_IsciPerformans_IsciId",
                table: "IsciPerformanslari",
                newName: "IX_IsciPerformanslari_IsciId");

            migrationBuilder.RenameIndex(
                name: "IX_IsciIzni_IsciId",
                table: "IsciIznleri",
                newName: "IX_IsciIznleri_IsciId");

            migrationBuilder.RenameIndex(
                name: "IX_Xerc_IstifadeciId",
                table: "Xercler",
                newName: "IX_Xercler_IstifadeciId");

            migrationBuilder.RenameIndex(
                name: "IX_AlisSifaris_TedarukcuId",
                table: "AlisSifarisleri",
                newName: "IX_AlisSifarisleri_TedarukcuId");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Tedarukculer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "TelefonNomresi",
                table: "Musteriler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "TamAd",
                table: "Musteriler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "StokKodu",
                table: "Mehsullar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Barkod",
                table: "Mehsullar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Mehsullar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Kateqoriyalar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "IstifadeciAdi",
                table: "Istifadeciler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "TamAd",
                table: "Isciler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "IstifadeciAdi",
                table: "GirisLoquKaydlari",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Brendler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Novbeler_IsciId",
                table: "Novbeler",
                column: "IsciId");
        }
    }
}
