using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAMvc1._1.Data.Migrations
{
    public partial class WeeksModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FantasyMatchupWeeks_FantasyLeagueID",
                table: "FantasyMatchupWeeks");

            migrationBuilder.DropColumn(
                name: "Week1",
                table: "FantasyMatchupWeeks");

            migrationBuilder.DropColumn(
                name: "Week2",
                table: "FantasyMatchupWeeks");

            migrationBuilder.DropColumn(
                name: "Week3",
                table: "FantasyMatchupWeeks");

            migrationBuilder.DropColumn(
                name: "Week4",
                table: "FantasyMatchupWeeks");

            migrationBuilder.DropColumn(
                name: "Week5",
                table: "FantasyMatchupWeeks");

            migrationBuilder.DropColumn(
                name: "Week6",
                table: "FantasyMatchupWeeks");

            migrationBuilder.DropColumn(
                name: "Week7",
                table: "FantasyMatchupWeeks");

            migrationBuilder.RenameColumn(
                name: "Week8",
                table: "FantasyMatchupWeeks",
                newName: "Date");

            migrationBuilder.AddColumn<int>(
                name: "WeekNum",
                table: "FantasyMatchupWeeks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FantasyMatchupWeeks_FantasyLeagueID",
                table: "FantasyMatchupWeeks",
                column: "FantasyLeagueID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FantasyMatchupWeeks_FantasyLeagueID",
                table: "FantasyMatchupWeeks");

            migrationBuilder.DropColumn(
                name: "WeekNum",
                table: "FantasyMatchupWeeks");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "FantasyMatchupWeeks",
                newName: "Week8");

            migrationBuilder.AddColumn<DateTime>(
                name: "Week1",
                table: "FantasyMatchupWeeks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Week2",
                table: "FantasyMatchupWeeks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Week3",
                table: "FantasyMatchupWeeks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Week4",
                table: "FantasyMatchupWeeks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Week5",
                table: "FantasyMatchupWeeks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Week6",
                table: "FantasyMatchupWeeks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Week7",
                table: "FantasyMatchupWeeks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_FantasyMatchupWeeks_FantasyLeagueID",
                table: "FantasyMatchupWeeks",
                column: "FantasyLeagueID",
                unique: true);
        }
    }
}
