using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Library.Migrations
{
    public partial class list : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameBook",
                table: "BorrowAssignment");

            migrationBuilder.DropColumn(
                name: "NameStudent",
                table: "BorrowAssignment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
