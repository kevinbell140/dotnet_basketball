using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAMvc1._1.Data.Migrations
{
    public partial class PlayerGameStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerGameStats",
                columns: table => new
                {
                    StatID = table.Column<int>(nullable: false),
                    PlayerID = table.Column<int>(nullable: false),
                    GameID = table.Column<int>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Minutes = table.Column<int>(nullable: false),
                    FieldGoalsMade = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FieldGoalsAttempted = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FieldGoalsPercentage = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ThreePointersMade = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ThreePointersAttempted = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ThreePointersPercentage = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FreeThrowsMade = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FreeThrowsAttempted = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FreeThrowsPercentage = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    OffensiveRebounds = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DefensiveRebounds = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Rebounds = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Assists = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Steals = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    BlockedShots = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Turnovers = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PersonalFouls = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Points = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PlusMinus = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGameStats", x => x.StatID);
                    table.ForeignKey(
                        name: "FK_PlayerGameStats_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGameStats_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameStats_GameID",
                table: "PlayerGameStats",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameStats_PlayerID",
                table: "PlayerGameStats",
                column: "PlayerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerGameStats");
        }
    }
}
