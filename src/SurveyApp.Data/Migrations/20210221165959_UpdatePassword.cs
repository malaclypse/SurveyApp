using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyApp.Data.Migrations
{
    public partial class UpdatePassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Password",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Password",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordSalt",
                table: "Password",
                type: "text",
                nullable: false,
                oldClrType: typeof(byte[]));

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Password",
                type: "text",
                nullable: false,
                oldClrType: typeof(byte[]));
        }
    }
}
