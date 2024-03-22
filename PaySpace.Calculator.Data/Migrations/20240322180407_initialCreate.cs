using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PaySpace.Calculator.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculatorHistories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Income = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Calculator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculatorHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalculatorSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calculator = table.Column<int>(type: "int", nullable: false),
                    RateType = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    From = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    To = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculatorSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostalCodes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calculator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalCodes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CalculatorSettings",
                columns: new[] { "Id", "Calculator", "From", "Rate", "RateType", "To" },
                values: new object[,]
                {
                    { 1L, 1, 0m, 10m, 0, 8350m },
                    { 2L, 1, 8351m, 15m, 0, 33950m },
                    { 3L, 1, 33951m, 25m, 0, 82250m },
                    { 4L, 1, 82251m, 28m, 0, 171550m },
                    { 5L, 1, 171551m, 33m, 0, 372950m },
                    { 6L, 1, 372951m, 35m, 0, 79228162514264337593543950335m },
                    { 7L, 2, 0m, 5m, 0, 199999m },
                    { 8L, 2, 200000m, 10000m, 1, 79228162514264337593543950335m },
                    { 9L, 3, 0m, 17.5m, 0, 79228162514264337593543950335m }
                });

            migrationBuilder.InsertData(
                table: "PostalCodes",
                columns: new[] { "Id", "Calculator", "Code" },
                values: new object[,]
                {
                    { 1L, 1, "7441" },
                    { 2L, 2, "A100" },
                    { 3L, 3, "7000" },
                    { 4L, 1, "1000" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculatorHistories");

            migrationBuilder.DropTable(
                name: "CalculatorSettings");

            migrationBuilder.DropTable(
                name: "PostalCodes");
        }
    }
}
