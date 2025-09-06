using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class AddEmeliyyatJurnaliTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SeriyaNomresi",
                table: "TemirSifarisleri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ServisHaqqi",
                table: "TemirSifarisleri",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Silinib",
                table: "TemirSifarisleri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ZemanetMuddeti",
                table: "TemirSifarisleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Silinib",
                table: "TedarukcuOdemeleri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Silinib",
                table: "Tedarukculer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Silinib",
                table: "Satislar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Silinib",
                table: "SatisDetallari",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Silinib",
                table: "Rollar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Silinib",
                table: "Novbeler",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Silinib",
                table: "NisyeHereketleri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Silinib",
                table: "Musteriler",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Silinib",
                table: "Mehsullar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Silinib",
                table: "Kateqoriyalar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Silinib",
                table: "Istifadeciler",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Silinib",
                table: "IsciPerformanslari",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Silinib",
                table: "Isciler",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Silinib",
                table: "IsciIznleri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Silinib",
                table: "Brendler",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Silinib",
                table: "AlisSifarisSetirleri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Silinib",
                table: "AlisSifarisleri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Silinib",
                table: "AlisSenetleri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Silinib",
                table: "AlisSenedSetirleri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "EmeliyyatJurnallari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IstifadeciId = table.Column<int>(type: "int", nullable: false),
                    EmeliyyatTarixi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmeliyyatNovu = table.Column<int>(type: "int", nullable: false),
                    CədvəlAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObyektId = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Silinib = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmeliyyatJurnallari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qaytarmalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarix = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SatisId = table.Column<int>(type: "int", nullable: false),
                    UmumiMebleg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sebeb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KassirId = table.Column<int>(type: "int", nullable: false),
                    Silinib = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qaytarmalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Qaytarmalar_Istifadeciler_KassirId",
                        column: x => x.KassirId,
                        principalTable: "Istifadeciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Qaytarmalar_Satislar_SatisId",
                        column: x => x.SatisId,
                        principalTable: "Satislar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QaytarmaDetallari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QaytarmaId = table.Column<int>(type: "int", nullable: false),
                    MehsulId = table.Column<int>(type: "int", nullable: false),
                    Miqdar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qiymet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UmumiMebleg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Silinib = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QaytarmaDetallari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QaytarmaDetallari_Mehsullar_MehsulId",
                        column: x => x.MehsulId,
                        principalTable: "Mehsullar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QaytarmaDetallari_Qaytarmalar_QaytarmaId",
                        column: x => x.QaytarmaId,
                        principalTable: "Qaytarmalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Remove the problematic UpdateData calls that were causing syntax errors
            // These were trying to update existing records with empty column arrays

            migrationBuilder.CreateIndex(
                name: "IX_QaytarmaDetallari_QaytarmaId",
                table: "QaytarmaDetallari",
                column: "QaytarmaId");

            migrationBuilder.CreateIndex(
                name: "IX_QaytarmaDetallari_MehsulId",
                table: "QaytarmaDetallari",
                column: "MehsulId");

            migrationBuilder.CreateIndex(
                name: "IX_Qaytarmalar_KassirId",
                table: "Qaytarmalar",
                column: "KassirId");

            migrationBuilder.CreateIndex(
                name: "IX_Qaytarmalar_SatisId",
                table: "Qaytarmalar",
                column: "SatisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmeliyyatJurnallari");

            migrationBuilder.DropTable(
                name: "QaytarmaDetallari");

            migrationBuilder.DropTable(
                name: "Qaytarmalar");

            migrationBuilder.DropColumn(
                name: "SeriyaNomresi",
                table: "TemirSifarisleri");

            migrationBuilder.DropColumn(
                name: "ServisHaqqi",
                table: "TemirSifarisleri");

            migrationBuilder.DropColumn(
                name: "Silinib",
                table: "TemirSifarisleri");

            migrationBuilder.DropColumn(
                name: "ZemanetMuddeti",
                table: "TemirSifarisleri");

            migrationBuilder.DropColumn(
                name: "Silinib",
                table: "TedarukcuOdemeleri");

            migrationBuilder.DropColumn(
                name: "Silinib",
                table: "Tedarukculer");

            migrationBuilder.DropColumn(
                name: "Silinib",
                table: "Satislar");

            migrationBuilder.DropColumn(
                name: "Silinib",
                table: "SatisDetallari");

            migrationBuilder.DropColumn(
                name: "Silinib",
                table: "Rollar");

            migrationBuilder.DropColumn(
                name: "Silinib",
                table: "Novbeler");

            migrationBuilder.DropColumn(
                name: "Silinib",
                table: "NisyeHereketleri");

            migrationBuilder.DropColumn(
                name: "Silinib",
                table: "Musteriler");

            migrationBuilder.DropColumn(
                name: "Silinib",
                table: "Mehsullar");

            migrationBuilder.DropColumn(
                name: "Silinib",
                table: "Kateqoriyalar");

            migrationBuilder.DropColumn(
                name: "Silinib",
                table: "Istifadeciler");

            migrationBuilder.DropColumn(
                name: "Silinib",
                table: "IsciPerformanslari");

            migrationBuilder.DropColumn(
                name: "Silinib",
                table: "Isciler");

            migrationBuilder.DropColumn(
                name: "Silinib",
                table: "IsciIznleri");

            migrationBuilder.DropColumn(
                name: "Silinib",
                table: "Brendler");

            migrationBuilder.DropColumn(
                name: "Silinib",
                table: "AlisSifarisSetirleri");

            migrationBuilder.DropColumn(
                name: "Silinib",
                table: "AlisSifarisleri");

            migrationBuilder.DropColumn(
                name: "Silinib",
                table: "AlisSenetleri");

            migrationBuilder.DropColumn(
                name: "Silinib",
                table: "AlisSenedSetirleri");
        }
    }
}