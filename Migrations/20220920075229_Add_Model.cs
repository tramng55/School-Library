using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Library.Migrations
{
    public partial class Add_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Author_AuthorsAuthorID",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Book_BooksBookID",
                table: "AuthorBook");

            migrationBuilder.DropTable(
                name: "BookAssignment");

            migrationBuilder.DropTable(
                name: "StudentAssignment");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "NameStaff",
                table: "Student",
                newName: "NameStudent");

            migrationBuilder.RenameColumn(
                name: "Namebook",
                table: "Book",
                newName: "NameBook");

            migrationBuilder.RenameColumn(
                name: "BooksBookID",
                table: "AuthorBook",
                newName: "BookID");

            migrationBuilder.RenameColumn(
                name: "AuthorsAuthorID",
                table: "AuthorBook",
                newName: "AuthorID");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBook_BooksBookID",
                table: "AuthorBook",
                newName: "IX_AuthorBook_BookID");

            migrationBuilder.CreateTable(
                name: "BorrowAssignment",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    NameBook = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowAssignment", x => new { x.StudentID, x.BookID });
                    table.ForeignKey(
                        name: "FK_BorrowAssignment_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowAssignment_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowAssignment_BookID",
                table: "BorrowAssignment",
                column: "BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Author_AuthorID",
                table: "AuthorBook",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Book_BookID",
                table: "AuthorBook",
                column: "BookID",
                principalTable: "Book",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Author_AuthorID",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Book_BookID",
                table: "AuthorBook");

            migrationBuilder.DropTable(
                name: "BorrowAssignment");

            migrationBuilder.RenameColumn(
                name: "NameStudent",
                table: "Student",
                newName: "NameStaff");

            migrationBuilder.RenameColumn(
                name: "NameBook",
                table: "Book",
                newName: "Namebook");

            migrationBuilder.RenameColumn(
                name: "BookID",
                table: "AuthorBook",
                newName: "BooksBookID");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "AuthorBook",
                newName: "AuthorsAuthorID");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBook_BookID",
                table: "AuthorBook",
                newName: "IX_AuthorBook_BooksBookID");

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookAssignment",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false),
                    BookID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAssignment", x => new { x.AuthorID, x.BookID });
                    table.ForeignKey(
                        name: "FK_BookAssignment_Author_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Author",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAssignment_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssignment",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    BookID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssignment", x => new { x.StudentID, x.BookID });
                    table.ForeignKey(
                        name: "FK_StudentAssignment_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssignment_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAssignment_BookID",
                table: "BookAssignment",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignment_BookID",
                table: "StudentAssignment",
                column: "BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Author_AuthorsAuthorID",
                table: "AuthorBook",
                column: "AuthorsAuthorID",
                principalTable: "Author",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Book_BooksBookID",
                table: "AuthorBook",
                column: "BooksBookID",
                principalTable: "Book",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
