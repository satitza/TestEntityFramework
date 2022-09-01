using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestEntityFramework.Migrations
{
    public partial class AddTeacherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teacher",
                schema: "dbo",
                columns: table => new
                {
                    TeacherGUID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.TeacherGUID);
                });

            migrationBuilder.CreateTable(
                name: "StudentTeacher",
                schema: "dbo",
                columns: table => new
                {
                    StudentGUID = table.Column<Guid>(nullable: false),
                    TeacherGUID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTeacher", x => new { x.StudentGUID, x.TeacherGUID });
                    table.ForeignKey(
                        name: "FK_StudentTeacher_Student_StudentGUID",
                        column: x => x.StudentGUID,
                        principalSchema: "dbo",
                        principalTable: "Student",
                        principalColumn: "StudentGUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTeacher_Teacher_TeacherGUID",
                        column: x => x.TeacherGUID,
                        principalSchema: "dbo",
                        principalTable: "Teacher",
                        principalColumn: "TeacherGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentTeacher_TeacherGUID",
                schema: "dbo",
                table: "StudentTeacher",
                column: "TeacherGUID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentTeacher",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Teacher",
                schema: "dbo");
        }
    }
}
