using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class BorcOdenisiNovbeUzlasmasi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NovbeId",
                table: "KassaHareketleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OdenisMetodu",
                table: "KassaHareketleri",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NovbeId",
                table: "KassaHareketleri");

            migrationBuilder.DropColumn(
                name: "OdenisMetodu",
                table: "KassaHareketleri");
        }
    }
}
