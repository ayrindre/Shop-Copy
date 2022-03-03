using Microsoft.EntityFrameworkCore.Migrations;

namespace infrastructure.Migrations
{
    public partial class moreimg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdMoreImage",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "MoreImages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoreImages_ProductId",
                table: "MoreImages",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoreImages_Products_ProductId",
                table: "MoreImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoreImages_Products_ProductId",
                table: "MoreImages");

            migrationBuilder.DropIndex(
                name: "IX_MoreImages_ProductId",
                table: "MoreImages");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "MoreImages");

            migrationBuilder.AddColumn<string>(
                name: "IdMoreImage",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
