using Microsoft.EntityFrameworkCore.Migrations;

namespace Marketplace.Infrastructure.Migrations
{
    public partial class UpdateProductOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductOffers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ProductOffers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductOffers");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ProductOffers");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                nullable: true);
        }
    }
}
