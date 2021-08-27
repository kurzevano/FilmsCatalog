using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsCatalog.Migrations
{
    public partial class addeduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Film",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Film_CreateUserId",
                table: "Film",
                column: "CreateUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Film_AspNetUsers_CreateUserId",
                table: "Film",
                column: "CreateUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Film_AspNetUsers_CreateUserId",
                table: "Film");

            migrationBuilder.DropIndex(
                name: "IX_Film_CreateUserId",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Film");
        }
    }
}
