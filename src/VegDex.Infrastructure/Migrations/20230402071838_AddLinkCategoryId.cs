using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VegDex.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLinkCategoryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_LinkCategory_CategoryId",
                table: "Link");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Link",
                newName: "LinkCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Link_CategoryId",
                table: "Link",
                newName: "IX_Link_LinkCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_LinkCategory_LinkCategoryId",
                table: "Link",
                column: "LinkCategoryId",
                principalTable: "LinkCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_LinkCategory_LinkCategoryId",
                table: "Link");

            migrationBuilder.RenameColumn(
                name: "LinkCategoryId",
                table: "Link",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Link_LinkCategoryId",
                table: "Link",
                newName: "IX_Link_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_LinkCategory_CategoryId",
                table: "Link",
                column: "CategoryId",
                principalTable: "LinkCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
