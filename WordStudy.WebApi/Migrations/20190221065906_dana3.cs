using Microsoft.EntityFrameworkCore.Migrations;

namespace WordStudy.WebApi.Migrations
{
    public partial class dana3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "columnq",
                schema: "EWSDB",
                table: "Word",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "columnq",
                schema: "EWSDB",
                table: "Word");
        }
    }
}
