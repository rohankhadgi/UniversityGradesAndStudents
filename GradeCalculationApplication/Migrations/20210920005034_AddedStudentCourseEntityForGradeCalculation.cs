using Microsoft.EntityFrameworkCore.Migrations;

namespace GradeCalculationApplication.Migrations
{
    public partial class AddedStudentCourseEntityForGradeCalculation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Students_StudentEntityStudentID",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_StudentEntityStudentID",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentEntityStudentID",
                table: "Courses");

            migrationBuilder.AddColumn<decimal>(
                name: "CGPA",
                table: "Students",
                type: "decimal",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseCredit",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    IsCalculated = table.Column<bool>(type: "bit", nullable: false),
                    HasPassed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StudentID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseID",
                table: "StudentCourses",
                column: "CourseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "CGPA",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "CourseCredit",
                table: "Courses",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StudentEntityStudentID",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentEntityStudentID",
                table: "Courses",
                column: "StudentEntityStudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Students_StudentEntityStudentID",
                table: "Courses",
                column: "StudentEntityStudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
