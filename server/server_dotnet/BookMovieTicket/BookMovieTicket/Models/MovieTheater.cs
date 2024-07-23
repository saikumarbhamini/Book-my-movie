using System.ComponentModel.DataAnnotations;

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
    
    [Required]
    public int Screens { get; set; }
}