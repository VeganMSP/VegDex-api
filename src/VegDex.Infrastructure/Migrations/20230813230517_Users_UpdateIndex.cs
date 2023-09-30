using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VegDex.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Users_UpdateIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AboutPage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 8, 13, 18, 5, 17, 143, DateTimeKind.Local).AddTicks(9710), new DateTime(2023, 8, 13, 18, 5, 17, 143, DateTimeKind.Local).AddTicks(9730) });

            migrationBuilder.UpdateData(
                table: "HomePage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 8, 13, 18, 5, 17, 143, DateTimeKind.Local).AddTicks(2610), new DateTime(2023, 8, 13, 18, 5, 17, 143, DateTimeKind.Local).AddTicks(2680) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Username",
                table: "Users");

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
    }
}
