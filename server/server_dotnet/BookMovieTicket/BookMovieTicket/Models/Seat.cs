using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookMovieTicket.Models;

public class Seat
{
    public int Id { get; set; }
    [Required]
    public TheatreScreen? ScreenId { get; set; }
    [Required]
    [MaxLength(10)]
    public string? Row { get; set; }
    [Required]
    public int Number { get; set; }
    [Required]
    public bool Status { get; set; }
    
    [JsonIgnore]
    public ICollection<Reservation>? Reservations { get; set; }
    
}