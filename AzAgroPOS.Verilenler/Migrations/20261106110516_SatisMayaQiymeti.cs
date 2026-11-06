using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class SatisMayaQiymeti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AlisQiymeti",
                table: "SatisDetallari",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlisQiymeti",
                table: "SatisDetallari");
        }
    }
}
