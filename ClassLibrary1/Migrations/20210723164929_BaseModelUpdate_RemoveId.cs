using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhiskyCrate.Data.Migrations
{
    public partial class BaseModelUpdate_RemoveId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Distilleries",
                table: "Distilleries");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Distilleries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Distilleries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Distilleries",
                table: "Distilleries",
                column: "Id");
        }
    }
}
