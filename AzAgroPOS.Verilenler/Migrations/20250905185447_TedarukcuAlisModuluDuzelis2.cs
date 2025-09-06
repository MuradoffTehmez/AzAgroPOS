using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class TedarukcuAlisModuluDuzelis2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tedarukculer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unvan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankHesabi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktivdir = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tedarukculer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlisSenetleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenedNomresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YaradilmaTarixi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TedarukcuId = table.Column<int>(type: "int", nullable: false),
                    TehvilTarixi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UmumiMebleg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Qeydler = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlisSenetleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlisSenetleri_Tedarukculer_TedarukcuId",
                        column: x => x.TedarukcuId,
                        principalTable: "Tedarukculer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlisSifarisleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SifarisNomresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YaradilmaTarixi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TesdiqTarixi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GozlenilenTehvilTarixi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FaktikiTehvilTarixi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TedarukcuId = table.Column<int>(type: "int", nullable: false),
                    UmumiMebleg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Qeydler = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlisSifarisleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlisSifarisleri_Tedarukculer_TedarukcuId",
                        column: x => x.TedarukcuId,
                        principalTable: "Tedarukculer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TedarukcuOdemeleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdemeNomresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YaradilmaTarixi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TedarukcuId = table.Column<int>(type: "int", nullable: false),
                    AlisSenedId = table.Column<int>(type: "int", nullable: true),
                    OdemeTarixi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mebleg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OdemeUsulu = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Qeydler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankMelumatlari = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TedarukcuOdemeleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TedarukcuOdemeleri_AlisSenetleri_AlisSenedId",
                        column: x => x.AlisSenedId,
                        principalTable: "AlisSenetleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TedarukcuOdemeleri_Tedarukculer_TedarukcuId",
                        column: x => x.TedarukcuId,
                        principalTable: "Tedarukculer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlisSifarisSetirleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlisSifarisId = table.Column<int>(type: "int", nullable: false),
                    MehsulId = table.Column<int>(type: "int", nullable: false),
                    Miqdar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BirVahidQiymet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CemiMebleg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TehvilAlinanMiqdar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlisSifarisSetirleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlisSifarisSetirleri_AlisSifarisleri_AlisSifarisId",
                        column: x => x.AlisSifarisId,
                        principalTable: "AlisSifarisleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlisSifarisSetirleri_Mehsullar_MehsulId",
                        column: x => x.MehsulId,
                        principalTable: "Mehsullar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlisSenedSetirleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlisSenedId = table.Column<int>(type: "int", nullable: false),
                    MehsulId = table.Column<int>(type: "int", nullable: false),
                    Miqdar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BirVahidQiymet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CemiMebleg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AlisSifarisSetiriId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlisSenedSetirleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlisSenedSetirleri_AlisSenetleri_AlisSenedId",
                        column: x => x.AlisSenedId,
                        principalTable: "AlisSenetleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlisSenedSetirleri_AlisSifarisSetirleri_AlisSifarisSetiriId",
                        column: x => x.AlisSifarisSetiriId,
                        principalTable: "AlisSifarisSetirleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlisSenedSetirleri_Mehsullar_MehsulId",
                        column: x => x.MehsulId,
                        principalTable: "Mehsullar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Tedarukculer",
                columns: new[] { "Id", "Ad", "Aktivdir", "BankHesabi", "Email", "Telefon", "Unvan", "Voen" },
                values: new object[,]
                {
                    { 1, "Ənənəvi Bakery", true, "IBAN: AZ12NABZ0000000012345678", "info@enanavi-bakery.az", "+994123456789", "Bakı şəh., Nəsimi r-nu, Cavid prospekti 45", "1234567890" },
                    { 2, "Fresh Dairy Products", true, "IBAN: AZ87NABZ0000000087654321", "orders@fresh-dairy.az", "+994181234567", "Sumqayıt şəh., Sənaye rayonu, Zavod küçəsi 12", "0987654321" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlisSenedSetirleri_AlisSenedId",
                table: "AlisSenedSetirleri",
                column: "AlisSenedId");

            migrationBuilder.CreateIndex(
                name: "IX_AlisSenedSetirleri_AlisSifarisSetiriId",
                table: "AlisSenedSetirleri",
                column: "AlisSifarisSetiriId");

            migrationBuilder.CreateIndex(
                name: "IX_AlisSenedSetirleri_MehsulId",
                table: "AlisSenedSetirleri",
                column: "MehsulId");

            migrationBuilder.CreateIndex(
                name: "IX_AlisSenetleri_TedarukcuId",
                table: "AlisSenetleri",
                column: "TedarukcuId");

            migrationBuilder.CreateIndex(
                name: "IX_AlisSifarisleri_TedarukcuId",
                table: "AlisSifarisleri",
                column: "TedarukcuId");

            migrationBuilder.CreateIndex(
                name: "IX_AlisSifarisSetirleri_AlisSifarisId",
                table: "AlisSifarisSetirleri",
                column: "AlisSifarisId");

            migrationBuilder.CreateIndex(
                name: "IX_AlisSifarisSetirleri_MehsulId",
                table: "AlisSifarisSetirleri",
                column: "MehsulId");

            migrationBuilder.CreateIndex(
                name: "IX_TedarukcuOdemeleri_AlisSenedId",
                table: "TedarukcuOdemeleri",
                column: "AlisSenedId");

            migrationBuilder.CreateIndex(
                name: "IX_TedarukcuOdemeleri_TedarukcuId",
                table: "TedarukcuOdemeleri",
                column: "TedarukcuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlisSenedSetirleri");

            migrationBuilder.DropTable(
                name: "TedarukcuOdemeleri");

            migrationBuilder.DropTable(
                name: "AlisSifarisSetirleri");

            migrationBuilder.DropTable(
                name: "AlisSenetleri");

            migrationBuilder.DropTable(
                name: "AlisSifarisleri");

            migrationBuilder.DropTable(
                name: "Tedarukculer");
        }
    }
}
