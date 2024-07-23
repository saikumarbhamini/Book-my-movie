using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMovieTicket.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieTheaters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: true),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    Screens = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTheaters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieIdImdbId = table.Column<string>(type: "varchar(30)", nullable: false),
                    ShowTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shows_Movies_MovieIdImdbId",
                        column: x => x.MovieIdImdbId,
                        principalTable: "Movies",
                        principalColumn: "imdb_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TheatreScreens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreenName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TheaterIdId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheatreScreens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheatreScreens_MovieTheaters_TheaterIdId",
                        column: x => x.TheaterIdId,
                        principalTable: "MovieTheaters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TicketPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ShowId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketPrices_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScreenShowMappers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowId = table.Column<int>(type: "int", nullable: true),
                    ScreenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenShowMappers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScreenShowMappers_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScreenShowMappers_TheatreScreens_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "TheatreScreens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreenIdId = table.Column<int>(type: "int", nullable: false),
                    Row = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_TheatreScreens_ScreenIdId",
                        column: x => x.ScreenIdId,
                        principalTable: "TheatreScreens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdId = table.Column<string>(type: "char(32)", nullable: true),
                    ScreenShowIdId = table.Column<int>(type: "int", nullable: true),
                    ReservationCode = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_ScreenShowMappers_ScreenShowIdId",
                        column: x => x.ScreenShowIdId,
                        principalTable: "ScreenShowMappers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_user_data_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "user_data",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ReservationSeat",
                columns: table => new
                {
                    ReservationsId = table.Column<int>(type: "int", nullable: false),
                    SeatsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationSeat", x => new { x.ReservationsId, x.SeatsId });
                    table.ForeignKey(
                        name: "FK_ReservationSeat_Reservations_ReservationsId",
                        column: x => x.ReservationsId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationSeat_Seats_SeatsId",
                        column: x => x.SeatsId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ScreenShowIdId",
                table: "Reservations",
                column: "ScreenShowIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserIdId",
                table: "Reservations",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationSeat_SeatsId",
                table: "ReservationSeat",
                column: "SeatsId");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenShowMappers_ScreenId",
                table: "ScreenShowMappers",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenShowMappers_ShowId",
                table: "ScreenShowMappers",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_ScreenIdId",
                table: "Seats",
                column: "ScreenIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_MovieIdImdbId",
                table: "Shows",
                column: "MovieIdImdbId");

            migrationBuilder.CreateIndex(
                name: "IX_TheatreScreens_TheaterIdId",
                table: "TheatreScreens",
                column: "TheaterIdId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPrices_ShowId",
                table: "TicketPrices",
                column: "ShowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationSeat");

            migrationBuilder.DropTable(
                name: "TicketPrices");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "ScreenShowMappers");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "TheatreScreens");

            migrationBuilder.DropTable(
                name: "MovieTheaters");
        }
    }
}
