using Microsoft.EntityFrameworkCore.Migrations;

namespace WordStudy.WebApi.Migrations
{
    public partial class deneme2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deneme2",
                schema: "EWSDB",
                table: "Word",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deneme2",
                schema: "EWSDB",
                table: "Word");
        }
    }
}
