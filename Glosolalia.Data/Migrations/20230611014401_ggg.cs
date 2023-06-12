using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Glosolalia.Data.Migrations
{
    /// <inheritdoc />
    public partial class ggg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SheetSet_LanguageSet_LanguageOneId",
                table: "SheetSet");

            migrationBuilder.DropForeignKey(
                name: "FK_SheetSet_LanguageSet_LanguageTwoId",
                table: "SheetSet");

            migrationBuilder.AddForeignKey(
                name: "FK_SheetSet_LanguageSet_LanguageOneId",
                table: "SheetSet",
                column: "LanguageOneId",
                principalTable: "LanguageSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SheetSet_LanguageSet_LanguageTwoId",
                table: "SheetSet",
                column: "LanguageTwoId",
                principalTable: "LanguageSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.AddForeignKey(
                name: "FK_SheetSet_LanguageSet_LanguageOneId",
                table: "SheetSet",
                column: "LanguageOneId",
                principalTable: "LanguageSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SheetSet_LanguageSet_LanguageTwoId",
                table: "SheetSet",
                column: "LanguageTwoId",
                principalTable: "LanguageSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
