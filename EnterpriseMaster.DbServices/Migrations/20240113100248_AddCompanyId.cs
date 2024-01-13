using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "WhatsNew",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "UserRoles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "Trainings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "SupportCases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "SubscriptionOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "Shippers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "SalesOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "Returns",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "Refunds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "PurchaseOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "PurchaseOrderReports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "ProductionOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "PaymentReports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "Parts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "Offers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "JobOffers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "InvoiceItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "InventoryReports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "EmployeeRoles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "CustomerFeedbacks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company",
                table: "CaseStatus",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "WhatsNew");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "SupportCases");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "SubscriptionOrders");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Returns");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "PurchaseOrderReports");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "ProductionOrders");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "PaymentReports");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "InvoiceItem");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "InventoryReports");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "EmployeeRoles");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "CustomerFeedbacks");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "CaseStatus");
        }
    }
}
