using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMEManagementService.Migrations
{
    /// <inheritdoc />
    public partial class changedNumOFPartToBool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfParticipations",
                table: "PersonnelParticipations",
                newName: "HasCompleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HasCompleted",
                table: "PersonnelParticipations",
                newName: "NumberOfParticipations");
        }
    }
}
