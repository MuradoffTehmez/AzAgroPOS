using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class IstifadeciTemirElaqesiDuzelisi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Istifadeciler",
                keyColumn: "Id",
                keyValue: 1,
                column: "ParolHash",
                value: "$2a$12$7k.z0VbLveS04B26Sg6Xoel5d1k3e.d6eJd.r4zGuL/l0U8h5V2qC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Istifadeciler",
                keyColumn: "Id",
                keyValue: 1,
                column: "ParolHash",
                value: "admin_parolu_hash_formatinda_olmalidir");
        }
    }
}
