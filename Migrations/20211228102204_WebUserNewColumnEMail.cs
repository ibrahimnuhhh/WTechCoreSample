using Microsoft.EntityFrameworkCore.Migrations;

namespace WTechCoreSample.Migrations
{
    public partial class WebUserNewColumnEMail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EMail",
                table: "WebUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EMail",
                table: "WebUsers");
        }
    }
}
