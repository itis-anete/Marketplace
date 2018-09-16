using Microsoft.EntityFrameworkCore.Migrations;

namespace Marketplace.Infrastructure.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserUId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserUId",
                table: "MarketProducts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UId = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserUId",
                table: "Products",
                column: "UserUId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketProducts_UserUId",
                table: "MarketProducts",
                column: "UserUId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketProducts_Users_UserUId",
                table: "MarketProducts",
                column: "UserUId",
                principalTable: "Users",
                principalColumn: "UId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserUId",
                table: "Products",
                column: "UserUId",
                principalTable: "Users",
                principalColumn: "UId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketProducts_Users_UserUId",
                table: "MarketProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserUId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserUId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_MarketProducts_UserUId",
                table: "MarketProducts");

            migrationBuilder.DropColumn(
                name: "UserUId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserUId",
                table: "MarketProducts");
        }
    }
}
