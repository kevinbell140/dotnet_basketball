using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAMvc1._1.Data.Migrations
{
    public partial class MatchupScoresDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "HomeTeamScore",
                table: "FantasyMatchup",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AwayTeamScore",
                table: "FantasyMatchup",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HomeTeamScore",
                table: "FantasyMatchup",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AwayTeamScore",
                table: "FantasyMatchup",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);
        }
    }
}
