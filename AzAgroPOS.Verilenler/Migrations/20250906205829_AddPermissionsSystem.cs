using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionsSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Icazeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tesvir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Silinib = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icazeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolIcazeleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    IcazeId = table.Column<int>(type: "int", nullable: false),
                    Silinib = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolIcazeleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolIcazeleri_Icazeler_IcazeId",
                        column: x => x.IcazeId,
                        principalTable: "Icazeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolIcazeleri_Rollar_RolId",
                        column: x => x.RolId,
                        principalTable: "Rollar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolIcazeleri_IcazeId",
                table: "RolIcazeleri",
                column: "IcazeId");

            migrationBuilder.CreateIndex(
                name: "IX_RolIcazeleri_RolId",
                table: "RolIcazeleri",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolIcazeleri");

            migrationBuilder.DropTable(
                name: "Icazeler");
        }
    }
}
