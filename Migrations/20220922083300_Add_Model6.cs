using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Library.Migrations
{
    public partial class Add_Model6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Checkin_out_StudentID",
                table: "Checkin_out",
                column: "StudentID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkin_out_Student_StudentID",
                table: "Checkin_out",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkin_out_Student_StudentID",
                table: "Checkin_out");

            migrationBuilder.DropIndex(
                name: "IX_Checkin_out_StudentID",
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
    }
}
