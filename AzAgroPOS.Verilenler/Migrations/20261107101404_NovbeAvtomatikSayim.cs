using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class NovbeAvtomatikSayim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SayimAparilib",
                table: "Novbeler",
                type: "bit",
                nullable: false,
                defaultValue: false);

            // Əvvəlki bağlanmış növbələr əl ilə sayılmışdı.
            migrationBuilder.Sql("UPDATE Novbeler SET SayimAparilib = 1 WHERE Status = 2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SayimAparilib",
                table: "Novbeler");
        }
    }
}
