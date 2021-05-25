using Microsoft.EntityFrameworkCore.Migrations;

namespace ozdilekteyim.Migrations
{
    public partial class tra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArapCategorys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    LanguageCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    Source = table.Column<int>(type: "int", nullable: false),
                    ShopPHPID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopPHPName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopPHPState = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArapCategorys", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ArapCategorys_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArapProducts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopPHPID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopPHPName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopPHPState = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArapProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ArapProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EngCategorys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    LanguageCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    Source = table.Column<int>(type: "int", nullable: false),
                    ShopPHPID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopPHPName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopPHPState = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngCategorys", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EngCategorys_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EngProducts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopPHPID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopPHPName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopPHPState = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EngProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RusCategorys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    LanguageCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    Source = table.Column<int>(type: "int", nullable: false),
                    ShopPHPID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopPHPName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopPHPState = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RusCategorys", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RusCategorys_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RusProducts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopPHPID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopPHPName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopPHPState = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RusProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RusProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArapCategorys_CategoryID",
                table: "ArapCategorys",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ArapProducts_ProductID",
                table: "ArapProducts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_EngCategorys_CategoryID",
                table: "EngCategorys",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_EngProducts_ProductID",
                table: "EngProducts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_RusCategorys_CategoryID",
                table: "RusCategorys",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_RusProducts_ProductID",
                table: "RusProducts",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArapCategorys");

            migrationBuilder.DropTable(
                name: "ArapProducts");

            migrationBuilder.DropTable(
                name: "EngCategorys");

            migrationBuilder.DropTable(
                name: "EngProducts");

            migrationBuilder.DropTable(
                name: "RusCategorys");

            migrationBuilder.DropTable(
                name: "RusProducts");
        }
    }
}
