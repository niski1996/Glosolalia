using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Glosolalia.Data.Migrations
{
    /// <inheritdoc />
    public partial class EasyDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_EnSentenceSet_EnSentenceId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_EnWords_EnWordId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_EsSentenceSet_EsSentenceId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_EsWords_EsWordId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_PlSentenceSet_PlSentenceId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_PlWords_PlWordId",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "EnSentenceEnWord");

            migrationBuilder.DropTable(
                name: "EnSentenceSheet");

            migrationBuilder.DropTable(
                name: "EnWordPlWord");

            migrationBuilder.DropTable(
                name: "EnWordSheet");

            migrationBuilder.DropTable(
                name: "EsSentenceEsWord");

            migrationBuilder.DropTable(
                name: "EsSentenceSheet");

            migrationBuilder.DropTable(
                name: "EsWordPlWord");

            migrationBuilder.DropTable(
                name: "EsWordSheet");

            migrationBuilder.DropTable(
                name: "PlSentencePlWord");

            migrationBuilder.DropTable(
                name: "EnSentenceSet");

            migrationBuilder.DropTable(
                name: "EnWords");

            migrationBuilder.DropTable(
                name: "EsSentenceSet");

            migrationBuilder.DropTable(
                name: "EsWords");

            migrationBuilder.DropTable(
                name: "PlWords");

            migrationBuilder.DropTable(
                name: "PlSentenceSet");

            migrationBuilder.DropIndex(
                name: "IX_Tags_EnSentenceId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_EnWordId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_EsSentenceId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_EsWordId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_PlSentenceId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_Value",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_SheetSet_Name",
                table: "SheetSet");

            migrationBuilder.DropIndex(
                name: "IX_PartsOfSpeech_Value",
                table: "PartsOfSpeech");

            migrationBuilder.DropColumn(
                name: "EnSentenceId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "EnWordId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "EsSentenceId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "EsWordId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "PlSentenceId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "SheetSet");

            migrationBuilder.RenameColumn(
                name: "PlWordId",
                table: "Tags",
                newName: "TranslationId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_PlWordId",
                table: "Tags",
                newName: "IX_Tags_TranslationId");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SheetSet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "PartsOfSpeech",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "PartsOfSpeech",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Translation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    PartOfSpeechId = table.Column<int>(type: "int", nullable: true),
                    LastInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SheetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translation_PartsOfSpeech_PartOfSpeechId",
                        column: x => x.PartOfSpeechId,
                        principalTable: "PartsOfSpeech",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Translation_SheetSet_SheetId",
                        column: x => x.SheetId,
                        principalTable: "SheetSet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LanguageTranslation",
                columns: table => new
                {
                    LanguageSetId = table.Column<int>(type: "int", nullable: false),
                    TranslationSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageTranslation", x => new { x.LanguageSetId, x.TranslationSetId });
                    table.ForeignKey(
                        name: "FK_LanguageTranslation_Language_LanguageSetId",
                        column: x => x.LanguageSetId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageTranslation_Translation_TranslationSetId",
                        column: x => x.TranslationSetId,
                        principalTable: "Translation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    TranslationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Words_Translation_TranslationId",
                        column: x => x.TranslationId,
                        principalTable: "Translation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageTranslation_TranslationSetId",
                table: "LanguageTranslation",
                column: "TranslationSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_PartOfSpeechId",
                table: "Translation",
                column: "PartOfSpeechId");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_SheetId",
                table: "Translation",
                column: "SheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_LanguageId",
                table: "Words",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_TranslationId",
                table: "Words",
                column: "TranslationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Translation_TranslationId",
                table: "Tags",
                column: "TranslationId",
                principalTable: "Translation",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Translation_TranslationId",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "LanguageTranslation");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Translation");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "PartsOfSpeech");

            migrationBuilder.RenameColumn(
                name: "TranslationId",
                table: "Tags",
                newName: "PlWordId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_TranslationId",
                table: "Tags",
                newName: "IX_Tags_PlWordId");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Tags",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EnSentenceId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnWordId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EsSentenceId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EsWordId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlSentenceId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SheetSet",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "SheetSet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "PartsOfSpeech",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "EnWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartOfSpeechId = table.Column<int>(type: "int", nullable: true),
                    LastInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                name: "EsWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartOfSpeechId = table.Column<int>(type: "int", nullable: true),
                    LastInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EsWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EsWords_PartsOfSpeech_PartOfSpeechId",
                        column: x => x.PartOfSpeechId,
                        principalTable: "PartsOfSpeech",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlSentenceSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlSentenceSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartOfSpeechId = table.Column<int>(type: "int", nullable: true),
                    LastInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                name: "EnWordSheet",
                columns: table => new
                {
                    EnWordSetId = table.Column<int>(type: "int", nullable: false),
                    SheetSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnWordSheet", x => new { x.EnWordSetId, x.SheetSetId });
                    table.ForeignKey(
                        name: "FK_EnWordSheet_EnWords_EnWordSetId",
                        column: x => x.EnWordSetId,
                        principalTable: "EnWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnWordSheet_SheetSet_SheetSetId",
                        column: x => x.SheetSetId,
                        principalTable: "SheetSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EsWordSheet",
                columns: table => new
                {
                    EsWordSetId = table.Column<int>(type: "int", nullable: false),
                    SheetSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EsWordSheet", x => new { x.EsWordSetId, x.SheetSetId });
                    table.ForeignKey(
                        name: "FK_EsWordSheet_EsWords_EsWordSetId",
                        column: x => x.EsWordSetId,
                        principalTable: "EsWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EsWordSheet_SheetSet_SheetSetId",
                        column: x => x.SheetSetId,
                        principalTable: "SheetSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnSentenceSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    plTranslationId = table.Column<int>(type: "int", nullable: false),
                    LastInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnSentenceSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnSentenceSet_PlSentenceSet_plTranslationId",
                        column: x => x.plTranslationId,
                        principalTable: "PlSentenceSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EsSentenceSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    plTranslationId = table.Column<int>(type: "int", nullable: false),
                    LastInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EsSentenceSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EsSentenceSet_PlSentenceSet_plTranslationId",
                        column: x => x.plTranslationId,
                        principalTable: "PlSentenceSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnWordPlWord",
                columns: table => new
                {
                    EnWordsId = table.Column<int>(type: "int", nullable: false),
                    PlWordSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnWordPlWord", x => new { x.EnWordsId, x.PlWordSetId });
                    table.ForeignKey(
                        name: "FK_EnWordPlWord_EnWords_EnWordsId",
                        column: x => x.EnWordsId,
                        principalTable: "EnWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnWordPlWord_PlWords_PlWordSetId",
                        column: x => x.PlWordSetId,
                        principalTable: "PlWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EsWordPlWord",
                columns: table => new
                {
                    EsWordsId = table.Column<int>(type: "int", nullable: false),
                    PlWordSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EsWordPlWord", x => new { x.EsWordsId, x.PlWordSetId });
                    table.ForeignKey(
                        name: "FK_EsWordPlWord_EsWords_EsWordsId",
                        column: x => x.EsWordsId,
                        principalTable: "EsWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EsWordPlWord_PlWords_PlWordSetId",
                        column: x => x.PlWordSetId,
                        principalTable: "PlWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlSentencePlWord",
                columns: table => new
                {
                    PlWordSetId = table.Column<int>(type: "int", nullable: false),
                    SentenceSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlSentencePlWord", x => new { x.PlWordSetId, x.SentenceSetId });
                    table.ForeignKey(
                        name: "FK_PlSentencePlWord_PlSentenceSet_SentenceSetId",
                        column: x => x.SentenceSetId,
                        principalTable: "PlSentenceSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlSentencePlWord_PlWords_PlWordSetId",
                        column: x => x.PlWordSetId,
                        principalTable: "PlWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnSentenceEnWord",
                columns: table => new
                {
                    EnSentenceSetId = table.Column<int>(type: "int", nullable: false),
                    EnWordSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnSentenceEnWord", x => new { x.EnSentenceSetId, x.EnWordSetId });
                    table.ForeignKey(
                        name: "FK_EnSentenceEnWord_EnSentenceSet_EnSentenceSetId",
                        column: x => x.EnSentenceSetId,
                        principalTable: "EnSentenceSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnSentenceEnWord_EnWords_EnWordSetId",
                        column: x => x.EnWordSetId,
                        principalTable: "EnWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnSentenceSheet",
                columns: table => new
                {
                    EnSentenceSetId = table.Column<int>(type: "int", nullable: false),
                    SheetSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnSentenceSheet", x => new { x.EnSentenceSetId, x.SheetSetId });
                    table.ForeignKey(
                        name: "FK_EnSentenceSheet_EnSentenceSet_EnSentenceSetId",
                        column: x => x.EnSentenceSetId,
                        principalTable: "EnSentenceSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnSentenceSheet_SheetSet_SheetSetId",
                        column: x => x.SheetSetId,
                        principalTable: "SheetSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EsSentenceEsWord",
                columns: table => new
                {
                    EsWordSetId = table.Column<int>(type: "int", nullable: false),
                    SentenceSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EsSentenceEsWord", x => new { x.EsWordSetId, x.SentenceSetId });
                    table.ForeignKey(
                        name: "FK_EsSentenceEsWord_EsSentenceSet_SentenceSetId",
                        column: x => x.SentenceSetId,
                        principalTable: "EsSentenceSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EsSentenceEsWord_EsWords_EsWordSetId",
                        column: x => x.EsWordSetId,
                        principalTable: "EsWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EsSentenceSheet",
                columns: table => new
                {
                    EsSentenceSetId = table.Column<int>(type: "int", nullable: false),
                    SheetSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EsSentenceSheet", x => new { x.EsSentenceSetId, x.SheetSetId });
                    table.ForeignKey(
                        name: "FK_EsSentenceSheet_EsSentenceSet_EsSentenceSetId",
                        column: x => x.EsSentenceSetId,
                        principalTable: "EsSentenceSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EsSentenceSheet_SheetSet_SheetSetId",
                        column: x => x.SheetSetId,
                        principalTable: "SheetSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_EnSentenceId",
                table: "Tags",
                column: "EnSentenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_EnWordId",
                table: "Tags",
                column: "EnWordId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_EsSentenceId",
                table: "Tags",
                column: "EsSentenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_EsWordId",
                table: "Tags",
                column: "EsWordId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_PlSentenceId",
                table: "Tags",
                column: "PlSentenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Value",
                table: "Tags",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SheetSet_Name",
                table: "SheetSet",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartsOfSpeech_Value",
                table: "PartsOfSpeech",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnSentenceEnWord_EnWordSetId",
                table: "EnSentenceEnWord",
                column: "EnWordSetId");

            migrationBuilder.CreateIndex(
                name: "IX_EnSentenceSet_LastInput",
                table: "EnSentenceSet",
                column: "LastInput");

            migrationBuilder.CreateIndex(
                name: "IX_EnSentenceSet_plTranslationId",
                table: "EnSentenceSet",
                column: "plTranslationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnSentenceSet_Progress",
                table: "EnSentenceSet",
                column: "Progress");

            migrationBuilder.CreateIndex(
                name: "IX_EnSentenceSheet_SheetSetId",
                table: "EnSentenceSheet",
                column: "SheetSetId");

            migrationBuilder.CreateIndex(
                name: "IX_EnWordPlWord_PlWordSetId",
                table: "EnWordPlWord",
                column: "PlWordSetId");

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
                name: "IX_EnWordSheet_SheetSetId",
                table: "EnWordSheet",
                column: "SheetSetId");

            migrationBuilder.CreateIndex(
                name: "IX_EsSentenceEsWord_SentenceSetId",
                table: "EsSentenceEsWord",
                column: "SentenceSetId");

            migrationBuilder.CreateIndex(
                name: "IX_EsSentenceSet_LastInput",
                table: "EsSentenceSet",
                column: "LastInput");

            migrationBuilder.CreateIndex(
                name: "IX_EsSentenceSet_plTranslationId",
                table: "EsSentenceSet",
                column: "plTranslationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EsSentenceSet_Progress",
                table: "EsSentenceSet",
                column: "Progress");

            migrationBuilder.CreateIndex(
                name: "IX_EsSentenceSet_Value",
                table: "EsSentenceSet",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EsSentenceSheet_SheetSetId",
                table: "EsSentenceSheet",
                column: "SheetSetId");

            migrationBuilder.CreateIndex(
                name: "IX_EsWordPlWord_PlWordSetId",
                table: "EsWordPlWord",
                column: "PlWordSetId");

            migrationBuilder.CreateIndex(
                name: "IX_EsWords_LastInput",
                table: "EsWords",
                column: "LastInput");

            migrationBuilder.CreateIndex(
                name: "IX_EsWords_PartOfSpeechId",
                table: "EsWords",
                column: "PartOfSpeechId");

            migrationBuilder.CreateIndex(
                name: "IX_EsWords_Value",
                table: "EsWords",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EsWordSheet_SheetSetId",
                table: "EsWordSheet",
                column: "SheetSetId");

            migrationBuilder.CreateIndex(
                name: "IX_PlSentencePlWord_SentenceSetId",
                table: "PlSentencePlWord",
                column: "SentenceSetId");

            migrationBuilder.CreateIndex(
                name: "IX_PlSentenceSet_LastInput",
                table: "PlSentenceSet",
                column: "LastInput");

            migrationBuilder.CreateIndex(
                name: "IX_PlSentenceSet_Progress",
                table: "PlSentenceSet",
                column: "Progress");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_EnSentenceSet_EnSentenceId",
                table: "Tags",
                column: "EnSentenceId",
                principalTable: "EnSentenceSet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_EnWords_EnWordId",
                table: "Tags",
                column: "EnWordId",
                principalTable: "EnWords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_EsSentenceSet_EsSentenceId",
                table: "Tags",
                column: "EsSentenceId",
                principalTable: "EsSentenceSet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_EsWords_EsWordId",
                table: "Tags",
                column: "EsWordId",
                principalTable: "EsWords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_PlSentenceSet_PlSentenceId",
                table: "Tags",
                column: "PlSentenceId",
                principalTable: "PlSentenceSet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_PlWords_PlWordId",
                table: "Tags",
                column: "PlWordId",
                principalTable: "PlWords",
                principalColumn: "Id");
        }
    }
}
