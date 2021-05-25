using Microsoft.EntityFrameworkCore.Migrations;

namespace ozdilekteyim.Migrations
{
    public partial class ee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopPHPID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShopPHPName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShopPHPState",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShopPHPID",
                table: "Markets");

            migrationBuilder.DropColumn(
                name: "ShopPHPName",
                table: "Markets");

            migrationBuilder.DropColumn(
                name: "ShopPHPState",
                table: "Markets");

            migrationBuilder.DropColumn(
                name: "ShopPHPID",
                table: "KategoriAddresses");

            migrationBuilder.DropColumn(
                name: "ShopPHPName",
                table: "KategoriAddresses");

            migrationBuilder.DropColumn(
                name: "ShopPHPState",
                table: "KategoriAddresses");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "EngCategories");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "ArapCategories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShopPHPID",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShopPHPName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShopPHPState",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ShopPHPID",
                table: "Markets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShopPHPName",
                table: "Markets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShopPHPState",
                table: "Markets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ShopPHPID",
                table: "KategoriAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShopPHPName",
                table: "KategoriAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShopPHPState",
                table: "KategoriAddresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Source",
                table: "EngCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Source",
                table: "ArapCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
