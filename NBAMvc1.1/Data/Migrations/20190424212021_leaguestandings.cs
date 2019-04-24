using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAMvc1._1.Data.Migrations
{
    public partial class leaguestandings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FantasyLeagueStandings",
                columns: table => new
                {
                    FantasyLeagueStandingsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FantasyLeagueID = table.Column<int>(nullable: false),
                    MyTeamID = table.Column<int>(nullable: true),
                    Wins = table.Column<int>(nullable: false),
                    Losses = table.Column<int>(nullable: false),
                    Draws = table.Column<int>(nullable: false),
                    FantasyPoints = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FantasyPointsAgainst = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    GamesBack = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyLeagueStandings", x => x.FantasyLeagueStandingsID);
                    table.ForeignKey(
                        name: "FK_FantasyLeagueStandings_FantasyLeague_FantasyLeagueID",
                        column: x => x.FantasyLeagueID,
                        principalTable: "FantasyLeague",
                        principalColumn: "FantasyLeagueID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FantasyLeagueStandings_MyTeam_MyTeamID",
                        column: x => x.MyTeamID,
                        principalTable: "MyTeam",
                        principalColumn: "MyTeamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FantasyLeagueStandings_FantasyLeagueID",
                table: "FantasyLeagueStandings",
                column: "FantasyLeagueID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyLeagueStandings_MyTeamID",
                table: "FantasyLeagueStandings",
                column: "MyTeamID",
                unique: true,
                filter: "[MyTeamID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FantasyLeagueStandings");
        }
    }
}
