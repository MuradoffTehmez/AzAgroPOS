using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class StokVeBorcReqabetYoxlamasi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Musteriler",
                type: "rowversion",
                rowVersion: true,
                nullable: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Mehsullar",
                type: "rowversion",
                rowVersion: true,
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Musteriler");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Mehsullar");
        }
    }
}
