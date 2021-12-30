using Microsoft.EntityFrameworkCore.Migrations;

namespace TicTacToe.Repository.Migrations
{
    public partial class MoveAddAndChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_VictorId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_VictorId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "VictorId",
                table: "Games",
                newName: "Victor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Victor",
                table: "Games",
                newName: "VictorId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_VictorId",
                table: "Games",
                column: "VictorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_VictorId",
                table: "Games",
                column: "VictorId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
