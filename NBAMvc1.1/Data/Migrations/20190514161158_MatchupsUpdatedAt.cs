using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAMvc1._1.Data.Migrations
{
    public partial class MatchupsUpdatedAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "FantasyMatchup",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "FantasyMatchup");
        }
    }
}
