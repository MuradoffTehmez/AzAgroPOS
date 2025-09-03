using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class OlcuVahidiIdSutununuSil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OlcuVahidiId",
                table: "Mehsullar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OlcuVahidiId",
                table: "Mehsullar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Mehsullar",
                keyColumn: "Id",
                keyValue: 1,
                column: "OlcuVahidiId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Mehsullar",
                keyColumn: "Id",
                keyValue: 2,
                column: "OlcuVahidiId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Mehsullar",
                keyColumn: "Id",
                keyValue: 3,
                column: "OlcuVahidiId",
                value: 0);
        }
    }
}
