using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoofenshmirtzsWebShop.Migrations
{
    public partial class DoofenshmirtzWebShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    categoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.categoryID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userEmail = table.Column<string>(type: "nvarchar(320)", nullable: false),
                    userPassword = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    userRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    productID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    productPrice = table.Column<int>(type: "int", nullable: false),
                    productStock = table.Column<int>(type: "int", nullable: false),
                    productDescription = table.Column<string>(type: "nvarchar(3200)", nullable: true),
                    categoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.productID);
                    table.ForeignKey(
                        name: "FK_Product_Category_categoryID",
                        column: x => x.categoryID,
                        principalTable: "Category",
                        principalColumn: "categoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    addressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    addressCustomerName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    addressStreetName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    addressPostalCode = table.Column<int>(type: "int", nullable: false),
                    addressCountryName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.addressID);
                    table.ForeignKey(
                        name: "FK_Address_User_userID",
                        column: x => x.userID,
                        principalTable: "User",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    orderItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderItemQuantity = table.Column<int>(type: "int", nullable: false),
                    orderItemPrice = table.Column<int>(type: "int", nullable: false),
                    productID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.orderItemID);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_productID",
                        column: x => x.productID,
                        principalTable: "Product",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    productImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productImageImage = table.Column<string>(type: "nvarchar", nullable: false),
                    productImageImageDescription = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    productID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.productImageID);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_productID",
                        column: x => x.productID,
                        principalTable: "Product",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    orderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false),
                    orderItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.orderID);
                    table.ForeignKey(
                        name: "FK_Order_OrderItem_orderItemId",
                        column: x => x.orderItemId,
                        principalTable: "OrderItem",
                        principalColumn: "orderItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_User_userID",
                        column: x => x.userID,
                        principalTable: "User",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "categoryID", "categoryName" },
                values: new object[,]
                {
                    { 1, "Products" },
                    { 2, "Books" },
                    { 3, "Merch" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "userID", "userEmail", "userName", "userPassword", "userRole" },
                values: new object[,]
                {
                    { 1, "doofen@evil.com", "EvilMaster", "DamnYouPerry", 0 },
                    { 2, "perry@platypus.com", "Perry", "Doofenia", 1 },
                    { 3, "planty@pottedplant.com", "Planty", "Planty1234", 1 }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "addressID", "addressCountryName", "addressCustomerName", "addressPostalCode", "addressStreetName", "userID" },
                values: new object[,]
                {
                    { 1, "TriState Area", "Pinky the Chihuahua", 6969, "2034 Danville Avenue", 2 },
                    { 2, "TriState Area", "Planty the PottedPlant", 6969, "1001 Danville Boulevard", 3 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "productID", "categoryID", "productDescription", "productName", "productPrice", "productStock" },
                values: new object[,]
                {
                    { 1, 1, "Tired of listening to meaningless things all the time? try blasting them with this gun and you'll never have to hear them again!", "The I-Don't-Care-Inator", 49, 7 },
                    { 2, 1, "Dr. Heinz Doofenshmirtz' no. 1 guide to everything you need to know about being evil!", "Kill-half-the-people-in-the-world-with-a-snap-Inator", 299, 2 },
                    { 3, 1, "Support your local evil branch with this T-shirt!", "Shut-The-Hell-Up-Inator", 50, 8 }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "orderItemID", "orderItemPrice", "orderItemQuantity", "productID" },
                values: new object[] { 1, 100, 1, 1 });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "orderItemID", "orderItemPrice", "orderItemQuantity", "productID" },
                values: new object[] { 2, 30, 1, 1 });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "orderItemID", "orderItemPrice", "orderItemQuantity", "productID" },
                values: new object[] { 3, 125, 5, 2 });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "orderID", "orderDate", "orderItemId", "userID" },
                values: new object[] { 1, new DateTime(2021, 9, 20, 18, 54, 4, 206, DateTimeKind.Local).AddTicks(2979), 1, 1 });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "orderID", "orderDate", "orderItemId", "userID" },
                values: new object[] { 3, new DateTime(2021, 9, 20, 18, 54, 4, 209, DateTimeKind.Local).AddTicks(4067), 2, 2 });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "orderID", "orderDate", "orderItemId", "userID" },
                values: new object[] { 2, new DateTime(2021, 9, 20, 18, 54, 4, 209, DateTimeKind.Local).AddTicks(4030), 3, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Address_userID",
                table: "Address",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_orderItemId",
                table: "Order",
                column: "orderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_userID",
                table: "Order",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_productID",
                table: "OrderItem",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_categoryID",
                table: "Product",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_productID",
                table: "ProductImage",
                column: "productID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
