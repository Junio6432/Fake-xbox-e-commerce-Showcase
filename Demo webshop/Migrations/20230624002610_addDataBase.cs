using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo_webshop.Migrations
{
    public partial class addDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffbff311-d6ba-4a68-870d-81ae9c701b92",
                column: "ConcurrencyStamp",
                value: "28500f77-a219-4396-911b-40006f9bf524");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc787601-3197-4180-8587-9f0433cade28",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "02ed2e5b-4561-4e14-b305-9d1396f2703a", "8550f835-f100-4db9-81a3-29a684333750" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffbff311-d6ba-4a68-870d-81ae9c701b92",
                column: "ConcurrencyStamp",
                value: "983fa29b-9319-4161-8a7b-80f7431ba070");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc787601-3197-4180-8587-9f0433cade28",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "45398036-134d-44dd-85ac-0d162985ff8d", "3007fd72-5780-4aec-b6a3-a2a855606513" });
        }
    }
}
