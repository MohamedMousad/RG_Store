using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RG_Store.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryAndFavourite1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Favourite_FavouriteId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FavouriteId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FavId",
                table: "AspNetUsers");

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
                name: "FK_AspNetUsers_Favourite_FavouriteId",
                table: "AspNetUsers",
                column: "FavouriteId",
                principalTable: "Favourite",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Favourite_FavouriteId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FavouriteId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "FavouriteId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FavId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavouriteId",
                table: "AspNetUsers",
                column: "FavouriteId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Favourite_FavouriteId",
                table: "AspNetUsers",
                column: "FavouriteId",
                principalTable: "Favourite",
                principalColumn: "Id");
        }
    }
}
