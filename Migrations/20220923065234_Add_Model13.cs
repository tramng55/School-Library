using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Library.Migrations
{
    public partial class Add_Model13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Checkin_outID",
                table: "Checkin_out",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BorrowAssignmentID",
                table: "BorrowAssignment",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Checkin_outID",
                table: "Checkin_out");

            migrationBuilder.DropColumn(
                name: "BorrowAssignmentID",
                table: "BorrowAssignment");
        }
    }
}
