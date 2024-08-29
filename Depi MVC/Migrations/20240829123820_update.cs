using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Depi_MVC.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Degree",
                table: "Courses",
                newName: "MaxDegree");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Degree",
                table: "Courses",
                newName: "MaxDegree");
        }
    }
}
