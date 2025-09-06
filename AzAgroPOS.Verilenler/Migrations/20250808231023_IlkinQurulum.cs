using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class IlkinQurulum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mehsullar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StokKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Barkod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SatisQiymeti = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AlisQiymeti = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MovcudSay = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mehsullar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TamAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonNomresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unvan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UmumiBorc = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rollar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rollar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Istifadeciler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IstifadeciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParolHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TamAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Istifadeciler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Istifadeciler_Rollar_RolId",
                        column: x => x.RolId,
                        principalTable: "Rollar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Novbeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsciId = table.Column<int>(type: "int", nullable: false),
                    AcilmaTarixi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaglanmaTarixi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaslangicMebleg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GozlenilenMebleg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FaktikiMebleg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novbeler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Novbeler_Istifadeciler_IsciId",
                        column: x => x.IsciId,
                        principalTable: "Istifadeciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemirSifarisleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CihazAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProblemTesviri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QebulTarixi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TamamlanmaTarixi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TemirXerci = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YekunMebleg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsciId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemirSifarisleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemirSifarisleri_Istifadeciler_IsciId",
                        column: x => x.IsciId,
                        principalTable: "Istifadeciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Satislar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarix = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UmumiMebleg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OdenisMetodu = table.Column<int>(type: "int", nullable: false),
                    MusteriId = table.Column<int>(type: "int", nullable: true),
                    NovbeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Satislar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Satislar_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Satislar_Novbeler_NovbeId",
                        column: x => x.NovbeId,
                        principalTable: "Novbeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NisyeHereketleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    Tarix = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmeliyyatNovu = table.Column<int>(type: "int", nullable: false),
                    Mebleg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SatisId = table.Column<int>(type: "int", nullable: true),
                    Qeyd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NisyeHereketleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NisyeHereketleri_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NisyeHereketleri_Satislar_SatisId",
                        column: x => x.SatisId,
                        principalTable: "Satislar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SatisDetallari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SatisId = table.Column<int>(type: "int", nullable: false),
                    MehsulId = table.Column<int>(type: "int", nullable: false),
                    Miqdar = table.Column<int>(type: "int", nullable: false),
                    Qiymet = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatisDetallari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SatisDetallari_Mehsullar_MehsulId",
                        column: x => x.MehsulId,
                        principalTable: "Mehsullar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SatisDetallari_Satislar_SatisId",
                        column: x => x.SatisId,
                        principalTable: "Satislar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Mehsullar",
                columns: new[] { "Id", "Ad", "AlisQiymeti", "Barkod", "MovcudSay", "SatisQiymeti", "StokKodu" },
                values: new object[,]
                {
                    { 1, "Çörək", 0.50m, "869000000001", 100, 0.70m, "SK001" },
                    { 2, "Süd 1L", 2.00m, "869000000002", 50, 2.50m, "SK002" },
                    { 3, "Yumurta (10 ədəd)", 2.80m, "869000000003", 200, 3.20m, "SK003" }
                });

            migrationBuilder.InsertData(
                table: "Rollar",
                columns: new[] { "Id", "Ad" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Kassir" }
                });

            migrationBuilder.InsertData(
                table: "Istifadeciler",
                columns: new[] { "Id", "IstifadeciAdi", "ParolHash", "RolId", "TamAd" },
                values: new object[] { 1, "admin", "$2a$11$wvv2PHlk9LWlv4vuz3eEBl.ynUDwxFQSIHWle5nHfS3sL7hTkTQPG", 1, "Sistem Administratoru" });

            migrationBuilder.CreateIndex(
                name: "IX_Istifadeciler_RolId",
                table: "Istifadeciler",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_NisyeHereketleri_MusteriId",
                table: "NisyeHereketleri",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_NisyeHereketleri_SatisId",
                table: "NisyeHereketleri",
                column: "SatisId");

            migrationBuilder.CreateIndex(
                name: "IX_Novbeler_IsciId",
                table: "Novbeler",
                column: "IsciId");

            migrationBuilder.CreateIndex(
                name: "IX_SatisDetallari_MehsulId",
                table: "SatisDetallari",
                column: "MehsulId");

            migrationBuilder.CreateIndex(
                name: "IX_SatisDetallari_SatisId",
                table: "SatisDetallari",
                column: "SatisId");

            migrationBuilder.CreateIndex(
                name: "IX_Satislar_MusteriId",
                table: "Satislar",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Satislar_NovbeId",
                table: "Satislar",
                column: "NovbeId");

            migrationBuilder.CreateIndex(
                name: "IX_TemirSifarisleri_IsciId",
                table: "TemirSifarisleri",
                column: "IsciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NisyeHereketleri");

            migrationBuilder.DropTable(
                name: "SatisDetallari");

            migrationBuilder.DropTable(
                name: "TemirSifarisleri");

            migrationBuilder.DropTable(
                name: "Mehsullar");

            migrationBuilder.DropTable(
                name: "Satislar");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropTable(
                name: "Novbeler");

            migrationBuilder.DropTable(
                name: "Istifadeciler");

            migrationBuilder.DropTable(
                name: "Rollar");
        }
    }
}
