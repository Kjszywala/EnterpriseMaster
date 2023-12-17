using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentreportsCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "PaymentReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                table: "PaymentReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "PaymentReports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportNumber",
                table: "PaymentReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReports_EmployeeId",
                table: "PaymentReports",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentReports_Employees_EmployeeId",
                table: "PaymentReports",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentReports_Employees_EmployeeId",
                table: "PaymentReports");

            migrationBuilder.DropIndex(
                name: "IX_PaymentReports_EmployeeId",
                table: "PaymentReports");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "PaymentReports");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "PaymentReports");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "PaymentReports");

            migrationBuilder.DropColumn(
                name: "ReportNumber",
                table: "PaymentReports");
        }
    }
}
