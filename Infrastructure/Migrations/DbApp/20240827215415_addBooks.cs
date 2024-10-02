using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.DbApp
{
    /// <inheritdoc />
    public partial class addBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Book",
                columnTypes: new string[] { "string", "string", "decimal", "string", "int", "string", "Date", "string", "string", "string" , "bit"},
                columns: new[] { "Id", "NameBook", "Price", "AuthorId", "NumberSales", "CategoryId", "Date", "Description", "PhotoUrl", "PdfUrl" , "offer"  },
                values: new object[] { Guid.NewGuid().ToString(), "THE WRITER’S idea" , 120.0 , "2fd82f19-84aa-4573-8761-7bfb4d567da3" ,
                        10 , "55964058-aef2-485c-9f4e-91f05f9436ca" , DateTime.Now,"In a field crowded with disappointing tomes, what a joy to open The Writer’s\r\nIdea Book and find vast regions of opinion and experience mined for creative\r\nfodder. As much fun to read as it is to use.\r\n",
                        "e2c11a3180736bb275526c96bebf49ee.jpg" , "pdf books/The Writer's Idea Book 10th Anniversary Edition_ How to Develop Great Ideas for Fiction, Nonfiction, Poetry, and Screenplays ( PDFDrive ).pdf",
                        true


                },
                schema: "dbo"

            );

            migrationBuilder.InsertData(
                    table: "Book",
                    columnTypes: new string[] { "string", "string", "decimal", "string", "int", "string", "Date", "string", "string", "string" , "bit" },
                    columns: new[] { "Id", "NameBook", "Price", "AuthorId", "NumberSales", "CategoryId", "Date", "Description", "PhotoUrl", "PdfUrl" , "offer" },
                    values: new object[] {
                             Guid.NewGuid().ToString(), "Building with Earth" , 150.0 , "d4502c37-ab67-4484-9278-ffd6ed74b21a" ,
                             14 , "55964058-aef2-485c-9f4e-91f05f9436ca" , DateTime.Now,"Written in response to an increasing worldwide interest in building with earth, this\r\nhandbook deals with earth as a building\r\nmaterial, and provides a survey of all of its\r\napplications and construction techniques,\r\nincluding the relevant physical data, while\r\nexplaining its specific qualities and the possibilities of optimising them. No theoretical\r\ntreatise, however, can substitute for practical\r\nexperience involving actually building with\r\nearth. The data and experiences and the\r\nspecific realisations of earth construction\r\ncontained in this volume may be used as\r\nguidelines for a variety of construction\r\nprocesses and possible applications by engineers, architects, entrepreneurs, craftsmen\r\nand public policy-makers who find themselves attempting, either from desire or\r\nnecessity, to come to terms with humanity’s\r\noldest building material. ",
                            "17ccb65a3f6364ca6221593c92a0058a.jpg" , "pdf books/Building with Earth_ Design and Technology of a Sustainable  ( PDFDrive ).pdf" 
                            , true


                    },
                    schema: "dbo"

            );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from [dbo].[Book]");

        }
    }
}
