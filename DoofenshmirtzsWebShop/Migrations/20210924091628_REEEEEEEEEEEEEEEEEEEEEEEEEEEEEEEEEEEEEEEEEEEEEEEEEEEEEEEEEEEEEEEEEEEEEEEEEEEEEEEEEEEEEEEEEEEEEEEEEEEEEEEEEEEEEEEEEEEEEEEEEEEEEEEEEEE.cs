using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoofenshmirtzsWebShop.Migrations
{
    public partial class REEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "orderID",
                keyValue: 1,
                column: "orderDate",
                value: new DateTime(2021, 9, 24, 11, 16, 27, 778, DateTimeKind.Local).AddTicks(6402));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "orderID",
                keyValue: 2,
                column: "orderDate",
                value: new DateTime(2021, 9, 24, 11, 16, 27, 781, DateTimeKind.Local).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "orderID",
                keyValue: 3,
                column: "orderDate",
                value: new DateTime(2021, 9, 24, 11, 16, 27, 781, DateTimeKind.Local).AddTicks(2326));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
