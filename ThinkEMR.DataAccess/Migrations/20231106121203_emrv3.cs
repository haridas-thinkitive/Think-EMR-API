using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThinkEMR_Care.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class emrv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1423d735-dd8a-4bba-abcc-b35793200c35");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b5a78de-eef9-4c55-a0ca-4ca286afaf8e");

            migrationBuilder.CreateTable(
                name: "BasicAccountProfileData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaOfFocus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalAffilation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeGroupSeen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguagesSpoken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderEmploymentReferralNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcceptNewPatients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcceptCashPay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceVerification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderBio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpertiseIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkExperience = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicAccountProfileData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProviderUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ProviderType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicensedStates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeFaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxonomyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NPINumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupNPINumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsurancesAccepted = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkLocations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasicAccountProfileId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderUsers_BasicAccountProfileData_BasicAccountProfileId",
                        column: x => x.BasicAccountProfileId,
                        principalTable: "BasicAccountProfileData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b0235e78-71b4-428e-b4f9-817948438200", "2", "Admin", "Admin1" },
                    { "f6695a94-2d5e-4191-88c5-94bceeaee138", "1", "SuperAdmin", "SuperAdmin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProviderUsers_BasicAccountProfileId",
                table: "ProviderUsers",
                column: "BasicAccountProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProviderUsers");

            migrationBuilder.DropTable(
                name: "StaffUsers");

            migrationBuilder.DropTable(
                name: "BasicAccountProfileData");

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
                    { "1423d735-dd8a-4bba-abcc-b35793200c35", "1", "SuperAdmin", "SuperAdmin" },
                    { "1b5a78de-eef9-4c55-a0ca-4ca286afaf8e", "2", "Admin", "Admin1" }
                });
        }
    }
}
