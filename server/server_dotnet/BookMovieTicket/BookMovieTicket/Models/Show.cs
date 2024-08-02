using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookMovieTicket.Models;

public class Show
{
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string? MovieId { get; set; }

    public Movie Movie { get; set; } = null!;
    
    [Required]
    public DateTime ShowTime { get; set; }
    public int ScreenId { get; set; }
    public TheatreScreen Screen { get; set; } = null!;
    
    public int TheatreId { get; set; }
    public MovieTheater Theatre { get; set; } = null!;
    
    public ICollection<Reservation> Reservations { get; set; } = null!;
}