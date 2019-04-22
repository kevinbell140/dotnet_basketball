using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAMvc1._1.Data.Migrations
{
    public partial class FantasyLeagueIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentWeek",
                table: "FantasyLeague");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "FantasyLeague",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "FantasyLeague");

            migrationBuilder.AddColumn<int>(
                name: "CurrentWeek",
                table: "FantasyLeague",
                nullable: false,
                defaultValue: 0);
        }
    }
}
