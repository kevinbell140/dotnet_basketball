using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAMvc1._1.Data.Migrations
{
    public partial class FantasyLeagues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FantasyLeagueID",
                table: "MyTeam",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FantasyLeague",
                columns: table => new
                {
                    FantasyLeagueID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommissionerID = table.Column<int>(nullable: false),
                    ComissionerNavId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyLeague", x => x.FantasyLeagueID);
                    table.ForeignKey(
                        name: "FK_FantasyLeague_AspNetUsers_ComissionerNavId",
                        column: x => x.ComissionerNavId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyTeam_FantasyLeagueID",
                table: "MyTeam",
                column: "FantasyLeagueID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyLeague_ComissionerNavId",
                table: "FantasyLeague",
                column: "ComissionerNavId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyTeam_FantasyLeague_FantasyLeagueID",
                table: "MyTeam",
                column: "FantasyLeagueID",
                principalTable: "FantasyLeague",
                principalColumn: "FantasyLeagueID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyTeam_FantasyLeague_FantasyLeagueID",
                table: "MyTeam");

            migrationBuilder.DropTable(
                name: "FantasyLeague");

            migrationBuilder.DropIndex(
                name: "IX_MyTeam_FantasyLeagueID",
                table: "MyTeam");

            migrationBuilder.DropColumn(
                name: "FantasyLeagueID",
                table: "MyTeam");
        }
    }
}
