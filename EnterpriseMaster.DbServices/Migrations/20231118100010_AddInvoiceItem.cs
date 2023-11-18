using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class AddInvoiceItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_PurchaseOrders_PurchaseOrdersId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_SalesOrders_SalesOrdersId",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "SalesOrdersId",
                table: "Invoices",
                newName: "SalesOrderId");

            migrationBuilder.RenameColumn(
                name: "PurchaseOrdersId",
                table: "Invoices",
                newName: "PurchaseOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_SalesOrdersId",
                table: "Invoices",
                newName: "IX_Invoices_SalesOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_PurchaseOrdersId",
                table: "Invoices",
                newName: "IX_Invoices_PurchaseOrderId");

            migrationBuilder.AddColumn<int>(
                name: "CustomerInformationId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "InvoiceItemId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "InvoiceItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerInformationId",
                table: "Invoices",
                column: "CustomerInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceItemId",
                table: "Invoices",
                column: "InvoiceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_ProductId",
                table: "InvoiceItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_CustomerInformation_CustomerInformationId",
                table: "Invoices",
                column: "CustomerInformationId",
                principalTable: "CustomerInformation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_InvoiceItem_InvoiceItemId",
                table: "Invoices",
                column: "InvoiceItemId",
                principalTable: "InvoiceItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_PurchaseOrders_PurchaseOrderId",
                table: "Invoices",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_SalesOrders_SalesOrderId",
                table: "Invoices",
                column: "SalesOrderId",
                principalTable: "SalesOrders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_CustomerInformation_CustomerInformationId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_InvoiceItem_InvoiceItemId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_PurchaseOrders_PurchaseOrderId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_SalesOrders_SalesOrderId",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "InvoiceItem");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_CustomerInformationId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_InvoiceItemId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CustomerInformationId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceItemId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "SalesOrderId",
                table: "Invoices",
                newName: "SalesOrdersId");

            migrationBuilder.RenameColumn(
                name: "PurchaseOrderId",
                table: "Invoices",
                newName: "PurchaseOrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_SalesOrderId",
                table: "Invoices",
                newName: "IX_Invoices_SalesOrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_PurchaseOrderId",
                table: "Invoices",
                newName: "IX_Invoices_PurchaseOrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_PurchaseOrders_PurchaseOrdersId",
                table: "Invoices",
                column: "PurchaseOrdersId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_SalesOrders_SalesOrdersId",
                table: "Invoices",
                column: "SalesOrdersId",
                principalTable: "SalesOrders",
                principalColumn: "Id");
        }
    }
}
