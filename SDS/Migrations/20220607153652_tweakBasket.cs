using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SDS.Migrations
{
    public partial class tweakBasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Basket_BasketidBasket",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_BasketidBasket",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "BasketidBasket",
                table: "Course");

            migrationBuilder.CreateTable(
                name: "basket_course",
                columns: table => new
                {
                    idBasket = table.Column<string>(type: "TEXT", nullable: false),
                    idCourse = table.Column<string>(type: "TEXT", nullable: false),
                    idTransaction = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.idTransaction);
                }
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Basket_idBasket",
                table: "basket_course",
                column: "idBasket",
                principalTable: "Basket",
                principalColumn: "idBasket");
            migrationBuilder.AddForeignKey(
                name: "FK_Course_Basket_idCourse",
                table: "basket_course",
                column: "idCourse",
                principalTable: "Course",
                principalColumn: "Id");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BasketidBasket",
                table: "Course",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_BasketidBasket",
                table: "Course",
                column: "BasketidBasket");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Basket_BasketidBasket",
                table: "Course",
                column: "BasketidBasket",
                principalTable: "Basket",
                principalColumn: "idBasket");
        }
    }
}
