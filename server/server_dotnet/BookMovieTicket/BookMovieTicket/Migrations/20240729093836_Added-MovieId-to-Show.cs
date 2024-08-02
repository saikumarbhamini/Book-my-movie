using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMovieTicket.Migrations
{
    /// <inheritdoc />
    public partial class AddedMovieIdtoShow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Movies_MovieImdbId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_MovieImdbId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "MovieImdbId",
                table: "Shows");

            migrationBuilder.AddColumn<string>(
                name: "MovieId",
                table: "Shows",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_MovieId",
                table: "Shows",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Movies_MovieId",
                table: "Shows",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "imdb_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Movies_MovieId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_MovieId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Shows");

            migrationBuilder.AddColumn<string>(
                name: "MovieImdbId",
                table: "Shows",
                type: "varchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_MovieImdbId",
                table: "Shows",
                column: "MovieImdbId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Movies_MovieImdbId",
                table: "Shows",
                column: "MovieImdbId",
                principalTable: "Movies",
                principalColumn: "imdb_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
