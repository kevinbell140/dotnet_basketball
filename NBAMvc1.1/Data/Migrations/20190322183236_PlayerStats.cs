using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAMvc1._1.Data.Migrations
{
    public partial class PlayerStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerSeasonStats",
                columns: table => new
                {
                    StatID = table.Column<int>(nullable: false),
                    PlayerID = table.Column<int>(nullable: false),
                    Games = table.Column<int>(nullable: false),
                    FieldGoalsPercentage = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FreeThrowsPercentage = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ThreePointersMade = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Points = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Assists = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Rebounds = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Steals = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    BlockedShots = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Turnovers = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSeasonStats", x => x.StatID);
                    table.ForeignKey(
                        name: "FK_PlayerSeasonStats_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasonStats_PlayerID",
                table: "PlayerSeasonStats",
                column: "PlayerID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerSeasonStats");
        }
    }
}
