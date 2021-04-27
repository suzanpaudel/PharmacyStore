using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyStore.Data.Migrations
{
    public partial class SalesInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SalesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    SalesDate = table.Column<DateTime>(nullable: false),
                    SalesBillNo = table.Column<string>(nullable: false),
                    SalesTotalAmount = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SalesID);
                    table.ForeignKey(
                        name: "FK_Sales_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesDetail",
                columns: table => new
                {
                    SalesDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: false),
                    SalesID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    SellingPrice = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetail", x => x.SalesDetailID);
                    table.ForeignKey(
                        name: "FK_SalesDetail_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesDetail_Sales_SalesID",
                        column: x => x.SalesID,
                        principalTable: "Sales",
                        principalColumn: "SalesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerID",
                table: "Sales",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetail_ProductID",
                table: "SalesDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetail_SalesID",
                table: "SalesDetail",
                column: "SalesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesDetail");

            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}
