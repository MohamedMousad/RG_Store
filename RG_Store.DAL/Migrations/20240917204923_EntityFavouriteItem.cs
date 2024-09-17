using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RG_Store.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EntityFavouriteItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Favourites_FavouriteId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FavouriteId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Favourites",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "FavouriteItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FavouriteId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouriteItems_Favourites_FavouriteId",
                        column: x => x.FavouriteId,
                        principalTable: "Favourites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_UserId",
                table: "Favourites",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteItems_FavouriteId",
                table: "FavouriteItems",
                column: "FavouriteId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteItems_ItemId",
                table: "FavouriteItems",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_AspNetUsers_UserId",
                table: "Favourites",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_AspNetUsers_UserId",
                table: "Favourites");

            migrationBuilder.DropTable(
                name: "FavouriteItems");

            migrationBuilder.DropIndex(
                name: "IX_Favourites_UserId",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Favourites");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavouriteId",
                table: "AspNetUsers",
                column: "FavouriteId",
                unique: true,
                filter: "[FavouriteId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Favourites_FavouriteId",
                table: "AspNetUsers",
                column: "FavouriteId",
                principalTable: "Favourites",
                principalColumn: "Id");
        }
    }
}
