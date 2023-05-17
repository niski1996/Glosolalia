using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Glosolalia.Data.Migrations
{
    /// <inheritdoc />
    public partial class EasyDB202identitykeypropissue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_TranslationSet_TranslationId",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Words_TranslationId",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "TranslationId",
                table: "Words");

            migrationBuilder.CreateTable(
                name: "TranslationWord",
                columns: table => new
                {
                    TranslatableSetId = table.Column<int>(type: "int", nullable: false),
                    TranslationSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationWord", x => new { x.TranslatableSetId, x.TranslationSetId });
                    table.ForeignKey(
                        name: "FK_TranslationWord_TranslationSet_TranslationSetId",
                        column: x => x.TranslationSetId,
                        principalTable: "TranslationSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TranslationWord_Words_TranslatableSetId",
                        column: x => x.TranslatableSetId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TranslationWord_TranslationSetId",
                table: "TranslationWord",
                column: "TranslationSetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TranslationWord");

            migrationBuilder.AddColumn<int>(
                name: "TranslationId",
                table: "Words",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Words_TranslationId",
                table: "Words",
                column: "TranslationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_TranslationSet_TranslationId",
                table: "Words",
                column: "TranslationId",
                principalTable: "TranslationSet",
                principalColumn: "Id");
        }
    }
}
