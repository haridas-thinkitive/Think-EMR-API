using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThinkEMR_Care.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "collaborators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collaborators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashboardCounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderGroupCount = table.Column<int>(type: "int", nullable: false),
                    ProvidersCount = table.Column<int>(type: "int", nullable: false),
                    PatientsCount = table.Column<int>(type: "int", nullable: false),
                    AppointmentsCount = table.Column<int>(type: "int", nullable: false),
                    EncountersCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardCounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashboardDatas",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderGroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvidersCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientsCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncounterCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardDatas", x => x.GroupId);
                });

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
                    ProviderGroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaxId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderGroupEmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ProviderGroup", x => x.ProviderGroupId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Provider",
                columns: table => new
                {
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ProviderGroupId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProviderPhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    OfficeFaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupNPINumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxonomyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderTypeId = table.Column<int>(type: "int", nullable: false),
                    SpecialityId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    ProviderAcceptedInsuranceId = table.Column<int>(type: "int", nullable: false),
                    ProviderLicensedStateId = table.Column<int>(type: "int", nullable: false),
                    ProviderWorkLocationId = table.Column<int>(type: "int", nullable: false),
                    Sub_Specialities = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Hospital_Affialation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeGroupSeen = table.Column<int>(type: "int", nullable: false),
                    Provider_Employment_Referral_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcceptNewPatients = table.Column<bool>(type: "bit", nullable: false),
                    AcceptCashPay = table.Column<bool>(type: "bit", nullable: false),
                    ProviderSpokenLanguageId = table.Column<int>(type: "int", nullable: false),
                    InsuranceVerification = table.Column<int>(type: "int", nullable: false),
                    ProviderBio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExpertiseIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Education_WorkExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
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
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentAdminId = table.Column<int>(type: "int", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderGroupId = table.Column<int>(type: "int", nullable: false)
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
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speciality = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaxId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "collaborators");

            migrationBuilder.DropTable(
                name: "DashboardCounts");

            migrationBuilder.DropTable(
                name: "DashboardDatas");

            migrationBuilder.DropTable(
                name: "tbl_Provider");

            migrationBuilder.DropTable(
                name: "tbl_ProviderDepartment");

            migrationBuilder.DropTable(
                name: "tbl_ProviderGroupLocation");

            migrationBuilder.DropTable(
                name: "tbl_ProviderStaffUser");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
        }
    }
}
