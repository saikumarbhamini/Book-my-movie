using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookMovieTicket.Models;

public class MovieTheater
{
    public int Id { get; set; }
    [Required]
    [MaxLength(225)]
    public string? Name { get; set; }
    [MaxLength(225)]
    public string? Location { get; set; }
    [Required]
    public bool? IsOpen { get; set; }

    public ICollection<TheatreScreen> Screens { get; set; } = null!;
    public ICollection<Show> Shows { get; set; } = null!;
}