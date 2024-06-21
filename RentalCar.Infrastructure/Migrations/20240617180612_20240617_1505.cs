using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalCar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20240617_1505 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CustomerUsers_Email_Password",
                table: "CustomerUsers",
                columns: new[] { "Email", "Password" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CustomerUsers_Email_Password",
                table: "CustomerUsers");
        }
    }
}
