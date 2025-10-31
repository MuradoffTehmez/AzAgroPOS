using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class XercKassaHareketiCedvelleri2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Miqdar",
                table: "SatisDetallari",
                type: "decimal(18,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Miqdar",
                table: "QaytarmaDetallari",
                type: "decimal(18,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TehvilAlinanMiqdar",
                table: "AlisSifarisSetirleri",
                type: "decimal(18,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Miqdar",
                table: "AlisSifarisSetirleri",
                type: "decimal(18,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Miqdar",
                table: "AlisSenedSetirleri",
                type: "decimal(18,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "Xercler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Novu = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mebleg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tarix = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenedNomresi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qeyd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IstifadeciId = table.Column<int>(type: "int", nullable: true),
                    Silinib = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xercler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Xercler_Istifadeciler_IstifadeciId",
                        column: x => x.IstifadeciId,
                        principalTable: "Istifadeciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "KassaHareketleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HareketNovu = table.Column<int>(type: "int", nullable: false),
                    EmeliyyatNovu = table.Column<int>(type: "int", nullable: false),
                    EmeliyyatId = table.Column<int>(type: "int", nullable: true),
                    Mebleg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tarix = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Qeyd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IstifadeciId = table.Column<int>(type: "int", nullable: true),
                    Silinib = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KassaHareketleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KassaHareketleri_Istifadeciler_IstifadeciId",
                        column: x => x.IstifadeciId,
                        principalTable: "Istifadeciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Xerc_Novu",
                table: "Xercler",
                column: "Novu");

            migrationBuilder.CreateIndex(
                name: "IX_Xerc_Tarix",
                table: "Xercler",
                column: "Tarix");

            migrationBuilder.CreateIndex(
                name: "IX_Xercler_IstifadeciId",
                table: "Xercler",
                column: "IstifadeciId");

            migrationBuilder.CreateIndex(
                name: "IX_KassaHareketi_Emeliyyat",
                table: "KassaHareketleri",
                columns: new[] { "EmeliyyatNovu", "EmeliyyatId" });

            migrationBuilder.CreateIndex(
                name: "IX_KassaHareketi_Tarix",
                table: "KassaHareketleri",
                column: "Tarix");

            migrationBuilder.CreateIndex(
                name: "IX_KassaHareketleri_IstifadeciId",
                table: "KassaHareketleri",
                column: "IstifadeciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Xercler");

            migrationBuilder.DropTable(
                name: "KassaHareketleri");

            migrationBuilder.AlterColumn<decimal>(
                name: "Miqdar",
                table: "SatisDetallari",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Miqdar",
                table: "QaytarmaDetallari",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TehvilAlinanMiqdar",
                table: "AlisSifarisSetirleri",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Miqdar",
                table: "AlisSifarisSetirleri",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Miqdar",
                table: "AlisSenedSetirleri",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)");
        }
    }
}
