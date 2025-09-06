using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultPermissionsAndRolePermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Icazeler",
                columns: new[] { "Id", "Ad", "Tesvir" },
                values: new object[,]
                {
                    { 1, "CanDeleteSale", "Satış silmək imkanı" },
                    { 2, "CanGiveDiscount", "Endirim tətbiq etmək imkanı" },
                    { 3, "CanViewReports", "Hesabatları görmək imkanı" },
                    { 4, "CanManageProducts", "Məhsulları idarə etmək imkanı" },
                    { 5, "CanManageUsers", "İstifadəçiləri idarə etmək imkanı" }
                });

            migrationBuilder.InsertData(
                table: "RolIcazeleri",
                columns: new[] { "Id", "IcazeId", "RolId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 5, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolIcazeleri",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RolIcazeleri",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RolIcazeleri",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RolIcazeleri",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RolIcazeleri",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Icazeler",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Icazeler",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Icazeler",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Icazeler",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Icazeler",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
