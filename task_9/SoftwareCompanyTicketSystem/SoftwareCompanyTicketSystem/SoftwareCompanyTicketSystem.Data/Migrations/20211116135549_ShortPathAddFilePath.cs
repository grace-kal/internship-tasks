using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareCompanyTicketSystem.Data.Migrations
{
    public partial class ShortPathAddFilePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortPath",
                table: "FilePaths",
                type: "varchar",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortPath",
                table: "FilePaths");
        }
    }
}
