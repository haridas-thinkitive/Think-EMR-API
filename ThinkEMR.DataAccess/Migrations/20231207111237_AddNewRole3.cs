using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThinkEMR_Care.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddNewRole3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36f39a27-102d-48b8-83c2-aa609611ad20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6091d52-ab56-4b12-a0cd-b0be4b038e90");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RoleUsers");

            migrationBuilder.DropColumn(
                name: "Permissions",
                table: "RoleUsers");

            migrationBuilder.AlterColumn<int>(
                name: "RoleType",
                table: "RoleUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "SelectedPermissions",
                table: "RoleUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1de2a8cf-b408-484a-a445-575ca96596ad", "2", "Admin", "Admin1" },
                    { "d08731ad-c873-418a-9e88-38a172ddaa17", "1", "SuperAdmin", "SuperAdmin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1de2a8cf-b408-484a-a445-575ca96596ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d08731ad-c873-418a-9e88-38a172ddaa17");

            migrationBuilder.DropColumn(
                name: "SelectedPermissions",
                table: "RoleUsers");

            migrationBuilder.AlterColumn<string>(
                name: "RoleType",
                table: "RoleUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RoleUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Permissions",
                table: "RoleUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36f39a27-102d-48b8-83c2-aa609611ad20", "1", "SuperAdmin", "SuperAdmin" },
                    { "b6091d52-ab56-4b12-a0cd-b0be4b038e90", "2", "Admin", "Admin1" }
                });
        }
    }
}
