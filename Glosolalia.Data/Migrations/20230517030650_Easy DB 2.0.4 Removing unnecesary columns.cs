using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Glosolalia.Data.Migrations
{
    /// <inheritdoc />
    public partial class EasyDB204Removingunnecesarycolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageTranslation");

            migrationBuilder.DropIndex(
                name: "IX_Words_LanguageId",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "TranslationSet");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Words",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SheetSet",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Language",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Words_LanguageId_Value",
                table: "Words",
                columns: new[] { "LanguageId", "Value" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SheetSet_Name",
                table: "SheetSet",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Language_Name",
                table: "Language",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Words_LanguageId_Value",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_SheetSet_Name",
                table: "SheetSet");

            migrationBuilder.DropIndex(
                name: "IX_Language_Name",
                table: "Language");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Words",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "TranslationSet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SheetSet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Language",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
                        name: "FK_LanguageTranslation_TranslationSet_TranslationSetId",
                        column: x => x.TranslationSetId,
                        principalTable: "TranslationSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Words_LanguageId",
                table: "Words",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageTranslation_TranslationSetId",
                table: "LanguageTranslation",
                column: "TranslationSetId");
        }
    }
}
