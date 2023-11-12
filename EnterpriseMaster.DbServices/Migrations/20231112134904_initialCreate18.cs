using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompaniesId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompaniesId",
                table: "Users",
                column: "CompaniesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompaniesId",
                table: "Users",
                column: "CompaniesId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompaniesId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompaniesId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompaniesId",
                table: "Users");
        }
    }
}
