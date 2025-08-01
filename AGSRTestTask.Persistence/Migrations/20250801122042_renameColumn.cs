using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGSRTestTask.Persistence.Migrations
{
    public partial class renameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HumanName_Use",
                table: "Patients",
                newName: "Use");

            migrationBuilder.RenameColumn(
                name: "HumanName_MiddleName",
                table: "Patients",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "HumanName_LastName",
                table: "Patients",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "HumanName_FirstName",
                table: "Patients",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Use",
                table: "Patients",
                newName: "HumanName_Use");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Patients",
                newName: "HumanName_MiddleName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Patients",
                newName: "HumanName_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Patients",
                newName: "HumanName_FirstName");
        }
    }
}
