using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RG_Store.DAL.Migrations
{
    /// <inheritdoc />
    public partial class IntialdB4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Delivaries_Orders_OrderId",
                table: "Delivaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Delivaries",
                table: "Delivaries");

            migrationBuilder.RenameTable(
                name: "Delivaries",
                newName: "Deliveries");

            migrationBuilder.RenameIndex(
                name: "IX_Delivaries_OrderId",
                table: "Deliveries",
                newName: "IX_Deliveries_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deliveries",
                table: "Deliveries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Orders_OrderId",
                table: "Deliveries",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Orders_OrderId",
                table: "Deliveries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deliveries",
                table: "Deliveries");

            migrationBuilder.RenameTable(
                name: "Deliveries",
                newName: "Delivaries");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_OrderId",
                table: "Delivaries",
                newName: "IX_Delivaries_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Delivaries",
                table: "Delivaries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Delivaries_Orders_OrderId",
                table: "Delivaries",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
