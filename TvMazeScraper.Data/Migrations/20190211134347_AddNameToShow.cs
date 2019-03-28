using Microsoft.EntityFrameworkCore.Migrations;

namespace TvMazeScraper.Data.Migrations
{
    public partial class AddNameToShow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Shows",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Shows");
        }
    }
}
