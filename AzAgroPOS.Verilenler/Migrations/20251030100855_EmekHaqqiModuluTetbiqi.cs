using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class EmekHaqqiModuluTetbiqi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmekHaqqilari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsciId = table.Column<int>(type: "int", nullable: false),
                    Dovr = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HesablanmaTarixi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EsasMaas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bonuslar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ElaveOdenisler = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IcazeTutulmasi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DigerTutulmalar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OdenisTarixi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Qeyd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IstifadeciId = table.Column<int>(type: "int", nullable: true),
                    Silinib = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmekHaqqilari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmekHaqqilari_Isciler_IsciId",
                        column: x => x.IsciId,
                        principalTable: "Isciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmekHaqqilari_Istifadeciler_IstifadeciId",
                        column: x => x.IstifadeciId,
                        principalTable: "Istifadeciler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmekHaqqi_Dovr",
                table: "EmekHaqqilari",
                column: "Dovr");

            migrationBuilder.CreateIndex(
                name: "IX_EmekHaqqi_IsciId",
                table: "EmekHaqqilari",
                column: "IsciId");

            migrationBuilder.CreateIndex(
                name: "IX_EmekHaqqi_Status",
                table: "EmekHaqqilari",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_EmekHaqqilari_IstifadeciId",
                table: "EmekHaqqilari",
                column: "IstifadeciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmekHaqqilari");
        }
    }
}
