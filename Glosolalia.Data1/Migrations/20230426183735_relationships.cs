using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Glosolalia.Data.Migrations
{
    /// <inheritdoc />
    public partial class relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdLanguage",
                table: "PlWords",
                newName: "PartOfSpeechId");

            migrationBuilder.RenameColumn(
                name: "IdLanguage",
                table: "EnWords",
                newName: "PartOfSpeechId");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "PlWords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "EnWords",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_PlWords_LanguageId",
                table: "PlWords",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PlWords_PartOfSpeechId",
                table: "PlWords",
                column: "PartOfSpeechId");

            migrationBuilder.CreateIndex(
                name: "IX_EnWords_LanguageId",
                table: "EnWords",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_EnWords_PartOfSpeechId",
                table: "EnWords",
                column: "PartOfSpeechId");

            migrationBuilder.CreateIndex(
                name: "IX_EnWordPlWord_EnWordId",
                table: "EnWordPlWord",
                column: "EnWordId");

            migrationBuilder.CreateIndex(
                name: "IX_EnWordPlWord_PlWordId",
                table: "EnWordPlWord",
                column: "PlWordId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnWords_Languages_LanguageId",
                table: "EnWords",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnWords_PartsOfSpeech_PartOfSpeechId",
                table: "EnWords",
                column: "PartOfSpeechId",
                principalTable: "PartsOfSpeech",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlWords_Languages_LanguageId",
                table: "PlWords",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlWords_PartsOfSpeech_PartOfSpeechId",
                table: "PlWords",
                column: "PartOfSpeechId",
                principalTable: "PartsOfSpeech",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnWords_Languages_LanguageId",
                table: "EnWords");

            migrationBuilder.DropForeignKey(
                name: "FK_EnWords_PartsOfSpeech_PartOfSpeechId",
                table: "EnWords");

            migrationBuilder.DropForeignKey(
                name: "FK_PlWords_Languages_LanguageId",
                table: "PlWords");

            migrationBuilder.DropForeignKey(
                name: "FK_PlWords_PartsOfSpeech_PartOfSpeechId",
                table: "PlWords");

            migrationBuilder.DropTable(
                name: "EnWordPlWord");

            migrationBuilder.DropIndex(
                name: "IX_PlWords_LanguageId",
                table: "PlWords");

            migrationBuilder.DropIndex(
                name: "IX_PlWords_PartOfSpeechId",
                table: "PlWords");

            migrationBuilder.DropIndex(
                name: "IX_EnWords_LanguageId",
                table: "EnWords");

            migrationBuilder.DropIndex(
                name: "IX_EnWords_PartOfSpeechId",
                table: "EnWords");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "PlWords");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "EnWords");

            migrationBuilder.RenameColumn(
                name: "PartOfSpeechId",
                table: "PlWords",
                newName: "IdLanguage");

            migrationBuilder.RenameColumn(
                name: "PartOfSpeechId",
                table: "EnWords",
                newName: "IdLanguage");
        }
    }
}
