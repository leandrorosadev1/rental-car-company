using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalCar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20240618_1138 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarCalendar_Cars_CarId",
                table: "CarCalendar");

            migrationBuilder.DropIndex(
                name: "IX_CarCalendar_CalendarDate_CarId",
                table: "CarCalendar");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "CarCalendar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarCalendar_CalendarDate_CarId",
                table: "CarCalendar",
                columns: new[] { "CalendarDate", "CarId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarCalendar_Cars_CarId",
                table: "CarCalendar",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarCalendar_Cars_CarId",
                table: "CarCalendar");

            migrationBuilder.DropIndex(
                name: "IX_CarCalendar_CalendarDate_CarId",
                table: "CarCalendar");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "CarCalendar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_CarCalendar_CalendarDate_CarId",
                table: "CarCalendar",
                columns: new[] { "CalendarDate", "CarId" },
                unique: true,
                filter: "[CarId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CarCalendar_Cars_CarId",
                table: "CarCalendar",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }
    }
}
