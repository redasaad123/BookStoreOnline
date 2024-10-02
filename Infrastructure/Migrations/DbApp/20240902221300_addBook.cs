using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.DbApp
{
    /// <inheritdoc />
    public partial class addBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Book",
                columnTypes: new string[] { "string", "string", "decimal", "string", "int", "string", "Date", "string", "string", "string", "bit" },
                columns: new[] { "Id", "NameBook", "Price", "AuthorId", "NumberSales", "CategoryId", "Date", "Description", "PhotoUrl", "PdfUrl", "offer" },
                values: new object[] { Guid.NewGuid().ToString(), "Cannibal adventure" , 360.0 , "f96c17f8-a589-4c90-89f2-5cc5dc740a48" ,
                        15 , "0a517e6f-6776-45e8-93e6-96527ac8f079" , DateTime.Now,"First American Edition, 1973 Text © 1972 by Willard Price\r\nIllustrations © 1972 by Jonathan Cape Ltd. All rights reserved. No part of this book may be reprinted, or reproduced or utilized in any form or by any electronic, mechanicalor other means, now known or hereafter invented, including photocopying and recording, or in any information storage and retrieval system, without permission in writing from the Publisher. The John Day Company, 257 Park Avenue South,\r\nNew York, N.Y. 10010\r\nPublished on the same day in Canada by Longman Canada Limited.Library of Congress Cataloging in Publication Data\r\nPrice, Willard, 1887- Cannibal adventure. SUMMARY: Dangerous adventure awaits two boys\r\nsearching in New Guinea for rare animals for their family's animal farm.\r\n[1. New Guinea—Fiction. 2. Adventure stories | I. Marriott, Pat, 1920- illus. II. Title. PZ7.P9318Can3 [Fie] 78-179785 ISBN 0-381-99640-9\r\nPrinted in the United States of America",
                        "7f77fc6c-c073-47e1-ace7-a4ad3263ff40.webp" , "Cannibal Adventure.pdf",
                        true
                },
                schema: "dbo"

            );

            migrationBuilder.InsertData(
                table: "Book",
                columnTypes: new string[] { "string", "string", "decimal", "string", "int", "string", "Date", "string", "string", "string", "bit" },
                columns: new[] { "Id", "NameBook", "Price", "AuthorId", "NumberSales", "CategoryId", "Date", "Description", "PhotoUrl", "PdfUrl", "offer" },
                values: new object[] { Guid.NewGuid().ToString(), "The Call of the Wild, White Fang and Other Stories" , 340.0 , "3e8620b9-96bd-44cb-b657-261109a2834a" ,
                        15 , "0a517e6f-6776-45e8-93e6-96527ac8f079" , DateTime.Now,"The Call of the Wild, London’s masterpiece about a dog learning to survive in\r\nthe wilderness, sees pampered pet Buck snatched from his home and set to\r\nwork as a sled-dog. White Fang, set in the frozen tundra and boreal forests of\r\nCanada’s Yukon territory, is the story of a wolf-dog struggling to survive in a\r\nhuman society every bit as violent as the natural world. This volume of Jack\r\nLondon’s famed stories of the North also includes ‘Batard’, in which an abused\r\ndog takes revenge on his owner; and ‘Love of Life’, in which an injured\r\nprospector, abandoned by his partner, must struggle home alone through the\r\nwilderness, stalked by a lone wolf.\r\n",
                        "6ae0f3a5d1b983176469399b32daf83a.jpg" , "The Call of the Wild, White Fan - Jack London.pdf ( PDFDrive ).pdf",
                        false
                },
                schema: "dbo"

            );


            migrationBuilder.InsertData(
                table: "Book",
                columnTypes: new string[] { "string", "string", "decimal", "string", "int", "string", "Date", "string", "string", "string", "bit" },
                columns: new[] { "Id", "NameBook", "Price", "AuthorId", "NumberSales", "CategoryId", "Date", "Description", "PhotoUrl", "PdfUrl", "offer" },
                values: new object[] { Guid.NewGuid().ToString(), "Before Atlantis" , 290.0 , "de7dc879-3b77-4646-a6ff-02d19ea0b194" ,
                        17 , "0a517e6f-6776-45e8-93e6-96527ac8f079" , DateTime.Now,"“A comprehensive exploration of Earth’s ancient past, the\r\nevolution of humanity, the rise of civilization, and the effects of global\r\ncatastrophe”—Provided by publisher",
                        "3981e145f058c6c6f1e5bf8073ce287d.jpg" , "Before Atlantis_ 20 Million Years of Human and Pre-Human Cultures ( PDFDrive ).pdf",
                        true
                },
                schema: "dbo"

            );


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
