using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsCatalog.Migrations
{
    public partial class addeduserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Film_AspNetUsers_CreateUserId",
                table: "Film");

            migrationBuilder.RenameColumn(
                name: "CreateUserId",
                table: "Film",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Film_CreateUserId",
                table: "Film",
                newName: "IX_Film_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Film_AspNetUsers_UserId",
                table: "Film",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Film_AspNetUsers_UserId",
                table: "Film");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Film",
                newName: "CreateUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Film_UserId",
                table: "Film",
                newName: "IX_Film_CreateUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Film_AspNetUsers_CreateUserId",
                table: "Film",
                column: "CreateUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
