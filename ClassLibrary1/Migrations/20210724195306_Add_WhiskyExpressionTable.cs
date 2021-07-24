using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhiskyCrate.Data.Migrations
{
    public partial class Add_WhiskyExpressionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WhiskyExpression",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgeInMonths = table.Column<int>(type: "int", nullable: false),
                    TastingNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistillingNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistilleryId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhiskyExpression", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhiskyExpression_Distilleries_DistilleryId",
                        column: x => x.DistilleryId,
                        principalTable: "Distilleries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WhiskyExpression_DistilleryId",
                table: "WhiskyExpression",
                column: "DistilleryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WhiskyExpression");
        }
    }
}
