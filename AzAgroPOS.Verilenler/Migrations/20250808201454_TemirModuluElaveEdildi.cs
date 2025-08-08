using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class TemirModuluElaveEdildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TemirSifarisleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CihazAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProblemTesviri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QebulTarixi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TamamlanmaTarixi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TemirXerci = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YekunMebleg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsciId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemirSifarisleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemirSifarisleri_Istifadeciler_IsciId",
                        column: x => x.IsciId,
                        principalTable: "Istifadeciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemirSifarisleri_IsciId",
                table: "TemirSifarisleri",
                column: "IsciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemirSifarisleri");
        }
    }
}
