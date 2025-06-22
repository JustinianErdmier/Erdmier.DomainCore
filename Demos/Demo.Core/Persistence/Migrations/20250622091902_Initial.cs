using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(name: "Books",
                                         columns: table => new
                                         {
                                             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                                             Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_Books", x => x.Id);
                                         });

            migrationBuilder.CreateTable(name: "BookAuthors",
                                         columns: table => new
                                         {
                                             BookAuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                                             BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                                             Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_BookAuthors", x => new { x.BookAuthorId, x.BookId });
                                             table.ForeignKey(
                                                              name: "FK_BookAuthors_Books_BookId",
                                                              column: x => x.BookId,
                                                              principalTable: "Books",
                                                              principalColumn: "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            migrationBuilder.CreateIndex(name: "IX_BookAuthors_BookId",
                                         table: "BookAuthors",
                                         column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "BookAuthors");

            migrationBuilder.DropTable(name: "Books");
        }
    }
}
