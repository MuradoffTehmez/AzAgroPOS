using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class MehsulaOlcuVahidiElaveEdildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OlcuVahidi",
                table: "Mehsullar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Mehsullar",
                keyColumn: "Id",
                keyValue: 1,
                column: "OlcuVahidi",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Mehsullar",
                keyColumn: "Id",
                keyValue: 2,
                column: "OlcuVahidi",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Mehsullar",
                keyColumn: "Id",
                keyValue: 3,
                column: "OlcuVahidi",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OlcuVahidi",
                table: "Mehsullar");
        }
    }
}
