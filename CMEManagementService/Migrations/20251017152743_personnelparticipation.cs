using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMEManagementService.Migrations
{
    /// <inheritdoc />
    public partial class personnelparticipation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonnelParticipations",
                columns: table => new
                {
                    PersonnelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EducationCourseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    NumberOfParticipations = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelParticipations", x => new { x.PersonnelId, x.EducationCourseId });
                    table.ForeignKey(
                        name: "FK_PersonnelParticipations_EducationCourses_EducationCourseId",
                        column: x => x.EducationCourseId,
                        principalTable: "EducationCourses",
                        principalColumn: "EducationCourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonnelParticipations_Personnel_PersonnelId",
                        column: x => x.PersonnelId,
                        principalTable: "Personnel",
                        principalColumn: "PersonnelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelParticipations_EducationCourseId",
                table: "PersonnelParticipations",
                column: "EducationCourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonnelParticipations");
        }
    }
}
