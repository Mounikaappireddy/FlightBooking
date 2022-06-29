using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightAdminservices.Migrations
{
    public partial class changingcolumnname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "FlightDetail",
                newName: "ReturnDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReturnDate",
                table: "FlightDetail",
                newName: "EndDate");
        }
    }
}
