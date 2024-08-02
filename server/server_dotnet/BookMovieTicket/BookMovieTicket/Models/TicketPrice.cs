using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookMovieTicket.Models;

public class TicketPrice
{
    public int Id { get; set; }
    [Required]
    [MaxLength(20)]
    public string? Class { get; set; }
    [Required]
    [JsonIgnore]
    public Show? Show { get; set; }
    [Required]
    public float Price { get; set; }
}