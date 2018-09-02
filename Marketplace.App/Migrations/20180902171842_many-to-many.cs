using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Marketplace.App.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Markets_Products_ProductId",
                table: "Markets");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Markets_MarketId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MarketId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Markets_ProductId",
                table: "Markets");

            migrationBuilder.DropColumn(
                name: "MarketId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Markets");

            migrationBuilder.CreateTable(
                name: "MarketProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MarketId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketProduct_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarketProduct_MarketId",
                table: "MarketProduct",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketProduct_ProductId",
                table: "MarketProduct",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketProduct");

            migrationBuilder.AddColumn<int>(
                name: "MarketId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Markets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MarketId",
                table: "Products",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_Markets_ProductId",
                table: "Markets",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Markets_Products_ProductId",
                table: "Markets",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Markets_MarketId",
                table: "Products",
                column: "MarketId",
                principalTable: "Markets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
