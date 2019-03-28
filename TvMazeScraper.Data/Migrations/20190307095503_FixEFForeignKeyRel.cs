using Microsoft.EntityFrameworkCore.Migrations;

namespace TvMazeScraper.Data.Migrations
{
    public partial class FixEFForeignKeyRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casts_Shows_ShowId",
                table: "Casts");

            migrationBuilder.AlterColumn<int>(
                name: "ShowId",
                table: "Casts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Casts_Shows_ShowId",
                table: "Casts",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casts_Shows_ShowId",
                table: "Casts");

            migrationBuilder.AlterColumn<int>(
                name: "ShowId",
                table: "Casts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Casts_Shows_ShowId",
                table: "Casts",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
