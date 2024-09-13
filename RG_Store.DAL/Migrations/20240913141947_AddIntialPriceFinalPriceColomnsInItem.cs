using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RG_Store.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddIntialPriceFinalPriceColomnsInItem : Migration
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

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Items");

            migrationBuilder.AddColumn<decimal>(
                name: "FinalPrice",
                table: "Items",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "IntialPrice",
                table: "Items",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FavouriteId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Favourites_FavouriteId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FavouriteId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FinalPrice",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IntialPrice",
                table: "Items");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "FavouriteId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavouriteId",
                table: "AspNetUsers",
                column: "FavouriteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Favourites_FavouriteId",
                table: "AspNetUsers",
                column: "FavouriteId",
                principalTable: "Favourites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
