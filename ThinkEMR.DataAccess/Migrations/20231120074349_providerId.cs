using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThinkEMR_Care.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class providerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8e5a19c-bcd7-4b4b-bd16-aad9f3fbd70f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7fdb01b-204f-4178-a724-59103f0c256a");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderId",
                table: "ProviderUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a9b85bd5-7099-4b6a-bb6b-7a3f49299180", "1", "SuperAdmin", "SuperAdmin" },
                    { "ea0b5a3b-e3a5-4eac-8036-bab2a3a6af88", "2", "Admin", "Admin1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9b85bd5-7099-4b6a-bb6b-7a3f49299180");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea0b5a3b-e3a5-4eac-8036-bab2a3a6af88");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderId",
                table: "ProviderUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a8e5a19c-bcd7-4b4b-bd16-aad9f3fbd70f", "2", "Admin", "Admin1" },
                    { "c7fdb01b-204f-4178-a724-59103f0c256a", "1", "SuperAdmin", "SuperAdmin" }
                });
        }
    }
}
