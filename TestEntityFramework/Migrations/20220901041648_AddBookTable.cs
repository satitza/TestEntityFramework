using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestEntityFramework.Migrations
{
    public partial class AddBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                schema: "dbo",
                columns: table => new
                {
                    BookGUID = table.Column<Guid>(nullable: false),
                    BookName = table.Column<string>(nullable: true),
                    BookCode = table.Column<int>(nullable: false),
                    StudentGUID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookGUID);
                    table.ForeignKey(
                        name: "FK_Book_Student_BookGUID",
                        column: x => x.BookGUID,
                        principalSchema: "dbo",
                        principalTable: "Student",
                        principalColumn: "StudentGUID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book",
                schema: "dbo");
        }
    }
}
