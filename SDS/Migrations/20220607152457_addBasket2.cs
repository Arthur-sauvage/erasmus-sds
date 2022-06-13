using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SDS.Migrations
{
    public partial class addBasket2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BasketidBasket",
                table: "Course",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Basket_BasketidBasket",
                table: "Course");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropIndex(
                name: "IX_Course_BasketidBasket",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "BasketidBasket",
                table: "Course");
        }
    }
}
