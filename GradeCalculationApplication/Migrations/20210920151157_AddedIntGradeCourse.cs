using Microsoft.EntityFrameworkCore.Migrations;

namespace GradeCalculationApplication.Migrations
{
    public partial class AddedIntGradeCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "StudentCourses",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Grade",
                table: "StudentCourses",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
