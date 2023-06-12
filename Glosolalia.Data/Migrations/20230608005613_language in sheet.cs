using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Glosolalia.Data.Migrations
{
    /// <inheritdoc />
    public partial class languageinsheet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageOneId",
                table: "SheetSet",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "LanguageTwoId",
                table: "SheetSet",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_SheetSet_LanguageOneId",
                table: "SheetSet",
                column: "LanguageOneId");

            migrationBuilder.CreateIndex(
                name: "IX_SheetSet_LanguageTwoId",
                table: "SheetSet",
                column: "LanguageTwoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SheetSet_LanguageSet_LanguageOneId",
                table: "SheetSet",
                column: "LanguageOneId",
                principalTable: "LanguageSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SheetSet_LanguageSet_LanguageTwoId",
                table: "SheetSet",
                column: "LanguageTwoId",
                principalTable: "LanguageSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SheetSet_LanguageSet_LanguageOneId",
                table: "SheetSet");

            migrationBuilder.DropForeignKey(
                name: "FK_SheetSet_LanguageSet_LanguageTwoId",
                table: "SheetSet");

            migrationBuilder.DropIndex(
                name: "IX_SheetSet_LanguageOneId",
                table: "SheetSet");

            migrationBuilder.DropIndex(
                name: "IX_SheetSet_LanguageTwoId",
                table: "SheetSet");

            migrationBuilder.DropColumn(
                name: "LanguageOneId",
                table: "SheetSet");

            migrationBuilder.DropColumn(
                name: "LanguageTwoId",
                table: "SheetSet");
        }
    }
}
