using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class PartsCompaniesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartsCompaniesId",
                table: "Parts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PartsCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsCompanies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parts_PartsCompaniesId",
                table: "Parts",
                column: "PartsCompaniesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_PartsCompanies_PartsCompaniesId",
                table: "Parts",
                column: "PartsCompaniesId",
                principalTable: "PartsCompanies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_PartsCompanies_PartsCompaniesId",
                table: "Parts");

            migrationBuilder.DropTable(
                name: "PartsCompanies");

            migrationBuilder.DropIndex(
                name: "IX_Parts_PartsCompaniesId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "PartsCompaniesId",
                table: "Parts");
        }
    }
}
