using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VegDex.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceMetaWithSeparateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meta");

            migrationBuilder.CreateTable(
                name: "AboutPage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutPage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomePage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePage", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AboutPage",
                columns: new[] { "Id", "Content", "DateCreated", "DateUpdated" },
                values: new object[] { 1, "VeganMSP.com is a new project from <a href=\"https://jrgnsn.net\" target=\"_blank\">Matthew Jorgensen</a>. Inspired\nby <a href=\"https://veganmilwaukee.com/\" target=\"_blank\">VeganMKE.com</a>, this site aims to be a complete-as-possible\nguide to being vegan in and around the Minneapolis/St. Paul area. But\nwe're always welcome to suggestions! Find something wrong? Feel free to\n<a href=\"https://github.com/VeganMSP/VeganMSP.com/issues\">open a ticket</a> on our tracker.", new DateTime(2023, 4, 5, 20, 42, 0, 720, DateTimeKind.Local).AddTicks(4900), new DateTime(2023, 4, 5, 20, 42, 0, 720, DateTimeKind.Local).AddTicks(4920) });

            migrationBuilder.InsertData(
                table: "HomePage",
                columns: new[] { "Id", "Content", "DateCreated", "DateUpdated" },
                values: new object[] { 1, "It’s easy being vegan in Minneapolis and St. Paul, but it can be hard to\nknow where to start, or where to look for information and answers. We\naim to fix that.\n\nAt VeganMSP.com you will find restaurant and food guides, shopping\nguides, and other information to help you on your vegan journey.", new DateTime(2023, 4, 5, 20, 42, 0, 720, DateTimeKind.Local).AddTicks(100), new DateTime(2023, 4, 5, 20, 42, 0, 720, DateTimeKind.Local).AddTicks(160) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutPage");

            migrationBuilder.DropTable(
                name: "HomePage");

            migrationBuilder.CreateTable(
                name: "Meta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AboutPage = table.Column<string>(type: "TEXT", nullable: false),
                    AboutPageCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AboutPageLastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HomePage = table.Column<string>(type: "TEXT", nullable: false),
                    HomePageCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HomePageLastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meta", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Meta",
                columns: new[] { "Id", "AboutPage", "AboutPageCreated", "AboutPageLastUpdated", "HomePage", "HomePageCreated", "HomePageLastUpdated" },
                values: new object[] { 1, "VeganMSP.com is a new project from <a href=\"https://jrgnsn.net\" target=\"_blank\">Matthew Jorgensen</a>. Inspired\nby <a href=\"https://veganmilwaukee.com/\" target=\"_blank\">VeganMKE.com</a>, this site aims to be a complete-as-possible\nguide to being vegan in and around the Minneapolis/St. Paul area. But\nwe're always welcome to suggestions! Find something wrong? Feel free to\n<a href=\"https://github.com/VeganMSP/VeganMSP.com/issues\">open a ticket</a> on our tracker.", new DateTime(2023, 4, 5, 20, 19, 1, 971, DateTimeKind.Local).AddTicks(5660), new DateTime(2023, 4, 5, 20, 19, 1, 971, DateTimeKind.Local).AddTicks(5670), "It’s easy being vegan in Minneapolis and St. Paul, but it can be hard to\nknow where to start, or where to look for information and answers. We\naim to fix that.\n\nAt VeganMSP.com you will find restaurant and food guides, shopping\nguides, and other information to help you on your vegan journey.", new DateTime(2023, 4, 5, 20, 19, 1, 971, DateTimeKind.Local).AddTicks(5600), new DateTime(2023, 4, 5, 20, 19, 1, 971, DateTimeKind.Local).AddTicks(5660) });
        }
    }
}
