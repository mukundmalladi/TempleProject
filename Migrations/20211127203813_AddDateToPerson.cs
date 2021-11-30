using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TempleProject.Migrations
{
    public partial class AddDateToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Now);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Person");
        }
    }
}
