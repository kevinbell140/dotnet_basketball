using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAMvc1._1.Data.Migrations
{
    public partial class Games : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameID = table.Column<int>(nullable: false),
                    Season = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    HomeTeamID = table.Column<int>(nullable: true),
                    AwayTeamID = table.Column<int>(nullable: true),
                    HomeTeamScore = table.Column<int>(nullable: false),
                    AwayTeamScore = table.Column<int>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    PointSpread = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    OverUnder = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    AwayTeamMoneyLine = table.Column<int>(nullable: false),
                    HomeTeamMoneyLine = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameID);
                    table.ForeignKey(
                        name: "FK_Game_Team_AwayTeamID",
                        column: x => x.AwayTeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Team_HomeTeamID",
                        column: x => x.HomeTeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_AwayTeamID",
                table: "Game",
                column: "AwayTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Game_HomeTeamID",
                table: "Game",
                column: "HomeTeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
