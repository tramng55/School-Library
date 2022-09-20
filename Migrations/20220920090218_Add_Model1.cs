using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Library.Migrations
{
    public partial class Add_Model1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "BookCategory");

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

            migrationBuilder.CreateTable(
                name: "BookProducer",
                columns: table => new
                {
                    BooksBookID = table.Column<int>(type: "int", nullable: false),
                    ProducersProducerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookProducer", x => new { x.BooksBookID, x.ProducersProducerID });
                    table.ForeignKey(
                        name: "FK_BookProducer_Book_BooksBookID",
                        column: x => x.BooksBookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookProducer_Producer_ProducersProducerID",
                        column: x => x.ProducersProducerID,
                        principalTable: "Producer",
                        principalColumn: "ProducerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Checkin_outStudent",
                columns: table => new
                {
                    StudentsStudentID = table.Column<int>(type: "int", nullable: false),
                    Checkin_outStudentID = table.Column<int>(type: "int", nullable: false),
                    Checkin_outStaffID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkin_outStudent", x => new { x.StudentsStudentID, x.Checkin_outStudentID, x.Checkin_outStaffID });
                    table.ForeignKey(
                        name: "FK_Checkin_outStudent_Checkin_out_Checkin_outStudentID_Checkin_outStaffID",
                        columns: x => new { x.Checkin_outStudentID, x.Checkin_outStaffID },
                        principalTable: "Checkin_out",
                        principalColumns: new[] { "StudentID", "StaffID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checkin_outStudent_Student_StudentsStudentID",
                        column: x => x.StudentsStudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkin_out_StaffID",
                table: "Checkin_out",
                column: "StaffID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryID",
                table: "Book",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_BookProducer_ProducersProducerID",
                table: "BookProducer",
                column: "ProducersProducerID");

            migrationBuilder.CreateIndex(
                name: "IX_Checkin_outStudent_Checkin_outStudentID_Checkin_outStaffID",
                table: "Checkin_outStudent",
                columns: new[] { "Checkin_outStudentID", "Checkin_outStaffID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Category_CategoryID",
                table: "Book",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkin_out_Staff_StaffID",
                table: "Checkin_out",
                column: "StaffID",
                principalTable: "Staff",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_CategoryID",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkin_out_Staff_StaffID",
                table: "Checkin_out");

            migrationBuilder.DropTable(
                name: "BookProducer");

            migrationBuilder.DropTable(
                name: "Checkin_outStudent");

            migrationBuilder.DropIndex(
                name: "IX_Checkin_out_StaffID",
                table: "Checkin_out");

            migrationBuilder.DropIndex(
                name: "IX_Book_CategoryID",
                table: "Book");

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
                name: "IX_BookCategory_CategorysCategoryID",
                table: "BookCategory",
                column: "CategorysCategoryID");

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
    }
}
