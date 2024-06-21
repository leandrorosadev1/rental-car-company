using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentalCar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20240619_1459 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "CarBrands",
            columns: new[] { "Id", "CreatedDate", "CreatedUser", "ModifiedDate", "ModifiedUser", "Name" },
            values: new object[,]
            {
                { 100, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "Chevrolet" },
                { 101, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "Ford" },
                { 102, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "Volkswagen" },
                { 103, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "Renault" },
                { 104, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "Fiat" }
            });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedDate", "CreatedUser", "DriverMinimumAge", "ModifiedDate", "ModifiedUser", "Name" },
                values: new object[,]
                {
            { 100, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, 18, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "Argentina" },
            { 101, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, 16, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "Brasil" },
            { 102, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, 21, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "Chile" }
                });

            migrationBuilder.InsertData(
                table: "PlatformPermissions",
                columns: new[] { "Id", "CreatedDate", "CreatedUser", "Description", "ModifiedDate", "ModifiedUser", "Name" },
                values: new object[,]
                {
        { 100, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "Add new vehicle", new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "VEHICLE_ADD" },
        { 101, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "Remove a vehicle", new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "VEHICLE_REMOVE" },
        { 102, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "Remove a customer", new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "CUSTOMER_REMOVE" },
        { 103, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "Add new rental", new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "RENTAL_ADD" },
        { 104, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "Cancel rental", new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "RENTAL_CANCEL" }
                });

            migrationBuilder.InsertData(
                table: "PlatformRoles",
                columns: new[] { "Id", "CreatedDate", "CreatedUser", "ModifiedDate", "ModifiedUser", "Name" },
                values: new object[,]
                {
        { 100, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "ADMIN" },
        { 101, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarBrandId", "CreatedDate", "CreatedUser", "DailyPrice", "IsActive", "ModifiedDate", "ModifiedUser", "NumberPlate", "PlacedInCountryId" },
                values: new object[,]
                {
        { 100, 100, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, 100f, true, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "key123", 100 },
        { 101, 101, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, 250f, true, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "foo123", 100 }
                });

            migrationBuilder.InsertData(
                table: "CompanyUsers",
                columns: new[] { "Id", "BirthDate", "CountryId", "CreatedDate", "CreatedUser", "Email", "Firstname", "Lastname", "ModifiedDate", "ModifiedUser", "Password", "PlatformRoleId" },
                values: new object[] { 100, new DateTime(1999, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "martamartinez@example.com", "Marta", "Martinez", new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "288A771EBF8EF6A3C7B1E2ECDD87DAC9CFEF02BE94724EEEC526D381DE11396D", 100 });

            migrationBuilder.InsertData(
                table: "CustomerUsers",
                columns: new[] { "Id", "BirthDate", "CountryId", "CreatedDate", "CreatedUser", "DriverLicenseNumber", "Email", "Firstname", "IdCardNumber", "IsActive", "Lastname", "ModifiedDate", "ModifiedUser", "Password" },
                values: new object[] { 100, new DateTime(1999, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "abc123", "juanperez@example.com", "Juan", "41737140", true, "Perez", new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "288A771EBF8EF6A3C7B1E2ECDD87DAC9CFEF02BE94724EEEC526D381DE11396D" });

            migrationBuilder.InsertData(
                table: "CarCalendar",
                columns: new[] { "Id", "CalendarDate", "CarId", "CreatedDate", "CreatedUser", "HoldByCustomerUserId", "HoldUpToDate", "ModifiedDate", "ModifiedUser", "Status", "Version" },
                values: new object[,]
                {
                    { 100, new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, 1, 1 },
                    { 101, new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "CarCalendar",
                columns: new[] { "Id", "CalendarDate", "CarId", "CreatedDate", "CreatedUser", "HoldByCustomerUserId", "HoldUpToDate", "ModifiedDate", "ModifiedUser" },
                values: new object[,]
                {
                    { 102, new DateTime(2024, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null },
                    { 103, new DateTime(2024, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null },
                    { 104, new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null },
                    { 105, new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null },
                    { 106, new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null },
                    { 107, new DateTime(2024, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null },
                    { 108, new DateTime(2024, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null },
                    { 109, new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, null, null, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "CarId", "CreatedDate", "CreatedUser", "CustomerUserId", "DailyPrice", "FromDate", "ModifiedDate", "ModifiedUser", "Status", "ToDate", "TotalPrice" },
                values: new object[] { 100, 100, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, 100, 100f, new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), null, 0, new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 200f });


            migrationBuilder.Sql(@"Insert Into PlatformPermissionPlatformRole values (100, 100)");
            migrationBuilder.Sql(@"Insert Into PlatformPermissionPlatformRole values (101, 100)");
            migrationBuilder.Sql(@"Insert Into PlatformPermissionPlatformRole values (102, 100)");
            migrationBuilder.Sql(@"Insert Into PlatformPermissionPlatformRole values (104, 100)");

            migrationBuilder.Sql(@"Insert Into PlatformPermissionPlatformRole values (102, 101)");
            migrationBuilder.Sql(@"Insert Into PlatformPermissionPlatformRole values (103, 101)");
            migrationBuilder.Sql(@"Insert Into PlatformPermissionPlatformRole values (104, 101)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarCalendar",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "CarCalendar",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "CarCalendar",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "CarCalendar",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "CarCalendar",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "CarCalendar",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "CarCalendar",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "CarCalendar",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "CarCalendar",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "CarCalendar",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 100);
        }
    }
}
