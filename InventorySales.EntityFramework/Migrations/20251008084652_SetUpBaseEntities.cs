using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventorySales.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class SetUpBaseEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "core");

            migrationBuilder.EnsureSchema(
                name: "metadata");

            migrationBuilder.EnsureSchema(
                name: "transactions");

            migrationBuilder.CreateTable(
                name: "AssetTypes",
                schema: "core",
                columns: table => new
                {
                    AssetTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTypes", x => x.AssetTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "core",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "DataTypes",
                schema: "metadata",
                columns: table => new
                {
                    DataTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeValueSample = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTypes", x => x.DataTypeId);
                });

            migrationBuilder.CreateTable(
                name: "MetadataSchemaVersions",
                schema: "core",
                columns: table => new
                {
                    MetadataSchemaVersionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Version = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    VersionDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetadataSchemaVersions", x => x.MetadataSchemaVersionId);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                schema: "core",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetTypeId = table.Column<int>(type: "int", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    MetadataSchemaVersionId = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_Assets_AssetTypes_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalSchema: "core",
                        principalTable: "AssetTypes",
                        principalColumn: "AssetTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_MetadataSchemaVersions_MetadataSchemaVersionId",
                        column: x => x.MetadataSchemaVersionId,
                        principalSchema: "core",
                        principalTable: "MetadataSchemaVersions",
                        principalColumn: "MetadataSchemaVersionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElementDefinitions",
                schema: "metadata",
                columns: table => new
                {
                    ElementDefinitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElementName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ElementDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MetadataSchemaVersionId = table.Column<int>(type: "int", nullable: false),
                    DataTypeId = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementDefinitions", x => x.ElementDefinitionId);
                    table.ForeignKey(
                        name: "FK_ElementDefinitions_DataTypes_DataTypeId",
                        column: x => x.DataTypeId,
                        principalSchema: "metadata",
                        principalTable: "DataTypes",
                        principalColumn: "DataTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ElementDefinitions_MetadataSchemaVersions_MetadataSchemaVersionId",
                        column: x => x.MetadataSchemaVersionId,
                        principalSchema: "core",
                        principalTable: "MetadataSchemaVersions",
                        principalColumn: "MetadataSchemaVersionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                schema: "core",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventories_Assets_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "core",
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventories_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                schema: "transactions",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_Sales_Assets_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "core",
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "core",
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElementValues",
                schema: "metadata",
                columns: table => new
                {
                    ElementValueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElementDefinitionId = table.Column<int>(type: "int", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntityRecordId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: true),
                    ElementDefinitionId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementValues", x => x.ElementValueId);
                    table.ForeignKey(
                        name: "FK_ElementValues_Assets_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "core",
                        principalTable: "Assets",
                        principalColumn: "AssetId");
                    table.ForeignKey(
                        name: "FK_ElementValues_ElementDefinitions_ElementDefinitionId",
                        column: x => x.ElementDefinitionId,
                        principalSchema: "metadata",
                        principalTable: "ElementDefinitions",
                        principalColumn: "ElementDefinitionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ElementValues_ElementDefinitions_ElementDefinitionId1",
                        column: x => x.ElementDefinitionId1,
                        principalSchema: "metadata",
                        principalTable: "ElementDefinitions",
                        principalColumn: "ElementDefinitionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetTypeId",
                schema: "core",
                table: "Assets",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_CreatedAt",
                schema: "core",
                table: "Assets",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_CreatedByUserId",
                schema: "core",
                table: "Assets",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_MetadataSchemaVersionId",
                schema: "core",
                table: "Assets",
                column: "MetadataSchemaVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_UpdatedByUserId",
                schema: "core",
                table: "Assets",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementDefinitions_DataTypeId",
                schema: "metadata",
                table: "ElementDefinitions",
                column: "DataTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementDefinitions_MetadataSchemaVersionId",
                schema: "metadata",
                table: "ElementDefinitions",
                column: "MetadataSchemaVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementValues_AssetId",
                schema: "metadata",
                table: "ElementValues",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementValues_ElementDefinitionId",
                schema: "metadata",
                table: "ElementValues",
                column: "ElementDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementValues_ElementDefinitionId1",
                schema: "metadata",
                table: "ElementValues",
                column: "ElementDefinitionId1");

            migrationBuilder.CreateIndex(
                name: "IX_ElementValues_EntityName",
                schema: "metadata",
                table: "ElementValues",
                column: "EntityName");

            migrationBuilder.CreateIndex(
                name: "IX_ElementValues_EntityRecordId",
                schema: "metadata",
                table: "ElementValues",
                column: "EntityRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_AssetId",
                schema: "core",
                table: "Inventories",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_CreatedByUserId",
                schema: "core",
                table: "Inventories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_UpdatedByUserId",
                schema: "core",
                table: "Inventories",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_AssetId",
                schema: "transactions",
                table: "Sales",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                schema: "transactions",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SaleDate",
                schema: "transactions",
                table: "Sales",
                column: "SaleDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementValues",
                schema: "metadata");

            migrationBuilder.DropTable(
                name: "Inventories",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Sales",
                schema: "transactions");

            migrationBuilder.DropTable(
                name: "ElementDefinitions",
                schema: "metadata");

            migrationBuilder.DropTable(
                name: "Assets",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "core");

            migrationBuilder.DropTable(
                name: "DataTypes",
                schema: "metadata");

            migrationBuilder.DropTable(
                name: "AssetTypes",
                schema: "core");

            migrationBuilder.DropTable(
                name: "MetadataSchemaVersions",
                schema: "core");
        }
    }
}
