using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentReports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: true),
                    PartId = table.Column<int>(type: "int", nullable: true),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: true),
                    InvoicesId = table.Column<int>(type: "int", nullable: true),
                    PaymentStatusId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PricePaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LargestSinglePayment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentsTotal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MostFrequentlySellPart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MostFrequentlyPaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LargestQuantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityTotal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentReports_Invoices_InvoicesId",
                        column: x => x.InvoicesId,
                        principalTable: "Invoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentReports_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentReports_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentReports_PaymentStatus_PaymentStatusId",
                        column: x => x.PaymentStatusId,
                        principalTable: "PaymentStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentReports_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReports_InvoicesId",
                table: "PaymentReports",
                column: "InvoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReports_PartId",
                table: "PaymentReports",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReports_PaymentMethodId",
                table: "PaymentReports",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReports_PaymentStatusId",
                table: "PaymentReports",
                column: "PaymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReports_PurchaseOrderId",
                table: "PaymentReports",
                column: "PurchaseOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentReports");
        }
    }
}
