using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_UserAccesses_EmployeeAccessId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccesses",
                table: "UserAccesses");

            migrationBuilder.RenameTable(
                name: "UserAccesses",
                newName: "EmployeeAccesses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HireDate",
                table: "Employees",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeAccesses",
                table: "EmployeeAccesses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeAccesses_EmployeeAccessId",
                table: "Employees",
                column: "EmployeeAccessId",
                principalTable: "EmployeeAccesses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeAccesses_EmployeeAccessId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeAccesses",
                table: "EmployeeAccesses");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "EmployeeAccesses",
                newName: "UserAccesses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HireDate",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccesses",
                table: "UserAccesses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_UserAccesses_EmployeeAccessId",
                table: "Employees",
                column: "EmployeeAccessId",
                principalTable: "UserAccesses",
                principalColumn: "Id");
        }
    }
}
