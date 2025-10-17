using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMEManagementService.Migrations
{
    /// <inheritdoc />
    public partial class coursecontroller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditHours",
                table: "EducationCourses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "EducationCourses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "EducationCourses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "EducationCourses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "EducationCourses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditHours",
                table: "EducationCourses");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "EducationCourses");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "EducationCourses");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "EducationCourses");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "EducationCourses");
        }
    }
}
