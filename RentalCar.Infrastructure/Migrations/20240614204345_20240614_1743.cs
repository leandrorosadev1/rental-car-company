using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalCar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20240614_1743 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "DailyPrice",
                table: "Rentals",
                type: "real",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "Rentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDate",
                table: "Rentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "TotalPrice",
                table: "Rentals",
                type: "real",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyPrice",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "ToDate",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Rentals");
        }
    }
}
