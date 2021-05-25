using Microsoft.EntityFrameworkCore.Migrations;

namespace ozdilekteyim.Migrations
{
    public partial class pathıd45 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdadakilerID",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BazaaramedID",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MarulID",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdadakilerID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "BazaaramedID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "MarulID",
                table: "Categories");
        }
    }
}
