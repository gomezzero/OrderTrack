using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderTrack.Migrations
{
    /// <inheritdoc />
    public partial class fixOfCategoryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_category_id",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_category_id",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "category_id1",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_category_id1",
                table: "products",
                column: "category_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_category_id1",
                table: "products",
                column: "category_id1",
                principalTable: "categories",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_category_id1",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_category_id1",
                table: "products");

            migrationBuilder.DropColumn(
                name: "category_id1",
                table: "products");

            migrationBuilder.CreateIndex(
                name: "IX_products_category_id",
                table: "products",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_category_id",
                table: "products",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
