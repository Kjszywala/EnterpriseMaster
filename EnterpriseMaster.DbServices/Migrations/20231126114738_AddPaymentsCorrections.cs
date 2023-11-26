using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentsCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "InvoicesId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesOrdersId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_InvoicesId",
                table: "Payments",
                column: "InvoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PurchaseOrderId",
                table: "Payments",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_SalesOrdersId",
                table: "Payments",
                column: "SalesOrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Invoices_InvoicesId",
                table: "Payments",
                column: "InvoicesId",
                principalTable: "Invoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PurchaseOrders_PurchaseOrderId",
                table: "Payments",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_SalesOrders_SalesOrdersId",
                table: "Payments",
                column: "SalesOrdersId",
                principalTable: "SalesOrders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Invoices_InvoicesId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PurchaseOrders_PurchaseOrderId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_SalesOrders_SalesOrdersId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_InvoicesId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_PurchaseOrderId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_SalesOrdersId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "InvoicesId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "SalesOrdersId",
                table: "Payments");

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
    }
}
