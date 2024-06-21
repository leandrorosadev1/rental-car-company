using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalCar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20240621_1554 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PlatformPermissions",
                columns: new[] { "Id", "CreatedDate", "CreatedUser", "Description", "ModifiedDate", "ModifiedUser", "Name" },
                values: new object[] { 105, new DateTime(2024, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), null, "Return rental", new DateTime(2024, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), null, "RENTAL_RETURN" });

            migrationBuilder.Sql(@"Insert Into PlatformPermissionPlatformRole values (105, 100)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlatformPermissions",
                keyColumn: "Id",
                keyValue: 105);
        }
    }
}
