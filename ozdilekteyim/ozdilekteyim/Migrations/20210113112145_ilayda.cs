using Microsoft.EntityFrameworkCore.Migrations;

namespace ozdilekteyim.Migrations
{
    public partial class ilayda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductsInBrandsID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductsInBrands",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    ProductAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductBarcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<int>(type: "int", nullable: false),
                    ShopPHPID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopPHPName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopPHPState = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsInBrands", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductsInBrandsID",
                table: "Products",
                column: "ProductsInBrandsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductsInBrands_ProductsInBrandsID",
                table: "Products",
                column: "ProductsInBrandsID",
                principalTable: "ProductsInBrands",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductsInBrands_ProductsInBrandsID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductsInBrands");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductsInBrandsID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductsInBrandsID",
                table: "Products");
        }
    }
}
