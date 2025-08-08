using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class NovbeModuluElaveEdildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NovbeId",
                table: "Satislar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Novbeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsciId = table.Column<int>(type: "int", nullable: false),
                    AcilmaTarixi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaglanmaTarixi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaslangicMebleg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GozlenilenMebleg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FaktikiMebleg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novbeler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Novbeler_Istifadeciler_IsciId",
                        column: x => x.IsciId,
                        principalTable: "Istifadeciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Satislar_NovbeId",
                table: "Satislar",
                column: "NovbeId");

            migrationBuilder.CreateIndex(
                name: "IX_Novbeler_IsciId",
                table: "Novbeler",
                column: "IsciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Satislar_Novbeler_NovbeId",
                table: "Satislar",
                column: "NovbeId",
                principalTable: "Novbeler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Satislar_Novbeler_NovbeId",
                table: "Satislar");

            migrationBuilder.DropTable(
                name: "Novbeler");

            migrationBuilder.DropIndex(
                name: "IX_Satislar_NovbeId",
                table: "Satislar");

            migrationBuilder.DropColumn(
                name: "NovbeId",
                table: "Satislar");
        }
    }
}
