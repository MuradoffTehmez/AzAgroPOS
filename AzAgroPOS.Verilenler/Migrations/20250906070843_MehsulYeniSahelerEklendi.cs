using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class MehsulYeniSahelerEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrendId",
                table: "Mehsullar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KateqoriyaId",
                table: "Mehsullar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinimumStok",
                table: "Mehsullar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SekilYolu",
                table: "Mehsullar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TedarukcuId",
                table: "Mehsullar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brendler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Olke = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vebsayt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tesvir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoqoFaylYolu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktivdir = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brendler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kateqoriyalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tesvir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktivdir = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kateqoriyalar", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Brendler",
                columns: new[] { "Id", "Ad", "Aktivdir", "LoqoFaylYolu", "Olke", "Tesvir", "Vebsayt" },
                values: new object[,]
                {
                    { 1, "Ənənəvi", true, null, "Azərbaycan", "Yerli brend", "www.enanevi.az" },
                    { 2, "Fresh", true, null, "Azərbaycan", "Təzə məhsullar", "www.fresh.az" },
                    { 3, "CleanHome", true, null, "Almaniya", "Təmizlik vasitələri", "www.cleanhome.de" }
                });

            migrationBuilder.InsertData(
                table: "Kateqoriyalar",
                columns: new[] { "Id", "Ad", "Aktivdir", "Tesvir" },
                values: new object[,]
                {
                    { 1, "Qida Məhsulları", true, "Yemək və içki məhsulları" },
                    { 2, "Təmizlik Vasitələri", true, "Ev təmizliyi üçün vasitələr" },
                    { 3, "Şəxsi Gigiyena", true, "Şəxsi gigiyena məhsulları" }
                });

            migrationBuilder.UpdateData(
                table: "Mehsullar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BrendId", "KateqoriyaId", "MinimumStok", "SekilYolu", "TedarukcuId" },
                values: new object[] { null, null, 0, null, null });

            migrationBuilder.UpdateData(
                table: "Mehsullar",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BrendId", "KateqoriyaId", "MinimumStok", "SekilYolu", "TedarukcuId" },
                values: new object[] { null, null, 0, null, null });

            migrationBuilder.UpdateData(
                table: "Mehsullar",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BrendId", "KateqoriyaId", "MinimumStok", "SekilYolu", "TedarukcuId" },
                values: new object[] { null, null, 0, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Mehsullar_BrendId",
                table: "Mehsullar",
                column: "BrendId");

            migrationBuilder.CreateIndex(
                name: "IX_Mehsullar_KateqoriyaId",
                table: "Mehsullar",
                column: "KateqoriyaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mehsullar_TedarukcuId",
                table: "Mehsullar",
                column: "TedarukcuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mehsullar_Brendler_BrendId",
                table: "Mehsullar",
                column: "BrendId",
                principalTable: "Brendler",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Mehsullar_Kateqoriyalar_KateqoriyaId",
                table: "Mehsullar",
                column: "KateqoriyaId",
                principalTable: "Kateqoriyalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Mehsullar_Tedarukculer_TedarukcuId",
                table: "Mehsullar",
                column: "TedarukcuId",
                principalTable: "Tedarukculer",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mehsullar_Brendler_BrendId",
                table: "Mehsullar");

            migrationBuilder.DropForeignKey(
                name: "FK_Mehsullar_Kateqoriyalar_KateqoriyaId",
                table: "Mehsullar");

            migrationBuilder.DropForeignKey(
                name: "FK_Mehsullar_Tedarukculer_TedarukcuId",
                table: "Mehsullar");

            migrationBuilder.DropTable(
                name: "Brendler");

            migrationBuilder.DropTable(
                name: "Kateqoriyalar");

            migrationBuilder.DropIndex(
                name: "IX_Mehsullar_BrendId",
                table: "Mehsullar");

            migrationBuilder.DropIndex(
                name: "IX_Mehsullar_KateqoriyaId",
                table: "Mehsullar");

            migrationBuilder.DropIndex(
                name: "IX_Mehsullar_TedarukcuId",
                table: "Mehsullar");

            migrationBuilder.DropColumn(
                name: "BrendId",
                table: "Mehsullar");

            migrationBuilder.DropColumn(
                name: "KateqoriyaId",
                table: "Mehsullar");

            migrationBuilder.DropColumn(
                name: "MinimumStok",
                table: "Mehsullar");

            migrationBuilder.DropColumn(
                name: "SekilYolu",
                table: "Mehsullar");

            migrationBuilder.DropColumn(
                name: "TedarukcuId",
                table: "Mehsullar");
        }
    }
}
