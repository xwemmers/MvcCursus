using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcCursus.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(maxLength: 20, nullable: false),
                    Lastname = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "DateOfBirth", "Firstname", "Lastname" },
                values: new object[] { 1, new DateTime(1994, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peter", "Teeninga" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "DateOfBirth", "Firstname", "Lastname" },
                values: new object[] { 2, new DateTime(1981, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thang", "Le" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "DateOfBirth", "Firstname", "Lastname" },
                values: new object[] { 3, new DateTime(1974, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xander", "Wemmers" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
