using Microsoft.EntityFrameworkCore.Migrations;

namespace ozdilekteyim.Migrations
{
    public partial class pathıd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathID",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathID",
                table: "Categories");
        }
    }
}
