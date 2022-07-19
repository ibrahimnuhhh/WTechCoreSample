using Microsoft.EntityFrameworkCore.Migrations;

namespace WTechCoreSample.Migrations
{
    public partial class MenuTableSortColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortNumber",
                table: "Menus",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortNumber",
                table: "Menus");
        }
    }
}
