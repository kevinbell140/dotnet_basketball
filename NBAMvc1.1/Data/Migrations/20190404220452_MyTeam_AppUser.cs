using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAMvc1._1.Data.Migrations
{
    public partial class MyTeam_AppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyTeam",
                columns: table => new
                {
                    MyTeamID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyTeam", x => x.MyTeamID);
                    table.ForeignKey(
                        name: "FK_MyTeam_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerMyTeam",
                columns: table => new
                {
                    PlayerID = table.Column<int>(nullable: false),
                    MyTeamID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMyTeam", x => new { x.PlayerID, x.MyTeamID });
                    table.ForeignKey(
                        name: "FK_PlayerMyTeam_MyTeam_MyTeamID",
                        column: x => x.MyTeamID,
                        principalTable: "MyTeam",
                        principalColumn: "MyTeamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerMyTeam_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyTeam_UserID",
                table: "MyTeam",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMyTeam_MyTeamID",
                table: "PlayerMyTeam",
                column: "MyTeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerMyTeam");

            migrationBuilder.DropTable(
                name: "MyTeam");
        }
    }
}
