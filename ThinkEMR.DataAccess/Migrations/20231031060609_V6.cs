using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThinkEMR_Care.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class V6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08aff6c8-a904-4b40-8848-4dbbcee95b89");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed53fb62-3242-4028-b4e1-81303f3d3546");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1807aa97-9c4d-49e1-8ecc-0cad19737029", "2", "Admin", "Admin1" },
                    { "4bb434db-e027-4f94-9110-47c8f2c45533", "1", "SuperAdmin", "SuperAdmin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1807aa97-9c4d-49e1-8ecc-0cad19737029");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bb434db-e027-4f94-9110-47c8f2c45533");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08aff6c8-a904-4b40-8848-4dbbcee95b89", "1", "SuperAdmin", "SuperAdmin" },
                    { "ed53fb62-3242-4028-b4e1-81303f3d3546", "2", "Admin", "Admin1" }
                });
        }
    }
}
