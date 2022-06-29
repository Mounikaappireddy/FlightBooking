using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightAdminservices.Migrations
{
    public partial class deletingunwantedcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassOfSeats",
                table: "FlightDetail");

            migrationBuilder.DropColumn(
                name: "IsInstrumentUsed",
                table: "FlightDetail");

            migrationBuilder.DropColumn(
                name: "TotalSeat",
                table: "FlightDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassOfSeats",
                table: "FlightDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsInstrumentUsed",
                table: "FlightDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalSeat",
                table: "FlightDetail",
                type: "int",
                nullable: true);
        }
    }
}
