using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.DbApp
{
    /// <inheritdoc />
    public partial class userContact1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserContact_AppUsers_userId",
                table: "UserContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserContact",
                table: "UserContact");

            migrationBuilder.RenameTable(
                name: "UserContact",
                newName: "MessageUsers");

            migrationBuilder.RenameIndex(
                name: "IX_UserContact_userId",
                table: "MessageUsers",
                newName: "IX_MessageUsers_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageUsers",
                table: "MessageUsers",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageUsers_AppUsers_userId",
                table: "MessageUsers",
                column: "userId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageUsers_AppUsers_userId",
                table: "MessageUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageUsers",
                table: "MessageUsers");

            migrationBuilder.RenameTable(
                name: "MessageUsers",
                newName: "UserContact");

            migrationBuilder.RenameIndex(
                name: "IX_MessageUsers_userId",
                table: "UserContact",
                newName: "IX_UserContact_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserContact",
                table: "UserContact",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserContact_AppUsers_userId",
                table: "UserContact",
                column: "userId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
