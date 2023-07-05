using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VegDex.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogCategoryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPost_BlogCategory_CategoryId",
                table: "BlogPost");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "BlogPost",
                newName: "BlogCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPost_CategoryId",
                table: "BlogPost",
                newName: "IX_BlogPost_BlogCategoryId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPost_BlogCategory_BlogCategoryId",
                table: "BlogPost",
                column: "BlogCategoryId",
                principalTable: "BlogCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPost_BlogCategory_BlogCategoryId",
                table: "BlogPost");

            migrationBuilder.RenameColumn(
                name: "BlogCategoryId",
                table: "BlogPost",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPost_BlogCategoryId",
                table: "BlogPost",
                newName: "IX_BlogPost_CategoryId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPost_BlogCategory_CategoryId",
                table: "BlogPost",
                column: "CategoryId",
                principalTable: "BlogCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
