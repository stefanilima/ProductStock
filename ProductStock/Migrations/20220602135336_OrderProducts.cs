using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductStock.Migrations
{
    public partial class OrderProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_IdOrder",
                table: "OrderProducts",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_IdProduct",
                table: "OrderProducts",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Orders_IdOrder",
                table: "OrderProducts",
                column: "IdOrder",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Products_IdProduct",
                table: "OrderProducts",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Orders_IdOrder",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Products_IdProduct",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_IdOrder",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_IdProduct",
                table: "OrderProducts");
        }
    }
}
