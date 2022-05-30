using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductStock.Migrations
{
    public partial class CreatedRelationProductCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCategory",
                table: "Products",
                column: "IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categorys_IdCategory",
                table: "Products",
                column: "IdCategory",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categorys_IdCategory",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdCategory",
                table: "Products");
        }
    }
}
