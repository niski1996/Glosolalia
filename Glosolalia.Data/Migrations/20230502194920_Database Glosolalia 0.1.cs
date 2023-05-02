using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Glosolalia.Data.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseGlosolalia01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartsOfSpeech",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsOfSpeech", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PartOfSpeechId = table.Column<int>(type: "int", nullable: true),
                    LastInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnWords_PartsOfSpeech_PartOfSpeechId",
                        column: x => x.PartOfSpeechId,
                        principalTable: "PartsOfSpeech",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PartOfSpeechId = table.Column<int>(type: "int", nullable: true),
                    LastInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlWords_PartsOfSpeech_PartOfSpeechId",
                        column: x => x.PartOfSpeechId,
                        principalTable: "PartsOfSpeech",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EnWordPlWord",
                columns: table => new
                {
                    EnWordsId = table.Column<int>(type: "int", nullable: false),
                    PlWordsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnWordPlWord", x => new { x.EnWordsId, x.PlWordsId });
                    table.ForeignKey(
                        name: "FK_EnWordPlWord_EnWords_EnWordsId",
                        column: x => x.EnWordsId,
                        principalTable: "EnWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnWordPlWord_PlWords_PlWordsId",
                        column: x => x.PlWordsId,
                        principalTable: "PlWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    EnWordId = table.Column<int>(type: "int", nullable: true),
                    PlWordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_EnWords_EnWordId",
                        column: x => x.EnWordId,
                        principalTable: "EnWords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tags_PlWords_PlWordId",
                        column: x => x.PlWordId,
                        principalTable: "PlWords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnWordPlWord_PlWordsId",
                table: "EnWordPlWord",
                column: "PlWordsId");

            migrationBuilder.CreateIndex(
                name: "IX_EnWords_LastInput",
                table: "EnWords",
                column: "LastInput");

            migrationBuilder.CreateIndex(
                name: "IX_EnWords_PartOfSpeechId",
                table: "EnWords",
                column: "PartOfSpeechId");

            migrationBuilder.CreateIndex(
                name: "IX_EnWords_Progress",
                table: "EnWords",
                column: "Progress");

            migrationBuilder.CreateIndex(
                name: "IX_EnWords_Value",
                table: "EnWords",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlWords_LastInput",
                table: "PlWords",
                column: "LastInput");

            migrationBuilder.CreateIndex(
                name: "IX_PlWords_PartOfSpeechId",
                table: "PlWords",
                column: "PartOfSpeechId");

            migrationBuilder.CreateIndex(
                name: "IX_PlWords_Progress",
                table: "PlWords",
                column: "Progress");

            migrationBuilder.CreateIndex(
                name: "IX_PlWords_Value",
                table: "PlWords",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_EnWordId",
                table: "Tags",
                column: "EnWordId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_PlWordId",
                table: "Tags",
                column: "PlWordId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Value",
                table: "Tags",
                column: "Value",
                unique: true);
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
                name: "PartsOfSpeech");
        }
    }
}
