using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.DbApp
{
    /// <inheritdoc />
    public partial class AddTableBookMark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            

            migrationBuilder.AddColumn<bool>(
                name: "isSelected",
                table: "Book",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "bookMark",
                columns: table => new
                {
                    BookMarkId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookMark", x => x.BookMarkId);
                });

            migrationBuilder.CreateTable(
                name: "bookMarkBook",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookMarkId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookMarkBook", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookMark");

            migrationBuilder.DropTable(
                name: "bookMarkBook");

            migrationBuilder.DropColumn(
                name: "isSelected",
                table: "Book");

            migrationBuilder.AlterColumn<string>(
                name: "BasketId",
                table: "BookBasket",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "booksId",
                table: "BookBasket",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BookBasket_BasketId",
                table: "BookBasket",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBasket_booksId",
                table: "BookBasket",
                column: "booksId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookBasket_Book_booksId",
                table: "BookBasket",
                column: "booksId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookBasket_basket_BasketId",
                table: "BookBasket",
                column: "BasketId",
                principalTable: "basket",
                principalColumn: "BasketId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
