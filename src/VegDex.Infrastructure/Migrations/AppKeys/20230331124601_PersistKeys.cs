#nullable disable
using Microsoft.EntityFrameworkCore.Migrations;

namespace VegDex.Infrastructure.Migrations.AppKeys;

/// <inheritdoc />
public partial class PersistKeys : Migration
{
    /// <inheritdoc />
    override protected void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "DataProtectionKeys");
    }
    /// <inheritdoc />
    override protected void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "DataProtectionKeys",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                FriendlyName = table.Column<string>("TEXT", nullable: true),
                Xml = table.Column<string>("TEXT", nullable: true)
            },
            constraints: table => { table.PrimaryKey("PK_DataProtectionKeys", x => x.Id); });
    }
}
