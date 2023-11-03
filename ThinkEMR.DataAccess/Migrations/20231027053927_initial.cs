using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThinkEMR_Care.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fc67049-54bc-42fd-9338-cb05b025c7d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50e08bb1-746d-4828-8278-440fc679247b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43900d6f-ebd9-4100-b531-3f4f31a7d2e6", "2", "Admin2", "Admin2" },
                    { "ff94b32f-c952-475c-bcad-7281bc711393", "1", "Admin1", "Admin1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43900d6f-ebd9-4100-b531-3f4f31a7d2e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff94b32f-c952-475c-bcad-7281bc711393");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2fc67049-54bc-42fd-9338-cb05b025c7d4", "1", "Admin1", "Admin1" },
                    { "50e08bb1-746d-4828-8278-440fc679247b", "2", "Admin2", "Admin2" }
                });
        }
    }
}
