using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Library.Migrations
{
    public partial class Add_Model12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameBook",
                table: "BorrowAssignment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameStudent",
                table: "BorrowAssignment",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameBook",
                table: "BorrowAssignment");

            migrationBuilder.DropColumn(
                name: "NameStudent",
                table: "BorrowAssignment");
        }
    }
}
