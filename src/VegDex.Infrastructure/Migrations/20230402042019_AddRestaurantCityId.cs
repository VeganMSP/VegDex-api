using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VegDex.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRestaurantCityId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_City_LocationId",
                table: "Restaurant");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Restaurant",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurant_LocationId",
                table: "Restaurant",
                newName: "IX_Restaurant_CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_City_CityId",
                table: "Restaurant",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_City_CityId",
                table: "Restaurant");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Restaurant",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurant_CityId",
                table: "Restaurant",
                newName: "IX_Restaurant_LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_City_LocationId",
                table: "Restaurant",
                column: "LocationId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
