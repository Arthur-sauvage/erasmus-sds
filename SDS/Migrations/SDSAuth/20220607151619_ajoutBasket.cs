using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SDS.Migrations.SDSAuth
{
    public partial class ajoutBasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "basketidBasket",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    idBasket = table.Column<string>(type: "TEXT", nullable: false),
                    idStudent = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.idBasket);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Speciality = table.Column<string>(type: "TEXT", nullable: true),
                    Ects = table.Column<int>(type: "INTEGER", nullable: false),
                    Likes = table.Column<int>(type: "INTEGER", nullable: false),
                    Difficulty = table.Column<int>(type: "INTEGER", nullable: true),
                    LastComment = table.Column<string>(type: "TEXT", nullable: true),
                    Quality = table.Column<int>(type: "INTEGER", nullable: true),
                    BasketidBasket = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Basket_BasketidBasket",
                        column: x => x.BasketidBasket,
                        principalTable: "Basket",
                        principalColumn: "idBasket");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<string>(type: "TEXT", nullable: false),
                    IdStudent = table.Column<string>(type: "TEXT", nullable: true),
                    IDCourse = table.Column<int>(type: "INTEGER", nullable: false),
                    CommentStudent = table.Column<string>(type: "TEXT", nullable: true),
                    QualityC = table.Column<int>(type: "INTEGER", nullable: false),
                    DifficultyC = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_basketidBasket",
                table: "AspNetUsers",
                column: "basketidBasket");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CourseId",
                table: "Comment",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_BasketidBasket",
                table: "Course",
                column: "BasketidBasket");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Basket_basketidBasket",
                table: "AspNetUsers",
                column: "basketidBasket",
                principalTable: "Basket",
                principalColumn: "idBasket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Basket_basketidBasket",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_basketidBasket",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "basketidBasket",
                table: "AspNetUsers");
        }
    }
}
