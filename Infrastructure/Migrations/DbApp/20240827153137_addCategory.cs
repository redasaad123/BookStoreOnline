using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.DbApp
{
    /// <inheritdoc />
    public partial class addCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "category",
               columnTypes: new string[] { "string", "string" },
               columns: new[] { "categoryId", "categoryName" },
               values: new object[] { Guid.NewGuid().ToString(), "Historical fiction" },
               schema: "dbo"

           );

            migrationBuilder.InsertData(
                table: "category",
                columnTypes: new string[] { "string", "string" },
                columns: new[] { "categoryId", "categoryName" },
                values: new object[] { Guid.NewGuid().ToString(), "Science fiction" },
                schema: "dbo"

                );
            migrationBuilder.InsertData(
                table: "category",
                columnTypes: new string[] { "string", "string" },
                columns: new[] { "categoryId", "categoryName" },
                values: new object[] { Guid.NewGuid().ToString(), "War" },
                schema: "dbo"

                );
            migrationBuilder.InsertData(
                table: "category",
                 columnTypes: new string[] { "string", "string" },
                columns: new[] { "categoryId", "categoryName" },
                values: new object[] { Guid.NewGuid().ToString(), "Fantasy" },
                schema: "dbo"

                );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from [dbo].[category]");

        }
    }
}
