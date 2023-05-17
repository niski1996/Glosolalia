using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Glosolalia.Data.Migrations
{
    /// <inheritdoc />
    public partial class kutang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_Language_LanguageId",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "LanguageSet");

            migrationBuilder.RenameIndex(
                name: "IX_Language_Name",
                table: "LanguageSet",
                newName: "IX_LanguageSet_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LanguageSet",
                table: "LanguageSet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_LanguageSet_LanguageId",
                table: "Words",
                column: "LanguageId",
                principalTable: "LanguageSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_LanguageSet_LanguageId",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LanguageSet",
                table: "LanguageSet");

            migrationBuilder.RenameTable(
                name: "LanguageSet",
                newName: "Language");

            migrationBuilder.RenameIndex(
                name: "IX_LanguageSet_Name",
                table: "Language",
                newName: "IX_Language_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Language_LanguageId",
                table: "Words",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
