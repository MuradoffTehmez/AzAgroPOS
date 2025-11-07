using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class AuditSaheleriElave : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "TemirSifarisleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "TemirSifarisleri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "TemirSifarisleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "TemirSifarisleri",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "TedarukcuOdemeleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "TedarukcuOdemeleri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "TedarukcuOdemeleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "Tedarukculer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "Tedarukculer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "Tedarukculer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "Tedarukculer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "StokHareketleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "StokHareketleri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "StokHareketleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "StokHareketleri",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "Satislar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "Satislar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "Satislar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "Satislar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "SatisDetallari",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "SatisDetallari",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "SatisDetallari",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "SatisDetallari",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "Rollar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "Rollar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "Rollar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "Rollar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "RolIcazeleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "RolIcazeleri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "RolIcazeleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "RolIcazeleri",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "Novbeler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "Novbeler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "Novbeler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "Novbeler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "NisyeHereketleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "NisyeHereketleri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "NisyeHereketleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "NisyeHereketleri",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "Musteriler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "Musteriler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "Musteriler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "Musteriler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "MusteriBonuslari",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "MusteriBonuslari",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "MusteriBonuslari",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "MusteriBonuslari",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "Mehsullar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "Mehsullar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "Mehsullar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "Mehsullar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "Qaytarmalar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "Qaytarmalar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "Qaytarmalar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "Qaytarmalar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "QaytarmaDetallari",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "QaytarmaDetallari",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "QaytarmaDetallari",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "QaytarmaDetallari",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "Konfiqurasiyalar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "Konfiqurasiyalar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "Konfiqurasiyalar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "Konfiqurasiyalar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "Kateqoriyalar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "Kateqoriyalar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "Kateqoriyalar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "Kateqoriyalar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "KassaHareketleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "KassaHareketleri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "KassaHareketleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "KassaHareketleri",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "IstifadeciSessiyalari",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "IstifadeciSessiyalari",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "IstifadeciSessiyalari",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "IstifadeciSessiyalari",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "Istifadeciler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "Istifadeciler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "Istifadeciler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "Istifadeciler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "IsciPerformanslari",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "IsciPerformanslari",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "IsciPerformanslari",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "IsciPerformanslari",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "Isciler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "Isciler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "Isciler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "Isciler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "IsciIznleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "IsciIznleri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "IsciIznleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "IsciIznleri",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "Icazeler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "Icazeler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "Icazeler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "Icazeler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "Xercler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "Xercler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "Xercler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "Xercler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "GirisLoquKaydlari",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "GirisLoquKaydlari",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "GirisLoquKaydlari",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "GirisLoquKaydlari",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "EmeliyyatJurnallari",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "EmeliyyatJurnallari",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "EmeliyyatJurnallari",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "EmeliyyatJurnallari",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "EmekHaqqilari",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "EmekHaqqilari",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "EmekHaqqilari",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "EmekHaqqilari",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "Brendler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "Brendler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "Brendler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "Brendler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "BonusQeydleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "BonusQeydleri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "BonusQeydleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "BonusQeydleri",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "AlisSifarisSetirleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "AlisSifarisSetirleri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "AlisSifarisSetirleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "AlisSifarisSetirleri",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "AlisSifarisleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "AlisSifarisleri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "AlisSifarisleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "AlisSenetleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "AlisSenetleri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "AlisSenetleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeyisdirenIstifadeciId",
                table: "AlisSenedSetirleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeyisdirilmeTarixi",
                table: "AlisSenedSetirleri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YaradanIstifadeciId",
                table: "AlisSenedSetirleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YaradilmaTarixi",
                table: "AlisSenedSetirleri",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Brendler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Brendler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Brendler",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Icazeler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Icazeler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Icazeler",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Icazeler",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Icazeler",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Isciler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Isciler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Istifadeciler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Kateqoriyalar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Kateqoriyalar",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Kateqoriyalar",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Mehsullar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Mehsullar",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Mehsullar",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "RolIcazeleri",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "RolIcazeleri",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "RolIcazeleri",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "RolIcazeleri",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "RolIcazeleri",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rollar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rollar",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tedarukculer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tedarukculer",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeyisdirenIstifadeciId", "DeyisdirilmeTarixi", "YaradanIstifadeciId", "YaradilmaTarixi" },
                values: new object[] { null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "TemirSifarisleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "TemirSifarisleri");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "TemirSifarisleri");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "TemirSifarisleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "TedarukcuOdemeleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "TedarukcuOdemeleri");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "TedarukcuOdemeleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "Tedarukculer");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "Tedarukculer");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "Tedarukculer");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "Tedarukculer");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "StokHareketleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "StokHareketleri");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "StokHareketleri");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "StokHareketleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "Satislar");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "Satislar");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "Satislar");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "Satislar");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "SatisDetallari");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "SatisDetallari");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "SatisDetallari");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "SatisDetallari");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "Rollar");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "Rollar");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "Rollar");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "Rollar");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "RolIcazeleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "RolIcazeleri");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "RolIcazeleri");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "RolIcazeleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "Novbeler");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "Novbeler");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "Novbeler");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "Novbeler");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "NisyeHereketleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "NisyeHereketleri");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "NisyeHereketleri");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "NisyeHereketleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "Musteriler");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "Musteriler");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "Musteriler");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "Musteriler");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "MusteriBonuslari");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "MusteriBonuslari");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "MusteriBonuslari");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "MusteriBonuslari");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "Mehsullar");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "Mehsullar");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "Mehsullar");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "Mehsullar");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "Qaytarmalar");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "Qaytarmalar");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "Qaytarmalar");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "Qaytarmalar");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "QaytarmaDetallari");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "QaytarmaDetallari");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "QaytarmaDetallari");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "QaytarmaDetallari");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "Konfiqurasiyalar");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "Konfiqurasiyalar");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "Konfiqurasiyalar");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "Konfiqurasiyalar");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "Kateqoriyalar");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "Kateqoriyalar");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "Kateqoriyalar");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "Kateqoriyalar");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "KassaHareketleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "KassaHareketleri");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "KassaHareketleri");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "KassaHareketleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "IstifadeciSessiyalari");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "IstifadeciSessiyalari");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "IstifadeciSessiyalari");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "IstifadeciSessiyalari");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "Istifadeciler");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "Istifadeciler");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "Istifadeciler");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "Istifadeciler");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "IsciPerformanslari");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "IsciPerformanslari");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "IsciPerformanslari");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "IsciPerformanslari");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "Isciler");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "Isciler");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "Isciler");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "Isciler");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "IsciIznleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "IsciIznleri");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "IsciIznleri");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "IsciIznleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "Icazeler");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "Icazeler");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "Icazeler");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "Icazeler");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "Xercler");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "Xercler");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "Xercler");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "Xercler");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "GirisLoquKaydlari");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "GirisLoquKaydlari");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "GirisLoquKaydlari");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "GirisLoquKaydlari");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "EmeliyyatJurnallari");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "EmeliyyatJurnallari");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "EmeliyyatJurnallari");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "EmeliyyatJurnallari");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "EmekHaqqilari");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "EmekHaqqilari");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "EmekHaqqilari");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "EmekHaqqilari");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "Brendler");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "Brendler");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "Brendler");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "Brendler");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "BonusQeydleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "BonusQeydleri");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "BonusQeydleri");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "BonusQeydleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "AlisSifarisSetirleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "AlisSifarisSetirleri");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "AlisSifarisSetirleri");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "AlisSifarisSetirleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "AlisSifarisleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "AlisSifarisleri");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "AlisSifarisleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "AlisSenetleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "AlisSenetleri");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "AlisSenetleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirenIstifadeciId",
                table: "AlisSenedSetirleri");

            migrationBuilder.DropColumn(
                name: "DeyisdirilmeTarixi",
                table: "AlisSenedSetirleri");

            migrationBuilder.DropColumn(
                name: "YaradanIstifadeciId",
                table: "AlisSenedSetirleri");

            migrationBuilder.DropColumn(
                name: "YaradilmaTarixi",
                table: "AlisSenedSetirleri");
        }
    }
}
