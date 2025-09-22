using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventorySales.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedDescriptionAndIsActiveColumnsToIdentityRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "identity",
                table: "Roles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "identity",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRole",
                schema: "identity");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "identity",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "identity",
                table: "Roles");
        }
    }
}
