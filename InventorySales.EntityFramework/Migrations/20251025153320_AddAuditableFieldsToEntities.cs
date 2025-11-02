using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventorySales.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditableFieldsToEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Users_CreatedByUserId",
                schema: "core",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Users_UpdatedByUserId",
                schema: "core",
                table: "Assets");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "core",
                table: "AssetTypes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                schema: "core",
                table: "AssetTypes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "core",
                table: "AssetTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                schema: "core",
                table: "AssetTypes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetTypes_CreatedByUserId",
                schema: "core",
                table: "AssetTypes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetTypes_UpdatedByUserId",
                schema: "core",
                table: "AssetTypes",
                column: "UpdatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Users_CreatedByUserId",
                schema: "core",
                table: "Assets",
                column: "CreatedByUserId",
                principalSchema: "identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Users_UpdatedByUserId",
                schema: "core",
                table: "Assets",
                column: "UpdatedByUserId",
                principalSchema: "identity",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetTypes_Users_CreatedByUserId",
                schema: "core",
                table: "AssetTypes",
                column: "CreatedByUserId",
                principalSchema: "identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetTypes_Users_UpdatedByUserId",
                schema: "core",
                table: "AssetTypes",
                column: "UpdatedByUserId",
                principalSchema: "identity",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Users_CreatedByUserId",
                schema: "core",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Users_UpdatedByUserId",
                schema: "core",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetTypes_Users_CreatedByUserId",
                schema: "core",
                table: "AssetTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetTypes_Users_UpdatedByUserId",
                schema: "core",
                table: "AssetTypes");

            migrationBuilder.DropIndex(
                name: "IX_AssetTypes_CreatedByUserId",
                schema: "core",
                table: "AssetTypes");

            migrationBuilder.DropIndex(
                name: "IX_AssetTypes_UpdatedByUserId",
                schema: "core",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "core",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "core",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "core",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                schema: "core",
                table: "AssetTypes");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Users_CreatedByUserId",
                schema: "core",
                table: "Assets",
                column: "CreatedByUserId",
                principalSchema: "identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Users_UpdatedByUserId",
                schema: "core",
                table: "Assets",
                column: "UpdatedByUserId",
                principalSchema: "identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
