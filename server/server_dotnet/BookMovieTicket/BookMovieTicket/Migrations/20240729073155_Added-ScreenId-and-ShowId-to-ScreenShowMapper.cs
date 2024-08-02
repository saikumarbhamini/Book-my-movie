using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMovieTicket.Migrations
{
    /// <inheritdoc />
    public partial class AddedScreenIdandShowIdtoScreenShowMapper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScreenShowMappers_Shows_ShowId",
                table: "ScreenShowMappers");

            migrationBuilder.DropForeignKey(
                name: "FK_ScreenShowMappers_TheatreScreens_ScreenId",
                table: "ScreenShowMappers");

            migrationBuilder.DropIndex(
                name: "IX_ScreenShowMappers_ScreenId",
                table: "ScreenShowMappers");

            migrationBuilder.DropIndex(
                name: "IX_ScreenShowMappers_ShowId",
                table: "ScreenShowMappers");

            migrationBuilder.AlterColumn<int>(
                name: "ShowId",
                table: "ScreenShowMappers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ScreenId",
                table: "ScreenShowMappers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScreenShowMappers_ScreenId",
                table: "ScreenShowMappers",
                column: "ScreenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScreenShowMappers_ShowId",
                table: "ScreenShowMappers",
                column: "ShowId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ScreenShowMappers_Shows_ShowId",
                table: "ScreenShowMappers",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScreenShowMappers_TheatreScreens_ScreenId",
                table: "ScreenShowMappers",
                column: "ScreenId",
                principalTable: "TheatreScreens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScreenShowMappers_Shows_ShowId",
                table: "ScreenShowMappers");

            migrationBuilder.DropForeignKey(
                name: "FK_ScreenShowMappers_TheatreScreens_ScreenId",
                table: "ScreenShowMappers");

            migrationBuilder.DropIndex(
                name: "IX_ScreenShowMappers_ScreenId",
                table: "ScreenShowMappers");

            migrationBuilder.DropIndex(
                name: "IX_ScreenShowMappers_ShowId",
                table: "ScreenShowMappers");

            migrationBuilder.AlterColumn<int>(
                name: "ShowId",
                table: "ScreenShowMappers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ScreenId",
                table: "ScreenShowMappers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenShowMappers_ScreenId",
                table: "ScreenShowMappers",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenShowMappers_ShowId",
                table: "ScreenShowMappers",
                column: "ShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScreenShowMappers_Shows_ShowId",
                table: "ScreenShowMappers",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScreenShowMappers_TheatreScreens_ScreenId",
                table: "ScreenShowMappers",
                column: "ScreenId",
                principalTable: "TheatreScreens",
                principalColumn: "Id");
        }
    }
}
