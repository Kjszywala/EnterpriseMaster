using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class ShippersCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Roles_RolesId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolesId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RolesId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Employees_RolesId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "ShippersAddressesId",
                table: "Shippers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shippers_ShippersAddressesId",
                table: "Shippers",
                column: "ShippersAddressesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shippers_ShippersAddresses_ShippersAddressesId",
                table: "Shippers",
                column: "ShippersAddressesId",
                principalTable: "ShippersAddresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shippers_ShippersAddresses_ShippersAddressesId",
                table: "Shippers");

            migrationBuilder.DropIndex(
                name: "IX_Shippers_ShippersAddressesId",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "ShippersAddressesId",
                table: "Shippers");

            migrationBuilder.AddColumn<int>(
                name: "RolesId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolesId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolesId",
                table: "Users",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RolesId",
                table: "Employees",
                column: "RolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Roles_RolesId",
                table: "Employees",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RolesId",
                table: "Users",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
