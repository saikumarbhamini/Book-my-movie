using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookMovieTicket.Models;

public class TheatreScreen
{
    public int Id { get; set; }
    [MaxLength(20)]
    public string? ScreenName { get; set; }
    
    public int Seats { get; set; }
    
    public int TheatreId { get; set; }
    
    [JsonIgnore]
    public MovieTheater? Theatre { get; set; }
    public int ShowId { get; set; }
    [JsonIgnore]
    public Show MovieShow { get; set; } = null!;
}