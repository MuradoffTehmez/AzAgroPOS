using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class MusteriKreditLimiti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "KreditLimiti",
                table: "Musteriler",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KreditLimiti",
                table: "Musteriler");
        }
    }
}
