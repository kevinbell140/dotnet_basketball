using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAMvc1._1.Data.Migrations
{
    public partial class DefaultValuesPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Player",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Player",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Player",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Player",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true,
                oldDefaultValue: 0);
        }
    }
}
