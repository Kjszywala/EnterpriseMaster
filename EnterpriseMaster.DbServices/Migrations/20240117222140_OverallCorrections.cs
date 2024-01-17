using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class OverallCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EffortPoints",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TasksPrioritiesId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TasksPriorityId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ProfessionalPlanPage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdvancedAccountingText",
                table: "ProfessionalPlanPage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdvancedAccountingTextTitle",
                table: "ProfessionalPlanPage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GetStarted",
                table: "ProfessionalPlanPage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ManageCustomerDataText",
                table: "ProfessionalPlanPage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ManageCustomerDataTextTitle",
                table: "ProfessionalPlanPage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlanSalesActivitiesText",
                table: "ProfessionalPlanPage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlanSalesActivitiesTextTitle",
                table: "ProfessionalPlanPage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfessionalPlanText",
                table: "ProfessionalPlanPage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfessionalPlanTextTitle",
                table: "ProfessionalPlanPage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnalyticsOption1",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnalyticsOption2",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnalyticsOption3",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnalyticsOption4",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnalyticsOption5",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnalyticsText",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnalyticsTitle",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasicPlanOption1",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasicPlanOption2",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasicPlanOption3",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasicPlanOption4",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasicPlanOption5",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasicPlanPrice",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasicPlanText",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnterprisePlanOption1",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnterprisePlanOption2",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnterprisePlanOption3",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnterprisePlanOption4",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnterprisePlanOption5",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnterprisePlanOption6",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnterprisePlanPrice",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnterprisePlanText",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProPlanOption1",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProPlanOption2",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProPlanOption3",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProPlanOption4",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProPlanOption5",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProPlanPrice",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProPlanText",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesOption1",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesOption2",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesOption3",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesOption4",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesOption5",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesText",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesTitle",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextOverButton",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleOverButton",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WarehouseOption1",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WarehouseOption2",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WarehouseOption3",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WarehouseOption4",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WarehouseOption5",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WarehouseText",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WarehouseTitle",
                table: "MainPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnalyticsReportingText",
                table: "EnterprisePlan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnalyticsReportingTitle",
                table: "EnterprisePlan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnterprisePlanText",
                table: "EnterprisePlan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnterprisePlanTitle",
                table: "EnterprisePlan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GetStarted",
                table: "EnterprisePlan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HumanResourcesText",
                table: "EnterprisePlan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HumanResourcesTitle",
                table: "EnterprisePlan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductionManagementText",
                table: "EnterprisePlan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductionManagementTitle",
                table: "EnterprisePlan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasicCreateOffersText",
                table: "BasicPlanPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasicCreateOffersTextTitle",
                table: "BasicPlanPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasicFinancialManagementText",
                table: "BasicPlanPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasicFinancialManagementTextTitle",
                table: "BasicPlanPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasicGenerateInvoicesText",
                table: "BasicPlanPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasicGenerateInvoicesTextTitle",
                table: "BasicPlanPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasicInventoryText",
                table: "BasicPlanPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasicInventoryTextTitle",
                table: "BasicPlanPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasicManageOrdersText",
                table: "BasicPlanPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasicManageOrdersTextTitle",
                table: "BasicPlanPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasicSalesText",
                table: "BasicPlanPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasicSalesTextTitle",
                table: "BasicPlanPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GetStarted",
                table: "BasicPlanPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUsTitle",
                table: "AboutPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUsTitleLess",
                table: "AboutPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUsTitleText",
                table: "AboutPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OurMissionTitle",
                table: "AboutPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OurMissionTitleLess",
                table: "AboutPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OurMissionTitleText",
                table: "AboutPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OurVisionTitle",
                table: "AboutPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OurVisionTitleLess",
                table: "AboutPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OurVisionTitleText",
                table: "AboutPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TasksPriorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksPriorities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TasksPrioritiesId",
                table: "Tasks",
                column: "TasksPrioritiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TasksPriorities_TasksPrioritiesId",
                table: "Tasks",
                column: "TasksPrioritiesId",
                principalTable: "TasksPriorities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TasksPriorities_TasksPrioritiesId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "TasksPriorities");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TasksPrioritiesId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "EffortPoints",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TasksPrioritiesId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TasksPriorityId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AdvancedAccountingText",
                table: "ProfessionalPlanPage");

            migrationBuilder.DropColumn(
                name: "AdvancedAccountingTextTitle",
                table: "ProfessionalPlanPage");

            migrationBuilder.DropColumn(
                name: "GetStarted",
                table: "ProfessionalPlanPage");

            migrationBuilder.DropColumn(
                name: "ManageCustomerDataText",
                table: "ProfessionalPlanPage");

            migrationBuilder.DropColumn(
                name: "ManageCustomerDataTextTitle",
                table: "ProfessionalPlanPage");

            migrationBuilder.DropColumn(
                name: "PlanSalesActivitiesText",
                table: "ProfessionalPlanPage");

            migrationBuilder.DropColumn(
                name: "PlanSalesActivitiesTextTitle",
                table: "ProfessionalPlanPage");

            migrationBuilder.DropColumn(
                name: "ProfessionalPlanText",
                table: "ProfessionalPlanPage");

            migrationBuilder.DropColumn(
                name: "ProfessionalPlanTextTitle",
                table: "ProfessionalPlanPage");

            migrationBuilder.DropColumn(
                name: "AnalyticsOption1",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "AnalyticsOption2",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "AnalyticsOption3",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "AnalyticsOption4",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "AnalyticsOption5",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "AnalyticsText",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "AnalyticsTitle",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "BasicPlanOption1",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "BasicPlanOption2",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "BasicPlanOption3",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "BasicPlanOption4",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "BasicPlanOption5",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "BasicPlanPrice",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "BasicPlanText",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "EnterprisePlanOption1",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "EnterprisePlanOption2",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "EnterprisePlanOption3",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "EnterprisePlanOption4",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "EnterprisePlanOption5",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "EnterprisePlanOption6",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "EnterprisePlanPrice",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "EnterprisePlanText",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "ProPlanOption1",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "ProPlanOption2",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "ProPlanOption3",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "ProPlanOption4",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "ProPlanOption5",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "ProPlanPrice",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "ProPlanText",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "SalesOption1",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "SalesOption2",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "SalesOption3",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "SalesOption4",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "SalesOption5",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "SalesText",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "SalesTitle",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "TextOverButton",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "TitleOverButton",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "WarehouseOption1",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "WarehouseOption2",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "WarehouseOption3",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "WarehouseOption4",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "WarehouseOption5",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "WarehouseText",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "WarehouseTitle",
                table: "MainPages");

            migrationBuilder.DropColumn(
                name: "AnalyticsReportingText",
                table: "EnterprisePlan");

            migrationBuilder.DropColumn(
                name: "AnalyticsReportingTitle",
                table: "EnterprisePlan");

            migrationBuilder.DropColumn(
                name: "EnterprisePlanText",
                table: "EnterprisePlan");

            migrationBuilder.DropColumn(
                name: "EnterprisePlanTitle",
                table: "EnterprisePlan");

            migrationBuilder.DropColumn(
                name: "GetStarted",
                table: "EnterprisePlan");

            migrationBuilder.DropColumn(
                name: "HumanResourcesText",
                table: "EnterprisePlan");

            migrationBuilder.DropColumn(
                name: "HumanResourcesTitle",
                table: "EnterprisePlan");

            migrationBuilder.DropColumn(
                name: "ProductionManagementText",
                table: "EnterprisePlan");

            migrationBuilder.DropColumn(
                name: "ProductionManagementTitle",
                table: "EnterprisePlan");

            migrationBuilder.DropColumn(
                name: "BasicCreateOffersText",
                table: "BasicPlanPage");

            migrationBuilder.DropColumn(
                name: "BasicCreateOffersTextTitle",
                table: "BasicPlanPage");

            migrationBuilder.DropColumn(
                name: "BasicFinancialManagementText",
                table: "BasicPlanPage");

            migrationBuilder.DropColumn(
                name: "BasicFinancialManagementTextTitle",
                table: "BasicPlanPage");

            migrationBuilder.DropColumn(
                name: "BasicGenerateInvoicesText",
                table: "BasicPlanPage");

            migrationBuilder.DropColumn(
                name: "BasicGenerateInvoicesTextTitle",
                table: "BasicPlanPage");

            migrationBuilder.DropColumn(
                name: "BasicInventoryText",
                table: "BasicPlanPage");

            migrationBuilder.DropColumn(
                name: "BasicInventoryTextTitle",
                table: "BasicPlanPage");

            migrationBuilder.DropColumn(
                name: "BasicManageOrdersText",
                table: "BasicPlanPage");

            migrationBuilder.DropColumn(
                name: "BasicManageOrdersTextTitle",
                table: "BasicPlanPage");

            migrationBuilder.DropColumn(
                name: "BasicSalesText",
                table: "BasicPlanPage");

            migrationBuilder.DropColumn(
                name: "BasicSalesTextTitle",
                table: "BasicPlanPage");

            migrationBuilder.DropColumn(
                name: "GetStarted",
                table: "BasicPlanPage");

            migrationBuilder.DropColumn(
                name: "AboutUsTitle",
                table: "AboutPage");

            migrationBuilder.DropColumn(
                name: "AboutUsTitleLess",
                table: "AboutPage");

            migrationBuilder.DropColumn(
                name: "AboutUsTitleText",
                table: "AboutPage");

            migrationBuilder.DropColumn(
                name: "OurMissionTitle",
                table: "AboutPage");

            migrationBuilder.DropColumn(
                name: "OurMissionTitleLess",
                table: "AboutPage");

            migrationBuilder.DropColumn(
                name: "OurMissionTitleText",
                table: "AboutPage");

            migrationBuilder.DropColumn(
                name: "OurVisionTitle",
                table: "AboutPage");

            migrationBuilder.DropColumn(
                name: "OurVisionTitleLess",
                table: "AboutPage");

            migrationBuilder.DropColumn(
                name: "OurVisionTitleText",
                table: "AboutPage");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ProfessionalPlanPage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
