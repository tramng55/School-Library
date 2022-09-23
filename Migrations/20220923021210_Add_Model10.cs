using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Library.Migrations
{
    public partial class Add_Model10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NamStaff",
                table: "Checkin_out",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameStudent",
                table: "Checkin_out",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NamStaff",
                table: "Checkin_out");

            migrationBuilder.DropColumn(
                name: "NameStudent",
                table: "Checkin_out");
        }
    }
}
