using Microsoft.EntityFrameworkCore.Migrations;

namespace GradeCalculationApplication.Migrations
{
    public partial class UpdatedHasPassedEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasPassed",
                table: "StudentCourses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasPassed",
                table: "StudentCourses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
