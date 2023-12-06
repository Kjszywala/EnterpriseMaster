using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderStatusToPOAndSO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_OrderStatuses_OrderStatusesId",
                table: "PurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_OrderStatuses_OrderStatusesId",
                table: "SalesOrders");

            migrationBuilder.RenameColumn(
                name: "OrderStatusesId",
                table: "SalesOrders",
                newName: "OrderStatuseId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesOrders_OrderStatusesId",
                table: "SalesOrders",
                newName: "IX_SalesOrders_OrderStatuseId");

            migrationBuilder.RenameColumn(
                name: "OrderStatusesId",
                table: "PurchaseOrders",
                newName: "OrderStatuseId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrders_OrderStatusesId",
                table: "PurchaseOrders",
                newName: "IX_PurchaseOrders_OrderStatuseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_OrderStatuses_OrderStatuseId",
                table: "PurchaseOrders",
                column: "OrderStatuseId",
                principalTable: "OrderStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_OrderStatuses_OrderStatuseId",
                table: "SalesOrders",
                column: "OrderStatuseId",
                principalTable: "OrderStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_OrderStatuses_OrderStatuseId",
                table: "PurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_OrderStatuses_OrderStatuseId",
                table: "SalesOrders");

            migrationBuilder.RenameColumn(
                name: "OrderStatuseId",
                table: "SalesOrders",
                newName: "OrderStatusesId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesOrders_OrderStatuseId",
                table: "SalesOrders",
                newName: "IX_SalesOrders_OrderStatusesId");

            migrationBuilder.RenameColumn(
                name: "OrderStatuseId",
                table: "PurchaseOrders",
                newName: "OrderStatusesId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrders_OrderStatuseId",
                table: "PurchaseOrders",
                newName: "IX_PurchaseOrders_OrderStatusesId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_OrderStatuses_OrderStatusesId",
                table: "PurchaseOrders",
                column: "OrderStatusesId",
                principalTable: "OrderStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_OrderStatuses_OrderStatusesId",
                table: "SalesOrders",
                column: "OrderStatusesId",
                principalTable: "OrderStatuses",
                principalColumn: "Id");
        }
    }
}
