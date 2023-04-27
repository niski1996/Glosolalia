using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Glosolalia.Data.Migrations
{
    /// <inheritdoc />
    public partial class CtorChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastInput",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Progress",
                table: "Languages");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastInput",
                table: "PlWords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Progress",
                table: "PlWords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastInput",
                table: "EnWords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Progress",
                table: "EnWords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastInput",
                table: "PlWords");

            migrationBuilder.DropColumn(
                name: "Progress",
                table: "PlWords");

            migrationBuilder.DropColumn(
                name: "LastInput",
                table: "EnWords");

            migrationBuilder.DropColumn(
                name: "Progress",
                table: "EnWords");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastInput",
                table: "Languages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Progress",
                table: "Languages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
