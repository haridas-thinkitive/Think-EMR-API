using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThinkEMR_Care.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NotificationTableIsRead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08144b88-0950-4814-9880-529422138226");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d0bc22e-bd5a-4f28-b806-d8bfc7e2cbeb");

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5c189385-5427-405f-8a5f-f8d4bb14992e", "1", "SuperAdmin", "SuperAdmin" },
                    { "6be307bb-20a2-42df-8a52-5b2cd6c9eb8b", "2", "Admin", "Admin1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c189385-5427-405f-8a5f-f8d4bb14992e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6be307bb-20a2-42df-8a52-5b2cd6c9eb8b");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "notifications");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08144b88-0950-4814-9880-529422138226", "1", "SuperAdmin", "SuperAdmin" },
                    { "9d0bc22e-bd5a-4f28-b806-d8bfc7e2cbeb", "2", "Admin", "Admin1" }
                });
        }
    }
}
