using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RG_Store.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryAndFavourite3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DelivaryId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryCost",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DelivaryId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryCost",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
