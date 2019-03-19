using Microsoft.EntityFrameworkCore.Migrations;

namespace WordStudy.WebApi.Migrations
{
    public partial class deneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Deneme",
                schema: "EWSDB",
                table: "Word",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deneme",
                schema: "EWSDB",
                table: "Word");
        }
    }
}
