using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SDS.Migrations
{
    public partial class ajoutCourseID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDCourse",
                table: "Comment",
                type: "INTEGER",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDCourse",
                table: "Comment");
        }
    }
}
