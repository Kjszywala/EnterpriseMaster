using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class AddInventoryTableCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "InventoryReports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReports_EmployeeId",
                table: "InventoryReports",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReports_Employees_EmployeeId",
                table: "InventoryReports",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReports_Employees_EmployeeId",
                table: "InventoryReports");

            migrationBuilder.DropIndex(
                name: "IX_InventoryReports_EmployeeId",
                table: "InventoryReports");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "InventoryReports");
        }
    }
}
