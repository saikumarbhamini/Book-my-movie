namespace BookMovieTicket.Models;

public class ScreenShowMapper
{
    public int Id { get; set; }
    public Show? Show { get; set; }
    public TheatreScreen? Screen { get; set; }
}