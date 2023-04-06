using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VegDex.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMeta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HomePage = table.Column<string>(type: "TEXT", nullable: false),
                    AboutPage = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meta", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Meta",
                columns: new[] { "Id", "AboutPage", "HomePage" },
                values: new object[] { 1, "VeganMSP.com is a new project from <a href=\"https://jrgnsn.net\" target=\"_blank\">Matthew Jorgensen</a>. Inspired\nby <a href=\"https://veganmilwaukee.com/\" target=\"_blank\">VeganMKE.com</a>, this site aims to be a complete-as-possible\nguide to being vegan in and around the Minneapolis/St. Paul area. But\nwe're always welcome to suggestions! Find something wrong? Feel free to\n<a href=\"https://github.com/VeganMSP/VeganMSP.com/issues\">open a ticket</a> on our tracker.", "It’s easy being vegan in Minneapolis and St. Paul, but it can be hard to\nknow where to start, or where to look for information and answers. We\naim to fix that.\n\nAt VeganMSP.com you will find restaurant and food guides, shopping\nguides, and other information to help you on your vegan journey." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meta");
        }
    }
}
