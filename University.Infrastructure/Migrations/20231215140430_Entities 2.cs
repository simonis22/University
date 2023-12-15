using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Entities2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "StudentCourses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentCourses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "LecturerCourses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LecturerId",
                table: "LecturerCourses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerCourses_CourseId",
                table: "LecturerCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerCourses_LecturerId",
                table: "LecturerCourses",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerCourses_Courses_CourseId",
                table: "LecturerCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerCourses_Lecturers_LecturerId",
                table: "LecturerCourses",
                column: "LecturerId",
                principalTable: "Lecturers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Students_StudentId",
                table: "StudentCourses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LecturerCourses_Courses_CourseId",
                table: "LecturerCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerCourses_Lecturers_LecturerId",
                table: "LecturerCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Students_StudentId",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_LecturerCourses_CourseId",
                table: "LecturerCourses");

            migrationBuilder.DropIndex(
                name: "IX_LecturerCourses_LecturerId",
                table: "LecturerCourses");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "LecturerCourses");

            migrationBuilder.DropColumn(
                name: "LecturerId",
                table: "LecturerCourses");
        }
    }
}
