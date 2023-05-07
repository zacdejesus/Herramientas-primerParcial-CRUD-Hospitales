using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospitales.Migrations
{
    /// <inheritdoc />
    public partial class fixInDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Hospital_hospitalId",
                table: "Doctor");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Hospital_hospitalId",
                table: "Doctor",
                column: "hospitalId",
                principalTable: "Hospital",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Hospital_hospitalId",
                table: "Doctor");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Hospital_hospitalId",
                table: "Doctor",
                column: "hospitalId",
                principalTable: "Hospital",
                principalColumn: "id");
        }
    }
}
