using Microsoft.EntityFrameworkCore.Migrations;

namespace BagLib.Migrations
{
    public partial class Currencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyType",
                table: "Country");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Market",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "CountryCurrency",
                columns: table => new
                {
                    CountriesCountryId = table.Column<int>(type: "int", nullable: false),
                    CurrenciesCurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCurrency", x => new { x.CountriesCountryId, x.CurrenciesCurrencyId });
                    table.ForeignKey(
                        name: "FK_CountryCurrency_Country_CountriesCountryId",
                        column: x => x.CountriesCountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryCurrency_Currency_CurrenciesCurrencyId",
                        column: x => x.CurrenciesCurrencyId,
                        principalTable: "Currency",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Market_CountryId",
                table: "Market",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Market_CurrencyId",
                table: "Market",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryCurrency_CurrenciesCurrencyId",
                table: "CountryCurrency",
                column: "CurrenciesCurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Market_Country_CountryId",
                table: "Market",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Market_Currency_CurrencyId",
                table: "Market",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Market_Country_CountryId",
                table: "Market");

            migrationBuilder.DropForeignKey(
                name: "FK_Market_Currency_CurrencyId",
                table: "Market");

            migrationBuilder.DropTable(
                name: "CountryCurrency");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropIndex(
                name: "IX_Market_CountryId",
                table: "Market");

            migrationBuilder.DropIndex(
                name: "IX_Market_CurrencyId",
                table: "Market");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Market");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyType",
                table: "Country",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
