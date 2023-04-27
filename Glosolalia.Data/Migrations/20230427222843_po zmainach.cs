using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Glosolalia.Data.Migrations
{
    /// <inheritdoc />
    public partial class pozmainach : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartsOfSpeech",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsOfSpeech", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    PartOfSpeechId = table.Column<int>(type: "int", nullable: false),
                    LastInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnWords_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnWords_PartsOfSpeech_PartOfSpeechId",
                        column: x => x.PartOfSpeechId,
                        principalTable: "PartsOfSpeech",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    PartOfSpeechId = table.Column<int>(type: "int", nullable: false),
                    LastInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlWords_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlWords_PartsOfSpeech_PartOfSpeechId",
                        column: x => x.PartOfSpeechId,
                        principalTable: "PartsOfSpeech",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnWordPlWord",
                columns: table => new
                {
                    IdPlWord = table.Column<int>(type: "int", nullable: false),
                    IdEnWord = table.Column<int>(type: "int", nullable: false),
                    EnWordId = table.Column<int>(type: "int", nullable: true),
                    PlWordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnWordPlWord", x => new { x.IdEnWord, x.IdPlWord });
                    table.ForeignKey(
                        name: "FK_EnWordPlWord_EnWords_EnWordId",
                        column: x => x.EnWordId,
                        principalTable: "EnWords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EnWordPlWord_PlWords_PlWordId",
                        column: x => x.PlWordId,
                        principalTable: "PlWords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnWordPlWord_EnWordId",
                table: "EnWordPlWord",
                column: "EnWordId");

            migrationBuilder.CreateIndex(
                name: "IX_EnWordPlWord_PlWordId",
                table: "EnWordPlWord",
                column: "PlWordId");

            migrationBuilder.CreateIndex(
                name: "IX_EnWords_LanguageId",
                table: "EnWords",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_EnWords_PartOfSpeechId",
                table: "EnWords",
                column: "PartOfSpeechId");

            migrationBuilder.CreateIndex(
                name: "IX_PlWords_LanguageId",
                table: "PlWords",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PlWords_PartOfSpeechId",
                table: "PlWords",
                column: "PartOfSpeechId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnWordPlWord");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "EnWords");

            migrationBuilder.DropTable(
                name: "PlWords");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "PartsOfSpeech");
        }
    }
}
