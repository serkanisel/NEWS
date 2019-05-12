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
                    PasswordSalt = table.Column<byte[]>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Knowns = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Introduction = table.Column<string>(nullable: true),
                    LookingFor = table.Column<string>(nullable: true),
                    Interests = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    LastActive = table.Column<DateTime>(nullable: false)
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
                name: "Photos",
                schema: "EWSDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "Serial", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "WrdList",
                schema: "EWSDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "Serial", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ListName = table.Column<string>(nullable: true),
                    UsrId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WrdList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WrdList_Usr_UsrId",
                        column: x => x.UsrId,
                        principalSchema: "EWSDB",
                        principalTable: "Usr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WordOfList",
                schema: "EWSDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "Serial", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    WordId = table.Column<int>(nullable: true),
                    WrdListId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordOfList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordOfList_Word_WordId",
                        column: x => x.WordId,
                        principalSchema: "EWSDB",
                        principalTable: "Word",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WordOfList_WrdList_WrdListId",
                        column: x => x.WrdListId,
                        principalSchema: "EWSDB",
                        principalTable: "WrdList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UsrId",
                schema: "EWSDB",
                table: "Photos",
                column: "UsrId");

            migrationBuilder.CreateIndex(
                name: "IX_WordOfList_WordId",
                schema: "EWSDB",
                table: "WordOfList",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_WordOfList_WrdListId",
                schema: "EWSDB",
                table: "WordOfList",
                column: "WrdListId");

            migrationBuilder.CreateIndex(
                name: "IX_WrdList_UsrId",
                schema: "EWSDB",
                table: "WrdList",
                column: "UsrId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos",
                schema: "EWSDB");

            migrationBuilder.DropTable(
                name: "WordOfList",
                schema: "EWSDB");

            migrationBuilder.DropTable(
                name: "Word",
                schema: "EWSDB");

            migrationBuilder.DropTable(
                name: "WrdList",
                schema: "EWSDB");

            migrationBuilder.DropTable(
                name: "Usr",
                schema: "EWSDB");
        }
    }
}
