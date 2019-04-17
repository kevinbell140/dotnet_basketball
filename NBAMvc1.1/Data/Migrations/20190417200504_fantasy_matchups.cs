using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAMvc1._1.Data.Migrations
{
    public partial class fantasy_matchups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FantasyMatchup",
                columns: table => new
                {
                    FantasyMatchupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FantasyLeagueID = table.Column<int>(nullable: false),
                    Week = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    HomeTeamID = table.Column<int>(nullable: true),
                    AwayTeamID = table.Column<int>(nullable: true),
                    HomeTeamScore = table.Column<int>(nullable: true),
                    AwayTeamScore = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyMatchup", x => x.FantasyMatchupID);
                    table.ForeignKey(
                        name: "FK_FantasyMatchup_MyTeam_AwayTeamID",
                        column: x => x.AwayTeamID,
                        principalTable: "MyTeam",
                        principalColumn: "MyTeamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FantasyMatchup_FantasyLeague_FantasyLeagueID",
                        column: x => x.FantasyLeagueID,
                        principalTable: "FantasyLeague",
                        principalColumn: "FantasyLeagueID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FantasyMatchup_MyTeam_HomeTeamID",
                        column: x => x.HomeTeamID,
                        principalTable: "MyTeam",
                        principalColumn: "MyTeamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FantasyMatchup_AwayTeamID",
                table: "FantasyMatchup",
                column: "AwayTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyMatchup_FantasyLeagueID",
                table: "FantasyMatchup",
                column: "FantasyLeagueID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyMatchup_HomeTeamID",
                table: "FantasyMatchup",
                column: "HomeTeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FantasyMatchup");
        }
    }
}
