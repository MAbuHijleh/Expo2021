using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpoAdmin.Data.Migrations
{
    public partial class addbadgeprinted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BadgePrinted",
                table: "RUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BadgePrinted",
                table: "RUsers");
        }
    }
}
