using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class AddPayments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "SalesOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentsId",
                table: "SalesOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "PurchaseOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentsId",
                table: "PurchaseOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentsId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_PaymentsId",
                table: "SalesOrders",
                column: "PaymentsId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_PaymentsId",
                table: "PurchaseOrders",
                column: "PaymentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PaymentsId",
                table: "Invoices",
                column: "PaymentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentMethodId",
                table: "Payments",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Payments_PaymentsId",
                table: "Invoices",
                column: "PaymentsId",
                principalTable: "Payments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Payments_PaymentsId",
                table: "PurchaseOrders",
                column: "PaymentsId",
                principalTable: "Payments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_Payments_PaymentsId",
                table: "SalesOrders",
                column: "PaymentsId",
                principalTable: "Payments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Payments_PaymentsId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Payments_PaymentsId",
                table: "PurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_Payments_PaymentsId",
                table: "SalesOrders");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrders_PaymentsId",
                table: "SalesOrders");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_PaymentsId",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_PaymentsId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "PaymentsId",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "PaymentsId",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "PaymentsId",
                table: "Invoices");
        }
    }
}
