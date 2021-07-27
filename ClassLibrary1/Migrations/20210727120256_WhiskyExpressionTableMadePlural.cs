using Microsoft.EntityFrameworkCore.Migrations;

namespace WhiskyCrate.Data.Migrations
{
    public partial class WhiskyExpressionTableMadePlural : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WhiskyExpression_Distilleries_DistilleryId",
                table: "WhiskyExpression");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WhiskyExpression",
                table: "WhiskyExpression");

            migrationBuilder.RenameTable(
                name: "WhiskyExpression",
                newName: "WhiskyExpressions");

            migrationBuilder.RenameIndex(
                name: "IX_WhiskyExpression_DistilleryId",
                table: "WhiskyExpressions",
                newName: "IX_WhiskyExpressions_DistilleryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WhiskyExpressions",
                table: "WhiskyExpressions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WhiskyExpressions_Distilleries_DistilleryId",
                table: "WhiskyExpressions",
                column: "DistilleryId",
                principalTable: "Distilleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WhiskyExpressions_Distilleries_DistilleryId",
                table: "WhiskyExpressions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WhiskyExpressions",
                table: "WhiskyExpressions");

            migrationBuilder.RenameTable(
                name: "WhiskyExpressions",
                newName: "WhiskyExpression");

            migrationBuilder.RenameIndex(
                name: "IX_WhiskyExpressions_DistilleryId",
                table: "WhiskyExpression",
                newName: "IX_WhiskyExpression_DistilleryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WhiskyExpression",
                table: "WhiskyExpression",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WhiskyExpression_Distilleries_DistilleryId",
                table: "WhiskyExpression",
                column: "DistilleryId",
                principalTable: "Distilleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
