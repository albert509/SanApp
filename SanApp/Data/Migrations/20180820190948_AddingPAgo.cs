using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SanApp.Data.Migrations
{
    public partial class AddingPAgo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaPago",
                table: "Pagos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaPago",
                table: "Pagos");
        }
    }
}
