using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo_webshop.Migrations
{
    public partial class managerCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ffbff311-d6ba-4a68-870d-81ae9c701b92", "413350c7-9a8f-43ce-9c1e-6492be8b3dea", "manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShoppingCartId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bc787601-3197-4180-8587-9f0433cade28", 0, "9de7a58d-e258-4d37-bae2-de95d53e708d", "ApplicationUser", "demo@example.com", false, "", "", false, null, "DEMO@EXAMPLE.COM", "DEMO@EXAMPLE.COM", "AQAAAAEAACcQAAAAEJDsJ11VXYg4gZRdj4QjrgjqwoJjs05G9sDQFZWzUJU0LcukM7syxdUrcOtIihvfxQ==", null, false, "1b4d55dd-0083-4091-a1c5-5d76fb9244f7", "", false, "demo@example.com" });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "Description",
                value: "Games in wich you use fire guns to advance");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ffbff311-d6ba-4a68-870d-81ae9c701b92", "bc787601-3197-4180-8587-9f0433cade28" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ffbff311-d6ba-4a68-870d-81ae9c701b92", "bc787601-3197-4180-8587-9f0433cade28\"" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc787601-3197-4180-8587-9f0433cade28");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffbff311-d6ba-4a68-870d-81ae9c701b92");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "Description",
                value: "Games in wich you use weapons to advance");
        }
    }
}
