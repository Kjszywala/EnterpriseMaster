using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class quantityTypesAddToParts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantityTypeId",
                table: "Parts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantityTypesId",
                table: "Parts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_QuantityTypesId",
                table: "Parts",
                column: "QuantityTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_QuantityTypes_QuantityTypesId",
                table: "Parts",
                column: "QuantityTypesId",
                principalTable: "QuantityTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_QuantityTypes_QuantityTypesId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_QuantityTypesId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "QuantityTypeId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "QuantityTypesId",
                table: "Parts");
        }
    }
}
