using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalCar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20240618_1104 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HoldByCustomerUserId",
                table: "CarCalendar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HoldUpToDate",
                table: "CarCalendar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CarCalendar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "CarCalendar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarCalendar_HoldByCustomerUserId",
                table: "CarCalendar",
                column: "HoldByCustomerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarCalendar_CustomerUsers_HoldByCustomerUserId",
                table: "CarCalendar",
                column: "HoldByCustomerUserId",
                principalTable: "CustomerUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarCalendar_CustomerUsers_HoldByCustomerUserId",
                table: "CarCalendar");

            migrationBuilder.DropIndex(
                name: "IX_CarCalendar_HoldByCustomerUserId",
                table: "CarCalendar");

            migrationBuilder.DropColumn(
                name: "HoldByCustomerUserId",
                table: "CarCalendar");

            migrationBuilder.DropColumn(
                name: "HoldUpToDate",
                table: "CarCalendar");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CarCalendar");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "CarCalendar");
        }
    }
}
