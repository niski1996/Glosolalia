using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Glosolalia.Data.Migrations
{
    /// <inheritdoc />
    public partial class EasyDB203fkforwordlang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_TranslationSet_TranslationId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_TranslationId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TranslationId",
                table: "Tags");

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

            migrationBuilder.CreateIndex(
                name: "IX_TagTranslation_TranslationSetId",
                table: "TagTranslation",
                column: "TranslationSetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagTranslation");

            migrationBuilder.AddColumn<int>(
                name: "TranslationId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TranslationId",
                table: "Tags",
                column: "TranslationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_TranslationSet_TranslationId",
                table: "Tags",
                column: "TranslationId",
                principalTable: "TranslationSet",
                principalColumn: "Id");
        }
    }
}
