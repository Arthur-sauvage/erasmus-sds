using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SDS.Migrations
{
    public partial class addqualitycomm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DifficultyC",
                table: "Comment",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QualityC",
                table: "Comment",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DifficultyC",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "QualityC",
                table: "Comment");
        }
    }
}
