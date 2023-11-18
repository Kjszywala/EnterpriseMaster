using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class AddInvoiceItemCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillingAddressId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShippingAddressId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_BillingAddressId",
                table: "Invoices",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ShippingAddressId",
                table: "Invoices",
                column: "ShippingAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_BillingAddresses_BillingAddressId",
                table: "Invoices",
                column: "BillingAddressId",
                principalTable: "BillingAddresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_ShippingAddresses_ShippingAddressId",
                table: "Invoices",
                column: "ShippingAddressId",
                principalTable: "ShippingAddresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_BillingAddresses_BillingAddressId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_ShippingAddresses_ShippingAddressId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_BillingAddressId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ShippingAddressId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "BillingAddressId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ShippingAddressId",
                table: "Invoices");
        }
    }
}
