using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class PartsCompaniesMigrationCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_PartsCompanies_PartsCompaniesId",
                table: "Parts");

            migrationBuilder.DropTable(
                name: "PartsCompanies");

            migrationBuilder.RenameColumn(
                name: "PartsCompaniesId",
                table: "Parts",
                newName: "SuppliersId");

            migrationBuilder.RenameIndex(
                name: "IX_Parts_PartsCompaniesId",
                table: "Parts",
                newName: "IX_Parts_SuppliersId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Suppliers_SuppliersId",
                table: "Parts",
                column: "SuppliersId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Suppliers_SuppliersId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "SuppliersId",
                table: "Parts",
                newName: "PartsCompaniesId");

            migrationBuilder.RenameIndex(
                name: "IX_Parts_SuppliersId",
                table: "Parts",
                newName: "IX_Parts_PartsCompaniesId");

            migrationBuilder.CreateTable(
                name: "PartsCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsCompanies", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_PartsCompanies_PartsCompaniesId",
                table: "Parts",
                column: "PartsCompaniesId",
                principalTable: "PartsCompanies",
                principalColumn: "Id");
        }
    }
}
