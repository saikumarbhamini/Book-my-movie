using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMovieTicket.Migrations
{
    /// <inheritdoc />
    public partial class AddScreenAsCollectionToTheatre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheatreScreens_MovieTheaters_TheaterId",
                table: "TheatreScreens");

            migrationBuilder.DropColumn(
                name: "Screens",
                table: "MovieTheaters");

            migrationBuilder.AlterColumn<int>(
                name: "TheaterId",
                table: "TheatreScreens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TheatreScreens_MovieTheaters_TheaterId",
                table: "TheatreScreens",
                column: "TheaterId",
                principalTable: "MovieTheaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheatreScreens_MovieTheaters_TheaterId",
                table: "TheatreScreens");

            migrationBuilder.AlterColumn<int>(
                name: "TheaterId",
                table: "TheatreScreens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Screens",
                table: "MovieTheaters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TheatreScreens_MovieTheaters_TheaterId",
                table: "TheatreScreens",
                column: "TheaterId",
                principalTable: "MovieTheaters",
                principalColumn: "Id");
        }
    }
}
