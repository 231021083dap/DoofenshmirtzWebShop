using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoofenshmirtzsWebShop.Migrations
{
    public partial class products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "orderItemId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "orderItemsorderItemID",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    orderItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderItemQuantity = table.Column<int>(type: "int", nullable: false),
                    orderItemPrice = table.Column<int>(type: "int", nullable: false),
                    orderID = table.Column<int>(type: "int", nullable: false),
                    productID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.orderItemID);
                });

            migrationBuilder.UpdateData(
                table: "Address",
                keyColumn: "addressID",
                keyValue: 1,
                columns: new[] { "addressCountryName", "addressCustomerName", "addressStreetName", "userID" },
                values: new object[] { "TriState Area", "Pinky the Chihuahua", "2034 Danville Avenue", 2 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "orderID",
                keyValue: 1,
                column: "orderDate",
                value: new DateTime(2021, 9, 21, 13, 33, 11, 860, DateTimeKind.Local).AddTicks(5797));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "orderID",
                keyValue: 2,
                column: "orderDate",
                value: new DateTime(2021, 9, 21, 13, 33, 11, 865, DateTimeKind.Local).AddTicks(410));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "orderID",
                keyValue: 3,
                column: "orderDate",
                value: new DateTime(2021, 9, 21, 13, 33, 11, 865, DateTimeKind.Local).AddTicks(476));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "userID",
                keyValue: 1,
                columns: new[] { "userEmail", "userName", "userPassword", "userRole" },
                values: new object[] { "doofen@evil.com", "EvilMaster", "DamnYouPerry", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "userID",
                keyValue: 2,
                column: "userEmail",
                value: "perry@platypus.com");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "userID", "userEmail", "userName", "userPassword", "userRole" },
                values: new object[] { 3, "planty@pottedplant.com", "Planty", "Planty1234", 1 });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "addressID", "addressCountryName", "addressCustomerName", "addressPostalCode", "addressStreetName", "userID" },
                values: new object[] { 2, "TriState Area", "Planty the PottedPlant", 6969, "1001 Danville Boulevard", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Order_orderItemsorderItemID",
                table: "Order",
                column: "orderItemsorderItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderItem_orderItemsorderItemID",
                table: "Order",
                column: "orderItemsorderItemID",
                principalTable: "OrderItem",
                principalColumn: "orderItemID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderItem_orderItemsorderItemID",
                table: "Order");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_Order_orderItemsorderItemID",
                table: "Order");

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "addressID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "userID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "orderItemId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "orderItemsorderItemID",
                table: "Order");

            migrationBuilder.UpdateData(
                table: "Address",
                keyColumn: "addressID",
                keyValue: 1,
                columns: new[] { "addressCountryName", "addressCustomerName", "addressStreetName", "userID" },
                values: new object[] { "Carkeys", "Test McTesting", "Danville 101", 1 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "orderID",
                keyValue: 1,
                column: "orderDate",
                value: new DateTime(2021, 9, 17, 14, 30, 46, 990, DateTimeKind.Local).AddTicks(3747));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "orderID",
                keyValue: 2,
                column: "orderDate",
                value: new DateTime(2021, 9, 17, 14, 30, 46, 992, DateTimeKind.Local).AddTicks(3024));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "orderID",
                keyValue: 3,
                column: "orderDate",
                value: new DateTime(2021, 9, 17, 14, 30, 46, 992, DateTimeKind.Local).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "userID",
                keyValue: 1,
                columns: new[] { "userEmail", "userName", "userPassword", "userRole" },
                values: new object[] { "test@test.dk", "Test101", "Test1234", 1 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "userID",
                keyValue: 2,
                column: "userEmail",
                value: "perry@platypus.dk");
        }
    }
}
