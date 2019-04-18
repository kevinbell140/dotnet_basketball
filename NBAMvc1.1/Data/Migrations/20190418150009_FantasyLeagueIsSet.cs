using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAMvc1._1.Data.Migrations
{
    public partial class FantasyLeagueIsSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isFull",
                table: "FantasyLeague",
                newName: "IsFull");

            migrationBuilder.AddColumn<bool>(
                name: "IsSet",
                table: "FantasyLeague",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSet",
                table: "FantasyLeague");

            migrationBuilder.RenameColumn(
                name: "IsFull",
                table: "FantasyLeague",
                newName: "isFull");
        }
    }
}
