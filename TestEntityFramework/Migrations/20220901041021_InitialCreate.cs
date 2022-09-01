using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestEntityFramework.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Student",
                schema: "dbo",
                columns: table => new
                {
                    StudentGUID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentGUID);
                });

            migrationBuilder.CreateTable(
                name: "Home",
                schema: "dbo",
                columns: table => new
                {
                    HomeGUID = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    StudentGUID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Home", x => x.HomeGUID);
                    table.ForeignKey(
                        name: "FK_Home_Student_StudentGUID",
                        column: x => x.StudentGUID,
                        principalSchema: "dbo",
                        principalTable: "Student",
                        principalColumn: "StudentGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Home_StudentGUID",
                schema: "dbo",
                table: "Home",
                column: "StudentGUID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Home",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Student",
                schema: "dbo");
        }
    }
}
