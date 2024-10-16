using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NimoInfotech.Migrations
{
    public partial class secondcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryModelCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryModelCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryModelCategoryId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategoryModelCategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryModelCategoryId",
                table: "Products",
                column: "CategoryModelCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryModelCategoryId",
                table: "Products",
                column: "CategoryModelCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
