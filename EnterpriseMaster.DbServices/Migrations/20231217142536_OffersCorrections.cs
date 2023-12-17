using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class OffersCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Offers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "Offers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RejectReason",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_EmployeeId",
                table: "Offers",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Employees_EmployeeId",
                table: "Offers",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Employees_EmployeeId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_EmployeeId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "RejectReason",
                table: "Offers");
        }
    }
}
