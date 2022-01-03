using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BagLib.Migrations
{
    public partial class myStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BagUser",
                columns: table => new
                {
                    BagUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagUser", x => x.BagUserId);
                });

            migrationBuilder.CreateTable(
                name: "MyStock",
                columns: table => new
                {
                    MyStockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    BuyPrice = table.Column<double>(type: "float", nullable: false),
                    BuyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    BagUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyStock", x => x.MyStockId);
                    table.ForeignKey(
                        name: "FK_MyStock_BagUser_BagUserId",
                        column: x => x.BagUserId,
                        principalTable: "BagUser",
                        principalColumn: "BagUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyStock_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "Stock",
                        principalColumn: "StockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyStock_BagUserId",
                table: "MyStock",
                column: "BagUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MyStock_StockId",
                table: "MyStock",
                column: "StockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyStock");

            migrationBuilder.DropTable(
                name: "BagUser");
        }
    }
}
