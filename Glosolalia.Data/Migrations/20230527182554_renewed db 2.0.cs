using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Glosolalia.Data.Migrations
{
    /// <inheritdoc />
    public partial class reneweddb20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LanguageSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageSet", x => x.Id);
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
                name: "SheetSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEdit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheetSet", x => x.Id);
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
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_LanguageSet_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "LanguageSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TranslationSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    PartOfSpeechId = table.Column<int>(type: "int", nullable: true),
                    LastInput = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslationSet_PartsOfSpeech_PartOfSpeechId",
                        column: x => x.PartOfSpeechId,
                        principalTable: "PartsOfSpeech",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SheetTranslation",
                columns: table => new
                {
                    SheetSetId = table.Column<int>(type: "int", nullable: false),
                    TranslationSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheetTranslation", x => new { x.SheetSetId, x.TranslationSetId });
                    table.ForeignKey(
                        name: "FK_SheetTranslation_SheetSet_SheetSetId",
                        column: x => x.SheetSetId,
                        principalTable: "SheetSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SheetTranslation_TranslationSet_TranslationSetId",
                        column: x => x.TranslationSetId,
                        principalTable: "TranslationSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagTranslation",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "int", nullable: false),
                    TranslationSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagTranslation", x => new { x.TagsId, x.TranslationSetId });
                    table.ForeignKey(
                        name: "FK_TagTranslation_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagTranslation_TranslationSet_TranslationSetId",
                        column: x => x.TranslationSetId,
                        principalTable: "TranslationSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TranslationWord",
                columns: table => new
                {
                    TranslationSetId = table.Column<int>(type: "int", nullable: false),
                    WordSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationWord", x => new { x.TranslationSetId, x.WordSetId });
                    table.ForeignKey(
                        name: "FK_TranslationWord_TranslationSet_TranslationSetId",
                        column: x => x.TranslationSetId,
                        principalTable: "TranslationSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TranslationWord_Words_WordSetId",
                        column: x => x.WordSetId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageSet_Name",
                table: "LanguageSet",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SheetSet_Name",
                table: "SheetSet",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SheetTranslation_TranslationSetId",
                table: "SheetTranslation",
                column: "TranslationSetId");

            migrationBuilder.CreateIndex(
                name: "IX_TagTranslation_TranslationSetId",
                table: "TagTranslation",
                column: "TranslationSetId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationSet_PartOfSpeechId",
                table: "TranslationSet",
                column: "PartOfSpeechId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationWord_WordSetId",
                table: "TranslationWord",
                column: "WordSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_LanguageId_Value",
                table: "Words",
                columns: new[] { "LanguageId", "Value" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SheetTranslation");

            migrationBuilder.DropTable(
                name: "TagTranslation");

            migrationBuilder.DropTable(
                name: "TranslationWord");

            migrationBuilder.DropTable(
                name: "SheetSet");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "TranslationSet");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "PartsOfSpeech");

            migrationBuilder.DropTable(
                name: "LanguageSet");
        }
    }
}
