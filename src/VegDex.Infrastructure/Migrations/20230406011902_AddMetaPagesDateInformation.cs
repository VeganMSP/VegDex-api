using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VegDex.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMetaPagesDateInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AboutPageCreated",
                table: "Meta",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AboutPageLastUpdated",
                table: "Meta",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HomePageCreated",
                table: "Meta",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HomePageLastUpdated",
                table: "Meta",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Meta",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AboutPageCreated", "AboutPageLastUpdated", "HomePageCreated", "HomePageLastUpdated" },
                values: new object[] { new DateTime(2023, 4, 5, 20, 19, 1, 971, DateTimeKind.Local).AddTicks(5660), new DateTime(2023, 4, 5, 20, 19, 1, 971, DateTimeKind.Local).AddTicks(5670), new DateTime(2023, 4, 5, 20, 19, 1, 971, DateTimeKind.Local).AddTicks(5600), new DateTime(2023, 4, 5, 20, 19, 1, 971, DateTimeKind.Local).AddTicks(5660) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutPageCreated",
                table: "Meta");

            migrationBuilder.DropColumn(
                name: "AboutPageLastUpdated",
                table: "Meta");

            migrationBuilder.DropColumn(
                name: "HomePageCreated",
                table: "Meta");

            migrationBuilder.DropColumn(
                name: "HomePageLastUpdated",
                table: "Meta");
        }
    }
}
