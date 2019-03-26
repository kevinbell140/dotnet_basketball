using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAMvc1._1.Data.Migrations
{
    public partial class PlayerPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsaTodayHeadshotUrl",
                table: "Player",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "UsaTodayHeadshotUrl",
                table: "Player");
        }
    }
}
