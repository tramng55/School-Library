using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Library.Migrations
{
    public partial class Add_Model11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NamStaff",
                table: "Checkin_out",
                newName: "NameStaff");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameStaff",
                table: "Checkin_out",
                newName: "NamStaff");
        }
    }
}
