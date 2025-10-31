using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class StokHareketiEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StokHareketleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HareketTipi = table.Column<int>(type: "int", nullable: false),
                    SenedNovu = table.Column<int>(type: "int", nullable: false),
                    SenedId = table.Column<int>(type: "int", nullable: true),
                    MehsulId = table.Column<int>(type: "int", nullable: false),
                    Miqdar = table.Column<int>(type: "int", nullable: false),
                    Tarix = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Qeyd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IstifadeciId = table.Column<int>(type: "int", nullable: true),
                    Silinib = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StokHareketleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StokHareketleri_Istifadeciler_IstifadeciId",
                        column: x => x.IstifadeciId,
                        principalTable: "Istifadeciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_StokHareketleri_Mehsullar_MehsulId",
                        column: x => x.MehsulId,
                        principalTable: "Mehsullar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketi_MehsulId",
                table: "StokHareketleri",
                column: "MehsulId");

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketi_Sened",
                table: "StokHareketleri",
                columns: new[] { "SenedNovu", "SenedId" });

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketi_Tarix",
                table: "StokHareketleri",
                column: "Tarix");

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketleri_IstifadeciId",
                table: "StokHareketleri",
                column: "IstifadeciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StokHareketleri");
        }
    }
}
