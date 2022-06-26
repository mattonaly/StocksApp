using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StocksApp.Migrations
{
    public partial class UpdateWatchedStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StockLocale",
                table: "WatchedStocks",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "StockLogo",
                table: "WatchedStocks",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "StockName",
                table: "WatchedStocks",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockLocale",
                table: "WatchedStocks");

            migrationBuilder.DropColumn(
                name: "StockLogo",
                table: "WatchedStocks");

            migrationBuilder.DropColumn(
                name: "StockName",
                table: "WatchedStocks");
        }
    }
}
