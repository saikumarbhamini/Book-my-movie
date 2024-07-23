using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookMovieTicket.Models;

public class Show
{
    public int Id { get; set; }
    [Required]
    public Movie? MovieId { get; set; }
    
    [Required]
    public DateTime ShowTime { get; set; }
}