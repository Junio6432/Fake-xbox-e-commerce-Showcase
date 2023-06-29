using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo_webshop.Migrations
{
    public partial class addProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffbff311-d6ba-4a68-870d-81ae9c701b92",
                column: "ConcurrencyStamp",
                value: "e517031b-e6e6-48ca-b70a-a15c95f9c688");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc787601-3197-4180-8587-9f0433cade28",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ea56c9d0-aa5f-40a6-adfc-d5ee048525f4", "8ae9476d-09bd-43c4-abf7-f9473605598b" });
        }
    }
}
