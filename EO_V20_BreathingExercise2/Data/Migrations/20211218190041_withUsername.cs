using Microsoft.EntityFrameworkCore.Migrations;

namespace EO_V20_BreathingExercise2.Data.Migrations
{
    public partial class withUsername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Exercises");
        }
    }
}
