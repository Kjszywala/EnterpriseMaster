using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class AddPurchaseAndSalesOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustomerInformation_CustomerInformationId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusesId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderStatusesId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderStatusesId",
                table: "Orders",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "CustomerInformationId",
                table: "Orders",
                newName: "CompaniesId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerInformationId",
                table: "Orders",
                newName: "IX_Orders_CompaniesId");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrdersId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesOrdersId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "CustomerInformation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerAddressId",
                table: "CustomerInformation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddressId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    QuantityTypeId = table.Column<int>(type: "int", nullable: true),
                    PricePaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CompaniesId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    RejectedReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentTerm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillingAddressesId = table.Column<int>(type: "int", nullable: true),
                    OrderStatusesId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_BillingAddresses_BillingAddressesId",
                        column: x => x.BillingAddressesId,
                        principalTable: "BillingAddresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_OrderStatuses_OrderStatusesId",
                        column: x => x.OrderStatusesId,
                        principalTable: "OrderStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_QuantityTypes_QuantityTypeId",
                        column: x => x.QuantityTypeId,
                        principalTable: "QuantityTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_ShippingAddresses_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "ShippingAddresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalesOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerInformationId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    QuantityTypeId = table.Column<int>(type: "int", nullable: true),
                    PricePaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CompaniesId = table.Column<int>(type: "int", nullable: true),
                    RejectedReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentTerm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillingAddressId = table.Column<int>(type: "int", nullable: true),
                    OrderStatusesId = table.Column<int>(type: "int", nullable: true),
                    ShippingAddressesId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrders_BillingAddresses_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "BillingAddresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesOrders_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesOrders_CustomerInformation_CustomerInformationId",
                        column: x => x.CustomerInformationId,
                        principalTable: "CustomerInformation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesOrders_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesOrders_OrderStatuses_OrderStatusesId",
                        column: x => x.OrderStatusesId,
                        principalTable: "OrderStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesOrders_QuantityTypes_QuantityTypeId",
                        column: x => x.QuantityTypeId,
                        principalTable: "QuantityTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesOrders_ShippingAddresses_ShippingAddressesId",
                        column: x => x.ShippingAddressesId,
                        principalTable: "ShippingAddresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PurchaseOrdersId",
                table: "Invoices",
                column: "PurchaseOrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SalesOrdersId",
                table: "Invoices",
                column: "SalesOrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInformation_CompanyId",
                table: "CustomerInformation",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInformation_CustomerAddressId",
                table: "CustomerInformation",
                column: "CustomerAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_BillingAddressesId",
                table: "PurchaseOrders",
                column: "BillingAddressesId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_CompaniesId",
                table: "PurchaseOrders",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_EmployeeId",
                table: "PurchaseOrders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_OrderStatusesId",
                table: "PurchaseOrders",
                column: "OrderStatusesId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_ProductId",
                table: "PurchaseOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_QuantityTypeId",
                table: "PurchaseOrders",
                column: "QuantityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_ShippingAddressId",
                table: "PurchaseOrders",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_SupplierId",
                table: "PurchaseOrders",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_BillingAddressId",
                table: "SalesOrders",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_CompaniesId",
                table: "SalesOrders",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_CustomerInformationId",
                table: "SalesOrders",
                column: "CustomerInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_EmployeeId",
                table: "SalesOrders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_OrderStatusesId",
                table: "SalesOrders",
                column: "OrderStatusesId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_ProductId",
                table: "SalesOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_QuantityTypeId",
                table: "SalesOrders",
                column: "QuantityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_ShippingAddressesId",
                table: "SalesOrders",
                column: "ShippingAddressesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInformation_Companies_CompanyId",
                table: "CustomerInformation",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInformation_CustomerAddresses_CustomerAddressId",
                table: "CustomerInformation",
                column: "CustomerAddressId",
                principalTable: "CustomerAddresses",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Companies_CompaniesId",
                table: "Orders",
                column: "CompaniesId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInformation_Companies_CompanyId",
                table: "CustomerInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInformation_CustomerAddresses_CustomerAddressId",
                table: "CustomerInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_PurchaseOrders_PurchaseOrdersId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_SalesOrders_SalesOrdersId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Companies_CompaniesId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "SalesOrders");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_PurchaseOrdersId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_SalesOrdersId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInformation_CompanyId",
                table: "CustomerInformation");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInformation_CustomerAddressId",
                table: "CustomerInformation");

            migrationBuilder.DropColumn(
                name: "PurchaseOrdersId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "SalesOrdersId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "CustomerInformation");

            migrationBuilder.DropColumn(
                name: "CustomerAddressId",
                table: "CustomerInformation");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Orders",
                newName: "OrderStatusesId");

            migrationBuilder.RenameColumn(
                name: "CompaniesId",
                table: "Orders",
                newName: "CustomerInformationId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CompaniesId",
                table: "Orders",
                newName: "IX_Orders_CustomerInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusesId",
                table: "Orders",
                column: "OrderStatusesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustomerInformation_CustomerInformationId",
                table: "Orders",
                column: "CustomerInformationId",
                principalTable: "CustomerInformation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusesId",
                table: "Orders",
                column: "OrderStatusesId",
                principalTable: "OrderStatuses",
                principalColumn: "Id");
        }
    }
}
