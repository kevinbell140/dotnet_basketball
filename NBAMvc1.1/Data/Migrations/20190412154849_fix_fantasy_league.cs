using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAMvc1._1.Data.Migrations
{
    public partial class fix_fantasy_league : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FantasyLeague_AspNetUsers_ComissionerNavId",
                table: "FantasyLeague");

            migrationBuilder.DropIndex(
                name: "IX_FantasyLeague_ComissionerNavId",
                table: "FantasyLeague");

            migrationBuilder.DropColumn(
                name: "ComissionerNavId",
                table: "FantasyLeague");

            migrationBuilder.AlterColumn<string>(
                name: "CommissionerID",
                table: "FantasyLeague",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FantasyLeague_CommissionerID",
                table: "FantasyLeague",
                column: "CommissionerID");

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyLeague_AspNetUsers_CommissionerID",
                table: "FantasyLeague",
                column: "CommissionerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FantasyLeague_AspNetUsers_CommissionerID",
                table: "FantasyLeague");

            migrationBuilder.DropIndex(
                name: "IX_FantasyLeague_CommissionerID",
                table: "FantasyLeague");

            migrationBuilder.AlterColumn<string>(
                name: "CommissionerID",
                table: "FantasyLeague",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComissionerNavId",
                table: "FantasyLeague",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FantasyLeague_ComissionerNavId",
                table: "FantasyLeague",
                column: "ComissionerNavId");

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyLeague_AspNetUsers_ComissionerNavId",
                table: "FantasyLeague",
                column: "ComissionerNavId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
