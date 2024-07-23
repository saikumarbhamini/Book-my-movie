using BookMovieTicket.Data;
using BookMovieTicket.Models;
using Microsoft.EntityFrameworkCore;

namespace BookMovieTicket.Services;

public class MoviesService
{
    private readonly MoviesDbContext _context;
    public MoviesService(MoviesDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Movie> GetAllMovies()
    {
        return _context.Movies.AsNoTracking().ToList();
    }

    public Movie? GetMovieById(string id)
    {
        return _context
            .Movies.AsNoTracking().SingleOrDefault(p => p.ImdbId == id);
    }
}