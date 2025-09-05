using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class IsciIdareetmeModulu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Novbeler_Istifadeciler_IsciId",
                table: "Novbeler");

            migrationBuilder.CreateTable(
                name: "Isciler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TamAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumTarixi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TelefonNomresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unvan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IseBaslamaTarixi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Maas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vezife = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departament = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SvsNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QeydiyyatUnvani = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankMəlumatları = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SistemIstifadecisiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Isciler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Isciler_Istifadeciler_SistemIstifadecisiId",
                        column: x => x.SistemIstifadecisiId,
                        principalTable: "Istifadeciler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IsciIznleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsciId = table.Column<int>(type: "int", nullable: false),
                    IzinNovu = table.Column<int>(type: "int", nullable: false),
                    BaslamaTarixi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitmeTarixi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IzinGunu = table.Column<int>(type: "int", nullable: false),
                    Sebeb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TesdiqEdenIsciId = table.Column<int>(type: "int", nullable: true),
                    TesdiqTarixi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Qeydler = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsciIznleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IsciIznleri_Isciler_IsciId",
                        column: x => x.IsciId,
                        principalTable: "Isciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IsciIznleri_Isciler_TesdiqEdenIsciId",
                        column: x => x.TesdiqEdenIsciId,
                        principalTable: "Isciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IsciPerformanslari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsciId = table.Column<int>(type: "int", nullable: false),
                    Tarix = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QeydDovru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qiymet = table.Column<int>(type: "int", nullable: false),
                    Qeydler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emsallar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teklifler = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsciPerformanslari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IsciPerformanslari_Isciler_IsciId",
                        column: x => x.IsciId,
                        principalTable: "Isciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Isciler",
                columns: new[] { "Id", "BankMəlumatları", "Departament", "DogumTarixi", "Email", "IseBaslamaTarixi", "Maas", "QeydiyyatUnvani", "SistemIstifadecisiId", "Status", "SvsNo", "TamAd", "TelefonNomresi", "Unvan", "Vezife" },
                values: new object[,]
                {
                    { 1, "IBAN: AZ12NABZ0000000012345678", "Satış", new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali.mammadov@example.com", new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200.00m, "Bakı şəh., Nərimanov r-nu", null, 1, "AZE12345678", "Əli Məmmədov", "+994501234567", "Bakı şəh., Nərimanov r-nu, Sədərək m/s", "Kassir" },
                    { 2, "IBAN: AZ87NABZ0000000087654321", "İdarəetmə", new DateTime(1992, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "nargiz.quliyeva@example.com", new DateTime(2019, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500.00m, "Bakı şəh., Xətai r-nu", null, 1, "AZE87654321", "Nərgiz Quliyeva", "+994552345678", "Bakı şəh., Xətai r-nu, Mərdəkan m/s", "Menecer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IsciIznleri_IsciId",
                table: "IsciIznleri",
                column: "IsciId");

            migrationBuilder.CreateIndex(
                name: "IX_IsciIznleri_TesdiqEdenIsciId",
                table: "IsciIznleri",
                column: "TesdiqEdenIsciId");

            migrationBuilder.CreateIndex(
                name: "IX_Isciler_SistemIstifadecisiId",
                table: "Isciler",
                column: "SistemIstifadecisiId");

            migrationBuilder.CreateIndex(
                name: "IX_IsciPerformanslari_IsciId",
                table: "IsciPerformanslari",
                column: "IsciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Novbeler_Istifadeciler_IsciId",
                table: "Novbeler",
                column: "IsciId",
                principalTable: "Istifadeciler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Novbeler_Istifadeciler_IsciId",
                table: "Novbeler");

            migrationBuilder.DropTable(
                name: "IsciIznleri");

            migrationBuilder.DropTable(
                name: "IsciPerformanslari");

            migrationBuilder.DropTable(
                name: "Isciler");

            migrationBuilder.AddForeignKey(
                name: "FK_Novbeler_Istifadeciler_IsciId",
                table: "Novbeler",
                column: "IsciId",
                principalTable: "Istifadeciler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
