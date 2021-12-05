using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagementSystem.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "SuperAdmin");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "SuperAdmin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "SuperAdmin");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "SuperAdmin",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
