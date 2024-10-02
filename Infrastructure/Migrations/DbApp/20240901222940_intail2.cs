using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.DbApp
{
    /// <inheritdoc />
    public partial class intail2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_basketbook_Book_booksId",
                table: "basketbook");

            migrationBuilder.DropForeignKey(
                name: "FK_basketbook_basket_BasketId",
                table: "basketbook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_basketbook",
                table: "basketbook");

            migrationBuilder.RenameTable(
                name: "basketbook",
                newName: "BookBasket");

            migrationBuilder.RenameIndex(
                name: "IX_basketbook_booksId",
                table: "BookBasket",
                newName: "IX_BookBasket_booksId");

            migrationBuilder.RenameIndex(
                name: "IX_basketbook_BasketId",
                table: "BookBasket",
                newName: "IX_BookBasket_BasketId");

            migrationBuilder.AlterColumn<string>(
                name: "booksId",
                table: "BookBasket",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookBasket",
                table: "BookBasket",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookBasket_Book_booksId",
                table: "BookBasket");

            migrationBuilder.DropForeignKey(
                name: "FK_BookBasket_basket_BasketId",
                table: "BookBasket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookBasket",
                table: "BookBasket");

            migrationBuilder.RenameTable(
                name: "BookBasket",
                newName: "basketbook");

            migrationBuilder.RenameIndex(
                name: "IX_BookBasket_booksId",
                table: "basketbook",
                newName: "IX_basketbook_booksId");

            migrationBuilder.RenameIndex(
                name: "IX_BookBasket_BasketId",
                table: "basketbook",
                newName: "IX_basketbook_BasketId");

            migrationBuilder.AlterColumn<string>(
                name: "booksId",
                table: "basketbook",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_basketbook",
                table: "basketbook",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_basketbook_Book_booksId",
                table: "basketbook",
                column: "booksId",
                principalTable: "Book",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_basketbook_basket_BasketId",
                table: "basketbook",
                column: "BasketId",
                principalTable: "basket",
                principalColumn: "BasketId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
