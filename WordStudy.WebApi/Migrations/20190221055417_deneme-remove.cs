using Microsoft.EntityFrameworkCore.Migrations;

namespace WordStudy.WebApi.Migrations
{
    public partial class denemeremove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deneme",
                schema: "EWSDB",
                table: "Word");

            migrationBuilder.DropColumn(
                name: "Deneme2",
                schema: "EWSDB",
                table: "Word");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Deneme",
                schema: "EWSDB",
                table: "Word",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Deneme2",
                schema: "EWSDB",
                table: "Word",
                nullable: false,
                defaultValue: false);
        }
    }
}
