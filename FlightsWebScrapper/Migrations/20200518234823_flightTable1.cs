using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightsWebScrapper.Migrations
{
    public partial class flightTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FlightCode = table.Column<string>(nullable: true),
                    RecordDate = table.Column<DateTime>(nullable: false),
                    FlightDate = table.Column<DateTime>(nullable: false),
                    FromAirportFullname = table.Column<string>(nullable: true),
                    FromAirportIATA = table.Column<string>(nullable: true),
                    ToAirportFullname = table.Column<string>(nullable: true),
                    ToAirportIATA = table.Column<string>(nullable: true),
                    AircraftModel = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    ScheduledTimeDeparture = table.Column<double>(nullable: false),
                    ActualTimeDeparture = table.Column<double>(nullable: false),
                    ScheduledTimeArrival = table.Column<double>(nullable: false),
                    ActualTimeArrival = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
