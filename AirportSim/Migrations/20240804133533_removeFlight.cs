using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportSim.Migrations
{
    /// <inheritdoc />
    public partial class removeFlight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Flight_FlightId",
                table: "Logs");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Logs_FlightId",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "FlightId",
                table: "Logs",
                newName: "FlightStatus");

            migrationBuilder.AddColumn<Guid>(
                name: "FlightNumber",
                table: "Logs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightNumber",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "FlightStatus",
                table: "Logs",
                newName: "FlightId");

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_FlightId",
                table: "Logs",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Flight_FlightId",
                table: "Logs",
                column: "FlightId",
                principalTable: "Flight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
