using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Library.Migrations
{
    public partial class Add_Model7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Checkin_out_StaffID",
                table: "Checkin_out");

            migrationBuilder.DropIndex(
                name: "IX_Checkin_out_StudentID",
                table: "Checkin_out");

            migrationBuilder.CreateIndex(
                name: "IX_Checkin_out_StaffID",
                table: "Checkin_out",
                column: "StaffID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Checkin_out_StaffID",
                table: "Checkin_out");

            migrationBuilder.CreateIndex(
                name: "IX_Checkin_out_StaffID",
                table: "Checkin_out",
                column: "StaffID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checkin_out_StudentID",
                table: "Checkin_out",
                column: "StudentID",
                unique: true);
        }
    }
}
