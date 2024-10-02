using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.DbApp
{
    /// <inheritdoc />
    public partial class addAuther : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Author",
               columnTypes: new string[] { "string", "string" },
               columns: new[] { "AuthorId", "AuthorName" },
               values: new object[] { Guid.NewGuid().ToString(), "Jack Heffron" },
               schema: "dbo"

           );

            migrationBuilder.InsertData(
               table: "Author",
               columnTypes: new string[] { "string", "string" },
               columns: new[] { "AuthorId", "AuthorName" },
               values: new object[] { Guid.NewGuid().ToString(), "Gernot Minke" },
               schema: "dbo"

           );

            migrationBuilder.InsertData(
               table: "Author",
               columnTypes: new string[] { "string", "string" },
               columns: new[] { "AuthorId", "AuthorName" },
               values: new object[] { Guid.NewGuid().ToString(), "Lewis Turce" },
               schema: "dbo"

           );

            migrationBuilder.InsertData(
               table: "Author",
               columnTypes: new string[] { "string", "string" },
               columns: new[] { "AuthorId", "AuthorName" },
               values: new object[] { Guid.NewGuid().ToString(), "Louis L'Amour" },
               schema: "dbo"

           );

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from [dbo].[Author]");
        }
    }
}
