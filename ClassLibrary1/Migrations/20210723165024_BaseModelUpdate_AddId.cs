using Microsoft.EntityFrameworkCore.Migrations;

namespace WhiskyCrate.Data.Migrations
{
    public partial class BaseModelUpdate_AddId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Distilleries",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Distilleries",
                table: "Distilleries",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Distilleries",
                table: "Distilleries");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Distilleries");
        }
    }
}
