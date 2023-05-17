using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Glosolalia.Data.Migrations
{
    /// <inheritdoc />
    public partial class EasyDB201 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LanguageTranslation_Translation_TranslationSetId",
                table: "LanguageTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Translation_TranslationId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Translation_PartsOfSpeech_PartOfSpeechId",
                table: "Translation");

            migrationBuilder.DropForeignKey(
                name: "FK_Translation_SheetSet_SheetId",
                table: "Translation");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_Translation_TranslationId",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Translation",
                table: "Translation");

            migrationBuilder.RenameTable(
                name: "Translation",
                newName: "TranslationSet");

            migrationBuilder.RenameIndex(
                name: "IX_Translation_SheetId",
                table: "TranslationSet",
                newName: "IX_TranslationSet_SheetId");

            migrationBuilder.RenameIndex(
                name: "IX_Translation_PartOfSpeechId",
                table: "TranslationSet",
                newName: "IX_TranslationSet_PartOfSpeechId");

            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "TranslationSet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TranslationSet",
                table: "TranslationSet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageTranslation_TranslationSet_TranslationSetId",
                table: "LanguageTranslation",
                column: "TranslationSetId",
                principalTable: "TranslationSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_TranslationSet_TranslationId",
                table: "Tags",
                column: "TranslationId",
                principalTable: "TranslationSet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslationSet_PartsOfSpeech_PartOfSpeechId",
                table: "TranslationSet",
                column: "PartOfSpeechId",
                principalTable: "PartsOfSpeech",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslationSet_SheetSet_SheetId",
                table: "TranslationSet",
                column: "SheetId",
                principalTable: "SheetSet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_TranslationSet_TranslationId",
                table: "Words",
                column: "TranslationId",
                principalTable: "TranslationSet",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LanguageTranslation_TranslationSet_TranslationSetId",
                table: "LanguageTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_TranslationSet_TranslationId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslationSet_PartsOfSpeech_PartOfSpeechId",
                table: "TranslationSet");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslationSet_SheetSet_SheetId",
                table: "TranslationSet");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_TranslationSet_TranslationId",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TranslationSet",
                table: "TranslationSet");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "TranslationSet");

            migrationBuilder.RenameTable(
                name: "TranslationSet",
                newName: "Translation");

            migrationBuilder.RenameIndex(
                name: "IX_TranslationSet_SheetId",
                table: "Translation",
                newName: "IX_Translation_SheetId");

            migrationBuilder.RenameIndex(
                name: "IX_TranslationSet_PartOfSpeechId",
                table: "Translation",
                newName: "IX_Translation_PartOfSpeechId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translation",
                table: "Translation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageTranslation_Translation_TranslationSetId",
                table: "LanguageTranslation",
                column: "TranslationSetId",
                principalTable: "Translation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Translation_TranslationId",
                table: "Tags",
                column: "TranslationId",
                principalTable: "Translation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_PartsOfSpeech_PartOfSpeechId",
                table: "Translation",
                column: "PartOfSpeechId",
                principalTable: "PartsOfSpeech",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_SheetSet_SheetId",
                table: "Translation",
                column: "SheetId",
                principalTable: "SheetSet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Translation_TranslationId",
                table: "Words",
                column: "TranslationId",
                principalTable: "Translation",
                principalColumn: "Id");
        }
    }
}
