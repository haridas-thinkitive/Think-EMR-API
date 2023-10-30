using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThinkEMR_Care.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Provider");

            migrationBuilder.DropTable(
                name: "tbl_ProviderDepartment");

            migrationBuilder.DropTable(
                name: "tbl_ProviderGroupLocation");

            migrationBuilder.DropTable(
                name: "tbl_ProviderStaffUser");

            migrationBuilder.DropTable(
                name: "ProviderAcceptedInsurance");

            migrationBuilder.DropTable(
                name: "ProviderLicensedState");

            migrationBuilder.DropTable(
                name: "ProviderSpokenLanguage");

            migrationBuilder.DropTable(
                name: "ProviderType");

            migrationBuilder.DropTable(
                name: "ProviderWorkLocation");

            migrationBuilder.DropTable(
                name: "Speciality");

            migrationBuilder.DropTable(
                name: "tbl_ProviderGroup");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3acc945e-d6a3-4e5a-9da1-4e0e3f79a746");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efe7045f-bdcd-4130-98ae-68f67d05e898");

            migrationBuilder.CreateTable(
                name: "BillingAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SameAsPhysicalAddress = table.Column<bool>(type: "bit", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentAdmin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationsBillingAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SameAsPhysicalAddress = table.Column<bool>(type: "bit", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationsBillingAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationsPhysicalAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationsPhysicalAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PracticeOfficeHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monday = table.Column<bool>(type: "bit", nullable: false),
                    Tuesday = table.Column<bool>(type: "bit", nullable: false),
                    Wednesday = table.Column<bool>(type: "bit", nullable: false),
                    Thursday = table.Column<bool>(type: "bit", nullable: false),
                    Friday = table.Column<bool>(type: "bit", nullable: false),
                    Saturday = table.Column<bool>(type: "bit", nullable: false),
                    Sunday = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeOfficeHours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddLocationLogo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaxId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationsPhysicalAddressId = table.Column<int>(type: "int", nullable: false),
                    BillingAddressId = table.Column<int>(type: "int", nullable: false),
                    PracticeOfficeHoursId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_locations_LocationsBillingAddress_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "LocationsBillingAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_locations_LocationsPhysicalAddress_LocationsPhysicalAddressId",
                        column: x => x.LocationsPhysicalAddressId,
                        principalTable: "LocationsPhysicalAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_locations_PracticeOfficeHours_PracticeOfficeHoursId",
                        column: x => x.PracticeOfficeHoursId,
                        principalTable: "PracticeOfficeHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "providerGroupProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ProviderGroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupNPINumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialityTypes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaxId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhysicalAddressId = table.Column<int>(type: "int", nullable: false),
                    BillingAddressId = table.Column<int>(type: "int", nullable: false),
                    PracticeOfficeHoursId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_providerGroupProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_providerGroupProfiles_BillingAddress_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "BillingAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_providerGroupProfiles_PhysicalAddress_PhysicalAddressId",
                        column: x => x.PhysicalAddressId,
                        principalTable: "PhysicalAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_providerGroupProfiles_PracticeOfficeHours_PracticeOfficeHoursId",
                        column: x => x.PracticeOfficeHoursId,
                        principalTable: "PracticeOfficeHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2fc67049-54bc-42fd-9338-cb05b025c7d4", "1", "Admin1", "Admin1" },
                    { "50e08bb1-746d-4828-8278-440fc679247b", "2", "Admin2", "Admin2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_locations_BillingAddressId",
                table: "locations",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_locations_LocationsPhysicalAddressId",
                table: "locations",
                column: "LocationsPhysicalAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_locations_PracticeOfficeHoursId",
                table: "locations",
                column: "PracticeOfficeHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_providerGroupProfiles_BillingAddressId",
                table: "providerGroupProfiles",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_providerGroupProfiles_PhysicalAddressId",
                table: "providerGroupProfiles",
                column: "PhysicalAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_providerGroupProfiles_PracticeOfficeHoursId",
                table: "providerGroupProfiles",
                column: "PracticeOfficeHoursId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "providerGroupProfiles");

            migrationBuilder.DropTable(
                name: "LocationsBillingAddress");

            migrationBuilder.DropTable(
                name: "LocationsPhysicalAddress");

            migrationBuilder.DropTable(
                name: "BillingAddress");

            migrationBuilder.DropTable(
                name: "PhysicalAddress");

            migrationBuilder.DropTable(
                name: "PracticeOfficeHours");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fc67049-54bc-42fd-9338-cb05b025c7d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50e08bb1-746d-4828-8278-440fc679247b");

            migrationBuilder.CreateTable(
                name: "ProviderAcceptedInsurance",
                columns: table => new
                {
                    ProviderAcceptedInsuranceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderAcceptedInsuranceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderAcceptedInsurance", x => x.ProviderAcceptedInsuranceId);
                });

            migrationBuilder.CreateTable(
                name: "ProviderLicensedState",
                columns: table => new
                {
                    ProviderLicensedStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderLicensedStateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderLicensedState", x => x.ProviderLicensedStateId);
                });

            migrationBuilder.CreateTable(
                name: "ProviderSpokenLanguage",
                columns: table => new
                {
                    ProviderSpokenLanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderSpokenLanguageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderSpokenLanguage", x => x.ProviderSpokenLanguageId);
                });

            migrationBuilder.CreateTable(
                name: "ProviderType",
                columns: table => new
                {
                    ProviderTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderType", x => x.ProviderTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ProviderWorkLocation",
                columns: table => new
                {
                    ProviderWorkLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderWorkLocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderWorkLocation", x => x.ProviderWorkLocationId);
                });

            migrationBuilder.CreateTable(
                name: "Speciality",
                columns: table => new
                {
                    SpecialityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speciality", x => x.SpecialityId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ProviderGroup",
                columns: table => new
                {
                    ProviderGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaxId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderGroupEmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderGroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ProviderGroup", x => x.ProviderGroupId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Provider",
                columns: table => new
                {
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderAcceptedInsuranceId = table.Column<int>(type: "int", nullable: false),
                    ProviderGroupId = table.Column<int>(type: "int", nullable: false),
                    ProviderLicensedStateId = table.Column<int>(type: "int", nullable: false),
                    ProviderSpokenLanguageId = table.Column<int>(type: "int", nullable: false),
                    ProviderTypeId = table.Column<int>(type: "int", nullable: false),
                    ProviderWorkLocationId = table.Column<int>(type: "int", nullable: false),
                    SpecialityId = table.Column<int>(type: "int", nullable: false),
                    AcceptCashPay = table.Column<bool>(type: "bit", nullable: false),
                    AcceptNewPatients = table.Column<bool>(type: "bit", nullable: false),
                    AgeGroupSeen = table.Column<int>(type: "int", nullable: false),
                    Education_WorkExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpertiseIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    GroupNPINumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hospital_Affialation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceVerification = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OfficeFaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderBio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProviderPhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Provider_Employment_Referral_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Sub_Specialities = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaxonomyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Provider", x => x.ProviderId);
                    table.ForeignKey(
                        name: "FK_tbl_Provider_ProviderAcceptedInsurance_ProviderAcceptedInsuranceId",
                        column: x => x.ProviderAcceptedInsuranceId,
                        principalTable: "ProviderAcceptedInsurance",
                        principalColumn: "ProviderAcceptedInsuranceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Provider_ProviderLicensedState_ProviderLicensedStateId",
                        column: x => x.ProviderLicensedStateId,
                        principalTable: "ProviderLicensedState",
                        principalColumn: "ProviderLicensedStateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Provider_ProviderSpokenLanguage_ProviderSpokenLanguageId",
                        column: x => x.ProviderSpokenLanguageId,
                        principalTable: "ProviderSpokenLanguage",
                        principalColumn: "ProviderSpokenLanguageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Provider_ProviderType_ProviderTypeId",
                        column: x => x.ProviderTypeId,
                        principalTable: "ProviderType",
                        principalColumn: "ProviderTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Provider_ProviderWorkLocation_ProviderWorkLocationId",
                        column: x => x.ProviderWorkLocationId,
                        principalTable: "ProviderWorkLocation",
                        principalColumn: "ProviderWorkLocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Provider_Speciality_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Speciality",
                        principalColumn: "SpecialityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Provider_tbl_ProviderGroup_ProviderGroupId",
                        column: x => x.ProviderGroupId,
                        principalTable: "tbl_ProviderGroup",
                        principalColumn: "ProviderGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ProviderDepartment",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderGroupId = table.Column<int>(type: "int", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentAdminId = table.Column<int>(type: "int", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ProviderDepartment", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_tbl_ProviderDepartment_tbl_ProviderGroup_ProviderGroupId",
                        column: x => x.ProviderGroupId,
                        principalTable: "tbl_ProviderGroup",
                        principalColumn: "ProviderGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ProviderGroupLocation",
                columns: table => new
                {
                    ProviderGroupLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderGroupId = table.Column<int>(type: "int", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaxId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speciality = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ProviderGroupLocation", x => x.ProviderGroupLocationId);
                    table.ForeignKey(
                        name: "FK_tbl_ProviderGroupLocation_tbl_ProviderGroup_ProviderGroupId",
                        column: x => x.ProviderGroupId,
                        principalTable: "tbl_ProviderGroup",
                        principalColumn: "ProviderGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ProviderStaffUser",
                columns: table => new
                {
                    StaffUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderGroupId = table.Column<int>(type: "int", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ProviderStaffUser", x => x.StaffUserId);
                    table.ForeignKey(
                        name: "FK_tbl_ProviderStaffUser_tbl_ProviderGroup_ProviderGroupId",
                        column: x => x.ProviderGroupId,
                        principalTable: "tbl_ProviderGroup",
                        principalColumn: "ProviderGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3acc945e-d6a3-4e5a-9da1-4e0e3f79a746", "2", "Admin2", "Admin2" },
                    { "efe7045f-bdcd-4130-98ae-68f67d05e898", "1", "Admin1", "Admin1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Provider_ProviderAcceptedInsuranceId",
                table: "tbl_Provider",
                column: "ProviderAcceptedInsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Provider_ProviderGroupId",
                table: "tbl_Provider",
                column: "ProviderGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Provider_ProviderLicensedStateId",
                table: "tbl_Provider",
                column: "ProviderLicensedStateId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Provider_ProviderSpokenLanguageId",
                table: "tbl_Provider",
                column: "ProviderSpokenLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Provider_ProviderTypeId",
                table: "tbl_Provider",
                column: "ProviderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Provider_ProviderWorkLocationId",
                table: "tbl_Provider",
                column: "ProviderWorkLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Provider_SpecialityId",
                table: "tbl_Provider",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ProviderDepartment_ProviderGroupId",
                table: "tbl_ProviderDepartment",
                column: "ProviderGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ProviderGroupLocation_ProviderGroupId",
                table: "tbl_ProviderGroupLocation",
                column: "ProviderGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ProviderStaffUser_ProviderGroupId",
                table: "tbl_ProviderStaffUser",
                column: "ProviderGroupId");
        }
    }
}
