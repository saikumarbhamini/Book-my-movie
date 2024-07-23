using System.ComponentModel.DataAnnotations;

namespace BookMovieTicket.Models;

public class TheatreScreen
{
    public int Id { get; set; }
    [MaxLength(20)]
    public string? ScreenName { get; set; }
    public MovieTheater? TheaterId { get; set; }
}