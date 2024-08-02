using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMovieTicket.Migrations
{
    /// <inheritdoc />
    public partial class RenamedcolumnnameTheaterIdtoTheatreId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheatreScreens_MovieTheaters_TheaterId",
                table: "TheatreScreens");

            migrationBuilder.RenameColumn(
                name: "TheaterId",
                table: "TheatreScreens",
                newName: "TheatreId");

            migrationBuilder.RenameIndex(
                name: "IX_TheatreScreens_TheaterId",
                table: "TheatreScreens",
                newName: "IX_TheatreScreens_TheatreId");

            migrationBuilder.AddForeignKey(
                name: "FK_TheatreScreens_MovieTheaters_TheatreId",
                table: "TheatreScreens",
                column: "TheatreId",
                principalTable: "MovieTheaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheatreScreens_MovieTheaters_TheatreId",
                table: "TheatreScreens");

            migrationBuilder.RenameColumn(
                name: "TheatreId",
                table: "TheatreScreens",
                newName: "TheaterId");

            migrationBuilder.RenameIndex(
                name: "IX_TheatreScreens_TheatreId",
                table: "TheatreScreens",
                newName: "IX_TheatreScreens_TheaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_TheatreScreens_MovieTheaters_TheaterId",
                table: "TheatreScreens",
                column: "TheaterId",
                principalTable: "MovieTheaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
