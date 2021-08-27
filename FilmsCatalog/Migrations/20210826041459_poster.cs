using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsCatalog.Migrations
{
    public partial class poster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Poster",
                table: "Film");

            migrationBuilder.AddColumn<string>(
                name: "PosterImage",
                table: "Film",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosterImage",
                table: "Film");

            migrationBuilder.AddColumn<byte[]>(
                name: "Poster",
                table: "Film",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
