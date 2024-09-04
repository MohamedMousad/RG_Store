using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pro.Migrations
{
    /// <inheritdoc />
    public partial class dbproo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adminemail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminpassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    itemid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    itemPrice = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.itemid);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    useremail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userpassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    useraddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userphone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usergender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orederDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderCost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderDeliveryDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false),
                    itemid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderid);
                    table.ForeignKey(
                        name: "FK_Orders_Items_itemid",
                        column: x => x.itemid,
                        principalTable: "Items",
                        principalColumn: "itemid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_itemid",
                table: "Orders",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_userid",
                table: "Orders",
                column: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
