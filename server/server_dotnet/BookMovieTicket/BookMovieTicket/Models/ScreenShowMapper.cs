using System.ComponentModel.DataAnnotations;

namespace BookMovieTicket.Models;

public class ScreenShowMapper
{
    public int Id { get; set; }
    
    [Required]
    public int ShowId { get; set; }
    public Show Show { get; set; } = null!;
    
    [Required]
    public int ScreenId { get; set; }
    public TheatreScreen Screen { get; set; } = null!;
}