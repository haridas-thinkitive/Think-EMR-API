using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThinkEMR_Care.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class V4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_providerGroupProfiles_PhysicalAddress_PhysicalAddressId",
                table: "providerGroupProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_collaborators",
                table: "collaborators");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43900d6f-ebd9-4100-b531-3f4f31a7d2e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff94b32f-c952-475c-bcad-7281bc711393");

            migrationBuilder.RenameTable(
                name: "collaborators",
                newName: "Collaborators");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collaborators",
                table: "Collaborators",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "cPTCodeCatalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CptCodeCatalog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cPTCodeCatalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dataImports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalRecords = table.Column<int>(type: "int", nullable: false),
                    SampleTemplate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadFile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dataImports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "drugCatalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medicine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    When = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Where = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drugCatalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hPCSCodeCatalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HCPCSCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hPCSCodeCatalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "icD10CodeCatalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icd10CodeCatalog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_icD10CodeCatalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loINCCodeCatalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icd10CodeCatalog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loINCCodeCatalogs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46d8e732-ae37-4421-8b07-17718a30d4fa", "2", "Admin2", "Admin2" },
                    { "b540df04-3e4c-4b7d-b8cf-ea62d3d598de", "1", "Admin1", "Admin1" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_providerGroupProfiles_PhysicalAddress_PhysicalAddressId",
                table: "providerGroupProfiles",
                column: "PhysicalAddressId",
                principalTable: "PhysicalAddress",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_providerGroupProfiles_PhysicalAddress_PhysicalAddressId",
                table: "providerGroupProfiles");

            migrationBuilder.DropTable(
                name: "cPTCodeCatalogs");

            migrationBuilder.DropTable(
                name: "dataImports");

            migrationBuilder.DropTable(
                name: "drugCatalogs");

            migrationBuilder.DropTable(
                name: "hPCSCodeCatalogs");

            migrationBuilder.DropTable(
                name: "icD10CodeCatalogs");

            migrationBuilder.DropTable(
                name: "loINCCodeCatalogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Collaborators",
                table: "Collaborators");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46d8e732-ae37-4421-8b07-17718a30d4fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b540df04-3e4c-4b7d-b8cf-ea62d3d598de");

            migrationBuilder.RenameTable(
                name: "Collaborators",
                newName: "collaborators");

            migrationBuilder.AddPrimaryKey(
                name: "PK_collaborators",
                table: "collaborators",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43900d6f-ebd9-4100-b531-3f4f31a7d2e6", "2", "Admin2", "Admin2" },
                    { "ff94b32f-c952-475c-bcad-7281bc711393", "1", "Admin1", "Admin1" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_providerGroupProfiles_PhysicalAddress_PhysicalAddressId",
                table: "providerGroupProfiles",
                column: "PhysicalAddressId",
                principalTable: "PhysicalAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
