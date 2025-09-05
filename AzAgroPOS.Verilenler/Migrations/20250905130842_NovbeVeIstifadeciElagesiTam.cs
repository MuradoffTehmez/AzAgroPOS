using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class NovbeVeIstifadeciElagesiTam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Novbeler_Istifadeciler_IsciId",
                table: "Novbeler");

            migrationBuilder.AddColumn<int>(
                name: "KassirId",
                table: "Novbeler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Novbeler_KassirId",
                table: "Novbeler",
                column: "KassirId");

            migrationBuilder.AddForeignKey(
                name: "FK_Novbeler_Istifadeciler_IsciId",
                table: "Novbeler",
                column: "IsciId",
                principalTable: "Istifadeciler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Novbeler_Istifadeciler_KassirId",
                table: "Novbeler",
                column: "KassirId",
                principalTable: "Istifadeciler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Novbeler_Istifadeciler_IsciId",
                table: "Novbeler");

            migrationBuilder.DropForeignKey(
                name: "FK_Novbeler_Istifadeciler_KassirId",
                table: "Novbeler");

            migrationBuilder.DropIndex(
                name: "IX_Novbeler_KassirId",
                table: "Novbeler");

            migrationBuilder.DropColumn(
                name: "KassirId",
                table: "Novbeler");

            migrationBuilder.AddForeignKey(
                name: "FK_Novbeler_Istifadeciler_IsciId",
                table: "Novbeler",
                column: "IsciId",
                principalTable: "Istifadeciler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
