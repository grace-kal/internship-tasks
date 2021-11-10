using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareCompanyTicketSystem.Data.Migrations
{
    public partial class ChnangesinFileFilePicLength8000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "FilePic",
                table: "Files",
                type: "varbinary(8000)",
                maxLength: 8000,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(2147483647)",
                oldMaxLength: 2147483647);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "FilePic",
                table: "Files",
                type: "varbinary(2147483647)",
                maxLength: 2147483647,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(8000)",
                oldMaxLength: 8000);
        }
    }
}
