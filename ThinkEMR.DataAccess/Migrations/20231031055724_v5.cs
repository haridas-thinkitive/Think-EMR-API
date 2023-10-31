using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThinkEMR_Care.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_locations_LocationsBillingAddress_BillingAddressId",
                table: "locations");

            migrationBuilder.DropForeignKey(
                name: "FK_locations_LocationsPhysicalAddress_LocationsPhysicalAddressId",
                table: "locations");

            migrationBuilder.DropForeignKey(
                name: "FK_locations_PracticeOfficeHours_PracticeOfficeHoursId",
                table: "locations");

            migrationBuilder.DropForeignKey(
                name: "FK_providerGroupProfiles_BillingAddress_BillingAddressId",
                table: "providerGroupProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_providerGroupProfiles_PhysicalAddress_PhysicalAddressId",
                table: "providerGroupProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_providerGroupProfiles_PracticeOfficeHours_PracticeOfficeHoursId",
                table: "providerGroupProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_providerGroupProfiles",
                table: "providerGroupProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_loINCCodeCatalogs",
                table: "loINCCodeCatalogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_locations",
                table: "locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_icD10CodeCatalogs",
                table: "icD10CodeCatalogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_drugCatalogs",
                table: "drugCatalogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departments",
                table: "departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dataImports",
                table: "dataImports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cPTCodeCatalogs",
                table: "cPTCodeCatalogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hPCSCodeCatalogs",
                table: "hPCSCodeCatalogs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46d8e732-ae37-4421-8b07-17718a30d4fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b540df04-3e4c-4b7d-b8cf-ea62d3d598de");

            migrationBuilder.RenameTable(
                name: "providerGroupProfiles",
                newName: "ProviderGroupProfiles");

            migrationBuilder.RenameTable(
                name: "loINCCodeCatalogs",
                newName: "LOINCCodeCatalogs");

            migrationBuilder.RenameTable(
                name: "locations",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "icD10CodeCatalogs",
                newName: "ICD10CodeCatalogs");

            migrationBuilder.RenameTable(
                name: "drugCatalogs",
                newName: "DrugCatalogs");

            migrationBuilder.RenameTable(
                name: "departments",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "dataImports",
                newName: "DataImports");

            migrationBuilder.RenameTable(
                name: "cPTCodeCatalogs",
                newName: "CPTCodeCatalogs");

            migrationBuilder.RenameTable(
                name: "hPCSCodeCatalogs",
                newName: "HCPCSCodeCatalogs");

            migrationBuilder.RenameIndex(
                name: "IX_providerGroupProfiles_PracticeOfficeHoursId",
                table: "ProviderGroupProfiles",
                newName: "IX_ProviderGroupProfiles_PracticeOfficeHoursId");

            migrationBuilder.RenameIndex(
                name: "IX_providerGroupProfiles_PhysicalAddressId",
                table: "ProviderGroupProfiles",
                newName: "IX_ProviderGroupProfiles_PhysicalAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_providerGroupProfiles_BillingAddressId",
                table: "ProviderGroupProfiles",
                newName: "IX_ProviderGroupProfiles_BillingAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_locations_PracticeOfficeHoursId",
                table: "Locations",
                newName: "IX_Locations_PracticeOfficeHoursId");

            migrationBuilder.RenameIndex(
                name: "IX_locations_LocationsPhysicalAddressId",
                table: "Locations",
                newName: "IX_Locations_LocationsPhysicalAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_locations_BillingAddressId",
                table: "Locations",
                newName: "IX_Locations_BillingAddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProviderGroupProfiles",
                table: "ProviderGroupProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LOINCCodeCatalogs",
                table: "LOINCCodeCatalogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ICD10CodeCatalogs",
                table: "ICD10CodeCatalogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DrugCatalogs",
                table: "DrugCatalogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataImports",
                table: "DataImports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CPTCodeCatalogs",
                table: "CPTCodeCatalogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HCPCSCodeCatalogs",
                table: "HCPCSCodeCatalogs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "tblRole",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRole", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "tblRoleType",
                columns: table => new
                {
                    RoleTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRoleType", x => x.RoleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "tblPermission",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleTypeId = table.Column<int>(type: "int", nullable: false),
                    PermissionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermissionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermissionStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPermission", x => x.PermissionId);
                    table.ForeignKey(
                        name: "FK_tblPermission_tblRoleType_RoleTypeId",
                        column: x => x.RoleTypeId,
                        principalTable: "tblRoleType",
                        principalColumn: "RoleTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblRolePermission",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRolePermission", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_tblRolePermission_tblPermission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "tblPermission",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblRolePermission_tblRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tblRole",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08aff6c8-a904-4b40-8848-4dbbcee95b89", "1", "SuperAdmin", "SuperAdmin" },
                    { "ed53fb62-3242-4028-b4e1-81303f3d3546", "2", "Admin", "Admin1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblPermission_RoleTypeId",
                table: "tblPermission",
                column: "RoleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRolePermission_PermissionId",
                table: "tblRolePermission",
                column: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_LocationsBillingAddress_BillingAddressId",
                table: "Locations",
                column: "BillingAddressId",
                principalTable: "LocationsBillingAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_LocationsPhysicalAddress_LocationsPhysicalAddressId",
                table: "Locations",
                column: "LocationsPhysicalAddressId",
                principalTable: "LocationsPhysicalAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_PracticeOfficeHours_PracticeOfficeHoursId",
                table: "Locations",
                column: "PracticeOfficeHoursId",
                principalTable: "PracticeOfficeHours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderGroupProfiles_BillingAddress_BillingAddressId",
                table: "ProviderGroupProfiles",
                column: "BillingAddressId",
                principalTable: "BillingAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderGroupProfiles_PhysicalAddress_PhysicalAddressId",
                table: "ProviderGroupProfiles",
                column: "PhysicalAddressId",
                principalTable: "PhysicalAddress",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderGroupProfiles_PracticeOfficeHours_PracticeOfficeHoursId",
                table: "ProviderGroupProfiles",
                column: "PracticeOfficeHoursId",
                principalTable: "PracticeOfficeHours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_LocationsBillingAddress_BillingAddressId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_LocationsPhysicalAddress_LocationsPhysicalAddressId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_PracticeOfficeHours_PracticeOfficeHoursId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderGroupProfiles_BillingAddress_BillingAddressId",
                table: "ProviderGroupProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderGroupProfiles_PhysicalAddress_PhysicalAddressId",
                table: "ProviderGroupProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderGroupProfiles_PracticeOfficeHours_PracticeOfficeHoursId",
                table: "ProviderGroupProfiles");

            migrationBuilder.DropTable(
                name: "tblRolePermission");

            migrationBuilder.DropTable(
                name: "tblPermission");

            migrationBuilder.DropTable(
                name: "tblRole");

            migrationBuilder.DropTable(
                name: "tblRoleType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProviderGroupProfiles",
                table: "ProviderGroupProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LOINCCodeCatalogs",
                table: "LOINCCodeCatalogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ICD10CodeCatalogs",
                table: "ICD10CodeCatalogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DrugCatalogs",
                table: "DrugCatalogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DataImports",
                table: "DataImports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CPTCodeCatalogs",
                table: "CPTCodeCatalogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HCPCSCodeCatalogs",
                table: "HCPCSCodeCatalogs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08aff6c8-a904-4b40-8848-4dbbcee95b89");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed53fb62-3242-4028-b4e1-81303f3d3546");

            migrationBuilder.RenameTable(
                name: "ProviderGroupProfiles",
                newName: "providerGroupProfiles");

            migrationBuilder.RenameTable(
                name: "LOINCCodeCatalogs",
                newName: "loINCCodeCatalogs");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "locations");

            migrationBuilder.RenameTable(
                name: "ICD10CodeCatalogs",
                newName: "icD10CodeCatalogs");

            migrationBuilder.RenameTable(
                name: "DrugCatalogs",
                newName: "drugCatalogs");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "departments");

            migrationBuilder.RenameTable(
                name: "DataImports",
                newName: "dataImports");

            migrationBuilder.RenameTable(
                name: "CPTCodeCatalogs",
                newName: "cPTCodeCatalogs");

            migrationBuilder.RenameTable(
                name: "HCPCSCodeCatalogs",
                newName: "hPCSCodeCatalogs");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderGroupProfiles_PracticeOfficeHoursId",
                table: "providerGroupProfiles",
                newName: "IX_providerGroupProfiles_PracticeOfficeHoursId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderGroupProfiles_PhysicalAddressId",
                table: "providerGroupProfiles",
                newName: "IX_providerGroupProfiles_PhysicalAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderGroupProfiles_BillingAddressId",
                table: "providerGroupProfiles",
                newName: "IX_providerGroupProfiles_BillingAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_PracticeOfficeHoursId",
                table: "locations",
                newName: "IX_locations_PracticeOfficeHoursId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_LocationsPhysicalAddressId",
                table: "locations",
                newName: "IX_locations_LocationsPhysicalAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_BillingAddressId",
                table: "locations",
                newName: "IX_locations_BillingAddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_providerGroupProfiles",
                table: "providerGroupProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_loINCCodeCatalogs",
                table: "loINCCodeCatalogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_locations",
                table: "locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_icD10CodeCatalogs",
                table: "icD10CodeCatalogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_drugCatalogs",
                table: "drugCatalogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_departments",
                table: "departments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dataImports",
                table: "dataImports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cPTCodeCatalogs",
                table: "cPTCodeCatalogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hPCSCodeCatalogs",
                table: "hPCSCodeCatalogs",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46d8e732-ae37-4421-8b07-17718a30d4fa", "2", "Admin2", "Admin2" },
                    { "b540df04-3e4c-4b7d-b8cf-ea62d3d598de", "1", "Admin1", "Admin1" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_locations_LocationsBillingAddress_BillingAddressId",
                table: "locations",
                column: "BillingAddressId",
                principalTable: "LocationsBillingAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_locations_LocationsPhysicalAddress_LocationsPhysicalAddressId",
                table: "locations",
                column: "LocationsPhysicalAddressId",
                principalTable: "LocationsPhysicalAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_locations_PracticeOfficeHours_PracticeOfficeHoursId",
                table: "locations",
                column: "PracticeOfficeHoursId",
                principalTable: "PracticeOfficeHours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_providerGroupProfiles_BillingAddress_BillingAddressId",
                table: "providerGroupProfiles",
                column: "BillingAddressId",
                principalTable: "BillingAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_providerGroupProfiles_PhysicalAddress_PhysicalAddressId",
                table: "providerGroupProfiles",
                column: "PhysicalAddressId",
                principalTable: "PhysicalAddress",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_providerGroupProfiles_PracticeOfficeHours_PracticeOfficeHoursId",
                table: "providerGroupProfiles",
                column: "PracticeOfficeHoursId",
                principalTable: "PracticeOfficeHours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
