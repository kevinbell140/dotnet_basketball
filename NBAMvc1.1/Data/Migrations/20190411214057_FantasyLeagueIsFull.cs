using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAMvc1._1.Data.Migrations
{
    public partial class FantasyLeagueIsFull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFull",
                table: "FantasyLeague",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFull",
                table: "FantasyLeague");
        }
    }
}
