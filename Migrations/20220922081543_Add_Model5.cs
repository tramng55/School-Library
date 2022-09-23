using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Library.Migrations
{
    public partial class Add_Model5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkin_outStudent");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Checkin_out");

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

            migrationBuilder.CreateIndex(
                name: "IX_Student_Checkin_outStudentID_Checkin_outStaffID",
                table: "Student",
                columns: new[] { "Checkin_outStudentID", "Checkin_outStaffID" });

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
                name: "FK_Student_Checkin_out_Checkin_outStudentID_Checkin_outStaffID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_Checkin_outStudentID_Checkin_outStaffID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Checkin_outStaffID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Checkin_outStudentID",
                table: "Student");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Checkin_out",
                type: "nvarchar(max)",
                nullable: true);

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
                name: "IX_Checkin_outStudent_Checkin_outStudentID_Checkin_outStaffID",
                table: "Checkin_outStudent",
                columns: new[] { "Checkin_outStudentID", "Checkin_outStaffID" });
        }
    }
}
