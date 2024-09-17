using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RG_Store.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EntityFavouriteItem2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Favourites_FavouriteId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_FavouriteId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "FavouriteId",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavouriteId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_FavouriteId",
                table: "Items",
                column: "FavouriteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Favourites_FavouriteId",
                table: "Items",
                column: "FavouriteId",
                principalTable: "Favourites",
                principalColumn: "Id");
        }
    }
}
