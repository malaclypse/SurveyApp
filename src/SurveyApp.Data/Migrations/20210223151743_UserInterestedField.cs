using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyApp.Data.Migrations
{
    public partial class UserInterestedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInterestedInMoreInfo",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInterestedInMoreInfo",
                table: "User");
        }
    }
}
