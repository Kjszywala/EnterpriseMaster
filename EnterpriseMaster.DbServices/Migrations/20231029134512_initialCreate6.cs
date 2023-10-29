using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMaster.DbServices.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionTypes_ApplicationFeatures_FeatureId",
                table: "SubscriptionTypes");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionTypes_FeatureId",
                table: "SubscriptionTypes");

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionTypeId",
                table: "ApplicationFeatures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFeatures_SubscriptionTypeId",
                table: "ApplicationFeatures",
                column: "SubscriptionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationFeatures_SubscriptionTypes_SubscriptionTypeId",
                table: "ApplicationFeatures",
                column: "SubscriptionTypeId",
                principalTable: "SubscriptionTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationFeatures_SubscriptionTypes_SubscriptionTypeId",
                table: "ApplicationFeatures");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationFeatures_SubscriptionTypeId",
                table: "ApplicationFeatures");

            migrationBuilder.DropColumn(
                name: "SubscriptionTypeId",
                table: "ApplicationFeatures");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionTypes_FeatureId",
                table: "SubscriptionTypes",
                column: "FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionTypes_ApplicationFeatures_FeatureId",
                table: "SubscriptionTypes",
                column: "FeatureId",
                principalTable: "ApplicationFeatures",
                principalColumn: "Id");
        }
    }
}
