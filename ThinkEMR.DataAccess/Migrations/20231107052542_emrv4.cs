using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThinkEMR_Care.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class emrv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0235e78-71b4-428e-b4f9-817948438200");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6695a94-2d5e-4191-88c5-94bceeaee138");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d9f9e443-e73c-482b-90e3-29a4a6fa94f9", "1", "SuperAdmin", "SuperAdmin" },
                    { "df15da4f-d9c6-4d4f-8d16-eea2c79db53a", "2", "Admin", "Admin1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9f9e443-e73c-482b-90e3-29a4a6fa94f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df15da4f-d9c6-4d4f-8d16-eea2c79db53a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b0235e78-71b4-428e-b4f9-817948438200", "2", "Admin", "Admin1" },
                    { "f6695a94-2d5e-4191-88c5-94bceeaee138", "1", "SuperAdmin", "SuperAdmin" }
                });
        }
    }
}
