using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VegDex.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAddressModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmersMarket_Address_AddressId",
                table: "FarmersMarket");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_FarmersMarket_AddressId",
                table: "FarmersMarket");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "FarmersMarket");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "FarmersMarket",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AboutPage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 4, 6, 9, 55, 22, 405, DateTimeKind.Local).AddTicks(866), new DateTime(2023, 4, 6, 9, 55, 22, 405, DateTimeKind.Local).AddTicks(883) });

            migrationBuilder.UpdateData(
                table: "HomePage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 4, 6, 9, 55, 22, 404, DateTimeKind.Local).AddTicks(1201), new DateTime(2023, 4, 6, 9, 55, 22, 404, DateTimeKind.Local).AddTicks(1246) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "FarmersMarket");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "FarmersMarket",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CityId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    Street1 = table.Column<string>(type: "TEXT", nullable: true),
                    Street2 = table.Column<string>(type: "TEXT", nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AboutPage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 4, 5, 20, 42, 0, 720, DateTimeKind.Local).AddTicks(4900), new DateTime(2023, 4, 5, 20, 42, 0, 720, DateTimeKind.Local).AddTicks(4920) });

            migrationBuilder.UpdateData(
                table: "HomePage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 4, 5, 20, 42, 0, 720, DateTimeKind.Local).AddTicks(100), new DateTime(2023, 4, 5, 20, 42, 0, 720, DateTimeKind.Local).AddTicks(160) });

            migrationBuilder.CreateIndex(
                name: "IX_FarmersMarket_AddressId",
                table: "FarmersMarket",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_FarmersMarket_Address_AddressId",
                table: "FarmersMarket",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
