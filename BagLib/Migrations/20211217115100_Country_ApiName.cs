﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BagLib.Migrations
{
    public partial class Country_ApiName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApiName",
                table: "Country",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApiName",
                table: "Country");
        }
    }
}
