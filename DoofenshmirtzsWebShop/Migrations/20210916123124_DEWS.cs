using Microsoft.EntityFrameworkCore.Migrations;

namespace DoofenshmirtzsWebShop.Migrations
{
    public partial class DEWS : Migration
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
                values: new object[] { 1, "test@test.dk", "Test101", "Test1234", 1 });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "addressID", "addressCountryName", "addressCustomerName", "addressPostalCode", "addressStreetName", "userID" },
                values: new object[] { 1, "Carkeys", "Test McTesting", 6969, "Danville 101", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Address_userID",
                table: "Address",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
