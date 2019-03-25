using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAMvc1._1.Data.Migrations
{
    public partial class Standings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Standings",
                columns: table => new
                {
                    TeamID = table.Column<int>(nullable: false),
                    Wins = table.Column<int>(nullable: false),
                    Losses = table.Column<int>(nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ConferenceWins = table.Column<int>(nullable: false),
                    ConferenceLosses = table.Column<int>(nullable: false),
                    DivisionWins = table.Column<int>(nullable: false),
                    DivisionLosses = table.Column<int>(nullable: false),
                    HomeWins = table.Column<int>(nullable: false),
                    HomeLosses = table.Column<int>(nullable: false),
                    AwayWins = table.Column<int>(nullable: false),
                    AwayLosses = table.Column<int>(nullable: false),
                    LastTenWins = table.Column<int>(nullable: false),
                    LastTenLosses = table.Column<int>(nullable: false),
                    Streak = table.Column<int>(nullable: false),
                    GamesBack = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standings", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Standings_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Standings");
        }
    }
}
