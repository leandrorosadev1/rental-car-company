using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalCar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20240614_1710 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlatformPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<int>(type: "int", nullable: true),
                    ModifiedUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlatformRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<int>(type: "int", nullable: true),
                    ModifiedUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlatformPermissionPlatformRole",
                columns: table => new
                {
                    PermissionsId = table.Column<int>(type: "int", nullable: false),
                    PlatformRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformPermissionPlatformRole", x => new { x.PermissionsId, x.PlatformRoleId });
                    table.ForeignKey(
                        name: "FK_PlatformPermissionPlatformRole_PlatformPermissions_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "PlatformPermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatformPermissionPlatformRole_PlatformRoles_PlatformRoleId",
                        column: x => x.PlatformRoleId,
                        principalTable: "PlatformRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlatformPermissionPlatformRole_PlatformRoleId",
                table: "PlatformPermissionPlatformRole",
                column: "PlatformRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlatformPermissionPlatformRole");

            migrationBuilder.DropTable(
                name: "PlatformPermissions");

            migrationBuilder.DropTable(
                name: "PlatformRoles");
        }
    }
}
