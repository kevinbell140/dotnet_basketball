using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAMvc1._1.Data.Migrations
{
    public partial class commissioneridinttostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CommissionerID",
                table: "FantasyLeague",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CommissionerID",
                table: "FantasyLeague",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
