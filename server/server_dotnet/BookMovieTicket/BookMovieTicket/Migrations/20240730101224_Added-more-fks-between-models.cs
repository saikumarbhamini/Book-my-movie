using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMovieTicket.Migrations
{
    /// <inheritdoc />
    public partial class Addedmorefksbetweenmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ScreenShowMappers_ScreenShowId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_ScreenShowMappers_ScreenId",
                table: "ScreenShowMappers");

            migrationBuilder.DropIndex(
                name: "IX_ScreenShowMappers_ShowId",
                table: "ScreenShowMappers");

            migrationBuilder.RenameColumn(
                name: "ScreenShowId",
                table: "Reservations",
                newName: "SelectedShowId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ScreenShowId",
                table: "Reservations",
                newName: "IX_Reservations_SelectedShowId");

            migrationBuilder.AddColumn<int>(
                name: "Seats",
                table: "TheatreScreens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShowId",
                table: "TheatreScreens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "Shows",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "ScreenId",
                table: "Shows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TheatreId",
                table: "Shows",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shows_ScreenId",
                table: "Shows",
                column: "ScreenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shows_TheatreId",
                table: "Shows",
                column: "TheatreId");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenShowMappers_ScreenId",
                table: "ScreenShowMappers",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenShowMappers_ShowId",
                table: "ScreenShowMappers",
                column: "ShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Shows_SelectedShowId",
                table: "Reservations",
                column: "SelectedShowId",
                principalTable: "Shows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_MovieTheaters_TheatreId",
                table: "Shows",
                column: "TheatreId",
                principalTable: "MovieTheaters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_TheatreScreens_ScreenId",
                table: "Shows",
                column: "ScreenId",
                principalTable: "TheatreScreens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Shows_SelectedShowId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_MovieTheaters_TheatreId",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_TheatreScreens_ScreenId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_ScreenId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_TheatreId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_ScreenShowMappers_ScreenId",
                table: "ScreenShowMappers");

            migrationBuilder.DropIndex(
                name: "IX_ScreenShowMappers_ShowId",
                table: "ScreenShowMappers");

            migrationBuilder.DropColumn(
                name: "Seats",
                table: "TheatreScreens");

            migrationBuilder.DropColumn(
                name: "ShowId",
                table: "TheatreScreens");

            migrationBuilder.DropColumn(
                name: "ScreenId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "TheatreId",
                table: "Shows");

            migrationBuilder.RenameColumn(
                name: "SelectedShowId",
                table: "Reservations",
                newName: "ScreenShowId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_SelectedShowId",
                table: "Reservations",
                newName: "IX_Reservations_ScreenShowId");

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "Shows",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30);

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
                name: "FK_Reservations_ScreenShowMappers_ScreenShowId",
                table: "Reservations",
                column: "ScreenShowId",
                principalTable: "ScreenShowMappers",
                principalColumn: "Id");
        }
    }
}
