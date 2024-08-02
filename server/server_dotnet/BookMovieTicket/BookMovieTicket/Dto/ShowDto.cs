using BookMovieTicket.Models;

namespace BookMovieTicket.Dto;

public class CreateShowDto
{
    public int Id { get; set; }
    
    public string MovieId { get; set; } = null!;
   
    public DateTime ShowTime { get; set; }
    
    public int ScreenId { get; set; }
    public int TheatreId { get; set; }
    
}

public class ShowDto
{
    public int Id { get; set; }
    
    public Movie Movie { get; set; } = null!;
   
    public DateTime ShowTime { get; set; }
    
    public int ScreenId { get; set; }
    public MovieTheater? Theatre { get; set; } = null!;
}