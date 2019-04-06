using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WordStudy.WebApi.Migrations
{
    public partial class UpdateUserAndPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "EWSDB",
                table: "Usr",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                schema: "EWSDB",
                table: "Usr",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "EWSDB",
                table: "Usr",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                schema: "EWSDB",
                table: "Usr",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                schema: "EWSDB",
                table: "Usr",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interests",
                schema: "EWSDB",
                table: "Usr",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                schema: "EWSDB",
                table: "Usr",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActive",
                schema: "EWSDB",
                table: "Usr",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "Serial", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<int>(nullable: false),
                    UsrId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Usr_UsrId",
                        column: x => x.UsrId,
                        principalSchema: "EWSDB",
                        principalTable: "Usr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UsrId",
                table: "Photos",
                column: "UsrId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropColumn(
                name: "City",
                schema: "EWSDB",
                table: "Usr");

            migrationBuilder.DropColumn(
                name: "Country",
                schema: "EWSDB",
                table: "Usr");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "EWSDB",
                table: "Usr");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                schema: "EWSDB",
                table: "Usr");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "EWSDB",
                table: "Usr");

            migrationBuilder.DropColumn(
                name: "Interests",
                schema: "EWSDB",
                table: "Usr");

            migrationBuilder.DropColumn(
                name: "Introduction",
                schema: "EWSDB",
                table: "Usr");

            migrationBuilder.DropColumn(
                name: "LastActive",
                schema: "EWSDB",
                table: "Usr");

         
        }
    }
}
