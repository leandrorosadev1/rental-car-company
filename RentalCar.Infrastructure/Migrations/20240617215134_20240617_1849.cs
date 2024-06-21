using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalCar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20240617_1849 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cars_NumberPlate",
                table: "Cars",
                column: "NumberPlate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarCalendar_CalendarDate_CarId",
                table: "CarCalendar",
                columns: new[] { "CalendarDate", "CarId" },
                unique: true,
                filter: "[CarId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cars_NumberPlate",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_CarCalendar_CalendarDate_CarId",
                table: "CarCalendar");
        }
    }
}
