using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAMvc1._1.Data.Migrations
{
    public partial class FantasyMatchupWeeks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FantasyMatchupWeeksID",
                table: "FantasyMatchup",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FantasyMatchupWeeks",
                columns: table => new
                {
                    FantasyMatchupWeeksID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FantasyLeagueID = table.Column<int>(nullable: false),
                    Week1 = table.Column<DateTime>(nullable: false),
                    Week2 = table.Column<DateTime>(nullable: false),
                    Week3 = table.Column<DateTime>(nullable: false),
                    Week4 = table.Column<DateTime>(nullable: false),
                    Week5 = table.Column<DateTime>(nullable: false),
                    Week6 = table.Column<DateTime>(nullable: false),
                    Week7 = table.Column<DateTime>(nullable: false),
                    Week8 = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyMatchupWeeks", x => x.FantasyMatchupWeeksID);
                    table.ForeignKey(
                        name: "FK_FantasyMatchupWeeks_FantasyLeague_FantasyLeagueID",
                        column: x => x.FantasyLeagueID,
                        principalTable: "FantasyLeague",
                        principalColumn: "FantasyLeagueID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FantasyMatchup_FantasyMatchupWeeksID",
                table: "FantasyMatchup",
                column: "FantasyMatchupWeeksID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyMatchupWeeks_FantasyLeagueID",
                table: "FantasyMatchupWeeks",
                column: "FantasyLeagueID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyMatchup_FantasyMatchupWeeks_FantasyMatchupWeeksID",
                table: "FantasyMatchup",
                column: "FantasyMatchupWeeksID",
                principalTable: "FantasyMatchupWeeks",
                principalColumn: "FantasyMatchupWeeksID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FantasyMatchup_FantasyMatchupWeeks_FantasyMatchupWeeksID",
                table: "FantasyMatchup");

            migrationBuilder.DropTable(
                name: "FantasyMatchupWeeks");

            migrationBuilder.DropIndex(
                name: "IX_FantasyMatchup_FantasyMatchupWeeksID",
                table: "FantasyMatchup");

            migrationBuilder.DropColumn(
                name: "FantasyMatchupWeeksID",
                table: "FantasyMatchup");
        }
    }
}
