using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAMvc1._1.Data.Migrations
{
    public partial class standings_timestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Updated",
                table: "Team",
                newName: "TimeStamp");

            migrationBuilder.RenameColumn(
                name: "Updated",
                table: "Player",
                newName: "TimeStamp");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "Standings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "Standings");

            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "Team",
                newName: "Updated");

            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "Player",
                newName: "Updated");
        }
    }
}
