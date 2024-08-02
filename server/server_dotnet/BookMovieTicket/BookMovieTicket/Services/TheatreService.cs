using BookMovieTicket.Data;
using BookMovieTicket.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookMovieTicket.Services;

public class TheatreService(MoviesDbContext context)
{
    private readonly MoviesDbContext _context=context;

    public ICollection<MovieTheater> GetMovieTheaters()
    {
        return _context.MovieTheaters
            .Include(m => m.Screens)
            .AsNoTracking()
            .ToList();
    }
    
    public MovieTheater? GetMovieTheatre(int id)
    {
        return _context
            .MovieTheaters
            .Include(m => m.Screens)
            .Include(m => m.Shows)
            .AsNoTracking()
            .SingleOrDefault(t => t.Id == id);
    }

    public MovieTheater? Create(MovieTheater theater)
    {
        _context.MovieTheaters.Add(theater);
        _context.SaveChanges();
        return theater;
    }

    public MovieTheater? Update(int id, MovieTheater theater)
    {
        var theatreToUpdate = _context.MovieTheaters.Find(id);
        if (theatreToUpdate is null)
        {
            throw new InvalidOperationException($"Theatre with id {id} doesn't exist");
        }
        _context.MovieTheaters.Update(theater);
        _context.SaveChanges();
        return theater;
    }

    public ICollection<TheatreScreen> GetScreens()
    {
        return _context.TheatreScreens.AsNoTracking().ToList();
    }

    public TheatreScreen? Create(TheatreScreen theatreScreen)
    {
        
        _context.TheatreScreens.Add(theatreScreen);
        _context.SaveChanges();
        return theatreScreen;
    }

    public TheatreScreen? GetTheatreScreen(int id)
    {
        var screen = _context
            .TheatreScreens
            .Include(t => t.Theatre)
            .AsNoTracking()
            .SingleOrDefault(s => s.Id == id);
        return screen;
    }

    public ICollection<Show> GetShows(string movieId)
    {
        var shows = _context.Shows
            .Include(s => s.Movie)
            .Include(t => t.Screen)
            .Where(s => s.Movie.ImdbId == movieId)
            .AsNoTracking()
            .ToList();
        return shows;
    }

    public Show? GetShow(int showId)
    {
        var show = _context.Shows
            .Include(s => s.Movie)
            .Include(s => s.Movie.MovieDetail)
            .Include(s => s.Theatre)
            .AsNoTracking()
            .SingleOrDefault(s => s.Id == showId);
        return show;
    }

    public Show CreateShow(Show show)
    {
        _context.Shows.Add(show);
        _context.SaveChanges();
        return show;
    }
}