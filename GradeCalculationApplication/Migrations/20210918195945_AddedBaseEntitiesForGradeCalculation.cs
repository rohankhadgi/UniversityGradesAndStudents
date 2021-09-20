using Microsoft.EntityFrameworkCore.Migrations;

namespace GradeCalculationApplication.Migrations
{
    public partial class AddedBaseEntitiesForGradeCalculation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    StudentNumber = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CourseCode = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CourseCredit = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    StudentEntityStudentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Courses_Students_StudentEntityStudentID",
                        column: x => x.StudentEntityStudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentEntityStudentID",
                table: "Courses",
                column: "StudentEntityStudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
