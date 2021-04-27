using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyStore.Data.Migrations
{
    public partial class AddCustomerController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: false),
                    CustomerEmail = table.Column<string>(nullable: false),
                    CustomerPhoneNo = table.Column<string>(nullable: false),
                    CustomerAddress = table.Column<string>(nullable: false),
                    MemberNo = table.Column<int>(nullable: false),
                    MemberType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
