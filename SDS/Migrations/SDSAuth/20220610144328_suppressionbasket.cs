using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SDS.Migrations.SDSAuth
{
    public partial class suppressionbasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Basket_basketidBasket",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_basketidBasket",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "basketidBasket",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    BasketidBasket = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Difficulty = table.Column<int>(type: "INTEGER", nullable: true),
                    Ects = table.Column<int>(type: "INTEGER", nullable: false),
                    LastComment = table.Column<string>(type: "TEXT", nullable: true),
                    Likes = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Quality = table.Column<int>(type: "INTEGER", nullable: true),
                    Speciality = table.Column<string>(type: "TEXT", nullable: true)
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
                    CommentStudent = table.Column<string>(type: "TEXT", nullable: true),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: true),
                    DifficultyC = table.Column<int>(type: "INTEGER", nullable: false),
                    IDCourse = table.Column<int>(type: "INTEGER", nullable: false),
                    IdStudent = table.Column<string>(type: "TEXT", nullable: true),
                    QualityC = table.Column<int>(type: "INTEGER", nullable: false)
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
    }
}
