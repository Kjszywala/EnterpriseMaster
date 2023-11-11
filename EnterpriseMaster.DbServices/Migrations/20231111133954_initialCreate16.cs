using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_EmployeeId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "EmployeeAccessId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees",
                newName: "IX_Employees_EmployeeAccessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_UserAccesses_EmployeeAccessId",
                table: "Employees",
                column: "EmployeeAccessId",
                principalTable: "UserAccesses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_UserAccesses_EmployeeAccessId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmployeeAccessId",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_EmployeeAccessId",
                table: "Employees",
                newName: "IX_Employees_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_EmployeeId",
                table: "Employees",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
