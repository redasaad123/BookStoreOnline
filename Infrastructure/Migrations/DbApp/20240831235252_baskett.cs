using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.DbApp
{
    /// <inheritdoc />
    public partial class baskett : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

           

            migrationBuilder.DropPrimaryKey(
                name: "PK_Basket",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "basketId",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Basket",
                newName: "basket");

            migrationBuilder.AddPrimaryKey(
                name: "PK_basket",
                table: "basket",
                column: "BasketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_basket",
                table: "basket");

            migrationBuilder.RenameTable(
                name: "basket",
                newName: "Basket");

            migrationBuilder.AddColumn<string>(
                name: "basketId",
                table: "Book",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Basket",
                table: "Basket",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_basketId",
                table: "Book",
                column: "basketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Basket_basketId",
                table: "Book",
                column: "basketId",
                principalTable: "Basket",
                principalColumn: "BasketId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
