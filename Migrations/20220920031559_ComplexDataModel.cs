using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Library.Migrations
{
    public partial class ComplexDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Checkin_outStaffID",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Checkin_outStudentID",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Checkin_outStaffID",
                table: "Staff",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Checkin_outStudentID",
                table: "Staff",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsAuthorID = table.Column<int>(type: "int", nullable: false),
                    BooksBookID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsAuthorID, x.BooksBookID });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Author_AuthorsAuthorID",
                        column: x => x.AuthorsAuthorID,
                        principalTable: "Author",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Book_BooksBookID",
                        column: x => x.BooksBookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "BookCategory",
                columns: table => new
                {
                    BooksBookID = table.Column<int>(type: "int", nullable: false),
                    CategorysCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => new { x.BooksBookID, x.CategorysCategoryID });
                    table.ForeignKey(
                        name: "FK_BookCategory_Book_BooksBookID",
                        column: x => x.BooksBookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategory_Category_CategorysCategoryID",
                        column: x => x.CategorysCategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Checkin_out",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkin_out", x => new { x.StudentID, x.StaffID });
                });

            migrationBuilder.CreateTable(
                name: "StudentAssignment",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Student_Checkin_outStudentID_Checkin_outStaffID",
                table: "Student",
                columns: new[] { "Checkin_outStudentID", "Checkin_outStaffID" });

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Checkin_outStudentID_Checkin_outStaffID",
                table: "Staff",
                columns: new[] { "Checkin_outStudentID", "Checkin_outStaffID" });

            migrationBuilder.CreateIndex(
                name: "IX_Book_ProducerID",
                table: "Book",
                column: "ProducerID");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksBookID",
                table: "AuthorBook",
                column: "BooksBookID");

            migrationBuilder.CreateIndex(
                name: "IX_BookAssignment_BookID",
                table: "BookAssignment",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_CategorysCategoryID",
                table: "BookCategory",
                column: "CategorysCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignment_BookID",
                table: "StudentAssignment",
                column: "BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Producer_ProducerID",
                table: "Book",
                column: "ProducerID",
                principalTable: "Producer",
                principalColumn: "ProducerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Checkin_out_Checkin_outStudentID_Checkin_outStaffID",
                table: "Staff",
                columns: new[] { "Checkin_outStudentID", "Checkin_outStaffID" },
                principalTable: "Checkin_out",
                principalColumns: new[] { "StudentID", "StaffID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Checkin_out_Checkin_outStudentID_Checkin_outStaffID",
                table: "Student",
                columns: new[] { "Checkin_outStudentID", "Checkin_outStaffID" },
                principalTable: "Checkin_out",
                principalColumns: new[] { "StudentID", "StaffID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Producer_ProducerID",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Checkin_out_Checkin_outStudentID_Checkin_outStaffID",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Checkin_out_Checkin_outStudentID_Checkin_outStaffID",
                table: "Student");

            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "BookAssignment");

            migrationBuilder.DropTable(
                name: "BookCategory");

            migrationBuilder.DropTable(
                name: "Checkin_out");

            migrationBuilder.DropTable(
                name: "StudentAssignment");

            migrationBuilder.DropIndex(
                name: "IX_Student_Checkin_outStudentID_Checkin_outStaffID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Staff_Checkin_outStudentID_Checkin_outStaffID",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Book_ProducerID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Checkin_outStaffID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Checkin_outStudentID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Checkin_outStaffID",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Checkin_outStudentID",
                table: "Staff");
        }
    }
}
