using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareCompanyTicketSystem.Data.Migrations
{
    public partial class ShortPathLengthChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShortPath",
                table: "FilePaths",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShortPath",
                table: "FilePaths",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true);
        }
    }
}
