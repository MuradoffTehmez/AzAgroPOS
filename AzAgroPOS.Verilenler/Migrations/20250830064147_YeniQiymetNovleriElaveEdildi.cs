using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class YeniQiymetNovleriElaveEdildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SatisQiymeti",
                table: "Mehsullar",
                newName: "TopdanSatisQiymeti");

            migrationBuilder.AddColumn<decimal>(
                name: "PerakendeSatisQiymeti",
                table: "Mehsullar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TekEdedSatisQiymeti",
                table: "Mehsullar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Mehsullar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OlcuVahidi", "PerakendeSatisQiymeti", "TekEdedSatisQiymeti", "TopdanSatisQiymeti" },
                values: new object[] { 1, 0.70m, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Mehsullar",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "OlcuVahidi", "PerakendeSatisQiymeti", "TekEdedSatisQiymeti", "TopdanSatisQiymeti" },
                values: new object[] { 3, 2.50m, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Mehsullar",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "OlcuVahidi", "PerakendeSatisQiymeti", "TekEdedSatisQiymeti", "TopdanSatisQiymeti" },
                values: new object[] { 5, 3.20m, 0m, 0m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerakendeSatisQiymeti",
                table: "Mehsullar");

            migrationBuilder.DropColumn(
                name: "TekEdedSatisQiymeti",
                table: "Mehsullar");

            migrationBuilder.RenameColumn(
                name: "TopdanSatisQiymeti",
                table: "Mehsullar",
                newName: "SatisQiymeti");

            migrationBuilder.UpdateData(
                table: "Mehsullar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OlcuVahidi", "SatisQiymeti" },
                values: new object[] { 0, 0.70m });

            migrationBuilder.UpdateData(
                table: "Mehsullar",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "OlcuVahidi", "SatisQiymeti" },
                values: new object[] { 0, 2.50m });

            migrationBuilder.UpdateData(
                table: "Mehsullar",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "OlcuVahidi", "SatisQiymeti" },
                values: new object[] { 0, 3.20m });
        }
    }
}
