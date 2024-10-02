using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.DbApp
{
    /// <inheritdoc />
    public partial class addAuther2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Author",
               columnTypes: new string[] { "string", "string" },
               columns: new[] { "AuthorId", "AuthorName" },
               values: new object[] { Guid.NewGuid().ToString(), "Willard Price" },
               schema: "dbo"

           );
            migrationBuilder.InsertData(
               table: "Author",
               columnTypes: new string[] { "string", "string" },
               columns: new[] { "AuthorId", "AuthorName" },
               values: new object[] { Guid.NewGuid().ToString(), "Jack London" },
               schema: "dbo"

           );

            migrationBuilder.InsertData(
               table: "Author",
               columnTypes: new string[] { "string", "string" },
               columns: new[] { "AuthorId", "AuthorName" },
               values: new object[] { Guid.NewGuid().ToString(), "Bear & Company" },
               schema: "dbo"

           );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
