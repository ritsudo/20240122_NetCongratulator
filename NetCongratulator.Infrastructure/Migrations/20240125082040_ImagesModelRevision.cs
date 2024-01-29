using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCongratulator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImagesModelRevision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCards_Avatars_AvatarId",
                table: "UserCards");

            migrationBuilder.DropTable(
                name: "Avatars");

            migrationBuilder.DropIndex(
                name: "IX_UserCards_AvatarId",
                table: "UserCards");

            migrationBuilder.DropColumn(
                name: "AvatarId",
                table: "UserCards");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "UserCards",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "UserCards");

            migrationBuilder.AddColumn<int>(
                name: "AvatarId",
                table: "UserCards",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Avatars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AvatarBlob = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avatars", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCards_AvatarId",
                table: "UserCards",
                column: "AvatarId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCards_Avatars_AvatarId",
                table: "UserCards",
                column: "AvatarId",
                principalTable: "Avatars",
                principalColumn: "Id");
        }
    }
}
