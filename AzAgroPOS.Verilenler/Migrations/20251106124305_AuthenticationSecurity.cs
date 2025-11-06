using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class AuthenticationSecurity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HesabAktivdir",
                table: "Istifadeciler",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "HesabKilidlenmeTarixi",
                table: "Istifadeciler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonGirisTarixi",
                table: "Istifadeciler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonSifreDeyismeTarixi",
                table: "Istifadeciler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UgursuzGirisCehdi",
                table: "Istifadeciler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GirisLoquKaydlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IstifadeciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ugurlu = table.Column<bool>(type: "bit", nullable: false),
                    CehdTarixi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpUnvani = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KomputerAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UgursuzluqSebebi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Silinib = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GirisLoquKaydlari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IstifadeciSessiyalari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IstifadeciId = table.Column<int>(type: "int", nullable: false),
                    BaslamaTarixi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SonAktivlikTarixi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitməTarixi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktivdir = table.Column<bool>(type: "bit", nullable: false),
                    IpUnvani = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KomputerAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Silinib = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IstifadeciSessiyalari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IstifadeciSessiyalari_Istifadeciler_IstifadeciId",
                        column: x => x.IstifadeciId,
                        principalTable: "Istifadeciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Istifadeciler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HesabAktivdir", "HesabKilidlenmeTarixi", "SonGirisTarixi", "SonSifreDeyismeTarixi", "UgursuzGirisCehdi" },
                values: new object[] { true, null, null, null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_IstifadeciSessiyalari_IstifadeciId",
                table: "IstifadeciSessiyalari",
                column: "IstifadeciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GirisLoquKaydlari");

            migrationBuilder.DropTable(
                name: "IstifadeciSessiyalari");

            migrationBuilder.DropColumn(
                name: "HesabAktivdir",
                table: "Istifadeciler");

            migrationBuilder.DropColumn(
                name: "HesabKilidlenmeTarixi",
                table: "Istifadeciler");

            migrationBuilder.DropColumn(
                name: "SonGirisTarixi",
                table: "Istifadeciler");

            migrationBuilder.DropColumn(
                name: "SonSifreDeyismeTarixi",
                table: "Istifadeciler");

            migrationBuilder.DropColumn(
                name: "UgursuzGirisCehdi",
                table: "Istifadeciler");
        }
    }
}
