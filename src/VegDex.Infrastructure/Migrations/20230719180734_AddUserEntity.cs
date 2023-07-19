using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VegDex.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AboutPage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 7, 19, 13, 7, 33, 484, DateTimeKind.Local).AddTicks(3410), new DateTime(2023, 7, 19, 13, 7, 33, 484, DateTimeKind.Local).AddTicks(3480) });

            migrationBuilder.UpdateData(
                table: "HomePage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 7, 19, 13, 7, 33, 482, DateTimeKind.Local).AddTicks(8720), new DateTime(2023, 7, 19, 13, 7, 33, 482, DateTimeKind.Local).AddTicks(8810) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "AboutPage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 4, 6, 11, 47, 25, 900, DateTimeKind.Local).AddTicks(6009), new DateTime(2023, 4, 6, 11, 47, 25, 900, DateTimeKind.Local).AddTicks(6024) });

            migrationBuilder.UpdateData(
                table: "HomePage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 4, 6, 11, 47, 25, 900, DateTimeKind.Local).AddTicks(113), new DateTime(2023, 4, 6, 11, 47, 25, 900, DateTimeKind.Local).AddTicks(162) });
        }
    }
}
