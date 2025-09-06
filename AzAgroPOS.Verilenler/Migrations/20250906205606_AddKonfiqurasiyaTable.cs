using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class AddKonfiqurasiyaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Konfiqurasiyalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Acar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deyer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tesvir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qrup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Silinib = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konfiqurasiyalar", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Konfiqurasiyalar");
        }
    }
}
