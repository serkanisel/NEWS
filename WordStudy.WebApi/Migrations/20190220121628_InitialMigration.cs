using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WordStudy.WebApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EWSDB");

            migrationBuilder.CreateTable(
                name: "Usr",
                schema: "EWSDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "Serial", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    SurName = table.Column<string>(maxLength: 100, nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usr", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Word",
                schema: "EWSDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "Serial", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Body = table.Column<string>(maxLength: 1024, nullable: false),
                    Mean = table.Column<string>(maxLength: 1024, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    AddType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Word", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WordOfList",
                schema: "EWSDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "Serial", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    WordID = table.Column<int>(nullable: false),
                    ListID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordOfList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WrdList",
                schema: "EWSDB",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ListName = table.Column<string>(nullable: true),
                    UsrID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WrdList", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usr",
                schema: "EWSDB");

            migrationBuilder.DropTable(
                name: "Word",
                schema: "EWSDB");

            migrationBuilder.DropTable(
                name: "WordOfList",
                schema: "EWSDB");

            migrationBuilder.DropTable(
                name: "WrdList",
                schema: "EWSDB");
        }
    }
}
