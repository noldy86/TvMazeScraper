using Microsoft.EntityFrameworkCore.Migrations;

namespace TvMazeScraper.Data.Migrations
{
    public partial class AddUniqueIdDueToInsertConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cast_Shows_ShowId",
                table: "Cast");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cast",
                table: "Cast");

            migrationBuilder.RenameTable(
                name: "Cast",
                newName: "Casts");

            migrationBuilder.RenameIndex(
                name: "IX_Cast_ShowId",
                table: "Casts",
                newName: "IX_Casts_ShowId");

            migrationBuilder.AddColumn<int>(
                name: "ShowId",
                table: "Shows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CastId",
                table: "Casts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Casts",
                table: "Casts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Casts_Shows_ShowId",
                table: "Casts",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casts_Shows_ShowId",
                table: "Casts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Casts",
                table: "Casts");

            migrationBuilder.DropColumn(
                name: "ShowId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "CastId",
                table: "Casts");

            migrationBuilder.RenameTable(
                name: "Casts",
                newName: "Cast");

            migrationBuilder.RenameIndex(
                name: "IX_Casts_ShowId",
                table: "Cast",
                newName: "IX_Cast_ShowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cast",
                table: "Cast",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cast_Shows_ShowId",
                table: "Cast",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
