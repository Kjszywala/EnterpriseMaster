using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentStatuId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentStatuId",
                table: "Payments",
                column: "PaymentStatuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PaymentStatus_PaymentStatuId",
                table: "Payments",
                column: "PaymentStatuId",
                principalTable: "PaymentStatus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PaymentStatus_PaymentStatuId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "PaymentStatus");

            migrationBuilder.DropIndex(
                name: "IX_Payments_PaymentStatuId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentStatuId",
                table: "Payments");
        }
    }
}
