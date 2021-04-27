using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyStore.Data.Migrations
{
    public partial class PurchaseInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    PurchaseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    PurchaseBillNo = table.Column<int>(nullable: false),
                    VendorName = table.Column<string>(nullable: false),
                    PurchaseTotalAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.PurchaseID);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetail",
                columns: table => new
                {
                    PurchaseDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: false),
                    PurchaseID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    PurchasePrice = table.Column<int>(nullable: false),
                    ManufacturedDate = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetail", x => x.PurchaseDetailID);
                    table.ForeignKey(
                        name: "FK_PurchaseDetail_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseDetail_Purchase_PurchaseID",
                        column: x => x.PurchaseID,
                        principalTable: "Purchase",
                        principalColumn: "PurchaseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetail_ProductID",
                table: "PurchaseDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetail_PurchaseID",
                table: "PurchaseDetail",
                column: "PurchaseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseDetail");

            migrationBuilder.DropTable(
                name: "Purchase");
        }
    }
}
