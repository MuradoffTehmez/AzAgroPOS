using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class MusteriBonusSistemi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MusteriBonuslari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    ToplamBal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IstifadeEdilmisBal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SonBalQazanmaTarixi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SonBalIstifadeTarixi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Seviyye = table.Column<int>(type: "int", nullable: false),
                    Silinib = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusteriBonuslari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusteriBonuslari_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BonusQeydleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriBonusId = table.Column<int>(type: "int", nullable: false),
                    EmeliyyatNovu = table.Column<int>(type: "int", nullable: false),
                    BalMiqdari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmeliyyatTarixi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SatisId = table.Column<int>(type: "int", nullable: true),
                    Silinib = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonusQeydleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BonusQeydleri_MusteriBonuslari_MusteriBonusId",
                        column: x => x.MusteriBonusId,
                        principalTable: "MusteriBonuslari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BonusQeydleri_Satislar_SatisId",
                        column: x => x.SatisId,
                        principalTable: "Satislar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BonusQeydi_EmeliyyatTarixi",
                table: "BonusQeydleri",
                column: "EmeliyyatTarixi");

            migrationBuilder.CreateIndex(
                name: "IX_BonusQeydi_MusteriBonusId",
                table: "BonusQeydleri",
                column: "MusteriBonusId");

            migrationBuilder.CreateIndex(
                name: "IX_BonusQeydleri_SatisId",
                table: "BonusQeydleri",
                column: "SatisId");

            migrationBuilder.CreateIndex(
                name: "IX_MusteriBonus_MusteriId",
                table: "MusteriBonuslari",
                column: "MusteriId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BonusQeydleri");

            migrationBuilder.DropTable(
                name: "MusteriBonuslari");
        }
    }
}
