using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsCoursesManager.Migrations
{
    /// <inheritdoc />
    public partial class Fourteen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourse_StudentId",
                table: "StudentCourse");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StudentCourse",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse",
                columns: new[] { "StudentId", "CourseId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StudentCourse",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_StudentId",
                table: "StudentCourse",
                column: "StudentId");
        }
    }
}
