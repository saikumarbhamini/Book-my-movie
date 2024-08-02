using BookMovieTicket.Data;
using BookMovieTicket.Models;
using Microsoft.EntityFrameworkCore;

namespace BookMovieTicket.Services;

public class MoviesService(MoviesDbContext context)
{
    private readonly MoviesDbContext _context=context;

    public IEnumerable<Movie> GetAllMovies()
    {
        return _context.Movies
            .Include(p => p.MovieDetail)
            .Include(p => p.MovieRating)
            .Include(p => p.AdditionalInfo)
            .AsNoTracking()
            .ToList();
    }

    public Movie? GetMovieById(string id)
    {
        return _context
            .Movies
            .Include(p => p.MovieDetail)
            .Include(p => p.MovieRating)
            .Include(p => p.AdditionalInfo)
            .AsNoTracking()
            .SingleOrDefault(p => p.ImdbId == id);
    }

    public MovieDetail? GetMovieDetail(string id)
    {
        return _context.MovieDetails
            .AsNoTracking()
            .SingleOrDefault(p => p.ImdbId == id);
    }

    public MovieRating? GetMovieRating(string id)
    {
        return _context.MovieRatings
            .AsNoTracking()
            .SingleOrDefault(p => p.ImdbId == id);
    }
}